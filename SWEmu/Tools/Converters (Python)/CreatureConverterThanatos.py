#!/usr/bin/python
#CreatureTemplate converter WoWEmu->Thanatos THD format
#2005-Dec-5
#Updated 2005-Dec-5
import sys
from math import *
from struct import *

errlog=open("CreatureCvtErrors.txt","w")

creatures={}
data=[]
npctypes=[]

def warn(cid,msg):
    errlog.write("Warning: Creature "+str(cid)+": "+msg+"\n")
def note(cid,msg):
    errlog.write("Note: Creature "+str(cid)+": "+msg+"\n")
def load_creatures_scp(filename):
    f=open(filename)
    lines=f.readlines()
    cid=0
    for line in lines:
        if line.startswith('//'): continue
        if line is "\n":
            cid=0
            continue
        line=line.strip()
        if line.startswith("[creature "):
            cid=int(line.split("]")[0][10:]) #Suddenly, comments appear after ]...
            if creatures.has_key(cid): warn(cid,"Duplicate!")
            creatures[cid]={}
            continue
        if not line.find('=')+1: continue
        if cid:
            spl=line.split('=',1)
            spl[0]=spl[0].lower()
            if len(spl)>=2: spl[1]=spl[1].strip()
            if spl[1].find("//")+1:
                spl[1]=spl[1][:spl[1].find("//")]
                spl[1]=spl[1].strip()
            if spl[0] in ["sell","equipmodel","quest","train","loot"]:
                if not creatures[cid].has_key(spl[0]): creatures[cid][spl[0]]=[]
                creatures[cid][spl[0]].append(spl[1])
            elif not creatures[cid].has_key(spl[0]): creatures[cid][spl[0]]=spl[1]
    f.close()
"""
struct CreatureTemplateData
{
	char Name[64];
	char Guild[64];
	CreatureStats NormalStats;
	unsigned long Armor;
	unsigned short DamageMin;
	unsigned short DamageMax;
	float Size;
	float Speed;

	unsigned long Model;
	unsigned long Level;
	unsigned long LootTable;
	unsigned long Elite;
	unsigned long Flags;
	unsigned long Type;
	unsigned long Faction;
	unsigned long Family;
	unsigned long NPCFlags;
	char QuestGiverText[128];
	unsigned long TemplateID;
	unsigned long virtualItemDisplay[3];
	struct CreatureItemInfo virtualItemInfo[3];
	unsigned long Mount;
	float BoundingRadius;
	float CombatReach;

	// -- Stuff not to copy to creatures

	// used for preventing certain creatures from spawning too often. for example,
	// dragons that spawn every 100 hours would have a MinRespawnTime of 60*60*100
	// (seconds per minute)*(minutes per hour)*(number of hours)
	unsigned long MinRespawnTime; // number of seconds between allowed spawns of this creature
	unsigned long MaxLifetime;	  // number of seconds creature is allowed to live for (0=infinite)
	unsigned long LastSpawn; // when our emu stops working in 30 years, call me.
};
"""
def writethd(filename):
    creaturecount=len(creatures)
    f=open(filename,"wb")
    keys=creatures.keys()
    keys.sort()
    f.write(pack("I",8)) #creaturetemplate id
    f.write(pack("I",392)) #sizeof(data)
    for cid in keys:
        try:
            out=""
            if not creatures[cid]: raise Exception("Creature is empty! No data found!")
            out+=pack('II',cid | 0x08000000,0) # id, crc
            #out+=pack('64s','') # codename
            #out+=pack('64s64s64s64s',creatures[cid]['name'],creatures[cid]['name'],creatures[cid]['name'],creatures[cid]['name']) # name 0-3
            out+=pack('64s',creatures[cid]['name'])
            out+=pack('64s',creatures[cid].get('guild',''))
            k=int(creatures[cid].get('maxmana','0'))
            out+=pack('IIIII',int(creatures[cid]['maxhealth']),k,k,k,0)
            out+=pack('HH',int(float(creatures[cid]['damage'].split(' ')[0])),int(float(creatures[cid]['damage'].split(' ')[1])))
            out+=pack('f',float(creatures[cid].get('size','1.0')))
            out+=pack('f',float(creatures[cid].get('speed','1.0')))
            out+=pack('I',int(creatures[cid]['model']))
            a=creatures[cid].get("level","0 0")
            sep=" "
            if ".." in a: sep=".."
            if a=="0 0": warn(cid,"Level not found.")
            if not sep in a: a+=sep+a
            level=sum([int(k) for k in a.split(sep)])/2
            out+=pack('I',level)
            out+=pack('I',cid | 0x0A000000) #loottable
            out+=pack('I',int(creatures[cid].get('npctext','0')))
            out+=pack('I',int(creatures[cid].get('elite','0')))
            out+=pack('I',int(creatures[cid].get('flags','0')))
            out+=pack('I',int(creatures[cid].get('type','7')))
            out+=pack('I',int(creatures[cid].get('faction','0')))
            out+=pack('I',int(creatures[cid].get('family','0')))
            flags=creatures[cid].get('npcflags','0')
            if flags[0]=='0': npcflags=int(flags,16)
            else: npcflags=int(flags)
            if 0:
                if npcflags==1543: npcflags=512
                if npcflags>=3:
                    if npcflags&1: npcflags-=1
                    if npcflags&2: npcflags-=2
                if npcflags&0x40: npcflags-=0x40
            out+=pack('I',npcflags)
            out+=pack('128s',creatures[cid].get('npctext0_0',''))
            out+=pack('I',int(cid))
            if 'equipmodel' in creatures[cid]:
                for ind in range(3):
                    if ind < len(creatures[cid]['equipmodel']):
                        out+=pack('Ibbbbbbbb',*[int(u) for u in creatures[cid]['equipmodel'][ind].split()[1:]])
                    else:
                        out+=pack('III',0,0,0)
            else:
                out+=pack('IIIIIIIII',0,0,0,0,0,0,0,0,0)
            out+=pack('I',int(creatures[cid].get('mount','0')))
            out+=pack('f',float(creatures[cid].get('bounding_radius','0')))
            out+=pack('f',float(creatures[cid].get('combat_reach','0')))
            out+=pack('III',10,0,0) #10 seconds to respawn!
            if len(out)!=400:
                raise Exception("Bad Length: Got %i"%len(out))
            f.write(out)
        except Exception,detail:
            errlog.write("Error: Creature "+str(cid)+": "+str(detail)+"\n")
            creaturecount-=1
    f.close()
    
load_creatures_scp("creatures.scp")
load_creatures_scp("creatures_BHN.scp")
writethd("obj08.thd")
maxsell=0
maxtrain=0
for i in creatures:
    t=creatures[i].get('npcflags','0')
    if t[0]=='0': k=int(t,16)
    else: k=int(t)
    if not k in npctypes: npctypes.append(k)
    maxsell=max(len(creatures[i].get('sell',[])),maxsell)
    maxtrain=max(len(creatures[i].get('train',[])),maxtrain)
errlog.write(str(npctypes))
errlog.close()
