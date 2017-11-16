#!/usr/bin/python
#GameObject converter WoWEmu->Thanatos THD format
#2006-Jan-1
#Updated 2006-Jan-1
import sys
from struct import *

errlog=open("GOCvtErrors.txt","w")

gameobjects={}
data=[]

def warn(goid,msg):
    errlog.write("Warning: GO "+str(goid)+": "+msg+"\n")
def note(goid,msg):
    errlog.write("Note: GO "+str(goid)+": "+msg+"\n")
def load_go_scp(filename):
    f=open(filename)
    lines=f.readlines()
    goid=0
    for line in lines:
        if line.startswith('//'): continue
        if line is "\n":
            goid=0
            continue
        line=line.strip()
        if line.startswith("[gameobj "):
            goid=int(line.split("]")[0][9:]) #Suddenly, comments appear after ]...
            if gameobjects.has_key(goid): warn(goid,"Duplicate!")
            gameobjects[goid]={}
            continue
        if not line.find('=')+1: continue
        if goid:
            spl=line.split('=',1)
            if len(spl)>=2: spl[1]=spl[1].strip()
            if spl[1].find("//")+1:
                spl[1]=spl[1][:spl[1].find("//")]
                spl[1]=spl[1].strip()
            if spl[0] in ["loot"]:
                if not gameobjects[goid].has_key(spl[0]): gameobjects[goid][spl[0]]=[]
                gameobjects[goid][spl[0]].append(spl[1])
            elif not gameobjects[goid].has_key(spl[0]): gameobjects[goid][spl[0]]=spl[1]
    f.close()
    """unsigned long	ObjectID;
	char	Name[64];
	unsigned long	Model;
	unsigned long	Sound0;
	unsigned long	Sound1;
	unsigned long	Sound2;
	unsigned long	Sound3;
	unsigned long	Sound4;
	unsigned long	Sound5;
	unsigned long	Sound6;
	unsigned long	Sound7;
	unsigned long	Sound8;
	unsigned long	Sound9;
	unsigned long	Sound10;
	unsigned long	Faction;
	unsigned long	Flags;
	unsigned long	GType;
	float			Size;
	unsigned long  Level;
	// unsigned long LootTable; // GO LOOTING: TODO"""
def writethd(filename):
    gocount=len(gameobjects)
    f=open(filename,"wb")
    lt=open("gameobjloot.dat","wb")
    keys=gameobjects.keys()
    keys.sort()
    f.write(pack("I",19)) #gotemplate id
    f.write(pack("I",19*4+64)) #sizeof(data)
    maxloots=0
    for goid in keys:
        try:
            out=""
            if not gameobjects[goid]: raise Exception("GO is empty! No data found!")
            out+=pack('II',goid | 0x13000000,0) # id, crc
            out+=pack('I',goid)
            out+=pack('64s',gameobjects[goid].get('name',''))
            out+=pack('I',int(gameobjects[goid]['model'])) #mandatory field
            for i in range(11):
                out+=pack('I',int(gameobjects[goid].get('sound'+str(i),'0')))
            out+=pack('I',int(gameobjects[goid].get('faction','31')))
            flags=0
            if (gameobjects[goid].get('flags','0'))[0] == '0':
                flags=int(gameobjects[goid].get('flags','0'),16)
            else: flags=int(gameobjects[goid].get('flags','0'))
            out+=pack('I',flags)
            out+=pack('I',int(gameobjects[goid].get('gtype','0')))
            out+=pack('I',int(gameobjects[goid].get('type','0')))
            out+=pack('f',float(gameobjects[goid].get('size','1.0')))
            out+=pack('I',0) #level
            loots=gameobjects[goid].get('loot',[])
            if loots:
                maxloots=max(maxloots,len(loots))
                ltout=pack('II',goid | 0x13000000,len(loots))
                for i in loots:ltout+=pack('If',int(i.split()[0]),float(i.split()[1]))
                lt.write(ltout)
            f.write(out)
        except Exception,detail:
            errlog.write("Error: GameObject "+str(goid)+": "+str(detail)+"\n")
            gocount-=1
    f.close()
    note(0,"Max loots = %i"%maxloots)
    
load_go_scp("gameobjects.scp")
writethd("obj19.thd")

errlog.close()
