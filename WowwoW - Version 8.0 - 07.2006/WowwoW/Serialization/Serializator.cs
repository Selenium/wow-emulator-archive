using System;
using System.Collections;
using System.Reflection;
using System.IO;
using HelperTools;

//Serialization v1.0
//Created by TUM 13.08.05
//Great Thanks to ShaiDeath for the help and bug fixing

//Serialization v1.1
//Modified by ShaiDeath 14.08.05

namespace Server.Serialization
{
	/// <summary>
	/// Summary description for Serialization.
	/// </summary>
	/// 
	public class Serializator : IInitialize
	{
		public static ArrayList SerializeList = new ArrayList();
		public static void Initialize()
		{
			World.onSave += new World.OnSaveDelegate(Save);
			Load();
			GenerateList();			
		}

		public static void GenerateList()
		{
			//Assembly ass = Utility.externAsm; 
			AssemblyListEnumerator ale = Utility.externAsm.GetEnumerator();
			while ( ale.MoveNext() )
			{			
				if ( ale.Key != "creatures" && ale.Key != "Items" )
					continue;
				Type[] types = ale.Value.GetTypes(); 
				for (int i=0; i<types.Length;i++) 
				{
					if ( types[i].GetInterface("ISerialize",true) != null)
					{
						ConstructorInfo info = Utility.FindConstructor( types[i].FullName);
						SerializeList.Add(info.Invoke(null));
					}
				}
			}
		}

		public static void Save()
		{
			Console.Write("Saving serialized classes...");
			BinaryFileWriter writer = new BinaryFileWriter("Scriptsave.bin");
			BinaryFileWriter idx = new BinaryFileWriter("Scriptsave.idx");
			
			idx.Write(SerializeList.Count);

			foreach (ISerialize ser in SerializeList)
			{
				idx.Write((string)ser.GetType().FullName);
				long start = writer.Position;                
				idx.Write((long)start);
                
				ser.Serialize(writer);

				idx.Write( (int) (writer.Position - start) );
			}

			Console.WriteLine("done.");
			writer.Close();
			idx.Close();
		}
		public static void Load()
		{
			ArrayList ClassList = new ArrayList();

			if (!File.Exists("Scriptsave.bin") && !File.Exists("Scriptsave.idx"))
				return;

			Console.Write("Scriptsave: Loading...");

			using ( FileStream idx = new FileStream( "Scriptsave.idx", FileMode.Open, FileAccess.Read, FileShare.Read ) )
			{
				BinaryFileReader idxReader = new BinaryFileReader(new BinaryReader( idx ));
	
				int Count = idxReader.ReadInt();
				
				for (int i=0; i<Count; i++)
				{
					string ClassName = idxReader.ReadString();				

					ConstructorInfo info = Utility.FindConstructor(ClassName);

					if (info == null)
					{
						Console.WriteLine( "failed" );
						Console.WriteLine( "Error: Type '{0}' was not found. Delete this type? (y/n)", ClassName );
						
						if ( Console.ReadLine() == "y" )
						{							
							Console.Write( "Scriptsave: Loading..." );
							idxReader.ReadLong();
							idxReader.ReadInt();
						}
						else
						{
							Console.WriteLine( "Type will not be deleted. An exception will be thrown when you press return" );
							Console.ReadLine();
							throw new Exception( String.Format( "Bad type '{0}'", ClassName ) );
						}
					}
					else
					{
						long pos = idxReader.ReadLong();
						int length = idxReader.ReadInt();
						if (info.Invoke(null) is ISerialize)
							ClassList.Add(new ClassEntry(ClassName, pos, length));
						else
						{
							Console.WriteLine( "failed" );
							Console.WriteLine( "Error: Type '{0}' is not ISerialize. Delete this type? (y/n)", ClassName );
							if ( Console.ReadLine() == "y" )
							{							
								Console.Write( "Scriptsave: Loading..." );								
							}
							else
							{
								Console.WriteLine( "Type will not be deleted. An exception will be thrown when you press return" );
								Console.ReadLine();
								throw new Exception( String.Format( "Bad type '{0}'", ClassName ));								
							}

						}
					}
				}
			}

			if (File.Exists("Scriptsave.bin"))
			{
				using ( FileStream bin = new FileStream( "Scriptsave.bin", FileMode.Open, FileAccess.Read, FileShare.Read ) )
				{
					BinaryFileReader reader = new BinaryFileReader( new BinaryReader( bin ) );

					for ( int i = 0; i < ClassList.Count; ++i )
					{
						ClassEntry entry = (ClassEntry)ClassList[i];
						ISerialize ser = entry.Class;

						reader.Seek(entry.Position, SeekOrigin.Begin);
						
							ser.Deserialize( reader );						
						if ( reader.Position != (entry.Position + entry.Length) )
						{
							Console.WriteLine( "failed" );
							Console.WriteLine(String.Format( "***** Bad serialize on '{0}' type *****", entry.ClassName ) );
							Console.WriteLine("Do you want to remove this serialize? (y/n)");
							string FailName = entry.ClassName;
							if (Console.ReadLine() == "y")
							{
								
								ClassList.RemoveAt(i);
								BinaryFileWriter idx = new BinaryFileWriter("Scriptsave.idx");
								idx.Write(ClassList.Count);
								foreach(ClassEntry classentry in ClassList)
								{
									idx.Write(classentry.ClassName);
									idx.Write(classentry.Position);
									idx.Write(classentry.Length);
								}
								idx.Close();
								Console.WriteLine("Serialization of '" + FailName + "' removed.");
								Console.WriteLine( "An exception will be thrown when you press return" );
								Console.ReadLine();
								throw new Exception( String.Format( "Bad serialize" ));	
							}
							else
							{
								Console.WriteLine("Serialization of '" + FailName + "' don't removed.");
								Console.WriteLine( "An exception will be thrown when you press return" );
								Console.ReadLine();
								throw new Exception( String.Format( "Bad serialize" ));	
							}
							
						}

					}
					reader.Close();
					Console.WriteLine("done");
				}
			}						
		}
	}
	
}
