#!/usr/bin/python
#Quest Converter for WowwoW by nneonneo. Imports QDB Quest database files into WowwoW .cs format.
#2005-Sept-08
#Updated 2005-Oct-03
import sys

errlog=open("QuestErrors.txt","w")

texts={}
quests={}
inames={}
qtypes={0x51:"Dungeon",
        1:"Elite",
        0x15:"Life",
        0:"None",
        0x29:"PvP",
        0x3e:"Raid"}
def load_item_names(filename):
    try: f=open(filename)
    except IOError: return
    dat=f.readlines()
    f.close()
    for linenum in range(len(dat)/2):
        name=dat[2*linenum].replace("\n","")
        iid=dat[2*linenum+1].replace("\n","")
        if iid and name: inames[iid]=name
def load_texts(filename):
    f=open(filename)
    lines=f.readlines()
    tid=0
    for line in lines:
        if line.endswith('\n'): line=line[:-1]
        if line.startswith("[npctext "):
            tid=int(line[9:-1])
            continue
        if line.startswith("text0_0="):
            if tid:
                texts[tid]=line[8:].replace('"','\\"').replace('\\\\"','\\"')
                tid=0
    f.close()
def load_quests_scp(filename):
    f=open(filename)
    lines=f.readlines()
    qid=0
    for line in lines:
        if line.startswith('//'): continue
        if line is "\n":
            qid=0
            continue
        if line.endswith('\n'): line=line[:-1]
        if line.startswith("[quest "):
            qid=int(line.split("]")[0][7:]) #Suddenly, comments appear after ]...
            quests[qid]={}
            continue
        if not line.find('=')+1: continue
        spl=line.split('=',1)
        if spl[0] == "type": spl[0]="qtype"
        if spl[0] in ["reward_choice","deliver","src_item","spell_reward","reward_item","kill","next_quest"]: #lock_quest
            if not quests[qid].has_key(spl[0]): quests[qid][spl[0]]=[]
            if spl[1][-1]==" ": spl[1]=spl[1][:-1]
            quests[qid][spl[0]].append(spl[1].replace('"','\\"'))
        elif not quests[qid].has_key(spl[0]): quests[qid][spl[0]]=spl[1].replace('"','\\"').replace('\\\\"','\\"')
    f.close()
def nextprev():
    for qid in quests:
        nextlist=quests[qid].get("next_quest",[])
        for next in nextlist:
            if quests.get(int(next),None): quests[int(next)]["previous_quest"]=qid
def load_qdb(filename):
    f=open(filename)
    lines=f.readlines()
    qid=0
    for line in lines:
        if line.startswith('//'): continue
        if line is "\n":
            qid=0
            continue
        if line.endswith('\n'): line=line[:-1]
        if line.startswith("[quest "):
            qid=int(line[7:-1])
            if not quests.has_key(qid): qid=0
            continue
        if not line.find('=')+1: continue
        spl=line.split('=',1)
        if qid:
            if spl[0] in ["reward_choice","deliver","src_item","spell_reward","reward_item","kill","next_quest"]: #lock_quest
                if not quests[qid].has_key(spl[0]): quests[qid][spl[0]]=[]
                if spl[1][-1]==" ": spl[1]=spl[1][:-1]
                if not spl[1].replace('"','\\"') in quests[qid][spl[0]]: quests[qid][spl[0]].append(spl[1].replace('"','\\"'))
            elif not quests[qid].has_key(spl[0]): quests[qid][spl[0]]=spl[1].replace('"','\\"').replace('\\\\"','\\"')
    f.close()
