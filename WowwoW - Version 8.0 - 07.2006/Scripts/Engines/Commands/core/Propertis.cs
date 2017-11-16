/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/

using System;
using System.IO;
using System.Collections;
using Server;

namespace Server.Scripts.Properties
{
	public delegate void PropertyEventHandler( PropertyEventArgs e );
	public delegate string GetPropertyEventHandler( GetPropertyEventArgs e );

	public class PropertyEventArgs : EventArgs
	{
		private Mobile m_Target;
		private string m_Property, m_val;

		public Mobile Target
		{
			get
			{
				return m_Target;
			}
		}

		public string Property
		{
			get
			{
				return m_Property;
			}
		}

		public string val
		{
			get
			{
				return m_val;
			}
		}

		public PropertyEventArgs( Mobile target, string property, string val)
		{
			m_Target = target;
			m_Property = property;
			m_val = val;
		}
	}

	public class GetPropertyEventArgs : EventArgs
	{
		private Mobile m_Target;
		private string m_Property;

		public Mobile Target
		{
			get
			{
				return m_Target;
			}
		}

		public string Property
		{
			get
			{
				return m_Property;
			}
		}

		public GetPropertyEventArgs( Mobile target, string property)
		{
			m_Target = target;
			m_Property = property;
		}
	}

	public class PropertyEntry : IComparable
	{
		private string m_Property;
		private PropertyEventHandler m_Handler;
		private AccessLevels m_AccessLevel;

		public string Property
		{
			get
			{
				return m_Property;
			}
		}

		public PropertyEventHandler Handler
		{
			get
			{
				return m_Handler;
			}
		}		

		public AccessLevels AccessLevel
		{
			get
			{
				return m_AccessLevel;
			}
		}

		public PropertyEntry( string property, PropertyEventHandler handler, AccessLevels accessLevel )
		{
			m_Property = property;
			m_Handler = handler;
			m_AccessLevel = accessLevel;
		}

		public int CompareTo( object obj )
		{
			if ( obj == this )
				return 0;
			else if ( obj == null )
				return 1;

			PropertyEntry e = obj as PropertyEntry;

			if ( e == null )
				throw new ArgumentException();

			return m_Property.CompareTo( e.m_Property );
		}
	}

	public class GetPropertyEntry : IComparable
	{
		private string m_Property;
		private GetPropertyEventHandler m_GetHandler;
		private AccessLevels m_AccessLevel;

		public string Property
		{
			get
			{
				return m_Property;
			}
		}	

		public GetPropertyEventHandler GetHandler
		{
			get
			{
				return m_GetHandler;
			}
		}

		public AccessLevels AccessLevel
		{
			get
			{
				return m_AccessLevel;
			}
		}

		public GetPropertyEntry( string property, GetPropertyEventHandler gethandler, AccessLevels accessLevel )
		{
			m_Property = property;
			m_GetHandler = gethandler;
			m_AccessLevel = accessLevel;
		}

		public int CompareTo( object obj )
		{
			if ( obj == this )
				return 0;
			else if ( obj == null )
				return 1;

			GetPropertyEntry e = obj as GetPropertyEntry;

			if ( e == null )
				throw new ArgumentException();

			return m_Property.CompareTo( e.m_Property );
		}
	}

	public class CharacterProperties
	{
		private static Hashtable m_Entries;
		private static Hashtable m_GetEntries;

		public static Hashtable Entries
		{
			get
			{
				return m_Entries;
			}
		}
		public static Hashtable GetEntries
		{
			get
			{
				return m_GetEntries;
			}
		}

		static CharacterProperties()
		{
			m_Entries = new Hashtable( CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default );
			m_GetEntries = new Hashtable( CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default );
		}

		public static void Register( string property, AccessLevels access, PropertyEventHandler handler, GetPropertyEventHandler gethandler)
		{
			m_Entries[property] = new PropertyEntry( property, handler, access );
			m_GetEntries[property] = new GetPropertyEntry( property, gethandler, access );
		}

		public static AccessLevels GetAccessLevel(string property)
		{
            GetPropertyEntry entry = (GetPropertyEntry)m_GetEntries[property];
			if ( entry != null )
			{
				return entry.AccessLevel;
			}
			return AccessLevels.PlayerLevel;
		}

		public static bool HasProperty(string property)
		{
            GetPropertyEntry entry = (GetPropertyEntry)m_GetEntries[property];
			if ( entry!=null )
			{
				if ( entry.GetHandler != null )
				{
					return true;
				}
			}
			return false;
		}

		public static string GetValue( Mobile target, string propery)
		{
			if (!(target is Character)) return "";

			GetPropertyEntry entry = (GetPropertyEntry)m_GetEntries[propery];
			if ( entry != null )
			{
				if ( entry.GetHandler != null )
				{
					GetPropertyEventArgs e = new GetPropertyEventArgs( target, propery);
					string str = entry.GetHandler( e );
					EventSink.InvokeGetProperty( e );
					return str;
				}
				else
				{
					return "";
				}
			}
			else
			{
				return "";
			}
		}
		public static bool SetValue( Mobile target, string propery, string val )
		{

			PropertyEntry entry = (PropertyEntry)m_Entries[propery];

			if ( entry != null )
			{
				if ( entry.Handler != null )
				{
					PropertyEventArgs e = new PropertyEventArgs( target, propery, val);
					entry.Handler( e );
					EventSink.InvokeProperty( e );
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}

			return true;
		}
	}



	public class MobileProperties
	{
		private static Hashtable m_Entries;
		private static Hashtable m_GetEntries;

		public static Hashtable Entries
		{
			get
			{
				return m_Entries;
			}
		}
		public static Hashtable GetEntries
		{
			get
			{
				return m_GetEntries;
			}
		}

		static MobileProperties()
		{
			m_Entries = new Hashtable( CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default );
			m_GetEntries = new Hashtable( CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default );
		}

		public static void Register( string property, AccessLevels access, PropertyEventHandler handler, GetPropertyEventHandler gethandler)
		{
			m_Entries[property] = new PropertyEntry( property, handler, access );
			m_GetEntries[property] = new GetPropertyEntry( property, gethandler, access );
		}

		public static AccessLevels GetAccessLevel(string property)
		{
			GetPropertyEntry entry = (GetPropertyEntry)m_GetEntries[property];
			if ( entry != null )
			{
				return entry.AccessLevel;
			}
			return AccessLevels.PlayerLevel;
		}

		public static bool HasProperty(string propery)
		{
			GetPropertyEntry entry = (GetPropertyEntry)m_GetEntries[propery];
			if ( entry!=null )
			{
				if ( entry.GetHandler != null )
				{
					return true;
				}
			}
			return false;
		}

		public static string GetValue( Mobile target, string propery)
		{
			GetPropertyEntry entry = (GetPropertyEntry)m_GetEntries[propery];
			if ( entry != null )
			{

				if ( entry.GetHandler != null )
				{
					GetPropertyEventArgs e = new GetPropertyEventArgs( target, propery);
					string str = entry.GetHandler( e );
					EventSink.InvokeGetProperty( e );
					return str;
				}
				else
				{
					return "";
				}

			}
			else
			{
				return "";
			}
		}

		public static bool SetValue( Mobile target, string propery, string val )
		{

			PropertyEntry entry = (PropertyEntry)m_Entries[propery];

			if ( entry != null )
			{
				if ( entry.Handler != null )
				{
					PropertyEventArgs e = new PropertyEventArgs( target, propery, val);
					entry.Handler( e );
					EventSink.InvokeProperty( e );
				}
			}
			else
			{
				return false;
			}

			return true;
		}
	}


}