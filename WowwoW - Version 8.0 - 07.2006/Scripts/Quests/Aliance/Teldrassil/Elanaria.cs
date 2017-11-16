using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
    public class Vorlus_Vilehoof : BaseQuest
	{
    	public Vorlus_Vilehoof()     : base()
    	{
	        id = 1683;
	        npcId = 4088;
	        name = "Vorlus Vilehoof";
	        desc = "Bring the Horn of Vorlus to Elanaria in Darnassus.";
	        details = "The satyr Vorlus Vilehoof has found one of our remote moonwells, southeast of the Ban'ethil Barrow Den. He now splashes within it, defiling its pure waters with his filth. /n/nFind Vorlus at the moonwell and destroy him. Bring me his horn as proof and I will begin your advanced training as a warrior. /n/nThe path to the moonwell is hidden well, $N, but stay focused and alert and you will find it.";
	        questFlags = 0x020;
	        idealLevel = 10;
	        minLevel = 9;
	        zone = 141;
	        rewardXp= 850;
	        finishDialog = "Oh, i see you kill Vurlus.";
	        progressDialog= "Before I can teach you, you must show me your resolve.";
	        previousQuest = 1684;
	        classAllowed=qClasses.Warrior;
			raceAllowed=qRaces.Alliance;
	    }
	    public override void InitObjectives()
	    {
	        deliveryObjectives.Add( 6805, 1 );
	    }
	    public override DialogStatus QuestStatus(Mobile questOwner, Character c)
	    {
	        return BaseNPC.QDS(questOwner, c, this);
    	}
	}

    public class The_Shade_of_Elura : BaseQuest
	{
		public The_Shade_of_Elura() : base()
		{
			id = 1686;
			npcId = 4088;
			name = "The Shade of Elura";
			desc = "Bring 8 loads of Elunite Ore and the Medallion of Elura to Elanaria in Darnassus.";
			details = "You have learned much, $N. Now we will craft you a weapon. A warrior's weapon.$B$B To do this, you must travel to Darkshore.$B$BLong ago a ship crashed upon the rocks near the Auberdine lighthouse, scattering many crates of elunite ore along the ocean floor.$B$BFirst, you must defeat the elunite's guardian, the Shade of Elura. Once the ship's captain, she cursed herself to roam the deeps and protect her shipment for all time. Defeat her, gain her medallion, and gather the crates of lost Elunite.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 1;
			zone = 1657;
			rewardXp = 564;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 6809, 1 );
			deliveryObjectives.Add( 6808, 8 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) { return BaseNPC.QDS( questOwner, c, this ); }
	}

    public class Smith_Mathiel : BaseQuest
	{
		public Smith_Mathiel() : base()
		{
			id = 1692;
			npcId = 4088;
			name = "Smith Mathiel";
			desc = "Bring the Case of Elunite to Smith Mathiel.";
			details = "I have placed the elunite you gathered into a case. Take it to the blacksmith Mathiel, and he will craft for you an elunite weapon.$B$BMathiel is to the south, on the other side of this building.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 8;
			zone = 1657;
			rewardXp = 470;
			previousQuest = 1686;
			npcTargetId = 6142;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 6812, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( new Server.Items.CaseOfElunite(), 1, true );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) { return BaseNPC.QDS( questOwner, c, this ); }
	}
}