def load_ndb(filename):
    f=open(filename)
    lines=f.readlines()
    nid=0
    npctype=""
    isperson=False
    for line in lines:
        if line.startswith('//'): continue
        if line is "\n":
            nid=0
            isperson=False
            continue
        if line.endswith('\n'): line=line[:-1]
        if line.startswith("[npc "):
            nid=int(line[5:-1])
            if nid>1000000: nid-=1000000 #qmgrndb.def contains NPC 1000000+real ID in case of conflicts
            isperson=False
        if not line.find('=')+1: continue
        if line.startswith("npctype"):
            npctype=line[8:]
            if npctype.startswith("Person"):isperson=True
        spl=line.split('=',1)
        if nid:
            if isperson:
                if spl[0].endswith("quest"):
                    qid=int(spl[1])
                    if quests.has_key(qid):
                        quests[qid]["giver_npc"]=nid
                if spl[0].endswith("questinvolved"):
                    qid=int(spl[1])
                    if quests.has_key(qid):
                        quests[qid]["involve_npc"]=nid
            elif npctype.startswith("Item"):
                if spl[0].endswith("quest"):
                    qid=int(spl[1])
                    if quests.has_key(qid):
                        quests[qid]["giver_item"]=nid
                if spl[0].endswith("questinvolved"):
                    qid=int(spl[1])
                    if quests.has_key(qid):
                        quests[qid]["involve_item"]=nid
            elif npctype.startswith("Object"):
                if spl[0].endswith("quest"):
                    qid=int(spl[1])
                    if quests.has_key(qid):
                        quests[qid]["giver_gobj"]=nid
                if spl[0].endswith("questinvolved"):
                    qid=int(spl[1])
                    if quests.has_key(qid):
                        quests[qid]["involve_gobj"]=nid
    f.close()
def warn(qid,msg):
    errlog.write("Warning: Quest "+str(qid)+": "+msg+"\n")
