#!/usr/bin/python
#world.save converter WoWEmu -> Thanatos
#2005-Dec-5
#Updated 2005-Dec-25
import sys
from math import *
from struct import *
import random

errlog=open("SpawnCvtErrors.txt","w")

creatures={}
items={}
spawns=[]
data=[]
total=0
totalnpc=0
totalvend=0
npcflagtypes={}
def warn(guid,msg):
    errlog.write("Warning: Object "+str(guid)+": "+msg+"\n")
def note(guid,msg):
    errlog.write("Note: Object "+str(guid)+": "+msg+"\n")
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
            if creatures.has_key(cid): warn(cid,"Duplicate Creature!")
            creatures[cid]={}
            continue
        if not line.find('=')+1: continue
        if cid:
            spl=line.split('=',1)
            if len(spl)>=2: spl[1]=spl[1].strip()
            if spl[1].find("//")+1:
                spl[1]=spl[1][:spl[1].find("//")]
                spl[1]=spl[1].strip()
            if spl[0] in ["sell","equip","equipmodel","quest","train","loot"]:
                if not creatures[cid].has_key(spl[0]): creatures[cid][spl[0]]=[]
                creatures[cid][spl[0]].append(spl[1])
            elif not creatures[cid].has_key(spl[0]): creatures[cid][spl[0]]=spl[1]
    f.close()
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
            if spl[0] in ["bonus",'spell']:
                if not items[iid].has_key(spl[0]): items[iid][spl[0]]=[]
                items[iid][spl[0]].append(spl[1])
            elif not items[iid].has_key(spl[0]): items[iid][spl[0]]=spl[1]
    f.close()
def load_world_save(filename):
    f=open(filename)
    lines=f.readlines()
    cur=False
    for line in lines:
        if line.startswith('//'): continue
        if line == "\n":
            if len(spawns) and not 'SPAWN' in spawns[-1]:
                spawns.pop()
            cur=False
            continue
        line=line.strip()
        if line.startswith("[OBJECT]"):
            spawns.append(dict())
            cur=True
            continue
        if not line.find('=')+1: continue
        if cur:
            spl=line.split('=',1)
            if len(spl)>=2: spl[1]=spl[1].strip()
            if spl[1].find("//")+1:
                spl[1]=spl[1][:spl[1].find("//")]
                spl[1]=spl[1].strip()
            if not spawns[-1].has_key(spl[0]): spawns[-1][spl[0]]=spl[1]
    f.close()
    """	char Name[64];
	char Guild[64];
	unsigned long Continent;
	_Location Loc;
	float Facing;
	unsigned long Model;
	unsigned long Level;
	unsigned long Exp;
	long HitPoints;
	unsigned long DamageMin;
	unsigned long DamageMax;
	float Size;
	unsigned long NPCType;
	unsigned long FactionTemplate;"""
    
    """ unsigned long subtype[16];
	unsigned long minlevel;
	unsigned long maxlevel;
	unsigned long invtype;
	bool checkInvType;"""

def writesav(filename):
    global total,totalnpc,totalvend
    f=open(filename,"wb")
    for sp in spawns:
        try:
            out=""
            if not sp: raise Exception("No data found!")
            cid=int(sp['SPAWN'].split()[0])
            if cid==6491: continue
            cr=creatures[cid]
            #out+=pack('64s',cr['name'])
            #out+=pack('64s',cr.get('guild',''))
            out+=pack('I',int(cid))
            out+=pack('I',int(sp.get('MAP',0))) # WoWEmu does not write '0' fields
            k=sp['XYZ'].split()
            out+=pack('ffff',float(k[0]),float(k[1]),float(k[2]),float(k[3]))
"""
            out+=pack('I',int(cr['model']))
            a=cr.get("level","0 0")
            if a=="0 0": warn(cid,"Level not found.")
            if not " " in a: a+=" "+a
            lev=random.sample(xrange(int(a.split(" ")[0]),int(a.split(" ")[1])+1),1)[0]
            out+=pack('I',lev)
            out+=pack('I',45*lev) #quick fix XP
            out+=pack('I',int(cr['maxhealth']))
            a=cr.get("damage","0 0")
            if a=="0 0": warn(cid,"Damage not found.")
            if not " " in a: a+=" "+a
            out+=pack('II',int(a.split(" ")[0]),int(a.split(" ")[1]))
            out+=pack('f',float(cr.get('size','1.0')))
            flags=cr.get('npcflags','0')
            if flags[0]=='0': npcflags=int(flags,16)
            else: npcflags=int(flags)
            if npcflags==1543: npcflags=512
            if npcflags>=3:
                if npcflags&1: npcflags-=1
                if npcflags&2: npcflags-=2
            if npcflags&0x40: npcflags-=0x40
            npcflagtypes[npcflags]=1
            out+=pack('I',npcflags)
            out+=pack('I',int(cr.get('faction','1')))
            equips=[[0]*9]*3 # Model + 8 fields; 3 equip slots
            k=cr.get('equip',[])
            for item in k:
                p=[int(n) for n in item.split()]
                equips[p[0]][0]=p[1]
            k=cr.get('equipmodel',[])
            for item in k:
                p=[int(n) for n in item.split()]
                equips[p[0]]=p[1:]
            out+=pack('III',equips[0][0],equips[1][0],equips[2][0])
            for i in equips:
                for j in i[1:]:
                    out+=pack('B',j)
            if npcflags:
                if 'sell' in cr:
                    totalvend+=1
                    classes=[0]*16
                    minlvl=9999
                    maxlvl=0
                    for i in cr['sell']:
                        iid=int(i)
                        if not iid in items:
                            warn(sp['GUID'],"Item %i not found."%iid)
                            continue
                        item=items[iid]
                        iclass=item.get('class','0') #default 0
                        sclass=item.get('subclass','0')
                        classes[int(iclass)]|=(1<<int(sclass))
                        lvl=int(item.get('level','0'))
                        if not lvl: lvl=int(item.get('reqlevel','0'))
                        if not lvl: continue
                        minlvl=min(lvl,minlvl)
                        maxlvl=max(lvl,maxlvl)
                    out+=pack('I'*16,*classes)
                    out+=pack('IIII',minlvl,maxlvl,0,0) # no invtype, no checking
                else:
                    out+=pack('I'*16,*([0]*16)) #subtype
                    out+=pack('I'*4,*([0]*4)) # min, max, invtype, check
"""
            totalnpc+=1
            f.write(out)
            total+=1
        except Exception,detail:
            import traceback
            traceback.print_exc(None,errlog)
            #errlog.write("Error: Spawn "+sp['GUID']+": "+str(detail)+"\n")
    f.close()
load_world_save("world.save")
load_creatures_scp("creatures.scp")
#load_creatures_scp("creatures_custom.scp")
load_items_scp("items.scp")
#load_items_scp("items_custom.scp")
writesav("spawns.sav")
errlog.write("Fini! Total: "+str(total)+"; Total NPCs: "+str(totalnpc)+"; Total Vendors: "+str(totalvend))
errlog.close()
p={0:0,1:0,10:0,11:0}
for i in items:
    k=0
    if 'level' in items[i]: k+=10
    if 'reqlevel' in items[i]: k+=1
    p[k]+=1
print p
t=npcflagtypes.keys()
t.sort()
print t
