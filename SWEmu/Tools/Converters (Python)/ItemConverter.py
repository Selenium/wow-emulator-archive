#!/usr/bin/python
#ItemTemplate converter WoWEmu->Thanatos THD format
#2006-Feb-08
#Updated 2006-Feb-08
from struct import *

errlog=open("ItemCvtErrors.txt","w")

items={}

def warn(iid,msg):
    errlog.write("Warning: Item "+str(iid)+": "+msg+"\n")
def note(iid,msg):
    errlog.write("Note: Item "+str(iid)+": "+msg+"\n")
def load_items_scp(filename):
    f=open(filename)
    lines=f.readlines()
    iid=0
    for line in lines:
        if line.startswith('//'): continue
        if line == "\n":
            iid=0
            continue
        line=line.strip()
        if line.startswith("[item "):
            iid=int(line.split("]")[0][6:]) #Suddenly, comments appear after ]...
            if items.has_key(iid): warn(iid,"Duplicate Item!")
            items[iid]={}
            continue
        if not line.find('=')+1: continue
        if iid:
            spl=line.split('=',1)
            if len(spl)>=2: spl[1]=spl[1].strip()
            if spl[1].find("//")+1:
                spl[1]=spl[1][:spl[1].find("//")]
                spl[1]=spl[1].strip()
            if spl[0] in ["bonus",'spell','damage']:
                if not items[iid].has_key(spl[0]): items[iid][spl[0]]=[]
                items[iid][spl[0]].append(spl[1])
            elif not items[iid].has_key(spl[0]): items[iid][spl[0]]=spl[1]
    f.close()