def writecs(filename):
    questcount=len(quests)
    qlist=open("questlist.txt","w")
    f=open(filename,"w")
    f.write("""using System;
using Server;
using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
""")
    for qid in quests:
        try:
            out=""
            name=quests[qid].get("name")
            if (not name) or name.startswith("Missing details about "): raise Exception("Quest's name is missing")
            desc=quests[qid].get("desc","TODO")
            if desc.startswith("TODO") or desc.startswith("missing") or desc.endswith("missing"): warn(qid,"Description and details are missing")
            name=name.translate('________________________________________________0123456789_______ABCDEFGHIJKLMNOPQRSTUVWXYZ______abcdefghijklmnopqrstuvwxyz_____________________________________________________________________________________________________________________________________')
            name+='_'+str(qid)
            out+="\tpublic class "+name+" : BaseQuest"
            if quests[qid].get("giver_npc"): out+=" //NPC: "+str(quests[qid].get("giver_npc",0))
            elif quests[qid].get("giver_gobj"): out+=" //GameObject: "+str(quests[qid].get("giver_gobj",0))
            elif quests[qid].get("giver_item"): out+=" //Item: "+str(quests[qid].get("giver_item",0))
            else: warn(qid,"No NPC, GObj or Item associated with this quest")
            if quests[qid].get("involve_gobj"): out+=" //Involves GameObject: "+str(quests[qid].get("involve_gobj",0))
            elif quests[qid].get("involve_item"): out+=" //Involves item: "+str(quests[qid].get("involve_item",0))
            out+="\n\t{\n\t\tpublic "+name+"() : base()\n\t\t{"
            for more_info in ["class","race","tradeskill"]:
                if quests[qid].has_key(more_info):
                    out+="\n\t\t\t// "+more_info+":"+quests[qid][more_info]
            out+="\n\t\t\t"
            eoltab=";\n\t\t\t"
            out+="id = "+str(qid)+eoltab
            out+="name = \""+quests[qid]["name"]+'"'+eoltab
            out+="desc = \""+quests[qid].get("desc","")+'"'+eoltab
            out+="details = \""+quests[qid].get("details","")+'"'+eoltab
            if quests[qid].get("giver_npc"): out+="npcId = "+str(quests[qid].get("giver_npc",0))+eoltab
            elif quests[qid].get("giver_gobj") or quests[qid].get("giver_item"): warn(qid,"Quest has no NPC associated with it; npcId is left blank.")
            out+="questFlags = 0x"+quests[qid].get("quest_flags","0")+eoltab
            if quests[qid].get("levels","1 1")=="0 0": warn(qid,"Quest has invalid levels")
            lvl=quests[qid].get("levels","1 1").split(" ")
            if len(lvl) is 1: lvl=lvl.extend(lvl)
            out+="idealLevel = "+lvl[1]+eoltab
            out+="minLevel = "+lvl[0]+eoltab
            out+="zone = "+quests[qid].get("zone","1")+eoltab
            if quests[qid].has_key("reward_xp"): out+="rewardXp = "+quests[qid].get("reward_xp")+eoltab
            if quests[qid].has_key("reward_gold"): out+="rewardGold = "+str(min(long(quests[qid].get("reward_gold")),65535))+eoltab
            if quests[qid].has_key("spell_reward"):
                if len(quests[qid]["spell_reward"])>1: warn(qid,"More than one reward spell!")
                out+="rewardSpell = "+quests[qid]["spell_reward"][0]+eoltab
            if quests[qid].has_key("src_item"):
                if len(quests[qid]["src_item"])>1: warn(qid,"More than one source item!")
                k=quests[qid]["src_item"][0].split()
                if len(k) is 1: k.append("1")
                if k[1] != "1": warn(qid,"Source item needs to have "+k[1]+" copies!")
                out+="sourceItemId = "+k[0]+eoltab
            if quests[qid].has_key("previous_quest"): out+="previousQuest = "+str(quests[qid].get("previous_quest"))+eoltab
            if quests[qid].has_key("time_minutes"): out+="completionTime = new TimeSpan( 0, "+str(quests[qid].get("time_minutes"))+" , 0 )"+eoltab
            if quests[qid].has_key("completion_desc"):
                tid=int(quests[qid].get("completion_desc",""))
                if tid:
                    out+="finishDialog = \""+texts.get(tid,"")+'"'+eoltab
                    out+="finishTitle = \""+quests[qid]["name"]+'"'+eoltab
                else:
                    out+="finishDialog = \"Thanks for finishing the quest, $N!\""+eoltab+"finishTitle = \""+quests[qid]["name"]+'"'+eoltab
                    warn(qid,"Completion Text ID #"+str(tid)+" not found!")
            else:
                out+="finishDialog = \"Thanks for finishing the quest, $N!\""+eoltab+"finishTitle = \""+quests[qid]["name"]+'"'+eoltab
                warn(qid,"No Finish Dialog (completion_desc)!")
            if quests[qid].has_key("progress_desc"):
                tid=int(quests[qid].get("progress_desc",""))
                if tid:
                    out+="progressDialog = \""+texts.get(tid,"")+'"'+eoltab
                    out+="progressTitle = \""+quests[qid]["name"]+'"'+eoltab
                else:
                    out+="progressDialog = \"Are you done my quest, $N?\""+eoltab+"progressTitle = \""+quests[qid]["name"]+'"'+eoltab
                    warn(qid,"Progress Text ID #"+str(tid)+" not found!")
            else:
                out+="progressDialog = \"Are you done my quest, $N?\""+eoltab+"progressTitle = \""+quests[qid]["name"]+'"'+eoltab
                warn(qid,"No Progress Dialog (progress_desc)!")
            if quests[qid].has_key("qtype"):
                k=int(quests[qid]["qtype"])
                if qtypes.has_key(k): out+="questType = QuestType."+qtypes[k]+eoltab
                else: warn(qid,"Unknown Quest Type "+str(k))
            if quests[qid].has_key("class"): out+="classAllowed=qClasses."+quests[qid]["class"]+eoltab
            if quests[qid].has_key("race"):
                races=quests[qid]["race"].split(" ")
                if len(races)==8: out+="raceAllowed=qRaces.Any"+eoltab
                elif len(races)==4:
                    if races[0]=="Human": out+="raceAllowed=qRaces.Alliance"+eoltab
                    elif races[0]=="Orc": out+="raceAllowed=qRaces.Horde"+eoltab
                    else: warn(qid,"Strange 'race' entry.")
                elif len(races)==1: out+="raceAllowed=qRaces."+races[0]+eoltab
                else: warn(qid,"Strange 'race' entry.")
                        
            if quests[qid].has_key("type"):
                t=quests[qid].get("type","")
                if t.find("SpeakTo")+1:
                    x=True
                    for i in ["deliver","src_item","kill"]:
                        if quests[qid].has_key(i):
                            x=False
                            break
                    if x and str(quests[qid].get("involve_npc",quests[qid].get("giver_npc",0))) != str(quests[qid].get("giver_npc",0)):
                        out+="npcTargetId = "+str(quests[qid].get("involve_npc",0))+eoltab
            if quests[qid].has_key("deliver") and quests[qid].has_key("involve_npc"):
                if not quests[qid].get("giver_npc",0) is quests[qid].get("involve_npc",0):
                    out+="npcTargetId = "+str(quests[qid].get("involve_npc",0))+eoltab
            out=out[:-1]+"}\n"
            out+="\t\tpublic override void InitObjectives()\n\t\t{\n\t\t\ttry\n\t\t\t{\n\t\t\t\t"
            eoltab=";\n\t\t\t\t"
            if quests[qid].has_key("reward_choice"):
                for i in quests[qid]["reward_choice"]:
                    k=i.split()
                    if len(k) is 1: k.append("1")
                    out+="rewardChoice.Add( "+k[0]+", "+k[1]+" )"+eoltab
            if quests[qid].has_key("reward_item"):
                for i in quests[qid]["reward_item"]:
                    k=i.split()
                    if len(k) is 1: k.append("1")
                    out+="reward.Add( "+k[0]+", "+k[1]+" )"+eoltab
            if quests[qid].has_key("kill"):
                for i in quests[qid].get("kill",[]):
                    k=i.split()
                    if len(k) is 1: k.append("1")
                    out+="npcObjectives.Add( "+k[0]+", "+k[1]+" )"+eoltab
            if quests[qid].has_key("deliver"):
                for i in quests[qid].get("deliver",[]):
                    k=i.split()
                    if len(k) is 1: k.append("1")
                    out+="deliveryObjectives.Add( "+k[0]+", "+k[1]+" )"+eoltab
            if quests[qid].has_key("tradeskill"):
                if quests[qid]["tradeskill"]=="FirstAid": quests[qid]["tradeskill"]="First_Aid"
            	out+="skillsAllowed.Add( qSkills."+quests[qid]["tradeskill"]+" )"+eoltab
            out=out[:-1]+"}\n\t\t\tcatch { Console.WriteLine (\"Quest "+str(qid)+" bugged!\"); }\n\t\t}\n"
            out+="\t\tpublic override DialogStatus QuestStatus( Mobile questOwner, Character c ) { return BaseNPC.QDS( questOwner, c, this ); }\n"
            out+="\t}\n"
            f.write(out)
            qlist.write(str(qid)+" "+name+"\n")
        except Exception,detail:
            errlog.write("Error: Quest "+str(qid)+": "+str(detail)+"\n")
            questcount-=1
    f.write("}\n//Quests converted: "+str(questcount)+"\n//Failed quests: "+str(len(quests)-questcount))
    f.close()
    qlist.close()
load_item_names("items.txt")
load_texts("qdbtexts.scp")
load_quests_scp("quests.scp")
load_qdb("qmgrqdb.def")
load_ndb("qmgrndb.def")
nextprev()
writecs("ImportedQuests.cs")

errlog.close()
