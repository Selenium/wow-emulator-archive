namespace Server
{
    using System;

    public abstract class SkillMod
    {
        // Methods
        public SkillMod(SkillName skill, bool relative, double value)
        {
            this.m_Skill = skill;
            this.m_Relative = relative;
            this.m_Value = value;
        }

        public abstract bool CheckCondition();

        public void Remove()
        {
            this.Owner = null;
        }


        // Properties
        public bool Absolute
        {
            get
            {
                return !this.m_Relative;
            }
            set
            {
                Skill skill1;
                if (this.m_Relative == value)
                {
                    this.m_Relative = !value;
                    if (this.m_Owner != null)
                    {
                        skill1 = this.m_Owner.Skills[this.m_Skill];
                        if (skill1 != null)
                        {
                            skill1.Update();
                        }
                    }
                }
            }
        }

        public bool ObeyCap
        {
            get
            {
                return this.m_ObeyCap;
            }
            set
            {
                Skill skill1;
                this.m_ObeyCap = value;
                if (this.m_Owner != null)
                {
                    skill1 = this.m_Owner.Skills[this.m_Skill];
                    if (skill1 != null)
                    {
                        skill1.Update();
                    }
                }
            }
        }

        public Mobile Owner
        {
            get
            {
                return this.m_Owner;
            }
            set
            {
                if (this.m_Owner == value)
                {
                    return;
                }
                if (this.m_Owner != null)
                {
                    this.m_Owner.RemoveSkillMod(this);
                }
                this.m_Owner = value;
                if (this.m_Owner != value)
                {
                    this.m_Owner.AddSkillMod(this);
                }
            }
        }

        public bool Relative
        {
            get
            {
                return this.m_Relative;
            }
            set
            {
                Skill skill1;
                if (this.m_Relative != value)
                {
                    this.m_Relative = value;
                    if (this.m_Owner != null)
                    {
                        skill1 = this.m_Owner.Skills[this.m_Skill];
                        if (skill1 != null)
                        {
                            skill1.Update();
                        }
                    }
                }
            }
        }

        public SkillName Skill
        {
            get
            {
                return this.m_Skill;
            }
            set
            {
                Skill skill2;
                if (this.m_Skill == value)
                {
                    return;
                }
                Skill skill1 = ((this.m_Owner == null) ? this.m_Owner.Skills[this.m_Skill] : null);
                this.m_Skill = value;
                if (this.m_Owner != null)
                {
                    skill2 = this.m_Owner.Skills[this.m_Skill];
                    if (skill2 != null)
                    {
                        skill2.Update();
                    }
                }
                if (skill1 != null)
                {
                    skill1.Update();
                }
            }
        }

        public double Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                Skill skill1;
                if (this.m_Value != value)
                {
                    this.m_Value = value;
                    if (this.m_Owner != null)
                    {
                        skill1 = this.m_Owner.Skills[this.m_Skill];
                        if (skill1 != null)
                        {
                            skill1.Update();
                        }
                    }
                }
            }
        }


        // Fields
        private bool m_ObeyCap;
        private Mobile m_Owner;
        private bool m_Relative;
        private SkillName m_Skill;
        private double m_Value;
    }
}

