struct MapRec {
	int ID;
	char* Directory;
	int PVP;
	int IsInMap;
	char* MapName_lang[8];
	int MapName_flag;
};

struct SoundCharacterMacroLinesRec {
	int ID;
	int Category;
	int Sex;
	int Race;
	int SoundID;
};

struct ChrRacesRec {
	int ID;
	int flags;
	int factionID;
	int MaleDisplayId;
	int FemaleDisplayId;
	char* ClientPrefix;
	float MountScale;
	int BaseLanguage;
	int creatureType;
	int LoginEffectSpellID;
	int CombatStunSpellID;
	int ResSicknessSpellID;
	int SplashSoundID;
	int startingTaxiNodes;
	char* clientFileString;
	int cinematicSequenceID;
	char* name_lang[8];
	int name_flag;
};

struct AreaMIDIAmbiencesRec {
	int ID;
	char* DaySequence;
	char* NightSequence;
	char* DLSFile;
	float volume;
};

struct SoundWaterTypeRec {
	int ID;
	int soundType;
	int soundSubtype;
	int SoundID;
};

struct SoundEntriesRec {
	int ID;
	int soundType;
	char* name;
	char* File[10];
	int Freq[10];
	char* DirectoryBase;
	float volumeFloat;
	float pitch;
	float pitchVariation;
	int priority;
	int channel;
	int flags;
	float minDistance;
	float maxDistance;
	float distanceCutoff;
	int EAXDef;
};

struct ZoneMusicRec {
	int ID;
	float VolumeFloat;
	char* MusicFile[2];
	int SilenceIntervalMin[2];
	int SilenceIntervalMax[2];
	int SegmentLength[2];
	int SegmentPlayMin[2];
	int SegmentPlayMax[2];
	int Sounds[2];
};

struct SheatheSoundLookupsRec {
	int ID;
	int classID;
	int subclassID;
	int material;
	int checkMaterial;
	int sheatheSound;
	int unsheatheSound;
};

struct SoundSamplePreferencesRec {
	int ID;
	float EAX1EffectLevel;
	int EAX2SampleDirect;
	int EAX2SampleDirectHF;
	int EAX2SampleRoom;
	int EAX2SampleRoomHF;
	float EAX2SampleObstruction;
	float EAX2SampleObstructionLFRatio;
	float EAX2SampleOcclusion;
	float EAX2SampleOcclusionLFRatio;
	float EAX2SampleOcclusionRoomRatio;
	float EAX2SampleRoomRolloff;
	float EAX2SampleAirAbsorption;
	int EAX2SampleOutsideVolumeHF;
	float EAX3SampleOcclusionDirectRatio;
	float EAX3SampleExclusion;
	float EAX3SampleExclusionLFRatio;
	float EAX3SampleDopplerFactor;
	float Fast2DPredelayTime;
	float Fast2DDamping;
	float Fast2DReverbTime;
};

struct WeaponSwingSounds2Rec {
	int ID;
	int SwingType;
	int Crit;
	int SoundID;
};

struct WeaponImpactSoundsRec {
	int ID;
	int WeaponSubClassID;
	int ParrySoundType;
	int impactSoundID[10];
	int critImpactSoundID[10];
};

struct MaterialRec {
	int materialID;
	int flags;
	int foleySoundID;
};

};

struct SoundProviderPreferencesRec {
	int ID;
	char* Description;
	int Flags;
	int EAXEnvironmentSelection;
	float EAXEffectVolume;
	float EAXDecayTime;
	float EAXDamping;
	float EAX2EnvironmentSize;
	float EAX2EnvironmentDiffusion;
	int EAX2Room;
	int EAX2RoomHF;
	float EAX2DecayHFRatio;
	int EAX2Reflections;
	float EAX2ReflectionsDelay;
	int EAX2Reverb;
	float EAX2ReverbDelay;
	float EAX2RoomRolloff;
	float EAX2AirAbsorption;
	int EAX3RoomLF;
	float EAX3DecayLFRatio;
	float EAX3EchoTime;
	float EAX3EchoDepth;
	float EAX3ModulationTime;
	float EAX3ModulationDepth;
	float EAX3HFReference;
	float EAX3LFReference;
};

struct VocalUISoundsRec {
	int ID;
	int vocalUIEnum;
	int raceID;
	int NormalSoundID[2];
	int PissedSoundID[2];
};

