namespace Server
{
    using System;

    public class BounceInfo
    {
        // Methods
        public BounceInfo(Item item)
        {
            this.m_Map = item.Map;
            this.m_Location = item.Location;
            this.m_WorldLoc = item.GetWorldLocation();
            this.m_Parent = item.Parent;
        }

        private BounceInfo(Map map, Point3D loc, Point3D worldLoc, object parent)
        {
            this.m_Map = map;
            this.m_Location = loc;
            this.m_WorldLoc = worldLoc;
            this.m_Parent = parent;
        }

        public static BounceInfo Deserialize(GenericReader reader)
        {
            Map map1;
            Point3D pointd1;
            Point3D pointd2;
            object obj1;
            Serial serial1;
            if (reader.ReadBool())
            {
                map1 = reader.ReadMap();
                pointd1 = reader.ReadPoint3D();
                pointd2 = reader.ReadPoint3D();
                serial1 = Serial.op_Implicit(reader.ReadInt());
                if (serial1.IsItem)
                {
                    obj1 = World.FindItem(serial1);
                }
                else if (serial1.IsMobile)
                {
                    obj1 = World.FindMobile(serial1);
                }
                else
                {
                    obj1 = null;
                }
                return new BounceInfo(map1, pointd1, pointd2, obj1);
            }
            return null;
        }

        public static void Serialize(BounceInfo info, GenericWriter writer)
        {
            if (info == null)
            {
                writer.Write(false);
                return;
            }
            writer.Write(true);
            writer.Write(info.m_Map);
            writer.Write(info.m_Location);
            writer.Write(info.m_WorldLoc);
            if ((info.m_Parent is Mobile))
            {
                writer.Write(((Mobile) info.m_Parent));
                return;
            }
            if ((info.m_Parent is Item))
            {
                writer.Write(((Item) info.m_Parent));
                return;
            }
            writer.Write(Serial.op_Implicit(Serial.op_Implicit(0)));
        }


        // Fields
        public Point3D m_Location;
        public Map m_Map;
        public object m_Parent;
        public Point3D m_WorldLoc;
    }
}

