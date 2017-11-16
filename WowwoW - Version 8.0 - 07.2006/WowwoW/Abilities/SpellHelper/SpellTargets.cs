using System;
using Server;
using HelperTools;
using System.Collections;
using System.Reflection;
using Server.Creatures;

namespace Server
{
   public enum TargetType
   {
      // Fields
      Friend = 2,
      Enemy = 1,
      Party = 0,
      Pet = 3,
      GameObj = 4
   }

   public class SpellTargets
   {
	   /// <summary>
	   /// Created by Volhv
	   /// </summary>
	   public static bool FaceToBehind( Mobile _char, Mobile _creature )
	   {
		   float a45 = 0.78539816339744830961566084581988f; // .. = pi / 180 * 45 ( 45 grad in radian )
		   float v1 = _char.Orientation; // orient vector of character
		   float v2 = _creature.Orientation; // orient vector of creature
		   float _l = v1 + a45; // -45
		   float _r = v1 - a45; // +45
		   return ( _l >= v2 && v2 >= _r ) && ( GetDirection( _char, _creature ) == Pos.Behind );
	   }
	   /// <summary>
	   /// Created by Volhv
	   /// </summary>
	   public enum Pos { Front, Behind }
	   /// <summary>
	   /// Logic by Nerub
	   /// </summary>
	   public static Pos GetDirection( Mobile from, Mobile to )
	   {
		   float pi = 3.1415926535897932384626433832795f;
		   float pi2 = 6.283185307179586476925286766559f;
		   float dx = from.X - to.X;
		   float dy = from.Y - to.Y;
		   float angleChar = (float)Math.Atan2( dy, dx );
		   float dr = Math.Abs( angleChar - to.Orientation );
		   float tmp = (float)( 2*dr / pi );
		   float k = (float)( (int)( dr / pi2 ) * 4 );
		   if ( (1+k < tmp) && (tmp < 3+k ) ) return Pos.Behind; 
		   else return Pos.Front;
	   }
      public static ArrayList targetsAround(Mobile src, float area, TargetType tt)
      {
         ArrayList list1 = new ArrayList();
         if (src is Character)
         {
            switch(tt)
            {
               case TargetType.Party:
                  foreach (Character character1 in (src as Character).GroupMembers.Members)
                  {
                     if (!(character1 == src))
                     {
                        continue;
                     }
                     if (character1.Distance(src) < (area * area))
                     {
                        list1.Add(character1);
                     }
                  }
                  break;
               case TargetType.Friend:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(src) < (area * area)) && !(mobile1 as BaseCreature).IsHostile(src))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;
               case TargetType.Enemy:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(src) < (area * area)) && ((mobile1 as BaseCreature).IsHostile(src)))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;

            }
         }
         else
         {
            switch(tt)
            {
               case TargetType.Friend:
                  foreach (Mobile mobile5 in src.KnownObjects)
                  {
                     if (mobile5 == src)
                     {
                        continue;
                     }
                     if ((mobile5.Distance(src) < (area * area)) && (mobile5 as BaseCreature).IsFriend(src))
                     {
                        list1.Add(mobile5);
                     }
                  }
                  break;
               case TargetType.Enemy:
                  foreach (Mobile mobile2 in src.KnownObjects)
                  {
                     if (mobile2 == src)
                     {
                        continue;
                     }
                     if ((mobile2.Distance(src) < (area * area)) && !(mobile2 as BaseCreature).IsFriend(src))
                     {
                        list1.Add(mobile2);
                     }
                  }
                  break;

            }
         }
         return list1;
      }

      public static ArrayList targetsAroundXYZ(Mobile src, float X, float Y, float Z, float area, TargetType tt)
      {
         ArrayList list1 = new ArrayList();
         if (src is Character)
         {
            switch(tt)
            {
               case TargetType.Party:
                  foreach (Character character1 in (src as Character).GroupMembers.Members)
                  {
                     if (!(character1 == src))
                     {
                        continue;
                     }
                     if ((character1.Distance(X, Y, Z) < (area * area)) && (character1.MapId == src.MapId))
                     {
                        list1.Add(character1);
                     }
                  }
                  break;
               case TargetType.Friend:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(X, Y, Z) < (area * area)) && ((mobile1 as BaseCreature).IsFriend(src)) && (mobile1.MapId == src.MapId))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;
               case TargetType.Enemy:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(X, Y, Z) < (area * area)) && !(mobile1 as BaseCreature).IsFriend(src) && (mobile1.MapId == src.MapId))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;

            }
         }
         else
         {
            switch(tt)
            {
               case TargetType.Friend:
                  foreach (Mobile mobile2 in src.KnownObjects)
                  {
                     if (mobile2 == src)
                     {
                        continue;
                     }
                     if ((mobile2.Distance(X, Y, Z) < (area * area)) && (mobile2 as BaseCreature).IsFriend(src) && (mobile2.MapId == src.MapId))
                     {
                        list1.Add(mobile2);
                     }
                  }
                  break;
               case TargetType.Enemy:
                  foreach (Mobile mobile2 in src.KnownObjects)
                  {
                     if (mobile2 == src)
                     {
                        continue;
                     }
                     if ((mobile2.Distance(X, Y, Z) < (area * area)) && !(mobile2 as BaseCreature).IsFriend(src) && (mobile2.MapId == src.MapId))
                     {
                        list1.Add(mobile2);
                     }
                  }
                  break;

            }
         }
         return list1;
      }

      public static ArrayList closeTargets(Mobile src, float area, int quantity, TargetType tt)
      {
         ArrayList list1 = new ArrayList();
         Mobile temp = null;
         ArrayList list2 = new ArrayList();
         if (src is Character)
         {
            switch(tt)
            {
               case TargetType.Party:
                  foreach (Character character1 in (src as Character).GroupMembers.Members)
                  {
                     if (!(character1 == src))
                     {
                        continue;
                     }
                     if (character1.Distance(src) < (area * area))
                     {
                        list1.Add(character1);
                     }
                  }
                  break;

               case TargetType.Friend:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(src) < (area * area)) && (mobile1 as BaseCreature).IsFriend(src))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;

               case TargetType.Enemy:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(src) < (area * area)) && !(mobile1 as BaseCreature).IsFriend(src))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;
            }               
         }
         else
         {
            switch(tt)
            {
				case TargetType.Friend:
					foreach (Object obj1 in src.KnownObjects)
					{
						if (!(obj1 is Mobile) || (obj1 == src))
						{
							continue;
						}
						Mobile mobile1 = obj1 as Mobile;
						if ((mobile1.Distance(src) < (area * area)) && (mobile1 as BaseCreature).IsFriend(src))
						{
							list1.Add(mobile1);
						}
					}
				break;
				case TargetType.Enemy:
					foreach (Object obj1 in src.KnownObjects)
					{
						if (!(obj1 is Mobile) || (obj1 == src))
						{
							continue;
						}
						Mobile mobile1 = obj1 as Mobile;
						if ((mobile1.Distance(src) < (area * area)) && !(mobile1 as BaseCreature).IsFriend(src))
						{
							list1.Add(mobile1);
						}
					}
						break;
            }                  
         }
         for (int i = 0;i<quantity;i++)
         {
            int index = 1;
            foreach (Mobile mobile1 in list1)
            {   
               if(index == 1)
               {
                  temp = mobile1;
                  continue;
               }
               i++;
               if (src.Distance(temp) < src.Distance(mobile1))
                  temp = mobile1;                           
            }
            if (temp != null)
               list2.Add(temp);
         }   
         return list2;
      }

      public static ArrayList targetsInConeFront(Mobile src, float area, TargetType tt, int divider)
      {
         ArrayList list1 = new ArrayList();
         if (divider == 0) divider = 1;
         if (src is Character)
         {
            switch(tt)
            {
               case TargetType.Party:
                  foreach (Character character1 in (src as Character).GroupMembers.Members)
                  {
                     if (!(character1 == src))
                     {
                        continue;
                     }
                     if (src.Distance(character1) < (area * area) && (InFrontOf(src as Character, character1, System.Math.PI / divider)))
                     {
                        list1.Add(character1);
                     }
                  }
                  break;
               case TargetType.Friend:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(src) < (area * area)) && (mobile1 as BaseCreature).IsFriend(src) && (InFrontOf(src as Character, mobile1, System.Math.PI / divider)))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;
               case TargetType.Enemy:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(src) < (area * area)) && !(mobile1 as BaseCreature).IsFriend(src) && (InFrontOf(src as Character, mobile1, System.Math.PI / divider)))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;

            }
         }
         else
         {
            switch(tt)
            {
               case TargetType.Friend:
                  foreach (Mobile mobile2 in src.KnownObjects)
                  {
                     if (mobile2 == src)
                     {
                        continue;
                     }
                     if ((mobile2.Distance(src) < (area * area)) && (mobile2 as BaseCreature).IsFriend(src) && (InFrontOf(src as Character, mobile2, System.Math.PI / divider)))
                     {
                        list1.Add(mobile2);
                     }
                  }
                  break;
               case TargetType.Enemy:
                  foreach (Mobile mobile2 in src.KnownObjects)
                  {
                     if (mobile2 == src)
                     {
                        continue;
                     }
                     if ((mobile2.Distance(src) < (area * area)) && !(mobile2 as BaseCreature).IsFriend(src)&&(InFrontOf(src as Character, mobile2, System.Math.PI / divider)))
                     {
                        list1.Add(mobile2);
                     }
                  }
                  break;

            }
         }
         return list1;
      }

      public static ArrayList targetsInConeBehind(Mobile src, float area, TargetType tt, int divider)
      {
         ArrayList list1 = new ArrayList();
         if (divider == 0) divider = 1;
         if (src is Character)
         {
            switch(tt)
            {
               case TargetType.Party:
                  foreach (Character character1 in (src as Character).GroupMembers.Members)
                  {
                     if (!(character1 == src))
                     {
                        continue;
                     }
                     if (src.Distance(character1) < (area * area) && (InBehindOf(src, character1, System.Math.PI / divider)))
                     {
                        list1.Add(character1);
                     }
                  }
                  break;
               case TargetType.Friend:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(src) < (area * area))&& (mobile1 as BaseCreature).IsFriend(src) && (InBehindOf(src, mobile1, System.Math.PI / divider)))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;
               case TargetType.Enemy:
                  foreach (Object obj1 in (src as Character).Player.KnownObjects)
                  {
                     if (!(obj1 is Mobile) || (obj1 == src))
                     {
                        continue;
                     }
                     Mobile mobile1 = obj1 as Mobile;
                     if ((mobile1.Distance(src) < (area * area)&& !(mobile1 as BaseCreature).IsFriend(src)) && (InBehindOf(src, mobile1, System.Math.PI / divider)))
                     {
                        list1.Add(mobile1);
                     }
                  }
                  break;

            }
         }
         else
         {
            switch(tt)
            {
               case TargetType.Friend:
                  foreach (Mobile mobile2 in src.KnownObjects)
                  {
                     if (mobile2 == src)
                     {
                        continue;
                     }
                     if ((mobile2.Distance(src) < (area * area))&& (mobile2 as BaseCreature).IsFriend(src) && (InBehindOf(src, mobile2, System.Math.PI / divider)))
                     {
                        list1.Add(mobile2);
                     }
                  }
                  break;
               case TargetType.Enemy:
                  foreach (Mobile mobile2 in src.KnownObjects)
                  {
                     if (mobile2 == src)
                     {
                        continue;
                     }
                     if ((mobile2.Distance(src) < (area * area))&& !(mobile2 as BaseCreature).IsFriend(src)&& (InBehindOf(src, mobile2, System.Math.PI / divider)))
                     {
                        list1.Add(mobile2);
                     }
                  }
                  break;

            }
         }
         return list1;

      }

      public static bool InBehindOf(Mobile ch, Mobile target, double maxDifference)
         {
            double angle = System.Math.Atan2( ch.Y - target.Y, ch.X - target.X);   
            System.Console.WriteLine(angle);
            if ( angle > -System.Math.PI && angle < -System.Math.PI/2) // III
            {
               angle += System.Math.PI*2;
            }
            if ( angle > -System.Math.PI/2 && angle < 0.0) // IV
            {
               angle += System.Math.PI*2;
            }
            System.Console.WriteLine(ch.Orientation);
            if ( (ch.Orientation+maxDifference/2) >= angle && (ch.Orientation-maxDifference/2) <= angle)
            {
               return true;
            }
            return false;
         }

       public static bool InFrontOf(Mobile ch, Mobile target, double maxDifference)
       {
           double angle = System.Math.Atan2(ch.Y - target.Y, ch.X - target.X);
           if (angle > -System.Math.PI && angle < -System.Math.PI / 2) // III 
           {
               angle += System.Math.PI * 2;
           }
           if (angle > -System.Math.PI / 2 && angle < 0.0) // IV 
           {
               angle += System.Math.PI * 2;
           }
           angle -= System.Math.PI;
           if (angle < 0) angle = System.Math.PI * 2 + angle;
           if (System.Math.Abs(ch.Orientation - angle) < maxDifference)
           {
               return true;
           }
           return false;
       }         
   }
}