using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;
namespace LoginScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Test.
	/// </summary>
	[ChatCmdHandler()]
	public class SpellTests
	{
		[ChatCmdAttribute("SpellInfo", "SpellInfo")]
		static bool OnSpellInfo(LoginClient client, string input)
		{
			Chat.System(client, "Known Spells:");
			foreach(DBKnownSpell knownSpell in client.Character.Spells)
			{
				try
				{
					string SpellName=knownSpell.Spell.Name;
					uint Spelllevel=knownSpell.SpellLevel;					
					uint SpellMana=knownSpell.Spell.ManaCost;

					Chat.System(client, "Name:"+SpellName+"  Level:"+Spelllevel +"  Mana:"+SpellMana);
				}
				catch (Exception){}//{Chat.System(client, e.InnerException.Message);}
			}
			Chat.System(client,"End List");
			return true;
		}

		[ChatCmdAttribute("LearnSpell", "LearnSpell <SpellId> <slot> <level>")]
		static bool OnLearnSpell(LoginClient client, string input)
		{
			string[] split = input.Split(' ');
			if (split.Length < 2)
				return false;
			uint targetSpellId=(uint)uint.Parse(split[1]);
			DBSpell targetSpell = (DBSpell)DataServer.Database.FindObjectByKey(typeof(DBSpell), targetSpellId);
			if (targetSpell==null)	{Chat.System(client, "Spell "+targetSpellId+" not found");return true;}
			DBKnownSpell newSpell = new DBKnownSpell();
			newSpell.Spell_Id=targetSpellId;
			if (client.Character.Spells==null||client.Character.Spells.Length==0)
				newSpell.Slot=1;
			else
				newSpell.Slot=(uint)client.Character.Spells.Length+1;

			newSpell.CharacterID=client.Character.ObjectId;
			try
			{
				if (split.Length>2)
					newSpell.SpellLevel=uint.Parse(split[2]);
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
			return true;
		}
	
	}
}
