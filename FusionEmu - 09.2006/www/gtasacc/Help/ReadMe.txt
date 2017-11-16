GTA San Andreas Control Center Read-Me

This is our latest open source trainer project for GTA Series. We hereby thank to 
all coders for finding memory locations, coding several functios and gtaforums.com 
for providing us a communication platform during the development of the control center. 
The GTA SA Control Center is a moddable trainer with several controls for player, 
vehicle, weather and gameplay, integrated garage editor with mod support, integrated 
cheat inserter and editor, a teleport center with game map for visual teleporting, 
123 console commands freely mappable to keyboard for in-game controlling, and several 
bonus features. The control center currently supports the v1.0 and v1.1 of GTA SA. 
Some functions are bound to SCM, and are available only if you are using the original 
SCM. If you uncheck the 'is SCM Original' checkbox on Page 6, you can use the control 
center safely for all functions, except for the girlfriend progress controls (which 
then become disabled).

Installation:
You do not have to use the Full-Installer to run the control center. However, you will 
still need following microsoft user-controls, and Microsoft Visual Basic 6 Runtime SP6: 
Comdlg32.ocx
Mscomctl.ocx
Tabctl32.ocx

If you have decided for a manual install, just unpack the zip in a clean folder, 
make sure that the car pictures are copied in a subfolder named: \CarPics 
Following files are configuration files of the control center, and they will 
automatically be created in case they are inconsistent, or do not exist:
GTASACarPics.dat
GTASACheats.dat
GTASAConfig.dat
GTASAConsole.ini
GTASAData.dat
GTASALocs.dat
Please see the Appendix A for detailed description of these files, and how to 
edit them to mod control center.

General Control Logic:
All of the user-controls on the control center form have tool-tips. Please read the 
tooltips in case you are not sure what the given control does, and how to use it. 
Dynamic Game, Player and Vehicle values/stats are mostly controlled with a checkbox, 
a scroll-bar and a button. The checkbox represents the value of the value on its 
caption. You can alter the value using the scroll-box. If GTA SA is running, and 
you have loaded / started a game, the relevant value will automatically be changed 
in game memory. The button will change the scroll-value to a value that is represented 
on the button caption (either 0 or max). If you check the checkbox, the value you have 
set will be locked, and the in-game memory will accordingly set to this value as soon 
as this value gets changed by the game. GTA SA is not always happy with us changing 
its memory too much, so each locked status bring a small crash risk. If you are using 
the control center with all the stats locked, please save your game progress often. 
If you want to alt+tab out of the game to use the control center, please click ESC 
first to bring-up the game menu, and then alt+tab out of the game. GTA SA is also 
not happy with players that leave gameplay in the middle of some DirectX animations.
GTA SA Control Center needs to syncronize to the game in full due to excessive memory hooks. 
Please start the control center after you have started gta_sa, and loaded/started a game. 
If your system does not allow you to alt+tab out of the game to start the control center, 
you can also start the control center first, then the game. However, in this case, please 
avoid hitting any of the shortcuts that you have defined until your savegame is fully 
loaded, or a new game has fully started. Please also give a couple of seconds for the 
syncronization before you use the shortcut keys. 
If you also want to disable the message box that says you need to start control center 
after you have started the game, please edit the GTASAConsole.ini file, and find the line 
InfoMsg=1 and change it to InfoMsg=0 

