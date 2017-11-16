#!/usr/bin/python
#GUI THD Editor, built on wxPython
#2006-Oct-25
#Updated 2006-Nov-05
#Internal Version: 0.1.21

#----- DEFINES/GLOBAL VARIABLES -----#
TBC=False # Change to True for TBC analysis (affects Player)
defines={}
if TBC:
    defines['FACTION_ARRAY_COUNT']='128'
else:
    defines['FACTION_ARRAY_COUNT']='64'
defines['LAST_SLOT_PLAYER']='69'
defines['MAXLOOTITEMS']='432'
defines['MAX_GUILDMEMBERS']='100'
defines['MAX_PARTYMEMBERS']='5'
defines['TEXT_LEN']='512'

# These IDs will not appear at all
excludeIDs=[0,16] # None, Spell

typenames=['None',
           'Player',
           'Creature',
           'SpawnPoint',
           'Zone',
           'Account',
           'Item',
           'ItemTemplate',
           'CreatureTemplate',
           'Auction',
           'LootTable',
           'PathGroup',
           'Guild',
           'GameObject',
           'DynamicObject',
           'Party',
           'Spell',
           'QuestRelation',
           'Corpse',
           'GameObjectTemplate',
           'NPCText',
           'PageText',
           'Mail',
           'Quest',
           'TrainerTemplate',
           'NUMTYPES']
NUMTYPES=25
NULL=0
fieldtypes={'char':'b',
            'unsigned char':'B',
            'short':'h',
            'unsigned short':'H',
            'int':'i',
            'unsigned int':'I',
            'long':'l',
            'unsigned long':'l', # hack hack hack
            'float':'f',
            'string':'s',
            'pointer':'P',
            'guid_t':'L',
            'guidhigh_t':'L'}

MENU_FILE_ABOUT = 101
MENU_FILE_SAVE = 102
MENU_FILE_SAVEALL = 103
MENU_FILE_RELOAD = 104
MENU_FILE_EXIT = 199
MENU_EDIT_FIND_VALUE = 111
MENU_EDIT_FIND_TEXT = 112
MENU_EDIT_FIND_NEXT = 113
MENU_EDIT_JUMP_GUID = 120

ID_NOTEBOOK = 200

structs={}

#----- CODE -----#
import wx

from struct import *
try:
    import psyco
    psyco.profile()
except: pass

def ErrorDlg(text):
    dlgerror = wx.MessageDialog(None, text,
                              "Error", wx.OK | wx.ICON_ERROR)
    dlgerror.ShowModal()
    dlgerror.Destroy()

class ProportionalSplitter(wx.SplitterWindow):
        def __init__(self,parent, id = -1, proportion=0.66, size = wx.DefaultSize):
                wx.SplitterWindow.__init__(self,parent,id,wx.Point(0, 0),size,0)
                self.SetMinimumPaneSize(50) #the minimum size of a pane.
                self.proportion = proportion
                if not 0 < self.proportion < 1:
                        raise ValueError, "proportion value for ProportionalSplitter must be between 0 and 1."
                self.ResetSash()
                self.Bind(wx.EVT_SIZE, self.OnReSize)
                self.Bind(wx.EVT_SPLITTER_SASH_POS_CHANGED, self.OnSashChanged, id=id)
                ##hack to set sizes on first paint event
                self.Bind(wx.EVT_PAINT, self.OnPaint)
                self.firstpaint = True

        def SplitHorizontally(self, win1, win2):
                if self.GetParent() is None: return False
                return wx.SplitterWindow.SplitHorizontally(self, win1, win2,
                        int(round(self.GetParent().GetSize().GetHeight() * self.proportion)))

        def SplitVertically(self, win1, win2):
                if self.GetParent() is None: return False
                return wx.SplitterWindow.SplitVertically(self, win1, win2,
                        int(round(self.GetParent().GetSize().GetWidth() * self.proportion)))

        def GetExpectedSashPosition(self):
                if self.GetSplitMode() == wx.SPLIT_HORIZONTAL:
                        tot = max(self.GetMinimumPaneSize(),self.GetParent().GetClientSize().height)
                else:
                        tot = max(self.GetMinimumPaneSize(),self.GetParent().GetClientSize().width)
                return int(round(tot * self.proportion))

        def ResetSash(self):
                self.SetSashPosition(self.GetExpectedSashPosition())

        def OnReSize(self, event):
                "Window has been resized, so we need to adjust the sash based on self.proportion."
                self.ResetSash()
                event.Skip()

        def OnSashChanged(self, event):
                "We'll change self.proportion now based on where user dragged the sash."
                pos = float(self.GetSashPosition())
                if self.GetSplitMode() == wx.SPLIT_HORIZONTAL:
                        tot = max(self.GetMinimumPaneSize(),self.GetParent().GetClientSize().height)
                else:
                        tot = max(self.GetMinimumPaneSize(),self.GetParent().GetClientSize().width)
                self.proportion = pos / tot
                event.Skip()

        def OnPaint(self,event):
                if self.firstpaint:
                        if self.GetSashPosition() != self.GetExpectedSashPosition():
                                self.ResetSash()
                        self.firstpaint = False
                event.Skip()

