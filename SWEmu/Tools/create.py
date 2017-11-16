#!/usr/local/bin/python
import cgi,os
def reterror(instr):
    print '''<html><head>
    <title>Account Management - Error</title>
    </head>
    <body bgcolor="#000000"><p align="center"><img border="0" src="/banner.jpg" width="800" height="100"></p>
    <p align="center">&nbsp;</p>
    <p align="center">&nbsp;</p>
    <p align="center">&nbsp;</p>
    <p align="center"><font color="#FFFFFF" face="Tahoma" size="2">Error: '''+instr+'''</font></p></body></html>'''
def retmsg(instr):
    print '''<html><head>
    <title>Account Management - Success!</title>
    </head>
    <body bgcolor="#000000"><p align="center"><img border="0" src="/banner.jpg" width="800" height="100"></p>
    <p align="center">&nbsp;</p>
    <p align="center">&nbsp;</p>
    <p align="center">&nbsp;</p>
    <p align="center"><font color="#FFFFFF" face="Tahoma" size="2">'''+instr+'''</font></p></body></html>'''
def process_data():
    formdata=cgi.FieldStorage()
    if (not 'action' in formdata) or (not formdata['action'].value in ['create','change']):
        print """<html>
    <head>
    <title>Account Management</title>
    </head>
    <body bgcolor="#000000">
    <p align="center"><img border="0" src="/banner.jpg" width="800" height="100"></p>
    <p align="center">&nbsp;</p>
    <p align="center">&nbsp;</p>
    <p align="center">&nbsp;</p>
    <font color="#FFFFFF" face="Tahoma" size="2">
    <form method="POST" action=\""""+os.environ['SCRIPT_NAME']+"""\" name="create">
      <p align="center">Username: <input type="text" name="name" size="30"><br>
      Password: <input type="password" name="pw" size="30"><br>
      Password (confirm): <input type="password" name="pw_conf" size="30"></p>
      <p align="center"><input type="submit" value="Submit" name="B1" style="font-family: Tahoma; font-size: 12px; font-weight: bold; color: #0099FF">
      <input type="reset" value="Reset" name="B2" style="font-family: Tahoma; font-size: 12px; font-weight: bold; color: #0099FF"></p>
      <input type="hidden" name="action" value="create">
    </form>
    <form method="POST" action=\""""+os.environ['SCRIPT_NAME']+"""\" name="change">
      <p align="center">Username: <input type="text" name="name" size="30"><br>
      Old Password: <input type="password" name="pw_old" size="30"><br>
      New Password: <input type="password" name="pw_new" size="30"><br>
      New Password (confirm): <input type="password" name="pw_new_conf" size="30"></p>
      <p align="center"><input type="submit" value="Submit" name="B1" style="font-family: Tahoma; font-size: 12px; font-weight: bold; color: #0099FF">
      <input type="reset" value="Clear" name="B2" style="font-family: Tahoma; font-size: 12px; font-weight: bold; color: #0099FF"></p>
      <input type="hidden" name="action" value="change">
    </font>
    </form>
    <p align="center"><font color="#FFFFFF">
    <br>
    Account Creation presented by: Afinda, Spacey, nneonneo</font></p>
    </body>
    </html>"""
        return
    action=formdata['action'].value
    if action=='create':
        if not 'name' in formdata or not 'pw' in formdata or not 'pw_conf' in formdata:
            reterror('One or more required fields are empty.')
            return
        os.chdir('Accounts')
        name=formdata['name'].value
        pw=formdata['pw'].value
        if pw!=formdata['pw_conf'].value:
            reterror('Passwords do not match!')
            return
        if not name:
            reterror('Name is required.')
            return
        if not pw or len(pw)<4:
            reterror('Password must be at least 4 characters long.')
            return
        if len(name)>32 or len(pw)>32: #someone's been trying to hack the form. Oh noes!
            reterror('Invalid data.')
            return
        if not name.isalnum(): #can't have invalid characters
            charset="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_- !()[]^"
            for c in name:
                if not c in charset:
                    reterror('Name contains invalid symbols. Only these characters are allowed: _- !()[]^')
                    return
        if os.access(name,os.F_OK):
            reterror('Account '+name+' already exists.')
            return
        f=open(name,'wb')
        f.write(name.ljust(32,'\x00'))
        f.write(pw.ljust(76,'\x00'))
        f.close()
        retmsg("Account "+name+" was successfully created.")
        return
    if action=='change':
        if not 'name' in formdata or not 'pw_old' in formdata or not 'pw_new' in formdata or not 'pw_new_conf' in formdata:
            reterror('One or more required fields are empty.')
            return
        os.chdir('Accounts')
        name=formdata['name'].value
        pw=formdata['pw_old'].value
        newpw=formdata['pw_new'].value
        if not os.access(name,os.F_OK):
            reterror('Account '+name+' does not exist.')
            return
        f=open(name,'rb')
        f.read(32)
        oldpw=f.read(32).rstrip('\x00')
        f.close()
        if pw!=oldpw:
            reterror('Password for account '+name+' is wrong!')
            return
        if newpw!=formdata['pw_new_conf'].value:
            reterror('New Passwords do not match!')
            return
        if not name:
            reterror('Name is required.')
            return
        if not newpw or len(newpw)<4:
            reterror('New Password must be at least 4 characters long.')
            return
        f=open(name,'wb')
        f.write(name.ljust(32,'\x00'))
        f.write(newpw.ljust(76,'\x00'))
        f.close()
        retmsg("Account "+name+" was successfully modified.")
        return
process_data()