Page 1: Vehicle and Game Data
Control Center helps you out with almost all concepts related to vehicles. 
You can set your current car to Explosion-proof (EP), Damage-proof (DP), 
Bullet-proof (BP) and Flame-proof (FP). You can also lock these properties by checking 
the "Prevent Car taking damage from" checkbox. That is, these specialities will be 
carried to every car you get in, or set back in force when GTA SA changes them after 
some cutscenes. If you do not prefer setting your car to DP, you can also control 
the engine health using the relevant scroller. You can lock the engine health to 
a given pct. Please note that GTA changes the engine health to different values 
during missions, and if you lock the engine health using the control center during 
missions, GTA renders your vehicle as non-usable, resulting the car any the player 
to explode. Please use the 'do not burn' and 'do not explode' checkboxes to prevent 
the car burning / exploding due to damage caused by collisions. Also, the wheel damage 
is handled separately in GTA SA. You can check the 'prevent wheel damage' checkbox 
to prevent wheels of your car, and the car/trailer you tow from getting any damage. 
As you check this checkbox, your tires will also automatically be repaired. 
If you change the weight of a car in handling.cfg, all cars of that type will have the 
same weight. On the Control Center, you can change only the weight of YOUR car. That 
is, if you set your car to 400 Tons, you can kick everything out of city boundaries, 
including the same type of cars as you drive. If you lock this setting, the car weight 
will be adjusted for your new cars as soon as you get in a new car. You will also get 
an on-screen feedback on the current status of your new car. By changing the car 
weight, the max speed, grip and suspension levels are automatically normalized to 
the new car weight so that you will not notice any handling changes as you change the 
car weight. Setting the car weight to 100 Kg's is a lot of fun. You can drive 
around as you like, but if you hit people, you will be thrown several hundread 
meters away. The Damage-proof speciality is also set by changing the car weight. 
Higher weights over 2 Tons let you crush other cars, but if you hit a wall, your car 
gets the same damage itself. So it is too risky to drive a 50 Ton car without the 
damage-proof speciality. The Car Specialities and 'Prevent Wheel Damage' checkbox 
sets the relevant dynamics for the vehicle you are driving, and the vehicle or 
trailer that you are towing.
You can lock or open your car doors by selecting 'open' / 'locked' option boxes. 
If you also check the "Car Doors" checkbox, console decides for you: If you like 
to keep your doors locked, your doors will be locked as soon as you get in any car. 
They will also be locked after you get out. However if you try to get back in the 
same car, they will be opened for a second to let you in (please assign 'open car 
doors' console command to the same key that you use to enter a vehicle in game)
The cars have 2 main colors in GTA SA. A major and a minor color. The major color is 
the color of most parts of the car. The minor color is for example the color of the stripes. 
You can paint both of the colors of your current car by doubleclicking on the 
assigned color box. You will then get a color selection window as in the garage 
editor. The available car colors are originally read from the carcol.dat file in GTA SA 
directory. If you have modded the car colors in game, you can also mod the control 
center to respect these changes. On car selection dialog window, you can select the 
color by doubleclicking, or by clicking on the color and then "OK" button. Cancel 
returns back without any changes. By using the checkboxes in the Major and the Minor 
Colorboxes, you can lock the color. If you also check the "Car Color:" checkbox, 
your new car will also be painted as soon as you get in.
Some parked cars have alarms. If you check the 'automatically stop car-alarms' 
checkbox, the control center checks the alarm status of the car as you enter in,
and sets the alarm back in case it goes off.
A new concept in GTA SA is that the vehicles get stalled if you fall in water, or crash 
too hard. Normally, the car would not survive in both cases, but using the control 
center you can bring the car out of the water. The engine remains however stalled, 
and you cannot drive the car until you get out, and get back in. To prevent that, 
you can check the 'automatically restart car when stalled' checkbox, and your car 
engine will always run.
On some missions, you need to contol a RC car and drive/fly it as necessary. 
The 'control also RC cars' checkbox will help control center properly initialise this 
RC vehicle, so that you can apply normal vehicle specialities (as EP/DP.., weight, etc.) 
to the RC car, increase its speed, take a markup location, and transport this RC vehicle 
to the markup location.
There is another new concept in GTA SA: the number plates on the applicable vehicles. 
This function is under construction, but with the next version of control center, you will 
be able to not only read (as in this version) but also set the number plate on your vehicles.
In GTA SA, you can normally fly with planes and helicopters, but not with cars. 
The flight assistance helps you freeze your car on air, so that you can 'fly' with 
your car as if you were flying an UFO. In that case, please use the speed console 
commands to control the car on air, as normal in-game controls will not work on air. 
Please note that the 'flight assistance' is not for the planes, as it freezes the 
vehicle on air, rendering in-game plane flight controls useless. Flight assistance 
automatically sets the Z speed to a given percentage if your car starts to fall. 
You can select the Flight-assistance percent from the scroll box. This percentage 
level is car specific, and 100% is the maximum speed that your car can reach by 
free-falling. So if you keep the percentage around 2% or 3%, your car will hang in 
the air like a heli. (it will move up and down very slightly due to wind conditions.)
GTA SA uses a three dimensional speed and spin model. Movements in X dimension heads 
to North for positive values of X, and South for negative values. Positive values of 
Y heads to East, and negative values to West. For Z speed, positive values makes the 
car go up, and negative, go down. The Percentage levels are from -400% to +400%. 
That means you can set the speed of your car up to 4 times of its max speed. The 
spins are also much like the same for X and Y spins. The positive values of Z spin 
causes a spin in counterclock direction, and negative values in clock direction. 
With the "stop" buttons near the relevant spin/speed values, you can stop the speed 
or spin in only one coordinate, or in all coordinates (freeze car). 
The Set Car Direction options are for setting your car in 8 directions (North, 
Northeast, East, Southeast, South, Southwest, West, Northwest), fully leveled to 
the ground. Kickstart Car function sets the car position as in Set Car direction 
function, and gives the car additionally a car-speed on the direction. The speed 
level is also adjustable in percentages. The "Don't Burn" and "Don't Explode" 
checkboxes are for automatically controlling the car damage and burn status. 
If you choose "Don't Burn", the "Don't Explode" option is also checked. That is, 
if your car starts burning, the burning flag will be set back, and your car will 
be repaired automatically (except for the textures). If you choose only the 
"Don't Explode" option, and your car starts burning, it will burn forever, but 
never explode as long as you are in the car. The "Flip Car" button flips the car 
on 4 wheels, and back. 
In case you load another saved game, or start a new game, GTA SA might assign a 
new pointer to the player in memory, and some player and car specific commands 
do not work. Please restart the control center, or click on 'Re-sync to GTA SA' 
button to re-syncronize all the game pointers. With the 'set money' button, you 
can enter a money value to set the in-game player money amount to the given amount.
If you cheat within the game using the GTA SA internal cheats, a 'cheated' flag 
gets set, and everytime you want to save your game, you get a nag screen. By 
clicking on the 'clear cheated status and count' button, you can set this flag 
back to zero, and clear the stats value 'Times cheated' in GTA SA.
The GTA San Andreas game time respects the time, and weekday, but not the months 
or seasons. Using the scroll-box or console commands, you can game time in hours. 
The control center takes care of the changes in weekdays and days passed in game 
as you change the game time. In the in-game clock, the clock speed is set to 
1 real seconds = 1 game minutes. You can change this value using the relevant 
scroll-box, completely freeze the game clock, set it to 1 real minutes = 1 game 
minutes, or any other value, represented as percentage to original game clock 
speed. The game speed is controlled seperately. Using the assigned scroll-box, 
or the console command, you can change the game speed from 10% to 1000% of the 
original speed. Please note that the changes in game speed changes the complete 
game-play, so slowing down means that the player and movement animations, the 
game respond to your mouse and key controls also slow down.
The Game Time, Clock Speed and Game Speed sliders will start with the caption 
'(unknown)' until the game values are read from GTA SA. You can then change these 
values as you like.
There are 46 different weather animations in game from scorching hot to storming 
weather. The 'Current Weather' selection combo represent the current weather in 
game. As you pick a new weather from the combo, the game weather automatically 
gets set. The new weather will remain for a while, and will automatically get 
re-set to another value that is relevant to your location in game (ie. you get 
sand-storms only in desert etc.). The selected weather remains for about 5 to 10 
minutes. You can also set the weather selection as a keyboard shortcut to change 
game weather using shortcut keys. If you lock the selected weather, gta sa will 
still change it for day/night animations, but the weather specifications like 
rain or clear sky will remain unchanged (ie. locked). You can also set the weather 
selection as a keyboard shortcut to change game weather using shortcut keys.
GTA SA has introduced the girlfriends concept to game-play, and yes, you can 
change / lock the ongoing process with the girlfriends. Please note that you have
to have the given girl as girlfriend so that these sliders actually work. As you 
get a new girlfriend, the progress gets set to 20% by the game. Also, if you have 
set the on-going girlfriend progress to 100% using the control center, you will 
still have to date with the girlfriend once more to get the girlfriend specific 
presents. The girlfriend progresses are coded within the SCM block, and those 
sliders only work if you are using the standard SCM. You can still experiment 
with the progress sliders. If you are lucky, they might still work. If not, your 
ongoing game will get damaged. For this reason, we have implemented the checkbox 
'is SCM Original' on Page 6 of the control center to leave this decision to you.
The Car Spawner function is courtesy of Jacob. This function requires an ASM code 
to be injected to the executable. The control center checks if the code is already 
injected or not. If injected, you can use the spawn car button and the relevant 
console command to spawn any kind of vehicle right in front of the player. The 
control center also checks if the code is injectable or not. If you are using 
a gta_sa.exe version that we have not yet tested, this checkbox will remain 
disabled with the status caption 'code not injectable'. If the code is injected, 
you can select a vehicle from the combo box to spawn, or click on 'pick' button 
to bring the garage editor car selection screen to select one of the vehicles.
Please note that the car selection screen has only parkable vehicles. You can 
however spawn all vehicles using the combo's and the relevant console command.
The injection code is extended some more on the version 2.1, and now takes care 
of proper initialisation of weapons, ie. works for spawning weapons. Please 
inject this code if you want also to change/lock the player weapon specs.

Player Data:
On this page, you can control almost all of the player specific values and stats.
You can set player specialities Explosion-Proof / Collision-Proof / 
Bullet-Proof and Fire-Proof using the checkboxes. Please use the 'Prevent Player 
taking damage from:' checkbox to lock these specialities, as they get set by GTA 
after some cut-scenes. These specialities are self explanatory, and are just like 
the car specialities. You can also set or lock Player Armor and Health to a given 
level from 0 to 1000. Control Center will check your health and armor 10 times a 
second and set the values back. However, there are cases that the player gets wasted 
although the health level is 100%. For example, if you are free-falling with a 
parachute, and do not open your parachute, you get wasted, or if you are in a 
vehicle, and the vehicle explodes, you get wasted etc. For free-falling without 
parachute, if you have set your health over 160, you survive no matter how far or 
how long you have been falling down. 
There is one set of user-controls for each changeable stat for the player. You can 
change these stats using the relevant sliders, max them using the buttons, and lock 
the stat to your selected value to prevent GTA changing for example your FAT Stat 
after you eat something greasy. There are 10 different weapon specialities. On this 
page, you can see the average weapon proficiency level, max all proficiencies, or 
click on 'Show detailed weapon proficiency stats' button to bring the weapon 
proficiency editor window to change each level as you like. 
The player X/Y/Z Speed values, 'stop all speed' button, the Ped Direction and 
'Kick Start' controls, as well as the 'ped flight assistance' slider and checkbox 
help you control the player as if you were controlling the car. Please note that 
the speed and direction values are relevant to player's in-game environment. If 
player is driving a car, his speed is zero, no matter how fast he drives, as the 
speed is relevant to his car, and he is sitting.
There are 12 weapon slots in GTA SA. You can change the weapon, or the amount of 
ammo using the combo boxes and ammo entry. As you change the weapon or ammo, the 
background color of the entry boxes will become green, indicating that they can be 
written into memory. Please click on the button next to ammo entry textbox to write 
the changes into memory.
On this page, you find also the injectable cheats (so far 20). The control center 
checks the current cheat activation status and represents this as checked/unchecked 
on the relevant cheat checkbox. If you have locked the cheat status, control center 
will overwrite the cheat status to your selected value accordingly. The 'Infinite Run' 
and 'Fireproof' are not real cheats, and gets set to 1 by GTA as you complete the 
Paramedic and Fire-fighter missions. So please use these at your own risk if you 
are not using the original scm. These two checkboxes do not get disabled as you 
uncheck the original scm checkbox. The reason is, even if you are using a modded 
SCM, it is unlikely that the fire-fighter and paramedic sub-missions are also 
modded. However, if these are also modded, you will damage your ongoing game.
The checkbox 'autoclear status after inserting cheats' will check your cheated 
status, and if you have entered a cheat code using the keyboard, or using the 
control center, the cheated flag will automatically get reset to zero.

Garages:
There are 17 garages in GTA SA, each holding up to 4 vehicles. The garages are of 
different sizes, but still can hold up to 4 vehicles. The control center will try 
to park the vehicles at optimized locations within the parkable area of the given 
garage. However, if you park 4 cars in a small garage, you might not get in any of 
the cars, or the cars might get stuck into eachother. Each time you alt+tab out of
the game, the control center reads your garages, and shows the parked vehicles with 
all modding details, colors etc. You can change car specialities, park new cars in 
garages using the vehicle selection combo, or vehicle selection form, or mod your 
vehicles using the vehicle mod selection window. Which vehicles are parkable, and 
what kind of mods each vehicle can have, which color will be assigned to a newly 
selected vehicle is set in GTASAData.dat file. You can edit this file to change 
the garage editor behaviour. You can also lock the specs and the parked cars using 
the checkbox for each garage. In that case, the control center will check the garage 
door status during game play, and as a garage door closes, it parks the selected 
vehicles automatically in the given garage. So if you drive a car out of a garage, 
the car gets aoutomatically reparked. However, if you park a new car, it will 
disappear, as the control center will change the garage. This applies to the mods 
as well. If you have previously selected a mod for a vehicle, and locked the 
garage specs, the current mods also gets changed on the vehicles automatically. 
The garage editor respects also the special abilities of given vehicles as well. 
So if you park a monster truck in a garage using the control center, it will have 
rear-wheel dynamics. After changing the parked vehicles, please do not forget to 
click on 'Write garages to GTA SA' button, so that your vehicle selection can be 
written back to the GTA SA memory. You can save / load your favorite selection 
from the ini file using 'read garages from ini' and 'write garages to ini' buttons.
If you have changed your garages, but want to cancel your changes, please click 
on 'read garages from GTA SA' button to reread the game memory. The Vehicle 
Selection window reads its settings from the GTASACarPics.dat file. Please edit 
this file if you want to change the tabs that the vehicles are assigned to. In 
addition to 12 vehicle category tabs, there is a 'favorites' tab to help you in 
selecting vehicles. Using the right mouse click, you can assign a given vehicle 
to favorites, or remove a vehicle from favorites. The thumbnails are courtesy of 
www.g-unleashed.com, and they are from the X-Box version of GTA SA. So the car 
pictures may slightly differ from the PC version. The '*' column near the car 
thumbnail represent the Sex Appeal of the car as informaiton. The descriptions 
are also from g-unleashed.com. If you want to read the full description, you can 
resize the Description column on this selection list-box and scroll right to read.
You can edit/change car names, descriptions and thumbnails by editing the relevant
files (see appendix). The garages are represented on 4 tabs, LS/SF/LV/Desert, 
respecting their locations in game, and the available space on the control 
center.

GTA SA Cheats:
The GTA San Andeas PC version has over 70 cheats that you can type-in during game 
play to activate / deactivate. This control center section is for organizing these 
cheats in a readable tree structure. You can also create your own cheat combinations 
by entering the cheat codes after each other in Cheat String textbox, and giving the 
combination a new name that you can select on Keyboard shortcuts page to assign to 
a key. This section is only to assist you on entering the GTA SA internal cheats 
during gameplay. So the cheat-insertion works only during gameplay using console 
commands. The selected cheat string gets typed into the game as if you were typing 
it using the keyboard. Please note that, as the cheat strings get inserted to the 
keyboard, the control keys can also get pressed. So if 'C' is assigned to 'Croach',
and you insert the cheat 'Recruit anyone (Rockets)' cheat 'ROCKETMAYHEM', the 'C' 
gets also pressed, and player croaches. As you can also find in internet, there are 
several key combinations that activate the same cheat. (ie. 'ZSOXFSQ' activates also 
the 'Recruit anyone (Rockets)' cheat. So some of the cheats are listed more than once
in the treeview.
As with other 2 treeviews in the control center, you can edit the label of selected 
cheat or folder using the right-click context menu. If you select 'Move to folder' 
from the context menu, a window with all available folders will be shown for you to 
select. You can also move folders including all sub-elements to other folders. 
You can also insert a new folder, or delete selected folder or cheat from the list. 
On selecting a cheat from treeview, the cheat-string is shown in the relevant textbox. 
You can edit this, and then click on 'Apply changes' to apply your changes to the 
selected cheat, click on 'Insert as a new cheat' to create a new entry in the 
treeview. You can then edit the newly generated label. After changing cheats, or 
the folder assignments, please click on 'save changes to config file' to save 
chagnes, or click on 'read cheats from config file' to revert to last saved. If 
you have changed any of the settings, but have not saved, upon exiting the control 
center you will be asked if you would like to save configuration changes. Select 
'yes' to save all changes.

Locations:
The GTA SA Map has a size of 6000 x 6000 Game Points. The scaling factor of how many 
game points makes a mile is actually unimportant. On the locations tab, you have 
a full size GTA SA Map with zoom possibility from 50% to 400% of the map size.
Using the sliders on the left and bottom sides of the map, you can scroll within 
the map. the '#' button on bottom-left corner centers the map on visible area. 
As you alt+tab out of GTA SA, the control center automatically reads the player's
in-game location and represent this as a red box on the map. If you click on 'read 
from GTASA' button, the player's in-game location gets read into X/Y/Z coordinate 
text-boxes and the Angle textbox, with up to 6 decimal positions. You can also set 
a location with left-click on the map. This location is represented with a blue box.
If you click on the 'read from map' button, the X and Y values are read from the 
blue box and assigned to the relevant text boxes. Please note that this map is two 
dimensional, and you have to enter the Z Coordinate and Angle manually. You can also 
enter all coordinates manually, and click on 'show on map' to set the position of 
the blue box to these coordinates. Click on the 'teleport' button to teleport the 
player to the coordinates in the text boxes. 
This page has also a treeview for saving and organizing teleport locations. The 
utilization of this treeview is similar to the one on cheats tab. You can select 
a location or a folder from the treeview, and right-click on it to bring-up the 
context menu, then select the 'show on map' command to show the location(s) on 
map with yellow boxes, each box having the location label as tool-tip text, and 
a context menu to teleport to. If you select one location from the treeview and 
select show on map context menu, the map on left will get scrolled so that the 
newly shown yellow-box is on sight, and the size of the box changes twice to attract 
your attention. You can change the default size of these small location boxes to 
different values using the context menu of the map. Also the 'hide locations' 
context menu hidex all yellow boxes that are shown on the map.
The Locations are saved into the GTASALocs.dat file. Please see the appendix on 
how to edit this file manually.

Keyboard Shortcuts:
The Keyboard shortcuts, aka. Remote-Control page helps you to assign keyboard 
shortcuts to any of the more than 120 console-commands, GTA SA internal cheats 
(as defined in the relevant tab) and the teleport locations (also defined in 
the relevant tab).
You can assign the same key to several commands to enable the consequtive 
execution of a series of commands with one key. The main part of this tab is 
the treeview to help you organize your shortcuts in freely-definable folders. 
The usage of this treeview is also similar to other treeviews, with context 
menu's to edit labels, move shortcuts to other folders and activate/deactivate 
a given shortcut. You can also activate / deactivate all items within a folder 
if you select the relevant menu item from the folder context menu on the 
treeview. 
You can use one of the three main category selection combo's to start generating
a new shortcut. If you drop the 'GTASA Internal Cheats' combo, you will see all 
of the cheats that are listed on the relevant tab of the control center in 
alphabetical order. You can edit the labels on the cheats tab to alter the sort 
order on the cheat selection combo. The location selection combo also works in 
the same manner. The console command selection combo however has been getting 
new entries with each update to the control center, and in order to preserve 
backwards compatibility to previous versions, and the shortcut selections of 
the users, this list is not sorted in any way. For each console command, there 
are 19 different types of additional settings, that gets visible as you select 
an item from the command combo. If a console command needs no additional data, 
or you have selected a teleport location or a gta sa internal cheat, you will 
see the label 'No Additional Data is needed' at this location. Please see next 
section for detailed descriptions of each console command and selectable additional
values. After you have selected the command/cheat/location, you can select one 
of the keys from the drop-down combo. This list has only standard keys, to 
assure the stability of the control center between highly diversified keyboard 
layouts. You can also check one of the 'CTRL' or 'ALT' checkboxes as well. You 
cannot however select 'CTRL' and 'ALT' at the same time, again, for the stability
of the control center. The keyboard shortcuts are read without setting a global 
keyboard hook in order to increase Operating System stability. MS Windows is 
not always happy with a program hooking keyboard of another program, or a 
global keyboard hook. After you have selected your command and the key to 
assign it to, you can click on 'apply changes' to apply this selection to the 
selected treeview element on the treeview, or click on 'insert as a new shortcut'
to insert a new element into the active folder with these settings. The new element
will have your command and key selection as label. You can however edit this label
to your own needs. 
The Keyboard Control Interval slider is for you to select how often the keystrokes 
should get checked during gameplay. This affects your overall PC performance. 
(A keyboard hook has a 1 ms control interval). If you set this to a high value, 
the control center can be too slow to react to your keys, and if set to very low 
value, the pressed keys might trigger the same command several times, making the 
toggle commands harder to use within game play. The keyboard will be checked only 
if GTA SA has the full focus in order to save system resources. This setting also 
alters the way the flight assistance works. If you set the control interval too low, 
you might need to decrease the flight assistance level to have proper freezing on air.
As you use console commands assigned to keys during gameplay, you can receive an 
in-game feedback if you check the 'In-Game Feedback Messages' checkbox.
The 'is SCM Original' is for you to decide if SCM relevant commands and sliders 
should work or not. As discussed before, with a modded scm, these commands might 
work, but if they do not, they will most probably damage your ongoing game process.
The GTA SA Version selection combo is to select between the different versions 
of GTA. Currently, the original dvd version 1.0 and the german update to v1.1 is
supported. Please restart the control center after changing the version to ensure
proper operation.

Console Commands: 
There are 122 internal console commands in this version. 
Most of the commands accepts/requires additional parameters that you can also 
select from Keyboard shortcuts page. Here is the listing of all available 
commands, what parameters they accept and what they do:

* Set Armor Level to: (slider: 0 to 1000)
  Sets the Armor Level to a given value, selectable from 0 to 1000.
* Auto-Fix Armor Level to: (slider: 0 to 1000)
  Sets the Armor Level to a given value, selectable from 0 to 1000, and sets the 
  Armor-Level-Lock as well.
* Auto-Fix Armor: (ON/OFF)
  Sets or releases the Armor-level-lock
* Set Health Level to: (slider: 0 to 1000)
  Sets the Health Level to a given value, selectable from 0 to 1000
* Auto-Fix Health Level to: (slider: 0 to 1000)
  Sets the Health Level to a given value, selectable from 0 to 1000, and sets the 
  Health-Level-Lock as well.
* Auto-Fix Health: (ON/OFF)
  Sets or releases the Health-level-lock
* Set Car Specialities to: (BP/DP/EP/FP)
  Set the selected car specialities.
* Auto-Fix Car Specialities: (ON/OFF)
  Sets or releases the Lock for Set-Car-Specs for new cars.
* Set Car Doors to: (open/locked)
  Sets car doors to open or closed as selected.
* Auto-Lock Car Doors: (ON/OFF)
  Sets or releases the Auto-Lock car doors function.
* Prevent Wheel Damage (ON/OFF)
  Sets or releases the Prevent-Wheel-Damage Lock.
* Set Engine Health To: (slider: 0 to 400%)
  Sets engine health of the current/last car to the selected level.
* Auto-Fix Engine Health: (ON/OF)
  Sets or releases the lock to Engine Health level.
* Set Car Weight to: (slider: 0.1 to 400 Tons)
  Sets the current car weight to the selected level.
* Auto-Fix Car Weight: (ON/OFF)
  Sets or releases the lock to car weight for new cars.
* Paint My Car To: (selection of major/minor colors)
  Paints the current car with the selected colors.
* Auto-Paint My Car: (ON/OFF)
  Sets or releases the lock to car colors for new cars.
* Stop Car Alarm: (ON/OFF)
  Sets or releases the lock to car alarm for new cars, stops the current car 
  alarm if set to ON.
* Set Car Direction to: (selection of directions as North, Northeast etc.)
  Sets the car direction as selected, and levels the car to the ground.
* KickStart Car to: (selection of speed percentage and directions as North, NE...)
  Sets the car direction as selected, levels the car to the ground, and gives 
  the car a kick-start with the selected speed.
* Flip Car Back on 4 Wheels (no additional data needed)
  Flips car over on 4 wheels and back.
* Stop X Speed (no additional data needed)
  Stops the North-South speed.
* Stop Y Speed (no additional data needed)
  Stops the East-West speed.
* Stop Z Speed (no additional data needed)
  Stops the up-down speed.
* Stop All Speed (no additional data needed)
  Stops all speed of the car.
* Stop X Spin (no additional data needed)
  Stops nose up/down spin.
* Stop Y Spin (no additional data needed)
  Stops sideways spin.
* Stop Z Spin (no additional data needed)
  Stops clock/counterclock direction spin.
* Stop All Spin (no additional data needed)
  Stops all spin of the car.
* Stop All (Freeze Car) (no additional data needed)
  Freezes the car.
* Set X Speed to: (slider: -200% to +200%)
  Sets the North-South speed of the car to the given level.
* Set Y Speed to: (slider: -200% to +200%)
  Sets the East-West speed of the car to the given level.
* Set Z Speed to: (slider: -200% to +200%)
  Sets the Up-Down speed of the car to the given level.
* Set X Spin to: (slider: -200% to +200%)
  Sets the Nose up/down spin of the car to the given level.
* Set Y Spin to: (slider: -200% to +200%)
  Sets the sideways spin of the car to the given level.
* Set Z Spin to: (slider: -200% to +200%)
  Sets the clock/counterclock spin of the car to the given level.
* Increase X Speed by: (slider: -200% to +200%)
  Increases the North-South speed of the car by the given level.
* Increase Y Speed by: (slider: -200% to +200%)
  Increases the East-West speed of the car by the given level.
* Increase Z Speed by: (slider: -200% to +200%)
  Increases the Up-Down speed of the car by the given level.
* Decrease X Speed by: (slider: -200% to +200%)
  Decreases the North-South speed of the car by the given level.
* Decrease Y Speed by: (slider: -200% to +200%)
  Decreases the East-West speed of the car by the given level.
* Decrease Z Speed by: (slider: -200% to +200%)
  Decreases the Up-Down speed of the car by the given level.
* Increase X Spin by: (slider: -200% to +200%)
  Increases the Nose up/down spin of the car by the given level.
* Increase Y Spin by: (slider: -200% to +200%)
  Increases the sideways spin of the car by the given level.
* Increase Z Spin by: (slider: -200% to +200%)
  Increases the clock/counterclock spin of the car by the given level.
* Decrease X Spin by: (slider: -200% to +200%)
  Decreases the Nose up/down spin of the car by the given level.
* Decrease Y Spin by: (slider: -200% to +200%)
  Decreases the sideways spin of the car by the given level.
* Decrease Z Spin by: (slider: -200% to +200%)
  Decreases the clock/counterclock spin of the car by the given level.
* Clear Cheated Status (No Additional Data is needed)
  Clears the cheated status and cheated count
* Set Clock Speed to Real Time (No add. data is needed)
  Sets the Clock speed to 1 real minutes = 1 Game-clock minutes
* Set Clock Speed to Normal Game Time (No add. data is needed)
  Sets Clock speed to original value (1 real seconds = 1 game minutes)
* Set Car Speed To: (slider: -200% to +200%)
  Sets Car speed to the given value. The car speed will be set according to the 
  current positioning of the car, so this can be used as a turbo-switch.
* Increase Car Speed by: (slider: -200% to +200%)
  Increases Car speed by the given value. The car speed will be set according to 
  the current positioning of the car, so this can be used as an additional kick 
  to the current cruise speed, or to 'drive' on air.
* Flight Assistance: (ON/OFF)
  Activates or deactivates the vehicle flight assistance.
* Flight Assistance Level: (slider: 0% to 100%)
  Sets the flight assistance level as selected.
* Release from Camera-Lock (no additional data is needed)
  Releases 'flying' car from the stunt-camera locks. This is not yet available.
* Silent Mode (no Feedback): (ON/OFF)
  Activates or deactivates the on-screen feedbacks from the Control Center.
* Stop Alarm of my car (no additional data is needed)
  Stops the alarm of the current car.
* Take me to my last car (only if on Foot) (no additional data is needed)
  Warps the player near his last car, ready to get in.
  (if the car is still available within GTA SA)
* Bring my last car to me (only if on Foot) (no additional data is needed)
  Brings the last car of the player to him, and turns the car so that player can 
  just get in. Do not use this function if the player is facing to a wall :)
  (if the car is still available within GTA SA)
* Take me to my previous car (only if on Foot) (no additional data is needed)
  Warps the player near his previous car, ready to get in.
  (if the car is still available within GTA SA)
* Bring my previous car to me (only if on Foot) (no additional data is needed)
  Brings the previous car of the player to him, and turns the car so that player 
  can just get in. (if the car is still available within GTA SA)
* Remember my location as Markup Location (selection of 10 markup locations)
  Reads the player and car coordinates and keeps in one of the 10 markup location 
  variables as selected. These gets also saved in the ini file.
* Take me to Markup Location (selection of 10 markup locations)
  Teleports the player and car to the selected markup location coordinates,  
  provided that the selected markup location is already set. The markup locations
  gets saved to the ini file, so they are still available after you restart the
  control center.
* Set Doors of my Preivous Car to: (open/locked)
  Locks or opens the doors of the previous car as selected.
* Turn My Car in Clock Direction by: (slider: 0 to 180 Degrees)
  Turns the car in clock direction by selected amount of degrees.
* Turn My Car in Counterclock Direction by:  (slider: 0 to 180 Degrees)
  Turns the car in counterclock direction by selected amount of degrees.
* Torch my (last) car (no additional data is needed)
  Torches the last car that the player is/was in.
* Torch my previous car (no additional data is needed)
  Torches the previous car that the player was in.
* Set Game Speed to: (slider: 10% to 1000%)
  Sets the game speed to the selected value.
* Increase Game Speed (No Additional Data is needed)
  Increases Game Speed by one tick of the slider.
* Decrease Game Speed (No Additional Data is needed)
  Decreases Game Speed by one tick of the slider.
* Freeze Game Clock (No Additional Data is needed)
  Sets the Game Clock Speed to 3600 real minutes = 1 game minutes
* Thaw Game Clock (No Additional Data is needed)
  Sets Game Clock back to original (1 real seconds = 1 game minutes)
* Teleport to next Location (No Additional Data is needed)
  Teleports the player to next location in the locations tree-view.
  If currently no locations are selected on the treeview, teleports to
  the first location, and by each consequtive call, teleports to next.
* Teleport to previous Location (No Additional Data is needed)
  Teleports the player to previous location in the locations tree-view.
  If currently no locations are selected on the treeview, teleports to
  the last location, and by each consequtive call, teleports to previous.
* Prepare for Date with Denise (No Additional Data is needed)
  Teleports player to pickup location of Denise
* Prepare for Date with Michelle (No Additional Data is needed)
  Sets Player Fat stat to 750, and then teleports player to pickup 
  location of Michelle.
* Prepare for Date with Helena (No Additional Data is needed)
  Sets Player Fat stat to 0, Muscle Stat to 200, and then teleports 
  player to pickup location of Helena.
* Prepare for Date with Katie (No Additional Data is needed)
  Sets Player Muscle stat to 1000, and then teleports player to pickup 
  location of Katie.
* Prepare for Date with Barbara (No Additional Data is needed)
  Sets Player Fat stat to 750, and then teleports player to pickup 
  location of Barbara.
* Prepare for Date with Milie (No Additional Data is needed)
  Teleports player to pickup location of Millie.
* Toggle Never Wanted (No Additional Data is needed)
  Toggles 'Never Wanted' cheat status to on/off.
* Toggle Never Get Hungry (No Additional Data is needed)
  Toggles 'Never Get Hungry' cheat status to on/off.
* Toggle Infinite Health (No Additional Data is needed)
  Toggles 'Infinite Health' cheat status to on/off.
* Toggle Infinite Oxygen (No Additional Data is needed)
  Toggles 'Infinite Oxygen' cheat status to on/off.
* Toggle Infinite Ammo (No Additional Data is needed)
  Toggles 'Infinite Ammo' cheat status to on/off.
* Toggle Tank Mode (No Additional Data is needed)
  Toggles 'Tank Mode' (Smash'n Boom) cheat status to on/off.
* Toggle Mega Punch (No Additional Data is needed)
  Toggles 'Mega Punch' cheat status to on/off.
* Toggle Mega Jump (No Additional Data is needed)
  Toggles 'Mega Jump' cheat status to on/off.
* Toggle Infinite Run (No Additional Data is needed)
  Toggles 'Infinite Run' SCM Memory Value to on/off.
* Toggle Fireproof (No Additional Data is needed)
  Toggles 'Fireproof' SCM Memory Value to on/off.
* Advance Game Time by 1 Hour (No Additional Data is needed)
  Advances Game Clock by one hour, taking care of weekday etc.
* Revert Game Time by 1 Hour (No Additional Data is needed)
  Reverts Game Clock by one hour, taking care of weekday etc.
* Stop Ped X Speed (no additional data needed)
  Stops the North-South speed of player.
* Stop Ped Y Speed (no additional data needed)
  Stops the East-West speed of player.
* Stop Ped Z Speed (no additional data needed)
  Stops the up-down speed of player.
* Stop All Ped Speed (no additional data needed)
  Stops all speed of the player.
* Set Ped X Speed to: (slider: -200% to +200%)
  Sets the North-South speed of player to the given level.
* Set Ped Y Speed to: (slider: -200% to +200%)
  Sets the East-West speed of player to the given level.
* Set Ped Z Speed to: (slider: -200% to +200%)
  Sets the Up-Down speed of player to the given level.
* Increase Ped X Speed by: (slider: -200% to +200%)
  Increases the North-South speed of player by the given level.
* Increase Ped Y Speed by: (slider: -200% to +200%)
  Increases the East-West speed of player by the given level.
* Increase Ped Z Speed by: (slider: -200% to +200%)
  Increases the Up-Down speed of player by the given level.
* Decrease Ped X Speed by: (slider: -200% to +200%)
  Decreases the North-South speed of player by the given level.
* Decrease Ped Y Speed by: (slider: -200% to +200%)
  Decreases the East-West speed of player by the given level.
* Decrease Ped Z Speed by: (slider: -200% to +200%)
  Decreases the Up-Down speed of player by the given level.
* Set Ped Speed To: (slider: -200% to +200%)
  Sets Player speed to the given value. The speed will be set according to the 
  current positioning of the player, so this can be used as a turbo-switch.
  This is only effective if player is on air (free-falling or with 'ped flight
  assistance')
* Increase Ped Speed by: (slider: -200% to +200%)
  Increases Player speed on air by the given value. The player speed will be set 
  according to the current positioning of the player, so this can be used as an 
  additional kick to the current cruise speed, or to 'fly' on air. This is only 
  effective if player is on air (free-falling or with 'ped flight assistance')
* Ped Flight Assistance: (ON/OFF)
  Activates or deactivates the player flight assistance.
* Ped Flight Assistance Level: (slider: 0% to 100%)
  Sets the player flight assistance level as selected.
* Turn My Ped in Clock Direction by: (slider: 0 to 180 Degrees)
  Turns the player in clock direction by selected amount of degrees.
* Turn My Ped in Counterclock Direction by:  (slider: 0 to 180 Degrees)
  Turns the player in counterclock direction by selected amount of degrees.
* Toggle Perfect Handling (No Additional Data is needed)
  Toggles 'Perfect Handling' cheat status to on/off.
* Toggle Decreased Traffic (No Additional Data is needed)
  Toggles 'Decreased Traffic' cheat status to on/off.
* Toggle Huge Bunny Hop (No Additional Data is needed)
  Toggles 'Huge Bunny Hop' cheat status to on/off.
* Toggle Cars have Nitro (No Additional Data is needed)
  Toggles 'Cars have Nitro' cheat status to on/off.
* Toggle Boats can Fly (No Additional Data is needed)
  Toggles 'Boats can Fly' cheat status to on/off.
* Toggle Cars can Fly (No Additional Data is needed)
  Toggles 'Cars can Fly' cheat status to on/off.
* Spawn Car (selection of all vehicles)
  Spawns the selected vehicle in front of the player. You will need the 
  code injection for this command to work.
* Set Weather to: (selection of 46 different weather modes)
  Sets the game weather to the selected value.
* Toggle Weather Lock (No Additional Data is needed)
  Toggles 'Weather Lock' status to on/off.
* Toggle One Hit Kill (No Additional Data is needed)
  Toggles 'One Hit Kill' function status to on/off.
* Toggle Freeze Mission Timers (No Additional Data is needed)
  Toggles 'Freeze Mission Timers' function status to on/off.
* Give Weapon & Ammo (weapon selection combo and ammo entry box)
  Gives player the selected weapon and selected amount of ammo.
* Remove current weapon (No Additional Data is needed)
  Removes the currently selected weapon from player weapons.
* Clear all weapons (No Additional Data is needed)
  Clears all weapons of the player. Please use this only while your 
  selected weapon is fists.

Selectable Weathers:
00 - Blue, Partly cloudy 1
01 - Blue, Partly cloudy 2
02 - Blue, Partly cloudy 3
03 - Blue, Partly cloudy 4
04 - Blue, Partly cloudy 5
05 - Blue, Partly cloudy 6
06 - Blue, Partly cloudy 7
07 - Blue, Partly cloudy 8
08 - Storming
09 - Cloudy and Foggy
10 - Clear Blue Sky
11 - Scorching Hot
12 - Very dull, Colorless, Hazy 1
13 - Very dull, Colorless, Hazy 2
14 - Very dull, Colorless, Hazy 3
15 - Very dull, Colorless, Hazy 4
16 - Dull, Cloudy, Rainy
17 - Scorching Hot
17 - Scorching Hot
19 - Sandstorm
20 - Foggy, Greenish
21 - Very dark, Purple
22 - Very dark, Green
23 - Pale Orange 1
24 - Pale Orange 2
25 - Pale Orange 3
26 - Pale Orange 4
27 - Fresh Blue 1
28 - Fresh Blue 2
29 - Fresh Blue 3
30 - Dark, Cloudy, Teal 1
31 - Dark, Cloudy, Teal 2
32 - Dark, Cloudy, Teal 3
33 - Dark, Cloudy, Brown
34 - Blue/Purple, Regular
35 - Dull brown
36 - Bright, Foggy, Orange 1
37 - Bright, Foggy, Orange 2
38 - Bright, Foggy, Orange 3
39 - Extremely bright
40 - Blue/Purple cloudy
41 - Blue/Purple cloudy
42 - Blue/Purple cloudy
43 - Dark toxic clouds
44 - Black/White sky
45 - Black/Purple sky

GTASACarPics.dat
This file has all the details needed to load the garage editor / car spawner vehicle 
selection form. If you delete this file, it will be regenerated using the original 
values. Edit this file as you wish. CarTypes are the selection tab on garage editor 
extended car selection. Type Name is the caption of the tab. TypeID is the reference to 
CarPictures. CarPictures are 100x72 pixel thumbnails, and saved under \CarPics folder. 
If a thumbnail is missing, or the car is not parkable, it will not be listed on the selection. 
You can list vehicles on more than one selection list. Create your own favorites to select one 
of your favorite cars to park in the selected garage. Use Pipe character '|' as seperator 
between fields. Most of the descriptions and the thumbnails are courtesy of www.g-unleashed.com. 
The g-unleashed.com thumbnails and descriptions are from the X-Box version of GTA SA, so some 
of the pictures and descriptions can actually differ from the PC edition.
Please use '#' character for the comments. This file has 2 sections: GTASACarTypes and GTASACarPictures.

Section: GTASACarTypes
The seperator is '|' (pipe) character. you can use tabs or white-space to make this file more
readable. This section is for the 12 Vehicle Type Tabs and the Favorites Tab. The ID's are 
hard-coded (0 belonging to the favorites). You can edit the type name's freely.
Example:
#TypeID       Type Name
0|            Favorites
1|            Sports Cars

Section: GTASACarPictures
The seperator is '|' (pipe) character. you can use tabs or white-space to make this file more
readable. You can assign a car to more than one TypeID's, and have it appear on several tabs on the 
vehicle selection form. The CarID is hard coded GTA SA CarID. Please edit carefully. You can assign 
the car to one of the 12 vehicle types (1 to 12), or to 0 for being in 'favorites'. You can edit the
favorites listing on the control center using context menu, but you need to edit this section if you
want a vehicle to appear in a different tab. Car Name is in free-text. Stars is only as information,
and represents the sexappeal stat of this car. CarDes is a free-text description of this vehicle, 
and is from g-unleashed.com.
Example:
#CarID        TypeID        CarName       	Stars         CarDesc
506|          0|            Super GT|     	5|            A great looking car and quick too...
541|          1|            Bullet|       	5|            Awesome car. Looks stunning, drives...


GTASACheats.dat
Edit at your own risk. Consists of Cheat Data for GTASA Control Center. This file gets regenerated 
when you click on Save Changes to Config File button. If you delete this file, it will be regenerated 
by the next time you run GTA SA Control Center.
Section: GTASACheats
Each GTA SA cheat has its own UID to make it unique within the sessions of GTA SA control center. If
you are not sure what a UID is, please use the control center user interface to edit this file.
Seperator character is '|' (pipe) and no white-space or tab's are allowed.
Example:
#UID                                |Folder                |Cheat  |Description
2608DD1D-5704-F841-85E5-4EDCC39226A5|GTA SA Cheats\Gameplay|CPKTNWT|Blow Up All Cars

GTASAConfig.dat
Please do not edit this file if you are not an experienced modder. This file has one section (GTASAShortcuts)
and gets completely regenerated each time you click on 'save configuration' button. 
Example:
#UID|Folder|Description|Active|ComboText|ExtKeyCode|KeyCode|Category|Command|DataPage|AdditionalData|Data Description
B1B9B667-1128-4541-A46A-6778D91F67F1|GTA SA Shortcuts\Driving Help|1 Flight Assistance: (ON)|1|1|0|49|0|56|16|1|(ON)

GTASAData.dat
Edit at your own risk. Consists of Car Data and Color Data for GTASA Control Center. If you delete 
this file, it will be regenerated by the next time you run GTASA_Center. This file has three sections:

Section: DATVersion
This is the version of the GTASAData.dat, implemented to enable regenerating this file during version changes
Current version is 2.0.0, and thereby has only one line of information with the value of '200'

Section: GTASACars
Seperator is ',' (comma) for main list, and ';' for Modification part. White-space and tabs are allowed.
This list must have all CarID's complete. The control center reads the CarID from game memory, and compares
with this list to get additional information on the vehicle. Please edit carefully. This is also used as GTASA 
Control Center Vehicle Detail Table for Parking in Garages. Non-drivable vehicles (as AirTrain) and boats 
should not be parked at all (edit at your own risk). Planes are not parkable at some garages (due to size of 
parkable area in the garage). Type 'truck' means that the vehicle is parked 1/3 outside of the garage so that 
you can enter in (used only for small garages otherwise handled as car). Please do not edit the ID of the cars. 
The Vehicle ID is the only reference to the vehicles.ide of GTA San Andreas. Type is used by the control center 
to decide several aspects of the vehicle dynamics, for example on prevent wheel damage, or teleport. Please 
do not change the vehicle type, as it goes hand in hand with the CarID. Car Name is free-text, and alters the
name that is shown in the vehicle selection combo of the garage editor. The X/Y/Z dimensions are for calculating
the parking coordinates of the vehicles in the garages. These values are mostly taken from GTA3 and GTAVC 
handling.dat files for similar vehicles. hHandling is the hexadecimal handling flags from gta sa handling.dat.
This is needed to park a given vehicle into a garage with all normal handling capabilities (ie monster truck
with rear-wheel handling). isParkable is the flag to prevent this vehicle from appearing from garage editor
vehicle selection list. Some vehicles are not parkable (ie. trains), and gta sa crashes if you force-park them
in a garage. Minor Color and Major Colors are pre-selection colors for each vehicle when parking in a garage
for the first time. Please check the GTASAColors section for details. Allowed Modifications are coded in HEX,
and separated with ';'. There are 4 different type of modifications. The Standard mods apply to standard 
moddable cars. The Generic Mods are Nitro, Bas Boost and Hydraulics. Wheels Mods are for changing the wheels, 
and Mods that are assigned to a specific CarID. These can only be used with this CarID, as they have a hard
coded DFF object reference to the given car within GTA SA. Please see the Complete List of Modifications 
for details.
Example:
# Id	CarName (free text)	Type 		Dim.x * 100	Dim.y * 100	Dim.z *100	hHandling	isParkable	MinorColor	MajorColor	Allowed Modifications (depending on objects in standard dff's)
445,	Admiral,		car,		200,		490,		150,		400000,		1,		34,		34,		3F0;3F1;3F2;43E;43F
602,	Alpha,			car,		200,		500,		200,		200000,		1,		58,		1,		3F0;3F1;3F2;43E;43F
416,	Ambulance,		car,		220,		650,		200,		4,		1,		1,		3

Complete List of Modifications:
Hex	CarID		ModDesc
3E8	Standard	Pro Spoiler
3E9	Standard	Win Spoiler
3EA	Standard	Drag Spoiler
3EB	Standard	Alpha Spoiler
3EC	Standard	Champ Roof Scoop
3ED	Standard	Fury Roof Scoop
3EE	Standard	Roof Scoops
3EF	Standard	Side Skirts
3F0	Generic		Nitro x 5
3F1	Generic		Nitro x 2
3F2	Generic		Nitro x 10
3F3	Standard	Race Hood Scoop
3F4	Standard	Worx Hood Scoop
3F5	Standard	Round Fog Lights
3F6	Standard	Champ Spoiler
3F7	Standard	Race Spoiler
3F8	Standard	Vorx Spoiler
3FA	Standard	Upswept Exhaust
3FB	Standard	Twin Exhaust
3FC	Standard	Large Exhaust
3FD	Standard	Medium Exhaust
3FE	Standard	Small Exhaust
3FF	Standard	Fury Spoiler
400	Standard	Square Fog Lights
401	Wheels		Offroad Wheels
402	560		Alien Side Skirts
404	560		Alien Exhaust
405	560		X-Flow Exhaust
407	560		X-Flow Side Skirts
408	560		Alien Roof Vent
409	560		X-Flow Roof Vent
40A	562		Alien Exhaust
40B	562		X-Flow Roof Vent
40C	562		Alien Side Skirts
40D	562		X-Flow Exhaust
40E	562		Alien Roof Vent
40F	562		X-Flow Side Skirts
412	575		Chromer Side Strips
413	575		Slamin Exhaust
414	575		Chromer Exhaust
415	565		X-Flow Exhaust
416	565		Alien Exhaust
417	565		Alien Side Skirts
418	565		X-Flow Side Skirts
419	565		Alien Spoiler
41A	565		X-Flow Spoiler
41D	565		Alien Roof Vent
41E	565		X-Flow Roof Vent
41F	561		Alien Roof Vent
420	561		Alien Side Skirts
421	561		X-Flow Side Skirts
422	561		Alien Spoiler
423	561		X-Flow Exhaust
424	561		X-Flow Spoiler
425	561		X-Flow Roof Vent
428	561		Alien Exhaust
429	559		Alien Exhaust
42A	559		X-Flow Exhaust
42B	559		Alien Roof Vent
42C	559		X-Flow Roof Vent
42D	559		Alien Side Skirts
42E	559		X-Flow Side Skirts
431	Wheels		Shadow Wheels
432	Wheels		Mega Wheels
433	Wheels		Rimshine Wheels
434	Wheels		Wires Wheels
435	Wheels		Classic Wheels
436	Wheels		Twist Wheels
437	Wheels		Cutter Wheels
438	Wheels		Switch Wheels
439	Wheels		Groove Wheels
43A	Wheels		Import Wheels
43B	Wheels		Dollar Wheels
43C	Wheels		Trance Wheels
43D	Wheels		Atomic Wheels
43E	Generic		Car Stereo (Bas Boost)
43F	Generic		Hydraulics
440	558		Alien Roof Vent
441	558		X-Flow Exhaust
442	558		Alien Side Skirts
443	558		X-Flow Roof Vent
444	558		Alien Exhaust
445	558		X-Flow Side Skirts
448	Wheels		Ahab Wheels
449	Wheels		Virtual Wheels
44A	Wheels		Access Wheels
44C	534		Chrome Grill
44F	536		Convertible Roof
450	536		Cromer Exhaust
451	536		Slamin Exhaust
452	534		Chromer Arches (Side Skirts)
454	536		Chrome Side Skirt
455	535		Chrome Rear Bullbar
456	535		Slamin Rear Bullbar
459	535		Chromer Exhaust
45A	535		Slamin Exhaust
45B	535		Chromer Front Bullbar
45C	535		Slamin Front Bullbar
45D	535		Chromer Front Bumper
45E	535		Chromer Trims (Side Skirts)
45F	535		Wheelcovers (Side Skirts)
462	534		Chromer Flames (Side Skirts)
463	534		Chrome Bars
465	534		Chrome Lights
466	534		Chromer Exhaust
467	534		Slamin Exhaust
468	536		Vinly Hardtop Roof
469	567		Chromer Exhaust
46A	567		Hardtop Roof
46B	567		Softtop Roof
46C	567		Slamin Exhaust
46D	567		Chrome Strips (Side Skirts)
46E	576		Chromer Side Skirts
46F	576		Slamin Exhaust
470	576		Chromer Exhaust
472	560		Alien Spoiler
473	560		X-Flow Spoiler
474	560		X-Flow Rear Bumper
475	560		Alien Rear Bumper
477	Standard	Oval Hood Vents
479	Standard	Square Hood Vents
47A	562		X-Flow Spoiler
47B	562		Alien Spoiler
47C	562		X-Flow Rear Bumper
47D	562		Alien Rear Bumper
47E	565		Alien Rear Bumper
47F	565		X-Flow Rear Bumper
480	565		X-Flow Front Bumper
481	565		Alien Front Bumper
482	561		Alien Rear Bumper
483	561		Alien Front Bumper
484	561		X-Flow Rear Bumper
485	561		X-Flow Front Bumper
486	559		X-Flow Spoiler
487	559		Alien Rear Bumper
488	559		Alien Front Bumper
489	559		X-Flow Rear Bumper
48A	559		Alien Spoiler
48B	558		X-Flow Spoiler
48C	558		Alien Spoiler
48D	558		X-Flow Front Bumper
48E	558		Alien Front Bumper
48F	558		X-Flow Rear Bumper
490	558		Alien Rear Bumper
491	560		Alien Front Bumper
492	560		X-Flow Front Bumper
493	562		Alien Front Bumper
494	562		X-Flow Front Bumper
495	559		X-Flow Front Bumper
496	575		Chromer Front Bumper
497	575		Slamin Front Bumper
498	575		Chromer Rear Bumper
499	575		Slamin Rear Bumper
49A	534		Slamin Rear Bumper
49B	534		Chromer Front Bumper
49C	534		Chromer Rear Bumper
49D	536		Slamin Front Bumper
49E	536		Chromer Front Bumper
49F	536		Slamin Rear Bumper
4A0	536		Chromer Rear Bumper
4A1	534		Slamin Front Bumper
4A2	567		Slamin Rear Bumper
4A3	567		Chromer Rear Bumper
4A4	567		Slamin Front Bumper
4A5	567		Chromer Front Bumper
4A6	576		Slamin Front Bumper
4A7	576		Chromer Front Bumper
4A8	576		Chromer Rear Bumper
4A9	576		Slamin Rear Bumper

Section: GTASAColors
This section is a copy of the car color data file of GTA SA. If you have edited the 
original carcol.dat file, please edit this section to see the colors as they appear
in GTA SA. The RGB is Red,Green,Blue weight of the color. The ID is the Car Color ID
that is used by GTA SA. This is hard-coded. Please edit appropritely. The ToolTipText
is a free-text entry, and will be read into tooltiptext of the clickable color labels
on the color selection window in GTA SA Control Center.
Example:
# RGB				 ID ToolTipText				(not used)
0,0,0				# 0 black				black
245,245,245			# 1 white				white
42,119,161			# 2 police car blue			blue

GTASALocs.dat
This file consists of one section that holds Location Data for GTASA Control Center.
If you delete this file, it will be regenerated by the next time you run GTASA_ControlCenter.
This file gets completely regenerated when you click on Save Changes to Config File button.
The UID is the unique identifier of this location. Folder is where this teleport location 
will appear within the location selection tree-view. Description is the free-text shown 
on the treeview item label. The Locations are saved as X;Y;Z;Angle. Feel free to edit this 
file to your needs. You can also edit this file using the control center locations tab.
Seperator character is '|', and the location coordinates are separated by ';'. Whitespace
and tab are not allowed.
Example:
#UID                                |Folder                      |Description |LocationData(X;Y;Z;Angle)
B727780C-F192-6148-85FF-1847DA748C75|GTA SA Locations\Girlfriends|GF Barbara|-1404.344;2640.061;55.887;90
88AC0067-CDD8-394A-95CC-91FBF7EC73CB|GTA SA Locations\Girlfriends|GF Denise|2402.54;-1727.254;12.874;90

GTASAConsole.ini
All of the control center settings are saved into this file to keep the registry
clean. You can edit this file using notepad if you want. The console command 
initiated warp location settings are also saved into this ini file. If you have
set several markup locations, and want them to appear in the permanent teleport
locations list, copy the locations into the GTASALocs.dat file.

