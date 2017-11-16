using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace WowDaemon.Guild
{ 
	public class GuildManager
	{
		
		[ChatCmdHandler()] 
		public class GuildCommands
		{ 

			[ChatCmdAttribute("gcreate", "gcreate <Guildname>")] 
			static bool OnGuildCreate(LoginClient client, string input) 
			{
				string[] split=input.Split(' ');
				if (split.Length<2) {return false;}
				string newName = split[1];
				DataObject[] objt = DataServer.Database.SelectObjects(typeof(DBGuild), "Name = '"+newName+"'");
				if (objt.Length != 0) {SendResult(client, 0, newName, (int)GUILDRESULT.NAME_EXISTS);return true;}
				DBGuild newGuild = new DBGuild();
				newGuild.Name = newName ;
				newGuild.Leader = client.Character.ObjectId;
				newGuild.CreationDate=DateTime.Now;
				newGuild.MOTD = "Welcome to "+newName;
				DataServer.Database.AddNewObject(newGuild);
				DataServer.Database.SaveObject(newGuild);
				DataServer.Database.ReloadObject(newGuild);
				bool success=AddMember(client, newGuild, 0);
				SendResult(client, 0, newName, (int)GUILDRESULT.SUCCESS);
				return true;
			}//OnGuildCreate


			[ChatCmdAttribute("givetabard", "givetabard <membername>")] 
			static bool OnGiveTabard(LoginClient client, string input) 
			{
				if (client.Character.GuildID==0||client.Character.GuildRank>1)
				{
					Chat.System(client, "Only a guild leader or first officer may give out tabards");
					return true;
				}
				if (client.Character.Guild.Color==0xFFFFFFFF)
				{
					Chat.System(client, "You must first purchase a tabard from a tabard vendor before you can give them out");
					return true;
				}
				string[] split=input.Split(' ');
				if (split.Length<2) {return false;}
				DBCharacter targetmember = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), split[1]);
				if (targetmember == null) {Chat.System(client, "Player not found");return true;}

				if (targetmember.GuildID != client.Character.GuildID)
				{
					Chat.System(client, "That player is not a member of your guild");
					return true;
				}

				DBItem newItem = new DBItem();
				newItem.OwnerID = targetmember.ObjectId;
				newItem.OwnerSlot = 18; 
				newItem.TemplateID = 343;
				DataServer.Database.AddNewObject(newItem);
				DataServer.Database.FillObjectRelations(newItem);
				client.WorldConnection.Send(newItem);

				ScriptPacket Item = new ScriptPacket(SCRMSG.BUYITEM);

				Item.Write(targetmember.ObjectId);
				Item.Write(newItem.ObjectId);
				Item.Write((int)0);
				client.WorldConnection.Send(Item);
				return true;
			}


			[ChatCmdAttribute("gtest", "gtest <code1> <code2>")] 
			static bool OnGuildTest(LoginClient client, string input) 
			{
				string[] split=input.Split(' ');
				SendResult(client, int.Parse(split[1]), "TestString", int.Parse(split[2]));
				return true;
			}//OnGuildTest


			[ChatCmdAttribute("clearinvite", "cleainv")] 
			static bool OnClearInvite(LoginClient client, string input) 
			{
				client.Character.LastGuildInviterID=0;				
				return true;
			}//OnClearInvite


			[ChatCmdAttribute("tabclear", "tabclear")] 
			static bool OnTabClear(LoginClient client, string input) 
			{
				DBGuild guild = client.Character.Guild;
				if (guild==null||client.Character.GuildRank!=0)
				{
					Chat.System(client, "You must be a guild leader to use this command");
				}
				guild.Border=0xFFFFFFFF;
				guild.BorderColor=0xFFFFFFFF;;
				guild.Color=0xFFFFFFFF;;
				guild.Icon=0xFFFFFFFF;;
				guild.IconColor=0xFFFFFFFF;;
				DataServer.Database.SaveObject(guild);
				return true;
			}//OnTabClear
			
		} 

		[LoginPacketHandler()]
		public class GuildPackets
		{

			[LoginPacketDelegate(CMSG.GUILD_INVITE)]
			static bool OnGuildInvite(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild guild = client.Character.Guild;
				if (guild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}

				if ((guild.getRankFlags(client.Character.GuildRank) & (uint)GUILDFLAGS.INVITE)!=(uint)GUILDFLAGS.INVITE) 
				{
					SendResult(client, 1, " ", (int)GUILDRESULT.PERMISSIONS);
					;return true;
				}

				string name = data.ReadString();

				DBCharacter character = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name.ToLower());
				if(character == null)
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_FOUND);

				else
				{
					LoginClient targetClient=LoginServer.GetLoginClientByCharacterID(character.ObjectId);
					if (targetClient!=null)
					{
//						targetClient.Character.LastGuildID=client.Character.GuildID;
						if (targetClient.Character.LastGuildInviterID!=0)
						{
							SendResult(client, 1, name, (int)GUILDRESULT.ALREADY_INVITED_TO_GUILD_S);
							return true;
						}

						if (targetClient.Character.GuildID!=0)
						{
							SendResult(client, 1, targetClient.Character.Name, (int)GUILDRESULT.ALREADY_IN_GUILD_S);
							return true;
						}

						targetClient.Character.LastGuildInviterID=client.Character.ObjectId;

						BinWriter gpkg = LoginClient.NewPacket(SMSG.GUILD_INVITE); 
						gpkg.Write(client.Character.Name);
						gpkg.Write(guild.Name);
						targetClient.Send(gpkg);
						SendResult(client, 1, name, (int)GUILDRESULT.SUCCESS);
					}
					else {Chat.System(client, name+" is not currently online");}
				}
			
				return true; 
			}//OnGuildInvite


			[LoginPacketDelegate(CMSG.GUILD_QUERY)]
			static bool OnGuildQuery(LoginClient client, CMSG msgID, BinReader data)
			{
				uint guildId = data.ReadUInt32();
				BinWriter pkg = LoginClient.NewPacket(SMSG.GUILD_QUERY_RESPONSE);
				Chat.System(client, "Guild Query");
				DBGuild guild = (DBGuild)DataServer.Database.FindObjectByKey(typeof(DBGuild), guildId);
				if (guild == null)
				{
					return true;
 				}
				else
				{
					pkg.Write(guild.ObjectId);
					pkg.Write(guild.Name);
					for(uint i=0;i<10;i++)
						pkg.Write(guild.getRankName(i));
					pkg.Write((uint)guild.Icon);
					pkg.Write((uint)guild.IconColor);
					pkg.Write((uint)guild.Border);
					pkg.Write((uint)guild.BorderColor);
					pkg.Write((uint)guild.Color);
				}
				client.Send(pkg);
				return true;
			}//OnGuildQuery

		
			[LoginPacketDelegate(CMSG.GUILD_ACCEPT)]
			static bool OnGuildAccept(LoginClient client, CMSG msgID, BinReader data) 
			{ 
				LoginClient inviter=LoginServer.GetLoginClientByCharacterID(client.Character.LastGuildInviterID);
				client.Character.LastGuildInviterID=0;				
				if (inviter==null)
					return true;
				DBGuild guild = (DBGuild)DataServer.Database.FindObjectByKey(typeof(DBGuild), inviter.Character.GuildID);
				AddMember(client, guild, guild.MaxRank);
				Chat.GuildSay(0, client, "You have joined "+guild.Name, CHATMESSAGETYPE.GUILD);
				//Chat.System(inviter, client.Character.Name+" joins "+guild.Name);
				GuildMessage(guild, client.Character.Name+" has been accepted to the guild by"+inviter.Character.Name);

				return true; 
			}//OnGuildAccept


			[LoginPacketDelegate(CMSG.GUILD_DECLINE)]
			static bool OnGuildDecline(LoginClient client, CMSG msgID, BinReader data) 
			{ 
				LoginClient inviter=LoginServer.GetLoginClientByCharacterID(client.Character.LastGuildInviterID);
				client.Character.LastGuildInviterID=0;

				BinWriter pkg = LoginClient.NewPacket(SMSG.GUILD_DECLINE);
				pkg.Write(client.Character.Name);
				inviter.Send(pkg);

//				Chat.GuildSay(0, inviter, client.Character.Name+" has declined your offer to join "+client.Character.GuildName, CHATMESSAGETYPE.GUILD);
				return true; 
			}//OnGuildDecline


			[LoginPacketDelegate(CMSG.GUILD_PROMOTE)]
			static bool OnGuildPromote(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild guild = client.Character.Guild;
				if (guild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}

				if ((guild.getRankFlags(client.Character.GuildRank) & (uint)GUILDFLAGS.PROMOTE)!=(uint)GUILDFLAGS.PROMOTE) 
				{
					SendResult(client, 1, " ", (int)GUILDRESULT.PERMISSIONS);
					;return true;
				}

				string name = data.ReadString();

				DBCharacter tChar = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name.ToLower());
				if(tChar == null)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_FOUND);
					return true;
				}

				else if (client.Character.GuildID!=tChar.GuildID)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_IN_GUILD_S);
					return true;
				}

				if (tChar.GuildRank<=client.Character.GuildRank+1)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.RANK_TO_HIGH);
					return true;
				}

				DBGuildMembers tMember= (DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuildMembers), tChar.ObjectId);
				if (tMember!=null)
				tChar.GuildRank--;
				tMember.Rank--;
				SendToWorld(client, tChar);
				GuildMessage(guild, tChar.Name+"has been promoted to the rank of "+guild.getRankName(tChar.GuildRank)+" by "+client.Character.Name);
				SendRoster(client, guild);
				return true;

			}//OnGuildPromote


			[LoginPacketDelegate(CMSG.GUILD_DEMOTE)]
			static bool OnGuildDemote(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild guild = client.Character.Guild;
				if (guild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}

				if ((guild.getRankFlags(client.Character.GuildRank) & (uint)GUILDFLAGS.DEMOTE)!=(uint)GUILDFLAGS.DEMOTE) 
				{
					SendResult(client, 1, " ", (int)GUILDRESULT.PERMISSIONS);
					;return true;
				}

				string name = data.ReadString();

				DBCharacter tChar = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name.ToLower());
				if(tChar == null)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_FOUND);
					return true;
				}

				else if (client.Character.GuildID!=tChar.GuildID)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_IN_GUILD_S);
					return true;
				}
				//		2					1
				if (tChar.GuildRank<=client.Character.GuildRank)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.RANK_TO_HIGH);
					return true;
				}
				else if(tChar.GuildRank>=guild.MaxRank)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.RANK_TO_LOW);
					return true;
				}

				DBGuildMembers tMember= (DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuildMembers), tChar.ObjectId);
				if (tMember!=null)
					tChar.GuildRank++;
				tMember.Rank++;
				SendToWorld(client, tChar);
				GuildMessage(guild, tChar.Name+"has been demoted to the rank of "+guild.getRankName(tChar.GuildRank)+" by "+client.Character.Name);
				SendRoster(client, guild);
				return true;


			}//OnGuildDemote
		

			[LoginPacketDelegate(CMSG.GUILD_LEADER)]
			static bool OnGuildLeader(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild guild = client.Character.Guild;
				if (guild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}

				if (client.Character.GuildRank !=0) 
				{
					SendResult(client, 1, " ", (int)GUILDRESULT.PERMISSIONS);
					;return true;
				}

				string name = data.ReadString();

				DBCharacter tChar = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name.ToLower());
				if(tChar == null)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_FOUND);
					return true;
				}

				else if (client.Character.GuildID!=tChar.GuildID)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_IN_GUILD_S);
					return true;
				}

				DBGuildMembers tMember= (DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuildMembers), tChar.ObjectId);
				if (tMember==null)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.INTERNAL);
					return true;
				}

				tChar.GuildRank=0;
				tMember.Rank=0;
				guild.Leader=tChar.ObjectId;	
				client.Character.GuildRank=1;
				DBGuildMembers oldLeader= (DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuildMembers), client.Character.ObjectId);
				if (oldLeader==null)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.INTERNAL);
					return true;
				}
				oldLeader.Rank=1;

				SendToWorld(client, tChar);
				SendToWorld(client, client.Character);

				GuildMessage(guild, tChar.Name+" has been promoted to the rank of "+guild.getRankName(tChar.GuildRank)+" by "+client.Character.Name);
				SendRoster(client, guild);
				return true;

			}//OnGuildLeader

			
			[LoginPacketDelegate(CMSG.GUILD_RANK)]
			static bool OnGuildRank(LoginClient client, CMSG msgID, BinReader data) 
			{
				uint rank=data.ReadUInt32();
				uint rankflags=data.ReadUInt32();
				string rankname=data.ReadString();
				DBGuild guild = client.Character.Guild;
				guild.setRankName(rank, rankname);
				guild.setRankFlags(rank, rankflags);
				DataServer.Database.SaveObject(guild);
				UpdateGuild(client);
				SendRoster(client, guild);
				return true; 
			
			}//OnGuildRank


			[LoginPacketDelegate(CMSG.GUILD_ADD_RANK)]
			static bool OnGuildAddRank(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild tguild = client.Character.Guild;
				if (tguild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}
				tguild.MaxRank++;
				tguild.setRankName(tguild.MaxRank, data.ReadString());
				DataServer.Database.SaveObject(tguild);
				UpdateGuild(client);
				SendRoster(client, tguild);
				return true;
			} //OnGuildAddRank


			[LoginPacketDelegate(CMSG.GUILD_DEL_RANK)]
			static bool OnGuildDelRank(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild tguild = client.Character.Guild;
				if (tguild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}
				bool inuse=false;
				foreach (DBGuildMembers member in tguild.Members)
					if (member.Rank==tguild.MaxRank)
						inuse=true;
				if (inuse)
				{
					SendResult(client, 3, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}

				tguild.setRankName(tguild.MaxRank, "Unused");
				tguild.MaxRank--;
				DataServer.Database.SaveObject(tguild);
				UpdateGuild(client);
				SendRoster(client, tguild);
				return true;
			} //OnGuildDelRank


			[LoginPacketDelegate(CMSG.GUILD_MOTD)]
			static bool OnGuildMOTD(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild tguild = client.Character.Guild;
				if ((tguild.getRankFlags(client.Character.GuildRank) & (uint)GUILDFLAGS.SET_MOTD)!=(uint)GUILDFLAGS.SET_MOTD) 
				{
					SendResult(client, 1, " ", (int)GUILDRESULT.PERMISSIONS);
					;return true;
				}

				tguild.MOTD= data.ReadString();
				DataServer.Database.SaveObject(tguild);
				SendRoster(client, tguild);
				GuildMessage(tguild, "MOTD: "+tguild.MOTD);
				return true;
			} //OnGuildRoster


			[LoginPacketDelegate(CMSG.GUILD_INFO)]
			static bool OnGuildInfo(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild tguild = client.Character.Guild;
				tguild.GuildInfo= data.ReadString();
				DataServer.Database.SaveObject(tguild);
				BinWriter gpkg = LoginClient.NewPacket(SMSG.GUILD_INFO);
				gpkg.Write(tguild.ObjectId);
				gpkg.Write(tguild.GuildInfo);
//				gpkg.Write(rankname);
				client.Send(gpkg);

				return true;
			} //OnGuildRoster


			[LoginPacketDelegate(CMSG.GUILD_SET_PUBLIC_NOTE)]
			static bool OnGuildSetNote(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild tguild = client.Character.Guild;
				if (tguild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}

				DBCharacter tChar= (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), data.ReadString());
				if (tChar==null)
					return true;
				DBGuildMembers tMember = (DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuildMembers), tChar.ObjectId );
				if (tMember==null)
				{	Chat.System(client, "No member found for "+tChar.Name);
					return true;}
				tMember.Note= data.ReadString();
				DataServer.Database.SaveObject(tMember);

				SendRoster(client, tguild);
				return true;
			} //OnGuildSetNote


			[LoginPacketDelegate(CMSG.GUILD_SET_OFFICER_NOTE)]
			static bool OnGuildSetONote(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild tguild = client.Character.Guild;
				if (tguild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}
				DBCharacter tChar= (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), data.ReadString());
				if (tChar==null)
					return true;
				DBGuildMembers tMember = (DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuildMembers), tChar.ObjectId );
				if (tMember==null)
				{
					Chat.System(client, "No member found for "+tChar.Name);
					return true;}
				tMember.OfficerNote= data.ReadString();
				DataServer.Database.SaveObject(tMember);
				SendRoster(client, tguild);
				return true;
			} //OnGuildRoster


			[LoginPacketDelegate(CMSG.GUILD_DISBAND)]
			static bool OnGuildDisband(LoginClient client, CMSG msgID, BinReader data) 
			{
				if (client.Character.GuildRank!=0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.PERMISSIONS);
					return true;
				}

				DBGuild tguild = client.Character.Guild;
				if (tguild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}
				GuildMessage(tguild, "You guild has been disbanded by "+client.Character.Name);
				foreach(DBGuildMembers member in tguild.Members)
				{
					RemoveMember(member, client);

				}
				Chat.System(client, "You have disbanded "+tguild.Name); 
				DataServer.Database.DeleteObject(tguild);
				return true;

			}//OnGuildDisband


			[LoginPacketDelegate(CMSG.GUILD_LEAVE)]
			static bool OnGuildLeave(LoginClient client, CMSG msgID, BinReader data) 
			{
				if (client.Character.GuildRank==0)
				{
					Chat.GuildSay(0, client, "You must appoint a new guild leader using /gleader before you can leave", CHATMESSAGETYPE.GUILD);
					//SendResult(client, 3, " ", (int)GUILDRESULT.PERMISSIONS);  //Didnt like this message
					return true;
				}
		
				DBGuildMembers member = (DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuildMembers), client.Character.ObjectId);
				if (member==null)
				{
					client.Character.GuildID=0;		//To correct if Character DB still has Guild info when 
					client.Character.GuildRank=0;	//there is not a member record.  Shouldnt happen but...
					client.Character.GuildName=" ";
					SendToWorld(client, client.Character);
				}
				else
					RemoveMember(member, client);
				return true;
			}//OnGuildLeave


			[LoginPacketDelegate(CMSG.GUILD_REMOVE)]
			static bool OnGuildRemove(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild guild = client.Character.Guild;
				if (guild==null||client.Character.GuildID==0)
				{
					SendResult(client, 2, " ", (int)GUILDRESULT.NOT_IN_GUILD);
					return true;
				}

				if ((guild.getRankFlags(client.Character.GuildRank) & (uint)GUILDFLAGS.DEMOTE)!=(uint)GUILDFLAGS.DEMOTE) 
				{
					SendResult(client, 1, " ", (int)GUILDRESULT.PERMISSIONS);
					;return true;
				}

				string name = data.ReadString();

				DBCharacter tChar = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name.ToLower());
				if(tChar == null)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_FOUND);
					return true;
				}

				else if (client.Character.GuildID!=tChar.GuildID)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_IN_GUILD_S);
					return true;
				}
				//		2					1
				if (tChar.GuildRank<=client.Character.GuildRank)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.RANK_TO_HIGH);
					return true;
				}

				DBGuildMembers member = (DBGuildMembers)DataServer.Database.FindObjectByKey(typeof(DBGuildMembers), tChar.ObjectId);
				if (member==null||member.GuildID!=client.Character.GuildID)
				{
					SendResult(client, 1, name, (int)GUILDRESULT.NOT_IN_GUILD_S);
					return true;
				}
				if (RemoveMember(member, client))
				{	
					Chat.System(client, "You have removed "+tChar.Name+" from the guild");
				}
				else
				{	
					SendResult(client, 1, name, (int)GUILDRESULT.INTERNAL);
				}					
				return true;

			}//OnGuildRemove


			[LoginPacketDelegate(CMSG.GUILD_ROSTER)]
			static bool OnGuildRoster(LoginClient client, CMSG msgID, BinReader data) 
			{
				SendRoster(client, client.Character.Guild);
				return true;
			} //OnGuildRoster


			[LoginPacketDelegate(CMSG.SAVE_GUILD_EMBLEM)]
			static bool OnGuildTabard(LoginClient client, CMSG msgID, BinReader data) 
			{
				DBGuild tguild = client.Character.Guild;
				ulong vGUID=data.ReadUInt64();
				tguild.Icon=data.ReadUInt32();
				tguild.IconColor=data.ReadUInt32();
				tguild.Border=data.ReadUInt32();
				tguild.BorderColor=data.ReadUInt32();
				tguild.Color=data.ReadUInt32();
				DataServer.Database.SaveObject(tguild);
				SendToWorld(client, client.Character);
				DBItem newItem = new DBItem();
				newItem.OwnerID = client.Character.ObjectId;
				newItem.OwnerSlot = 18; 
				newItem.TemplateID = 343;
				DataServer.Database.AddNewObject(newItem);
				DataServer.Database.FillObjectRelations(newItem);
				client.WorldConnection.Send(newItem);

				ScriptPacket Item = new ScriptPacket(SCRMSG.BUYITEM);

				Item.Write(client.Character.ObjectId);
				Item.Write(newItem.ObjectId);
				Item.Write((int)100000);
				client.WorldConnection.Send(Item);

				BinWriter tpkg = LoginClient.NewPacket(SMSG.TABARDVENDOR_ACTIVATE);
				tpkg.Write(client.Character.Selected);
				client.Send(tpkg);

				string gmsg = "Congratulations on your purchase, You may now give them to your members using !givetabard <member>";
				Chat.GuildSay(0, client, gmsg, CHATMESSAGETYPE.GUILD);


				return true;

			} //OnGuildTabard


			[LoginPacketDelegate(CMSG.TABARDVENDOR_ACTIVATE)]
			static bool OnTabardVendor(LoginClient client, CMSG msgID, BinReader data) 
			{
				BinWriter TestPacket = LoginClient.NewPacket(SMSG.TABARDVENDOR_ACTIVATE);
				TestPacket.Write(client.Character.Selected);
				client.Send(TestPacket);
				return true;
			}//OnTabardVendor


		} //GuildPackets

		public static bool RemoveMember(DBGuildMembers tMember, LoginClient client)
		{
			DBCharacter tChar;
			LoginClient tClient=null;
			DBGuild oldGuild = client.Character.Guild;

			if (tMember==null) {Chat.System(client, "tMember was null");return false;}
			if (tMember.MemberID!=client.Character.ObjectId)
				tClient=LoginServer.GetLoginClientByCharacterID(tMember.MemberID);
			else
				tClient=client;

			if (tClient!=null)
			{
				tChar=tClient.Character;
				if (client.Character.ObjectId==tMember.MemberID)
				{
					Chat.System(tClient, "You have left "+oldGuild.Name);
					GuildMessage(oldGuild, client.Character.Name+" has left the guild");
				}
				else
				{
					Chat.System(tClient, "You have been removed from "+oldGuild.Name+" by "+client.Character.Name);
					GuildMessage(oldGuild, tClient.Character.Name+" has removed from the guild by "+client.Character.Name);
				}
				//SendToWorld(client, tChar);				
				ScriptPacket scrpkg = new ScriptPacket(SCRMSG.GUILDUPDATE);
				scrpkg.Write(tClient.Character.ObjectId);
				scrpkg.Write(0);
				scrpkg.Write(0);
				client.WorldConnection.Send(scrpkg);
				
			}
			else 
			{
				tChar=(DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), tMember.MemberID);
				if (tChar==null)
				{
					Console.WriteLine("Character not found when removing member from guild");
					return false;
				}
			}

			tChar.GuildID=0;
			tChar.GuildRank=0;
			tChar.GuildName=" ";
			tChar.Guild=null;
			DataServer.Database.SaveObject(tChar);

			if (tMember==null) {return false;}
			
			DataServer.Database.DeleteObject(tMember);
			DataServer.Database.FillObjectRelations(oldGuild);
			
			return true;
		} //RemoveMember
		
		
		public static bool AddMember(LoginClient client, DBGuild newGuild, uint Rank)
		{
			client.Character.GuildID=newGuild.ObjectId;
			client.Character.GuildRank=Rank;
			client.Character.GuildName=newGuild.Name;
			client.Character.Guild=newGuild;
			DataServer.Database.SaveObject(client.Character);

			SendToWorld(client, client.Character);

			DBGuildMembers newMember= new DBGuildMembers();

			newMember.GuildID=newGuild.ObjectId;
			newMember.MemberID=client.Character.ObjectId;
			newMember.Rank=(uint)Rank;
			DataServer.Database.AddNewObject(newMember);
			DataServer.Database.SaveObject(newMember);
			DataServer.Database.FillObjectRelations(newMember);
			DataServer.Database.FillObjectRelations(newGuild);
		
			return true;
		}//AddMember
		

		public static void SendResult(LoginClient client, int operation, string sparam, int result)
		{
			BinWriter w = LoginClient.NewPacket(SMSG.GUILD_COMMAND_RESULT);
			w.Write(operation);
			w.Write(sparam);
			w.Write(result);
			client.Send(w);
			return;
		}//SendResult


		public static void UpdateGuild(LoginClient client)
		{
			foreach (DBGuildMembers member in client.Character.Guild.Members)
				SendToWorld(client, member.Character);
		}


		public static void SendToWorld(LoginClient client, DBCharacter tChar)
		{
			ScriptPacket scrpkg = new ScriptPacket(SCRMSG.GUILDUPDATE);
			scrpkg.Write(tChar.ObjectId);
			scrpkg.Write(tChar.GuildID);
			scrpkg.Write(tChar.GuildRank);
			client.WorldConnection.Send(scrpkg);
			return;
		}


		public static void GuildMessage(DBGuild guild, string msg)
		{
			foreach(DBGuildMembers member in guild.Members)
			{
				LoginClient targetClient = LoginServer.GetLoginClientByCharacterID(member.MemberID);
				if(targetClient == null || targetClient.Character == null)
					{
						continue;
					}
					else
						Chat.GuildSay(0, targetClient, msg, CHATMESSAGETYPE.GUILD);
			}
		}


		public static void SendRoster(LoginClient client, DBGuild tGuild)
		{

			BinWriter pkg = LoginClient.NewPacket(SMSG.GUILD_ROSTER);
			pkg.Write((int)tGuild.Members.Length);
			pkg.Write((string)tGuild.MOTD);				//Guild.MOTD);
			pkg.Write((uint)tGuild.MaxRank+1);			//# of ranks
			for (uint i=0;i<tGuild.MaxRank+1;i++)
				pkg.Write((uint)tGuild.getRankFlags(i));	//Rank Flags for each rank
			foreach (DBGuildMembers member in tGuild.Members)
			{
				DataServer.Database.FillObjectRelations(member);
				pkg.Write((ulong)member.MemberID);//((LoginClient)e.Current).Character.Race);
				bool online=false;
				if (LoginServer.GetLoginClientByCharacterID(member.MemberID)!=null)
					online=true;
				pkg.Write((bool)online);//Online? 0-no/1-yes
				pkg.Write((string)member.Character.Name);	//Name
				pkg.Write((int)member.Character.GuildRank);	//Rank
				pkg.Write((byte)member.Character.Level);	//Level
				pkg.Write((byte)member.Character.Class);	//Class((LoginClient)e.Current).Character.Level);
				pkg.Write((uint)member.Character.Zone);		//Zone
				if (online)
					pkg.Write((byte)member.Character.GroupLook);	// Group (0-No/1-Yes) Only if online
				else
					pkg.Write((uint)member.Character.GuildTimeStamp);	// GuildTimeStamp

				pkg.Write((string)(member.Note==null?" ":member.Note));		//Player Note
				pkg.Write((string)(member.Note==null?" ":member.OfficerNote));	//Officer's Note
			}
			client.Send(pkg);
			return; 
		}//SendRoster
	
	}//GuildManager 
}//Namespace