def guid(objtype,ID):
    if type(objtype)==str:
        return ((typenames.index(objtype)<<24)|ID)
    else:
        return ((objtype<<24)|ID)

class Struct(object):
    def __init__(self,data):
        self.name=''
        self.fields=[]
        self.structfmt=''
        data=data.strip()
        for i in defines:
            data=data.replace(i,defines[i])
        lines=[]
        for i in data.split('\n'):
            if i.find('//')!=-1:
                i=i[:i.find('//')].strip()
            i=i.strip()
            if i:
                lines+=[i]
        if not lines: return
        if not lines[0].startswith('struct'):
            raise Exception("Invalid Struct")
        self.name=lines[0].split()[1]
        for i in lines[1:]:
            if not i[0] in 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_':
                continue
            i=i.strip(';')
            pieces=i.split()
            name=pieces[-1]
            ftype=' '.join(pieces[:-1])
            stype=''
            if name[0]=='*':
                name=name[1:]
                ftype+='*'
            stype=ftype
            if '*' in ftype: stype='pointer'
            splitsize=name.split('[')
            name=splitsize[0]
            size=1
            if len(splitsize)>1:
                size=eval(splitsize[1].replace(']',''))
                if ftype=='char':
                    stype='string'
            if stype=='string':
                self.structfmt+=str(size)+'s'
            elif size>1:
                fakename=ftype.replace(' ','$')+'@'+name+'[%i]'%size # $ - fake spaces; @ - sep. for type and name to maintain uniqueness
                if fakename not in structs:
                    fakestruct='struct %s\n{\n'%(fakename)
                    for i in range(size):
                        fakestruct+=ftype+' '+name+'(%i)'%i+'\n'
                    Struct(fakestruct)
                ftype=fakename
                size=1
                self.structfmt+=structs[ftype].structfmt
            elif ftype in structs:
                self.structfmt+=size*structs[ftype].structfmt
            else:
                self.structfmt+=size*fieldtypes[stype]
            self.fields+=[(ftype,size,name)]
        structs[self.name]=self
    def AppendToTree(self,parent,tree,data,index=0,sname=''):
        if not parent:
            root=tree.AddRoot(self.name,data=wx.TreeItemData({})) # dict will map field ID to item id
        else:
            root=tree.AppendItem(parent,self.name.replace('$',' ').split('@')[0]+' '+sname,data=wx.TreeItemData(-1))
        datapos=index
        for ftype,size,name in self.fields:
            if ftype in structs:
                datapos=structs[ftype].AppendToTree(root,tree,data,datapos,name)
            else:
                if size>1:
                    name+='[%i]'%size
                data_repr=str(data[datapos])
                if ftype=='guid_t':
                    if not data[datapos]:
                        data_repr='0'
                    else:
                        t=data[datapos]>>24
                        data_repr="guid('%s',%i)"%(typenames[t],data[datapos]&0xFFFFFF)
                tree.GetPyData(tree.GetRootItem())[datapos]=(
                    tree.AppendItem(root,ftype+' '+name+' : '+data_repr,data=wx.TreeItemData([datapos,size])))
                if ftype=='char':
                    datapos+=1
                else:
                    datapos+=size
        if not parent: tree.Expand(root)
        return datapos

