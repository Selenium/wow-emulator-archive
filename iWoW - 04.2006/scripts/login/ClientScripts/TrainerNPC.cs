using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientScripts
{
	/// <summary>
	/// Summary description for TrainerNPC.
	/// </summary>
	[LoginPacketHandler()]
	public class Trainer
	{
		[LoginPacketDelegate(CMSG.TRAINER_LIST)]
		static bool TrainerList(LoginClient client, CMSG msgID, BinReader data)
		{

			ulong trainerGUID = data.ReadUInt64();

			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID = '"+trainerGUID+"'");
			if (obj.Length==0) 
			{
				Chat.System(client, "Vendor not found");
				return true;
			}
			uint[] PlayerSpellIDs = null;
			if (client.Character.Spells!=null)
			{
				PlayerSpellIDs = new uint[client.Character.Spells.Length];
				for (int i=0;i<client.Character.Spells.Length;i++)
					PlayerSpellIDs[i] = client.Character.Spells[i].Spell_Id;
			}
			DBVendor tvendor = (DBVendor)obj[0];
			DataServer.Database.FillObjectRelations(tvendor);
			string greets = "Welcome, " +client.Character.Name+ "! Choose your skill or spell :";
			
			BinWriter trainer = LoginClient.NewPacket(SMSG.TRAINER_LIST);

			//Guid of the trainer
			trainer.Write(trainerGUID);
			//Fill the hole
			trainer.Write((UInt32)0);
			if (tvendor.Trainings==null)
			{	
				trainer.Write((uint)0);			
			}
			else
			{
				//Number of spells to show
				trainer.Write((UInt32)tvendor.Trainings.Length);  //Set this later too, just a default

				foreach (DBTraining training in tvendor.Trainings)
				{
					if (training.Spell.PlayerLevel>tvendor.Level) continue;
						//				bool tmp=false;
						//				if (tmp) continue;
					else
					{
						byte showspell=0;
						if (client.Character.Level<training.Spell.PlayerLevel) showspell=1;
						else
							if (PlayerSpellIDs!=null)
								foreach (uint kspellid in PlayerSpellIDs)
									if (kspellid == training.SpellID) showspell=2;
						//Id of the Spell
						trainer.Write((UInt32)training.SpellID);
						//Shown or not ? (0 = yes, 1 = no);
						trainer.Write((Byte)showspell); 
						//Price of the spell
						trainer.Write((UInt32)training.Price);
						//Unknow
						trainer.Write((UInt32)0);
						//Unknow
						trainer.Write((UInt32)0);
						//Required Level
						trainer.Write((UInt32)training.Spell.PlayerLevel);
						//Unknow
						trainer.Write((UInt32)0);
						//Unknow
						trainer.Write((UInt32)0);
						//Unknow
						trainer.Write((UInt32)0);
						//Unknow
						trainer.Write((UInt32)0);
						//Unknow
						trainer.Write((Byte)0);
					}
				}
			}
/*			//Id of the Spell
			trainer.Write((UInt32)143);
			//Shown or not ? (0 = yes, 1 = no);
			trainer.Write((Byte)0);
			//Price of the spell
			trainer.Write((UInt32)1);
			//Unknow
			trainer.Write((UInt32)0);
			//Unknow
			trainer.Write((UInt32)0);
			//Required Level
			trainer.Write((UInt32)3);
			//Unknow
			trainer.Write((UInt32)0);
			//Unknow
			trainer.Write((UInt32)0);
			//Unknow
			trainer.Write((UInt32)0);
			//Unknow
			trainer.Write((UInt32)0);
			//Unknow
			trainer.Write((Byte)0);
*/			//Greeting Message
			trainer.Write(greets);
			client.Send(trainer);

			Chat.System(client, "Trainer Working : GUID "+trainerGUID);
			
			return true;
		}
		[LoginPacketDelegate(CMSG.TRAINER_BUY_SPELL)]
		static bool TrainerBuy(LoginClient client, CMSG msgID, BinReader data)
		{

			ulong trainerGUID = data.ReadUInt64();
			ulong spellId = data.ReadUInt32();
			BinWriter trainer = LoginClient.NewPacket(SMSG.TRAINER_BUY_SUCCEEDED);
			trainer.Write(trainerGUID);
			trainer.Write(spellId);
			client.Send(trainer);

			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID = '"+trainerGUID+"'");
			if (obj.Length==0) 
			{
				Chat.System(client, "Vendor not found");
				return true;
			}

			DBVendor tvendor = (DBVendor)obj[0];
			DBTraining tTrain = null;
			foreach (DBTraining training in tvendor.Trainings)
			{
				if (training.SpellID==spellId)
				{
					tTrain = training;
					break;
				}
			}
			if (tTrain==null) {Chat.System("This vendor cannot teach you that spell");return true;}
			


//			DBSpell targetSpell = (DBSpell)DataServer.Database.FindObjectByKey(typeof(DBSpell), spellId);
			DBSpell targetSpell = tTrain.Spell;
			uint teachSpellId = (tTrain.TeachSpellID==0?0x1ff7:tTrain.TeachSpellID);

			if (targetSpell==null)	{Chat.System(client, "Spell "+spellId+" not found");return true;}
			DBKnownSpell newSpell = new DBKnownSpell();
			newSpell.Spell_Id=(uint)spellId;
			if (client.Character.Spells==null||client.Character.Spells.Length==0)
				newSpell.Slot=1;
			else
				newSpell.Slot=(uint)client.Character.Spells.Length+1;

			newSpell.CharacterID=client.Character.ObjectId;
			try
			{
				newSpell.SpellLevel = uint.Parse(targetSpell.Rank);
			}
			catch(Exception){}

			if (newSpell.SpellLevel==0) newSpell.SpellLevel=1;
			DataServer.Database.AddNewObject(newSpell);
			DataServer.Database.FillObjectRelations(client.Character);
			DataServer.Database.FillObjectRelations(client.Character.Spells[newSpell.Slot-1]);
			try
			{
				Chat.System(client, "Spell "+client.Character.Spells[newSpell.Slot-1].Spell.Name+" added.");
			}
			catch(Exception){}


			BinWriter trainer2 = LoginClient.NewPacket(SMSG.SPELL_START);
			trainer2.Write((ulong)trainerGUID);
			trainer2.Write((ulong)trainerGUID);//trainerGUID);
			trainer2.Write((uint)teachSpellId); //0x1ff7);
//			trainer2.Write((UInt16)0);
			trainer2.Write((ushort)0);
			trainer2.Write((UInt32)0);
			trainer2.Write((short)2);
			trainer2.Write((ulong)client.Character.ObjectId);
			client.Send(trainer2);

			BinWriter trainer3 = LoginClient.NewPacket(SMSG.LEARNED_SPELL);
			trainer3.Write((short)spellId);
			trainer3.Write((UInt16)0x00);
			client.Send(trainer3);

			BinWriter trainer4 = LoginClient.NewPacket(SMSG.SPELL_GO);
			trainer4.Write((ulong)trainerGUID);
			trainer4.Write((ulong)client.Character.ObjectId);//trainerGUID);
			trainer4.Write((uint)teachSpellId);  //0x1ff7);
			//trainer4.Write((UInt32)0);
//			trainer4.Write((UInt16)0);
			trainer4.Write((byte)0);
			trainer4.Write((byte)0x01);
			trainer4.Write((byte)0x01);
			trainer4.Write((ulong)client.Character.ObjectId);
			trainer4.Write((byte)0x00);
			trainer4.Write((short)2);
			trainer4.Write((ulong)client.Character.ObjectId);
			client.Send(trainer4);

			BinWriter trainer5 = LoginClient.NewPacket(SMSG.SPELLLOGEXECUTE);
			trainer5.Write((ulong)trainerGUID);
			trainer5.Write((short)spellId);
			trainer5.Write((UInt16)0);
			trainer5.Write((UInt32)0x1);
			trainer5.Write((UInt32)0x24);
			trainer5.Write((UInt32)0x1);
			trainer5.Write((ulong)client.Character.ObjectId);
			client.Send(trainer5);


			Chat.System(client, "Debug : successfully bought spell!");
			return true;
		}
	}
}
