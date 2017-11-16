namespace Server
{
    using Server.Accounting;
    using Server.ContextMenus;
    using Server.Guilds;
    using Server.Gumps;
    using Server.HuePickers;
    using Server.Items;
    using Server.Menus;
    using Server.Mobiles;
    using Server.Movement;
    using Server.Network;
    using Server.Prompts;
    using Server.Targeting;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Mobile : IEntity, IPoint3D, IPoint2D, IHued
    {
        // Methods
        static Mobile()
        {
            Mobile.m_DragEffects = true;
            Mobile.WarmodeSpamCatch = TimeSpan.FromSeconds(0.5);
            Mobile.WarmodeSpamDelay = TimeSpan.FromSeconds(2);
            Mobile.m_MaxPlayerResistance = 70;
            Mobile.m_ActionMessageDelay = TimeSpan.FromSeconds(0.125);
            Mobile.m_ExpireCriminalDelay = TimeSpan.FromMinutes(2);
            Mobile.m_MovingPacketCache = new MobileMoving[8];
            Mobile.m_WalkFoot = TimeSpan.FromSeconds(0.4);
            Mobile.m_RunFoot = TimeSpan.FromSeconds(0.2);
            Mobile.m_WalkMount = TimeSpan.FromSeconds(0.2);
            Mobile.m_RunMount = TimeSpan.FromSeconds(0.1);
            Mobile.m_MoveList = new ArrayList();
            Mobile.m_FwdAccessOverride = AccessLevel.GameMaster;
            Mobile.m_FwdEnabled = true;
            Mobile.m_FwdUOTDOverride = false;
            Mobile.m_FwdMaxSteps = 4;
            char[] chArray1 = new char[2];
            chArray1[0] = 'o';
            chArray1[1] = 'O';
            Mobile.m_GhostChars = chArray1;
            Mobile.m_AutoManifestTimeout = TimeSpan.FromSeconds(5);
            Mobile.m_GhostMutateContext = new object();
            string[] textArray1 = new string[5];
            textArray1[0] = "a player";
            textArray1[1] = "a counselor";
            textArray1[2] = "a game master";
            textArray1[3] = "a seer";
            textArray1[4] = "an administrator";
            Mobile.m_AccessLevelNames = textArray1;
            Mobile.m_InvalidBodies = new int[8] { 32, 95, 156, 169, 196, 197, 198, 199 };
            Mobile.m_DeltaQueue = new Queue();
            Mobile.m_BodyWeight = 14;
            textArray1 = new string[3];
            textArray1[0] = "";
            textArray1[1] = " (Chaos)";
            textArray1[2] = " (Order)";
            Mobile.m_GuildTypes = textArray1;
            Mobile.m_DisableHiddenSelfClick = true;
            Mobile.m_AsciiClickMessage = true;
            Mobile.m_GuildClickMessage = true;
        }

        public Mobile()
        {
            this.m_NameHue = -1;
            this.m_WarmodeChanges = 0;
            this.m_SkillMods = new ArrayList(1);
            this.m_HueMod = -1;
            this.m_SolidHueOverride = -1;
            this.m_Region = Map.Internal.DefaultRegion;
            this.m_Serial = Serial.NewMobile;
            this.DefaultMobileInit();
            World.AddMobile(this);
        }

        public Mobile(Serial serial)
        {
            this.m_NameHue = -1;
            this.m_WarmodeChanges = 0;
            this.m_SkillMods = new ArrayList(1);
            this.m_HueMod = -1;
            this.m_SolidHueOverride = -1;
            this.m_Region = Map.Internal.DefaultRegion;
            this.m_Serial = serial;
            this.m_ExpireCombatant = new ExpireCombatantTimer(this);
            this.m_ExpireCriminal = new ExpireCriminalTimer(this);
            this.m_CombatTimer = new CombatTimer(this);
            this.m_Aggressors = new ArrayList(1);
            this.m_Aggressed = new ArrayList(1);
            this.m_NextSkillTime = DateTime.MinValue;
            this.m_DamageEntries = new ArrayList(1);
            this.m_LogoutTimer = new LogoutTimer(this);
        }

        public void AddItem(Item item)
        {
            if ((item == null) || item.Deleted)
            {
                return;
            }
            if (item.Parent == this)
            {
                return;
            }
            if ((item.Parent is Mobile))
            {
                ((Mobile) item.Parent).RemoveItem(item);
            }
            else if ((item.Parent is Item))
            {
                ((Item) item.Parent).RemoveItem(item);
            }
            else
            {
                item.SendRemovePacket();
            }
            item.Parent = this;
            item.Map = this.m_Map;
            this.m_Items.Add(item);
            if (!(item is BankBox))
            {
                this.TotalWeight += (item.TotalWeight + item.PileWeight);
                this.TotalGold += item.TotalGold;
            }
            item.Delta(ItemDelta.Update);
            item.OnAdded(this);
            this.OnItemAdded(item);
            if (((item.PhysicalResistance != 0) || (item.FireResistance != 0)) || (((item.ColdResistance != 0) || (item.PoisonResistance != 0)) || (item.EnergyResistance != 0)))
            {
                this.UpdateResistances();
            }
        }

        public virtual void AddNameProperties(ObjectPropertyList list)
        {
            string text4;
            string text1 = this.Name;
            if (text1 == null)
            {
                text1 = string.Empty;
            }
            string text2 = "";
            if ((this.ShowFameTitle && (this.m_Player || this.m_Body.IsHuman)) && (this.m_Fame >= 10000))
            {
                text2 = (this.m_Female ? "Lady" : "Lord");
            }
            string text3 = "";
            if ((this.ClickTitle && (this.Title != null)) && (this.Title.Length > 0))
            {
                text3 = this.Title;
            }
            BaseGuild guild1 = this.m_Guild;
            if ((guild1 != null) && (this.m_Player || this.m_DisplayGuildTitle))
            {
                if (text3.Length > 0)
                {
                    text3 = string.Format("{0} [{1}]", text3, Utility.FixHtml(guild1.Abbreviation));
                }
                else
                {
                    text3 = string.Format("[{0}]", Utility.FixHtml(guild1.Abbreviation));
                }
            }
            list.Add(1050045, "{0} \t{1}\t {2}", text2, text1, text3);
            if ((guild1 == null) || (!this.m_DisplayGuildTitle && (!this.m_Player || (guild1.Type == GuildType.Regular))))
            {
                return;
            }
            if ((guild1.Type >= GuildType.Regular) && (guild1.Type < Mobile.m_GuildTypes.Length))
            {
                text4 = Mobile.m_GuildTypes[guild1.Type];
            }
            else
            {
                text4 = "";
            }
            string text5 = this.GuildTitle;
            if (text5 == null)
            {
                text5 = "";
            }
            else
            {
                text5 = text5.Trim();
            }
            if (text5.Length > 0)
            {
                list.Add("{0}, {1} Guild{2}", Utility.FixHtml(text5), Utility.FixHtml(guild1.Name), text4);
                return;
            }
            list.Add(Utility.FixHtml(guild1.Name));
        }

        public virtual void AddResistanceMod(ResistanceMod toAdd)
        {
            if (this.m_ResistMods == null)
            {
                this.m_ResistMods = new ArrayList(2);
            }
            this.m_ResistMods.Add(toAdd);
            this.UpdateResistances();
        }

        public virtual void AddSkillMod(SkillMod mod)
        {
            Skill skill1;
            if (mod == null)
            {
                return;
            }
            this.ValidateSkillMods();
            if (!this.m_SkillMods.Contains(mod))
            {
                this.m_SkillMods.Add(mod);
                mod.Owner = this;
                skill1 = this.m_Skills[mod.Skill];
                if (skill1 != null)
                {
                    skill1.Update();
                }
            }
        }

        private void AddSpeechItemsFrom(ArrayList list, Container cont)
        {
            int num1;
            Item item1;
            for (num1 = 0; (num1 < cont.Items.Count); ++num1)
            {
                item1 = ((Item) cont.Items[num1]);
                if (item1.HandlesOnSpeech)
                {
                    list.Add(item1);
                }
                if ((item1 is Container))
                {
                    this.AddSpeechItemsFrom(list, ((Container) item1));
                }
            }
        }

        public void AddStatMod(StatMod mod)
        {
            int num1;
            StatMod mod1;
            for (num1 = 0; (num1 < this.m_StatMods.Count); ++num1)
            {
                mod1 = ((StatMod) this.m_StatMods[num1]);
                if (mod1.Name == mod.Name)
                {
                    this.Delta(MobileDelta.Stat);
                    this.m_StatMods.RemoveAt(num1);
                    break;
                }
            }
            this.m_StatMods.Add(mod);
            this.Delta(MobileDelta.Stat);
            this.CheckStatTimers();
        }

        public bool AddToBackpack(Item item)
        {
            if (item.Deleted)
            {
                return false;
            }
            if (!this.PlaceInBackpack(item))
            {
                item.MoveToWorld(this.Location, this.Map);
                return false;
            }
            return true;
        }

        public virtual void AggressiveAction(Mobile aggressor)
        {
            this.AggressiveAction(aggressor, false);
        }

        public virtual void AggressiveAction(Mobile aggressor, bool criminal)
        {
            int num1;
            AggressorInfo info1;
            int num2;
            AggressorInfo info2;
            int num3;
            AggressorInfo info3;
            int num4;
            AggressorInfo info4;
            if (aggressor == this)
            {
                return;
            }
            AggressiveActionEventArgs args1 = AggressiveActionEventArgs.Create(this, aggressor, criminal);
            EventSink.InvokeAggressiveAction(args1);
            args1.Free();
            if (this.Combatant == aggressor)
            {
                this.m_ExpireCombatant.Stop();
                this.m_ExpireCombatant.Start();
            }
            bool flag1 = true;
            ArrayList list1 = this.m_Aggressors;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                info1 = ((AggressorInfo) list1[num1]);
                if (info1.Attacker == aggressor)
                {
                    info1.Refresh();
                    info1.CriminalAggression = criminal;
                    info1.CanReportMurder = criminal;
                    flag1 = false;
                }
            }
            list1 = aggressor.m_Aggressors;
            for (num2 = 0; (num2 < list1.Count); ++num2)
            {
                info2 = ((AggressorInfo) list1[num2]);
                if (info2.Attacker == this)
                {
                    info2.Refresh();
                    flag1 = false;
                }
            }
            bool flag2 = true;
            list1 = this.m_Aggressed;
            for (num3 = 0; (num3 < list1.Count); ++num3)
            {
                info3 = ((AggressorInfo) list1[num3]);
                if (info3.Defender == aggressor)
                {
                    info3.Refresh();
                    flag2 = false;
                }
            }
            list1 = aggressor.m_Aggressed;
            for (num4 = 0; (num4 < list1.Count); ++num4)
            {
                info4 = ((AggressorInfo) list1[num4]);
                if (info4.Defender == this)
                {
                    info4.Refresh();
                    info4.CriminalAggression = criminal;
                    info4.CanReportMurder = criminal;
                    flag2 = false;
                }
            }
            bool flag3 = false;
            if (flag1)
            {
                this.m_Aggressors.Add(AggressorInfo.Create(aggressor, this, criminal));
                if (this.CanSee(aggressor) && (this.m_NetState != null))
                {
                    this.m_NetState.Send(new MobileIncoming(this, aggressor));
                }
                if (this.Combatant == null)
                {
                    flag3 = true;
                }
                this.UpdateAggrExpire();
            }
            if (flag2)
            {
                aggressor.m_Aggressed.Add(AggressorInfo.Create(aggressor, this, criminal));
                if (this.CanSee(aggressor) && (this.m_NetState != null))
                {
                    this.m_NetState.Send(new MobileIncoming(this, aggressor));
                }
                if (this.Combatant == null)
                {
                    flag3 = true;
                }
                this.UpdateAggrExpire();
            }
            if (flag3)
            {
                this.Combatant = aggressor;
            }
            this.Region.OnAggressed(aggressor, this, criminal);
        }

        public virtual bool AllowItemUse(Item item)
        {
            return true;
        }

        public virtual bool AllowSkillUse(SkillName name)
        {
            return true;
        }

        public virtual void Animate(int action, int frameCount, int repeatCount, bool forward, bool repeat, int delay)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return;
            }
            this.ProcessDelta();
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = map1.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if (state1.Mobile.CanSee(this))
                {
                    state1.Mobile.ProcessDelta();
                    if (packet1 == null)
                    {
                        packet1 = new MobileAnimation(this, action, frameCount, repeatCount, forward, repeat, delay);
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public virtual ApplyPoisonResult ApplyPoison(Mobile from, Poison poison)
        {
            if (poison == null)
            {
                this.CurePoison(from);
                return ApplyPoisonResult.Cured;
            }
            if (this.CheckHigherPoison(from, poison))
            {
                this.OnHigherPoison(from, poison);
                return ApplyPoisonResult.HigherPoisonActive;
            }
            if (this.CheckPoisonImmunity(from, poison))
            {
                this.OnPoisonImmunity(from, poison);
                return ApplyPoisonResult.Immune;
            }
            Poison poison1 = this.m_Poison;
            this.Poison = poison;
            this.OnPoisoned(from, poison, poison1);
            return ApplyPoisonResult.Poisoned;
        }

        public virtual void Attack(Mobile m)
        {
            if (this.CheckAttack(m))
            {
                this.Combatant = m;
            }
        }

        public bool BeginAction(object toLock)
        {
            if (this.m_Actions == null)
            {
                this.m_Actions = new ArrayList(2);
                this.m_Actions.Add(toLock);
                return true;
            }
            if (!this.m_Actions.Contains(toLock))
            {
                this.m_Actions.Add(toLock);
                return true;
            }
            return false;
        }

        public Target BeginTarget(int range, bool allowGround, TargetFlags flags, TargetCallback callback)
        {
            Target target1 = new SimpleTarget(range, flags, allowGround, callback);
            this.Target = target1;
            return target1;
        }

        public Target BeginTarget(int range, bool allowGround, TargetFlags flags, TargetStateCallback callback, object state)
        {
            Target target1 = new SimpleStateTarget(range, flags, allowGround, callback, state);
            this.Target = target1;
            return target1;
        }

        public virtual bool BeneficialCheck(Mobile target)
        {
            if (this.CanBeBeneficial(target, true))
            {
                this.DoBeneficial(target);
                return true;
            }
            return false;
        }

        public void BoltEffect(int hue)
        {
            Effects.SendBoltEffect(this, true, hue);
        }

        public virtual bool CanBeBeneficial(Mobile target)
        {
            return this.CanBeBeneficial(target, true, false);
        }

        public virtual bool CanBeBeneficial(Mobile target, bool message)
        {
            return this.CanBeBeneficial(target, message, false);
        }

        public virtual bool CanBeBeneficial(Mobile target, bool message, bool allowDead)
        {
            if (target == null)
            {
                return false;
            }
            if (((this.m_Deleted || target.m_Deleted) || (!this.Alive || this.IsDeadBondedPet)) || (!allowDead && (!target.Alive || this.IsDeadBondedPet)))
            {
                if (message)
                {
                    this.SendLocalizedMessage(1001017);
                }
                return false;
            }
            if (target == this)
            {
                return true;
            }
            if (!this.Region.AllowBenificial(this, target))
            {
                if (message)
                {
                    this.SendLocalizedMessage(1001017);
                }
                return false;
            }
            return true;
        }

        public virtual bool CanBeDamaged()
        {
            return !this.m_Blessed;
        }

        public bool CanBeginAction(object toLock)
        {
            if (this.m_Actions != null)
            {
                return !this.m_Actions.Contains(toLock);
            }
            return true;
        }

        public virtual bool CanBeHarmful(Mobile target)
        {
            return this.CanBeHarmful(target, true);
        }

        public virtual bool CanBeHarmful(Mobile target, bool message)
        {
            return this.CanBeHarmful(target, message, false);
        }

        public virtual bool CanBeHarmful(Mobile target, bool message, bool ignoreOurBlessedness)
        {
            if (target == null)
            {
                return false;
            }
            if ((this.m_Deleted || (!ignoreOurBlessedness && this.m_Blessed)) || (((target.m_Deleted || target.m_Blessed) || (!this.Alive || this.IsDeadBondedPet)) || (!target.Alive || target.IsDeadBondedPet)))
            {
                if (message)
                {
                    this.SendLocalizedMessage(1001018);
                }
                return false;
            }
            if (target == this)
            {
                return true;
            }
            if (!this.Region.AllowHarmful(this, target))
            {
                if (message)
                {
                    this.SendLocalizedMessage(1001018);
                }
                return false;
            }
            return true;
        }

        public virtual bool CanBeRenamedBy(Mobile from)
        {
            return (from.m_AccessLevel > this.m_AccessLevel);
        }

        public virtual bool CanPaperdollBeOpenedBy(Mobile from)
        {
            Body body1 = this.Body;
            if (!body1.IsHuman)
            {
                body1 = this.Body;
                if (!body1.IsGhost)
                {
                    return this.IsBodyMod;
                }
            }
            return true;
        }

        public virtual bool CanSee(Item item)
        {
            BankBox box1;
            SecureTrade trade1;
            if (this.m_Map == Map.Internal)
            {
                return false;
            }
            if (item.Map == Map.Internal)
            {
                return false;
            }
            if (item.Parent != null)
            {
                if ((item.Parent is Item))
                {
                    if (!this.CanSee(((Item) item.Parent)))
                    {
                        return false;
                    }
                }
                else if ((item.Parent is Mobile) && !this.CanSee(((Mobile) item.Parent)))
                {
                    return false;
                }
            }
            if ((item is BankBox))
            {
                box1 = (item as BankBox);
                if (((box1 != null) && (this.m_AccessLevel <= AccessLevel.Counselor)) && ((box1.Owner != this) || !box1.Opened))
                {
                    return false;
                }
            }
            else if ((item is SecureTradeContainer))
            {
                trade1 = ((SecureTradeContainer) item).Trade;
                if (((trade1 != null) && (trade1.From.Mobile != this)) && (trade1.To.Mobile != this))
                {
                    return false;
                }
            }
            if (!item.Deleted && (item.Map == this.m_Map))
            {
                if (!item.Visible)
                {
                    return (this.m_AccessLevel > AccessLevel.Counselor);
                }
                return true;
            }
            return false;
        }

        public virtual bool CanSee(Mobile m)
        {
            if ((this.m_Deleted || m.m_Deleted) || ((this.m_Map == Map.Internal) || (m.m_Map == Map.Internal)))
            {
                return false;
            }
            if (this != m)
            {
                if ((m.m_Map == this.m_Map) && (!m.Hidden || (this.m_AccessLevel > m.AccessLevel)))
                {
                    if ((!m.Alive && this.Alive) && (this.m_AccessLevel <= AccessLevel.Player))
                    {
                        return m.Warmode;
                    }
                    return true;
                }
                return false;
            }
            return true;
        }

        public virtual bool CanSee(object o)
        {
            if ((o is Item))
            {
                return this.CanSee(((Item) o));
            }
            if ((o is Mobile))
            {
                return this.CanSee(((Mobile) o));
            }
            return true;
        }

        public bool CanUseStuckMenu()
        {
            int num1;
            if (this.m_StuckMenuUses == null)
            {
                return true;
            }
            for (num1 = 0; (num1 < this.m_StuckMenuUses.Length); ++num1)
            {
                if ((DateTime.Now - this.m_StuckMenuUses[num1]) > TimeSpan.FromDays(1))
                {
                    return true;
                }
            }
            return false;
        }

        private void CheckAggrExpire()
        {
            int num1;
            AggressorInfo info1;
            Mobile mobile1;
            int num2;
            AggressorInfo info2;
            Mobile mobile2;
            for (num1 = (this.m_Aggressors.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_Aggressors.Count)
                {
                    info1 = ((AggressorInfo) this.m_Aggressors[num1]);
                    if (info1.Expired)
                    {
                        mobile1 = info1.Attacker;
                        mobile1.RemoveAggressed(this);
                        this.m_Aggressors.RemoveAt(num1);
                        info1.Free();
                        if (((this.m_NetState != null) && this.CanSee(mobile1)) && Utility.InUpdateRange(this.m_Location, mobile1.m_Location))
                        {
                            this.m_NetState.Send(new MobileIncoming(this, mobile1));
                        }
                    }
                }
            }
            for (num2 = (this.m_Aggressed.Count - 1); (num2 >= 0); --num2)
            {
                if (num2 < this.m_Aggressed.Count)
                {
                    info2 = ((AggressorInfo) this.m_Aggressed[num2]);
                    if (info2.Expired)
                    {
                        mobile2 = info2.Defender;
                        mobile2.RemoveAggressor(this);
                        this.m_Aggressed.RemoveAt(num2);
                        info2.Free();
                        if (((this.m_NetState != null) && this.CanSee(mobile2)) && Utility.InUpdateRange(this.m_Location, mobile2.m_Location))
                        {
                            this.m_NetState.Send(new MobileIncoming(this, mobile2));
                        }
                    }
                }
            }
            this.UpdateAggrExpire();
        }

        public bool CheckAlive()
        {
            return this.CheckAlive(true);
        }

        public bool CheckAlive(bool message)
        {
            if (!this.Alive)
            {
                if (message)
                {
                    this.LocalOverheadMessage(MessageType.Regular, 946, 1019048);
                }
                return false;
            }
            return true;
        }

        public virtual bool CheckAttack(Mobile m)
        {
            if (Utility.InUpdateRange(this, m) && this.CanSee(m))
            {
                return this.InLOS(m);
            }
            return false;
        }

        public virtual bool CheckContextMenuDisplay(IEntity target)
        {
            return true;
        }

        public virtual bool CheckCure(Mobile from)
        {
            return true;
        }

        public virtual bool CheckEquip(Item item)
        {
            int num1;
            for (num1 = 0; (num1 < this.m_Items.Count); ++num1)
            {
                if (((Item) this.m_Items[num1]).CheckConflictingLayer(this, item, item.Layer) || item.CheckConflictingLayer(this, ((Item) this.m_Items[num1]), ((Item) this.m_Items[num1]).Layer))
                {
                    return false;
                }
            }
            return true;
        }

        public virtual bool CheckHearsMutatedSpeech(Mobile m, object context)
        {
            if (context == Mobile.m_GhostMutateContext)
            {
                if (m.Alive)
                {
                    return !m.CanHearGhosts;
                }
                return false;
            }
            return true;
        }

        public virtual bool CheckHigherPoison(Mobile from, Poison poison)
        {
            if (this.m_Poison != null)
            {
                return (this.m_Poison.Level >= poison.Level);
            }
            return false;
        }

        public virtual bool CheckItemUse(Mobile from, Item item)
        {
            return true;
        }

        public virtual bool CheckLift(Mobile from, Item item)
        {
            return true;
        }

        public virtual void CheckLightLevels(bool forceResend)
        {
        }

        public virtual bool CheckMovement(Direction d, out int newZ)
        {
            return Movement.CheckMovement(this, d, out newZ);
        }

        public virtual bool CheckNonlocalDrop(Mobile from, Item item, Item target)
        {
            if ((from == this) || ((from.AccessLevel > this.AccessLevel) && (from.AccessLevel >= AccessLevel.GameMaster)))
            {
                return true;
            }
            return false;
        }

        public virtual bool CheckNonlocalLift(Mobile from, Item item)
        {
            if ((from == this) || ((from.AccessLevel > this.AccessLevel) && (from.AccessLevel >= AccessLevel.GameMaster)))
            {
                return true;
            }
            return false;
        }

        public virtual bool CheckPoisonImmunity(Mobile from, Poison poison)
        {
            return false;
        }

        public virtual bool CheckResurrect()
        {
            return true;
        }

        public bool CheckSkill(SkillName skill, double chance)
        {
            if (Mobile.m_SkillCheckDirectLocationHandler == null)
            {
                return false;
            }
            return Mobile.m_SkillCheckDirectLocationHandler.Invoke(this, skill, chance);
        }

        public bool CheckSkill(SkillName skill, double minSkill, double maxSkill)
        {
            if (Mobile.m_SkillCheckLocationHandler == null)
            {
                return false;
            }
            return Mobile.m_SkillCheckLocationHandler.Invoke(this, skill, minSkill, maxSkill);
        }

        public virtual bool CheckSpeechManifest()
        {
            if (this.Alive)
            {
                return false;
            }
            TimeSpan span1 = Mobile.m_AutoManifestTimeout;
            if ((span1 > TimeSpan.Zero) && (!this.Warmode || (this.m_AutoManifestTimer != null)))
            {
                this.Manifest(span1);
                return true;
            }
            return false;
        }

        public virtual bool CheckSpellCast(ISpell spell)
        {
            return true;
        }

        public virtual void CheckStatTimers()
        {
            if (this.Hits < this.HitsMax)
            {
                if (this.m_HitsTimer == null)
                {
                    this.m_HitsTimer = new HitsTimer(this);
                }
                this.m_HitsTimer.Start();
            }
            else
            {
                this.Hits = this.HitsMax;
            }
            if (this.Stam < this.StamMax)
            {
                if (this.m_StamTimer == null)
                {
                    this.m_StamTimer = new StamTimer(this);
                }
                this.m_StamTimer.Start();
            }
            else
            {
                this.Stam = this.StamMax;
            }
            if (this.Mana < this.ManaMax)
            {
                if (this.m_ManaTimer == null)
                {
                    this.m_ManaTimer = new ManaTimer(this);
                }
                this.m_ManaTimer.Start();
                return;
            }
            this.Mana = this.ManaMax;
        }

        public virtual bool CheckTarget(Mobile from, Target targ, object targeted)
        {
            return true;
        }

        public bool CheckTargetSkill(SkillName skill, object target, double chance)
        {
            if (Mobile.m_SkillCheckDirectTargetHandler == null)
            {
                return false;
            }
            return Mobile.m_SkillCheckDirectTargetHandler.Invoke(this, skill, target, chance);
        }

        public bool CheckTargetSkill(SkillName skill, object target, double minSkill, double maxSkill)
        {
            if (Mobile.m_SkillCheckTargetHandler == null)
            {
                return false;
            }
            return Mobile.m_SkillCheckTargetHandler.Invoke(this, skill, target, minSkill, maxSkill);
        }

        public virtual void ClearFastwalkStack()
        {
            if ((this.m_MoveRecords != null) && (this.m_MoveRecords.Count > 0))
            {
                this.m_MoveRecords.Clear();
            }
            this.m_EndQueue = DateTime.Now;
        }

        public virtual void ClearHand(Item item)
        {
            if (((item != null) && item.Movable) && !item.AllowEquipedCast(this))
            {
                this.AddToBackpack(item);
            }
        }

        public virtual void ClearHands()
        {
            this.ClearHand(this.FindItemOnLayer(Layer.FirstValid));
            this.ClearHand(this.FindItemOnLayer(Layer.TwoHanded));
        }

        public void ClearQuestArrow()
        {
            this.m_QuestArrow = null;
        }

        public void ClearScreen()
        {
            Mobile mobile1;
            Item item1;
            NetState state1 = this.m_NetState;
            if ((this.m_Map == null) || (state1 == null))
            {
                return;
            }
            IPooledEnumerable enumerable1 = this.m_Map.GetObjectsInRange(this.m_Location, Core.GlobalMaxUpdateRange);
            foreach (object obj1 in enumerable1)
            {
                if ((obj1 is Mobile))
                {
                    mobile1 = ((Mobile) obj1);
                    if ((mobile1 == this) || !Utility.InUpdateRange(this.m_Location, mobile1.m_Location))
                    {
                        continue;
                    }
                    state1.Send(mobile1.RemovePacket);
                    continue;
                }
                if ((obj1 is Item))
                {
                    item1 = ((Item) obj1);
                    if (this.InRange(item1.Location, item1.GetUpdateRange(this)))
                    {
                        state1.Send(item1.RemovePacket);
                    }
                }
            }
            enumerable1.Free();
        }

        public void ClearTarget()
        {
            this.m_Target = null;
        }

        public bool CloseAllGumps()
        {
            return this.CloseAllGumps(false);
        }

        public bool CloseAllGumps(bool throwOnOffline)
        {
            Gump[] gumpArray1;
            int num1;
            NetState state1 = this.m_NetState;
            if (state1 != null)
            {
                gumpArray1 = state1.Gumps;
                for (num1 = 0; (num1 < gumpArray1.Length); ++num1)
                {
                    state1.Send(new CloseGump(gumpArray1[num1].TypeID, 0));
                }
                return true;
            }
            if (throwOnOffline)
            {
                throw new MobileNotConnectedException(this, "Gump close packets could not be sent.");
            }
            return false;
        }

        public bool CloseGump(Type type)
        {
            return this.CloseGump(type, 0, false);
        }

        public bool CloseGump(Type type, int buttonID)
        {
            return this.CloseGump(type, buttonID, false);
        }

        public bool CloseGump(Type type, int buttonID, bool throwOnOffline)
        {
            if (this.m_NetState != null)
            {
                this.m_NetState.Send(new CloseGump(Gump.GetTypeID(type), buttonID));
                return true;
            }
            if (throwOnOffline)
            {
                throw new MobileNotConnectedException(this, "Gump close packet could not be sent.");
            }
            return false;
        }

        public virtual void ComputeBaseLightLevels(out int global, out int personal)
        {
            global = 0;
            personal = this.m_LightLevel;
        }

        public virtual void ComputeLightLevels(out int global, out int personal)
        {
            this.ComputeBaseLightLevels(out global, out personal);
            if (this.m_Region != null)
            {
                this.m_Region.AlterLightLevel(this, ref global, ref personal);
            }
        }

        public virtual void ComputeResistances()
        {
            int num1;
            int num2;
            ResistanceMod mod1;
            int num3;
            int num4;
            Item item1;
            int num5;
            int num6;
            int num7;
            IntPtr ptr1;
            if (this.m_Resistances == null)
            {
                this.m_Resistances = new int[5] { -2147483648, -2147483648, -2147483648, -2147483648, -2147483648 };
            }
            for (num1 = 0; (num1 < this.m_Resistances.Length); ++num1)
            {
                this.m_Resistances[num1] = 0;
            }
            int[] numArray1 = this.m_Resistances;
            this.m_Resistances[0] = (numArray1[0] + this.BasePhysicalResistance);
            numArray1 = this.m_Resistances;
            this.m_Resistances[1] = (numArray1[1] + this.BaseFireResistance);
            numArray1 = this.m_Resistances;
            this.m_Resistances[2] = (numArray1[2] + this.BaseColdResistance);
            numArray1 = this.m_Resistances;
            this.m_Resistances[3] = (numArray1[3] + this.BasePoisonResistance);
            numArray1 = this.m_Resistances;
            this.m_Resistances[4] = (numArray1[4] + this.BaseEnergyResistance);
            for (num2 = 0; ((this.m_ResistMods != null) && (num2 < this.m_ResistMods.Count)); ++num2)
            {
                mod1 = ((ResistanceMod) this.m_ResistMods[num2]);
                num3 = ((int) mod1.Type);
                if ((num3 >= 0) && (num3 < this.m_Resistances.Length))
                {
                    numArray1 = this.m_Resistances;
                    ptr1 = ((IntPtr) num3);
                    this.m_Resistances[num3] = (numArray1[ptr1] + mod1.Offset);
                }
            }
            for (num4 = 0; (num4 < this.m_Items.Count); ++num4)
            {
                item1 = ((Item) this.m_Items[num4]);
                if (!item1.CheckPropertyConfliction(this))
                {
                    numArray1 = this.m_Resistances;
                    this.m_Resistances[0] = (numArray1[0] + item1.PhysicalResistance);
                    numArray1 = this.m_Resistances;
                    this.m_Resistances[1] = (numArray1[1] + item1.FireResistance);
                    numArray1 = this.m_Resistances;
                    this.m_Resistances[2] = (numArray1[2] + item1.ColdResistance);
                    numArray1 = this.m_Resistances;
                    this.m_Resistances[3] = (numArray1[3] + item1.PoisonResistance);
                    numArray1 = this.m_Resistances;
                    this.m_Resistances[4] = (numArray1[4] + item1.EnergyResistance);
                }
            }
            for (num5 = 0; (num5 < this.m_Resistances.Length); ++num5)
            {
                num6 = this.GetMinResistance(((ResistanceType) num5));
                num7 = this.GetMaxResistance(((ResistanceType) num5));
                if (num7 < num6)
                {
                    num7 = num6;
                }
                if (this.m_Resistances[num5] > num7)
                {
                    this.m_Resistances[num5] = num7;
                }
                else if (this.m_Resistances[num5] < num6)
                {
                    this.m_Resistances[num5] = num6;
                }
            }
        }

        public virtual void CriminalAction(bool message)
        {
            this.Criminal = true;
            this.m_Region.OnCriminalAction(this, message);
        }

        public virtual bool CurePoison(Mobile from)
        {
            Poison poison1;
            if (this.CheckCure(from))
            {
                poison1 = this.m_Poison;
                this.Poison = null;
                this.OnCured(from, poison1);
                return true;
            }
            this.OnFailedCure(from);
            return false;
        }

        public virtual void Damage(int amount)
        {
            this.Damage(amount, null);
        }

        public virtual void Damage(int amount, Mobile from)
        {
            NetState state1;
            NetState state2;
            Packet packet1;
            if (!this.CanBeDamaged())
            {
                return;
            }
            if (!this.Region.OnDamage(this, ref amount))
            {
                return;
            }
            if (amount <= 0)
            {
                return;
            }
            int num1 = this.Hits;
            int num2 = (num1 - amount);
            if (this.m_Spell != null)
            {
                this.m_Spell.OnCasterHurt();
            }
            if (from != null)
            {
                this.RegisterDamage(amount, from);
            }
            this.DisruptiveAction();
            this.Paralyzed = false;
            switch (Mobile.m_VisibleDamageType)
            {
                case VisibleDamageType.Related:
                {
                    state1 = this.m_NetState;
                    state2 = ((NetState) ((from == null) ? null : from.m_NetState));
                    if ((amount <= 0) || ((state1 == null) && (state2 == null)))
                    {
                        goto Label_00BC;
                    }
                    packet1 = new DamagePacket(this, amount);
                    if (state1 != null)
                    {
                        state1.Send(packet1);
                    }
                    if ((state2 == null) || (state2 == state1))
                    {
                        goto Label_00BC;
                    }
                    state2.Send(packet1);
                    goto Label_00BC;
                }
                case VisibleDamageType.Everyone:
                {
                    goto Label_00B5;
                }
            }
            goto Label_00BC;
        Label_00B5:
            this.SendDamageToAll(amount);
        Label_00BC:
            this.OnDamage(amount, from, (num2 < 0));
            if (num2 < 0)
            {
                this.m_LastKiller = from;
                this.Hits = 0;
                if (num1 < 0)
                {
                    return;
                }
                this.Kill();
                return;
            }
            this.Hits = num2;
        }

        public void DefaultMobileInit()
        {
            this.m_StatCap = 225;
            this.m_FollowersMax = 5;
            this.m_Skills = new Skills(this);
            this.m_Items = new ArrayList(1);
            this.m_StatMods = new ArrayList(1);
            this.Map = Map.Internal;
            this.m_AutoPageNotify = true;
            this.m_Aggressors = new ArrayList(1);
            this.m_Aggressed = new ArrayList(1);
            this.m_Virtues = new VirtueInfo();
            this.m_Stabled = new ArrayList(1);
            this.m_DamageEntries = new ArrayList(1);
            this.m_ExpireCombatant = new ExpireCombatantTimer(this);
            this.m_ExpireCriminal = new ExpireCriminalTimer(this);
            this.m_CombatTimer = new CombatTimer(this);
            this.m_LogoutTimer = new LogoutTimer(this);
            this.m_NextSkillTime = DateTime.MinValue;
            this.m_CreationTime = DateTime.Now;
        }

        public void DelayChangeWarmode(bool value)
        {
            if (this.m_WarmodeTimer != null)
            {
                this.m_WarmodeTimer.Value = value;
                return;
            }
            if (this.m_Warmode == value)
            {
                return;
            }
            DateTime time1 = DateTime.Now;
            DateTime time2 = this.m_NextWarmodeChange;
            if ((time1 > time2) || (this.m_WarmodeChanges == 0))
            {
                this.m_WarmodeChanges = 1;
                this.m_NextWarmodeChange = (time1 + Mobile.WarmodeSpamCatch);
            }
            else
            {
                if (this.m_WarmodeChanges == 4)
                {
                    this.m_WarmodeTimer = new WarmodeTimer(this, value);
                    this.m_WarmodeTimer.Start();
                    return;
                }
                ++this.m_WarmodeChanges;
            }
            this.Warmode = value;
        }

        public virtual void Delete()
        {
            int num1;
            if (this.m_Deleted)
            {
                return;
            }
            if (!World.OnDelete(this))
            {
                return;
            }
            if (this.m_NetState != null)
            {
                this.m_NetState.CancelAllTrades();
            }
            if (this.m_NetState != null)
            {
                this.m_NetState.Dispose();
            }
            this.DropHolding();
            this.Region.InternalExit(this);
            this.OnDelete();
            for (num1 = (this.m_Items.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_Items.Count)
                {
                    ((Item) this.m_Items[num1]).OnParentDeleted(this);
                }
            }
            this.SendRemovePacket();
            if (this.m_Guild != null)
            {
                this.m_Guild.OnDelete(this);
            }
            this.m_Deleted = true;
            if (this.m_Map != null)
            {
                this.m_Map.OnLeave(this);
                this.m_Map = null;
            }
            this.m_Hair = null;
            this.m_Beard = null;
            this.m_MountItem = null;
            World.RemoveMobile(this);
            this.OnAfterDelete();
            this.m_RemovePacket = null;
            this.m_OPLPacket = null;
            this.m_PropertyList = null;
        }

        public virtual void Delta(MobileDelta flag)
        {
            if ((this.m_Map == null) || (this.m_Map == Map.Internal))
            {
                return;
            }
            this.m_DeltaFlags |= flag;
            if (!this.m_InDeltaQueue)
            {
                this.m_InDeltaQueue = true;
                Mobile.m_DeltaQueue.Enqueue(this);
            }
        }

        public virtual void Deserialize(GenericReader reader)
        {
            int num3;
            Item item1;
            int num4;
            int num1 = reader.ReadInt();
            switch (num1)
            {
                case 0:
                {
                    goto Label_01E2;
                }
                case 1:
                {
                    goto Label_01D6;
                }
                case 2:
                {
                    goto Label_01CA;
                }
                case 3:
                {
                    goto Label_01BE;
                }
                case 4:
                {
                    goto Label_01B2;
                }
                case 5:
                {
                    goto Label_019A;
                }
                case 6:
                {
                    goto Label_018E;
                }
                case 7:
                {
                    goto Label_0182;
                }
                case 8:
                {
                    goto Label_0176;
                }
                case 9:
                {
                    goto Label_016A;
                }
                case 10:
                {
                    goto Label_015E;
                }
                case 11:
                {
                    goto Label_0152;
                }
                case 12:
                {
                    goto Label_0146;
                }
                case 13:
                {
                    goto Label_013A;
                }
                case 14:
                {
                    goto Label_012E;
                }
                case 15:
                {
                    goto Label_0116;
                }
                case 16:
                {
                    goto Label_00F7;
                }
                case 17:
                {
                    goto Label_00DF;
                }
                case 18:
                case 19:
                {
                    goto Label_00D3;
                }
                case 20:
                {
                    goto Label_00C7;
                }
                case 21:
                case 22:
                {
                    goto Label_00BB;
                }
                case 23:
                {
                    goto Label_00AF;
                }
                case 24:
                case 26:
                case 25:
                {
                    goto Label_009E;
                }
                case 27:
                {
                    goto Label_0092;
                }
                case 28:
                {
                    goto Label_0086;
                }
            }
            return;
        Label_0086:
            this.m_LastStatGain = reader.ReadDeltaTime();
        Label_0092:
            this.m_TithingPoints = reader.ReadInt();
        Label_009E:
            this.m_Corpse = (reader.ReadItem() as Container);
        Label_00AF:
            this.m_CreationTime = reader.ReadDateTime();
        Label_00BB:
            this.m_Stabled = reader.ReadMobileList();
        Label_00C7:
            this.m_CantWalk = reader.ReadBool();
        Label_00D3:
            this.m_Virtues = new VirtueInfo(reader);
        Label_00DF:
            this.m_Thirst = reader.ReadInt();
            this.m_BAC = reader.ReadInt();
        Label_00F7:
            this.m_ShortTermMurders = reader.ReadInt();
            if (num1 <= 24)
            {
                reader.ReadDateTime();
                reader.ReadDateTime();
            }
        Label_0116:
            if (num1 < 22)
            {
                reader.ReadInt();
            }
            this.m_FollowersMax = reader.ReadInt();
        Label_012E:
            this.m_MagicDamageAbsorb = reader.ReadInt();
        Label_013A:
            this.m_GuildFealty = reader.ReadMobile();
        Label_0146:
            this.m_Guild = reader.ReadGuild();
        Label_0152:
            this.m_DisplayGuildTitle = reader.ReadBool();
        Label_015E:
            this.m_CanSwim = reader.ReadBool();
        Label_016A:
            this.m_Squelched = reader.ReadBool();
        Label_0176:
            this.m_Holding = reader.ReadItem();
        Label_0182:
            this.m_VirtualArmor = reader.ReadInt();
        Label_018E:
            this.m_BaseSoundID = reader.ReadInt();
        Label_019A:
            this.m_DisarmReady = reader.ReadBool();
            this.m_StunReady = reader.ReadBool();
        Label_01B2:
            if (num1 <= 25)
            {
                Poison.Deserialize(reader);
            }
        Label_01BE:
            this.m_StatCap = reader.ReadInt();
        Label_01CA:
            this.m_NameHue = reader.ReadInt();
        Label_01D6:
            this.m_Hunger = reader.ReadInt();
        Label_01E2:
            if (num1 < 21)
            {
                this.m_Stabled = new ArrayList();
            }
            if (num1 < 18)
            {
                this.m_Virtues = new VirtueInfo();
            }
            if (num1 < 11)
            {
                this.m_DisplayGuildTitle = true;
            }
            if (num1 < 3)
            {
                this.m_StatCap = 225;
            }
            if (num1 < 15)
            {
                this.m_Followers = 0;
                this.m_FollowersMax = 5;
            }
            this.m_Location = reader.ReadPoint3D();
            this.m_Body = new Body(reader.ReadInt());
            this.m_Name = reader.ReadString();
            this.m_GuildTitle = reader.ReadString();
            this.m_Criminal = reader.ReadBool();
            this.m_Kills = reader.ReadInt();
            this.m_SpeechHue = reader.ReadInt();
            this.m_EmoteHue = reader.ReadInt();
            this.m_WhisperHue = reader.ReadInt();
            this.m_YellHue = reader.ReadInt();
            this.m_Language = reader.ReadString();
            this.m_Female = reader.ReadBool();
            this.m_Warmode = reader.ReadBool();
            this.m_Hidden = reader.ReadBool();
            this.m_Direction = ((Direction) reader.ReadByte());
            this.m_Hue = reader.ReadInt();
            this.m_Str = reader.ReadInt();
            this.m_Dex = reader.ReadInt();
            this.m_Int = reader.ReadInt();
            this.m_Hits = reader.ReadInt();
            this.m_Stam = reader.ReadInt();
            this.m_Mana = reader.ReadInt();
            this.m_Map = reader.ReadMap();
            this.m_Blessed = reader.ReadBool();
            this.m_Fame = reader.ReadInt();
            this.m_Karma = reader.ReadInt();
            this.m_AccessLevel = ((AccessLevel) reader.ReadByte());
            this.m_Skills = new Skills(this, reader);
            int num2 = reader.ReadInt();
            this.m_Items = new ArrayList(num2);
            for (num3 = 0; (num3 < num2); ++num3)
            {
                item1 = reader.ReadItem();
                if (item1 != null)
                {
                    this.m_Items.Add(item1);
                }
            }
            this.m_Player = reader.ReadBool();
            this.m_Title = reader.ReadString();
            this.m_Profile = reader.ReadString();
            this.m_ProfileLocked = reader.ReadBool();
            if (num1 <= 18)
            {
                reader.ReadInt();
                reader.ReadInt();
                reader.ReadInt();
            }
            this.m_AutoPageNotify = reader.ReadBool();
            this.m_LogoutLocation = reader.ReadPoint3D();
            this.m_LogoutMap = reader.ReadMap();
            this.m_StrLock = ((StatLockType) reader.ReadByte());
            this.m_DexLock = ((StatLockType) reader.ReadByte());
            this.m_IntLock = ((StatLockType) reader.ReadByte());
            this.m_StatMods = new ArrayList();
            if (reader.ReadBool())
            {
                this.m_StuckMenuUses = new DateTime[reader.ReadInt()];
                for (num4 = 0; (num4 < this.m_StuckMenuUses.Length); ++num4)
                {
                    this.m_StuckMenuUses[num4] = reader.ReadDateTime();
                }
            }
            else
            {
                this.m_StuckMenuUses = null;
            }
            if (this.m_Player && (this.m_Map != Map.Internal))
            {
                this.m_LogoutLocation = this.m_Location;
                this.m_LogoutMap = this.m_Map;
                this.m_Map = Map.Internal;
            }
            if (this.m_Map != null)
            {
                this.m_Map.OnEnter(this);
            }
            if (this.m_Criminal)
            {
                this.m_ExpireCriminal.Start();
            }
            if (this.ShouldCheckStatTimers)
            {
                this.CheckStatTimers();
            }
            if (!this.m_Player && (this.m_CombatTimer != null))
            {
                this.m_CombatTimer.Priority = TimerPriority.FiftyMS;
            }
            else if (this.m_CombatTimer != null)
            {
                this.m_CombatTimer.Priority = TimerPriority.EveryTick;
            }
            this.m_Region = Region.Find(this.m_Location, this.m_Map);
            this.m_Region.InternalEnter(this);
            this.UpdateResistances();
        }

        public virtual void DisplayPaperdollTo(Mobile to)
        {
            EventSink.InvokePaperdollRequest(new PaperdollRequestEventArgs(to, this));
        }

        public virtual void DisruptiveAction()
        {
            if (this.Meditating)
            {
                this.Meditating = false;
                this.SendLocalizedMessage(500134);
            }
        }

        public virtual void DoBeneficial(Mobile target)
        {
            if (target == null)
            {
                return;
            }
            this.OnBeneficialAction(target, this.IsBeneficialCriminal(target));
            this.Region.OnBenificialAction(this, target);
            target.Region.OnGotBenificialAction(this, target);
        }

        public virtual void DoHarmful(Mobile target)
        {
            this.DoHarmful(target, false);
        }

        public virtual void DoHarmful(Mobile target, bool indirect)
        {
            if (target == null)
            {
                return;
            }
            bool flag1 = this.IsHarmfulCriminal(target);
            this.OnHarmfulAction(target, flag1);
            target.AggressiveAction(this, flag1);
            this.Region.OnDidHarmful(this, target);
            target.Region.OnGotHarmful(this, target);
            if (!indirect)
            {
                this.Combatant = target;
            }
            this.m_ExpireCombatant.Stop();
            this.m_ExpireCombatant.Start();
        }

        public virtual void DoSpeech(string text, int[] keywords, MessageType type, int hue)
        {
            SpeechEventArgs args1;
            Mobile mobile1;
            int num2;
            Item item1;
            int num3;
            Mobile mobile2;
            NetState state1;
            NetState state2;
            int num4;
            object obj3;
            Mobile mobile3;
            Item item2;
            if (this.m_Deleted || Commands.Handle(this, text))
            {
                return;
            }
            int num1 = 15;
            MessageType type1 = type;
            switch (type1)
            {
                case MessageType.Regular:
                {
                    this.m_SpeechHue = hue;
                    goto Label_006E;
                }
                case MessageType.System:
                {
                    goto Label_006B;
                }
                case MessageType.Emote:
                {
                    this.m_EmoteHue = hue;
                    goto Label_006E;
                }
            }
            switch (type1)
            {
                case MessageType.Whisper:
                {
                    this.m_WhisperHue = hue;
                    num1 = 1;
                    goto Label_006E;
                }
                case MessageType.Yell:
                {
                    this.m_YellHue = hue;
                    num1 = 18;
                    goto Label_006E;
                }
            }
        Label_006B:
            type = MessageType.Regular;
        Label_006E:
            args1 = new SpeechEventArgs(this, text, type, hue, keywords);
            EventSink.InvokeSpeech(args1);
            this.m_Region.OnSpeech(args1);
            this.OnSaid(args1);
            if (args1.Blocked)
            {
                return;
            }
            text = args1.Speech;
            if ((text == null) || (text.Length == 0))
            {
                return;
            }
            if (Mobile.m_Hears == null)
            {
                Mobile.m_Hears = new ArrayList();
            }
            else if (Mobile.m_Hears.Count > 0)
            {
                Mobile.m_Hears.Clear();
            }
            if (Mobile.m_OnSpeech == null)
            {
                Mobile.m_OnSpeech = new ArrayList();
            }
            else if (Mobile.m_OnSpeech.Count > 0)
            {
                Mobile.m_OnSpeech.Clear();
            }
            ArrayList list1 = Mobile.m_Hears;
            ArrayList list2 = Mobile.m_OnSpeech;
            if (this.m_Map == null)
            {
                return;
            }
            IPooledEnumerable enumerable1 = this.m_Map.GetObjectsInRange(this.m_Location, num1);
            foreach (object obj1 in enumerable1)
            {
                if ((obj1 is Mobile))
                {
                    mobile1 = ((Mobile) obj1);
                    if (!mobile1.CanSee(this) || ((!Mobile.m_NoSpeechLOS && mobile1.Player) && !mobile1.InLOS(this)))
                    {
                        continue;
                    }
                    if (mobile1.m_NetState != null)
                    {
                        list1.Add(mobile1);
                    }
                    if (mobile1.HandlesOnSpeech(this))
                    {
                        list2.Add(mobile1);
                    }
                    for (num2 = 0; (num2 < mobile1.Items.Count); ++num2)
                    {
                        item1 = ((Item) mobile1.Items[num2]);
                        if (item1.HandlesOnSpeech)
                        {
                            list2.Add(item1);
                        }
                        if ((item1 is Container))
                        {
                            this.AddSpeechItemsFrom(list2, ((Container) item1));
                        }
                    }
                    continue;
                }
                if ((obj1 is Item))
                {
                    if (((Item) obj1).HandlesOnSpeech)
                    {
                        list2.Add(obj1);
                    }
                    if ((obj1 is Container))
                    {
                        this.AddSpeechItemsFrom(list2, ((Container) obj1));
                    }
                }
            }
            object obj2 = null;
            string text1 = text;
            SpeechEventArgs args2 = null;
            if (this.MutateSpeech(list1, ref text1, ref obj2))
            {
                args2 = new SpeechEventArgs(this, text1, type, hue, new int[0]);
            }
            this.CheckSpeechManifest();
            this.ProcessDelta();
            Packet packet1 = null;
            Packet packet2 = null;
            for (num3 = 0; (num3 < list1.Count); ++num3)
            {
                mobile2 = ((Mobile) list1[num3]);
                if ((args2 == null) || !this.CheckHearsMutatedSpeech(mobile2, obj2))
                {
                    mobile2.OnSpeech(args1);
                    state1 = mobile2.NetState;
                    if (state1 != null)
                    {
                        if (packet1 == null)
                        {
                            packet1 = new UnicodeMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.m_Language, this.Name, text);
                        }
                        state1.Send(packet1);
                    }
                }
                else
                {
                    mobile2.OnSpeech(args2);
                    state2 = mobile2.NetState;
                    if (state2 != null)
                    {
                        if (packet2 == null)
                        {
                            packet2 = new UnicodeMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.m_Language, this.Name, text1);
                        }
                        state2.Send(packet2);
                    }
                }
            }
            if (list2.Count > 1)
            {
                list2.Sort(new LocationComparer(this));
            }
            for (num4 = 0; (num4 < list2.Count); ++num4)
            {
                obj3 = list2[num4];
                if ((obj3 is Mobile))
                {
                    mobile3 = ((Mobile) obj3);
                    if ((args2 == null) || !this.CheckHearsMutatedSpeech(mobile3, obj2))
                    {
                        mobile3.OnSpeech(args1);
                    }
                    else
                    {
                        mobile3.OnSpeech(args2);
                    }
                }
                else
                {
                    item2 = ((Item) obj3);
                    item2.OnSpeech(args1);
                }
            }
        }

        public virtual bool Drop(Point3D loc)
        {
            Mobile mobile1 = this;
            Item item1 = mobile1.Holding;
            if (item1 == null)
            {
                return false;
            }
            mobile1.Holding = null;
            bool flag1 = true;
            item1.SetLastMoved();
            if (!item1.DropToWorld(mobile1, loc))
            {
                item1.Bounce(mobile1);
            }
            else
            {
                flag1 = false;
            }
            item1.ClearBounce();
            if (!flag1)
            {
                this.SendDropEffect(item1);
            }
            return !flag1;
        }

        public virtual bool Drop(Item to, Point3D loc)
        {
            Mobile mobile1 = this;
            Item item1 = mobile1.Holding;
            if (item1 == null)
            {
                return false;
            }
            mobile1.Holding = null;
            bool flag1 = true;
            item1.SetLastMoved();
            if ((to == null) || !item1.DropToItem(mobile1, to, loc))
            {
                item1.Bounce(mobile1);
            }
            else
            {
                flag1 = false;
            }
            item1.ClearBounce();
            if (!flag1)
            {
                this.SendDropEffect(item1);
            }
            return !flag1;
        }

        public virtual bool Drop(Mobile to, Point3D loc)
        {
            Mobile mobile1 = this;
            Item item1 = mobile1.Holding;
            if (item1 == null)
            {
                return false;
            }
            mobile1.Holding = null;
            bool flag1 = true;
            item1.SetLastMoved();
            if ((to == null) || !item1.DropToMobile(mobile1, to, loc))
            {
                item1.Bounce(mobile1);
            }
            else
            {
                flag1 = false;
            }
            item1.ClearBounce();
            if (!flag1)
            {
                this.SendDropEffect(item1);
            }
            return !flag1;
        }

        public void DropHolding()
        {
            Item item1 = this.m_Holding;
            if (item1 == null)
            {
                return;
            }
            if (!item1.Deleted && (item1.Map == Map.Internal))
            {
                item1.MoveToWorld(this.m_Location, this.m_Map);
            }
            item1.ClearBounce();
            this.Holding = null;
        }

        public void Emote(int number)
        {
            this.Emote(number, "");
        }

        public void Emote(string text)
        {
            this.PublicOverheadMessage(MessageType.Emote, this.m_EmoteHue, false, text);
        }

        public void Emote(int number, string args)
        {
            this.PublicOverheadMessage(MessageType.Emote, this.m_EmoteHue, number, args);
        }

        public void Emote(string format, params object[] args)
        {
            this.Emote(string.Format(format, args));
        }

        public void EndAction(object toLock)
        {
            if (this.m_Actions != null)
            {
                this.m_Actions.Remove(toLock);
                if (this.m_Actions.Count == 0)
                {
                    this.m_Actions = null;
                }
            }
        }

        public virtual bool EquipItem(Item item)
        {
            if (((item == null) || item.Deleted) || !item.CanEquip(this))
            {
                return false;
            }
            if ((this.CheckEquip(item) && this.OnEquip(item)) && item.OnEquip(this))
            {
                if ((this.m_Spell != null) && !this.m_Spell.OnCasterEquiping(item))
                {
                    return false;
                }
                this.AddItem(item);
                return true;
            }
            return false;
        }

        public BankBox FindBankNoCreate()
        {
            if (((this.m_BankBox != null) && !this.m_BankBox.Deleted) && (this.m_BankBox.Parent == this))
            {
                return this.m_BankBox;
            }
            return (this.FindItemOnLayer(Layer.Bank) as BankBox);
        }

        public DamageEntry FindDamageEntryFor(Mobile m)
        {
            int num1;
            DamageEntry entry1;
            for (num1 = (this.m_DamageEntries.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_DamageEntries.Count)
                {
                    entry1 = ((DamageEntry) this.m_DamageEntries[num1]);
                    if (entry1.HasExpired)
                    {
                        this.m_DamageEntries.RemoveAt(num1);
                    }
                    else if (entry1.Damager == m)
                    {
                        return entry1;
                    }
                }
            }
            return null;
        }

        public Item FindItemOnLayer(Layer layer)
        {
            int num2;
            Item item1;
            ArrayList list1 = this.m_Items;
            int num1 = list1.Count;
            for (num2 = 0; (num2 < num1); ++num2)
            {
                item1 = ((Item) list1[num2]);
                if (!item1.Deleted && (item1.Layer == layer))
                {
                    return item1;
                }
            }
            return null;
        }

        public DamageEntry FindLeastRecentDamageEntry(bool allowSelf)
        {
            int num1;
            DamageEntry entry1;
            for (num1 = 0; (num1 < this.m_DamageEntries.Count); ++num1)
            {
                if (num1 >= 0)
                {
                    entry1 = ((DamageEntry) this.m_DamageEntries[num1]);
                    if (entry1.HasExpired)
                    {
                        this.m_DamageEntries.RemoveAt(num1);
                        --num1;
                    }
                    else if (allowSelf || (entry1.Damager != this))
                    {
                        return entry1;
                    }
                }
            }
            return null;
        }

        public Mobile FindLeastRecentDamager(bool allowSelf)
        {
            return Mobile.GetDamagerFrom(this.FindLeastRecentDamageEntry(allowSelf));
        }

        public DamageEntry FindLeastTotalDamageEntry(bool allowSelf)
        {
            int num1;
            DamageEntry entry2;
            DamageEntry entry1 = null;
            for (num1 = (this.m_DamageEntries.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_DamageEntries.Count)
                {
                    entry2 = ((DamageEntry) this.m_DamageEntries[num1]);
                    if (entry2.HasExpired)
                    {
                        this.m_DamageEntries.RemoveAt(num1);
                    }
                    else if ((allowSelf || (entry2.Damager != this)) && ((entry1 == null) || (entry2.DamageGiven < entry1.DamageGiven)))
                    {
                        entry1 = entry2;
                    }
                }
            }
            return entry1;
        }

        public Mobile FindLeastTotalDamger(bool allowSelf)
        {
            return Mobile.GetDamagerFrom(this.FindLeastTotalDamageEntry(allowSelf));
        }

        public DamageEntry FindMostRecentDamageEntry(bool allowSelf)
        {
            int num1;
            DamageEntry entry1;
            for (num1 = (this.m_DamageEntries.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_DamageEntries.Count)
                {
                    entry1 = ((DamageEntry) this.m_DamageEntries[num1]);
                    if (entry1.HasExpired)
                    {
                        this.m_DamageEntries.RemoveAt(num1);
                    }
                    else if (allowSelf || (entry1.Damager != this))
                    {
                        return entry1;
                    }
                }
            }
            return null;
        }

        public Mobile FindMostRecentDamager(bool allowSelf)
        {
            return Mobile.GetDamagerFrom(this.FindMostRecentDamageEntry(allowSelf));
        }

        public DamageEntry FindMostTotalDamageEntry(bool allowSelf)
        {
            int num1;
            DamageEntry entry2;
            DamageEntry entry1 = null;
            for (num1 = (this.m_DamageEntries.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_DamageEntries.Count)
                {
                    entry2 = ((DamageEntry) this.m_DamageEntries[num1]);
                    if (entry2.HasExpired)
                    {
                        this.m_DamageEntries.RemoveAt(num1);
                    }
                    else if ((allowSelf || (entry2.Damager != this)) && ((entry1 == null) || (entry2.DamageGiven > entry1.DamageGiven)))
                    {
                        entry1 = entry2;
                    }
                }
            }
            return entry1;
        }

        public Mobile FindMostTotalDamger(bool allowSelf)
        {
            return Mobile.GetDamagerFrom(this.FindMostTotalDamageEntry(allowSelf));
        }

        public void FixedEffect(int itemID, int speed, int duration)
        {
            Effects.SendTargetEffect(this, itemID, speed, duration, 0, 0);
        }

        public void FixedEffect(int itemID, int speed, int duration, int hue, int renderMode)
        {
            Effects.SendTargetEffect(this, itemID, speed, duration, hue, renderMode);
        }

        public void FixedParticles(int itemID, int speed, int duration, int effect, EffectLayer layer)
        {
            Effects.SendTargetParticles(this, itemID, speed, duration, 0, 0, effect, layer, 0);
        }

        public void FixedParticles(int itemID, int speed, int duration, int effect, EffectLayer layer, int unknown)
        {
            Effects.SendTargetParticles(this, itemID, speed, duration, 0, 0, effect, layer, unknown);
        }

        public void FixedParticles(int itemID, int speed, int duration, int effect, int hue, int renderMode, EffectLayer layer)
        {
            Effects.SendTargetParticles(this, itemID, speed, duration, hue, renderMode, effect, layer, 0);
        }

        public void FixedParticles(int itemID, int speed, int duration, int effect, int hue, int renderMode, EffectLayer layer, int unknown)
        {
            Effects.SendTargetParticles(this, itemID, speed, duration, hue, renderMode, effect, layer, unknown);
        }

        public void ForceRegionReEnter(bool Exit)
        {
            if (this.m_Deleted)
            {
                return;
            }
            Region region1 = Region.Find(this.m_Location, this.m_Map);
            if (region1 == this.m_Region)
            {
                return;
            }
            if (Exit)
            {
                this.m_Region.InternalExit(this);
            }
            this.m_Region = region1;
            this.OnRegionChange(region1, this.m_Region);
            this.m_Region.InternalEnter(this);
            this.CheckLightLevels(false);
        }

        public void FreeCache()
        {
            this.m_RemovePacket = null;
            this.m_OPLPacket = null;
            this.m_PropertyList = null;
        }

        public void Freeze(TimeSpan duration)
        {
            if (!this.m_Frozen)
            {
                this.m_Frozen = true;
                this.m_FrozenTimer = new FrozenTimer(this, duration);
                this.m_FrozenTimer.Start();
            }
        }

        public static string GetAccessLevelName(AccessLevel level)
        {
            return Mobile.m_AccessLevelNames[level];
        }

        public virtual int GetAngerSound()
        {
            if (this.m_BaseSoundID != 0)
            {
                return this.m_BaseSoundID;
            }
            return -1;
        }

        public virtual int GetAttackSound()
        {
            if (this.m_BaseSoundID != 0)
            {
                return (this.m_BaseSoundID + 2);
            }
            return -1;
        }

        public virtual void GetChildProperties(ObjectPropertyList list, Item item)
        {
        }

        public IPooledEnumerable GetClientsInRange(int range)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return Map.NullEnumerable.Instance;
            }
            return map1.GetClientsInRange(this.m_Location, range);
        }

        public virtual void GetContextMenuEntries(Mobile from, ArrayList list)
        {
            if (this.m_Deleted)
            {
                return;
            }
            if (this.CanPaperdollBeOpenedBy(from))
            {
                list.Add(new PaperdollEntry(this));
            }
            if (((from == this) && (this.Backpack != null)) && (this.CanSee(this.Backpack) && this.CheckAlive(false)))
            {
                list.Add(new OpenBackpackEntry(this));
            }
        }

        public virtual Mobile GetDamageMaster(Mobile damagee)
        {
            return null;
        }

        public static Mobile GetDamagerFrom(DamageEntry de)
        {
            if (de != null)
            {
                return de.Damager;
            }
            return null;
        }

        public virtual int GetDeathSound()
        {
            if (this.m_BaseSoundID != 0)
            {
                return (this.m_BaseSoundID + 4);
            }
            if (this.m_Body.IsHuman)
            {
                return Utility.Random((this.m_Female ? 788 : 1059), (this.m_Female ? 4 : 5));
            }
            return -1;
        }

        public virtual IWeapon GetDefaultWeapon()
        {
            return Mobile.m_DefaultWeapon;
        }

        public Direction GetDirectionTo(IPoint2D p)
        {
            if (p == null)
            {
                return Direction.North;
            }
            return this.GetDirectionTo(p.X, p.Y);
        }

        public Direction GetDirectionTo(Point2D p)
        {
            return this.GetDirectionTo(p.m_X, p.m_Y);
        }

        public Direction GetDirectionTo(Point3D p)
        {
            return this.GetDirectionTo(p.m_X, p.m_Y);
        }

        public Direction GetDirectionTo(int x, int y)
        {
            int num1 = (this.m_Location.m_X - x);
            int num2 = (this.m_Location.m_Y - y);
            int num3 = ((num1 - num2) * 44);
            int num4 = ((num1 + num2) * 44);
            int num5 = Math.Abs(num3);
            int num6 = Math.Abs(num4);
            if (((num6 >> 1) - num5) >= 0)
            {
                return ((num4 > 0) ? Direction.Up : Direction.Down);
            }
            if (((num5 >> 1) - num6) >= 0)
            {
                return ((num3 > 0) ? Direction.Left : Direction.Right);
            }
            if ((num3 >= 0) && (num4 >= 0))
            {
                return Direction.West;
            }
            if ((num3 >= 0) && (num4 < 0))
            {
                return Direction.South;
            }
            if ((num3 < 0) && (num4 < 0))
            {
                return Direction.East;
            }
            return Direction.North;
        }

        public double GetDistanceToSqrt(IPoint2D p)
        {
            int num1 = (this.m_Location.m_X - p.X);
            int num2 = (this.m_Location.m_Y - p.Y);
            return Math.Sqrt(((num1 * num1) + (num2 * num2)));
        }

        public double GetDistanceToSqrt(Mobile m)
        {
            int num1 = (this.m_Location.m_X - m.m_Location.m_X);
            int num2 = (this.m_Location.m_Y - m.m_Location.m_Y);
            return Math.Sqrt(((num1 * num1) + (num2 * num2)));
        }

        public double GetDistanceToSqrt(Point3D p)
        {
            int num1 = (this.m_Location.m_X - p.m_X);
            int num2 = (this.m_Location.m_Y - p.m_Y);
            return Math.Sqrt(((num1 * num1) + (num2 * num2)));
        }

        public static TimeSpan GetHitsRegenRate(Mobile m)
        {
            if (Mobile.m_HitsRegenRate == null)
            {
                return Mobile.m_DefaultHitsRate;
            }
            return Mobile.m_HitsRegenRate.Invoke(m);
        }

        public virtual int GetHurtSound()
        {
            if (this.m_BaseSoundID != 0)
            {
                return (this.m_BaseSoundID + 3);
            }
            return -1;
        }

        public virtual int GetIdleSound()
        {
            if (this.m_BaseSoundID != 0)
            {
                return (this.m_BaseSoundID + 1);
            }
            return -1;
        }

        public virtual DeathMoveResult GetInventoryMoveResultFor(Item item)
        {
            return item.OnInventoryDeath(this);
        }

        public IPooledEnumerable GetItemsInRange(int range)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return Map.NullEnumerable.Instance;
            }
            return map1.GetItemsInRange(this.m_Location, range);
        }

        public virtual TimeSpan GetLogoutDelay()
        {
            return this.Region.GetLogoutDelay(this);
        }

        public static TimeSpan GetManaRegenRate(Mobile m)
        {
            if (Mobile.m_ManaRegenRate == null)
            {
                return Mobile.m_DefaultManaRate;
            }
            return Mobile.m_ManaRegenRate.Invoke(m);
        }

        public virtual int GetMaxResistance(ResistanceType type)
        {
            if (this.m_Player)
            {
                return Mobile.m_MaxPlayerResistance;
            }
            return 2147483647;
        }

        public virtual int GetMinResistance(ResistanceType type)
        {
            return -2147483648;
        }

        public IPooledEnumerable GetMobilesInRange(int range)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return Map.NullEnumerable.Instance;
            }
            return map1.GetMobilesInRange(this.m_Location, range);
        }

        public IPooledEnumerable GetObjectsInRange(int range)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return Map.NullEnumerable.Instance;
            }
            return map1.GetObjectsInRange(this.m_Location, range);
        }

        public virtual int GetPacketFlags()
        {
            int num1 = 0;
            if (this.m_Female)
            {
                num1 |= 2;
            }
            if (this.m_Poison != null)
            {
                num1 |= 4;
            }
            if (this.m_Blessed || this.m_YellowHealthbar)
            {
                num1 |= 8;
            }
            if (this.m_Warmode)
            {
                num1 |= 64;
            }
            if (this.m_Hidden)
            {
                num1 |= 128;
            }
            return num1;
        }

        public virtual DeathMoveResult GetParentMoveResultFor(Item item)
        {
            return item.OnParentDeath(this);
        }

        public virtual void GetProperties(ObjectPropertyList list)
        {
            this.AddNameProperties(list);
        }

        public virtual int GetResistance(ResistanceType type)
        {
            if (this.m_Resistances == null)
            {
                this.m_Resistances = new int[5] { -2147483648, -2147483648, -2147483648, -2147483648, -2147483648 };
            }
            int num1 = ((int) type);
            if ((num1 < 0) || (num1 >= this.m_Resistances.Length))
            {
                return 0;
            }
            int num2 = this.m_Resistances[num1];
            if (num2 == -2147483648)
            {
                this.ComputeResistances();
                num2 = this.m_Resistances[num1];
            }
            return num2;
        }

        public virtual int GetSeason()
        {
            if (this.m_Map != null)
            {
                return this.m_Map.Season;
            }
            return 1;
        }

        public static TimeSpan GetStamRegenRate(Mobile m)
        {
            if (Mobile.m_StamRegenRate == null)
            {
                return Mobile.m_DefaultStamRate;
            }
            return Mobile.m_StamRegenRate.Invoke(m);
        }

        public StatMod GetStatMod(string name)
        {
            int num1;
            StatMod mod1;
            for (num1 = 0; (num1 < this.m_StatMods.Count); ++num1)
            {
                mod1 = ((StatMod) this.m_StatMods[num1]);
                if (mod1.Name == name)
                {
                    return mod1;
                }
            }
            return null;
        }

        public int GetStatOffset(StatType type)
        {
            int num2;
            StatMod mod1;
            int num1 = 0;
            for (num2 = 0; (num2 < this.m_StatMods.Count); ++num2)
            {
                mod1 = ((StatMod) this.m_StatMods[num2]);
                if (mod1.HasElapsed())
                {
                    this.m_StatMods.RemoveAt(num2);
                    this.Delta(MobileDelta.Stat);
                    this.CheckStatTimers();
                    --num2;
                }
                else if ((mod1.Type & type) != 0)
                {
                    num1 += mod1.Offset;
                }
            }
            return num1;
        }

        public virtual bool HandlesOnSpeech(Mobile from)
        {
            return false;
        }

        public virtual bool HarmfulCheck(Mobile target)
        {
            if (this.CanBeHarmful(target))
            {
                this.DoHarmful(target);
                return true;
            }
            return false;
        }

        public bool HasFreeHand()
        {
            return (this.FindItemOnLayer(Layer.TwoHanded) == null);
        }

        public bool HasGump(Type type)
        {
            return this.HasGump(type, false);
        }

        public bool HasGump(Type type, bool throwOnOffline)
        {
            bool flag1;
            Gump[] gumpArray1;
            int num1;
            NetState state1 = this.m_NetState;
            if (state1 != null)
            {
                flag1 = false;
                gumpArray1 = state1.Gumps;
                for (num1 = 0; (!flag1 && (num1 < gumpArray1.Length)); ++num1)
                {
                    flag1 = (gumpArray1[num1].GetType() == type);
                }
                return flag1;
            }
            if (throwOnOffline)
            {
                throw new MobileNotConnectedException(this, "Mobile is not connected.");
            }
            return false;
        }

        public void Heal(int amount)
        {
            if (!this.Alive || this.IsDeadBondedPet)
            {
                return;
            }
            if (!this.Region.OnHeal(this, ref amount))
            {
                return;
            }
            if ((this.Hits + amount) > this.HitsMax)
            {
                amount = (this.HitsMax - this.Hits);
            }
            this.Hits += amount;
            if ((amount > 0) && (this.m_NetState != null))
            {
                this.m_NetState.Send(new MessageLocalizedAffix(Serial.MinusOne, -1, MessageType.Label, 946, 3, 1008158, "", AffixType.System, amount.ToString(), ""));
            }
        }

        public void InitStats(int str, int dex, int intel)
        {
            this.m_Str = str;
            this.m_Dex = dex;
            this.m_Int = intel;
            this.Hits = this.HitsMax;
            this.Stam = this.StamMax;
            this.Mana = this.ManaMax;
            this.Delta((MobileDelta.Stat | MobileDelta.Attributes));
        }

        public bool InLOS(Mobile target)
        {
            if (this.m_Deleted || (this.m_Map == null))
            {
                return false;
            }
            if ((target == this) || (this.m_AccessLevel > AccessLevel.Player))
            {
                return true;
            }
            return this.m_Map.LineOfSight(this, target);
        }

        public bool InLOS(Point3D target)
        {
            if (this.m_Deleted || (this.m_Map == null))
            {
                return false;
            }
            if (this.m_AccessLevel > AccessLevel.Player)
            {
                return true;
            }
            return this.m_Map.LineOfSight(this, target);
        }

        public bool InLOS(object target)
        {
            if (this.m_Deleted || (this.m_Map == null))
            {
                return false;
            }
            if ((target == this) || (this.m_AccessLevel > AccessLevel.Player))
            {
                return true;
            }
            if ((target is Item) && (((Item) target).RootParent == this))
            {
                return true;
            }
            return this.m_Map.LineOfSight(this, target);
        }

        public bool InRange(IPoint2D p, int range)
        {
            if (((p.X >= (this.m_Location.m_X - range)) && (p.X <= (this.m_Location.m_X + range))) && (p.Y >= (this.m_Location.m_Y - range)))
            {
                return (p.Y <= (this.m_Location.m_Y + range));
            }
            return false;
        }

        public bool InRange(Point2D p, int range)
        {
            if (((p.m_X >= (this.m_Location.m_X - range)) && (p.m_X <= (this.m_Location.m_X + range))) && (p.m_Y >= (this.m_Location.m_Y - range)))
            {
                return (p.m_Y <= (this.m_Location.m_Y + range));
            }
            return false;
        }

        public bool InRange(Point3D p, int range)
        {
            if (((p.m_X >= (this.m_Location.m_X - range)) && (p.m_X <= (this.m_Location.m_X + range))) && (p.m_Y >= (this.m_Location.m_Y - range)))
            {
                return (p.m_Y <= (this.m_Location.m_Y + range));
            }
            return false;
        }

        public void Internalize()
        {
            this.Map = Map.Internal;
        }

        private bool InternalOnMove(Direction d)
        {
            if (!this.OnMove(d))
            {
                return false;
            }
            MovementEventArgs args1 = MovementEventArgs.Create(this, d);
            EventSink.InvokeMovement(args1);
            bool flag1 = !args1.Blocked;
            args1.Free();
            return flag1;
        }

        private void InternalRemoveSkillMod(SkillMod mod)
        {
            Skill skill1;
            if (this.m_SkillMods.Contains(mod))
            {
                this.m_SkillMods.Remove(mod);
                mod.Owner = null;
                skill1 = this.m_Skills[mod.Skill];
                if (skill1 != null)
                {
                    skill1.Update();
                }
            }
        }

        public void InvalidateProperties()
        {
            ObjectPropertyList list1;
            ObjectPropertyList list2;
            if (!Core.AOS)
            {
                return;
            }
            if ((this.m_Map != null) && (this.m_Map != Map.Internal))
            {
                list1 = this.m_PropertyList;
                this.m_PropertyList = null;
                list2 = this.PropertyList;
                if ((list1 != null) && (list1.Hash == list2.Hash))
                {
                    return;
                }
                this.m_OPLPacket = null;
                this.Delta(MobileDelta.Properties);
                return;
            }
            this.m_PropertyList = null;
            this.m_OPLPacket = null;
        }

        public virtual bool IsBeneficialCriminal(Mobile target)
        {
            if (this == target)
            {
                return false;
            }
            int num1 = Notoriety.Compute(this, target);
            if (num1 != 4)
            {
                return (num1 == 6);
            }
            return true;
        }

        public virtual bool IsHarmfulCriminal(Mobile target)
        {
            if (this == target)
            {
                return false;
            }
            return (Notoriety.Compute(this, target) == 1);
        }

        public virtual bool IsSnoop(Mobile from)
        {
            return (from != this);
        }

        public virtual void Kill()
        {
            Item item1;
            ArrayList list5;
            int num2;
            Item item2;
            DeathMoveResult result2;
            int num3;
            Item item3;
            Packet packet1;
            Packet packet2;
            IPooledEnumerable enumerable1;
            if (!this.CanBeDamaged())
            {
                return;
            }
            if (!this.Alive || this.IsDeadBondedPet)
            {
                return;
            }
            if (this.m_Deleted)
            {
                return;
            }
            if (!this.Region.OnDeath(this))
            {
                return;
            }
            if (!this.OnBeforeDeath())
            {
                return;
            }
            BankBox box1 = this.FindBankNoCreate();
            if ((box1 != null) && box1.Opened)
            {
                box1.Close();
            }
            if (this.m_NetState != null)
            {
                this.m_NetState.CancelAllTrades();
            }
            if (this.m_Spell != null)
            {
                this.m_Spell.OnCasterKilled();
            }
            if (this.m_Target != null)
            {
                this.m_Target.Cancel(this, TargetCancelType.Canceled);
            }
            this.DisruptiveAction();
            this.Warmode = false;
            this.DropHolding();
            this.Hits = 0;
            this.Stam = 0;
            this.Mana = 0;
            this.Poison = null;
            this.Combatant = null;
            if (this.Paralyzed)
            {
                this.Paralyzed = false;
                if (this.m_ParaTimer != null)
                {
                    this.m_ParaTimer.Stop();
                }
            }
            if (this.Frozen)
            {
                this.Frozen = false;
                if (this.m_FrozenTimer != null)
                {
                    this.m_FrozenTimer.Stop();
                }
            }
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList(this.m_Items);
            Container container1 = this.Backpack;
            int num1 = 0;
            while ((num1 < list4.Count))
            {
                item1 = ((Item) list4[num1]);
                if (item1 == container1)
                {
                    goto Label_018A;
                }
                switch (this.GetParentMoveResultFor(item1))
                {
                    case DeathMoveResult.MoveToCorpse:
                    {
                        list1.Add(item1);
                        list2.Add(item1);
                        goto Label_018A;
                    }
                    case DeathMoveResult.RemainEquiped:
                    {
                        goto Label_018A;
                    }
                    case DeathMoveResult.MoveToBackpack:
                    {
                        goto Label_0181;
                    }
                }
                goto Label_018A;
            Label_0181:
                list3.Add(item1);
            Label_018A:
                ++num1;
            }
            if (container1 != null)
            {
                list5 = new ArrayList(container1.Items);
                for (num2 = 0; (num2 < list5.Count); ++num2)
                {
                    item2 = ((Item) list5[num2]);
                    result2 = this.GetInventoryMoveResultFor(item2);
                    if (result2 == DeathMoveResult.MoveToCorpse)
                    {
                        list1.Add(item2);
                    }
                    else
                    {
                        list3.Add(item2);
                    }
                }
                for (num3 = 0; (num3 < list3.Count); ++num3)
                {
                    item3 = ((Item) list3[num3]);
                    if (!this.RetainPackLocsOnDeath || (item3.Parent != container1))
                    {
                        container1.DropItem(item3);
                    }
                }
            }
            Container container2 = ((Container) ((Mobile.m_CreateCorpse == null) ? null : Mobile.m_CreateCorpse.Invoke(this, list1, list2)));
            if (this.m_Map != null)
            {
                packet1 = null;
                packet2 = null;
                enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
                foreach (NetState state1 in enumerable1)
                {
                    if (state1 != this.m_NetState)
                    {
                        if (packet1 == null)
                        {
                            packet1 = new DeathAnimation(this, container2);
                        }
                        state1.Send(packet1);
                        if (!state1.Mobile.CanSee(this))
                        {
                            if (packet2 == null)
                            {
                                packet2 = this.RemovePacket;
                            }
                            state1.Send(packet2);
                        }
                    }
                }
                enumerable1.Free();
            }
            this.OnDeath(container2);
        }

        public void LaunchBrowser(string url)
        {
            if (this.m_NetState != null)
            {
                this.m_NetState.LaunchBrowser(url);
            }
        }

        public virtual void Lift(Item item, int amount, out bool rejected, out LRReason reject)
        {
            object obj1;
            int num1;
            Map map1;
            IPooledEnumerable enumerable1;
            Packet packet1;
            IEntity entity1;
            Point3D pointd1;
            Map map2;
            bool flag1;
            int num2;
            rejected = true;
            reject = 5;
            if (item == null)
            {
                return;
            }
            Mobile mobile1 = this;
            NetState state1 = this.m_NetState;
            if ((mobile1.AccessLevel >= AccessLevel.GameMaster) || (DateTime.Now >= mobile1.NextActionTime))
            {
                if (mobile1.CheckAlive())
                {
                    mobile1.DisruptiveAction();
                    if (mobile1.Holding != null)
                    {
                        reject = 4;
                    }
                    else if ((mobile1.AccessLevel < AccessLevel.GameMaster) && !mobile1.InRange(item.GetWorldLocation(), 2))
                    {
                        reject = 1;
                    }
                    else if (!mobile1.CanSee(item) || !mobile1.InLOS(item))
                    {
                        reject = 2;
                    }
                    else if (!item.VerifyMove(mobile1))
                    {
                        reject = 0;
                    }
                    else if (item.InSecureTrade || !item.IsAccessibleTo(mobile1))
                    {
                        reject = 0;
                    }
                    else if (!item.CheckLift(mobile1, item))
                    {
                        reject = 5;
                    }
                    else
                    {
                        obj1 = item.RootParent;
                        if (((obj1 != null) && (obj1 is Mobile)) && !((Mobile) obj1).CheckNonlocalLift(mobile1, item))
                        {
                            reject = 3;
                        }
                        else if (!mobile1.OnDragLift(item) || !item.OnDragLift(mobile1))
                        {
                            reject = 5;
                        }
                        else
                        {
                            item.SetLastMoved();
                            if (amount == 0)
                            {
                                amount = 1;
                            }
                            if (amount > item.Amount)
                            {
                                amount = item.Amount;
                            }
                            num1 = item.Amount;
                            item.Amount = amount;
                            if (amount < num1)
                            {
                                item.Dupe((num1 - amount));
                            }
                            map1 = mobile1.Map;
                            if ((Mobile.DragEffects && (map1 != null)) && ((obj1 == null) || (obj1 is Item)))
                            {
                                enumerable1 = map1.GetClientsInRange(mobile1.Location);
                                packet1 = null;
                                foreach (NetState state2 in enumerable1)
                                {
                                    if ((state2.Mobile == mobile1) || !state2.Mobile.CanSee(mobile1))
                                    {
                                        continue;
                                    }
                                    if (packet1 == null)
                                    {
                                        if (obj1 == null)
                                        {
                                            entity1 = new Entity(Serial.Zero, item.Location, map1);
                                        }
                                        else
                                        {
                                            entity1 = new Entity(((Item) obj1).Serial, ((Item) obj1).Location, map1);
                                        }
                                        packet1 = new DragEffect(entity1, mobile1, item.ItemID, item.Hue, amount);
                                    }
                                    state2.Send(packet1);
                                }
                                enumerable1.Free();
                            }
                            pointd1 = item.Location;
                            map2 = item.Map;
                            flag1 = (item.Parent == null);
                            item.RecordBounce();
                            item.OnItemLifted(mobile1, item);
                            item.Internalize();
                            mobile1.Holding = item;
                            num2 = item.GetLiftSound(mobile1);
                            if (num2 != -1)
                            {
                                mobile1.Send(new PlaySound(num2, mobile1));
                            }
                            mobile1.NextActionTime = (DateTime.Now + TimeSpan.FromSeconds(0.5));
                            if ((map2 != null) && flag1)
                            {
                                map2.FixColumn(pointd1.m_X, pointd1.m_Y);
                            }
                            reject = 5;
                            rejected = false;
                        }
                    }
                }
                else
                {
                    reject = 5;
                }
            }
            else
            {
                this.SendActionMessage();
                reject = 5;
            }
            if (!rejected || (state1 == null))
            {
                return;
            }
            state1.Send(new LiftRej(reject));
            if ((item.Parent is Item))
            {
                state1.Send(new ContainerContentUpdate(item));
            }
            else if ((item.Parent is Mobile))
            {
                state1.Send(new EquipUpdate(item));
            }
            else
            {
                item.SendInfoTo(state1);
            }
            if (ObjectPropertyList.Enabled && (item.Parent != null))
            {
                state1.Send(item.OPLPacket);
            }
        }

        public void LocalOverheadMessage(MessageType type, int hue, int number)
        {
            this.LocalOverheadMessage(type, hue, number, "");
        }

        public void LocalOverheadMessage(MessageType type, int hue, bool ascii, string text)
        {
            NetState state1 = this.m_NetState;
            if (state1 == null)
            {
                return;
            }
            if (ascii)
            {
                state1.Send(new AsciiMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.Name, text));
                return;
            }
            state1.Send(new UnicodeMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.m_Language, this.Name, text));
        }

        public void LocalOverheadMessage(MessageType type, int hue, int number, string args)
        {
            NetState state1 = this.m_NetState;
            if (state1 != null)
            {
                state1.Send(new MessageLocalized(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, number, this.Name, args));
            }
        }

        public virtual void Manifest(TimeSpan delay)
        {
            this.Warmode = true;
            if (this.m_AutoManifestTimer == null)
            {
                this.m_AutoManifestTimer = new AutoManifestTimer(this, delay);
            }
            else
            {
                this.m_AutoManifestTimer.Stop();
            }
            this.m_AutoManifestTimer.Start();
        }

        public virtual bool Move(Direction d)
        {
            int num1;
            Sector sector1;
            Sector sector2;
            ArrayList list1;
            int num7;
            Mobile mobile1;
            int num8;
            Item item1;
            int num9;
            Mobile mobile2;
            int num10;
            Item item2;
            int num11;
            Mobile mobile3;
            int num12;
            Item item3;
            Region region1;
            MovementRecord record1;
            FastWalkEventArgs args1;
            TimeSpan span1;
            DateTime time1;
            MobileMoving[] movingArray1;
            int num13;
            IPooledEnumerable enumerable1;
            Item item4;
            int num14;
            object obj2;
            Mobile mobile4;
            NetState state1;
            int num15;
            MobileMoving moving1;
            ItemData data1;
            MobileMoving moving2;
            if (this.m_Deleted)
            {
                return false;
            }
            BankBox box1 = this.FindBankNoCreate();
            if ((box1 != null) && box1.Opened)
            {
                box1.Close();
            }
            Point3D pointd1 = this.Location;
            Point3D pointd2 = pointd1;
            if ((this.m_Direction & Direction.Up) != (d & Direction.Up))
            {
                goto Label_0683;
            }
            if ((this.m_Spell != null) && !this.m_Spell.OnCasterMoving(d))
            {
                return false;
            }
            if (this.m_Paralyzed || this.m_Frozen)
            {
                this.SendLocalizedMessage(500111);
                return false;
            }
            if (!this.CheckMovement(d, out num1))
            {
                goto Label_067B;
            }
            int num2 = this.m_Location.m_X;
            int num3 = this.m_Location.m_Y;
            int num4 = num2;
            int num5 = num3;
            int num6 = this.m_Location.m_Z;
            switch ((d & 7))
            {
                case Direction.North:
                {
                    --num3;
                    goto Label_0131;
                }
                case Direction.Right:
                {
                    ++num2;
                    --num3;
                    goto Label_0131;
                }
                case Direction.East:
                {
                    ++num2;
                    goto Label_0131;
                }
                case Direction.Down:
                {
                    ++num2;
                    ++num3;
                    goto Label_0131;
                }
                case Direction.South:
                {
                    ++num3;
                    goto Label_0131;
                }
                case Direction.Left:
                {
                    --num2;
                    ++num3;
                    goto Label_0131;
                }
                case Direction.West:
                {
                    --num2;
                    goto Label_0131;
                }
                case Direction.Up:
                {
                    goto Label_0125;
                }
            }
            goto Label_0131;
        Label_0125:
            --num2;
            --num3;
        Label_0131:
            this.m_Pushing = false;
            Map map1 = this.m_Map;
            if (map1 != null)
            {
                sector1 = map1.GetSector(num4, num5);
                sector2 = map1.GetSector(num2, num3);
                if (sector1 != sector2)
                {
                    list1 = sector1.Mobiles;
                    for (num7 = 0; (num7 < list1.Count); ++num7)
                    {
                        mobile1 = ((Mobile) list1[num7]);
                        if ((((mobile1 != this) && (mobile1.X == num4)) && ((mobile1.Y == num5) && ((mobile1.Z + 15) > num6))) && (((num6 + 15) > mobile1.Z) && !mobile1.OnMoveOff(this)))
                        {
                            return false;
                        }
                    }
                    list1 = sector1.Items;
                    num8 = 0;
                    while ((num8 < list1.Count))
                    {
                        item1 = ((Item) list1[num8]);
                        if (item1.AtWorldPoint(num4, num5))
                        {
                            if (item1.Z != num6)
                            {
                                data1 = item1.ItemData;
                                if (((item1.Z + data1.Height) <= num6) || ((num6 + 15) <= item1.Z))
                                {
                                    goto Label_0248;
                                }
                            }
                            if (!item1.OnMoveOff(this))
                            {
                                return false;
                            }
                        }
                    Label_0248:
                        ++num8;
                    }
                    list1 = sector2.Mobiles;
                    for (num9 = 0; (num9 < list1.Count); ++num9)
                    {
                        mobile2 = ((Mobile) list1[num9]);
                        if ((((mobile2.X == num2) && (mobile2.Y == num3)) && (((mobile2.Z + 15) > num1) && ((num1 + 15) > mobile2.Z))) && !mobile2.OnMoveOver(this))
                        {
                            return false;
                        }
                    }
                    list1 = sector2.Items;
                    num10 = 0;
                    while ((num10 < list1.Count))
                    {
                        item2 = ((Item) list1[num10]);
                        if (item2.AtWorldPoint(num2, num3))
                        {
                            if (item2.Z != num1)
                            {
                                data1 = item2.ItemData;
                                if (((item2.Z + data1.Height) <= num1) || ((num1 + 15) <= item2.Z))
                                {
                                    goto Label_032D;
                                }
                            }
                            if (!item2.OnMoveOver(this))
                            {
                                return false;
                            }
                        }
                    Label_032D:
                        ++num10;
                    }
                }
                else
                {
                    list1 = sector1.Mobiles;
                    for (num11 = 0; (num11 < list1.Count); ++num11)
                    {
                        mobile3 = ((Mobile) list1[num11]);
                        if ((((mobile3 != this) && (mobile3.X == num4)) && ((mobile3.Y == num5) && ((mobile3.Z + 15) > num6))) && (((num6 + 15) > mobile3.Z) && !mobile3.OnMoveOff(this)))
                        {
                            return false;
                        }
                        if ((((mobile3.X == num2) && (mobile3.Y == num3)) && (((mobile3.Z + 15) > num1) && ((num1 + 15) > mobile3.Z))) && !mobile3.OnMoveOver(this))
                        {
                            return false;
                        }
                    }
                    list1 = sector1.Items;
                    num12 = 0;
                    while ((num12 < list1.Count))
                    {
                        item3 = ((Item) list1[num12]);
                        if (item3.AtWorldPoint(num4, num5))
                        {
                            if (item3.Z != num6)
                            {
                                data1 = item3.ItemData;
                                if (((item3.Z + data1.Height) <= num6) || ((num6 + 15) <= item3.Z))
                                {
                                    goto Label_0466;
                                }
                            }
                            if (!item3.OnMoveOff(this))
                            {
                                return false;
                            }
                        }
                    Label_0466:
                        if (item3.AtWorldPoint(num2, num3))
                        {
                            if (item3.Z != num1)
                            {
                                data1 = item3.ItemData;
                                if (((item3.Z + data1.Height) <= num1) || ((num1 + 15) <= item3.Z))
                                {
                                    goto Label_04B1;
                                }
                            }
                            if (!item3.OnMoveOver(this))
                            {
                                return false;
                            }
                        }
                    Label_04B1:
                        ++num12;
                    }
                }
                region1 = Region.Find(new Point3D(num2, num3, num1), this.m_Map);
                if ((region1 != null) && !region1.OnMoveInto(this, d, new Point3D(num2, num3, num1), pointd2))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            if (!this.InternalOnMove(d))
            {
                return false;
            }
            if (((Mobile.m_FwdEnabled && (this.m_NetState != null)) && (this.m_AccessLevel < Mobile.m_FwdAccessOverride)) && (!Mobile.m_FwdUOTDOverride || ((this.m_NetState.Version != null) && (this.m_NetState.Version.Type != ClientType.UOTD))))
            {
                if (this.m_MoveRecords == null)
                {
                    this.m_MoveRecords = new Queue(6);
                }
                while ((this.m_MoveRecords.Count > 0))
                {
                    record1 = ((MovementRecord) this.m_MoveRecords.Peek());
                    if (!record1.Expired())
                    {
                        break;
                    }
                    this.m_MoveRecords.Dequeue();
                }
                if (this.m_MoveRecords.Count >= Mobile.m_FwdMaxSteps)
                {
                    args1 = new FastWalkEventArgs(this.m_NetState);
                    EventSink.InvokeFastWalk(args1);
                    if (args1.Blocked)
                    {
                        return false;
                    }
                }
                if (this.Mounted)
                {
                    span1 = (((d & ((Direction) 128)) != ((byte) 0)) ? Mobile.m_RunMount : Mobile.m_WalkMount);
                }
                else
                {
                    span1 = (((d & ((Direction) 128)) != ((byte) 0)) ? Mobile.m_RunFoot : Mobile.m_WalkFoot);
                }
                if (this.m_MoveRecords.Count > 0)
                {
                    time1 = (this.m_EndQueue + span1);
                }
                else
                {
                    time1 = (DateTime.Now + span1);
                }
                this.m_MoveRecords.Enqueue(MovementRecord.NewInstance(time1));
                this.m_EndQueue = time1;
            }
            this.m_LastMoveTime = DateTime.Now;
            pointd1 = new Point3D(num2, num3, num1);
            goto Label_067D;
        Label_067B:
            return false;
        Label_067D:
            this.DisruptiveAction();
        Label_0683:
            if (this.m_NetState != null)
            {
                this.m_NetState.Send(MovementAck.Instantiate(this.m_NetState.Sequence, this));
            }
            this.SetLocation(pointd1, false);
            this.SetDirection(d);
            if (this.m_Map != null)
            {
                movingArray1 = Mobile.m_MovingPacketCache;
                for (num13 = 0; (num13 < movingArray1.Length); ++num13)
                {
                    movingArray1[num13] = null;
                }
                enumerable1 = this.m_Map.GetObjectsInRange(this.m_Location, Core.GlobalMaxUpdateRange);
                foreach (object obj1 in enumerable1)
                {
                    if (obj1 == this)
                    {
                        continue;
                    }
                    if ((obj1 is Mobile))
                    {
                        Mobile.m_MoveList.Add(obj1);
                        continue;
                    }
                    if ((obj1 is Item))
                    {
                        item4 = ((Item) obj1);
                        if (item4.HandlesOnMovement)
                        {
                            Mobile.m_MoveList.Add(item4);
                        }
                    }
                }
                enumerable1.Free();
                for (num14 = 0; (num14 < Mobile.m_MoveList.Count); ++num14)
                {
                    obj2 = Mobile.m_MoveList[num14];
                    if ((obj2 is Mobile))
                    {
                        mobile4 = ((Mobile) Mobile.m_MoveList[num14]);
                        state1 = mobile4.NetState;
                        if (((state1 != null) && Utility.InUpdateRange(this.m_Location, mobile4.m_Location)) && mobile4.CanSee(this))
                        {
                            num15 = Notoriety.Compute(mobile4, this);
                            moving1 = movingArray1[num15];
                            if (moving1 == null)
                            {
                                movingArray1[num15] = (moving2 = new MobileMoving(this, num15));
                                moving1 = moving2;
                            }
                            state1.Send(moving1);
                        }
                        mobile4.OnMovement(this, pointd2);
                    }
                    else if ((obj2 is Item))
                    {
                        ((Item) obj2).OnMovement(this, pointd2);
                    }
                }
                if (Mobile.m_MoveList.Count > 0)
                {
                    Mobile.m_MoveList.Clear();
                }
            }
            return true;
        }

        public virtual void MoveToWorld(Point3D newLocation, Map map)
        {
            int num1;
            NetState state1;
            if (this.m_Map == map)
            {
                this.SetLocation(newLocation, true);
                return;
            }
            BankBox box1 = this.FindBankNoCreate();
            if ((box1 != null) && box1.Opened)
            {
                box1.Close();
            }
            Point3D pointd1 = this.m_Location;
            Map map1 = this.m_Map;
            Region region1 = this.m_Region;
            if (map1 != null)
            {
                map1.OnLeave(this);
                this.ClearScreen();
                this.SendRemovePacket();
            }
            for (num1 = 0; (num1 < this.m_Items.Count); ++num1)
            {
                ((Item) this.m_Items[num1]).Map = map;
            }
            this.m_Map = map;
            this.m_Region.InternalExit(this);
            this.m_Location = newLocation;
            if (this.m_Map != null)
            {
                this.m_Map.OnEnter(this);
                this.m_Region = Region.Find(this.m_Location, this.m_Map);
                this.OnRegionChange(region1, this.m_Region);
                this.m_Region.InternalEnter(this);
                state1 = this.m_NetState;
                if ((state1 != null) && (this.m_Map != null))
                {
                    state1.Sequence = 0;
                    state1.Send(new MapChange(this));
                    state1.Send(new MapPatches());
                    state1.Send(SeasonChange.Instantiate(this.GetSeason(), true));
                    state1.Send(new MobileUpdate(this));
                    this.ClearFastwalkStack();
                }
            }
            if (this.m_NetState != null)
            {
                if (this.m_Map != null)
                {
                    this.Send(new ServerChange(this, this.m_Map));
                }
                if (this.m_NetState != null)
                {
                    this.m_NetState.Sequence = 0;
                    this.ClearFastwalkStack();
                }
                this.Send(new MobileIncoming(this, this));
                this.Send(new MobileUpdate(this));
                this.CheckLightLevels(true);
                this.Send(new MobileUpdate(this));
            }
            this.SendEverything();
            this.SendIncomingPacket();
            if (this.m_NetState != null)
            {
                if (this.m_NetState != null)
                {
                    this.m_NetState.Sequence = 0;
                    this.ClearFastwalkStack();
                }
                this.Send(new MobileIncoming(this, this));
                this.Send(SupportedFeatures.Instantiate());
                this.Send(new MobileUpdate(this));
                this.Send(new MobileAttributes(this));
            }
            this.OnMapChange(map1);
            this.OnLocationChange(pointd1);
            this.m_Region.OnLocationChanged(this, pointd1);
        }

        public void MovingEffect(IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes)
        {
            Effects.SendMovingEffect(this, to, itemID, speed, duration, fixedDirection, explodes, 0, 0);
        }

        public void MovingEffect(IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode)
        {
            Effects.SendMovingEffect(this, to, itemID, speed, duration, fixedDirection, explodes, hue, renderMode);
        }

        public void MovingParticles(IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int effect, int explodeEffect, int explodeSound)
        {
            Effects.SendMovingParticles(this, to, itemID, speed, duration, fixedDirection, explodes, 0, 0, effect, explodeEffect, explodeSound, 0);
        }

        public void MovingParticles(IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int effect, int explodeEffect, int explodeSound, int unknown)
        {
            Effects.SendMovingParticles(this, to, itemID, speed, duration, fixedDirection, explodes, effect, explodeEffect, explodeSound, unknown);
        }

        public void MovingParticles(IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, int unknown)
        {
            Effects.SendMovingParticles(this, to, itemID, speed, duration, fixedDirection, explodes, hue, renderMode, effect, explodeEffect, explodeSound, ((EffectLayer) 255), unknown);
        }

        public void MovingParticles(IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, EffectLayer layer, int unknown)
        {
            Effects.SendMovingParticles(this, to, itemID, speed, duration, fixedDirection, explodes, hue, renderMode, effect, explodeEffect, explodeSound, layer, unknown);
        }

        public virtual bool MutateSpeech(ArrayList hears, ref string text, ref object context)
        {
            int num1;
            if (this.Alive)
            {
                return false;
            }
            StringBuilder builder1 = new StringBuilder(text.Length, text.Length);
            for (num1 = 0; (num1 < text.Length); ++num1)
            {
                if (text[num1] != ' ')
                {
                    builder1.Append(Mobile.m_GhostChars[Utility.Random(Mobile.m_GhostChars.Length)]);
                }
                else
                {
                    builder1.Append(' ');
                }
            }
            text = builder1.ToString();
            context = Mobile.m_GhostMutateContext;
            return true;
        }

        public void NonlocalOverheadMessage(MessageType type, int hue, int number)
        {
            this.NonlocalOverheadMessage(type, hue, number, "");
        }

        public void NonlocalOverheadMessage(MessageType type, int hue, bool ascii, string text)
        {
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if ((state1 != this.m_NetState) && state1.Mobile.CanSee(this))
                {
                    if (packet1 == null)
                    {
                        if (ascii)
                        {
                            packet1 = new AsciiMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.Name, text);
                        }
                        else
                        {
                            packet1 = new UnicodeMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.Language, this.Name, text);
                        }
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public void NonlocalOverheadMessage(MessageType type, int hue, int number, string args)
        {
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if ((state1 != this.m_NetState) && state1.Mobile.CanSee(this))
                {
                    if (packet1 == null)
                    {
                        packet1 = new MessageLocalized(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, number, this.Name, args);
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public virtual void OnAccessLevelChanged(AccessLevel oldLevel)
        {
        }

        public virtual void OnAfterDelete()
        {
            this.StopAggrExpire();
            this.CheckAggrExpire();
            if (this.m_PoisonTimer != null)
            {
                this.m_PoisonTimer.Stop();
            }
            if (this.m_HitsTimer != null)
            {
                this.m_HitsTimer.Stop();
            }
            if (this.m_StamTimer != null)
            {
                this.m_StamTimer.Stop();
            }
            if (this.m_ManaTimer != null)
            {
                this.m_ManaTimer.Stop();
            }
            this.m_CombatTimer.Stop();
            this.m_ExpireCombatant.Stop();
            this.m_ExpireCriminal.Stop();
            this.m_LogoutTimer.Stop();
            if (this.m_WarmodeTimer != null)
            {
                this.m_WarmodeTimer.Stop();
            }
            if (this.m_ParaTimer != null)
            {
                this.m_ParaTimer.Stop();
            }
            if (this.m_FrozenTimer != null)
            {
                this.m_FrozenTimer.Stop();
            }
        }

        public virtual void OnAfterResurrect()
        {
        }

        public virtual void OnAosSingleClick(Mobile from)
        {
            int num1;
            ObjectPropertyList list1 = this.PropertyList;
            if (list1.Header <= 0)
            {
                return;
            }
            if (this.m_NameHue != -1)
            {
                num1 = this.m_NameHue;
            }
            else if (this.m_AccessLevel > AccessLevel.Player)
            {
                num1 = 11;
            }
            else
            {
                num1 = Notoriety.GetHue(Notoriety.Compute(from, this));
            }
            from.Send(new MessageLocalized(this.m_Serial, Body.op_Implicit(this.Body), MessageType.Label, num1, 3, list1.Header, this.Name, list1.HeaderArgs));
        }

        public virtual bool OnBeforeDeath()
        {
            return true;
        }

        public virtual void OnBeforeResurrect()
        {
        }

        public virtual void OnBeneficialAction(Mobile target, bool isCriminal)
        {
            if (isCriminal)
            {
                this.CriminalAction(false);
            }
        }

        public virtual void OnCombatantChange()
        {
        }

        public virtual void OnConnected()
        {
        }

        public virtual void OnCured(Mobile from, Poison oldPoison)
        {
        }

        public virtual void OnDamage(int amount, Mobile from, bool willKill)
        {
        }

        public virtual void OnDeath(Container c)
        {
            int num1 = this.GetDeathSound();
            if (num1 >= 0)
            {
                Effects.PlaySound(this, this.Map, num1);
            }
            if (!this.m_Player)
            {
                this.Delete();
                return;
            }
            this.Send(DeathStatus.Instantiate(true));
            this.Warmode = false;
            this.BodyMod = Body.op_Implicit(0);
            this.Body = Body.op_Implicit((this.Female ? 403 : 402));
            Item item1 = new Item(8270);
            item1.Movable = false;
            item1.Layer = Layer.OuterTorso;
            this.AddItem(item1);
            this.m_Items.Remove(item1);
            this.m_Items.Insert(0, item1);
            this.Poison = null;
            this.Combatant = null;
            this.Hits = 0;
            this.Stam = 0;
            this.Mana = 0;
            EventSink.InvokePlayerDeath(new PlayerDeathEventArgs(this));
            Mobile.ProcessDeltaQueue();
            this.Send(DeathStatus.Instantiate(false));
        }

        public virtual void OnDelete()
        {
        }

        public virtual void OnDisconnected()
        {
        }

        public virtual void OnDoubleClick(Mobile from)
        {
            IMount mount1;
            if ((this == from) && (!Mobile.m_DisableDismountInWarmode || !this.m_Warmode))
            {
                mount1 = this.Mount;
                if (mount1 != null)
                {
                    mount1.Rider = null;
                    return;
                }
            }
            if (this.CanPaperdollBeOpenedBy(from))
            {
                this.DisplayPaperdollTo(from);
            }
        }

        public virtual void OnDoubleClickCantSee(Mobile from)
        {
        }

        public virtual void OnDoubleClickDead(Mobile from)
        {
            if (this.CanPaperdollBeOpenedBy(from))
            {
                this.DisplayPaperdollTo(from);
            }
        }

        public virtual void OnDoubleClickOutOfRange(Mobile from)
        {
        }

        public virtual bool OnDragDrop(Mobile from, Item dropped)
        {
            Container container1;
            NetState state1;
            NetState state2;
            Container container2;
            if (from == this)
            {
                container1 = this.Backpack;
                if (container1 != null)
                {
                    return dropped.DropToItem(from, container1, new Point3D(-1, -1, 0));
                }
                return false;
            }
            if (((from.Player && this.Player) && (from.Alive && this.Alive)) && from.InRange(this.Location, 2))
            {
                state1 = this.m_NetState;
                state2 = from.m_NetState;
                if ((state1 != null) && (state2 != null))
                {
                    container2 = state2.TradeWith(state1);
                    container2.AddItem(dropped);
                    return true;
                }
                return false;
            }
            return false;
        }

        public virtual bool OnDragLift(Item item)
        {
            return true;
        }

        public virtual bool OnDroppedItemInto(Item item, Container container, Point3D loc)
        {
            return true;
        }

        public virtual bool OnDroppedItemOnto(Item item, Item target)
        {
            return true;
        }

        public virtual bool OnDroppedItemToItem(Item item, Item target, Point3D loc)
        {
            return true;
        }

        public virtual bool OnDroppedItemToMobile(Item item, Mobile target)
        {
            return true;
        }

        public virtual bool OnDroppedItemToWorld(Item item, Point3D location)
        {
            return true;
        }

        public virtual bool OnEquip(Item item)
        {
            return true;
        }

        public virtual void OnFailedCure(Mobile from)
        {
        }

        public virtual void OnFameChange(int oldValue)
        {
        }

        public virtual void OnGenderChanged(bool oldFemale)
        {
        }

        public virtual void OnGuildChange(BaseGuild oldGuild)
        {
        }

        public virtual void OnGuildTitleChange(string oldTitle)
        {
        }

        public virtual void OnHarmfulAction(Mobile target, bool isCriminal)
        {
            if (isCriminal)
            {
                this.CriminalAction(false);
            }
        }

        public virtual void OnHelpRequest(Mobile from)
        {
        }

        public virtual void OnHigherPoison(Mobile from, Poison poison)
        {
        }

        public virtual void OnItemAdded(Item item)
        {
        }

        public virtual void OnItemLifted(Mobile from, Item item)
        {
        }

        public virtual void OnItemRemoved(Item item)
        {
        }

        public virtual void OnItemUsed(Mobile from, Item item)
        {
        }

        public virtual void OnKarmaChange(int oldValue)
        {
        }

        public virtual void OnKillsChange(int oldValue)
        {
        }

        protected virtual void OnLocationChange(Point3D oldLocation)
        {
        }

        protected virtual void OnMapChange(Map oldMap)
        {
        }

        protected virtual bool OnMove(Direction d)
        {
            if ((this.m_Hidden && (this.m_AccessLevel == AccessLevel.Player)) && (((this.m_AllowedStealthSteps-- <= 0) || ((d & ((Direction) 128)) != ((byte) 0))) || this.Mounted))
            {
                this.RevealingAction();
            }
            return true;
        }

        public virtual void OnMovement(Mobile m, Point3D oldLocation)
        {
        }

        public virtual bool OnMoveOff(Mobile m)
        {
            return true;
        }

        public virtual bool OnMoveOver(Mobile m)
        {
            int num1;
            if ((this.m_Map == null) || this.m_Deleted)
            {
                return true;
            }
            if ((this.m_Map.Rules & MapRules.FreeMovement) == MapRules.FeluccaRules)
            {
                if ((!this.Alive || !m.Alive) || (this.IsDeadBondedPet || m.IsDeadBondedPet))
                {
                    return true;
                }
                if (this.m_Hidden && (this.m_AccessLevel > AccessLevel.Player))
                {
                    return true;
                }
                if (!m.m_Pushing)
                {
                    m.m_Pushing = true;
                    if (m.AccessLevel > AccessLevel.Player)
                    {
                        num1 = (this.m_Hidden ? 1019041 : 1019040);
                    }
                    else if (m.Stam == m.StamMax)
                    {
                        num1 = (this.m_Hidden ? 1019043 : 1019042);
                        m.Stam -= 10;
                        m.RevealingAction();
                    }
                    else
                    {
                        return false;
                    }
                    m.SendLocalizedMessage(num1);
                }
            }
            return true;
        }

        public virtual void OnNetStateChanged()
        {
        }

        public virtual void OnPaperdollRequest()
        {
            if (this.CanPaperdollBeOpenedBy(this))
            {
                this.DisplayPaperdollTo(this);
            }
        }

        public virtual void OnPoisoned(Mobile from, Poison poison, Poison oldPoison)
        {
            if (poison != null)
            {
                this.LocalOverheadMessage(MessageType.Regular, 34, (1042857 + (poison.Level * 2)));
                this.NonlocalOverheadMessage(MessageType.Regular, 34, ((int) (1042858 + (poison.Level * 2))), this.Name);
            }
        }

        public virtual void OnPoisonImmunity(Mobile from, Poison poison)
        {
            this.PublicOverheadMessage(MessageType.Emote, 946, 1005534);
        }

        public virtual void OnRawDexChange(int oldValue)
        {
        }

        public virtual void OnRawIntChange(int oldValue)
        {
        }

        public virtual void OnRawStatChange(StatType stat, int oldValue)
        {
        }

        public virtual void OnRawStrChange(int oldValue)
        {
        }

        public virtual void OnRegionChange(Region Old, Region New)
        {
        }

        public virtual void OnSaid(SpeechEventArgs e)
        {
            if (this.m_Squelched)
            {
                this.SendLocalizedMessage(500168);
                e.Blocked = true;
            }
            if (!e.Blocked)
            {
                this.RevealingAction();
            }
        }

        public virtual void OnSectorActivate()
        {
        }

        public virtual void OnSectorDeactivate()
        {
        }

        public virtual void OnSingleClick(Mobile from)
        {
            BaseGuild guild1;
            string text1;
            string text2;
            string text3;
            int num1;
            string text5;
            if (this.m_Deleted)
            {
                return;
            }
            if (((this.AccessLevel == AccessLevel.Player) && Mobile.DisableHiddenSelfClick) && (this.Hidden && (from == this)))
            {
                return;
            }
            if (Mobile.m_GuildClickMessage)
            {
                guild1 = this.m_Guild;
                if ((guild1 != null) && (this.m_DisplayGuildTitle || (this.m_Player && (guild1.Type != GuildType.Regular))))
                {
                    text1 = this.GuildTitle;
                    if (text1 == null)
                    {
                        text1 = "";
                    }
                    else
                    {
                        text1 = text1.Trim();
                    }
                    if ((guild1.Type >= GuildType.Regular) && (guild1.Type < Mobile.m_GuildTypes.Length))
                    {
                        text2 = Mobile.m_GuildTypes[guild1.Type];
                    }
                    else
                    {
                        text2 = "";
                    }
                    text3 = string.Format(((text1.Length <= 0) ? "[{1}]{2}" : "[{0}, {1}]{2}"), text1, guild1.Abbreviation, text2);
                    this.PrivateOverheadMessage(MessageType.Regular, this.SpeechHue, true, text3, from.NetState);
                }
            }
            if (this.m_NameHue != -1)
            {
                num1 = this.m_NameHue;
            }
            else if (this.AccessLevel > AccessLevel.Player)
            {
                num1 = 11;
            }
            else
            {
                num1 = Notoriety.GetHue(Notoriety.Compute(from, this));
            }
            string text4 = this.Name;
            if (text4 == null)
            {
                text4 = string.Empty;
            }
            if ((this.ShowFameTitle && (this.m_Player || this.m_Body.IsHuman)) && (this.m_Fame >= 10000))
            {
                text5 = (this.m_Female ? "Lady " : "Lord ") + text4;
            }
            else
            {
                text5 = text4;
            }
            if ((this.ClickTitle && (this.Title != null)) && (this.Title.Length > 0))
            {
                text5 = text5 + " " + this.Title;
            }
            this.PrivateOverheadMessage(MessageType.Label, num1, Mobile.m_AsciiClickMessage, text5, from.NetState);
        }

        public virtual void OnSkillChange(SkillName skill, double oldBase)
        {
        }

        public virtual void OnSkillInvalidated(Skill skill)
        {
        }

        public virtual void OnSkillsQuery(Mobile from)
        {
            if (from == this)
            {
                this.Send(new SkillUpdate(this.m_Skills));
            }
        }

        public virtual void OnSpeech(SpeechEventArgs e)
        {
        }

        public virtual void OnSpellCast(ISpell spell)
        {
        }

        public virtual void OnStatsQuery(Mobile from)
        {
            if (((from.Map == this.Map) && Utility.InUpdateRange(this, from)) && from.CanSee(this))
            {
                from.Send(new MobileStatus(from, this));
            }
            if (from == this)
            {
                this.Send(new StatLockInfo(this));
            }
            IParty party1 = (this.m_Party as IParty);
            if (party1 != null)
            {
                party1.OnStatsQuery(from, this);
            }
        }

        public virtual void OnSubItemAdded(Item item)
        {
        }

        public virtual void OnSubItemRemoved(Item item)
        {
        }

        protected virtual void OnTargetChange()
        {
        }

        public virtual void OnWeightChange(int oldValue)
        {
        }

        public void Paralyze(TimeSpan duration)
        {
            if (!this.m_Paralyzed)
            {
                this.Paralyzed = true;
                this.m_ParaTimer = new ParalyzedTimer(this, duration);
                this.m_ParaTimer.Start();
            }
        }

        public bool PlaceInBackpack(Item item)
        {
            if (item.Deleted)
            {
                return false;
            }
            Container container1 = this.Backpack;
            if (container1 != null)
            {
                return container1.TryDropItem(this, item, false);
            }
            return false;
        }

        public void PlaySound(int soundID)
        {
            if (soundID == -1)
            {
                return;
            }
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if (state1.Mobile.CanSee(this))
                {
                    if (packet1 == null)
                    {
                        packet1 = new PlaySound(soundID, this);
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public void PrivateOverheadMessage(MessageType type, int hue, int number, NetState state)
        {
            this.PrivateOverheadMessage(type, hue, number, "", state);
        }

        public void PrivateOverheadMessage(MessageType type, int hue, bool ascii, string text, NetState state)
        {
            if (state == null)
            {
                return;
            }
            if (ascii)
            {
                state.Send(new AsciiMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.Name, text));
                return;
            }
            state.Send(new UnicodeMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.m_Language, this.Name, text));
        }

        public void PrivateOverheadMessage(MessageType type, int hue, int number, string args, NetState state)
        {
            if (state != null)
            {
                state.Send(new MessageLocalized(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, number, this.Name, args));
            }
        }

        public virtual void ProcessDelta()
        {
            int num1;
            int num2;
            IParty party1;
            Mobile mobile2;
            int num3;
            MobileMoving moving1;
            MobileMoving moving2;
            Mobile mobile1 = this;
            MobileDelta delta1 = mobile1.m_DeltaFlags;
            if (delta1 == MobileDelta.None)
            {
                return;
            }
            MobileDelta delta2 = (delta1 & MobileDelta.Attributes);
            mobile1.m_DeltaFlags = MobileDelta.None;
            mobile1.m_InDeltaQueue = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            bool flag8 = false;
            bool flag9 = false;
            bool flag10 = false;
            bool flag11 = false;
            bool flag12 = false;
            bool flag13 = false;
            bool flag14 = (!Core.AOS ? false : ((delta1 & MobileDelta.Properties) != MobileDelta.None));
            if (delta2 != MobileDelta.None)
            {
                flag5 = true;
                if (delta2 == MobileDelta.Attributes)
                {
                    flag4 = true;
                }
                else
                {
                    flag1 = ((delta2 & MobileDelta.Hits) != MobileDelta.None);
                    flag2 = ((delta2 & MobileDelta.Stam) != MobileDelta.None);
                    flag3 = ((delta2 & MobileDelta.Mana) != MobileDelta.None);
                }
            }
            if ((delta1 & MobileDelta.GhostUpdate) != MobileDelta.None)
            {
                flag7 = true;
            }
            if ((delta1 & MobileDelta.Hue) != MobileDelta.None)
            {
                flag7 = true;
                flag8 = true;
                flag9 = true;
            }
            if ((delta1 & MobileDelta.Direction) != MobileDelta.None)
            {
                flag13 = true;
                flag8 = true;
            }
            if ((delta1 & MobileDelta.Body) != MobileDelta.None)
            {
                flag8 = true;
                flag6 = true;
            }
            if ((delta1 & (MobileDelta.Noto | MobileDelta.Flags)) != MobileDelta.None)
            {
                flag12 = true;
            }
            if ((delta1 & MobileDelta.Name) != MobileDelta.None)
            {
                flag4 = false;
                flag1 = false;
                flag5 = (flag2 ? true : flag3);
                flag10 = true;
            }
            if ((delta1 & (MobileDelta.WeaponDamage | (MobileDelta.Resistances | (MobileDelta.TithingPoints | (MobileDelta.Followers | (MobileDelta.StatCap | (MobileDelta.Armor | (MobileDelta.Weight | (MobileDelta.Gold | MobileDelta.Stat))))))))) != MobileDelta.None)
            {
                flag11 = true;
            }
            MobileMoving[] movingArray1 = Mobile.m_MovingPacketCache;
            if (flag12 || flag13)
            {
                for (num1 = 0; (num1 < movingArray1.Length); ++num1)
                {
                    movingArray1[num1] = null;
                }
            }
            NetState state1 = mobile1.m_NetState;
            if (state1 != null)
            {
                if (flag8)
                {
                    state1.Sequence = 0;
                    state1.Send(new MobileUpdate(mobile1));
                    this.ClearFastwalkStack();
                }
                if (flag6)
                {
                    state1.Send(new MobileIncoming(mobile1, mobile1));
                }
                if (flag12)
                {
                    num2 = Notoriety.Compute(mobile1, mobile1);
                    movingArray1[num2] = (moving2 = new MobileMoving(mobile1, num2));
                    state1.Send(moving2);
                }
                if (flag10 || flag11)
                {
                    state1.Send(new MobileStatusExtended(mobile1));
                }
                else if (flag4)
                {
                    state1.Send(new MobileAttributes(mobile1));
                }
                else if (flag5)
                {
                    if (flag1)
                    {
                        state1.Send(new MobileHits(mobile1));
                    }
                    if (flag2)
                    {
                        state1.Send(new MobileStam(mobile1));
                    }
                    if (flag3)
                    {
                        state1.Send(new MobileMana(mobile1));
                    }
                }
                if (flag2 || flag3)
                {
                    party1 = (this.m_Party as IParty);
                    if ((party1 != null) && flag2)
                    {
                        party1.OnStamChanged(this);
                    }
                    if ((party1 != null) && flag3)
                    {
                        party1.OnManaChanged(this);
                    }
                }
                if (flag14)
                {
                    state1.Send(this.OPLPacket);
                }
            }
            flag12 = (flag12 ? true : flag13);
            flag6 = (flag6 ? true : flag7);
            if ((mobile1.m_Map == null) || (((!flag9 && !flag6) && (!flag10 && !flag1)) && (!flag12 && !flag14)))
            {
                return;
            }
            IPooledEnumerable enumerable1 = mobile1.Map.GetClientsInRange(mobile1.m_Location);
            Packet packet1 = null;
            Packet packet2 = null;
            Packet packet3 = null;
            foreach (NetState state2 in enumerable1)
            {
                mobile2 = state2.Mobile;
                if ((mobile2 != mobile1) && mobile2.CanSee(mobile1))
                {
                    if (flag9)
                    {
                        state2.Send(mobile1.RemovePacket);
                    }
                    if (flag6)
                    {
                        state2.Send(new MobileIncoming(mobile2, mobile1));
                        if (mobile1.IsDeadBondedPet)
                        {
                            state2.Send(new BondedStatus(0, mobile1.m_Serial, 1));
                        }
                    }
                    if (flag12)
                    {
                        num3 = Notoriety.Compute(mobile2, mobile1);
                        moving1 = movingArray1[num3];
                        if (moving1 == null)
                        {
                            movingArray1[num3] = (moving1 = new MobileMoving(mobile1, num3));
                        }
                        state2.Send(moving1);
                    }
                    if (flag10)
                    {
                        if (mobile1.CanBeRenamedBy(mobile2))
                        {
                            if (packet2 == null)
                            {
                                packet2 = new MobileStatusCompact(true, mobile1);
                            }
                            state2.Send(packet2);
                        }
                        else
                        {
                            if (packet3 == null)
                            {
                                packet3 = new MobileStatusCompact(false, mobile1);
                            }
                            state2.Send(packet3);
                        }
                    }
                    else if (flag1)
                    {
                        if (packet1 == null)
                        {
                            packet1 = new MobileHitsN(mobile1);
                        }
                        state2.Send(packet1);
                    }
                    if (flag14)
                    {
                        state2.Send(this.OPLPacket);
                    }
                }
            }
            enumerable1.Free();
        }

        public static void ProcessDeltaQueue()
        {
            int num1 = Mobile.m_DeltaQueue.Count;
            int num2 = 0;
            while (((Mobile.m_DeltaQueue.Count > 0) && (num2++ < num1)))
            {
                ((Mobile) Mobile.m_DeltaQueue.Dequeue()).ProcessDelta();
            }
        }

        public void PublicOverheadMessage(MessageType type, int hue, int number)
        {
            this.PublicOverheadMessage(type, hue, number, "", true);
        }

        public void PublicOverheadMessage(MessageType type, int hue, bool ascii, string text)
        {
            this.PublicOverheadMessage(type, hue, ascii, text, true);
        }

        public void PublicOverheadMessage(MessageType type, int hue, int number, string args)
        {
            this.PublicOverheadMessage(type, hue, number, args, true);
        }

        public void PublicOverheadMessage(MessageType type, int hue, bool ascii, string text, bool noLineOfSight)
        {
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if (state1.Mobile.CanSee(this) && (noLineOfSight || state1.Mobile.InLOS(this)))
                {
                    if (packet1 == null)
                    {
                        if (ascii)
                        {
                            packet1 = new AsciiMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.Name, text);
                        }
                        else
                        {
                            packet1 = new UnicodeMessage(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, this.m_Language, this.Name, text);
                        }
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public void PublicOverheadMessage(MessageType type, int hue, int number, string args, bool noLineOfSight)
        {
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if (state1.Mobile.CanSee(this) && (noLineOfSight || state1.Mobile.InLOS(this)))
                {
                    if (packet1 == null)
                    {
                        packet1 = new MessageLocalized(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, number, this.Name, args);
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public void PublicOverheadMessage(MessageType type, int hue, int number, AffixType affixType, string affix, string args)
        {
            this.PublicOverheadMessage(type, hue, number, affixType, affix, args, true);
        }

        public void PublicOverheadMessage(MessageType type, int hue, int number, AffixType affixType, string affix, string args, bool noLineOfSight)
        {
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if (state1.Mobile.CanSee(this) && (noLineOfSight || state1.Mobile.InLOS(this)))
                {
                    if (packet1 == null)
                    {
                        packet1 = new MessageLocalizedAffix(this.m_Serial, Body.op_Implicit(this.Body), type, hue, 3, number, this.Name, affixType, affix, args);
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public virtual DamageEntry RegisterDamage(int amount, Mobile from)
        {
            int num1;
            DamageEntry entry3;
            DamageEntry entry1 = this.FindDamageEntryFor(from);
            if (entry1 == null)
            {
                entry1 = new DamageEntry(from);
            }
            entry1.DamageGiven += amount;
            entry1.LastDamage = DateTime.Now;
            this.m_DamageEntries.Remove(entry1);
            this.m_DamageEntries.Add(entry1);
            Mobile mobile1 = from.GetDamageMaster(this);
            if (mobile1 == null)
            {
                return entry1;
            }
            ArrayList list1 = entry1.Responsible;
            if (list1 == null)
            {
                entry1.Responsible = (list1 = new ArrayList());
            }
            DamageEntry entry2 = null;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                entry3 = ((DamageEntry) list1[num1]);
                if (entry3.Damager == mobile1)
                {
                    entry2 = entry3;
                    break;
                }
            }
            if (entry2 == null)
            {
                list1.Add((entry2 = new DamageEntry(mobile1)));
            }
            entry2.DamageGiven += amount;
            entry2.LastDamage = DateTime.Now;
            return entry1;
        }

        public void RemoveAggressed(Mobile aggressed)
        {
            int num1;
            AggressorInfo info1;
            if (this.m_Deleted)
            {
                return;
            }
            ArrayList list1 = this.m_Aggressed;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                info1 = ((AggressorInfo) list1[num1]);
                if (info1.Defender == aggressed)
                {
                    this.m_Aggressed.RemoveAt(num1);
                    info1.Free();
                    if ((this.m_NetState == null) || !this.CanSee(aggressed))
                    {
                        break;
                    }
                    this.m_NetState.Send(new MobileIncoming(this, aggressed));
                    break;
                }
            }
            this.UpdateAggrExpire();
        }

        public void RemoveAggressor(Mobile aggressor)
        {
            int num1;
            AggressorInfo info1;
            if (this.m_Deleted)
            {
                return;
            }
            ArrayList list1 = this.m_Aggressors;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                info1 = ((AggressorInfo) list1[num1]);
                if (info1.Attacker == aggressor)
                {
                    this.m_Aggressors.RemoveAt(num1);
                    info1.Free();
                    if ((this.m_NetState == null) || !this.CanSee(aggressor))
                    {
                        break;
                    }
                    this.m_NetState.Send(new MobileIncoming(this, aggressor));
                    break;
                }
            }
            this.UpdateAggrExpire();
        }

        public void RemoveItem(Item item)
        {
            if ((item == null) || (this.m_Items == null))
            {
                return;
            }
            if (!this.m_Items.Contains(item))
            {
                return;
            }
            item.SendRemovePacket();
            this.m_Items.Count;
            this.m_Items.Remove(item);
            if (!(item is BankBox))
            {
                this.TotalWeight -= (item.TotalWeight + item.PileWeight);
                this.TotalGold -= item.TotalGold;
            }
            item.Parent = null;
            item.OnRemoved(this);
            this.OnItemRemoved(item);
            if ((!(item.PhysicalResistance == 0) || !(item.FireResistance == 0)) || ((!(item.ColdResistance == 0) || !(item.PoisonResistance == 0)) || !(item.EnergyResistance == 0)))
            {
                this.UpdateResistances();
            }
            return;
        }

        public virtual void RemoveResistanceMod(ResistanceMod toRemove)
        {
            if (this.m_ResistMods != null)
            {
                this.m_ResistMods.Remove(toRemove);
                if (this.m_ResistMods.Count == 0)
                {
                    this.m_ResistMods = null;
                }
            }
            this.UpdateResistances();
        }

        public virtual void RemoveSkillMod(SkillMod mod)
        {
            if (mod == null)
            {
                return;
            }
            this.ValidateSkillMods();
            this.InternalRemoveSkillMod(mod);
        }

        public bool RemoveStatMod(string name)
        {
            int num1;
            StatMod mod1;
            for (num1 = 0; (num1 < this.m_StatMods.Count); ++num1)
            {
                mod1 = ((StatMod) this.m_StatMods[num1]);
                if (mod1.Name == name)
                {
                    this.m_StatMods.RemoveAt(num1);
                    this.CheckStatTimers();
                    this.Delta(MobileDelta.Stat);
                    return true;
                }
            }
            return false;
        }

        public virtual void Resurrect()
        {
            int num1;
            Item item1;
            if (this.Alive)
            {
                return;
            }
            if (!this.Region.OnResurrect(this))
            {
                return;
            }
            if (!this.CheckResurrect())
            {
                return;
            }
            this.OnBeforeResurrect();
            BankBox box1 = this.FindBankNoCreate();
            if ((box1 != null) && box1.Opened)
            {
                box1.Close();
            }
            this.Poison = null;
            this.Warmode = false;
            this.Hits = 10;
            this.Stam = this.StamMax;
            this.Mana = 0;
            this.BodyMod = Body.op_Implicit(0);
            this.Body = Body.op_Implicit((this.m_Female ? 401 : 400));
            Mobile.ProcessDeltaQueue();
            for (num1 = (this.m_Items.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_Items.Count)
                {
                    item1 = ((Item) this.m_Items[num1]);
                    if (item1.ItemID == 8270)
                    {
                        item1.Delete();
                    }
                }
            }
            this.SendIncomingPacket();
            this.SendIncomingPacket();
            this.OnAfterResurrect();
        }

        public virtual void RevealingAction()
        {
            if (this.m_Hidden && (this.m_AccessLevel == AccessLevel.Player))
            {
                this.Hidden = false;
            }
            this.DisruptiveAction();
        }

        public virtual int SafeBody(int body)
        {
            int num2;
            int num1 = -1;
            for (num2 = 0; ((num1 < 0) && (num2 < Mobile.m_InvalidBodies.Length)); ++num2)
            {
                num1 = (Mobile.m_InvalidBodies[num2] - body);
            }
            if (num1 != 0)
            {
                return body;
            }
            return 0;
        }

        public void Say(int number)
        {
            this.Say(number, "");
        }

        public void Say(string text)
        {
            this.PublicOverheadMessage(MessageType.Regular, this.m_SpeechHue, false, text);
        }

        public void Say(bool ascii, string text)
        {
            this.PublicOverheadMessage(MessageType.Regular, this.m_SpeechHue, ascii, text);
        }

        public void Say(int number, string args)
        {
            this.PublicOverheadMessage(MessageType.Regular, this.m_SpeechHue, number, args);
        }

        public void Say(string format, params object[] args)
        {
            this.Say(string.Format(format, args));
        }

        public void Say(int number, AffixType type, string affix, string args)
        {
            this.PublicOverheadMessage(MessageType.Regular, this.m_SpeechHue, number, type, affix, args);
        }

        public void SayTo(Mobile to, int number)
        {
            to.Send(new MessageLocalized(this.m_Serial, Body.op_Implicit(this.Body), MessageType.Regular, this.m_SpeechHue, 3, number, this.Name, ""));
        }

        public void SayTo(Mobile to, string text)
        {
            this.SayTo(to, false, text);
        }

        public void SayTo(Mobile to, bool ascii, string text)
        {
            this.PrivateOverheadMessage(MessageType.Regular, this.m_SpeechHue, ascii, text, to.NetState);
        }

        public void SayTo(Mobile to, int number, string args)
        {
            to.Send(new MessageLocalized(this.m_Serial, Body.op_Implicit(this.Body), MessageType.Regular, this.m_SpeechHue, 3, number, this.Name, args));
        }

        public void SayTo(Mobile to, string format, params object[] args)
        {
            this.SayTo(to, false, string.Format(format, args));
        }

        public void SayTo(Mobile to, bool ascii, string format, params object[] args)
        {
            this.SayTo(to, ascii, string.Format(format, args));
        }

        public bool Send(Packet p)
        {
            return this.Send(p, false);
        }

        public bool Send(Packet p, bool throwOnOffline)
        {
            if (this.m_NetState != null)
            {
                this.m_NetState.Send(p);
                return true;
            }
            if (throwOnOffline)
            {
                throw new MobileNotConnectedException(this, "Packet could not be sent.");
            }
            return false;
        }

        public virtual void SendActionMessage()
        {
            if (DateTime.Now < this.m_NextActionMessage)
            {
                return;
            }
            this.m_NextActionMessage = (DateTime.Now + Mobile.m_ActionMessageDelay);
            this.SendLocalizedMessage(500119);
        }

        public void SendAsciiMessage(string text)
        {
            this.SendAsciiMessage(946, text);
        }

        public void SendAsciiMessage(int hue, string text)
        {
            NetState state1 = this.m_NetState;
            if (state1 != null)
            {
                state1.Send(new AsciiMessage(Serial.MinusOne, -1, MessageType.Regular, hue, 3, "System", text));
            }
        }

        public void SendAsciiMessage(string format, params object[] args)
        {
            this.SendAsciiMessage(946, string.Format(format, args));
        }

        public void SendAsciiMessage(int hue, string format, params object[] args)
        {
            this.SendAsciiMessage(hue, string.Format(format, args));
        }

        public virtual void SendDamageToAll(int amount)
        {
            if (amount < 0)
            {
                return;
            }
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return;
            }
            IPooledEnumerable enumerable1 = map1.GetClientsInRange(this.m_Location);
            Packet packet1 = null;
            foreach (NetState state1 in enumerable1)
            {
                if (state1.Mobile.CanSee(this))
                {
                    if (packet1 == null)
                    {
                        packet1 = new DamagePacket(this, amount);
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public virtual void SendDropEffect(Item item)
        {
            IEntity entity1;
            if (!Mobile.DragEffects)
            {
                return;
            }
            Map map1 = this.m_Map;
            object obj1 = item.RootParent;
            if ((map1 == null) || ((obj1 != null) && !(obj1 is Item)))
            {
                return;
            }
            IPooledEnumerable enumerable1 = map1.GetClientsInRange(this.m_Location);
            Packet packet1 = null;
            foreach (NetState state1 in enumerable1)
            {
                if ((state1.Mobile == this) || !state1.Mobile.CanSee(this))
                {
                    continue;
                }
                if (packet1 == null)
                {
                    if (obj1 == null)
                    {
                        entity1 = new Entity(Serial.Zero, item.Location, map1);
                    }
                    else
                    {
                        entity1 = new Entity(((Item) obj1).Serial, ((Item) obj1).Location, map1);
                    }
                    packet1 = new DragEffect(this, entity1, item.ItemID, item.Hue, item.Amount);
                }
                state1.Send(packet1);
            }
            enumerable1.Free();
        }

        public void SendEverything()
        {
            Item item1;
            Mobile mobile1;
            NetState state1 = this.m_NetState;
            if ((this.m_Map == null) || (state1 == null))
            {
                return;
            }
            IPooledEnumerable enumerable1 = this.m_Map.GetObjectsInRange(this.m_Location, Core.GlobalMaxUpdateRange);
            foreach (object obj1 in enumerable1)
            {
                if ((obj1 is Item))
                {
                    item1 = ((Item) obj1);
                    if (!this.CanSee(item1) || !this.InRange(item1.Location, item1.GetUpdateRange(this)))
                    {
                        continue;
                    }
                    item1.SendInfoTo(state1);
                    continue;
                }
                if ((obj1 is Mobile))
                {
                    mobile1 = ((Mobile) obj1);
                    if (this.CanSee(mobile1) && Utility.InUpdateRange(this.m_Location, mobile1.m_Location))
                    {
                        state1.Send(new MobileIncoming(this, mobile1));
                        if (mobile1.IsDeadBondedPet)
                        {
                            state1.Send(new BondedStatus(0, mobile1.m_Serial, 1));
                        }
                        if (ObjectPropertyList.Enabled)
                        {
                            state1.Send(mobile1.OPLPacket);
                        }
                    }
                }
            }
            enumerable1.Free();
        }

        public bool SendGump(Gump g)
        {
            return this.SendGump(g, false);
        }

        public bool SendGump(Gump g, bool throwOnOffline)
        {
            if (this.m_NetState != null)
            {
                g.SendTo(this.m_NetState);
                return true;
            }
            if (throwOnOffline)
            {
                throw new MobileNotConnectedException(this, "Gump could not be sent.");
            }
            return false;
        }

        public bool SendHuePicker(HuePicker p)
        {
            return this.SendHuePicker(p, false);
        }

        public bool SendHuePicker(HuePicker p, bool throwOnOffline)
        {
            if (this.m_NetState != null)
            {
                p.SendTo(this.m_NetState);
                return true;
            }
            if (throwOnOffline)
            {
                throw new MobileNotConnectedException(this, "Hue picker could not be sent.");
            }
            return false;
        }

        public void SendIncomingPacket()
        {
            if (this.m_Map == null)
            {
                return;
            }
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if (state1.Mobile.CanSee(this))
                {
                    state1.Send(new MobileIncoming(state1.Mobile, this));
                    if (this.IsDeadBondedPet)
                    {
                        state1.Send(new BondedStatus(0, this.m_Serial, 1));
                    }
                    if (ObjectPropertyList.Enabled)
                    {
                        state1.Send(this.OPLPacket);
                    }
                }
            }
            enumerable1.Free();
        }

        public void SendLocalizedMessage(int number)
        {
            NetState state1 = this.m_NetState;
            if (state1 != null)
            {
                state1.Send(MessageLocalized.InstantiateGeneric(number));
            }
        }

        public void SendLocalizedMessage(int number, string args)
        {
            NetState state1;
            if ((args == null) || (args.Length == 0))
            {
                state1 = this.m_NetState;
                if (state1 == null)
                {
                    return;
                }
                state1.Send(MessageLocalized.InstantiateGeneric(number));
                return;
            }
            NetState state2 = this.m_NetState;
            if (state2 != null)
            {
                state2.Send(new MessageLocalized(Serial.MinusOne, -1, MessageType.Regular, 946, 3, number, "System", args));
            }
        }

        public void SendLocalizedMessage(int number, bool append, string affix)
        {
            this.SendLocalizedMessage(number, append, affix, "", 946);
        }

        public void SendLocalizedMessage(int number, string args, int hue)
        {
            NetState state1;
            if ((hue == 946) && ((args == null) || (args.Length == 0)))
            {
                state1 = this.m_NetState;
                if (state1 == null)
                {
                    return;
                }
                state1.Send(MessageLocalized.InstantiateGeneric(number));
                return;
            }
            NetState state2 = this.m_NetState;
            if (state2 != null)
            {
                state2.Send(new MessageLocalized(Serial.MinusOne, -1, MessageType.Regular, hue, 3, number, "System", args));
            }
        }

        public void SendLocalizedMessage(int number, bool append, string affix, string args)
        {
            this.SendLocalizedMessage(number, append, affix, args);
        }

        public void SendLocalizedMessage(int number, bool append, string affix, string args, int hue)
        {
            NetState state1 = this.m_NetState;
            if (state1 != null)
            {
                state1.Send(new MessageLocalizedAffix(Serial.MinusOne, -1, MessageType.Regular, hue, 3, number, "System", ((append ? 0 : 1) | 2), affix, args));
            }
        }

        public bool SendMenu(IMenu m)
        {
            return this.SendMenu(m, false);
        }

        public bool SendMenu(IMenu m, bool throwOnOffline)
        {
            if (this.m_NetState != null)
            {
                m.SendTo(this.m_NetState);
                return true;
            }
            if (throwOnOffline)
            {
                throw new MobileNotConnectedException(this, "Menu could not be sent.");
            }
            return false;
        }

        public void SendMessage(string text)
        {
            this.SendMessage(946, text);
        }

        public void SendMessage(int hue, string text)
        {
            NetState state1 = this.m_NetState;
            if (state1 != null)
            {
                state1.Send(new UnicodeMessage(Serial.MinusOne, -1, MessageType.Regular, hue, 3, "ENU", "System", text));
            }
        }

        public void SendMessage(string format, params object[] args)
        {
            this.SendMessage(946, string.Format(format, args));
        }

        public void SendMessage(int hue, string format, params object[] args)
        {
            this.SendMessage(hue, string.Format(format, args));
        }

        public virtual void SendPropertiesTo(Mobile from)
        {
            from.Send(this.PropertyList);
        }

        public void SendRemovePacket()
        {
            this.SendRemovePacket(true);
        }

        public void SendRemovePacket(bool everyone)
        {
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
            foreach (NetState state1 in enumerable1)
            {
                if ((state1 != this.m_NetState) && (everyone || !state1.Mobile.CanSee(this)))
                {
                    if (packet1 == null)
                    {
                        packet1 = this.RemovePacket;
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public virtual void SendSkillMessage()
        {
            if (DateTime.Now < this.m_NextActionMessage)
            {
                return;
            }
            this.m_NextActionMessage = (DateTime.Now + Mobile.m_ActionMessageDelay);
            this.SendLocalizedMessage(500118);
        }

        public void SendSound(int soundID)
        {
            if ((soundID != -1) && (this.m_NetState != null))
            {
                this.Send(new PlaySound(soundID, this));
            }
        }

        public void SendSound(int soundID, IPoint3D p)
        {
            if ((soundID != -1) && (this.m_NetState != null))
            {
                this.Send(new PlaySound(soundID, p));
            }
        }

        public virtual void Serialize(GenericWriter writer)
        {
            int num1;
            int num2;
            writer.Write(28);
            writer.WriteDeltaTime(this.m_LastStatGain);
            writer.Write(this.m_TithingPoints);
            writer.Write(this.m_Corpse);
            writer.Write(this.m_CreationTime);
            writer.WriteMobileList(this.m_Stabled, true);
            writer.Write(this.m_CantWalk);
            VirtueInfo.Serialize(writer, this.m_Virtues);
            writer.Write(this.m_Thirst);
            writer.Write(this.m_BAC);
            writer.Write(this.m_ShortTermMurders);
            writer.Write(this.m_FollowersMax);
            writer.Write(this.m_MagicDamageAbsorb);
            writer.Write(this.m_GuildFealty);
            writer.Write(this.m_Guild);
            writer.Write(this.m_DisplayGuildTitle);
            writer.Write(this.m_CanSwim);
            writer.Write(this.m_Squelched);
            writer.Write(this.m_Holding);
            writer.Write(this.m_VirtualArmor);
            writer.Write(this.m_BaseSoundID);
            writer.Write(this.m_DisarmReady);
            writer.Write(this.m_StunReady);
            writer.Write(this.m_StatCap);
            writer.Write(this.m_NameHue);
            writer.Write(this.m_Hunger);
            writer.Write(this.m_Location);
            writer.Write(Body.op_Implicit(this.m_Body));
            writer.Write(this.m_Name);
            writer.Write(this.m_GuildTitle);
            writer.Write(this.m_Criminal);
            writer.Write(this.m_Kills);
            writer.Write(this.m_SpeechHue);
            writer.Write(this.m_EmoteHue);
            writer.Write(this.m_WhisperHue);
            writer.Write(this.m_YellHue);
            writer.Write(this.m_Language);
            writer.Write(this.m_Female);
            writer.Write(this.m_Warmode);
            writer.Write(this.m_Hidden);
            writer.Write(((byte) this.m_Direction));
            writer.Write(this.m_Hue);
            writer.Write(this.m_Str);
            writer.Write(this.m_Dex);
            writer.Write(this.m_Int);
            writer.Write(this.m_Hits);
            writer.Write(this.m_Stam);
            writer.Write(this.m_Mana);
            writer.Write(this.m_Map);
            writer.Write(this.m_Blessed);
            writer.Write(this.m_Fame);
            writer.Write(this.m_Karma);
            writer.Write(((byte) this.m_AccessLevel));
            this.m_Skills.Serialize(writer);
            writer.Write(this.m_Items.Count);
            for (num1 = 0; (num1 < this.m_Items.Count); ++num1)
            {
                writer.Write(((Item) this.m_Items[num1]));
            }
            writer.Write(this.m_Player);
            writer.Write(this.m_Title);
            writer.Write(this.m_Profile);
            writer.Write(this.m_ProfileLocked);
            writer.Write(this.m_AutoPageNotify);
            writer.Write(this.m_LogoutLocation);
            writer.Write(this.m_LogoutMap);
            writer.Write(((byte) this.m_StrLock));
            writer.Write(((byte) this.m_DexLock));
            writer.Write(((byte) this.m_IntLock));
            if (this.m_StuckMenuUses != null)
            {
                writer.Write(true);
                writer.Write(this.m_StuckMenuUses.Length);
                for (num2 = 0; (num2 < this.m_StuckMenuUses.Length); ++num2)
                {
                    writer.Write(this.m_StuckMenuUses[num2]);
                }
                return;
            }
            writer.Write(false);
        }

        public void SetDirection(Direction dir)
        {
            this.m_Direction = dir;
        }

        public virtual void SetLocation(Point3D newLocation, bool isTeleport)
        {
            Packet packet1;
            IPooledEnumerable enumerable1;
            NetState state2;
            Item item1;
            int num1;
            Point3D pointd2;
            Mobile mobile1;
            bool flag1;
            Point3D pointd1 = this.m_Location;
            Region region1 = this.m_Region;
            if (pointd1 == newLocation)
            {
                return;
            }
            this.m_Location = newLocation;
            BankBox box1 = this.FindBankNoCreate();
            if ((box1 != null) && box1.Opened)
            {
                box1.Close();
            }
            if (this.m_NetState != null)
            {
                this.m_NetState.ValidateAllTrades();
            }
            if (this.m_Map != null)
            {
                this.m_Map.OnMove(pointd1, this);
            }
            if (isTeleport && (this.m_NetState != null))
            {
                this.m_NetState.Sequence = 0;
                this.m_NetState.Send(new MobileUpdate(this));
                this.ClearFastwalkStack();
            }
            Map map1 = this.m_Map;
            if (map1 != null)
            {
                packet1 = null;
                enumerable1 = map1.GetClientsInRange(pointd1);
                foreach (NetState state1 in enumerable1)
                {
                    if ((state1 != this.m_NetState) && !Utility.InUpdateRange(newLocation, state1.Mobile.Location))
                    {
                        if (packet1 == null)
                        {
                            packet1 = this.RemovePacket;
                        }
                        state1.Send(packet1);
                    }
                }
                enumerable1.Free();
                state2 = this.m_NetState;
                if (state2 != null)
                {
                    enumerable1 = map1.GetObjectsInRange(newLocation, Core.GlobalMaxUpdateRange);
                    foreach (object obj1 in enumerable1)
                    {
                        if ((obj1 is Item))
                        {
                            item1 = ((Item) obj1);
                            num1 = item1.GetUpdateRange(this);
                            pointd2 = item1.Location;
                            if ((!this.CanSee(item1) || Utility.InRange(pointd1, pointd2, num1)) || !Utility.InRange(newLocation, pointd2, num1))
                            {
                                continue;
                            }
                            item1.SendInfoTo(state2);
                            continue;
                        }
                        if ((obj1 != this) && (obj1 is Mobile))
                        {
                            mobile1 = ((Mobile) obj1);
                            if (Utility.InUpdateRange(newLocation, mobile1.m_Location))
                            {
                                flag1 = Utility.InUpdateRange(pointd1, mobile1.m_Location);
                                if ((isTeleport || !flag1) && ((mobile1.m_NetState != null) && mobile1.CanSee(this)))
                                {
                                    mobile1.m_NetState.Send(new MobileIncoming(mobile1, this));
                                    if (this.IsDeadBondedPet)
                                    {
                                        mobile1.m_NetState.Send(new BondedStatus(0, this.m_Serial, 1));
                                    }
                                    if (ObjectPropertyList.Enabled)
                                    {
                                        mobile1.m_NetState.Send(this.OPLPacket);
                                    }
                                }
                                if (!flag1 && this.CanSee(mobile1))
                                {
                                    state2.Send(new MobileIncoming(this, mobile1));
                                    if (mobile1.IsDeadBondedPet)
                                    {
                                        state2.Send(new BondedStatus(0, mobile1.m_Serial, 1));
                                    }
                                    if (ObjectPropertyList.Enabled)
                                    {
                                        state2.Send(mobile1.OPLPacket);
                                    }
                                }
                            }
                        }
                    }
                    enumerable1.Free();
                }
                else
                {
                    enumerable1 = map1.GetClientsInRange(newLocation);
                    foreach (NetState state3 in enumerable1)
                    {
                        if ((isTeleport || !Utility.InUpdateRange(pointd1, state3.Mobile.Location)) && state3.Mobile.CanSee(this))
                        {
                            state3.Send(new MobileIncoming(state3.Mobile, this));
                            if (this.IsDeadBondedPet)
                            {
                                state3.Send(new BondedStatus(0, this.m_Serial, 1));
                            }
                            if (ObjectPropertyList.Enabled)
                            {
                                state3.Send(this.OPLPacket);
                            }
                        }
                    }
                    enumerable1.Free();
                }
            }
            this.m_Region = Region.Find(this.m_Location, this.m_Map);
            if (region1 != this.m_Region)
            {
                region1.InternalExit(this);
                this.m_Region.InternalEnter(this);
                this.OnRegionChange(region1, this.m_Region);
            }
            this.OnLocationChange(pointd1);
            this.CheckLightLevels(false);
            this.m_Region.OnLocationChanged(this, pointd1);
        }

        private void StopAggrExpire()
        {
            if (this.m_ExpireAggrTimer != null)
            {
                this.m_ExpireAggrTimer.Stop();
            }
            this.m_ExpireAggrTimer = null;
        }

        public override string ToString()
        {
            return string.Format("0x{0:X} \"{1}\"", this.m_Serial.Value, this.Name);
        }

        private void UpdateAggrExpire()
        {
            if (this.m_Deleted || ((this.m_Aggressors.Count == 0) && (this.m_Aggressed.Count == 0)))
            {
                this.StopAggrExpire();
                return;
            }
            if (this.m_ExpireAggrTimer == null)
            {
                this.m_ExpireAggrTimer = new ExpireAggressorsTimer(this);
                this.m_ExpireAggrTimer.Start();
            }
        }

        public virtual void UpdateResistances()
        {
            int num1;
            if (this.m_Resistances == null)
            {
                this.m_Resistances = new int[5] { -2147483648, -2147483648, -2147483648, -2147483648, -2147483648 };
            }
            bool flag1 = false;
            for (num1 = 0; (num1 < this.m_Resistances.Length); ++num1)
            {
                if (this.m_Resistances[num1] != -2147483648)
                {
                    this.m_Resistances[num1] = -2147483648;
                    flag1 = true;
                }
            }
            if (flag1)
            {
                this.Delta(MobileDelta.Resistances);
            }
        }

        public virtual void UpdateSkillMods()
        {
            int num1;
            SkillMod mod1;
            Skill skill1;
            this.ValidateSkillMods();
            for (num1 = 0; (num1 < this.m_SkillMods.Count); ++num1)
            {
                mod1 = ((SkillMod) this.m_SkillMods[num1]);
                skill1 = this.m_Skills[mod1.Skill];
                if (skill1 != null)
                {
                    skill1.Update();
                }
            }
        }

        public virtual void UpdateTotals()
        {
            int num2;
            Item item1;
            if (this.m_Items == null)
            {
                return;
            }
            int num1 = this.m_TotalWeight;
            this.m_TotalGold = 0;
            this.m_TotalWeight = 0;
            for (num2 = 0; (num2 < this.m_Items.Count); ++num2)
            {
                item1 = ((Item) this.m_Items[num2]);
                item1.UpdateTotals();
                if (!(item1 is BankBox))
                {
                    this.m_TotalGold += item1.TotalGold;
                    this.m_TotalWeight += (item1.TotalWeight + item1.PileWeight);
                }
            }
            if (this.m_Holding != null)
            {
                this.m_TotalWeight += (this.m_Holding.TotalWeight + this.m_Holding.PileWeight);
            }
            this.OnWeightChange(num1);
        }

        public virtual void Use(Item item)
        {
            Region region1;
            if ((item == null) || item.Deleted)
            {
                return;
            }
            this.DisruptiveAction();
            if ((this.m_Spell != null) && !this.m_Spell.OnCasterUsingObject(item))
            {
                return;
            }
            object obj1 = item.RootParent;
            bool flag1 = false;
            if (!Utility.InUpdateRange(this, item.GetWorldLocation()))
            {
                item.OnDoubleClickOutOfRange(this);
            }
            else if (!this.CanSee(item))
            {
                item.OnDoubleClickCantSee(this);
            }
            else if (!item.IsAccessibleTo(this))
            {
                region1 = Region.Find(item.GetWorldLocation(), item.Map);
                if ((region1 == null) || !region1.SendInaccessibleMessage(item, this))
                {
                    item.OnDoubleClickNotAccessible(this);
                }
            }
            else if (!this.CheckAlive(false))
            {
                item.OnDoubleClickDead(this);
            }
            else if (item.InSecureTrade)
            {
                item.OnDoubleClickSecureTrade(this);
            }
            else if (!this.AllowItemUse(item))
            {
                flag1 = false;
            }
            else if (!item.CheckItemUse(this, item))
            {
                flag1 = false;
            }
            else if (((obj1 != null) && (obj1 is Mobile)) && ((Mobile) obj1).IsSnoop(this))
            {
                item.OnSnoop(this);
            }
            else if (this.m_Region.OnDoubleClick(this, item))
            {
                flag1 = true;
            }
        Label_010E:
            if (!flag1)
            {
                return;
            }
            if (!item.Deleted)
            {
                item.OnItemUsed(this, item);
            }
            if (!item.Deleted)
            {
                item.OnDoubleClick(this);
            }
        }

        public virtual void Use(Mobile m)
        {
            if ((m == null) || m.Deleted)
            {
                return;
            }
            this.DisruptiveAction();
            if ((this.m_Spell != null) && !this.m_Spell.OnCasterUsingObject(m))
            {
                return;
            }
            if (!Utility.InUpdateRange(this, m))
            {
                m.OnDoubleClickOutOfRange(this);
                return;
            }
            if (!this.CanSee(m))
            {
                m.OnDoubleClickCantSee(this);
                return;
            }
            if (!this.CheckAlive(false))
            {
                m.OnDoubleClickDead(this);
                return;
            }
            if (this.m_Region.OnDoubleClick(this, m) && !m.Deleted)
            {
                m.OnDoubleClick(this);
            }
        }

        public void UsedStuckMenu()
        {
            int num1;
            if (this.m_StuckMenuUses == null)
            {
                this.m_StuckMenuUses = new DateTime[2];
            }
            for (num1 = 0; (num1 < this.m_StuckMenuUses.Length); ++num1)
            {
                if ((DateTime.Now - this.m_StuckMenuUses[num1]) > TimeSpan.FromDays(1))
                {
                    this.m_StuckMenuUses[num1] = DateTime.Now;
                    return;
                }
            }
        }

        public virtual bool UseSkill(SkillName name)
        {
            return Skills.UseSkill(this, name);
        }

        public virtual bool UseSkill(int skillID)
        {
            return Skills.UseSkill(this, skillID);
        }

        public virtual void ValidateSkillMods()
        {
            SkillMod mod1;
            int num1 = 0;
            while ((num1 < this.m_SkillMods.Count))
            {
                mod1 = ((SkillMod) this.m_SkillMods[num1]);
                if (mod1.CheckCondition())
                {
                    ++num1;
                    continue;
                }
                this.InternalRemoveSkillMod(mod1);
            }
        }

        public void Whisper(int number)
        {
            this.Whisper(number, "");
        }

        public void Whisper(string text)
        {
            this.PublicOverheadMessage(MessageType.Whisper, this.m_WhisperHue, false, text);
        }

        public void Whisper(int number, string args)
        {
            this.PublicOverheadMessage(MessageType.Whisper, this.m_WhisperHue, number, args);
        }

        public void Whisper(string format, params object[] args)
        {
            this.Whisper(string.Format(format, args));
        }

        public void Yell(int number)
        {
            this.Yell(number, "");
        }

        public void Yell(string text)
        {
            this.PublicOverheadMessage(MessageType.Yell, this.m_YellHue, false, text);
        }

        public void Yell(int number, string args)
        {
            this.PublicOverheadMessage(MessageType.Yell, this.m_YellHue, number, args);
        }

        public void Yell(string format, params object[] args)
        {
            this.Yell(string.Format(format, args));
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor, AccessLevel.Administrator)]
        public AccessLevel AccessLevel
        {
            get
            {
                return this.m_AccessLevel;
            }
            set
            {
                object[] objArray1;
                AccessLevel level1 = this.m_AccessLevel;
                if (level1 != value)
                {
                    this.m_AccessLevel = value;
                    this.Delta(MobileDelta.Noto);
                    this.InvalidateProperties();
                    objArray1 = new object[1];
                    objArray1[0] = Mobile.GetAccessLevelName(value);
                    this.SendMessage("Your access level has been changed. You are now {0}.", objArray1);
                    this.ClearScreen();
                    this.SendEverything();
                    this.OnAccessLevelChanged(level1);
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, (AccessLevel.Administrator | AccessLevel.Counselor))]
        public IAccount Account
        {
            get
            {
                return this.m_Account;
            }
            set
            {
                this.m_Account = value;
            }
        }

        public static TimeSpan ActionMessageDelay
        {
            get
            {
                return Mobile.m_ActionMessageDelay;
            }
            set
            {
                Mobile.m_ActionMessageDelay = value;
            }
        }

        public ArrayList Aggressed
        {
            get
            {
                return this.m_Aggressed;
            }
        }

        public ArrayList Aggressors
        {
            get
            {
                return this.m_Aggressors;
            }
        }

        public virtual bool Alive
        {
            get
            {
                if (!this.m_Deleted)
                {
                    if (this.m_Player)
                    {
                        return !this.m_Body.IsGhost;
                    }
                    return true;
                }
                return false;
            }
        }

        public static AllowBeneficialHandler AllowBeneficialHandler
        {
            get
            {
                return Mobile.m_AllowBeneficialHandler;
            }
            set
            {
                Mobile.m_AllowBeneficialHandler = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int AllowedStealthSteps
        {
            get
            {
                return this.m_AllowedStealthSteps;
            }
            set
            {
                this.m_AllowedStealthSteps = value;
            }
        }

        public static AllowHarmfulHandler AllowHarmfulHandler
        {
            get
            {
                return Mobile.m_AllowHarmfulHandler;
            }
            set
            {
                Mobile.m_AllowHarmfulHandler = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public double ArmorRating
        {
            get
            {
                double num1 = 0;
                IArmor armor1 = this.NeckArmor;
                if (armor1 != null)
                {
                    num1 += armor1.ArmorRating;
                }
                armor1 = this.HandArmor;
                if (armor1 != null)
                {
                    num1 += armor1.ArmorRating;
                }
                armor1 = this.HeadArmor;
                if (armor1 != null)
                {
                    num1 += armor1.ArmorRating;
                }
                armor1 = this.ArmsArmor;
                if (armor1 != null)
                {
                    num1 += armor1.ArmorRating;
                }
                armor1 = this.LegsArmor;
                if (armor1 != null)
                {
                    num1 += armor1.ArmorRating;
                }
                armor1 = this.ChestArmor;
                if (armor1 != null)
                {
                    num1 += armor1.ArmorRating;
                }
                armor1 = this.ShieldArmor;
                if (armor1 != null)
                {
                    num1 += armor1.ArmorRating;
                }
                return ((this.m_VirtualArmor + this.m_VirtualArmorMod) + num1);
            }
        }

        public IArmor ArmsArmor
        {
            get
            {
                return (this.FindItemOnLayer(Layer.Arms) as IArmor);
            }
        }

        public static bool AsciiClickMessage
        {
            get
            {
                return Mobile.m_AsciiClickMessage;
            }
            set
            {
                Mobile.m_AsciiClickMessage = value;
            }
        }

        public static TimeSpan AutoManifestTimeout
        {
            get
            {
                return Mobile.m_AutoManifestTimeout;
            }
            set
            {
                Mobile.m_AutoManifestTimeout = value;
            }
        }

        [CommandProperty(AccessLevel.Administrator)]
        public bool AutoPageNotify
        {
            get
            {
                return this.m_AutoPageNotify;
            }
            set
            {
                this.m_AutoPageNotify = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BAC
        {
            get
            {
                return this.m_BAC;
            }
            set
            {
                this.m_BAC = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Container Backpack
        {
            get
            {
                Container container1;
                if (((this.m_Backpack != null) && !this.m_Backpack.Deleted) && (this.m_Backpack.Parent == this))
                {
                    return this.m_Backpack;
                }
                this.m_Backpack = (container1 = (this.FindItemOnLayer(Layer.Backpack) as Container));
                return container1;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public BankBox BankBox
        {
            get
            {
                BankBox box1;
                if (((this.m_BankBox != null) && !this.m_BankBox.Deleted) && (this.m_BankBox.Parent == this))
                {
                    return this.m_BankBox;
                }
                this.m_BankBox = (this.FindItemOnLayer(Layer.Bank) as BankBox);
                if (this.m_BankBox == null)
                {
                    this.m_BankBox = (box1 = new BankBox(this));
                    this.AddItem(box1);
                }
                return this.m_BankBox;
            }
        }

        public virtual int BaseColdResistance
        {
            get
            {
                return 0;
            }
        }

        public virtual int BaseEnergyResistance
        {
            get
            {
                return 0;
            }
        }

        public virtual int BaseFireResistance
        {
            get
            {
                return 0;
            }
        }

        public virtual int BasePhysicalResistance
        {
            get
            {
                return 0;
            }
        }

        public virtual int BasePoisonResistance
        {
            get
            {
                return 0;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BaseSoundID
        {
            get
            {
                return this.m_BaseSoundID;
            }
            set
            {
                this.m_BaseSoundID = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Item Beard
        {
            get
            {
                Item item1;
                if (((this.m_Beard != null) && !this.m_Beard.Deleted) && (this.m_Beard.Parent == this))
                {
                    return this.m_Beard;
                }
                this.m_Beard = (item1 = this.FindItemOnLayer(Layer.FacialHair));
                return item1;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Blessed
        {
            get
            {
                return this.m_Blessed;
            }
            set
            {
                if (this.m_Blessed != value)
                {
                    this.m_Blessed = value;
                    this.Delta(MobileDelta.Flags);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster), Body]
        public Body Body
        {
            get
            {
                if (this.IsBodyMod)
                {
                    return this.m_BodyMod;
                }
                return this.m_Body;
            }
            set
            {
                if ((this.m_Body != value) && !this.IsBodyMod)
                {
                    this.m_Body = Body.op_Implicit(this.SafeBody(Body.op_Implicit(value)));
                    this.Delta(MobileDelta.Body);
                    this.InvalidateProperties();
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Body BodyMod
        {
            get
            {
                return this.m_BodyMod;
            }
            set
            {
                if (this.m_BodyMod != value)
                {
                    this.m_BodyMod = value;
                    this.Delta(MobileDelta.Body);
                    this.InvalidateProperties();
                }
            }
        }

        [Body, CommandProperty(AccessLevel.GameMaster)]
        public int BodyValue
        {
            get
            {
                Body body1 = this.Body;
                return body1.BodyID;
            }
            set
            {
                this.Body = Body.op_Implicit(value);
            }
        }

        public static int BodyWeight
        {
            get
            {
                return Mobile.m_BodyWeight;
            }
            set
            {
                Mobile.m_BodyWeight = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool CanHearGhosts
        {
            get
            {
                if (!this.m_CanHearGhosts)
                {
                    return (this.AccessLevel >= AccessLevel.Counselor);
                }
                return true;
            }
            set
            {
                this.m_CanHearGhosts = value;
            }
        }

        public virtual bool CanRegenHits
        {
            get
            {
                if (this.Alive)
                {
                    return !this.Poisoned;
                }
                return false;
            }
        }

        public virtual bool CanRegenMana
        {
            get
            {
                return this.Alive;
            }
        }

        public virtual bool CanRegenStam
        {
            get
            {
                return this.Alive;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool CanSwim
        {
            get
            {
                return this.m_CanSwim;
            }
            set
            {
                this.m_CanSwim = value;
            }
        }

        public virtual bool CanTarget
        {
            get
            {
                return true;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool CantWalk
        {
            get
            {
                return this.m_CantWalk;
            }
            set
            {
                this.m_CantWalk = value;
            }
        }

        public bool ChangingCombatant
        {
            get
            {
                return (this.m_ChangingCombatant > 0);
            }
        }

        public IArmor ChestArmor
        {
            get
            {
                IArmor armor1 = (this.FindItemOnLayer(Layer.InnerTorso) as IArmor);
                if (armor1 == null)
                {
                    armor1 = (this.FindItemOnLayer(Layer.Shirt) as IArmor);
                }
                return armor1;
            }
        }

        public virtual bool ClickTitle
        {
            get
            {
                return true;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public virtual int ColdResistance
        {
            get
            {
                return this.GetResistance(ResistanceType.Cold);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual Mobile Combatant
        {
            get
            {
                return this.m_Combatant;
            }
            set
            {
                if ((this.m_Combatant == value) || (value == this))
                {
                    return;
                }
                Mobile mobile1 = this.m_Combatant;
                ++this.m_ChangingCombatant;
                this.m_Combatant = value;
                if (((this.m_Combatant != null) && !this.CanBeHarmful(this.m_Combatant, false)) || !this.Region.OnCombatantChange(this, mobile1, this.m_Combatant))
                {
                    this.m_Combatant = mobile1;
                    --this.m_ChangingCombatant;
                    return;
                }
                if (this.m_NetState != null)
                {
                    this.m_NetState.Send(new ChangeCombatant(this.m_Combatant));
                }
                if (this.m_Combatant == null)
                {
                    this.m_ExpireCombatant.Stop();
                    this.m_CombatTimer.Stop();
                }
                else
                {
                    this.m_ExpireCombatant.Start();
                    this.m_CombatTimer.Start();
                }
                if ((this.m_Combatant != null) && this.CanBeHarmful(this.m_Combatant, false))
                {
                    this.DoHarmful(this.m_Combatant);
                    if (this.m_Combatant != null)
                    {
                        this.m_Combatant.PlaySound(this.m_Combatant.GetAngerSound());
                    }
                }
                this.OnCombatantChange();
                --this.m_ChangingCombatant;
            }
        }

        public ContextMenu ContextMenu
        {
            get
            {
                return this.m_ContextMenu;
            }
            set
            {
                this.m_ContextMenu = value;
                if (this.m_ContextMenu != null)
                {
                    this.Send(new DisplayContextMenu(this.m_ContextMenu));
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Container Corpse
        {
            get
            {
                return this.m_Corpse;
            }
            set
            {
                this.m_Corpse = value;
            }
        }

        public static CreateCorpseHandler CreateCorpseHandler
        {
            get
            {
                return Mobile.m_CreateCorpse;
            }
            set
            {
                Mobile.m_CreateCorpse = value;
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return this.m_CreationTime;
            }
            set
            {
                this.m_CreationTime = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public bool Criminal
        {
            get
            {
                return this.m_Criminal;
            }
            set
            {
                if (this.m_Criminal != value)
                {
                    this.m_Criminal = value;
                    this.Delta(MobileDelta.Noto);
                    this.InvalidateProperties();
                }
                this.m_ExpireCriminal.Stop();
                if (this.m_Criminal)
                {
                    this.m_ExpireCriminal.Start();
                }
            }
        }

        public ArrayList DamageEntries
        {
            get
            {
                return this.m_DamageEntries;
            }
        }

        public static TimeSpan DefaultHitsRate
        {
            get
            {
                return Mobile.m_DefaultHitsRate;
            }
            set
            {
                Mobile.m_DefaultHitsRate = value;
            }
        }

        public static TimeSpan DefaultManaRate
        {
            get
            {
                return Mobile.m_DefaultManaRate;
            }
            set
            {
                Mobile.m_DefaultManaRate = value;
            }
        }

        public static TimeSpan DefaultStamRate
        {
            get
            {
                return Mobile.m_DefaultStamRate;
            }
            set
            {
                Mobile.m_DefaultStamRate = value;
            }
        }

        public static IWeapon DefaultWeapon
        {
            get
            {
                return Mobile.m_DefaultWeapon;
            }
            set
            {
                Mobile.m_DefaultWeapon = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return this.m_Deleted;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Dex
        {
            get
            {
                int num1 = (this.m_Dex + this.GetStatOffset(StatType.Dex));
                if (num1 < 1)
                {
                    return 1;
                }
                if (num1 > 65000)
                {
                    num1 = 65000;
                }
                return num1;
            }
            set
            {
                if (this.m_StatMods.Count == 0)
                {
                    this.RawDex = value;
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public StatLockType DexLock
        {
            get
            {
                return this.m_DexLock;
            }
            set
            {
                if (this.m_DexLock != value)
                {
                    this.m_DexLock = value;
                    if (this.m_NetState != null)
                    {
                        this.m_NetState.Send(new StatLockInfo(this));
                    }
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Direction Direction
        {
            get
            {
                return this.m_Direction;
            }
            set
            {
                if (this.m_Direction != value)
                {
                    this.m_Direction = value;
                    this.Delta(MobileDelta.Direction);
                }
            }
        }

        public static bool DisableDismountInWarmode
        {
            get
            {
                return Mobile.m_DisableDismountInWarmode;
            }
            set
            {
                Mobile.m_DisableDismountInWarmode = value;
            }
        }

        public static bool DisableHiddenSelfClick
        {
            get
            {
                return Mobile.m_DisableHiddenSelfClick;
            }
            set
            {
                Mobile.m_DisableHiddenSelfClick = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool DisarmReady
        {
            get
            {
                return this.m_DisarmReady;
            }
            set
            {
                this.m_DisarmReady = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool DisplayGuildTitle
        {
            get
            {
                return this.m_DisplayGuildTitle;
            }
            set
            {
                this.m_DisplayGuildTitle = value;
                this.InvalidateProperties();
            }
        }

        public static bool DragEffects
        {
            get
            {
                return Mobile.m_DragEffects;
            }
            set
            {
                Mobile.m_DragEffects = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int EmoteHue
        {
            get
            {
                return this.m_EmoteHue;
            }
            set
            {
                this.m_EmoteHue = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public virtual int EnergyResistance
        {
            get
            {
                return this.GetResistance(ResistanceType.Energy);
            }
        }

        public static TimeSpan ExpireCriminalDelay
        {
            get
            {
                return Mobile.m_ExpireCriminalDelay;
            }
            set
            {
                Mobile.m_ExpireCriminalDelay = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Fame
        {
            get
            {
                return this.m_Fame;
            }
            set
            {
                int num1 = this.m_Fame;
                if (num1 == value)
                {
                    return;
                }
                this.m_Fame = value;
                if ((this.ShowFameTitle && (this.m_Player || this.m_Body.IsHuman)) && ((num1 >= 10000) != (value >= 10000)))
                {
                    this.InvalidateProperties();
                }
                this.OnFameChange(num1);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Female
        {
            get
            {
                return this.m_Female;
            }
            set
            {
                if (this.m_Female != value)
                {
                    this.m_Female = value;
                    this.Delta(MobileDelta.Flags);
                    this.OnGenderChanged(!this.m_Female);
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public virtual int FireResistance
        {
            get
            {
                return this.GetResistance(ResistanceType.Fire);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Followers
        {
            get
            {
                return this.m_Followers;
            }
            set
            {
                if (this.m_Followers != value)
                {
                    this.m_Followers = value;
                    this.Delta(MobileDelta.Followers);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int FollowersMax
        {
            get
            {
                return this.m_FollowersMax;
            }
            set
            {
                if (this.m_FollowersMax != value)
                {
                    this.m_FollowersMax = value;
                    this.Delta(MobileDelta.Followers);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Frozen
        {
            get
            {
                return this.m_Frozen;
            }
            set
            {
                if (this.m_Frozen != value)
                {
                    this.m_Frozen = value;
                    if (this.m_FrozenTimer != null)
                    {
                        this.m_FrozenTimer.Stop();
                        this.m_FrozenTimer = null;
                    }
                }
            }
        }

        public static AccessLevel FwdAccessOverride
        {
            get
            {
                return Mobile.m_FwdAccessOverride;
            }
            set
            {
                Mobile.m_FwdAccessOverride = value;
            }
        }

        public static bool FwdEnabled
        {
            get
            {
                return Mobile.m_FwdEnabled;
            }
            set
            {
                Mobile.m_FwdEnabled = value;
            }
        }

        public static int FwdMaxSteps
        {
            get
            {
                return Mobile.m_FwdMaxSteps;
            }
            set
            {
                Mobile.m_FwdMaxSteps = value;
            }
        }

        public static bool FwdUOTDOverride
        {
            get
            {
                return Mobile.m_FwdUOTDOverride;
            }
            set
            {
                Mobile.m_FwdUOTDOverride = value;
            }
        }

        public static char[] GhostChars
        {
            get
            {
                return Mobile.m_GhostChars;
            }
            set
            {
                Mobile.m_GhostChars = value;
            }
        }

        public BaseGuild Guild
        {
            get
            {
                return this.m_Guild;
            }
            set
            {
                BaseGuild guild1 = this.m_Guild;
                if (guild1 == value)
                {
                    return;
                }
                if (value == null)
                {
                    this.GuildTitle = null;
                }
                this.m_Guild = value;
                this.Delta(MobileDelta.Noto);
                this.InvalidateProperties();
                this.OnGuildChange(guild1);
            }
        }

        public static bool GuildClickMessage
        {
            get
            {
                return Mobile.m_GuildClickMessage;
            }
            set
            {
                Mobile.m_GuildClickMessage = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile GuildFealty
        {
            get
            {
                return this.m_GuildFealty;
            }
            set
            {
                this.m_GuildFealty = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string GuildTitle
        {
            get
            {
                return this.m_GuildTitle;
            }
            set
            {
                string text1 = this.m_GuildTitle;
                if (text1 == value)
                {
                    return;
                }
                this.m_GuildTitle = value;
                if (((this.m_Guild != null) && !this.m_Guild.Disbanded) && (this.m_GuildTitle != null))
                {
                    this.SendLocalizedMessage(1018026, true, this.m_GuildTitle);
                }
                this.InvalidateProperties();
                this.OnGuildTitleChange(text1);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Item Hair
        {
            get
            {
                Item item1;
                if (((this.m_Hair != null) && !this.m_Hair.Deleted) && (this.m_Hair.Parent == this))
                {
                    return this.m_Hair;
                }
                this.m_Hair = (item1 = this.FindItemOnLayer(Layer.Hair));
                return item1;
            }
        }

        public IArmor HandArmor
        {
            get
            {
                return (this.FindItemOnLayer(Layer.Gloves) as IArmor);
            }
        }

        public IArmor HeadArmor
        {
            get
            {
                return (this.FindItemOnLayer(Layer.Helm) as IArmor);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Hidden
        {
            get
            {
                return this.m_Hidden;
            }
            set
            {
                if (this.m_Hidden == value)
                {
                    return;
                }
                this.m_AllowedStealthSteps = 0;
                this.m_Hidden = value;
                if (this.m_Map == null)
                {
                    return;
                }
                Packet packet1 = null;
                IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(this.m_Location);
                foreach (NetState state1 in enumerable1)
                {
                    if (!state1.Mobile.CanSee(this))
                    {
                        if (packet1 == null)
                        {
                            packet1 = this.RemovePacket;
                        }
                        state1.Send(packet1);
                        continue;
                    }
                    state1.Send(new MobileIncoming(state1.Mobile, this));
                    if (this.IsDeadBondedPet)
                    {
                        state1.Send(new BondedStatus(0, this.m_Serial, 1));
                    }
                    if (ObjectPropertyList.Enabled)
                    {
                        state1.Send(this.OPLPacket);
                    }
                }
                enumerable1.Free();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Hits
        {
            get
            {
                return this.m_Hits;
            }
            set
            {
                int num1;
                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= this.HitsMax)
                {
                    value = this.HitsMax;
                    if (this.m_HitsTimer != null)
                    {
                        this.m_HitsTimer.Stop();
                    }
                    for (num1 = 0; (num1 < this.m_Aggressors.Count); ++num1)
                    {
                        ((AggressorInfo) this.m_Aggressors[num1]).CanReportMurder = false;
                    }
                    if (this.m_DamageEntries.Count > 0)
                    {
                        this.m_DamageEntries.Clear();
                    }
                }
                if (value < this.HitsMax)
                {
                    if (this.m_HitsTimer == null)
                    {
                        this.m_HitsTimer = new HitsTimer(this);
                    }
                    this.m_HitsTimer.Start();
                }
                if (this.m_Hits != value)
                {
                    this.m_Hits = value;
                    this.Delta(MobileDelta.Hits);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual int HitsMax
        {
            get
            {
                return (50 + (this.Str / 2));
            }
        }

        public static RegenRateHandler HitsRegenRateHandler
        {
            get
            {
                return Mobile.m_HitsRegenRate;
            }
            set
            {
                Mobile.m_HitsRegenRate = value;
            }
        }

        public Item Holding
        {
            get
            {
                return this.m_Holding;
            }
            set
            {
                if (this.m_Holding == value)
                {
                    return;
                }
                if (this.m_Holding != null)
                {
                    this.TotalWeight -= (this.m_Holding.TotalWeight + this.m_Holding.PileWeight);
                    if (this.m_Holding.HeldBy == this)
                    {
                        this.m_Holding.HeldBy = null;
                    }
                }
                if ((value != null) && (this.m_Holding != null))
                {
                    value.ClearBounce();
                    this.DropHolding();
                }
                this.m_Holding = value;
                if (this.m_Holding != null)
                {
                    this.TotalWeight += (this.m_Holding.TotalWeight + this.m_Holding.PileWeight);
                    if (this.m_Holding.HeldBy == null)
                    {
                        this.m_Holding.HeldBy = this;
                    }
                }
            }
        }

        [Hue, CommandProperty(AccessLevel.GameMaster)]
        public virtual int Hue
        {
            get
            {
                if (this.m_HueMod != -1)
                {
                    return this.m_HueMod;
                }
                return this.m_Hue;
            }
            set
            {
                int num1 = this.m_Hue;
                if (num1 != value)
                {
                    this.m_Hue = value;
                    this.Delta(MobileDelta.Hue);
                }
            }
        }

        public virtual int HuedItemID
        {
            get
            {
                if (!this.m_Female)
                {
                    return 8454;
                }
                return 8455;
            }
        }

        [Hue, CommandProperty(AccessLevel.GameMaster)]
        public int HueMod
        {
            get
            {
                return this.m_HueMod;
            }
            set
            {
                if (this.m_HueMod != value)
                {
                    this.m_HueMod = value;
                    this.Delta(MobileDelta.Hue);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Hunger
        {
            get
            {
                return this.m_Hunger;
            }
            set
            {
                int num1 = this.m_Hunger;
                if (num1 != value)
                {
                    this.m_Hunger = value;
                    EventSink.InvokeHungerChanged(new HungerChangedEventArgs(this, num1));
                }
            }
        }

        public static bool InsuranceEnabled
        {
            get
            {
                return Mobile.m_InsuranceEnabled;
            }
            set
            {
                Mobile.m_InsuranceEnabled = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Int
        {
            get
            {
                int num1 = (this.m_Int + this.GetStatOffset(StatType.Int));
                if (num1 < 1)
                {
                    return 1;
                }
                if (num1 > 65000)
                {
                    num1 = 65000;
                }
                return num1;
            }
            set
            {
                if (this.m_StatMods.Count == 0)
                {
                    this.RawInt = value;
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public StatLockType IntLock
        {
            get
            {
                return this.m_IntLock;
            }
            set
            {
                if (this.m_IntLock != value)
                {
                    this.m_IntLock = value;
                    if (this.m_NetState != null)
                    {
                        this.m_NetState.Send(new StatLockInfo(this));
                    }
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsBodyMod
        {
            get
            {
                return (this.m_BodyMod.BodyID != 0);
            }
        }

        public virtual bool IsDeadBondedPet
        {
            get
            {
                return false;
            }
        }

        public ArrayList Items
        {
            get
            {
                return this.m_Items;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Karma
        {
            get
            {
                return this.m_Karma;
            }
            set
            {
                int num1 = this.m_Karma;
                if (num1 != value)
                {
                    this.m_Karma = value;
                    this.OnKarmaChange(num1);
                }
            }
        }

        public virtual bool KeepsItemsOnDeath
        {
            get
            {
                return (this.m_AccessLevel > AccessLevel.Player);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Kills
        {
            get
            {
                return this.m_Kills;
            }
            set
            {
                int num1 = this.m_Kills;
                if (this.m_Kills == value)
                {
                    return;
                }
                this.m_Kills = value;
                if (this.m_Kills < 0)
                {
                    this.m_Kills = 0;
                }
                if ((num1 >= 5) != (this.m_Kills >= 5))
                {
                    this.Delta(MobileDelta.Noto);
                    this.InvalidateProperties();
                }
                this.OnKillsChange(num1);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string Language
        {
            get
            {
                return this.m_Language;
            }
            set
            {
                this.m_Language = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile LastKiller
        {
            get
            {
                return this.m_LastKiller;
            }
            set
            {
                this.m_LastKiller = value;
            }
        }

        public DateTime LastMoveTime
        {
            get
            {
                return this.m_LastMoveTime;
            }
            set
            {
                this.m_LastMoveTime = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime LastStatGain
        {
            get
            {
                return this.m_LastStatGain;
            }
            set
            {
                this.m_LastStatGain = value;
            }
        }

        public IArmor LegsArmor
        {
            get
            {
                IArmor armor1 = (this.FindItemOnLayer(Layer.InnerLegs) as IArmor);
                if (armor1 == null)
                {
                    armor1 = (this.FindItemOnLayer(Layer.Pants) as IArmor);
                }
                return armor1;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int LightLevel
        {
            get
            {
                return this.m_LightLevel;
            }
            set
            {
                if (this.m_LightLevel != value)
                {
                    this.m_LightLevel = value;
                    this.CheckLightLevels(false);
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public Point3D Location
        {
            get
            {
                return this.m_Location;
            }
            set
            {
                this.SetLocation(value, true);
            }
        }

        public Point3D LogoutLocation
        {
            get
            {
                return this.m_LogoutLocation;
            }
            set
            {
                this.m_LogoutLocation = value;
            }
        }

        public Map LogoutMap
        {
            get
            {
                return this.m_LogoutMap;
            }
            set
            {
                this.m_LogoutMap = value;
            }
        }

        public virtual int Luck
        {
            get
            {
                return 0;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MagicDamageAbsorb
        {
            get
            {
                return this.m_MagicDamageAbsorb;
            }
            set
            {
                this.m_MagicDamageAbsorb = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Mana
        {
            get
            {
                return this.m_Mana;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= this.ManaMax)
                {
                    value = this.ManaMax;
                    if (this.m_ManaTimer != null)
                    {
                        this.m_ManaTimer.Stop();
                    }
                    if (this.Meditating)
                    {
                        this.Meditating = false;
                        this.SendLocalizedMessage(501846);
                    }
                }
                if (value < this.ManaMax)
                {
                    if (this.m_ManaTimer == null)
                    {
                        this.m_ManaTimer = new ManaTimer(this);
                    }
                    this.m_ManaTimer.Start();
                }
                if (this.m_Mana != value)
                {
                    this.m_Mana = value;
                    this.Delta(MobileDelta.Mana);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual int ManaMax
        {
            get
            {
                return this.Int;
            }
        }

        public static RegenRateHandler ManaRegenRateHandler
        {
            get
            {
                return Mobile.m_ManaRegenRate;
            }
            set
            {
                Mobile.m_ManaRegenRate = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public Map Map
        {
            get
            {
                return this.m_Map;
            }
            set
            {
                int num1;
                Region region1;
                NetState state1;
                if (this.m_Map == value)
                {
                    return;
                }
                if (this.m_NetState != null)
                {
                    this.m_NetState.ValidateAllTrades();
                }
                Map map1 = this.m_Map;
                if (this.m_Map != null)
                {
                    this.m_Map.OnLeave(this);
                    this.ClearScreen();
                    this.SendRemovePacket();
                }
                for (num1 = 0; (num1 < this.m_Items.Count); ++num1)
                {
                    ((Item) this.m_Items[num1]).Map = value;
                }
                this.m_Map = value;
                if (this.m_Map != null)
                {
                    this.m_Map.OnEnter(this);
                }
                this.m_Region.InternalExit(this);
                if (this.m_Map != null)
                {
                    region1 = this.m_Region;
                    this.m_Region = Region.Find(this.m_Location, this.m_Map);
                    this.OnRegionChange(region1, this.m_Region);
                    this.m_Region.InternalEnter(this);
                    state1 = this.m_NetState;
                    if ((state1 != null) && (this.m_Map != null))
                    {
                        state1.Sequence = 0;
                        state1.Send(new MapChange(this));
                        state1.Send(new MapPatches());
                        state1.Send(SeasonChange.Instantiate(this.GetSeason(), true));
                        state1.Send(new MobileUpdate(this));
                        this.ClearFastwalkStack();
                    }
                }
                if (this.m_NetState != null)
                {
                    if (this.m_Map != null)
                    {
                        this.Send(new ServerChange(this, this.m_Map));
                    }
                    if (this.m_NetState != null)
                    {
                        this.m_NetState.Sequence = 0;
                        this.ClearFastwalkStack();
                    }
                    this.Send(new MobileIncoming(this, this));
                    this.Send(new MobileUpdate(this));
                    this.CheckLightLevels(true);
                    this.Send(new MobileUpdate(this));
                }
                this.SendEverything();
                this.SendIncomingPacket();
                if (this.m_NetState != null)
                {
                    if (this.m_NetState != null)
                    {
                        this.m_NetState.Sequence = 0;
                        this.ClearFastwalkStack();
                    }
                    this.Send(new MobileIncoming(this, this));
                    this.Send(SupportedFeatures.Instantiate());
                    this.Send(new MobileUpdate(this));
                    this.Send(new MobileAttributes(this));
                }
                this.OnMapChange(map1);
            }
        }

        public static int MaxPlayerResistance
        {
            get
            {
                return Mobile.m_MaxPlayerResistance;
            }
            set
            {
                Mobile.m_MaxPlayerResistance = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Meditating
        {
            get
            {
                return this.m_Meditating;
            }
            set
            {
                this.m_Meditating = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MeleeDamageAbsorb
        {
            get
            {
                return this.m_MeleeDamageAbsorb;
            }
            set
            {
                this.m_MeleeDamageAbsorb = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public IMount Mount
        {
            get
            {
                IMountItem item1 = null;
                if (((this.m_MountItem != null) && !this.m_MountItem.Deleted) && (this.m_MountItem.Parent == this))
                {
                    item1 = ((IMountItem) this.m_MountItem);
                }
                if (item1 == null)
                {
                    this.m_MountItem = ((item1 = (this.FindItemOnLayer(Layer.Mount) as IMountItem)) as Item);
                }
                if (item1 != null)
                {
                    return item1.Mount;
                }
                return null;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Mounted
        {
            get
            {
                return (this.Mount != null);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string Name
        {
            get
            {
                if (this.m_NameMod != null)
                {
                    return this.m_NameMod;
                }
                return this.m_Name;
            }
            set
            {
                if (this.m_Name != value)
                {
                    this.m_Name = value;
                    this.Delta(MobileDelta.Name);
                    this.InvalidateProperties();
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int NameHue
        {
            get
            {
                return this.m_NameHue;
            }
            set
            {
                this.m_NameHue = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string NameMod
        {
            get
            {
                return this.m_NameMod;
            }
            set
            {
                if (this.m_NameMod != value)
                {
                    this.m_NameMod = value;
                    this.Delta(MobileDelta.Name);
                    this.InvalidateProperties();
                }
            }
        }

        public IArmor NeckArmor
        {
            get
            {
                return (this.FindItemOnLayer(Layer.Neck) as IArmor);
            }
        }

        public NetState NetState
        {
            get
            {
                if ((this.m_NetState != null) && (this.m_NetState.Socket == null))
                {
                    this.NetState = null;
                }
                return this.m_NetState;
            }
            set
            {
                int num1;
                Item item1;
                int num2;
                if (this.m_NetState == value)
                {
                    return;
                }
                if (this.m_Map != null)
                {
                    this.m_Map.OnClientChange(this.m_NetState, value, this);
                }
                if (this.m_Target != null)
                {
                    this.m_Target.Cancel(this, TargetCancelType.Disconnected);
                }
                if (this.m_QuestArrow != null)
                {
                    this.QuestArrow = null;
                }
                if (this.m_Spell != null)
                {
                    this.m_Spell.OnConnectionChanged();
                }
                if (this.m_NetState != null)
                {
                    this.m_NetState.CancelAllTrades();
                }
                BankBox box1 = this.FindBankNoCreate();
                if ((box1 != null) && box1.Opened)
                {
                    box1.Close();
                }
                this.m_NetState = value;
                if (this.m_NetState == null)
                {
                    this.OnDisconnected();
                    EventSink.InvokeDisconnected(new DisconnectedEventArgs(this));
                    this.m_LogoutTimer.Stop();
                    this.m_LogoutTimer.Delay = this.GetLogoutDelay();
                    this.m_LogoutTimer.Start();
                }
                else
                {
                    this.OnConnected();
                    EventSink.InvokeConnected(new ConnectedEventArgs(this));
                    this.m_LogoutTimer.Stop();
                    if ((this.m_Map == Map.Internal) && (this.m_LogoutMap != null))
                    {
                        this.Map = this.m_LogoutMap;
                        this.Location = this.m_LogoutLocation;
                    }
                }
                for (num1 = (this.m_Items.Count - 1); (num1 >= 0); --num1)
                {
                    if (num1 < this.m_Items.Count)
                    {
                        item1 = ((Item) this.m_Items[num1]);
                        if ((item1 is SecureTradeContainer))
                        {
                            for (num2 = (item1.Items.Count - 1); (num2 >= 0); --num2)
                            {
                                if (num2 < item1.Items.Count)
                                {
                                    ((Item) item1.Items[num2]).OnSecureTrade(this, this, this, false);
                                    this.AddToBackpack(((Item) item1.Items[num2]));
                                }
                            }
                            item1.Delete();
                        }
                    }
                }
                this.DropHolding();
                this.OnNetStateChanged();
            }
        }

        public DateTime NextActionMessage
        {
            get
            {
                return this.m_NextActionMessage;
            }
            set
            {
                this.m_NextActionMessage = value;
            }
        }

        public DateTime NextActionTime
        {
            get
            {
                return this.m_NextActionTime;
            }
            set
            {
                this.m_NextActionTime = value;
            }
        }

        public DateTime NextCombatTime
        {
            get
            {
                return this.m_NextCombatTime;
            }
            set
            {
                this.m_NextCombatTime = value;
            }
        }

        public DateTime NextSkillTime
        {
            get
            {
                return this.m_NextSkillTime;
            }
            set
            {
                this.m_NextSkillTime = value;
            }
        }

        public DateTime NextSpellTime
        {
            get
            {
                return this.m_NextSpellTime;
            }
            set
            {
                this.m_NextSpellTime = value;
            }
        }

        public static bool NoSpeechLOS
        {
            get
            {
                return Mobile.m_NoSpeechLOS;
            }
            set
            {
                Mobile.m_NoSpeechLOS = value;
            }
        }

        public Packet OPLPacket
        {
            get
            {
                if (this.m_OPLPacket == null)
                {
                    this.m_OPLPacket = new OPLInfo(this.PropertyList);
                }
                return this.m_OPLPacket;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Paralyzed
        {
            get
            {
                return this.m_Paralyzed;
            }
            set
            {
                if (this.m_Paralyzed == value)
                {
                    return;
                }
                this.m_Paralyzed = value;
                this.SendLocalizedMessage((this.m_Paralyzed ? 502381 : 502382));
                if (this.m_ParaTimer != null)
                {
                    this.m_ParaTimer.Stop();
                    this.m_ParaTimer = null;
                }
            }
        }

        public object Party
        {
            get
            {
                return this.m_Party;
            }
            set
            {
                this.m_Party = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public virtual int PhysicalResistance
        {
            get
            {
                return this.GetResistance(ResistanceType.Physical);
            }
        }

        [CommandProperty(AccessLevel.GameMaster, AccessLevel.Administrator)]
        public bool Player
        {
            get
            {
                return this.m_Player;
            }
            set
            {
                this.m_Player = value;
                this.InvalidateProperties();
                if (!this.m_Player && (this.m_CombatTimer != null))
                {
                    this.m_CombatTimer.Priority = TimerPriority.FiftyMS;
                    return;
                }
                if (this.m_CombatTimer != null)
                {
                    this.m_CombatTimer.Priority = TimerPriority.EveryTick;
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Poison Poison
        {
            get
            {
                return this.m_Poison;
            }
            set
            {
                this.m_Poison = value;
                this.Delta(MobileDelta.Flags);
                if (this.m_PoisonTimer != null)
                {
                    this.m_PoisonTimer.Stop();
                    this.m_PoisonTimer = null;
                }
                if (this.m_Poison != null)
                {
                    this.m_PoisonTimer = this.m_Poison.ConstructTimer(this);
                    if (this.m_PoisonTimer != null)
                    {
                        this.m_PoisonTimer.Start();
                    }
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Poisoned
        {
            get
            {
                return (this.m_Poison != null);
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public virtual int PoisonResistance
        {
            get
            {
                return this.GetResistance(ResistanceType.Poison);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public string Profile
        {
            get
            {
                return this.m_Profile;
            }
            set
            {
                this.m_Profile = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public bool ProfileLocked
        {
            get
            {
                return this.m_ProfileLocked;
            }
            set
            {
                this.m_ProfileLocked = value;
            }
        }

        public Prompt Prompt
        {
            get
            {
                return this.m_Prompt;
            }
            set
            {
                Prompt prompt1 = this.m_Prompt;
                Prompt prompt2 = value;
                if (prompt1 == prompt2)
                {
                    return;
                }
                this.m_Prompt = null;
                if ((prompt1 != null) && (prompt2 != null))
                {
                    prompt1.OnCancel(this);
                }
                this.m_Prompt = prompt2;
                if (prompt2 != null)
                {
                    this.Send(new UnicodePrompt(prompt2));
                }
            }
        }

        public ObjectPropertyList PropertyList
        {
            get
            {
                if (this.m_PropertyList == null)
                {
                    this.m_PropertyList = new ObjectPropertyList(this);
                    this.GetProperties(this.m_PropertyList);
                    this.m_PropertyList.Terminate();
                }
                return this.m_PropertyList;
            }
        }

        public bool Pushing
        {
            get
            {
                return this.m_Pushing;
            }
            set
            {
                this.m_Pushing = value;
            }
        }

        public QuestArrow QuestArrow
        {
            get
            {
                return this.m_QuestArrow;
            }
            set
            {
                if (this.m_QuestArrow == value)
                {
                    return;
                }
                if (this.m_QuestArrow != null)
                {
                    this.m_QuestArrow.Stop();
                }
                this.m_QuestArrow = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RawDex
        {
            get
            {
                return this.m_Dex;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                else if (value > 65000)
                {
                    value = 65000;
                }
                if (this.m_Dex == value)
                {
                    return;
                }
                int num1 = this.m_Dex;
                this.m_Dex = value;
                this.Delta((MobileDelta.Stat | MobileDelta.Stam));
                if (this.Stam < this.StamMax)
                {
                    if (this.m_StamTimer == null)
                    {
                        this.m_StamTimer = new StamTimer(this);
                    }
                    this.m_StamTimer.Start();
                }
                else if (this.Stam > this.StamMax)
                {
                    this.Stam = this.StamMax;
                }
                this.OnRawDexChange(num1);
                this.OnRawStatChange(StatType.Dex, num1);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RawInt
        {
            get
            {
                return this.m_Int;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                else if (value > 65000)
                {
                    value = 65000;
                }
                if (this.m_Int == value)
                {
                    return;
                }
                int num1 = this.m_Int;
                this.m_Int = value;
                this.Delta((MobileDelta.Stat | MobileDelta.Mana));
                if (this.Mana < this.ManaMax)
                {
                    if (this.m_ManaTimer == null)
                    {
                        this.m_ManaTimer = new ManaTimer(this);
                    }
                    this.m_ManaTimer.Start();
                }
                else if (this.Mana > this.ManaMax)
                {
                    this.Mana = this.ManaMax;
                }
                this.OnRawIntChange(num1);
                this.OnRawStatChange(StatType.Int, num1);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string RawName
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.Name = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RawStatTotal
        {
            get
            {
                return ((this.RawStr + this.RawDex) + this.RawInt);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RawStr
        {
            get
            {
                return this.m_Str;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                else if (value > 65000)
                {
                    value = 65000;
                }
                if (this.m_Str == value)
                {
                    return;
                }
                int num1 = this.m_Str;
                this.m_Str = value;
                this.Delta((MobileDelta.Stat | MobileDelta.Hits));
                if (this.Hits < this.HitsMax)
                {
                    if (this.m_HitsTimer == null)
                    {
                        this.m_HitsTimer = new HitsTimer(this);
                    }
                    this.m_HitsTimer.Start();
                }
                else if (this.Hits > this.HitsMax)
                {
                    this.Hits = this.HitsMax;
                }
                this.OnRawStrChange(num1);
                this.OnRawStatChange(StatType.Str, num1);
            }
        }

        public Region Region
        {
            get
            {
                return this.m_Region;
            }
        }

        public Packet RemovePacket
        {
            get
            {
                if (this.m_RemovePacket == null)
                {
                    this.m_RemovePacket = new RemoveMobile(this);
                }
                return this.m_RemovePacket;
            }
        }

        public ArrayList ResistanceMods
        {
            get
            {
                return this.m_ResistMods;
            }
            set
            {
                this.m_ResistMods = value;
            }
        }

        public int[] Resistances
        {
            get
            {
                return this.m_Resistances;
            }
        }

        public virtual bool RetainPackLocsOnDeath
        {
            get
            {
                return Core.AOS;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Serial Serial
        {
            get
            {
                return this.m_Serial;
            }
        }

        Point3D Server.IEntity.Location
        {
            get
            {
                return this.m_Location;
            }
        }

        public IArmor ShieldArmor
        {
            get
            {
                return (this.FindItemOnLayer(Layer.TwoHanded) as IArmor);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int ShortTermMurders
        {
            get
            {
                return this.m_ShortTermMurders;
            }
            set
            {
                if (this.m_ShortTermMurders != value)
                {
                    this.m_ShortTermMurders = value;
                    if (this.m_ShortTermMurders < 0)
                    {
                        this.m_ShortTermMurders = 0;
                    }
                }
            }
        }

        public virtual bool ShouldCheckStatTimers
        {
            get
            {
                return true;
            }
        }

        public virtual bool ShowFameTitle
        {
            get
            {
                return true;
            }
        }

        public static SkillCheckDirectLocationHandler SkillCheckDirectLocationHandler
        {
            get
            {
                return Mobile.m_SkillCheckDirectLocationHandler;
            }
            set
            {
                Mobile.m_SkillCheckDirectLocationHandler = value;
            }
        }

        public static SkillCheckDirectTargetHandler SkillCheckDirectTargetHandler
        {
            get
            {
                return Mobile.m_SkillCheckDirectTargetHandler;
            }
            set
            {
                Mobile.m_SkillCheckDirectTargetHandler = value;
            }
        }

        public static SkillCheckLocationHandler SkillCheckLocationHandler
        {
            get
            {
                return Mobile.m_SkillCheckLocationHandler;
            }
            set
            {
                Mobile.m_SkillCheckLocationHandler = value;
            }
        }

        public static SkillCheckTargetHandler SkillCheckTargetHandler
        {
            get
            {
                return Mobile.m_SkillCheckTargetHandler;
            }
            set
            {
                Mobile.m_SkillCheckTargetHandler = value;
            }
        }

        public ArrayList SkillMods
        {
            get
            {
                return this.m_SkillMods;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Skills Skills
        {
            get
            {
                return this.m_Skills;
            }
            set
            {
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillsCap
        {
            get
            {
                if (this.m_Skills != null)
                {
                    return this.m_Skills.Cap;
                }
                return 0;
            }
            set
            {
                if (this.m_Skills != null)
                {
                    this.m_Skills.Cap = value;
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SkillsTotal
        {
            get
            {
                if (this.m_Skills != null)
                {
                    return this.m_Skills.Total;
                }
                return 0;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SolidHueOverride
        {
            get
            {
                return this.m_SolidHueOverride;
            }
            set
            {
                if (this.m_SolidHueOverride == value)
                {
                    return;
                }
                this.m_SolidHueOverride = value;
                this.Delta((MobileDelta.Body | MobileDelta.Hue));
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int SpeechHue
        {
            get
            {
                return this.m_SpeechHue;
            }
            set
            {
                this.m_SpeechHue = value;
            }
        }

        public ISpell Spell
        {
            get
            {
                return this.m_Spell;
            }
            set
            {
                if ((this.m_Spell != null) && (value != null))
                {
                    Console.WriteLine("Warning: Spell has been overwritten");
                }
                this.m_Spell = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Squelched
        {
            get
            {
                return this.m_Squelched;
            }
            set
            {
                this.m_Squelched = value;
            }
        }

        public ArrayList Stabled
        {
            get
            {
                return this.m_Stabled;
            }
            set
            {
                this.m_Stabled = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Stam
        {
            get
            {
                return this.m_Stam;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= this.StamMax)
                {
                    value = this.StamMax;
                    if (this.m_StamTimer != null)
                    {
                        this.m_StamTimer.Stop();
                    }
                }
                if (value < this.StamMax)
                {
                    if (this.m_StamTimer == null)
                    {
                        this.m_StamTimer = new StamTimer(this);
                    }
                    this.m_StamTimer.Start();
                }
                if (this.m_Stam != value)
                {
                    this.m_Stam = value;
                    this.Delta(MobileDelta.Stam);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual int StamMax
        {
            get
            {
                return this.Dex;
            }
        }

        public static RegenRateHandler StamRegenRateHandler
        {
            get
            {
                return Mobile.m_StamRegenRate;
            }
            set
            {
                Mobile.m_StamRegenRate = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int StatCap
        {
            get
            {
                return this.m_StatCap;
            }
            set
            {
                if (this.m_StatCap != value)
                {
                    this.m_StatCap = value;
                    this.Delta(MobileDelta.StatCap);
                }
            }
        }

        public ArrayList StatMods
        {
            get
            {
                return this.m_StatMods;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Str
        {
            get
            {
                int num1 = (this.m_Str + this.GetStatOffset(StatType.Str));
                if (num1 < 1)
                {
                    return 1;
                }
                if (num1 > 65000)
                {
                    num1 = 65000;
                }
                return num1;
            }
            set
            {
                if (this.m_StatMods.Count == 0)
                {
                    this.RawStr = value;
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public StatLockType StrLock
        {
            get
            {
                return this.m_StrLock;
            }
            set
            {
                if (this.m_StrLock != value)
                {
                    this.m_StrLock = value;
                    if (this.m_NetState != null)
                    {
                        this.m_NetState.Send(new StatLockInfo(this));
                    }
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool StunReady
        {
            get
            {
                return this.m_StunReady;
            }
            set
            {
                this.m_StunReady = value;
            }
        }

        public Target Target
        {
            get
            {
                return this.m_Target;
            }
            set
            {
                Target target1 = this.m_Target;
                Target target2 = value;
                if (target1 == target2)
                {
                    return;
                }
                this.m_Target = null;
                if ((target1 != null) && (target2 != null))
                {
                    target1.Cancel(this, TargetCancelType.Overriden);
                }
                this.m_Target = target2;
                if (((target2 != null) && (this.m_NetState != null)) && !this.m_TargetLocked)
                {
                    this.m_NetState.Send(target2.GetPacket());
                }
                this.OnTargetChange();
            }
        }

        public bool TargetLocked
        {
            get
            {
                return this.m_TargetLocked;
            }
            set
            {
                this.m_TargetLocked = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Thirst
        {
            get
            {
                return this.m_Thirst;
            }
            set
            {
                this.m_Thirst = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TithingPoints
        {
            get
            {
                return this.m_TithingPoints;
            }
            set
            {
                if (this.m_TithingPoints != value)
                {
                    this.m_TithingPoints = value;
                    this.Delta(MobileDelta.TithingPoints);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
                this.InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalGold
        {
            get
            {
                return this.m_TotalGold;
            }
            set
            {
                if (this.m_TotalGold != value)
                {
                    this.m_TotalGold = value;
                    this.Delta(MobileDelta.Gold);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalWeight
        {
            get
            {
                return this.m_TotalWeight;
            }
            set
            {
                int num1 = this.m_TotalWeight;
                if (num1 != value)
                {
                    this.m_TotalWeight = value;
                    this.Delta(MobileDelta.Weight);
                    this.OnWeightChange(num1);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int VirtualArmor
        {
            get
            {
                return this.m_VirtualArmor;
            }
            set
            {
                if (this.m_VirtualArmor != value)
                {
                    this.m_VirtualArmor = value;
                    this.Delta(MobileDelta.Armor);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int VirtualArmorMod
        {
            get
            {
                return this.m_VirtualArmorMod;
            }
            set
            {
                if (this.m_VirtualArmorMod != value)
                {
                    this.m_VirtualArmorMod = value;
                    this.Delta(MobileDelta.Armor);
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public VirtueInfo Virtues
        {
            get
            {
                return this.m_Virtues;
            }
            set
            {
            }
        }

        public static VisibleDamageType VisibleDamageType
        {
            get
            {
                return Mobile.m_VisibleDamageType;
            }
            set
            {
                Mobile.m_VisibleDamageType = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Warmode
        {
            get
            {
                return this.m_Warmode;
            }
            set
            {
                if (this.m_Warmode == value)
                {
                    return;
                }
                if (this.m_AutoManifestTimer != null)
                {
                    this.m_AutoManifestTimer.Stop();
                    this.m_AutoManifestTimer = null;
                }
                this.m_Warmode = value;
                this.Delta(MobileDelta.Flags);
                if (this.m_NetState != null)
                {
                    this.Send(SetWarMode.Instantiate(value));
                }
                if (!this.m_Warmode)
                {
                    this.Combatant = null;
                }
                if (this.Alive)
                {
                    return;
                }
                if (value)
                {
                    this.Delta(MobileDelta.GhostUpdate);
                    return;
                }
                this.SendRemovePacket(false);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual IWeapon Weapon
        {
            get
            {
                IWeapon weapon1;
                Item item1 = (this.m_Weapon as Item);
                if (((item1 != null) && !item1.Deleted) && ((item1.Parent == this) && this.CanSee(item1)))
                {
                    return this.m_Weapon;
                }
                this.m_Weapon = null;
                item1 = this.FindItemOnLayer(Layer.FirstValid);
                if (item1 == null)
                {
                    item1 = this.FindItemOnLayer(Layer.TwoHanded);
                }
                if ((item1 is IWeapon))
                {
                    this.m_Weapon = (weapon1 = ((IWeapon) item1));
                    return weapon1;
                }
                return this.GetDefaultWeapon();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int WhisperHue
        {
            get
            {
                return this.m_WhisperHue;
            }
            set
            {
                this.m_WhisperHue = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int X
        {
            get
            {
                return this.m_Location.m_X;
            }
            set
            {
                this.Location = new Point3D(value, this.m_Location.m_Y, this.m_Location.m_Z);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Y
        {
            get
            {
                return this.m_Location.m_Y;
            }
            set
            {
                this.Location = new Point3D(this.m_Location.m_X, value, this.m_Location.m_Z);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int YellHue
        {
            get
            {
                return this.m_YellHue;
            }
            set
            {
                this.m_YellHue = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool YellowHealthbar
        {
            get
            {
                return this.m_YellowHealthbar;
            }
            set
            {
                this.m_YellowHealthbar = value;
                this.Delta(MobileDelta.Flags);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int Z
        {
            get
            {
                return this.m_Location.m_Z;
            }
            set
            {
                this.Location = new Point3D(this.m_Location.m_X, this.m_Location.m_Y, value);
            }
        }


        // Fields
        private AccessLevel m_AccessLevel;
        private static string[] m_AccessLevelNames;
        private IAccount m_Account;
        private static TimeSpan m_ActionMessageDelay;
        private ArrayList m_Actions;
        private ArrayList m_Aggressed;
        private ArrayList m_Aggressors;
        private static AllowBeneficialHandler m_AllowBeneficialHandler;
        private int m_AllowedStealthSteps;
        private static AllowHarmfulHandler m_AllowHarmfulHandler;
        private static bool m_AsciiClickMessage;
        private static TimeSpan m_AutoManifestTimeout;
        private Timer m_AutoManifestTimer;
        private bool m_AutoPageNotify;
        private int m_BAC;
        private Container m_Backpack;
        private BankBox m_BankBox;
        private int m_BaseSoundID;
        private Item m_Beard;
        private bool m_Blessed;
        private Body m_Body;
        private Body m_BodyMod;
        private static int m_BodyWeight;
        private bool m_CanHearGhosts;
        private bool m_CanSwim;
        private bool m_CantWalk;
        private int m_ChangingCombatant;
        private Mobile m_Combatant;
        private Timer m_CombatTimer;
        private ContextMenu m_ContextMenu;
        private Container m_Corpse;
        private static CreateCorpseHandler m_CreateCorpse;
        private DateTime m_CreationTime;
        private bool m_Criminal;
        private ArrayList m_DamageEntries;
        private static TimeSpan m_DefaultHitsRate;
        private static TimeSpan m_DefaultManaRate;
        private static TimeSpan m_DefaultStamRate;
        private static IWeapon m_DefaultWeapon;
        private bool m_Deleted;
        private MobileDelta m_DeltaFlags;
        private static Queue m_DeltaQueue;
        private int m_Dex;
        private StatLockType m_DexLock;
        private Direction m_Direction;
        private static bool m_DisableDismountInWarmode;
        private static bool m_DisableHiddenSelfClick;
        private bool m_DisarmReady;
        private bool m_DisplayGuildTitle;
        private static bool m_DragEffects;
        private int m_EmoteHue;
        private DateTime m_EndQueue;
        private Timer m_ExpireAggrTimer;
        private Timer m_ExpireCombatant;
        private Timer m_ExpireCriminal;
        private static TimeSpan m_ExpireCriminalDelay;
        private int m_Fame;
        private bool m_Female;
        private int m_Followers;
        private int m_FollowersMax;
        private bool m_Frozen;
        private FrozenTimer m_FrozenTimer;
        private static AccessLevel m_FwdAccessOverride;
        private static bool m_FwdEnabled;
        private static int m_FwdMaxSteps;
        private static bool m_FwdUOTDOverride;
        private static char[] m_GhostChars;
        private static object m_GhostMutateContext;
        private BaseGuild m_Guild;
        private static bool m_GuildClickMessage;
        private Mobile m_GuildFealty;
        private string m_GuildTitle;
        private static string[] m_GuildTypes;
        private Item m_Hair;
        private static ArrayList m_Hears;
        private bool m_Hidden;
        private int m_Hits;
        private static RegenRateHandler m_HitsRegenRate;
        private Timer m_HitsTimer;
        private Item m_Holding;
        private int m_Hue;
        private int m_HueMod;
        private int m_Hunger;
        private bool m_InDeltaQueue;
        private static bool m_InsuranceEnabled;
        private int m_Int;
        private StatLockType m_IntLock;
        private static int[] m_InvalidBodies;
        private ArrayList m_Items;
        private int m_Karma;
        private int m_Kills;
        private string m_Language;
        private Mobile m_LastKiller;
        private DateTime m_LastMoveTime;
        private DateTime m_LastStatGain;
        private int m_LightLevel;
        private Point3D m_Location;
        private Point3D m_LogoutLocation;
        private Map m_LogoutMap;
        private Timer m_LogoutTimer;
        private int m_MagicDamageAbsorb;
        private int m_Mana;
        private static RegenRateHandler m_ManaRegenRate;
        private Timer m_ManaTimer;
        private Map m_Map;
        private static int m_MaxPlayerResistance;
        private bool m_Meditating;
        private int m_MeleeDamageAbsorb;
        private Item m_MountItem;
        private static ArrayList m_MoveList;
        private Queue m_MoveRecords;
        private static MobileMoving[] m_MovingPacketCache;
        private string m_Name;
        private int m_NameHue;
        private string m_NameMod;
        private NetState m_NetState;
        private DateTime m_NextActionMessage;
        private DateTime m_NextActionTime;
        private DateTime m_NextCombatTime;
        private DateTime m_NextSkillTime;
        private DateTime m_NextSpellTime;
        private DateTime m_NextWarmodeChange;
        private static bool m_NoSpeechLOS;
        private static ArrayList m_OnSpeech;
        private Packet m_OPLPacket;
        private bool m_Paralyzed;
        private ParalyzedTimer m_ParaTimer;
        private object m_Party;
        private bool m_Player;
        private Poison m_Poison;
        private Timer m_PoisonTimer;
        private string m_Profile;
        private bool m_ProfileLocked;
        private Prompt m_Prompt;
        private ObjectPropertyList m_PropertyList;
        private bool m_Pushing;
        private QuestArrow m_QuestArrow;
        private Region m_Region;
        private Packet m_RemovePacket;
        private int[] m_Resistances;
        private ArrayList m_ResistMods;
        private static TimeSpan m_RunFoot;
        private static TimeSpan m_RunMount;
        private Serial m_Serial;
        private int m_ShortTermMurders;
        private static SkillCheckDirectLocationHandler m_SkillCheckDirectLocationHandler;
        private static SkillCheckDirectTargetHandler m_SkillCheckDirectTargetHandler;
        private static SkillCheckLocationHandler m_SkillCheckLocationHandler;
        private static SkillCheckTargetHandler m_SkillCheckTargetHandler;
        private ArrayList m_SkillMods;
        private Skills m_Skills;
        private int m_SolidHueOverride;
        private int m_SpeechHue;
        private ISpell m_Spell;
        private bool m_Squelched;
        private ArrayList m_Stabled;
        private int m_Stam;
        private static RegenRateHandler m_StamRegenRate;
        private Timer m_StamTimer;
        private int m_StatCap;
        private ArrayList m_StatMods;
        private int m_Str;
        private StatLockType m_StrLock;
        private DateTime[] m_StuckMenuUses;
        private bool m_StunReady;
        private Target m_Target;
        private bool m_TargetLocked;
        private int m_Thirst;
        private int m_TithingPoints;
        private string m_Title;
        private int m_TotalGold;
        private int m_TotalWeight;
        private int m_VirtualArmor;
        private int m_VirtualArmorMod;
        private VirtueInfo m_Virtues;
        private static VisibleDamageType m_VisibleDamageType;
        private static TimeSpan m_WalkFoot;
        private static TimeSpan m_WalkMount;
        private bool m_Warmode;
        private int m_WarmodeChanges;
        private WarmodeTimer m_WarmodeTimer;
        private IWeapon m_Weapon;
        private int m_WhisperHue;
        private int m_YellHue;
        private bool m_YellowHealthbar;
        private const int WarmodeCatchCount = 4;
        private static TimeSpan WarmodeSpamCatch;
        private static TimeSpan WarmodeSpamDelay;

        // Nested Types
        private class AutoManifestTimer : Timer
        {
            // Methods
            public AutoManifestTimer(Mobile m, TimeSpan delay) : base(delay)
            {
                this.m_Mobile = m;
            }

            protected override void OnTick()
            {
                if (!this.m_Mobile.Alive)
                {
                    this.m_Mobile.Warmode = false;
                }
            }


            // Fields
            private Mobile m_Mobile;
        }

        private class CombatTimer : Timer
        {
            // Methods
            public CombatTimer(Mobile m) : base(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(0.01), 0)
            {
                this.m_Mobile = m;
                if (!this.m_Mobile.m_Player && (this.m_Mobile.m_Dex <= 100))
                {
                    base.Priority = TimerPriority.FiftyMS;
                }
            }

            protected override void OnTick()
            {
                if (DateTime.Now <= this.m_Mobile.m_NextCombatTime)
                {
                    return;
                }
                Mobile mobile1 = this.m_Mobile.Combatant;
                if ((((mobile1 == null) || mobile1.m_Deleted) || (this.m_Mobile.m_Deleted || (mobile1.m_Map != this.m_Mobile.m_Map))) || ((!mobile1.Alive || !this.m_Mobile.Alive) || ((!this.m_Mobile.CanSee(mobile1) || mobile1.IsDeadBondedPet) || this.m_Mobile.IsDeadBondedPet)))
                {
                    this.m_Mobile.Combatant = null;
                    base.Stop();
                    return;
                }
                IWeapon weapon1 = this.m_Mobile.Weapon;
                if (this.m_Mobile.InRange(mobile1, weapon1.MaxRange) && this.m_Mobile.InLOS(mobile1))
                {
                    this.m_Mobile.RevealingAction();
                    this.m_Mobile.m_NextCombatTime = (DateTime.Now + weapon1.OnSwing(this.m_Mobile, mobile1));
                }
            }


            // Fields
            private Mobile m_Mobile;
        }

        private class ExpireAggressorsTimer : Timer
        {
            // Methods
            public ExpireAggressorsTimer(Mobile m) : base(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5))
            {
                this.m_Mobile = m;
                base.Priority = TimerPriority.FiveSeconds;
            }

            protected override void OnTick()
            {
                if (this.m_Mobile.Deleted || ((this.m_Mobile.Aggressors.Count == 0) && (this.m_Mobile.Aggressed.Count == 0)))
                {
                    this.m_Mobile.StopAggrExpire();
                    return;
                }
                this.m_Mobile.CheckAggrExpire();
            }


            // Fields
            private Mobile m_Mobile;
        }

        private class ExpireCombatantTimer : Timer
        {
            // Methods
            public ExpireCombatantTimer(Mobile m) : base(TimeSpan.FromMinutes(1))
            {
                base.Priority = TimerPriority.FiveSeconds;
                this.m_Mobile = m;
            }

            protected override void OnTick()
            {
                this.m_Mobile.Combatant = null;
            }


            // Fields
            private Mobile m_Mobile;
        }

        private class ExpireCriminalTimer : Timer
        {
            // Methods
            public ExpireCriminalTimer(Mobile m) : base(Mobile.m_ExpireCriminalDelay)
            {
                base.Priority = TimerPriority.FiveSeconds;
                this.m_Mobile = m;
            }

            protected override void OnTick()
            {
                this.m_Mobile.Criminal = false;
            }


            // Fields
            private Mobile m_Mobile;
        }

        private class FrozenTimer : Timer
        {
            // Methods
            public FrozenTimer(Mobile m, TimeSpan duration) : base(duration)
            {
                base.Priority = TimerPriority.TwentyFiveMS;
                this.m_Mobile = m;
            }

            protected override void OnTick()
            {
                this.m_Mobile.Frozen = false;
            }


            // Fields
            private Mobile m_Mobile;
        }

        private class HitsTimer : Timer
        {
            // Methods
            public HitsTimer(Mobile m) : base(Mobile.GetHitsRegenRate(m), Mobile.GetHitsRegenRate(m))
            {
                base.Priority = TimerPriority.FiftyMS;
                this.m_Owner = m;
            }

            protected override void OnTick()
            {
                TimeSpan span1;
                if (this.m_Owner.CanRegenHits)
                {
                    ++this.m_Owner.Hits;
                }
                base.Interval = (span1 = Mobile.GetHitsRegenRate(this.m_Owner));
                base.Delay = span1;
            }


            // Fields
            private Mobile m_Owner;
        }

        private class LocationComparer : IComparer
        {
            // Methods
            public LocationComparer(IPoint3D relativeTo)
            {
                this.m_RelativeTo = relativeTo;
            }

            public int Compare(object x, object y)
            {
                IPoint3D pointd1 = (x as IPoint3D);
                IPoint3D pointd2 = (y as IPoint3D);
                return (this.GetDistance(pointd1) - this.GetDistance(pointd2));
            }

            private int GetDistance(IPoint3D p)
            {
                int num1 = (this.m_RelativeTo.X - p.X);
                int num2 = (this.m_RelativeTo.Y - p.Y);
                int num3 = (this.m_RelativeTo.Z - p.Z);
                num1 *= 11;
                num2 *= 11;
                return (((num1 * num1) + (num2 * num2)) + (num3 * num3));
            }


            // Fields
            private IPoint3D m_RelativeTo;
        }

        private class LogoutTimer : Timer
        {
            // Methods
            public LogoutTimer(Mobile m) : base(TimeSpan.FromDays(1))
            {
                base.Priority = TimerPriority.OneSecond;
                this.m_Mobile = m;
            }

            protected override void OnTick()
            {
                if (this.m_Mobile.m_Map != Map.Internal)
                {
                    EventSink.InvokeLogout(new LogoutEventArgs(this.m_Mobile));
                    this.m_Mobile.m_LogoutLocation = this.m_Mobile.m_Location;
                    this.m_Mobile.m_LogoutMap = this.m_Mobile.m_Map;
                    this.m_Mobile.Internalize();
                }
            }


            // Fields
            private Mobile m_Mobile;
        }

        private class ManaTimer : Timer
        {
            // Methods
            public ManaTimer(Mobile m) : base(Mobile.GetManaRegenRate(m), Mobile.GetManaRegenRate(m))
            {
                base.Priority = TimerPriority.FiftyMS;
                this.m_Owner = m;
            }

            protected override void OnTick()
            {
                TimeSpan span1;
                if (this.m_Owner.CanRegenMana)
                {
                    ++this.m_Owner.Mana;
                }
                base.Interval = (span1 = Mobile.GetManaRegenRate(this.m_Owner));
                base.Delay = span1;
            }


            // Fields
            private Mobile m_Owner;
        }

        private class MovementRecord
        {
            // Methods
            static MovementRecord()
            {
                Mobile.MovementRecord.m_InstancePool = new Queue();
            }

            private MovementRecord(DateTime end)
            {
                this.m_End = end;
            }

            public bool Expired()
            {
                bool flag1 = (DateTime.Now >= this.m_End);
                if (flag1)
                {
                    Mobile.MovementRecord.m_InstancePool.Enqueue(this);
                }
                return flag1;
            }

            public static Mobile.MovementRecord NewInstance(DateTime end)
            {
                Mobile.MovementRecord record1;
                if (Mobile.MovementRecord.m_InstancePool.Count > 0)
                {
                    record1 = ((Mobile.MovementRecord) Mobile.MovementRecord.m_InstancePool.Dequeue());
                    record1.m_End = end;
                    return record1;
                }
                return new Mobile.MovementRecord(end);
            }


            // Fields
            public DateTime m_End;
            private static Queue m_InstancePool;
        }

        private class ParalyzedTimer : Timer
        {
            // Methods
            public ParalyzedTimer(Mobile m, TimeSpan duration) : base(duration)
            {
                base.Priority = TimerPriority.TwentyFiveMS;
                this.m_Mobile = m;
            }

            protected override void OnTick()
            {
                this.m_Mobile.Paralyzed = false;
            }


            // Fields
            private Mobile m_Mobile;
        }

        private class SimpleStateTarget : Target
        {
            // Methods
            public SimpleStateTarget(int range, TargetFlags flags, bool allowGround, TargetStateCallback callback, object state) : base(range, allowGround, flags)
            {
                this.m_Callback = callback;
                this.m_State = state;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (this.m_Callback != null)
                {
                    this.m_Callback.Invoke(from, targeted, this.m_State);
                }
            }


            // Fields
            private TargetStateCallback m_Callback;
            private object m_State;
        }

        private class SimpleTarget : Target
        {
            // Methods
            public SimpleTarget(int range, TargetFlags flags, bool allowGround, TargetCallback callback) : base(range, allowGround, flags)
            {
                this.m_Callback = callback;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (this.m_Callback != null)
                {
                    this.m_Callback(from, targeted);
                }
            }


            // Fields
            private TargetCallback m_Callback;
        }

        private class StamTimer : Timer
        {
            // Methods
            public StamTimer(Mobile m) : base(Mobile.GetStamRegenRate(m), Mobile.GetStamRegenRate(m))
            {
                base.Priority = TimerPriority.FiftyMS;
                this.m_Owner = m;
            }

            protected override void OnTick()
            {
                TimeSpan span1;
                if (this.m_Owner.CanRegenStam)
                {
                    ++this.m_Owner.Stam;
                }
                base.Interval = (span1 = Mobile.GetStamRegenRate(this.m_Owner));
                base.Delay = span1;
            }


            // Fields
            private Mobile m_Owner;
        }

        private class WarmodeTimer : Timer
        {
            // Methods
            public WarmodeTimer(Mobile m, bool value) : base(Mobile.WarmodeSpamDelay)
            {
                this.m_Mobile = m;
                this.m_Value = value;
            }

            protected override void OnTick()
            {
                this.m_Mobile.Warmode = this.m_Value;
                this.m_Mobile.m_WarmodeChanges = 0;
                this.m_Mobile.m_WarmodeTimer = null;
            }


            // Properties
            public bool Value
            {
                get
                {
                    return this.m_Value;
                }
                set
                {
                    this.m_Value = value;
                }
            }


            // Fields
            private Mobile m_Mobile;
            private bool m_Value;
        }
    }
}

