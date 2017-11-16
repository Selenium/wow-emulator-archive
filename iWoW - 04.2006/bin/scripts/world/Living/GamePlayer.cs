using System;
using WoWDaemon.Database.DataTables;
using WoWDaemon.World;
namespace WorldScripts.Living
{
	public class GamePlayerSaveEvent : WorldEvent
	{
		GamePlayer m_player;
		public GamePlayerSaveEvent(GamePlayer player) : base(TimeSpan.FromMinutes(1.0))
		{
			m_player = player;
		}

		public override void FireEvent()
		{
			m_player.Save();
			Chat.System(m_player, "You have been saved.");
			eventTime = DateTime.Now.Add(TimeSpan.FromMinutes(15.0));
			EventManager.AddEvent(this);
		}

	}
	public class PlayerRegen : WorldEvent
	{
		GamePlayer m_player;
		public PlayerRegen(GamePlayer player) : base(TimeSpan.FromSeconds(3))
		{
			m_player = player;
		}

		public override void FireEvent()
		{
			if(!m_player.Dead && !m_player.RezSickness && (m_player.Health < m_player.MaxHealth || m_player.Power < m_player.MaxPower))
			{
				StatManager.CalculateRegenTick(m_player);
				m_player.UpdateData();
			}
			eventTime = DateTime.Now.Add(TimeSpan.FromSeconds(3));
			EventManager.AddEvent(this);
		}
	}

	/// <summary>
	/// Summary description for GamePlayer.
	/// </summary>
	public class GamePlayer : PlayerObject
	{
		GamePlayerSaveEvent saveEvent;
		PlayerRegen playerregen;


		public GamePlayer(DBCharacter c) : base(c)
		{
			if(base.Health < 0)
			{
				base.Dead = true;
			}
			saveEvent = new GamePlayerSaveEvent(this);
			EventManager.AddEvent(saveEvent);

			playerregen = new PlayerRegen(this);
			EventManager.AddEvent(playerregen);
		}

		public override void SaveAndRemove()
		{
			base.SaveAndRemove ();
			EventManager.RemoveEvent(saveEvent);
			EventManager.RemoveEvent(playerregen);
			inWorld = false;
		}

	}
}
