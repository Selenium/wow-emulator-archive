You will need Python 2.4 or newer, and wxPython (newest possible for 2.4). Put the script and the defs/ folder
in your data/ folder, and execute the script.
Please report any bugs in the BUGS.txt file in this directory.

Changes:
Nov 02 2006 [0.1.17]:
	* Bugfix: Save All now saves only changed pages
	* Behaviour change: Program no longer errors on missing files

Nov 02 2006 [0.1.18]:
	+ Jump to GUID function (Edit->Jump to GUID) jumps display to selected guid_t target (useful for quick account-to-player jumps)
	+ ErrorDlg (unified error dialog handler)
	* Bugfix: fixed parsing and generation of lists and list handlers
	/ Removed space after names in tabs

Nov 02 2006 [0.1.19]:
	* Updates to defs/ based on newest Object IDs
	* defs/ have changed: please update

Nov 02 2006 [0.1.20]:
	* minor bug in Jump to GUID fixed

Nov 05 2006 [0.1.21]:
	* added Reload Current Page option (File->Reload Current Page)