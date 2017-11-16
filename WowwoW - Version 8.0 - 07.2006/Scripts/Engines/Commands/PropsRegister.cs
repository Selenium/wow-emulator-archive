/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/

using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using Server;
using Server.Scripts.Properties;
using HelperTools;
using Server.Scripts;
namespace Server.Scripts.Properties
{
	public class Set : IInitialize
	{
		public static void Initialize()
		{
			CharacterProperties.Register( "Username", AccessLevels.Admin, new PropertyEventHandler( Set_Username ), new GetPropertyEventHandler( Get_Username) );
			CharacterProperties.Register( "Password", AccessLevels.Admin, new PropertyEventHandler( Set_Password ), new GetPropertyEventHandler( Get_Password) );
			CharacterProperties.Register( "AccessLevel", AccessLevels.Admin, new PropertyEventHandler( Set_AccessLevel ), new GetPropertyEventHandler( Get_AccessLevel) );

			CharacterProperties.Register( "Name", AccessLevels.GM, new PropertyEventHandler( Set_Name ), new GetPropertyEventHandler( Get_Name) );
			CharacterProperties.Register( "Money", AccessLevels.GM, new PropertyEventHandler( Set_Money ), new GetPropertyEventHandler( Get_Money) );

			MobileProperties.Register( "Str", AccessLevels.GM, new PropertyEventHandler( Set_Str ), new GetPropertyEventHandler( Get_Str) );
			MobileProperties.Register( "Agi", AccessLevels.GM, new PropertyEventHandler( Set_Agility ), new GetPropertyEventHandler( Get_Agility) );
			MobileProperties.Register( "Sta", AccessLevels.GM, new PropertyEventHandler( Set_Stamina ), new GetPropertyEventHandler( Get_Stamina) );
			MobileProperties.Register( "Int", AccessLevels.GM, new PropertyEventHandler( Set_Iq ), new GetPropertyEventHandler( Get_Iq) );
			MobileProperties.Register( "Spi", AccessLevels.GM, new PropertyEventHandler( Set_Spirit ), new GetPropertyEventHandler( Get_Spirit) );

			MobileProperties.Register( "Exp", AccessLevels.GM, new PropertyEventHandler( Set_Exp ), new GetPropertyEventHandler( Get_Exp) );
			MobileProperties.Register( "Model", AccessLevels.GM, new PropertyEventHandler( Set_Model ), new GetPropertyEventHandler( Get_Model) );
			MobileProperties.Register( "Size", AccessLevels.GM, new PropertyEventHandler( Set_Size ), new GetPropertyEventHandler( Get_Size) );
			MobileProperties.Register( "Speed", AccessLevels.GM, new PropertyEventHandler( Set_Speed ), new GetPropertyEventHandler( Get_Speed) );

			//Properties.Register( "X", AccessLevels.Admin, new PropertyEventHandler( Set_X ), new GetPropertyEventHandler( Get_X) );
			//Properties.Register( "Y", AccessLevels.Admin, new PropertyEventHandler( Set_Y ), new GetPropertyEventHandler( Get_Y) );
			//Properties.Register( "Z", AccessLevels.Admin, new PropertyEventHandler( Set_Z ), new GetPropertyEventHandler( Get_Z) );
			//Properties.Register( "ZoneId", AccessLevels.Admin, new PropertyEventHandler( Set_ZoneId ), new GetPropertyEventHandler( Get_ZoneId) );
		}

		private static void Set_Username( PropertyEventArgs e ) {((Character)e.Target).Player.Username = e.val;}
		private static string Get_Username( GetPropertyEventArgs e ) {return ((Character)e.Target).Player.Username;}

		private static void Set_Password( PropertyEventArgs e ) {((Character)e.Target).Player.Password = e.val;}
		private static string Get_Password( GetPropertyEventArgs e ) {return ((Character)e.Target).Player.Password;}

