using System;
using System.Reflection;

namespace DDB
{
	/// <summary>
	/// Summary description for ClassDescriptor.
	/// </summary>
	public class ClassDescriptor
	{
		Type []types;
		public ClassDescriptor()
		{
		}
		public ClassDescriptor( Type []t )
		{
			types = t;
		}
		public object Construct( Type t, byte []b )
		{
			ConstructorInfo []ci = t.GetConstructors();
			object []ca = null;
			ConstructorInfo ct = null;
			for(int i = 0;i < ci.Length;i++ )
			{
				ca = ci[ i ].GetCustomAttributes( typeof( DDBConstructor ) , true );
				if ( ca.Length > 0 )
				{
					ct = ci[ i ];
					break;
				}
			}
			if ( ct != null )
			{
				ParameterInfo []pi = ct.GetParameters();
				int offset = 0;
				object []parameters = new object[ pi.Length ];
				for(int j = 0;j < pi.Length;j++ )
				{
					ParameterInfo p = pi[ j ];
					if ( p.ParameterType == typeof( System.Int32 ) )
					{
						parameters[ j ] = BitConverter.ToInt32( b, offset );
						offset += 4;
					}
					if ( p.ParameterType == typeof( System.UInt32 ) )
					{
						parameters[ j ] = BitConverter.ToUInt32( b, offset );
						offset += 4;
					}
					if ( p.ParameterType == typeof( System.Single ) )
					{
						parameters[ j ] = BitConverter.ToSingle( b, offset );
						offset += 4;
					}
					if ( p.ParameterType == typeof( System.Byte ) )
					{
						parameters[ j ] = b[ offset++ ];
					}
					if ( p.ParameterType == typeof( Int32[] ) )
					{						
						int nElement = BitConverter.ToInt32( b, offset );
						offset += 4;
						int []array = new int[ nElement ];						
						for(int n = 0;n < nElement;n++ )
						{
							array[ n ] = BitConverter.ToInt32( b, offset );
							offset += 4;
						}
						parameters[ j ] = array;
					}
				}
				
				return ct.Invoke( parameters );
			}
			return null;
		}
	}
}