struct SpellRec {
	int ID;
	int school;
	int category;
	int castUI;
	int attributes;
	int attributesEx;
	int shapeshiftMask;
	int targets;
	int targetCreatureType;
	int requiresSpellFocus;
	int casterAuraState;
	int targetAuraState;
	int castingTimeIndex;
	int recoveryTime;
	int categoryRecoveryTime;
	int interruptFlags;
	int auraInterruptFlags;
	int channelInterruptFlags;
	int procFlags;
	int procChance;
	int procCharges;
	int maxLevel;
	int baseLevel;
	int spellLevel;
	int durationIndex;
	int powerType;
	int manaCost;
	int manaCostPerLevel;
	int manaPerSecond;
	int manaPerSecondPerLevel;
	int rangeIndex;
	float speed;
	int modalNextSpell;
	int totem[2];
	int reagent[8];
	int reagentCount[8];
	int equippedItemClass;
	int equippedItemSubclass;
	int effect[3];
	int effectDieSides[3];
	int effectBaseDice[3];
	int effectDicePerLevel[3];
	float effectRealPointsPerLevel[3];
	int effectBasePoints[3];
	int implicitTargetA[3];
	int implicitTargetB[3];
	int effectRadiusIndex[3];
	int effectAura[3];
	int effectAuraPeriod[3];
	float effectAmplitude[3];
	int effectChainTargets[3];
	int effectItemType[3];
	int effectMiscValue[3];
	int effectTriggerSpell[3];
	int spellVisualID;
	int spellIconID;
	int activeIconID;
	int spellPriority;
	char* name_lang[8];
	int name_flag;
	char* nameSubtext_lang[8];
	int nameSubtext_flag;
	char* description_lang[8];
	int description_flag;
	int manaCostPct;
	int startRecoveryCategory;
	int startRecoveryTime;
};

struct ResistancesRec {
	int ID;
	int Flags;
	int FizzleSoundID;
	char* name_lang[8];
	int name_flag;
};

struct ItemDisplayInfoRec {
	int ID;
	char* modelName[2];
	char* modelTexture[2];
	char* inventoryIcon;
	char* groundModel;
	int geosetGroup[4];
	int flags;
	int spellVisualID;
	int groupSoundIndex;
	int itemSize;
	int helmetGeosetVisID;
	char* texture[8];
	int itemVisual;
};

struct TerrainTypeRec {
	int TerrainID;
	char* TerrainDesc;
	int FootstepSprayRun;
	int FootstepSprayWalk;
	int SoundID;
	int Flags;
	int generatedID;
};

struct TerrainTypeSoundsRec {
	int ID;
};

struct ItemGroupSoundsRec {
	int ID;
	int sound[4];
};

struct FootstepTerrainLookupRec {
	int ID;
	int CreatureFootstepID;
	int TerrainSoundID;
	int SoundID;
	int SoundIDSplash;
};

struct ChrClassesRec {
	int ID;
	int PlayerClass;
	int DamageBonusStat;
	int DisplayPower;
	char* petNameToken;
	char* name_lang[8];
	int name_flag;
};

struct AreaTableRec {
	int ID;
	int AreaNumber;
	int ContinentID;
	int ParentAreaNum;
	int AreaBit;
	int flags;
	int SoundProviderPref;
	int SoundProviderPrefUnderwater;
	int MIDIAmbience;
	int MIDIAmbienceUnderwater;
	int ZoneMusic;
	int IntroSound;
	int IntroPriority;
	char* AreaName_lang[8];
	int AreaName_flag;
};

struct CreatureDisplayInfoRec {
	int ID;
	int modelID;
	int soundID;
	int extendedDisplayInfoID;
	float creatureModelScale;
	int creatureModelAlpha;
	char* textureVariation[3];
	int bloodID;
};

struct CreatureModelDataRec {
	int ID;
	int flags;
	char* ModelName;
	int sizeClass;
	float modelScale;
	int bloodID;
	int footprintTextureID;
	float footprintTextureLength;
	float footprintTextureWidth;
	float footprintParticleScale;
	int foleyMaterialID;
	int footstepShakeSize;
	int deathThudShakeSize;
	int soundID;
};

struct CharacterCreateCamerasRec {
	int Race;
	int Sex;
	int Camera;
	float Height;
	float Radius;
	float Target;
	int generatedID;
};

struct FactionGroupRec {
	int ID;
	int maskID;
	char* internalName;
	char* name_lang[8];
	int name_flag;
};

struct FactionTemplateRec {
	int ID;
	int faction;
	int factionGroup;
	int friendGroup;
	int enemyGroup;
	int enemies[4];
	int friends[4];
};

struct CharBaseInfoRec {
	unsigned char raceID;
	unsigned char classID;
	int proficiency;
	int generatedID;
};