class MyFrame(wx.Frame):
    def __init__(self, parent, ID, title):
        wx.Frame.__init__(self, parent, ID, title,
                         wx.DefaultPosition, wx.Size(620,700))

        self.CreateStatusBar()
        self.SetStatusText("")

        self.SearchVal=None
        self.SearchType=None
        
        menu = wx.Menu()
        menu.Append(MENU_FILE_ABOUT, "&About",
                    "About this program")
        menu.AppendSeparator()
        menu.Append(MENU_FILE_SAVE, "&Save\tCtrl+S", "Save current file")
        menu.Append(MENU_FILE_SAVEALL, "Sa&ve All\tCtrl+Shift+S", "Save all files")
        menu.AppendSeparator()
        menu.Append(MENU_FILE_RELOAD, "Reload Current Page\tCtrl+R", "Reload current page, discarding changes")
        menu.AppendSeparator()
        menu.Append(MENU_FILE_EXIT, "E&xit\tCtrl+Q", "Terminate the program")
        menuBar = wx.MenuBar()
        menuBar.Append(menu, "&File")
        menuEdit=wx.Menu()
        menuEdit.Append(MENU_EDIT_FIND_TEXT, "Find &Text\tCtrl+F", "Find a string")
        menuEdit.Append(MENU_EDIT_FIND_VALUE, "Find &Value/ID\tCtrl+Shift+F", "Find a particular integer value")
        menuEdit.Append(MENU_EDIT_FIND_NEXT, "Find &Next\tF3", "Find Next Value")
        menuEdit.AppendSeparator()
        self.MenuGuidJump=menuEdit.Append(MENU_EDIT_JUMP_GUID, "&Jump to GUID\tCtrl+J", "Jump to the selected GUID")
        menuBar.Append(menuEdit,"&Edit")
        self.SetMenuBar(menuBar)

        self.Notebook=wx.Notebook(self,-1)

        wx.EVT_MENU(self, MENU_FILE_ABOUT, self.OnAbout)
        wx.EVT_MENU(self, MENU_FILE_SAVE,  self.SaveCurrentPane)
        wx.EVT_MENU(self, MENU_FILE_SAVEALL,self.SaveAll)
        wx.EVT_MENU(self, MENU_FILE_RELOAD, self.ReloadCurrentPane)
        wx.EVT_MENU(self, MENU_FILE_EXIT,  self.TimeToQuit)
        wx.EVT_MENU(self, MENU_EDIT_FIND_VALUE,self.FindValue)
        wx.EVT_MENU(self, MENU_EDIT_FIND_TEXT,self.FindText)
        wx.EVT_MENU(self, MENU_EDIT_FIND_NEXT,self.FindNext)
        wx.EVT_MENU(self, MENU_EDIT_JUMP_GUID,self.GUIDJump)
        wx.EVT_CLOSE(self, self.OnCloseWindow)

    def OnAbout(self, event):
        dlg = wx.MessageDialog(self, 'THD Editor\n'
                               '(c) nneonneo 2006',
                              "About...", wx.OK | wx.ICON_INFORMATION)
        dlg.ShowModal()
        dlg.Destroy()

    def OnCloseWindow(self,event):
        for i in range(self.Notebook.GetPageCount()):
            if self.Notebook.GetPageText(i)[-1]=='*':
                confirmdlg=wx.MessageDialog(None,"Unsaved Changes. Save All?","Save Changes",wx.YES_NO|wx.CANCEL)
                res=confirmdlg.ShowModal()
                confirmdlg.Destroy()
                if res==wx.ID_YES:
                    self.SaveAll(None)
                    self.Destroy()
                elif res==wx.ID_NO:
                    self.Destroy()
                else:
                    if event.CanVeto(): event.Veto()
                    else: self.Destroy()
                return
        self.Destroy()

    def FindValue(self,event):
        dlg=wx.TextEntryDialog(None,"Find Value")
        if dlg.ShowModal()!=wx.ID_OK:
            dlg.Destroy()
            return
        try:
            self.SearchVal=int(eval(dlg.GetValue()))
        except Exception,detail:
            ErrorDlg('Error! Value inputted is invalid.\n'+str(detail))
            dlg.Destroy()
            return
        self.SearchType='Value'
        dlg.Destroy()
        self.SetStatusText("Finding...")
        self.Notebook.GetCurrentPage().MyPage.FindValue(self.SearchVal,True)
        self.SetStatusText('')

    def FindText(self,event):
        dlg=wx.TextEntryDialog(None,"Find Text")
        if dlg.ShowModal()!=wx.ID_OK:
            dlg.Destroy()
            return
        self.SearchVal=dlg.GetValue()
        self.SearchType='Text'
        dlg.Destroy()
        self.SetStatusText("Finding...")
        self.Notebook.GetCurrentPage().MyPage.FindText(self.SearchVal,True)
        self.SetStatusText('')

    def FindNext(self,event):
        if self.SearchVal==None:
            ErrorDlg('No search in progress!')
            return
        self.SetStatusText("Finding...")
        if self.SearchType=='Value':
            self.Notebook.GetCurrentPage().MyPage.FindValue(self.SearchVal,False)
        else:
            self.Notebook.GetCurrentPage().MyPage.FindText(self.SearchVal,False)
        self.SetStatusText('')

    def GUIDJump(self,event):
        page=self.Notebook.GetCurrentPage().MyPage
        selection=page.Tree.GetSelection()
        if selection:
            text=page.Tree.GetItemText(selection)
            data=page.Tree.GetPyData(selection)
            if text.split()[0]!='guid_t':
                ErrorDlg('Error! You have not selected a GUID.')
                return
            guid=page.data[page.ObjID][data[0]]
            if not guid:
                ErrorDlg('Invalid GUID Selected!')
                return
            objid=guid>>24
            if objid>=NUMTYPES:
                ErrorDlg('Invalid GUID Selected!')
                return
            tgtpageid=-1
            for i in range(self.Notebook.GetPageCount()):
                if self.Notebook.GetPage(i).MyPage.ID==objid:
                    tgtpageid=i
                    break
            if tgtpageid==-1:
                ErrorDlg('Invalid GUID Selected!')
                return
            tgtpage=self.Notebook.GetPage(tgtpageid).MyPage
            if not (guid) in tgtpage.ids:
                ErrorDlg('GUID does not exist in page "%s"!'%typenames[objid])
                return
            self.Notebook.SetSelection(tgtpageid)
            tgtpage.ListBox.SetSelection(tgtpage.ids.index(guid))
            tgtpage.SelectID(tgtpage.ListBox) # it has a GetSelection method :P
        else:
            ErrorDlg('Nothing selected!')
            return
    
    def SaveCurrentPane(self, event):
        self.Notebook.GetCurrentPage().MyPage.Save()

    def ReloadCurrentPane(self, event):
        if self.Notebook.GetPageText(self.Notebook.GetSelection())[-1]=='*':
            confirmdlg=wx.MessageDialog(None,"Unsaved Changes. Reload anyway?","Confirm",wx.OK|wx.CANCEL)
            res=confirmdlg.ShowModal()
            confirmdlg.Destroy()
            if res==wx.ID_OK:
                page=self.Notebook.GetCurrentPage().MyPage
                page.LoadTHD(file("obj%02i.thd"%page.ID,"rb"))

    def SaveAll(self, event):
        for i in range(self.Notebook.GetPageCount()):
            if self.Notebook.GetPageText(i)[-1]=='*':
                self.Notebook.GetPage(i).MyPage.Save()

    def TimeToQuit(self, event):
        self.Close(True)

