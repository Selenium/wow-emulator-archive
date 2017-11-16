LudmillaSrv.exe is windows service extension for console LudMilla.

If you don't know, "windows services" are processes in windows,
which work in background. Services are not connected with users,
so they works even if there is no user logined.

This application combines 3 logical part in 1 executable:
- As configuration program it allows to setup service, start and stop it.
- As service it works resident, calls console program (Ludmilla) and redirect all input/output to pipes.
- As client it connects to pipes and sends/receives data (interactive communication with Ludmilla).

Common tasks:
- Setup Ludmilla as servise:
	1. Run LudmillaSrv.exe from dir with LudMilla.exe.
	2. Press Register button.
	3. Press Start button.
	4. Run services.msc and set other options if you want.
- Send command to console of Ludmilla
	1. Run LudmillaSrv.exe
	2. Check "Enable" in "Remote control" and write settings if you need to do it remotely, press "login".
	3. Press "Connect" button.
	4. Write command, press "execute".
	5. Read output in console window.
	6. Press "disconnect", "logout", close window.

Note 1: With windows's "services.msc" (Control Panel -> Administrate - > Services)
		you can set action (like "restart service") on service's fault.
Note 2: You must have admin's rights.
Note 3: You can use command line instead of GUI (write "LudmillaSrv.exe /?" for help).
Note 4: Command line options are order sensitive.

FAQ

Q:
What is teh control section used for?

A:
Service redirects all ludmilla's input and output to pipes.
When you press "connect" button, program connects to those pipes, and shows own local console window with ludmilla's output.
If you enter some text and press "execute", this text will be send to pipe and then to ludmilla's input.
Also you can use control section to watch emu's output while ludmilla is loading. Start service and quickly press "connect" - you'll see.

2DO:
Выводить тупые ошибки при конектах/логонах красиво.
Писать в журнал сообщение о смерти людмилы красиво.
Регистрируя сервис, сразу ему авторестарт прописать.