struct CharStartOutfitRec {
	int ID;
	unsigned char raceID;
	unsigned char classID;
	unsigned char sexID;
	unsigned char outfitID;
	int ItemID[12];
	int DisplayItemID[12];
	int InventoryType[12];
};

struct ItemVisualEffectsRec {
	int ID;
	char* Model;
};

struct HelmetGeosetVisDataRec {
	int ID;
	int DefaultFlags[32];
	int PreferredFlags[32];
	int HideFlags[32];
};

struct ItemVisualsRec {
	int ID;
	int Slot[5];
};

struct CharVariationsRec {
	int RaceID;
	int SexID;
	int TextureHoldLayer[4];
	int generatedID;
};

struct CharacterFacialHairStylesRec {
	int RaceID;
	int SexID;
	int VariationID;
	int BeardGeoset;
	int MoustacheGeoset;
	int SideburnGeoset;
	int generatedID;
};

struct CharTextureVariationsV2Rec {
	int ID;
	int RaceID;
	int SexID;
	int SectionID;
	int VariationID;
	int ColorID;
	int IsNPC;
	char* TextureName;
};

struct CharHairGeosetsRec {
	int ID;
	int RaceID;
	int SexID;
	int VariationID;
	int GeosetID;
	int Showscalp;
};

struct SpellRadiusRec {
	int ID;
	float radius;
	float radiusPerLevel;
	float radiusMax;
};

struct SpellDurationRec {
	int ID;
	int duration;
	int durationPerLevel;
	int maxDuration;
};

struct SpellRangeRec {
	int ID;
	float rangeMin;
	float rangeMax;
	int flags;
	char* displayName_lang[8];
	int displayName_flag;
	char* displayNameShort_lang[8];
	int displayNameShort_flag;
};

struct PageTextMaterialRec {
	int ID;
	char* name;
};

struct SkillLineRec {
	int ID;
	int raceMask;
	int classMask;
	int excludeRace;
	int excludeClass;
	int categoryID;
	int skillType;
	int minCharLevel;
	int maxRank;
	int abandonable;
	char* displayName_lang[8];
	int displayName_flag;
};

struct ItemClassRec {
	int classID;
	int subclassMapID;
	int flags;
	char* className_lang[8];
	int className_flag;
	int generatedID;
};

struct ItemSubClassRec {
	int classID;
	int subClassID;
	int prerequisiteProficiency;
	int postrequisiteProficiency;
	int flags;
	int displayFlags;
	int weaponParrySeq;
	int weaponReadySeq;
	int weaponAttackSeq;
	int WeaponSwingSize;
	char* displayName_lang[8];
	int displayName_flag;
	char* verboseName_lang[8];
	int verboseName_flag;
	int generatedID;
};

struct SpellFocusObjectRec {
	int ID;
	char* name_lang[8];
	int name_flag;
};

struct BankBagSlotPricesRec {
	int ID;
	int Cost;
};

struct SpellIconRec {
	int ID;
	char* textureFilename;
};

struct FactionRec {
	int ID;
	int reputationIndex;
	int reputationRaceMask[4];
	int reputationClassMask[4];
	int reputationBase[4];
	char* name_lang[8];
	int name_flag;
};

struct ChrProficiencyRec {
	int ID;
	int proficiency_minLevel[16];
	int proficiency_acquireMethod[16];
	int proficiency_itemClass[16];
	int proficiency_itemSubClassMask[16];
};

struct PaperDollItemFrameRec {
	char* ItemButtonName;
	char* SlotIcon;
	int SlotNumber;
	int generatedID;
};

struct SpellShapeshiftFormRec {
	int ID;
	int bonusActionBar;
	char* name_lang[8];
	int name_flag;
	int flags;
};

struct TaxiNodesRec {
	int ID;
	int ContinentID;
	float X;
	float Y;
	float Z;
	char* Name_lang[8];
	int Name_flag;
};

struct QuestSortRec {
	int ID;
	char* SortName_lang[8];
	int SortName_flag;
};

struct QuestInfoRec {
	int ID;
	char* InfoName_lang[8];
	int InfoName_flag;
};

struct SpellCastTimesRec {
	int ID;
	int base;
	int perLevel;
	int minimum;
};

struct SpellItemEnchantmentRec {
	int ID;
	int effect[3];
	int effectPointsMin[3];
	int effectPointsMax[3];
	int effectArg[3];
	char* name_lang[8];
	int name_flag;
	int itemVisual;
};

struct AreaPOIRec {
	int ID;
	int importance;
	int icon;
	int factionID;
	float x;
	float y;
	float z;
	int continentID;
	int flags;
	char* name_lang[8];
	int name_flag;
};

