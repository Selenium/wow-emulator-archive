namespace Server
{
    using System;

    public class EquipedSkillMod : SkillMod
    {
        // Methods
        public EquipedSkillMod(SkillName skill, bool relative, double value, Item item, Mobile mobile) : base(skill, relative, value)
        {
            this.m_Item = item;
            this.m_Mobile = mobile;
        }

        public override bool CheckCondition()
        {
            if (!this.m_Item.Deleted && !this.m_Mobile.Deleted)
            {
                return (this.m_Item.Parent == this.m_Mobile);
            }
            return false;
        }


        // Fields
        private Item m_Item;
        private Mobile m_Mobile;
    }
}