		private static void Set_AccessLevel( PropertyEventArgs e ) {((Character)e.Target).Player.AccessLevel = (AccessLevels)Utility.ToInt32(e.val);}
		private static string Get_AccessLevel( GetPropertyEventArgs e ) {return ((int)((Character)e.Target).Player.AccessLevel).ToString();}

//
		private static void Set_Name( PropertyEventArgs e ) {((Character)e.Target).Name = e.val;}
		private static string Get_Name( GetPropertyEventArgs e ) {return ((Character)e.Target).Name;}

		private static void Set_Money( PropertyEventArgs e ) {((Character)e.Target).Copper = (uint)Utility.ToInt32(e.val); ((Character)e.Target).ItemsUpdate();}
		private static string Get_Money( GetPropertyEventArgs e ) {return ((Character)e.Target).Copper.ToString();}

//
		private static void Set_Str( PropertyEventArgs e ) {e.Target.Str = Utility.ToInt32(e.val);}
		private static string Get_Str( GetPropertyEventArgs e ) {return e.Target.Str.ToString();}

		private static void Set_Agility( PropertyEventArgs e ) {e.Target.Agility = Utility.ToInt32(e.val);}
		private static string Get_Agility( GetPropertyEventArgs e ) {return e.Target.Agility.ToString();}

		private static void Set_Stamina( PropertyEventArgs e ) {e.Target.Stamina = Utility.ToInt32(e.val);}
		private static string Get_Stamina( GetPropertyEventArgs e ) {return e.Target.Stamina.ToString();}

		private static void Set_Iq( PropertyEventArgs e ) {e.Target.Iq = Utility.ToInt32(e.val);}
		private static string Get_Iq( GetPropertyEventArgs e ) {return e.Target.Iq.ToString();}

		private static void Set_Spirit( PropertyEventArgs e ) {e.Target.Spirit = Utility.ToInt32(e.val);}
		private static string Get_Spirit( GetPropertyEventArgs e ) {return e.Target.Spirit.ToString();}

//
		private static void Set_Exp( PropertyEventArgs e ) {e.Target.Exp = (uint)Utility.ToInt32(e.val);}
		private static string Get_Exp( GetPropertyEventArgs e ) {return e.Target.Exp.ToString();}

		private static void Set_Model( PropertyEventArgs e ) {e.Target.Model = Utility.ToInt32(e.val);}
		private static string Get_Model( GetPropertyEventArgs e ) {return e.Target.Model.ToString();}

		private static void Set_Size( PropertyEventArgs e ) {e.Target.Size = (float)Utility.ToDouble(e.val);}
		private static string Get_Size( GetPropertyEventArgs e ) {return e.Target.Size.ToString();}

		private static void Set_Speed( PropertyEventArgs e ) {e.Target.Speed = (float)Utility.ToDouble(e.val);}
		private static string Get_Speed( GetPropertyEventArgs e ) {return e.Target.Speed.ToString();}

//
		/*private static void Set_X( PropertyEventArgs e ) {e.Mobile.X = Utility.ToInt32(e.val);}
		private static string Get_X( GetPropertyEventArgs e ) {return e.Mobile.X.ToString();}

		private static void Set_Y( PropertyEventArgs e ) {e.Mobile.Y = Utility.ToInt32(e.val);}
		private static string Get_Y( GetPropertyEventArgs e ) {return e.Mobile.Y.ToString();}

		private static void Set_Z( PropertyEventArgs e ) {e.Mobile.Z = Utility.ToInt32(e.val);}
		private static string Get_Z( GetPropertyEventArgs e ) {return e.Mobile.Z.ToString();}

		private static void Set_ZoneId( PropertyEventArgs e ) {e.Mobile.ZoneId = (ushort)Utility.ToInt32(e.val);}
		private static string Get_ZoneId( GetPropertyEventArgs e ) {return e.Mobile.ZoneId.ToString();}*/




	}

}