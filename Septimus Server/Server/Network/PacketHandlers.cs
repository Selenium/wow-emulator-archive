namespace Server.Network
{
    using Server;
    using Server.Accounting;
    using Server.ContextMenus;
    using Server.Gumps;
    using Server.HuePickers;
    using Server.Items;
    using Server.Menus;
    using Server.Mobiles;
    using Server.Prompts;
    using Server.Targeting;
    using System;
    using System.Collections;
    using System.IO;

    public class PacketHandlers
    {
        // Methods
        static PacketHandlers()
        {
            PacketHandlers.m_EmptyInts = new int[0];
            PacketHandlers.m_KeywordList = new KeywordList();
            PacketHandlers.m_ValidAnimations = new int[32] { 6, 21, 32, 33, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 123, 124, 125, 126, 127, 128 };
            PacketHandlers.m_AuthIDWindow = new int[128];
            PacketHandlers.m_AuthIDWindowAge = new DateTime[128];
            PacketHandlers.m_ClientVerification = true;
            PacketHandlers.m_Handlers = new PacketHandler[256];
            PacketHandlers.m_ExtendedHandlersLow = new PacketHandler[256];
            PacketHandlers.m_ExtendedHandlersHigh = new Hashtable();
            PacketHandlers.m_EncodedHandlersLow = new EncodedPacketHandler[256];
            PacketHandlers.m_EncodedHandlersHigh = new Hashtable();
            PacketHandlers.Register(0, 104, false, new OnPacketReceive(PacketHandlers.CreateCharacter));
            PacketHandlers.Register(1, 5, false, new OnPacketReceive(PacketHandlers.Disconnect));
            PacketHandlers.Register(2, 7, true, new OnPacketReceive(PacketHandlers.MovementReq));
            PacketHandlers.Register(3, 0, true, new OnPacketReceive(PacketHandlers.AsciiSpeech));
            PacketHandlers.Register(4, 2, true, new OnPacketReceive(PacketHandlers.GodModeRequest));
            PacketHandlers.Register(5, 5, true, new OnPacketReceive(PacketHandlers.AttackReq));
            PacketHandlers.Register(6, 5, true, new OnPacketReceive(PacketHandlers.UseReq));
            PacketHandlers.Register(7, 7, true, new OnPacketReceive(PacketHandlers.LiftReq));
            PacketHandlers.Register(8, 14, true, new OnPacketReceive(PacketHandlers.DropReq));
            PacketHandlers.Register(9, 5, true, new OnPacketReceive(PacketHandlers.LookReq));
            PacketHandlers.Register(10, 11, true, new OnPacketReceive(PacketHandlers.Edit));
            PacketHandlers.Register(18, 0, true, new OnPacketReceive(PacketHandlers.TextCommand));
            PacketHandlers.Register(19, 10, true, new OnPacketReceive(PacketHandlers.EquipReq));
            PacketHandlers.Register(20, 6, true, new OnPacketReceive(PacketHandlers.ChangeZ));
            PacketHandlers.Register(34, 3, true, new OnPacketReceive(PacketHandlers.Resynchronize));
            PacketHandlers.Register(44, 2, true, new OnPacketReceive(PacketHandlers.DeathStatusResponse));
            PacketHandlers.Register(52, 10, true, new OnPacketReceive(PacketHandlers.MobileQuery));
            PacketHandlers.Register(58, 0, true, new OnPacketReceive(PacketHandlers.ChangeSkillLock));
            PacketHandlers.Register(59, 0, true, new OnPacketReceive(PacketHandlers.VendorBuyReply));
            PacketHandlers.Register(71, 11, true, new OnPacketReceive(PacketHandlers.NewTerrain));
            PacketHandlers.Register(72, 73, true, new OnPacketReceive(PacketHandlers.NewAnimData));
            PacketHandlers.Register(88, 106, true, new OnPacketReceive(PacketHandlers.NewRegion));
            PacketHandlers.Register(93, 73, false, new OnPacketReceive(PacketHandlers.PlayCharacter));
            PacketHandlers.Register(97, 9, true, new OnPacketReceive(PacketHandlers.DeleteStatic));
            PacketHandlers.Register(108, 19, true, new OnPacketReceive(PacketHandlers.TargetResponse));
            PacketHandlers.Register(111, 0, true, new OnPacketReceive(PacketHandlers.SecureTrade));
            PacketHandlers.Register(114, 5, true, new OnPacketReceive(PacketHandlers.SetWarMode));
            PacketHandlers.Register(115, 2, false, new OnPacketReceive(PacketHandlers.PingReq));
            PacketHandlers.Register(117, 35, true, new OnPacketReceive(PacketHandlers.RenameRequest));
            PacketHandlers.Register(121, 9, true, new OnPacketReceive(PacketHandlers.ResourceQuery));
            PacketHandlers.Register(126, 2, true, new OnPacketReceive(PacketHandlers.GodviewQuery));
            PacketHandlers.Register(125, 13, true, new OnPacketReceive(PacketHandlers.MenuResponse));
            PacketHandlers.Register(128, 62, false, new OnPacketReceive(PacketHandlers.AccountLogin));
            PacketHandlers.Register(131, 39, false, new OnPacketReceive(PacketHandlers.DeleteCharacter));
            PacketHandlers.Register(145, 65, false, new OnPacketReceive(PacketHandlers.GameLogin));
            PacketHandlers.Register(149, 9, true, new OnPacketReceive(PacketHandlers.HuePickerResponse));
            PacketHandlers.Register(150, 0, true, new OnPacketReceive(PacketHandlers.GameCentralMoniter));
            PacketHandlers.Register(152, 0, true, new OnPacketReceive(PacketHandlers.MobileNameRequest));
            PacketHandlers.Register(154, 0, true, new OnPacketReceive(PacketHandlers.AsciiPromptResponse));
            PacketHandlers.Register(155, 258, true, new OnPacketReceive(PacketHandlers.HelpRequest));
            PacketHandlers.Register(157, 51, true, new OnPacketReceive(PacketHandlers.GMSingle));
            PacketHandlers.Register(159, 0, true, new OnPacketReceive(PacketHandlers.VendorSellReply));
            PacketHandlers.Register(160, 3, false, new OnPacketReceive(PacketHandlers.PlayServer));
            PacketHandlers.Register(164, 149, false, new OnPacketReceive(PacketHandlers.SystemInfo));
            PacketHandlers.Register(167, 4, true, new OnPacketReceive(PacketHandlers.RequestScrollWindow));
            PacketHandlers.Register(173, 0, true, new OnPacketReceive(PacketHandlers.UnicodeSpeech));
            PacketHandlers.Register(177, 0, true, new OnPacketReceive(PacketHandlers.DisplayGumpResponse));
            PacketHandlers.Register(181, 64, true, new OnPacketReceive(PacketHandlers.ChatRequest));
            PacketHandlers.Register(182, 9, true, new OnPacketReceive(PacketHandlers.ObjectHelpRequest));
            PacketHandlers.Register(184, 0, true, new OnPacketReceive(PacketHandlers.ProfileReq));
            PacketHandlers.Register(187, 9, false, new OnPacketReceive(PacketHandlers.AccountID));
            PacketHandlers.Register(189, 0, true, new OnPacketReceive(PacketHandlers.ClientVersion));
            PacketHandlers.Register(190, 0, true, new OnPacketReceive(PacketHandlers.AssistVersion));
            PacketHandlers.Register(191, 0, true, new OnPacketReceive(PacketHandlers.ExtendedCommand));
            PacketHandlers.Register(194, 0, true, new OnPacketReceive(PacketHandlers.UnicodePromptResponse));
            PacketHandlers.Register(200, 2, true, new OnPacketReceive(PacketHandlers.SetUpdateRange));
            PacketHandlers.Register(201, 6, true, new OnPacketReceive(PacketHandlers.TripTime));
            PacketHandlers.Register(202, 6, true, new OnPacketReceive(PacketHandlers.UTripTime));
            PacketHandlers.Register(207, 0, false, new OnPacketReceive(PacketHandlers.AccountLogin));
            PacketHandlers.Register(208, 0, true, new OnPacketReceive(PacketHandlers.ConfigurationFile));
            PacketHandlers.Register(209, 2, true, new OnPacketReceive(PacketHandlers.LogoutReq));
            PacketHandlers.Register(215, 0, true, new OnPacketReceive(PacketHandlers.EncodedCommand));
            PacketHandlers.RegisterExtended(5, false, new OnPacketReceive(PacketHandlers.ScreenSize));
            PacketHandlers.RegisterExtended(6, true, new OnPacketReceive(PacketHandlers.PartyMessage));
            PacketHandlers.RegisterExtended(7, true, new OnPacketReceive(PacketHandlers.QuestArrow));
            PacketHandlers.RegisterExtended(9, true, new OnPacketReceive(PacketHandlers.DisarmRequest));
            PacketHandlers.RegisterExtended(10, true, new OnPacketReceive(PacketHandlers.StunRequest));
            PacketHandlers.RegisterExtended(11, false, new OnPacketReceive(PacketHandlers.Language));
            PacketHandlers.RegisterExtended(12, true, new OnPacketReceive(PacketHandlers.CloseStatus));
            PacketHandlers.RegisterExtended(14, true, new OnPacketReceive(PacketHandlers.Animate));
            PacketHandlers.RegisterExtended(15, false, new OnPacketReceive(PacketHandlers.Empty));
            PacketHandlers.RegisterExtended(16, true, new OnPacketReceive(PacketHandlers.QueryProperties));
            PacketHandlers.RegisterExtended(19, true, new OnPacketReceive(PacketHandlers.ContextMenuRequest));
            PacketHandlers.RegisterExtended(21, true, new OnPacketReceive(PacketHandlers.ContextMenuResponse));
            PacketHandlers.RegisterExtended(26, true, new OnPacketReceive(PacketHandlers.StatLockChange));
            PacketHandlers.RegisterExtended(28, true, new OnPacketReceive(PacketHandlers.CastSpell));
            PacketHandlers.RegisterEncoded(25, true, new OnEncodedPacketReceive(PacketHandlers.SetAbility));
        }

        public PacketHandlers()
        {
        }

        public static void AccountID(NetState state, PacketReader pvSrc)
        {
        }

        public static void AccountLogin(NetState state, PacketReader pvSrc)
        {
            if (state.SentFirstPacket)
            {
                state.Dispose();
                return;
            }
            state.SentFirstPacket = true;
            string text1 = pvSrc.ReadString(30);
            string text2 = pvSrc.ReadString(30);
            AccountLoginEventArgs args1 = new AccountLoginEventArgs(state, text1, text2);
            EventSink.InvokeAccountLogin(args1);
            if (args1.Accepted)
            {
                PacketHandlers.AccountLogin_ReplyAck(state);
                return;
            }
            PacketHandlers.AccountLogin_ReplyRej(state, args1.RejectReason);
        }

        public static void AccountLogin_ReplyAck(NetState state)
        {
            ServerListEventArgs args1 = new ServerListEventArgs(state, state.Account);
            EventSink.InvokeServerList(args1);
            if (args1.Rejected)
            {
                state.Account = null;
                state.Send(new AccountLoginRej(((ALRReason) 255)));
                state.Dispose();
                return;
            }
            ServerInfo[] infoArray1 = ((ServerInfo[]) args1.Servers.ToArray(typeof(ServerInfo)));
            state.ServerInfo = infoArray1;
            state.Send(new AccountLoginAck(infoArray1));
        }

        public static void AccountLogin_ReplyRej(NetState state, ALRReason reason)
        {
            state.Send(new AccountLoginRej(reason));
            state.Dispose();
        }

        public static void Animate(NetState state, PacketReader pvSrc)
        {
            int num2;
            Body body1;
            Mobile mobile1 = state.Mobile;
            int num1 = pvSrc.ReadInt32();
            bool flag1 = false;
            for (num2 = 0; (!flag1 && (num2 < PacketHandlers.m_ValidAnimations.Length)); ++num2)
            {
                flag1 = (num1 == PacketHandlers.m_ValidAnimations[num2]);
            }
            if (((mobile1 != null) && flag1) && mobile1.Alive)
            {
                body1 = mobile1.Body;
                if (body1.IsHuman && !mobile1.Mounted)
                {
                    mobile1.Animate(num1, 7, 1, true, false, 0);
                }
            }
        }

        public static void AsciiPromptResponse(NetState state, PacketReader pvSrc)
        {
            int num1 = pvSrc.ReadInt32();
            int num2 = pvSrc.ReadInt32();
            int num3 = pvSrc.ReadInt32();
            string text1 = pvSrc.ReadStringSafe();
            if (text1.Length > 128)
            {
                return;
            }
            Mobile mobile1 = state.Mobile;
            Prompt prompt1 = mobile1.Prompt;
            if (((prompt1 == null) || (prompt1.Serial != num1)) || (prompt1.Serial != num2))
            {
                return;
            }
            mobile1.Prompt = null;
            if (num3 == 0)
            {
                prompt1.OnCancel(mobile1);
                return;
            }
            prompt1.OnResponse(mobile1, text1);
        }

        public static void AsciiSpeech(NetState state, PacketReader pvSrc)
        {
            Mobile mobile1 = state.Mobile;
            MessageType type1 = ((MessageType) pvSrc.ReadByte());
            int num1 = pvSrc.ReadInt16();
            pvSrc.ReadInt16();
            string text1 = pvSrc.ReadStringSafe().Trim();
            if ((text1.Length <= 0) || (text1.Length > 128))
            {
                return;
            }
            if (!Enum.IsDefined(typeof(MessageType), type1))
            {
                type1 = MessageType.Regular;
            }
            mobile1.DoSpeech(text1, PacketHandlers.m_EmptyInts, type1, Utility.ClipDyedHue(num1));
        }

        public static void AssistVersion(NetState state, PacketReader pvSrc)
        {
            pvSrc.ReadInt32();
            pvSrc.ReadString();
        }

        public static void AttackReq(NetState state, PacketReader pvSrc)
        {
            Mobile mobile1 = state.Mobile;
            Mobile mobile2 = World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32()));
            if (mobile2 != null)
            {
                mobile1.Attack(mobile2);
            }
        }

        public static void CastSpell(NetState state, PacketReader pvSrc)
        {
            Mobile mobile1 = state.Mobile;
            if (mobile1 == null)
            {
                return;
            }
            Item item1 = null;
            if (pvSrc.ReadInt16() == 1)
            {
                item1 = World.FindItem(Serial.op_Implicit(pvSrc.ReadInt32()));
            }
            int num1 = (pvSrc.ReadInt16() - 1);
            EventSink.InvokeCastSpellRequest(new CastSpellRequestEventArgs(mobile1, num1, item1));
        }

        public static void ChangeSkillLock(NetState state, PacketReader pvSrc)
        {
            Skill skill1 = state.Mobile.Skills[pvSrc.ReadInt16()];
            if (skill1 != null)
            {
                skill1.SetLockNoRelay(((SkillLock) pvSrc.ReadByte()));
            }
        }

        public static void ChangeZ(NetState state, PacketReader pvSrc)
        {
            int num1;
            int num2;
            int num3;
            object[] objArray1;
            if (PacketHandlers.VerifyGC(state))
            {
                num1 = pvSrc.ReadInt16();
                num2 = pvSrc.ReadInt16();
                num3 = pvSrc.ReadSByte();
                objArray1 = new object[4];
                objArray1[0] = state;
                objArray1[1] = num1;
                objArray1[2] = num2;
                objArray1[3] = num3;
                Console.WriteLine("God Client: {0}: Change Z ({1}, {2}, {3})", objArray1);
            }
        }

        public static void ChatRequest(NetState state, PacketReader pvSrc)
        {
            EventSink.InvokeChatRequest(new ChatRequestEventArgs(state.Mobile));
        }

        public static void ClientVersion(NetState state, PacketReader pvSrc)
        {
            ClientVersion version2;
            object[] objArray1;
            TimeSpan span1;
            state.Version = (version2 = new ClientVersion(pvSrc.ReadString()));
            ClientVersion version1 = version2;
            string text1 = null;
            if ((ClientVersion.Required != null) && (version1 < ClientVersion.Required))
            {
                text1 = string.Format("This server requires your client version be at least {0}.", ClientVersion.Required);
            }
            else if ((!ClientVersion.AllowGod || !ClientVersion.AllowRegular) || !ClientVersion.AllowUOTD)
            {
                if (!ClientVersion.AllowGod && (version1.Type == ClientType.God))
                {
                    text1 = "This server does not allow god clients to connect.";
                }
                else if (!ClientVersion.AllowRegular && (version1.Type == ClientType.Regular))
                {
                    text1 = "This server does not allow regular clients to connect.";
                }
                else if (!ClientVersion.AllowUOTD && (version1.Type == ClientType.UOTD))
                {
                    text1 = "This server does not allow UO:TD clients to connect.";
                }
                if ((!ClientVersion.AllowGod && !ClientVersion.AllowRegular) && !ClientVersion.AllowUOTD)
                {
                    text1 = "This server does not allow any clients to connect.";
                }
                else if ((ClientVersion.AllowGod && !ClientVersion.AllowRegular) && (!ClientVersion.AllowUOTD && (version1.Type != ClientType.God)))
                {
                    text1 = "This server requires you to use the god client.";
                }
                else if (text1 != null)
                {
                    if (ClientVersion.AllowRegular && ClientVersion.AllowUOTD)
                    {
                        text1 = text1 + " You can use regular or UO:TD clients.";
                    }
                    else if (ClientVersion.AllowRegular)
                    {
                        text1 = text1 + " You can use regular clients.";
                    }
                    else if (ClientVersion.AllowUOTD)
                    {
                        text1 = text1 + " You can use UO:TD clients.";
                    }
                }
            }
            if (text1 != null)
            {
                state.Mobile.SendMessage(34, text1);
                objArray1 = new object[1];
                span1 = ClientVersion.KickDelay;
                objArray1[0] = span1.TotalSeconds;
                state.Mobile.SendMessage(34, "You will be disconnected in {0} seconds.", objArray1);
                new KickTimer(state, ClientVersion.KickDelay).Start();
            }
        }

        public static void CloseStatus(NetState state, PacketReader pvSrc)
        {
            Serial.op_Implicit(pvSrc.ReadInt32());
        }

        public static void ConfigurationFile(NetState state, PacketReader pvSrc)
        {
        }

        public static void ContextMenuRequest(NetState state, PacketReader pvSrc)
        {
            object obj1;
            int num1;
            Mobile mobile1 = state.Mobile;
            IEntity entity1 = World.FindEntity(Serial.op_Implicit(pvSrc.ReadInt32()));
            if (((mobile1 == null) || (entity1 == null)) || ((mobile1.Map != entity1.Map) || !mobile1.CanSee(entity1)))
            {
                return;
            }
            if ((entity1 is Mobile) && !Utility.InUpdateRange(mobile1.Location, entity1.Location))
            {
                return;
            }
            if ((entity1 is Item) && !Utility.InUpdateRange(mobile1.Location, ((Item) entity1).GetWorldLocation()))
            {
                return;
            }
            if (!mobile1.CheckContextMenuDisplay(entity1))
            {
                return;
            }
            ContextMenu menu1 = new ContextMenu(mobile1, entity1);
            if (menu1.Entries.Length <= 0)
            {
                return;
            }
            if ((entity1 is Item))
            {
                obj1 = ((Item) entity1).RootParent;
                if (((obj1 is Mobile) && (obj1 != mobile1)) && (((Mobile) obj1).AccessLevel >= mobile1.AccessLevel))
                {
                    for (num1 = 0; (num1 < menu1.Entries.Length); ++num1)
                    {
                        menu1.Entries[num1].Enabled = false;
                    }
                }
            }
            mobile1.ContextMenu = menu1;
        }

        public static void ContextMenuResponse(NetState state, PacketReader pvSrc)
        {
            Point3D pointd1;
            Mobile mobile1 = state.Mobile;
            if (mobile1 == null)
            {
                return;
            }
            ContextMenu menu1 = mobile1.ContextMenu;
            mobile1.ContextMenu = null;
            if (((menu1 == null) || (mobile1 == null)) || (mobile1 != menu1.From))
            {
                return;
            }
            IEntity entity1 = World.FindEntity(Serial.op_Implicit(pvSrc.ReadInt32()));
            if (((entity1 == null) || (entity1 != menu1.Target)) || !mobile1.CanSee(entity1))
            {
                return;
            }
            if ((entity1 is Mobile))
            {
                pointd1 = entity1.Location;
            }
            else if ((entity1 is Item))
            {
                pointd1 = ((Item) entity1).GetWorldLocation();
            }
            else
            {
                return;
            }
            int num1 = pvSrc.ReadUInt16();
            if ((num1 < 0) || (num1 >= menu1.Entries.Length))
            {
                return;
            }
            ContextMenuEntry entry1 = menu1.Entries[num1];
            int num2 = entry1.Range;
            if (num2 == -1)
            {
                num2 = 18;
            }
            if (entry1.Enabled && mobile1.InRange(pointd1, num2))
            {
                entry1.OnClick();
            }
        }

        public static void CreateCharacter(NetState state, PacketReader pvSrc)
        {
            int num20;
            Mobile mobile1;
            pvSrc.ReadInt32();
            pvSrc.ReadInt32();
            pvSrc.ReadByte();
            string text1 = pvSrc.ReadString(30);
            pvSrc.Seek(2, SeekOrigin.Current);
            int num1 = pvSrc.ReadInt32();
            pvSrc.Seek(8, SeekOrigin.Current);
            int num2 = pvSrc.ReadByte();
            pvSrc.Seek(15, SeekOrigin.Current);
            bool flag1 = pvSrc.ReadBoolean();
            int num3 = pvSrc.ReadByte();
            int num4 = pvSrc.ReadByte();
            int num5 = pvSrc.ReadByte();
            int num6 = pvSrc.ReadByte();
            int num7 = pvSrc.ReadByte();
            int num8 = pvSrc.ReadByte();
            int num9 = pvSrc.ReadByte();
            int num10 = pvSrc.ReadByte();
            int num11 = pvSrc.ReadByte();
            int num12 = pvSrc.ReadUInt16();
            int num13 = pvSrc.ReadInt16();
            int num14 = pvSrc.ReadInt16();
            int num15 = pvSrc.ReadInt16();
            int num16 = pvSrc.ReadInt16();
            pvSrc.ReadByte();
            int num17 = pvSrc.ReadByte();
            pvSrc.ReadInt32();
            pvSrc.ReadInt32();
            int num18 = pvSrc.ReadInt16();
            int num19 = pvSrc.ReadInt16();
            CityInfo[] infoArray1 = state.CityInfo;
            IAccount account1 = state.Account;
            if (((infoArray1 == null) || (account1 == null)) || ((num17 < 0) || (num17 >= infoArray1.Length)))
            {
                state.Dispose();
                return;
            }
            for (num20 = 0; (num20 < 5); ++num20)
            {
                mobile1 = account1[num20];
                if ((mobile1 != null) && (mobile1.Map != Map.Internal))
                {
                    Console.WriteLine("Login: {0}: Account in use", state);
                    state.Send(new PopupMessage(PMMessage.CharInWorld));
                    return;
                }
            }
            state.Flags = num1;
            SkillNameValue[] valueArray1 = new SkillNameValue[3];
            valueArray1[0] = new SkillNameValue(num6, num7);
            valueArray1[1] = new SkillNameValue(num8, num9);
            valueArray1[2] = new SkillNameValue(num10, num11);
            CharacterCreatedEventArgs args1 = new CharacterCreatedEventArgs(state, account1, text1, flag1, num12, num3, num4, num5, infoArray1[num17], valueArray1, num18, num19, num13, num14, num15, num16, num2);
            state.BlockAllPackets = true;
            EventSink.InvokeCharacterCreated(args1);
            Mobile mobile2 = args1.Mobile;
            if (mobile2 != null)
            {
                state.Mobile = mobile2;
                mobile2.NetState = state;
                state.BlockAllPackets = false;
                PacketHandlers.DoLogin(state, mobile2);
                return;
            }
            state.BlockAllPackets = false;
            state.Dispose();
        }

        public static void DeathStatusResponse(NetState state, PacketReader pvSrc)
        {
        }

        public static void DeleteCharacter(NetState state, PacketReader pvSrc)
        {
            pvSrc.Seek(30, SeekOrigin.Current);
            int num1 = pvSrc.ReadInt32();
            EventSink.InvokeDeleteRequest(new DeleteRequestEventArgs(state, num1));
        }

        public static void DeleteStatic(NetState state, PacketReader pvSrc)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            object[] objArray1;
            if (PacketHandlers.VerifyGC(state))
            {
                num1 = pvSrc.ReadInt16();
                num2 = pvSrc.ReadInt16();
                num3 = pvSrc.ReadInt16();
                num4 = pvSrc.ReadUInt16();
                objArray1 = new object[5];
                objArray1[0] = state;
                objArray1[1] = num1;
                objArray1[2] = num2;
                objArray1[3] = num3;
                objArray1[4] = num4;
                Console.WriteLine("God Client: {0}: Delete Static ({1}, {2}, {3}) 0x{4:X}", objArray1);
            }
        }

        public static void DisarmRequest(NetState state, PacketReader pvSrc)
        {
            EventSink.InvokeDisarmRequest(new DisarmRequestEventArgs(state.Mobile));
        }

        public static void Disconnect(NetState state, PacketReader pvSrc)
        {
            pvSrc.ReadInt32();
        }

        public static void DisplayGumpResponse(NetState state, PacketReader pvSrc)
        {
            int num5;
            int num7;
            int num8;
            int num9;
            string text1;
            int num10;
            Mobile mobile1;
            int num1 = pvSrc.ReadInt32();
            int num2 = pvSrc.ReadInt32();
            int num3 = pvSrc.ReadInt32();
            int num4 = pvSrc.ReadInt32();
            if ((num4 < 0) || (num4 > 2000))
            {
                return;
            }
            int[] numArray1 = new int[num4];
            for (num5 = 0; (num5 < numArray1.Length); ++num5)
            {
                numArray1[num5] = pvSrc.ReadInt32();
            }
            int num6 = pvSrc.ReadInt32();
            if ((num6 < 0) || (num6 > 2000))
            {
                return;
            }
            TextRelay[] relayArray1 = new TextRelay[num6];
            for (num7 = 0; (num7 < relayArray1.Length); ++num7)
            {
                num8 = pvSrc.ReadUInt16();
                num9 = pvSrc.ReadUInt16();
                if (num9 > 239)
                {
                    return;
                }
                text1 = pvSrc.ReadUnicodeStringSafe(num9);
                relayArray1[num7] = new TextRelay(num8, text1);
            }
            Gump[] gumpArray1 = state.Gumps;
            for (num10 = 0; (num10 < gumpArray1.Length); ++num10)
            {
                if ((gumpArray1[num10].Serial == num1) && (gumpArray1[num10].TypeID == num2))
                {
                    gumpArray1[num10].OnResponse(state, new RelayInfo(num3, numArray1, relayArray1));
                    state.RemoveGump(num10);
                    return;
                }
            }
            if (num2 != 461)
            {
                return;
            }
            if ((num3 == 1) && (numArray1.Length > 0))
            {
                mobile1 = World.FindMobile(Serial.op_Implicit(numArray1[0]));
                if (mobile1 == null)
                {
                    return;
                }
                EventSink.InvokeVirtueGumpRequest(new VirtueGumpRequestEventArgs(state.Mobile, mobile1));
                return;
            }
            Mobile mobile2 = World.FindMobile(Serial.op_Implicit(num1));
            if (mobile2 != null)
            {
                EventSink.InvokeVirtueItemRequest(new VirtueItemRequestEventArgs(state.Mobile, mobile2, num3));
            }
        }

        public static void DoLogin(NetState state, Mobile m)
        {
            state.Send(new LoginConfirm(m));
            if (m.Map != null)
            {
                state.Send(new MapChange(m));
            }
            state.Send(new MapPatches());
            state.Send(SeasonChange.Instantiate(m.GetSeason(), true));
            state.Send(SupportedFeatures.Instantiate());
            state.Sequence = 0;
            state.Send(new MobileUpdate(m));
            state.Send(new MobileUpdate(m));
            m.CheckLightLevels(true);
            state.Send(new MobileUpdate(m));
            state.Send(new MobileIncoming(m, m));
            state.Send(new MobileAttributes(m));
            state.Send(SetWarMode.Instantiate(m.Warmode));
            m.SendEverything();
            state.Send(SupportedFeatures.Instantiate());
            state.Send(new MobileUpdate(m));
            state.Send(new MobileAttributes(m));
            state.Send(SetWarMode.Instantiate(m.Warmode));
            state.Send(new MobileIncoming(m, m));
            state.Send(LoginComplete.Instance);
            state.Send(new CurrentTime());
            state.Send(SeasonChange.Instantiate(m.GetSeason(), true));
            state.Send(new MapChange(m));
            EventSink.InvokeLogin(new LoginEventArgs(m));
            m.ClearFastwalkStack();
        }

        public static void DropReq(NetState state, PacketReader pvSrc)
        {
            Point3D pointd1;
            pvSrc.ReadInt32();
            int num1 = pvSrc.ReadInt16();
            int num2 = pvSrc.ReadInt16();
            int num3 = pvSrc.ReadSByte();
            Serial serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
            pointd1 = new Point3D(num1, num2, num3);
            Mobile mobile1 = state.Mobile;
            if (serial1.IsMobile)
            {
                mobile1.Drop(World.FindMobile(serial1), pointd1);
                return;
            }
            if (serial1.IsItem)
            {
                mobile1.Drop(World.FindItem(serial1), pointd1);
                return;
            }
            mobile1.Drop(pointd1);
        }

        public static void Edit(NetState state, PacketReader pvSrc)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            object[] objArray1;
            if (PacketHandlers.VerifyGC(state))
            {
                num1 = pvSrc.ReadByte();
                num2 = pvSrc.ReadInt16();
                num3 = pvSrc.ReadInt16();
                num4 = pvSrc.ReadInt16();
                num5 = pvSrc.ReadSByte();
                num6 = pvSrc.ReadUInt16();
                objArray1 = new object[7];
                objArray1[0] = state;
                objArray1[1] = num2;
                objArray1[2] = num3;
                objArray1[3] = num5;
                objArray1[4] = num4;
                objArray1[5] = num6;
                objArray1[6] = num1;
                Console.WriteLine("God Client: {0}: Edit {6} ({1}, {2}, {3}) 0x{4:X} (0x{5:X})", objArray1);
            }
        }

        public static void Empty(NetState state, PacketReader pvSrc)
        {
        }

        public static void EncodedCommand(NetState state, PacketReader pvSrc)
        {
            IEntity entity1 = World.FindEntity(Serial.op_Implicit(pvSrc.ReadInt32()));
            int num1 = pvSrc.ReadUInt16();
            EncodedPacketHandler handler1 = PacketHandlers.GetEncodedHandler(num1);
            if (handler1 != null)
            {
                if (handler1.Ingame && (state.Mobile == null))
                {
                    Console.WriteLine("Client: {0}: Sent ingame packet (0xD7x{1:X2}) before having been attached to a mobile", state, num1);
                    state.Dispose();
                    return;
                }
                if (handler1.Ingame && state.Mobile.Deleted)
                {
                    state.Dispose();
                    return;
                }
                handler1.OnReceive.Invoke(state, entity1, new EncodedReader(pvSrc));
                return;
            }
            pvSrc.Trace(state);
        }

        public static void EquipReq(NetState state, PacketReader pvSrc)
        {
            Mobile mobile1 = state.Mobile;
            Item item1 = mobile1.Holding;
            if (item1 == null)
            {
                return;
            }
            mobile1.Holding = null;
            pvSrc.Seek(5, SeekOrigin.Current);
            Mobile mobile2 = World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32()));
            if (mobile2 == null)
            {
                mobile2 = mobile1;
            }
            if (((mobile1 != mobile2) && (mobile1.AccessLevel < AccessLevel.GameMaster)) || !mobile2.EquipItem(item1))
            {
                item1.Bounce(mobile1);
            }
            item1.ClearBounce();
        }

        public static void ExtendedCommand(NetState state, PacketReader pvSrc)
        {
            int num1 = pvSrc.ReadUInt16();
            PacketHandler handler1 = PacketHandlers.GetExtendedHandler(num1);
            if (handler1 != null)
            {
                if (handler1.Ingame && (state.Mobile == null))
                {
                    Console.WriteLine("Client: {0}: Sent ingame packet (0xBFx{1:X2}) before having been attached to a mobile", state, num1);
                    state.Dispose();
                    return;
                }
                if (handler1.Ingame && state.Mobile.Deleted)
                {
                    state.Dispose();
                    return;
                }
                handler1.OnReceive(state, pvSrc);
                return;
            }
            pvSrc.Trace(state);
        }

        public static void GameCentralMoniter(NetState state, PacketReader pvSrc)
        {
            int num1;
            int num2;
            if (PacketHandlers.VerifyGC(state))
            {
                num1 = pvSrc.ReadByte();
                num2 = pvSrc.ReadInt32();
                Console.WriteLine("God Client: {0}: Game central moniter", state);
                Console.WriteLine(" - Type: {0}", num1);
                Console.WriteLine(" - Number: {0}", num2);
                pvSrc.Trace(state);
            }
        }

        public static void GameLogin(NetState state, PacketReader pvSrc)
        {
            if (state.SentFirstPacket)
            {
                state.Dispose();
                return;
            }
            state.SentFirstPacket = true;
            int num1 = pvSrc.ReadInt32();
            if (!PacketHandlers.IsValidAuthID(num1))
            {
                Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", state);
                state.Dispose();
                return;
            }
            if ((state.m_AuthID != 0) && (num1 != state.m_AuthID))
            {
                Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", state);
                state.Dispose();
                return;
            }
            if ((state.m_AuthID == 0) && (num1 != state.m_Seed))
            {
                Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", state);
                state.Dispose();
                return;
            }
            string text1 = pvSrc.ReadString(30);
            string text2 = pvSrc.ReadString(30);
            GameLoginEventArgs args1 = new GameLoginEventArgs(state, text1, text2);
            EventSink.InvokeGameLogin(args1);
            if (args1.Accepted)
            {
                state.CityInfo = args1.CityInfo;
                state.CompressionEnabled = true;
                if (Core.AOS)
                {
                    state.Send(SupportedFeatures.Instantiate());
                }
                state.Send(new CharacterList(state.Account, state.CityInfo));
                return;
            }
            state.Dispose();
        }

        private static int GenerateAuthID()
        {
            int num3;
            int num1 = Utility.Random(1, 2147483646);
            if (Utility.RandomBool())
            {
                num1 |= -2147483648;
            }
            bool flag1 = false;
            DateTime time1 = DateTime.MaxValue;
            int num2 = 0;
            for (num3 = 0; (num3 < PacketHandlers.m_AuthIDWindow.Length); ++num3)
            {
                if (PacketHandlers.m_AuthIDWindow[num3] == 0)
                {
                    PacketHandlers.m_AuthIDWindow[num3] = num1;
                    PacketHandlers.m_AuthIDWindowAge[num3] = DateTime.Now;
                    flag1 = true;
                    break;
                }
                if (PacketHandlers.m_AuthIDWindowAge[num3] < time1)
                {
                    time1 = PacketHandlers.m_AuthIDWindowAge[num3];
                    num2 = num3;
                }
            }
            if (!flag1)
            {
                PacketHandlers.m_AuthIDWindow[num2] = num1;
                PacketHandlers.m_AuthIDWindowAge[num2] = DateTime.Now;
            }
            return num1;
        }

        public static EncodedPacketHandler GetEncodedHandler(int packetID)
        {
            if ((packetID >= 0) && (packetID < 256))
            {
                return PacketHandlers.m_EncodedHandlersLow[packetID];
            }
            return ((EncodedPacketHandler) PacketHandlers.m_EncodedHandlersHigh[packetID]);
        }

        public static PacketHandler GetExtendedHandler(int packetID)
        {
            if ((packetID >= 0) && (packetID < 256))
            {
                return PacketHandlers.m_ExtendedHandlersLow[packetID];
            }
            return ((PacketHandler) PacketHandlers.m_ExtendedHandlersHigh[packetID]);
        }

        public static PacketHandler GetHandler(int packetID)
        {
            return PacketHandlers.m_Handlers[packetID];
        }

        public static void GMSingle(NetState state, PacketReader pvSrc)
        {
            if (PacketHandlers.VerifyGC(state))
            {
                pvSrc.Trace(state);
            }
        }

        public static void GodModeRequest(NetState state, PacketReader pvSrc)
        {
            if (PacketHandlers.VerifyGC(state))
            {
                state.Send(new GodModeReply(pvSrc.ReadBoolean()));
            }
        }

        public static void GodviewQuery(NetState state, PacketReader pvSrc)
        {
            if (PacketHandlers.VerifyGC(state))
            {
                Console.WriteLine("God Client: {0}: Godview query 0x{1:X}", state, pvSrc.ReadByte());
            }
        }

        public static void HelpRequest(NetState state, PacketReader pvSrc)
        {
            EventSink.InvokeHelpRequest(new HelpRequestEventArgs(state.Mobile));
        }

        public static void HuePickerResponse(NetState state, PacketReader pvSrc)
        {
            int num3;
            HuePicker picker1;
            int num1 = pvSrc.ReadInt32();
            pvSrc.ReadInt16();
            int num2 = (pvSrc.ReadInt16() & 16383);
            num2 = Utility.ClipDyedHue(num2);
            HuePicker[] pickerArray1 = state.HuePickers;
            for (num3 = 0; (num3 < pickerArray1.Length); ++num3)
            {
                picker1 = pickerArray1[num3];
                if (picker1.Serial == num1)
                {
                    state.RemoveHuePicker(num3);
                    picker1.OnResponse(num2);
                    return;
                }
            }
        }

        private static bool IsValidAuthID(int authID)
        {
            int num1;
            for (num1 = 0; (num1 < PacketHandlers.m_AuthIDWindow.Length); ++num1)
            {
                if (PacketHandlers.m_AuthIDWindow[num1] == authID)
                {
                    PacketHandlers.m_AuthIDWindow[num1] = 0;
                    return true;
                }
            }
            return !PacketHandlers.m_ClientVerification;
        }

        public static void Language(NetState state, PacketReader pvSrc)
        {
            string text1 = pvSrc.ReadString(4);
            if (state.Mobile != null)
            {
                state.Mobile.Language = text1;
            }
        }

        public static void LiftReq(NetState state, PacketReader pvSrc)
        {
            bool flag1;
            LRReason reason1;
            Serial serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
            int num1 = pvSrc.ReadUInt16();
            Item item1 = World.FindItem(serial1);
            state.Mobile.Lift(item1, num1, out flag1, out reason1);
        }

        public static void LogoutReq(NetState state, PacketReader pvSrc)
        {
            state.Send(new LogoutAck());
        }

        public static void LookReq(NetState state, PacketReader pvSrc)
        {
            Mobile mobile2;
            Mobile mobile1 = state.Mobile;
            Serial serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
            if (serial1.IsMobile)
            {
                mobile2 = World.FindMobile(serial1);
                if (((mobile2 == null) || !mobile1.CanSee(mobile2)) || !Utility.InUpdateRange(mobile1, mobile2))
                {
                    return;
                }
                if (PacketHandlers.m_SingleClickProps)
                {
                    mobile2.OnAosSingleClick(mobile1);
                    return;
                }
                if (!mobile1.Region.OnSingleClick(mobile1, mobile2))
                {
                    return;
                }
                mobile2.OnSingleClick(mobile1);
                return;
            }
            if (!serial1.IsItem)
            {
                return;
            }
            Item item1 = World.FindItem(serial1);
            if (((item1 == null) || item1.Deleted) || (!mobile1.CanSee(item1) || !Utility.InUpdateRange(mobile1.Location, item1.GetWorldLocation())))
            {
                return;
            }
            if (PacketHandlers.m_SingleClickProps)
            {
                item1.OnAosSingleClick(mobile1);
                return;
            }
            if (!mobile1.Region.OnSingleClick(mobile1, item1))
            {
                return;
            }
            if ((item1.Parent is Item))
            {
                ((Item) item1.Parent).OnSingleClickContained(mobile1, item1);
            }
            item1.OnSingleClick(mobile1);
        }

        public static void MenuResponse(NetState state, PacketReader pvSrc)
        {
            int num3;
            int num1 = pvSrc.ReadInt32();
            pvSrc.ReadInt16();
            int num2 = pvSrc.ReadInt16();
            pvSrc.ReadInt16();
            pvSrc.ReadInt16();
            IMenu[] menuArray1 = state.Menus;
            for (num3 = 0; (num3 < menuArray1.Length); ++num3)
            {
                if (menuArray1[num3].Serial == num1)
                {
                    if (num2 <= 0)
                    {
                        menuArray1[num3].OnCancel(state);
                    }
                    else if (num2 <= menuArray1[num3].EntryLength)
                    {
                        menuArray1[num3].OnResponse(state, (num2 - 1));
                    }
                    state.RemoveMenu(num3);
                    return;
                }
            }
        }

        public static void MobileNameRequest(NetState state, PacketReader pvSrc)
        {
            Mobile mobile1 = World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32()));
            if (((mobile1 != null) && Utility.InUpdateRange(state.Mobile, mobile1)) && state.Mobile.CanSee(mobile1))
            {
                state.Send(new MobileName(mobile1));
            }
        }

        public static void MobileQuery(NetState state, PacketReader pvSrc)
        {
            object[] objArray1;
            Mobile mobile1 = state.Mobile;
            pvSrc.ReadInt32();
            int num1 = pvSrc.ReadByte();
            Mobile mobile2 = World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32()));
            if (mobile2 == null)
            {
                return;
            }
            int num2 = num1;
            if (num2 != 0)
            {
                switch (num2)
                {
                    case 4:
                    {
                        mobile2.OnStatsQuery(mobile1);
                        return;
                    }
                    case 5:
                    {
                        mobile2.OnSkillsQuery(mobile1);
                        return;
                    }
                }
            }
            else
            {
                if (!PacketHandlers.VerifyGC(state))
                {
                    return;
                }
                objArray1 = new object[4];
                objArray1[0] = state;
                objArray1[1] = num1;
                objArray1[2] = mobile2.Serial;
                objArray1[3] = mobile2.Name;
                Console.WriteLine("God Client: {0}: Query 0x{1:X2} on {2} \'{3}\'", objArray1);
                return;
            }
            pvSrc.Trace(state);
        }

        public static void MovementReq(NetState state, PacketReader pvSrc)
        {
            Direction direction1 = ((Direction) pvSrc.ReadByte());
            int num1 = pvSrc.ReadByte();
            pvSrc.ReadInt32();
            Mobile mobile1 = state.Mobile;
            if (((state.Sequence == 0) && (num1 != 0)) || !mobile1.Move(direction1))
            {
                state.Send(new MovementRej(num1, mobile1));
                state.Sequence = 0;
                mobile1.ClearFastwalkStack();
                return;
            }
            ++num1;
            if (num1 == 256)
            {
                num1 = 1;
            }
            state.Sequence = num1;
        }

        public static void NewAnimData(NetState state, PacketReader pvSrc)
        {
            if (PacketHandlers.VerifyGC(state))
            {
                Console.WriteLine("God Client: {0}: New tile animation", state);
                pvSrc.Trace(state);
            }
        }

        public static void NewRegion(NetState state, PacketReader pvSrc)
        {
            string text1;
            string text2;
            if (PacketHandlers.VerifyGC(state))
            {
                text1 = pvSrc.ReadString(40);
                pvSrc.ReadInt32();
                pvSrc.ReadInt16();
                pvSrc.ReadInt16();
                pvSrc.ReadInt16();
                pvSrc.ReadInt16();
                pvSrc.ReadInt16();
                pvSrc.ReadInt16();
                text2 = pvSrc.ReadString(40);
                pvSrc.ReadInt16();
                pvSrc.ReadInt16();
                pvSrc.ReadInt16();
                pvSrc.ReadByte();
                pvSrc.ReadInt16();
                Console.WriteLine("God Client: {0}: New Region \'{1}\' (\'{2}\')", state, text1, text2);
            }
        }

        public static void NewTerrain(NetState state, PacketReader pvSrc)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            object[] objArray1;
            if (PacketHandlers.VerifyGC(state))
            {
                num1 = pvSrc.ReadInt16();
                num2 = pvSrc.ReadInt16();
                num3 = pvSrc.ReadUInt16();
                num4 = pvSrc.ReadInt16();
                num5 = pvSrc.ReadInt16();
                objArray1 = new object[6];
                objArray1[0] = state;
                objArray1[1] = num1;
                objArray1[2] = num2;
                objArray1[3] = num4;
                objArray1[4] = num5;
                objArray1[5] = num3;
                Console.WriteLine("God Client: {0}: New Terrain ({1}, {2})+({3}, {4}) 0x{5:X4}", objArray1);
            }
        }

        public static void ObjectHelpRequest(NetState state, PacketReader pvSrc)
        {
            Item item1;
            Mobile mobile2;
            Mobile mobile1 = state.Mobile;
            Serial serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
            pvSrc.ReadByte();
            pvSrc.ReadString(3);
            if (serial1.IsItem)
            {
                item1 = World.FindItem(serial1);
                if (((item1 == null) || (mobile1.Map != item1.Map)) || (!Utility.InUpdateRange(item1.GetWorldLocation(), mobile1.Location) || !mobile1.CanSee(item1)))
                {
                    return;
                }
                item1.OnHelpRequest(mobile1);
                return;
            }
            if (serial1.IsMobile)
            {
                mobile2 = World.FindMobile(serial1);
                if (((mobile2 != null) && (mobile1.Map == mobile2.Map)) && (Utility.InUpdateRange(mobile2.Location, mobile1.Location) && mobile1.CanSee(mobile2)))
                {
                    mobile2.OnHelpRequest(mobile2);
                }
            }
        }

        public static void PartyMessage(NetState state, PacketReader pvSrc)
        {
            if (state.Mobile == null)
            {
                return;
            }
            switch (pvSrc.ReadByte())
            {
                case 1:
                {
                    PacketHandlers.PartyMessage_AddMember(state, pvSrc);
                    return;
                }
                case 2:
                {
                    PacketHandlers.PartyMessage_RemoveMember(state, pvSrc);
                    return;
                }
                case 3:
                {
                    PacketHandlers.PartyMessage_PrivateMessage(state, pvSrc);
                    return;
                }
                case 4:
                {
                    PacketHandlers.PartyMessage_PublicMessage(state, pvSrc);
                    return;
                }
                case 5:
                case 7:
                {
                    goto Label_0076;
                }
                case 6:
                {
                    PacketHandlers.PartyMessage_SetCanLoot(state, pvSrc);
                    return;
                }
                case 8:
                {
                    PacketHandlers.PartyMessage_Accept(state, pvSrc);
                    return;
                }
                case 9:
                {
                    PacketHandlers.PartyMessage_Decline(state, pvSrc);
                    return;
                }
            }
        Label_0076:
            pvSrc.Trace(state);
        }

        public static void PartyMessage_Accept(NetState state, PacketReader pvSrc)
        {
            if (PartyCommands.Handler != null)
            {
                PartyCommands.Handler.OnAccept(state.Mobile, World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32())));
            }
        }

        public static void PartyMessage_AddMember(NetState state, PacketReader pvSrc)
        {
            if (PartyCommands.Handler != null)
            {
                PartyCommands.Handler.OnAdd(state.Mobile);
            }
        }

        public static void PartyMessage_Decline(NetState state, PacketReader pvSrc)
        {
            if (PartyCommands.Handler != null)
            {
                PartyCommands.Handler.OnDecline(state.Mobile, World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32())));
            }
        }

        public static void PartyMessage_PrivateMessage(NetState state, PacketReader pvSrc)
        {
            if (PartyCommands.Handler != null)
            {
                PartyCommands.Handler.OnPrivateMessage(state.Mobile, World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32())), pvSrc.ReadUnicodeStringSafe());
            }
        }

        public static void PartyMessage_PublicMessage(NetState state, PacketReader pvSrc)
        {
            if (PartyCommands.Handler != null)
            {
                PartyCommands.Handler.OnPublicMessage(state.Mobile, pvSrc.ReadUnicodeStringSafe());
            }
        }

        public static void PartyMessage_RemoveMember(NetState state, PacketReader pvSrc)
        {
            if (PartyCommands.Handler != null)
            {
                PartyCommands.Handler.OnRemove(state.Mobile, World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32())));
            }
        }

        public static void PartyMessage_SetCanLoot(NetState state, PacketReader pvSrc)
        {
            if (PartyCommands.Handler != null)
            {
                PartyCommands.Handler.OnSetCanLoot(state.Mobile, pvSrc.ReadBoolean());
            }
        }

        public static void PingReq(NetState state, PacketReader pvSrc)
        {
            state.Send(PingAck.Instantiate(pvSrc.ReadByte()));
        }

        public static void PlayCharacter(NetState state, PacketReader pvSrc)
        {
            int num3;
            Mobile mobile2;
            pvSrc.ReadInt32();
            pvSrc.ReadString(30);
            pvSrc.Seek(2, SeekOrigin.Current);
            int num1 = pvSrc.ReadInt32();
            pvSrc.Seek(24, SeekOrigin.Current);
            int num2 = pvSrc.ReadInt32();
            pvSrc.ReadInt32();
            IAccount account1 = state.Account;
            if (((account1 == null) || (num2 < 0)) || (num2 >= 5))
            {
                state.Dispose();
                return;
            }
            Mobile mobile1 = account1[num2];
            for (num3 = 0; (num3 < 5); ++num3)
            {
                mobile2 = account1[num3];
                if (((mobile2 != null) && (mobile2.Map != Map.Internal)) && (mobile2 != mobile1))
                {
                    Console.WriteLine("Login: {0}: Account in use", state);
                    state.Send(new PopupMessage(PMMessage.CharInWorld));
                    return;
                }
            }
            if (mobile1 == null)
            {
                state.Dispose();
                return;
            }
            if (mobile1.NetState != null)
            {
                mobile1.NetState.Dispose();
            }
            NetState.ProcessDisposedQueue();
            state.BlockAllPackets = true;
            state.Flags = num1;
            state.Mobile = mobile1;
            mobile1.NetState = state;
            state.BlockAllPackets = false;
            PacketHandlers.DoLogin(state, mobile1);
        }

        public static void PlayServer(NetState state, PacketReader pvSrc)
        {
            int num1 = pvSrc.ReadInt16();
            ServerInfo[] infoArray1 = state.ServerInfo;
            IAccount account1 = state.Account;
            if (((infoArray1 == null) || (account1 == null)) || ((num1 < 0) || (num1 >= infoArray1.Length)))
            {
                state.Dispose();
                return;
            }
            ServerInfo info1 = infoArray1[num1];
            state.m_AuthID = (PlayServerAck.m_AuthID = PacketHandlers.GenerateAuthID());
            state.SentFirstPacket = false;
            state.Send(new PlayServerAck(info1));
        }

        public static void ProfileReq(NetState state, PacketReader pvSrc)
        {
            int num2;
            string text1;
            int num1 = pvSrc.ReadByte();
            Serial serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
            Mobile mobile1 = state.Mobile;
            Mobile mobile2 = World.FindMobile(serial1);
            if (mobile2 == null)
            {
                return;
            }
            switch (num1)
            {
                case 0:
                {
                    EventSink.InvokeProfileRequest(new ProfileRequestEventArgs(mobile1, mobile2));
                    return;
                }
                case 1:
                {
                    pvSrc.ReadInt16();
                    num2 = pvSrc.ReadUInt16();
                    if (num2 > 511)
                    {
                        return;
                    }
                    goto Label_005E;
                }
            }
            return;
        Label_005E:
            text1 = pvSrc.ReadUnicodeString(num2);
            EventSink.InvokeChangeProfileRequest(new ChangeProfileRequestEventArgs(mobile1, mobile2, text1));
        }

        public static void QueryProperties(NetState state, PacketReader pvSrc)
        {
            Mobile mobile2;
            Item item1;
            if (!ObjectPropertyList.Enabled)
            {
                return;
            }
            Mobile mobile1 = state.Mobile;
            Serial serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
            if (serial1.IsMobile)
            {
                mobile2 = World.FindMobile(serial1);
                if (((mobile2 == null) || !mobile1.CanSee(mobile2)) || !Utility.InUpdateRange(mobile1, mobile2))
                {
                    return;
                }
                mobile2.SendPropertiesTo(mobile1);
                return;
            }
            if (serial1.IsItem)
            {
                item1 = World.FindItem(serial1);
                if (((item1 != null) && !item1.Deleted) && (mobile1.CanSee(item1) && Utility.InUpdateRange(mobile1.Location, item1.GetWorldLocation())))
                {
                    item1.SendPropertiesTo(mobile1);
                }
            }
        }

        public static void QuestArrow(NetState state, PacketReader pvSrc)
        {
            bool flag1 = pvSrc.ReadBoolean();
            Mobile mobile1 = state.Mobile;
            if ((mobile1 != null) && (mobile1.QuestArrow != null))
            {
                mobile1.QuestArrow.OnClick(flag1);
            }
        }

        public static void Register(int packetID, int length, bool ingame, OnPacketReceive onReceive)
        {
            PacketHandlers.m_Handlers[packetID] = new PacketHandler(packetID, length, ingame, onReceive);
        }

        public static void RegisterEncoded(int packetID, bool ingame, OnEncodedPacketReceive onReceive)
        {
            if ((packetID >= 0) && (packetID < 256))
            {
                PacketHandlers.m_EncodedHandlersLow[packetID] = new EncodedPacketHandler(packetID, ingame, onReceive);
                return;
            }
            PacketHandlers.m_EncodedHandlersHigh[packetID] = new EncodedPacketHandler(packetID, ingame, onReceive);
        }

        public static void RegisterExtended(int packetID, bool ingame, OnPacketReceive onReceive)
        {
            if ((packetID >= 0) && (packetID < 256))
            {
                PacketHandlers.m_ExtendedHandlersLow[packetID] = new PacketHandler(packetID, 0, ingame, onReceive);
                return;
            }
            PacketHandlers.m_ExtendedHandlersHigh[packetID] = new PacketHandler(packetID, 0, ingame, onReceive);
        }

        public static void RemoveEncodedHandler(int packetID)
        {
            if ((packetID >= 0) && (packetID < 256))
            {
                PacketHandlers.m_EncodedHandlersLow[packetID] = null;
                return;
            }
            PacketHandlers.m_EncodedHandlersHigh.Remove(packetID);
        }

        public static void RemoveExtendedHandler(int packetID)
        {
            if ((packetID >= 0) && (packetID < 256))
            {
                PacketHandlers.m_ExtendedHandlersLow[packetID] = null;
                return;
            }
            PacketHandlers.m_ExtendedHandlersHigh.Remove(packetID);
        }

        public static void RenameRequest(NetState state, PacketReader pvSrc)
        {
            Mobile mobile1 = state.Mobile;
            Mobile mobile2 = World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32()));
            if (mobile2 != null)
            {
                EventSink.InvokeRenameRequest(new RenameRequestEventArgs(mobile1, mobile2, pvSrc.ReadStringSafe()));
            }
        }

        public static void RequestScrollWindow(NetState state, PacketReader pvSrc)
        {
            pvSrc.ReadInt16();
            pvSrc.ReadByte();
        }

        public static void ResourceQuery(NetState state, PacketReader pvSrc)
        {
            PacketHandlers.VerifyGC(state);
        }

        public static void Resynchronize(NetState state, PacketReader pvSrc)
        {
            Mobile mobile1 = state.Mobile;
            state.Send(new MobileUpdate(mobile1));
            state.Send(new MobileIncoming(mobile1, mobile1));
            mobile1.SendEverything();
            state.Sequence = 0;
            mobile1.ClearFastwalkStack();
        }

        public static void ScreenSize(NetState state, PacketReader pvSrc)
        {
            pvSrc.ReadInt32();
            pvSrc.ReadInt32();
        }

        public static void SecureTrade(NetState state, PacketReader pvSrc)
        {
            Serial serial1;
            SecureTradeContainer container1;
            Serial serial2;
            SecureTradeContainer container2;
            SecureTrade trade1;
            bool flag1;
            switch (pvSrc.ReadByte())
            {
                case 1:
                {
                    serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
                    container1 = (World.FindItem(serial1) as SecureTradeContainer);
                    if (((container1 == null) || (container1.Trade == null)) || ((container1.Trade.From.Mobile != state.Mobile) && (container1.Trade.To.Mobile != state.Mobile)))
                    {
                        return;
                    }
                    container1.Trade.Cancel();
                    return;
                }
                case 2:
                {
                    serial2 = Serial.op_Implicit(pvSrc.ReadInt32());
                    container2 = (World.FindItem(serial2) as SecureTradeContainer);
                    if (container2 == null)
                    {
                        return;
                    }
                    trade1 = container2.Trade;
                    flag1 = (pvSrc.ReadInt32() != 0);
                    if ((trade1 == null) || (trade1.From.Mobile != state.Mobile))
                    {
                        goto Label_00E1;
                    }
                    trade1.From.Accepted = flag1;
                    trade1.Update();
                    return;
                }
            }
            return;
        Label_00E1:
            if ((trade1 != null) && (trade1.To.Mobile == state.Mobile))
            {
                trade1.To.Accepted = flag1;
                trade1.Update();
            }
        }

        public static void SetAbility(NetState state, IEntity e, EncodedReader reader)
        {
            EventSink.InvokeSetAbility(new SetAbilityEventArgs(state.Mobile, reader.ReadInt32()));
        }

        public static void SetUpdateRange(NetState state, PacketReader pvSrc)
        {
            state.Send(ChangeUpdateRange.Instantiate(18));
        }

        public static void SetWarMode(NetState state, PacketReader pvSrc)
        {
            state.Mobile.DelayChangeWarmode(pvSrc.ReadBoolean());
        }

        public static void StatLockChange(NetState state, PacketReader pvSrc)
        {
            int num1 = pvSrc.ReadByte();
            int num2 = pvSrc.ReadByte();
            if (num2 > 2)
            {
                num2 = 0;
            }
            Mobile mobile1 = state.Mobile;
            if (mobile1 == null)
            {
                return;
            }
            switch (num1)
            {
                case 0:
                {
                    mobile1.StrLock = ((StatLockType) ((byte) num2));
                    return;
                }
                case 1:
                {
                    mobile1.DexLock = ((StatLockType) ((byte) num2));
                    return;
                }
                case 2:
                {
                    goto Label_0045;
                }
            }
            return;
        Label_0045:
            mobile1.IntLock = ((StatLockType) ((byte) num2));
        }

        public static void StunRequest(NetState state, PacketReader pvSrc)
        {
            EventSink.InvokeStunRequest(new StunRequestEventArgs(state.Mobile));
        }

        public static void SystemInfo(NetState state, PacketReader pvSrc)
        {
            pvSrc.ReadByte();
            pvSrc.ReadUInt16();
            pvSrc.ReadByte();
            pvSrc.ReadString(32);
            pvSrc.ReadString(32);
            pvSrc.ReadString(32);
            pvSrc.ReadString(32);
            pvSrc.ReadUInt16();
            pvSrc.ReadUInt16();
            pvSrc.ReadInt32();
            pvSrc.ReadInt32();
            pvSrc.ReadInt32();
        }

        public static void TargetResponse(NetState state, PacketReader pvSrc)
        {
            object obj1;
            Map map1;
            Tile[] tileArray1;
            bool flag1;
            int num6;
            int num1 = pvSrc.ReadByte();
            pvSrc.ReadInt32();
            pvSrc.ReadByte();
            Serial serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
            int num2 = pvSrc.ReadInt16();
            int num3 = pvSrc.ReadInt16();
            int num4 = pvSrc.ReadInt16();
            int num5 = pvSrc.ReadInt16();
            Mobile mobile1 = state.Mobile;
            Target target1 = mobile1.Target;
            if (target1 == null)
            {
                return;
            }
            if (((num2 == -1) && (num3 == -1)) && !serial1.IsValid)
            {
                target1.Cancel(mobile1, TargetCancelType.Canceled);
                return;
            }
            if (num1 == 1)
            {
                if (num5 == 0)
                {
                    obj1 = new LandTarget(new Point3D(num2, num3, num4), mobile1.Map);
                }
                else
                {
                    map1 = mobile1.Map;
                    if ((map1 == null) || (map1 == Map.Internal))
                    {
                        target1.Cancel(mobile1, TargetCancelType.Canceled);
                        return;
                    }
                    tileArray1 = map1.Tiles.GetStaticTiles(num2, num3, !target1.DisallowMultis);
                    flag1 = false;
                    for (num6 = 0; (!flag1 && (num6 < tileArray1.Length)); ++num6)
                    {
                        if ((tileArray1[num6].Z == num4) && ((tileArray1[num6].ID & 16383) == (num5 & 16383)))
                        {
                            flag1 = true;
                        }
                    }
                    if (!flag1)
                    {
                        target1.Cancel(mobile1, TargetCancelType.Canceled);
                        return;
                    }
                    obj1 = new StaticTarget(new Point3D(num2, num3, num4), num5);
                }
            }
            else if (serial1.IsMobile)
            {
                obj1 = World.FindMobile(serial1);
            }
            else if (serial1.IsItem)
            {
                obj1 = World.FindItem(serial1);
            }
            else
            {
                target1.Cancel(mobile1, TargetCancelType.Canceled);
                return;
            }
            target1.Invoke(mobile1, obj1);
        }

        public static void TextCommand(NetState state, PacketReader pvSrc)
        {
            string[] textArray1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num9;
            char[] chArray1;
            int num1 = pvSrc.ReadByte();
            string text1 = pvSrc.ReadString();
            Mobile mobile1 = state.Mobile;
            int num10 = num1;
            if (num10 <= 39)
            {
                if (num10 == 0)
                {
                    goto Label_006A;
                }
                if (num10 == 36)
                {
                    goto Label_00F9;
                }
                if (num10 == 39)
                {
                    goto Label_0148;
                }
                goto Label_01C8;
            }
            if (num10 == 67)
            {
                goto Label_012A;
            }
            switch (num10)
            {
                case 86:
                {
                    num9 = (Utility.ToInt32(text1) - 1);
                    EventSink.InvokeCastSpellRequest(new CastSpellRequestEventArgs(mobile1, num9, null));
                    return;
                }
                case 87:
                {
                    goto Label_01C8;
                }
                case 88:
                {
                    EventSink.InvokeOpenDoorMacroUsed(new OpenDoorMacroEventArgs(mobile1));
                    return;
                }
            }
            if (num10 == 199)
            {
                goto Label_00EC;
            }
            goto Label_01C8;
        Label_006A:
            if (!PacketHandlers.VerifyGC(state))
            {
                return;
            }
            try
            {
                chArray1 = new char[1];
                chArray1[0] = ' ';
                textArray1 = text1.Split(chArray1);
                num2 = Utility.ToInt32(textArray1[0]);
                num3 = Utility.ToInt32(textArray1[1]);
                if (textArray1.Length >= 3)
                {
                    num4 = Utility.ToInt32(textArray1[2]);
                }
                else if (mobile1.Map != null)
                {
                    num4 = mobile1.Map.GetAverageZ(num2, num3);
                }
                else
                {
                    num4 = 0;
                }
                mobile1.Location = new Point3D(num2, num3, num4);
                return;
            }
            catch
            {
                return;
            }
        Label_00EC:
            EventSink.InvokeAnimateRequest(new AnimateRequestEventArgs(mobile1, text1));
            return;
        Label_00F9:
            try
            {
                chArray1 = new char[1];
                chArray1[0] = ' ';
                num5 = Convert.ToInt32(text1.Split(chArray1)[0]);
            }
            catch
            {
                return;
            }
            Skills.UseSkill(mobile1, num5);
            return;
        Label_012A:
            try
            {
                num6 = Convert.ToInt32(text1);
            }
            catch
            {
                num6 = 1;
            }
            EventSink.InvokeOpenSpellbookRequest(new OpenSpellbookRequestEventArgs(mobile1, num6));
            return;
        Label_0148:
            chArray1 = new char[1];
            chArray1[0] = ' ';
            string[] textArray2 = text1.Split(chArray1);
            if (textArray2.Length <= 0)
            {
                return;
            }
            int num7 = (Utility.ToInt32(textArray2[0]) - 1);
            int num8 = ((textArray2.Length > 1) ? Utility.ToInt32(textArray2[1]) : -1);
            EventSink.InvokeCastSpellRequest(new CastSpellRequestEventArgs(mobile1, num7, World.FindItem(Serial.op_Implicit(num8))));
            return;
        Label_01C8:
            Console.WriteLine("Client: {0}: Unknown text-command type 0x{1:X2}: {2}", state, num1, text1);
        }

        public static void TripTime(NetState state, PacketReader pvSrc)
        {
            int num1 = pvSrc.ReadByte();
            pvSrc.ReadInt32();
            state.Send(new TripTimeResponse(num1));
        }

        public static void UnicodePromptResponse(NetState state, PacketReader pvSrc)
        {
            int num1 = pvSrc.ReadInt32();
            int num2 = pvSrc.ReadInt32();
            int num3 = pvSrc.ReadInt32();
            pvSrc.ReadString(4);
            string text1 = pvSrc.ReadUnicodeStringLESafe();
            if (text1.Length > 128)
            {
                return;
            }
            Mobile mobile1 = state.Mobile;
            Prompt prompt1 = mobile1.Prompt;
            if (((prompt1 == null) || (prompt1.Serial != num1)) || (prompt1.Serial != num2))
            {
                return;
            }
            mobile1.Prompt = null;
            if (num3 == 0)
            {
                prompt1.OnCancel(mobile1);
                return;
            }
            prompt1.OnResponse(mobile1, text1);
        }

        public static void UnicodeSpeech(NetState state, PacketReader pvSrc)
        {
            string text2;
            int[] numArray1;
            int num2;
            int num3;
            int num4;
            KeywordList list1;
            int num5;
            int num6;
            Mobile mobile1 = state.Mobile;
            MessageType type1 = ((MessageType) pvSrc.ReadByte());
            int num1 = pvSrc.ReadInt16();
            pvSrc.ReadInt16();
            string text1 = pvSrc.ReadString(4);
            bool flag1 = ((type1 & MessageType.Encoded) != MessageType.Regular);
            if (flag1)
            {
                num2 = pvSrc.ReadInt16();
                num3 = ((num2 & 65520) >> 4);
                num4 = (num2 & 15);
                if ((num3 < 0) || (num3 > 50))
                {
                    return;
                }
                list1 = PacketHandlers.m_KeywordList;
                for (num5 = 0; (num5 < num3); ++num5)
                {
                    if ((num5 & 1) == 0)
                    {
                        num4 = (num4 << 8);
                        num4 |= pvSrc.ReadByte();
                        num6 = num4;
                        num4 = 0;
                    }
                    else
                    {
                        num2 = pvSrc.ReadInt16();
                        num6 = ((num2 & 65520) >> 4);
                        num4 = (num2 & 15);
                    }
                    if (!list1.Contains(num6))
                    {
                        list1.Add(num6);
                    }
                }
                text2 = pvSrc.ReadUTF8StringSafe();
                numArray1 = list1.ToArray();
            }
            else
            {
                text2 = pvSrc.ReadUnicodeStringSafe();
                numArray1 = PacketHandlers.m_EmptyInts;
            }
            text2 = text2.Trim();
            if ((text2.Length <= 0) || (text2.Length > 128))
            {
                return;
            }
            type1 &= ((MessageType) -193);
            if (!Enum.IsDefined(typeof(MessageType), type1))
            {
                type1 = MessageType.Regular;
            }
            mobile1.Language = text1;
            mobile1.DoSpeech(text2, numArray1, type1, Utility.ClipDyedHue(num1));
        }

        public static void UseReq(NetState state, PacketReader pvSrc)
        {
            Serial serial1;
            Mobile mobile2;
            Item item1;
            Mobile mobile1 = state.Mobile;
            if ((mobile1.AccessLevel < AccessLevel.GameMaster) && (DateTime.Now < mobile1.NextActionTime))
            {
                goto Label_00AD;
            }
            int num1 = pvSrc.ReadInt32();
            if ((num1 & -2147483648) != 0)
            {
                mobile1.OnPaperdollRequest();
            }
            else
            {
                serial1 = Serial.op_Implicit(num1);
                if (serial1.IsMobile)
                {
                    mobile2 = World.FindMobile(serial1);
                    if ((mobile2 != null) && !mobile2.Deleted)
                    {
                        mobile1.Use(mobile2);
                    }
                }
                else if (serial1.IsItem)
                {
                    item1 = World.FindItem(serial1);
                    if ((item1 != null) && !item1.Deleted)
                    {
                        mobile1.Use(item1);
                    }
                }
            }
            mobile1.NextActionTime = (DateTime.Now + TimeSpan.FromSeconds(0.5));
            return;
        Label_00AD:
            mobile1.SendActionMessage();
        }

        public static void UTripTime(NetState state, PacketReader pvSrc)
        {
            int num1 = pvSrc.ReadByte();
            pvSrc.ReadInt32();
            state.Send(new UTripTimeResponse(num1));
        }

        public static void VendorBuyReply(NetState state, PacketReader pvSrc)
        {
            ArrayList list1;
            Serial serial1;
            int num3;
            IVendor vendor1;
            pvSrc.Seek(1, SeekOrigin.Begin);
            int num1 = pvSrc.ReadUInt16();
            Mobile mobile1 = World.FindMobile(Serial.op_Implicit(pvSrc.ReadInt32()));
            byte num2 = pvSrc.ReadByte();
            if (mobile1 == null)
            {
                return;
            }
            if (mobile1.Deleted || !Utility.RangeCheck(mobile1.Location, state.Mobile.Location, 10))
            {
                state.Send(new EndVendorBuy(mobile1));
                return;
            }
            if (num2 == 2)
            {
                num1 -= 8;
                if ((num1 / 7) > 100)
                {
                    return;
                }
                list1 = new ArrayList((num1 / 7));
                while ((num1 > 0))
                {
                    pvSrc.ReadByte();
                    serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
                    num3 = pvSrc.ReadInt16();
                    list1.Add(new BuyItemResponse(serial1, num3));
                    num1 -= 7;
                }
                if (list1.Count <= 0)
                {
                    return;
                }
                vendor1 = (mobile1 as IVendor);
                if ((vendor1 == null) || !vendor1.OnBuyItems(state.Mobile, list1))
                {
                    return;
                }
                state.Send(new EndVendorBuy(mobile1));
                return;
            }
            state.Send(new EndVendorBuy(mobile1));
        }

        public static void VendorSellReply(NetState state, PacketReader pvSrc)
        {
            int num2;
            Item item1;
            int num3;
            IVendor vendor1;
            Serial serial1 = Serial.op_Implicit(pvSrc.ReadInt32());
            Mobile mobile1 = World.FindMobile(serial1);
            if (mobile1 == null)
            {
                return;
            }
            if (mobile1.Deleted || !Utility.RangeCheck(mobile1.Location, state.Mobile.Location, 10))
            {
                state.Send(new EndVendorSell(mobile1));
                return;
            }
            int num1 = pvSrc.ReadUInt16();
            if ((num1 >= 100) || (pvSrc.Buffer.Length != (9 + (num1 * 6))))
            {
                return;
            }
            ArrayList list1 = new ArrayList(num1);
            for (num2 = 0; (num2 < num1); ++num2)
            {
                item1 = World.FindItem(Serial.op_Implicit(pvSrc.ReadInt32()));
                num3 = pvSrc.ReadInt16();
                if ((item1 != null) && (num3 > 0))
                {
                    list1.Add(new SellItemResponse(item1, num3));
                }
            }
            if (list1.Count > 0)
            {
                vendor1 = (mobile1 as IVendor);
                if ((vendor1 != null) && vendor1.OnSellItems(state.Mobile, list1))
                {
                    state.Send(new EndVendorSell(mobile1));
                }
            }
        }

        public static bool VerifyGC(NetState state)
        {
            if ((state.Mobile == null) || (state.Mobile.AccessLevel <= AccessLevel.Counselor))
            {
                if (state.Running)
                {
                    Console.WriteLine("Warning: {0}: Player using godclient, disconnecting", state);
                }
                state.Dispose();
                return false;
            }
            return true;
        }


        // Properties
        public static bool ClientVerification
        {
            get
            {
                return PacketHandlers.m_ClientVerification;
            }
            set
            {
                PacketHandlers.m_ClientVerification = value;
            }
        }

        public static PacketHandler[] Handlers
        {
            get
            {
                return PacketHandlers.m_Handlers;
            }
        }

        public static bool SingleClickProps
        {
            get
            {
                return PacketHandlers.m_SingleClickProps;
            }
            set
            {
                PacketHandlers.m_SingleClickProps = value;
            }
        }

        public static int[] ValidAnimations
        {
            get
            {
                return PacketHandlers.m_ValidAnimations;
            }
            set
            {
                PacketHandlers.m_ValidAnimations = value;
            }
        }


        // Fields
        private const int AuthIDWindowSize = 128;
        private const int BadFood = -1163005939;
        private const int BadUOTD = -3211314;
        private static int[] m_AuthIDWindow;
        private static DateTime[] m_AuthIDWindowAge;
        private static bool m_ClientVerification;
        private static int[] m_EmptyInts;
        private static Hashtable m_EncodedHandlersHigh;
        private static EncodedPacketHandler[] m_EncodedHandlersLow;
        private static Hashtable m_ExtendedHandlersHigh;
        private static PacketHandler[] m_ExtendedHandlersLow;
        private static PacketHandler[] m_Handlers;
        private static KeywordList m_KeywordList;
        private static bool m_SingleClickProps;
        public static int[] m_ValidAnimations;

        // Nested Types
        private class KickTimer : Timer
        {
            // Methods
            public KickTimer(NetState state, TimeSpan delay) : base(delay)
            {
                this.m_State = state;
            }

            protected override void OnTick()
            {
                if (this.m_State.Socket != null)
                {
                    Console.WriteLine("Client: {0}: Disconnecting, bad version", this.m_State);
                    this.m_State.Dispose();
                }
            }


            // Fields
            private NetState m_State;
        }
    }
}

