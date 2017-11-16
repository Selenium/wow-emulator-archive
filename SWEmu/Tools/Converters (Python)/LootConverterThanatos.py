#!/usr/bin/python
#LootTemplate converter WoWEmu->Thanatos THD format
#2005-Dec-5
#Updated 2005-Dec-5
import sys
from struct import *

errlog=open("LootCvtErrors.txt","w")

creatures={}
data=[]

MAXITEMS=432

def warn(cid,msg):
    errlog.write("Warning: LootTemplate "+str(cid)+": "+msg+"\n")
def note(cid,msg):
    errlog.write("Note: LootTemplate "+str(cid)+": "+msg+"\n")
def load_loot_scp(filename):
    f=open(filename)
    lines=f.readlines()
    cid=0
    for line in lines:
        if line.startswith('//'): continue
        if line is "\n":
            cid=0
            continue
        line=line.strip()
        if line.startswith("[loottemplate "):
            cid=int(line.split("]")[0][14:]) #Suddenly, comments appear after ]...
            if creatures.has_key(cid): warn(cid,"Duplicate!")
            creatures[cid]={}
            continue
        if not line.find('=')+1: continue
        if cid:
            spl=line.split('=',1)
            if len(spl)>=2: spl[1]=spl[1].strip()
            if spl[1].find("//")+1:
                spl[1]=spl[1][:spl[1].find("//")]
                spl[1]=spl[1].strip()
            if spl[0] in ["loot"]:
                if not creatures[cid].has_key(spl[0]): creatures[cid][spl[0]]=[]
                elif len(creatures[cid][spl[0]])<MAXITEMS:
                        creatures[cid][spl[0]].append(spl[1])
            elif not creatures[cid].has_key(spl[0]): creatures[cid][spl[0]]=spl[1]
    f.close()
def writethd(filename):
    creaturecount=len(creatures)
    f=open(filename,"wb")
    keys=creatures.keys()
    keys.sort()
    f.write(pack("I",10)) #creaturetemplate id
    f.write(pack("I",4+MAXITEMS*8)) #sizeof(data)
    maxloots=0
    for cid in keys:
        try:
            out=""
            if not creatures[cid]: raise Exception("Loot is empty! No data found!")
            loots=creatures[cid]['loot']
            out+=pack('II',cid | 0x0A000000,0) # id, crc
            out+=pack('I',len(loots))
            for i in loots:
                st=i.split(' ')
                if len(st)==1:
                    st=i.split(',')
                out+=pack('If',int(st[0]),float(st[1]))
            for i in range(MAXITEMS-len(loots)): out+=pack('If',0,0)
            maxloots=max(len(loots),maxloots)
            if len(out)!=3468: raise Exception("Wrong Size: Got %i. Expected 3468"%len(out))
            f.write(out)
        except Exception,detail:
            errlog.write("Error: LootTemplate "+str(cid)+": "+str(detail)+"\n")
            creaturecount-=1
    f.close()
    note(0,"Max loots = %i"%maxloots)
    
load_loot_scp("loottemplates.scp")
writethd("obj10.thd")

errlog.close()
