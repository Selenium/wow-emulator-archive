import struct
areatriggers={}
def load_areatriggers_scp(filename):
    f=open(filename)
    lines=f.readlines()
    aid=0
    for line in lines:
        if line.startswith('//'): continue
        if line is "\n":
            aid=0
            continue
        line=line.strip()
        if line.startswith("[areatrigger "):
            aid=int(line.split("]")[0][13:]) #Suddenly, comments appear after ]...
            if areatriggers.has_key(aid): warn(aid,"Duplicate Areatrigger!")
            areatriggers[aid]={}
            continue
        if not line.find('=')+1: continue
        if aid:
            spl=line.split('=',1)
            if len(spl)>=2: spl[1]=spl[1].strip()
            if spl[1].find("//")+1:
                spl[1]=spl[1][:spl[1].find("//")]
                spl[1]=spl[1].strip()
            if not areatriggers[aid].has_key(spl[0]): areatriggers[aid][spl[0]]=spl[1]
    f.close()

load_areatriggers_scp("areatriggers.scp")
f=open("AreaTriggers.dat","wb")
m=[]
n=[]
# ID, Map, XYZ, Facing
for i in areatriggers:
    if 'totrigger' in areatriggers[i]:
        k=areatriggers[int(areatriggers[i]['totrigger'])]['pos'].split()
        m.append(i)
        n.append(areatriggers[i]['name'])
        f.write(struct.pack("IIffff",i,int(k[0]),float(k[1]),float(k[2]),float(k[3]),float(k[4])))
    if 'topos' in areatriggers[i]:
        k=areatriggers[i]['topos'].split()
        m.append(i)
        n.append(areatriggers[i]['name'])
        f.write(struct.pack("IIffff",i,int(k[0]),float(k[1]),float(k[2]),float(k[3]),float(k[4])))
f.close()
m.sort()
print m
print n