"""
	unsigned long ItemID;
	unsigned long Class;
	unsigned long SubClass;
	
	char Name[64];
	char Name1[64];
	char Name2[64];
	char Name3[64];
	
	unsigned long DisplayID;
	unsigned long OverallQualityID;
	unsigned long Flags;
	unsigned long BuyPrice;// Player buys
	unsigned long SellPrice;// Player sells
	unsigned long InventoryType;
	unsigned long AllowableClass;
	unsigned long AllowableRace;
	unsigned long ItemLevel;

	unsigned long RequiredLevel;
	unsigned long RequiredSkill;
	unsigned long RequiredSkillRank;
	
	unsigned long RequiredSpell;
	unsigned long RequiredPVPRank;
	unsigned long unk1; //always 0?
	unsigned long RequiredFaction;
	unsigned long RequiredFactionLvL;

	unsigned long Stackable;
	unsigned long MaxStack;
	//unsigned long dummy; //Stackable
	unsigned long ContainerSlots;
	
	ItemAttribute Attributes[10];
	DamageStat DamageStats[5];
	
	ResistStat Resistances;

	unsigned long WeaponSpeed;
	unsigned long AmmoType;

	SpellStat SpellStats[5];

	unsigned long Bonding;
	char Description[128];
	unsigned long PageText;
	unsigned long LanguageID;
	unsigned long PageMaterial;
	unsigned long StartQuest;
	unsigned long LockID;
	unsigned long Material;
	unsigned long SheatheType;
	unsigned long Unknown1;
	unsigned long Block;
	//three new fields
	unsigned long SetID;
	unsigned long MaxDurability;
	unsigned long Unknown2;
"""
def writethd(filename):
    itemcount=len(items)
    f=open(filename,"wb")
    keys=items.keys()
    keys.sort()
    f.write(pack("I",7)) #creaturetemplate id
    f.write(pack("I",824)) #sizeof(data)
    for cid in keys:
        try:
            out=""
            if not items[cid]: raise Exception("Item is empty! No data found!")
            out+=pack('II',cid | 0x07000000,0) # id, crc
            out+=pack('I',int(cid))
            out+=pack('I',int(items[cid].get('class',0)))
            out+=pack('I',int(items[cid].get('subclass',0)))
            out+=pack('64s',items[cid]['name'])
            out+=pack('64s',items[cid]['name'])
            out+=pack('64s',items[cid]['name'])
            out+=pack('64s',items[cid]['name'])
            out+=pack('I',int(items[cid]['model']))
            out+=pack('I',int(items[cid].get('quality',0)))
            out+=pack('I',int(items[cid].get('flags',0)))
            out+=pack('I',int(items[cid].get('buyprice',0)))
            out+=pack('I',int(items[cid].get('sellprice',0)))
            out+=pack('I',int(items[cid].get('inventorytype',0)))
            out+=pack('I',int(items[cid].get('classes','0'),16))
            out+=pack('I',int(items[cid].get('races','0'),16))
            out+=pack('I',int(items[cid].get('level',0)))
            out+=pack('I',int(items[cid].get('reqlevel',0)))
            out+=pack('I',int(items[cid].get('skill',0)))
            out+=pack('I',int(items[cid].get('skillrank',0)))
            out+=pack('I',int(items[cid].get('spellreq',0)))
            out+=pack('I',int(items[cid].get('pvprankreq',0)))
            out+=pack('I',0) #unk1 #extra? # "Unique Flag"?
            out+=pack('I',0) #reqfaction
            out+=pack('I',0) #reqfactionlvl
            out+=pack('I',int(items[cid].get('stackable',0)))
            out+=pack('I',int(items[cid].get('maxstack',1)))
            out+=pack('I',int(items[cid].get('containerslots',0)))
            bonuscount=0
            for i in items[cid].get('bonus',[]):
                k=i.split()
                out+=pack('II',int(k[0]),int(k[1]))
                bonuscount+=1
            for i in range(bonuscount,10): out+=pack('II',0,0)
            dmgcount=0
            for i in items[cid].get("damage",[]):
                k=i.split()
                out+=pack('ffI',float(k[0]),float(k[1]),int(k[2]))
                dmgcount+=1
            for i in range(dmgcount,5): out+=pack('ffI',0,0,0)
            out+=pack('I',int(items[cid].get('resistance1',0)))
            out+=pack('I',int(items[cid].get('resistance2',0)))
            out+=pack('I',int(items[cid].get('resistance3',0)))
            out+=pack('I',int(items[cid].get('resistance4',0)))
            out+=pack('I',int(items[cid].get('resistance5',0)))
            out+=pack('I',int(items[cid].get('resistance6',0)))
            out+=pack('I',int(items[cid].get('resistance7',0)))
            out+=pack('I',int(items[cid].get('delay',0)))
            out+=pack('I',int(items[cid].get('ammotype',0)))
            spellcount=0
            for i in items[cid].get("spell",[]):
                k=i.split()
                out+=pack('IIIIII',*[int(s) for s in k])
                spellcount+=1
            for i in range(spellcount,5): out+=pack('IIIIII',0,0,0,0,0,0)
            out+=pack('I',int(items[cid].get('bonding',0)))
            out+=pack('128s',items[cid].get('description',''))
            out+=pack('I',int(items[cid].get('pagetext',0)))
            out+=pack('I',int(items[cid].get('language',0)))
            out+=pack('I',int(items[cid].get('pagematerial',0)))
            out+=pack('I',int(items[cid].get('questid',0)))
            out+=pack('I',int(items[cid].get('lockid',0)))
            out+=pack('I',int(items[cid].get('material',0)))
            out+=pack('I',int(items[cid].get('sheath',0)))
            out+=pack('I',int(items[cid].get('extra',0))) # extra?
            out+=pack('I',int(items[cid].get('block',0)))
            out+=pack('I',int(items[cid].get('set',0)))
            out+=pack('I',int(items[cid].get('durability',0)))
            out+=pack('I',int(items[cid].get('unk2',0))) # extra? # "Page ID"?
            f.write(out)
        except Exception,detail:
            errlog.write("Error: Creature "+str(cid)+": "+str(detail)+"\n")
            itemcount-=1
    f.close()
    
load_items_scp("items.scp")
writethd("obj07.thd")
errlog.close()
