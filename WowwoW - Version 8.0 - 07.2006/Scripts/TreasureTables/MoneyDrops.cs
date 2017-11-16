//script by ccsman

using Server;
namespace Server.Items
{
	public class MoneyDrops
	{
	
       public static Loot[] BeginnerMoneyDrops = new Loot[] {
                             new Loot( typeof( Money ), 1, 5, 100f )
                                                        };
       public static Loot[] LowMoneyDrops = new Loot[] {
                             new Loot( typeof( Money ), 6, 15, 100f )
                                                        };
       public static Loot[] MediumMoneyDrops = new Loot[] {
                             new Loot( typeof( Money ), 16, 25, 100f )
                                                        };
       public static Loot[] AdvancedMoneyDrops = new Loot[] {
                             new Loot( typeof( Money ), 26, 35, 100f )
                                                        };
       public static Loot[] HighMoneyDrops = new Loot[] {
                             new Loot( typeof( Money ), 36, 45, 100f )
                                                        };
       public static Loot[] AmazingMoneyDrops = new Loot[] {
                             new Loot( typeof( Money ), 46, 55, 100f )
                                                        };
       public static Loot[] IncredibleMoneyDrops = new Loot[] {
                             new Loot( typeof( Money ), 55, 60, 100f )
                                                        };

	public static int MinAmount (int lvl)
            {
             switch (lvl)
             {
              case 1 : return 3;
              case 2 : return 4;
              case 3 : return 5;
              case 4 : return 7;
              case 5 : return 8;
              case 6 : return 11;
              case 7 : return 17;
              case 8 : return 14;
              case 9 : return 12;
              case 10 : return 17;
              case 11 : return 19;
              case 12 : return 21;
              case 13 : return 24;
              case 14 : return 27;
              case 15 : return 30;
              case 16 : return 34;
              case 17 : return 37;
              case 18 : return 42;
              case 19 : return 46;
              case 20 : return 49;
              case 21 : return 54;
              case 22 : return 59;
              case 23 : return 65;
              case 24 : return 71;
              case 25 : return 78;
              case 26 : return 85;
              case 27 : return 92;
              case 28 : return 99;
              case 29 : return 10;
              case 30 : return 11;
              case 31 : return 11;
              case 32 : return 12;
              case 33 : return 13;
              case 34 : return 13;
              case 35 : return 14;
              case 36 : return 15;
              case 37 : return 16;
              case 38 : return 16;
              case 39 : return 17;
              case 40 : return 18;
              case 41 : return 19;
              case 42 : return 19;
              case 43 : return 20;
              case 44 : return 21;
              case 45 : return 22;
              case 46 : return 23;
              case 47 : return 24;
              case 48 : return 25;
              case 49 : return 26;
              case 50 : return 27;
              case 51 : return 28;
              case 52 : return 30;
              case 53 : return 31;
              case 54 : return 32;
              case 55 : return 34;
              case 56 : return 35;
              case 57 : return 36;
              case 58 : return 37;
              case 59 : return 39;
              case 60 : return 40;
              case 61 : return 41;
              case 62 : return 43;
              case 63 : return 44;
              case 64 : return 46;
              case 65 : return 47;
              default : return 10;
             }
            }
          public static int MaxAmount (int lvl)
            {
             switch (lvl)
             {
              case 1 : return 20;  
              case 2 : return 23;
              case 3 : return 27;
              case 4 : return 30;
              case 5 : return 33;
              case 6 : return 37;
              case 7 : return 40;
              case 8 : return 44;
              case 9 : return 48;
              case 10 : return 51;   
              case 11 : return 54;    
              case 12 : return 57;
              case 13 : return 61;    
              case 14 : return 64;
              case 15 : return 68;
              case 16 : return 71;
              case 17 : return 75;    
              case 18 : return 79;
              case 19 : return 82;    
              case 20 : return 86;
              case 21 : return 89;
              case 22 : return 93;
              case 23 : return 96;    
              case 24 : return 99;
              case 25 : return 107;    
              case 26 : return 102;    
              case 27 : return 117;
              case 28 : return 112;
              case 29 : return 117;
              case 30 : return 122;
              case 31 : return 127;    
              case 32 : return 125;
              case 33 : return 133;
              case 34 : return 133;    
              case 35 : return 146;
              case 36 : return 159;
              case 37 : return 167;   
              case 38 : return 175;
              case 39 : return 189;    
              case 40 : return 190;
              case 41 : return 217;    
              case 42 : return 222;    
              case 43 : return 244;    
              case 44 : return 254;    
              case 45 : return 272;    
              case 46 : return 278;    
              case 47 : return 282;
              case 48 : return 297;
              case 49 : return 293;    
              case 50 : return 308;    
              case 51 : return 302;    
              case 52 : return 318;    
              case 53 : return 313;   
              case 54 : return 328;
              case 55 : return 323;
              case 56 : return 338;   
              case 57 : return 341;
              case 58 : return 347;    
              case 59 : return 351;
              case 60 : return 356;
              case 61 : return 360;
              case 62 : return 364;
              case 63 : return 371;
              case 64 : return 376;
              case 65 : return 382;
              default : return 10;
             }
      }
  }

}              