struct WorldMapAreaRec {
	int ID;
	int mapID;
	int areaID;
	int leftBoundary;
	int rightBoundary;
	int topBoundary;
	int bottomBoundary;
	char* areaName;
};

struct WorldMapContinentRec {
	int ID;
	int mapID;
	int leftBoundary;
	int rightBoundary;
	int topBoundary;
	int bottomBoundary;
	float continentOffsetX;
	float continentOffsetY;
};

struct WorldSafeLocsRec {
	int ID;
	int continent;
	float locX;
	float locY;
	float locZ;
	char* AreaName_lang[8];
	int AreaName_flag;
};

struct LanguagesRec {
	int ID;
	char* name_lang[8];
	int name_flag;
};

struct LanguageWordsRec {
	int ID;
	int languageID;
	char* word;
};

struct EmotesTextRec {
	int ID;
	char* name;
	int emoteID;
	int emoteText[16];
};

struct EmotesTextDataRec {
	int ID;
	char* text_lang[8];
	int text_flag;
};

struct CinematicCameraRec {
	int ID;
	char* model;
	int soundID;
	float originX;
	float originY;
	float originZ;
	float originFacing;
};

struct CinematicSequencesRec {
	int ID;
	int soundID;
	int camera[8];
};

struct CameraShakesRec {
	int ID;
	int shakeType;
	int direction;
	float amplitude;
	float frequency;
	float duration;
	float phase;
	float coefficient;
};

struct SpellEffectNamesRec {
	int EnumID;
	char* name_lang[8];
	int name_flag;
	int generatedID;
};

struct SpellAuraNamesRec {
	int EnumID;
	int specialMiscValue;
	char* globalstrings_tag;
	char* name_lang[8];
	int name_flag;
	int generatedID;
};

struct SpellDispelTypeRec {
	int ID;
	char* name_lang[8];
	int name_flag;
};

struct CreatureTypeRec {
	int ID;
	char* name_lang[8];
	int name_flag;
};

struct LockRec {
	int ID;
	int Type[4];
	int Index[4];
	int Skill[4];
	int Action[4];
};

struct LockTypeRec {
	int ID;
	char* name_lang[8];
	int name_flag;
	char* resourceName_lang[8];
	int resourceName_flag;
	char* verb_lang[8];
	int verb_flag;
};

struct WMOAreaTableRec {
	int ID;
	int WMOID;
	int NameSetID;
	int WMOGroupID;
	int DayAmbienceSoundID;
	int NightAmbienceSoundID;
	int SoundProviderPref;
	int SoundProviderPrefUnderwater;
	int MIDIAmbience;
	int MIDIAmbienceUnderwater;
	int ZoneMusic;
	int IntroSound;
	int IntroPriority;
	int Flags;
	char* AreaName_lang[8];
	int AreaName_flag;
};

struct NPCSoundsRec {
	int ID;
	int SoundID[4];
};

struct StringLookupsRec {
	int ID;
	char* String;
};

struct SkillLineAbilityRec {
	int ID;
	int skillLine;
	int spell;
	int raceMask;
	int classMask;
	int excludeRace;
	int excludeClass;
	int minSkillLineRank;
	int supercededBySpell;
	int trivialSkillLineRankHigh;
	int trivialSkillLineRankLow;
	int abandonable;
};

struct SpellChainEffectsRec {
	int ID;
	float AvgSegLen;
	float Width;
	float NoiseScale;
	float TexCoordScale;
	int SegDuration;
	int SegDelay;
	char* Texture;
};

struct GameObjectDisplayInfoRec {
	int ID;
	char* modelName;
	int Sound[10];
};

struct GroundEffectTextureRec {
	int ID;
	int datestamp;
	int continentId;
	int zoneId;
	int textureId;
	char* textureName;
	int doodadId[4];
	int density;
	int sound;
};

struct EmotesRec {
	int ID;
	int EmoteAnimID;
	int EmoteFlags;
	int EmoteSpecProc;
	int EmoteSpecProcParam;
};

struct UnitBloodRec {
	int ID;
	int CombatBloodSpurtFront[2];
	int CombatBloodSpurtBack[2];
	char* GroundBlood[5];
};

struct UISoundLookupsRec {
	int ID;
	int SoundID;
	char* SoundName;
};

struct GroundEffectDoodadRec {
	int ID;
	int doodadIdTag;
	char* doodadpath;
};

struct UnitBloodLevelsRec {
	int ID;
	int Violencelevel[3];
};

struct NamesProfanityRec {
	int ID;
	char* Name;
};

struct NamesReservedRec {
	int ID;
	char* Name;
};

