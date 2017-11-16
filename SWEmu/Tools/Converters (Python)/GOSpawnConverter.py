#!/usr/bin/python
#world.save GameObject converter WoWEmu -> Thanatos
#2006-Jan-31

import sys
from struct import *

errlog=open("GOSpawnCvtErrors.txt","w")

spawns={}
total=0
def warn(guid,msg):
    errlog.write("Warning: Object "+str(guid)+": "+msg+"\n")
def note(guid,msg):
    errlog.write("Note: Object "+str(guid)+": "+msg+"\n")
def load_world_save(filename):
    """Loads a world.save.

Loads by GUID, i.e. spawns will hold the text GUIDs at the end of this."""
    f=open(filename)
    lines=f.readlines()
    cur=''
    progress=0
    total=len(lines)/100
    totalchk=len(lines)//100
    for line in lines:
        progress+=1
        if not (progress%totalchk):
            print str(progress/total)+'% complete'
        if line.startswith('//'): continue
        if line == "\n":
            cur=''
            continue
        line=line.strip()
        if line.startswith("GUID="):
            spawns[line[5:]]={}
            cur=line[5:]
            continue
        if not line.find('=')+1: continue
        if cur:
            spl=line.split('=',1)
            if len(spl)>=2: spl[1]=spl[1].strip()
            if spl[1].find("//")+1:
                spl[1]=spl[1][:spl[1].find("//")]
                spl[1]=spl[1].strip()
            if not spawns[cur].has_key(spl[0]): spawns[cur][spl[0]]=spl[1]
    f.close()

def writesav(filename):
    global total
    f=open(filename,"wb")
    for sid in spawns:
        try:
            sp=spawns[sid]
            if not 'GTYPE' in sp: continue # not a GO
            out=""
            if not sp: raise Exception("No data found!")
            #sp=spawns[sp['LINK']] # We may need the link someday.
            goid=int(sp['ENTRY'])
            rotation=sp.get('ROTATION','0 0 0 0').split()
            out+=pack('I',goid | 0x13000000)
            out+=pack('I',int(sp['TYPE']))
            out+=pack('I',int(sp.get('GTYPE',0)))
            out+=pack('I',int(sp.get('MAP',0))) # WoWEmu does not write '0' fields
            k=sp['XYZ'].split()
            out+=pack('ffff',float(k[0]),float(k[1]),float(k[2]),float(k[3]))
            out+=pack('ffff',float(rotation[0]),float(rotation[1]),float(rotation[2]),float(rotation[3]))
            f.write(out)
            total+=1
        except Exception,detail:
            import traceback
            traceback.print_exc(None,errlog)
    f.close()
load_world_save("world.save")
writesav("GOspawns.sav")
errlog.write("Total GOs converted: %i"%total)
errlog.close()