class MyPage(object):
    def __init__(self,parent,ID):
        parent.GetParent().SetStatusText('Loading %s'%typenames[ID])
        self.Window=wx.Window(parent,ID)
        self.Window.MyPage=self # set back reference
        parent.AddPage(self.Window,typenames[ID])
        self.struct=structs[typenames[ID]+'Data']
        self.ID=ID
        self.ids=[]
        self.data={}
        self.ObjID=-1
        self.findpos_i=0
        self.findpos_j=-1
        self.SplitterWindow=ProportionalSplitter(self.Window,-1,0.3,size=(600,600))
        self.Tree=wx.TreeCtrl(self.SplitterWindow,-1)
        self.ListBoxWnd=ProportionalSplitter(self.SplitterWindow,-1,0.9)
        self.ListBox=wx.ListBox(self.ListBoxWnd,-1,choices=self.ids)
        self.ButtonPane=wx.Panel(self.ListBoxWnd,-1)
        self.AddButton=wx.Button(self.ButtonPane,-1,"Add")
        self.DupButton=wx.Button(self.ButtonPane,-1,"Duplicate")
        self.DelButton=wx.Button(self.ButtonPane,-1,"Delete")
        self.BoxSizer=wx.BoxSizer(wx.HORIZONTAL)
        self.BoxSizer.Add(self.AddButton,1,wx.EXPAND)
        self.BoxSizer.Add(self.DupButton,1,wx.EXPAND)
        self.BoxSizer.Add(self.DelButton,1,wx.EXPAND)
        self.ButtonPane.SetSizer(self.BoxSizer)
        self.SplitterWindow.SplitVertically(self.ListBoxWnd,self.Tree)
        self.ListBoxWnd.SplitHorizontally(self.ListBox,self.ButtonPane)
        try:
            self.LoadTHD(file("obj%02i.thd"%ID,"rb"))
        except IOError:
            pass
        except Exception, detail:
            print "ID %i [%s]: "%(ID,typenames[ID])+str(detail)
        self.RedrawTree()
        wx.EVT_TREE_ITEM_ACTIVATED(self.Window,self.Tree.GetId(),self.EditTreeItem)
        wx.EVT_LISTBOX(self.Window,self.ListBox.GetId(),self.SelectID)
        wx.EVT_BUTTON(self.Window,self.AddButton.GetId(),self.AddItem)
        wx.EVT_BUTTON(self.Window,self.DelButton.GetId(),self.DelItem)
        wx.EVT_BUTTON(self.Window,self.DupButton.GetId(),self.DupItem)
        return None

    def AddItem(self,event):
        dlg=wx.TextEntryDialog(None,"New Item ID")
        if dlg.ShowModal()!=wx.ID_OK:
            dlg.Destroy()
            return
        try:
            ID=int(dlg.GetValue())|(self.ID<<24)
        except Exception,detail:
            ErrorDlg('Error! Value inputted is invalid.\n'+str(detail))
            dlg.Destroy()
            return
        if ID in self.data:
            ErrorDlg('Error! ID already exists.')
            dlg.Destroy()
            return
        newdat=[]
        for i in self.struct.structfmt:
            if i in 'bBhHiIlLP':
                newdat+=[0]
            elif i=='f':
                newdat+=[0.0]
            elif i=='s':
                newdat+=['']
        self.data[ID]=newdat
        self.ids+=[ID]
        self.ObjID=ID
        self.RedrawTree()
        self.UpdateListBox()
        self.ListBox.SetSelection(self.ids.index(ID))
        dlg.Destroy()
        notebook=self.Window.GetParent()
        windowid=notebook.GetSelection()
        notebook.SetPageText(windowid,typenames[self.ID]+'*')

    def DelItem(self,event):
        if self.ObjID==-1: return
        confirmdlg=wx.MessageDialog(None,"Delete object %i?"%(0xFFFFFF&self.ObjID),"Confirm")
        if confirmdlg.ShowModal()==wx.ID_OK:
            del self.data[self.ObjID]
            del self.ids[self.ids.index(self.ObjID)]
            self.ObjID=-1
            self.RedrawTree()
            self.UpdateListBox()
            notebook=self.Window.GetParent()
            windowid=notebook.GetSelection()
            notebook.SetPageText(windowid,typenames[self.ID]+'*')
        confirmdlg.Destroy()
        
    def DupItem(self,event):
        if self.ObjID==-1: return
        dlg=wx.TextEntryDialog(None,"New Item ID")
        if dlg.ShowModal()!=wx.ID_OK:
            dlg.Destroy()
            return
        try:
            ID=int(dlg.GetValue())|(self.ID<<24)
        except Exception,detail:
            ErrorDlg('Error! Value inputted is invalid.\n'+str(detail))
            dlg.Destroy()
            return
        if ID in self.data:
            ErrorDlg('Error! ID already exists.')
            dlg.Destroy()
            return
        self.data[ID]=self.data[self.ObjID][:] # copy
        self.ids+=[ID]
        self.ObjID=ID
        self.RedrawTree()
        self.UpdateListBox()
        self.ListBox.SetSelection(self.ids.index(ID))
        dlg.Destroy()
        notebook=self.Window.GetParent()
        windowid=notebook.GetSelection()
        notebook.SetPageText(windowid,typenames[self.ID]+'*')
        
    def EditTreeItem(self,event):
        if event.GetEventObject().GetPyData(event.GetItem())==-1:
            return False
        it=event.GetItem()
        tree=event.GetEventObject()
        itemname=tree.GetItemText(it)
        itemindex=tree.GetPyData(it)[0]
        itemlen=tree.GetPyData(it)[1]
        d=self.data[self.ObjID][itemindex]
        dlg=wx.TextEntryDialog(None,"Editing Item",caption=itemname,
                              defaultValue=self.Tree.GetItemText(it).split(' : ',1)[1])
        if dlg.ShowModal()!=wx.ID_OK:
            dlg.Destroy()
            return
        try:
            if type(d)==float:
                self.data[self.ObjID][itemindex]=float(dlg.GetValue())
            elif type(d)==str:
                if len(dlg.GetValue())>=itemlen:
                    raise Exception("Input string too long: got %i, expected maximum %i"%(len(dlg.GetValue()),itemlen))
                self.data[self.ObjID][itemindex]=str(dlg.GetValue())
            elif type(d)==int or type(d)==long:
                self.data[self.ObjID][itemindex]=int(eval(dlg.GetValue()))
            else: raise Exception("Bad type? Got %s"%type(d).__name__)
            newtext=self.Tree.GetItemText(it).split(' : ')[0]+' : '+dlg.GetValue()
            self.Tree.SetItemText(it,newtext)
            item=self.ListBox.GetSelection()
            self.UpdateListBox()
            self.ListBox.SetSelection(item)
            notebook=self.Window.GetParent()
            windowid=notebook.GetSelection()
            notebook.SetPageText(windowid,typenames[self.ID]+'*')
        except Exception,detail:
            ErrorDlg('Error! Value inputted is invalid.\n'+str(detail))
        dlg.Destroy()

    def UpdateListBox(self):
        listdata=[]
        self.ids.sort()
        for i in range(len(self.struct.fields)):
            if self.struct.fields[i][2] in ['Name','title','Subject']:
                for k in self.ids:
                    listdata+=[str(k&0xFFFFFF)+":"+self.data[k][i]]
                break # don't want multiple titles :P
        if not listdata:
            listdata=[str(i&0xFFFFFF) for i in self.ids]
        self.ListBox.Set(listdata)

    def SelectID(self,event):
        ID = event.GetSelection()
        self.ObjID=(self.ID << 24)|(self.ids[ID])
        self.RedrawTree()

    def RedrawTree(self):
        if self.ObjID==-1:
            self.Tree.DeleteAllItems()
            self.Tree.AddRoot("Select an item from the left to begin.")
            return
        if self.ObjID in self.data:
            self.Tree.DeleteAllItems()
            self.struct.AppendToTree(0,self.Tree,self.data[self.ObjID])

    def FindValue(self,val,reset,text=False):
        if reset:
            self.findpos_j=-1
            self.findpos_i=0
        searchval=str(val)
        if self.findpos_j==-1:
            searchlst=self.ListBox.GetStrings()
            for i in xrange(self.findpos_i,len(self.ids)):
                if text:
                    if searchlst[i].find(':')==-1: break # no names
                if ((not text and searchlst[i].split(':')[0]==searchval)
                     or (text and searchlst[i].split(':',1)[1].lower().find(searchval.lower())!=-1)):
                    self.ListBox.SetSelection(i)
                    self.ObjID=(self.ID << 24)|(self.ids[i])
                    self.RedrawTree()
                    self.findpos_i=i+1
                    return
            self.findpos_i=0
            self.findpos_j=0
        for i in xrange(self.findpos_i,len(self.ids)):
            for j in xrange(self.findpos_j,len(self.data[self.ids[i]])):
                if text:
                    if type(self.data[self.ids[i]][j])!=str:
                        continue
                if ((not text and self.data[self.ids[i]][j]==val)
                    or  (text and self.data[self.ids[i]][j].lower().find(searchval.lower())!=-1)):
                    self.ListBox.SetSelection(i)
                    self.ObjID=(self.ID << 24)|(self.ids[i])
                    self.RedrawTree()
                    item=self.Tree.GetPyData(self.Tree.GetRootItem())[j]
                    self.Tree.SelectItem(item)
                    self.Tree.EnsureVisible(item)
                    self.findpos_i=i
                    self.findpos_j=j+1
                    return
            self.findpos_j=0
        self.findpos_i=-1
        self.findpos_j=0
        dlgerror = wx.MessageDialog(None, 'Search Finished',
                              "Note", wx.OK | wx.ICON_INFORMATION)
        dlgerror.ShowModal()
        dlgerror.Destroy()

    def FindText(self,val,reset):
        self.FindValue(val,reset,True)

    def Save(self):
        self.Window.GetParent().GetParent().SetStatusText("Saving...")
        f=open("obj%02i.thd"%self.ID,"wb")
        f.write(pack("II",self.ID,calcsize(self.struct.structfmt)))
        for i in self.ids:
            f.write(pack('II',i,0))
            f.write(pack(self.struct.structfmt,*self.data[i]))
        f.close()
        notebook=self.Window.GetParent()
        windowid=notebook.GetSelection()
        notebook.SetPageText(windowid,typenames[self.ID])
        self.Window.GetParent().GetParent().SetStatusText('')

    def LoadTHD(self,f):
        self.ids=[]
        self.data={}
        ntype,size=unpack('LL',f.read(8))
        if ntype!=self.ID:
            raise Exception("THD header incorrect: Wrong Type Field: Got %i, expected %i"%(ntype,self.ID))
        if size!=calcsize(self.struct.structfmt):
            raise Exception("THD header incorrect: Wrong Size Field: Got %i, expected %i"%(size,calcsize(self.struct.structfmt)))
        d=f.read(8)
        while d:
            objid,crc=unpack('II',d)
            if objid not in self.ids: self.ids+=[objid]
            d=f.read(size)
            self.data[objid]=list(unpack(self.struct.structfmt,d))
            d=f.read(8)
        self.UpdateListBox()
        return True

class MyApp(wx.App):
    def OnInit(self):
        self.frame = MyFrame(None, -1, "GUI THD Editor")
        self.frame.Show(True)
        self.frame.SetStatusText('Loading...')
        for i in range(NUMTYPES):
            if i in excludeIDs: continue
            try:
                LoadDef('%s.h'%typenames[i])
                MyPage(self.frame.Notebook,i)
            except Exception,detail:
                print "ID %i [%s]: "%(i,typenames[i])+str(detail)
                continue
        self.frame.SetStatusText('')
        self.SetTopWindow(self.frame)
        return True

def LoadDef(filename):
    for i in file('defs/'+filename,'r').read().split('};'):
        Struct(i)

LoadDef('common.h')

app = MyApp(0)
app.MainLoop()