struct AreaTriggerRec {
	int ID;
	int ContinentID;
	float x;
	float y;
	float z;
	float radius;
};

struct EmoteAnimsRec {
	int ID;
	int ProcessedAnimIndex;
	char* AnimName;
};

struct CreatureDisplayInfoExtraRec {
	int ID;
	int DisplayRaceID;
	int DisplaySexID;
	int SkinID;
	int FaceID;
	int HairStyleID;
	int HairColorID;
	int FacialHairID;
	int NPCItemDisplay[10];
	char* BakeName;
};

struct SpellVisualAnimNameRec {
	int AnimID;
	char* name;
	int generatedID;
};

struct CreatureFamilyRec {
	int ID;
	float minScale;
	int minScaleLevel;
	float maxScale;
	int maxScaleLevel;
	int skillLine[2];
};

struct SpellVisualRec {
	int ID;
	int precastKit;
	int castKit;
	int impactKit;
	int stateKit;
	int channelKit;
	int hasMissile;
	int missileModel;
	int missilePathType;
	int missileDestinationAttachment;
	int missileSound;
	int hasAreaEffect;
	int areaModel;
	int areaKit;
	int animEventSoundID;
	unsigned char weaponTrailRed;
	unsigned char weaponTrailGreen;
	unsigned char weaponTrailBlue;
	unsigned char weaponTrailAlpha;
	unsigned char weaponTrailFadeoutRate;
	int weaponTrailDuration;
};

struct SpellVisualPrecastTransitionsRec {
	int ID;
	char* PrecastLoadAnimName;
	char* PrecastHoldAnimName;
};

struct TaxiPathRec {
	int ID;
	int FromTaxiNode;
	int ToTaxiNode;
	int Cost;
};

struct SpellVisualEffectNameRec {
	int ID;
	char* fileName;
	int specialID;
	int specialAttachPoint;
	float areaEffectSize;
	int VisualEffectNameFlags;
};

struct TransportAnimationRec {
	int ID;
	int TransportID;
	int TimeIndex;
	float PosX;
	float PosY;
	float PosZ;
};

struct TabardBackgroundTexturesRec {
	int ID;
	char* TorsoTexture[2];
};

struct FootprintTexturesRec {
	int ID;
	char* FootstepFilename;
};

struct TaxiPathNodeRec {
	int ID;
	int PathID;
	int NodeIndex;
	int ContinentID;
	float LocX;
	float LocY;
	float LocZ;
	int flags;
};

struct CreatureSoundDataRec {
	int ID;
	int soundExertionID;
	int soundExertionCriticalID;
	int soundInjuryID;
	int soundInjuryCriticalID;
	int soundInjuryCrushingBlowID;
	int soundDeathID;
	int soundStunID;
	int soundStandID;
	int soundFootstepID;
	int soundAggroID;
	int soundWingFlapID;
	int soundWingGlideID;
	int soundAlertID;
	int soundFidget[4];
	int customAttack[4];
	int NPCSoundID;
	int loopSoundID;
	int creatureImpactType;
	int soundJumpStartID;
	int soundJumpEndID;
};

struct SpellVisualKitRec {
	int ID;
	int kitType;
	int anim;
	int headEffect;
	int chestEffect;
	int baseEffect;
	int leftHandEffect;
	int rightHandEffect;
	int breathEffect;
	int specialEffect[3];
	int characterProcedure;
	float characterParam[4];
	int soundID;
	int shakeID;
};

struct TabardEmblemTexturesRec {
	int ID;
	char* TorsoTexture[2];
};

struct AttackAnimTypesRec {
	int AnimID;
	char* AnimName;
};

struct DeathThudLookupsRec {
	int ID;
	int SizeClass;
	int TerrainTypeSoundID;
	int SoundEntryID;
	int SoundEntryIDWater;
};

struct SpellEffectCameraShakesRec {
	int ID;
	int CameraShake[3];
};

struct AttackAnimKitsRec {	int ID;
	int ItemSubclassID;
	int AnimTypeID;
	int AnimFrequency;
	int WhichHand;};struct VideoHardwareRec {
	int vendorID;
	int deviceID;
	int farclipIdx;
	int terrainLODDistIdx;
	int terrainShadowLOD;
	int detailDoodadDensityIdx;
	int detailDoodadAlpha;
	int animatingDoodadIdx;
	int trilinear;
	int numLights;
	int specularity;
	int waterLODIdx;
	int particleDensityIdx;
	int unitDrawDistIdx;
	int smallCullDistIdx;
	int resolutionIdx;
	int baseMipLevel;
	int oglPixelShader;
	int d3dPixelShader;
	int generatedID;
};