using System;
using System.Diagnostics; 
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using WoWDaemon.Common;
using WoWDaemon.Realm;
using WoWDaemon.Login;
using WoWDaemon.World;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database.MemberValues;
using WoWDaemon.Common.Attributes;



namespace WoWDaemon.WinLoader
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class WinLoader : System.Windows.Forms.Form
	{
		#region GUI

		private System.Windows.Forms.GroupBox usersBox;
		public System.Windows.Forms.ListBox usersLIST;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem fileMENU;
		private System.Windows.Forms.MenuItem StartMENU;
		private System.Windows.Forms.MenuItem ShutdownMENU;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem confMENU;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem exitMENU;
		private System.Windows.Forms.MenuItem reloadWorldMENU;
		private System.Windows.Forms.MenuItem reloadLoginMENU;
		private System.Windows.Forms.MenuItem aboutMENU;
		private System.Windows.Forms.MenuItem wownetMENU;
		private System.Windows.Forms.GroupBox consoleBOX;
		private System.Windows.Forms.GroupBox statisticBox1;
		private System.Windows.Forms.Label StatusLABEL;
		private System.Windows.Forms.Label usersonLABEL;
		private System.Windows.Forms.Label accLABEL;
		private System.Windows.Forms.Label charsLABEL;
		private System.Windows.Forms.Label spanwsLABEL;
		private System.Windows.Forms.MenuItem serverMENU;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem infoMENU;
		private System.Windows.Forms.MenuItem kickMENU;
		private System.Windows.Forms.MenuItem banMENU;
		private System.Windows.Forms.MenuItem helpMENU;
		private System.Windows.Forms.Label onoffINFO;
		private System.Windows.Forms.Label usernINFO;
		private System.Windows.Forms.Label accnINFO;
		private System.Windows.Forms.Label charsnINFO;
		private System.Windows.Forms.Label spawnsINFO;
		private System.Windows.Forms.Label intemLABEL;
		private System.Windows.Forms.Label itemnINFO;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ipTEXT;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem exit2MENU;
		private System.Windows.Forms.MenuItem restoreMENU;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button updateBUTTON;
		private System.Windows.Forms.StatusBar statusbar;
		public System.Windows.Forms.ListBox consoleLISTBOX;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem newAccountMenu;
		private System.ComponentModel.IContainer components;

		public WinLoader()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			statusbar.Text = "Version" + Application.ProductVersion;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(WinLoader));
			this.usersBox = new System.Windows.Forms.GroupBox();
			this.usersLIST = new System.Windows.Forms.ListBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.fileMENU = new System.Windows.Forms.MenuItem();
			this.StartMENU = new System.Windows.Forms.MenuItem();
			this.ShutdownMENU = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.confMENU = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.exitMENU = new System.Windows.Forms.MenuItem();
			this.serverMENU = new System.Windows.Forms.MenuItem();
			this.reloadWorldMENU = new System.Windows.Forms.MenuItem();
			this.reloadLoginMENU = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.infoMENU = new System.Windows.Forms.MenuItem();
			this.kickMENU = new System.Windows.Forms.MenuItem();
			this.banMENU = new System.Windows.Forms.MenuItem();
			this.helpMENU = new System.Windows.Forms.MenuItem();
			this.aboutMENU = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.wownetMENU = new System.Windows.Forms.MenuItem();
			this.consoleBOX = new System.Windows.Forms.GroupBox();
			this.consoleLISTBOX = new System.Windows.Forms.ListBox();
			this.statisticBox1 = new System.Windows.Forms.GroupBox();
			this.updateBUTTON = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ipTEXT = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.itemnINFO = new System.Windows.Forms.Label();
			this.intemLABEL = new System.Windows.Forms.Label();
			this.spawnsINFO = new System.Windows.Forms.Label();
			this.charsnINFO = new System.Windows.Forms.Label();
			this.accnINFO = new System.Windows.Forms.Label();
			this.usernINFO = new System.Windows.Forms.Label();
			this.onoffINFO = new System.Windows.Forms.Label();
			this.spanwsLABEL = new System.Windows.Forms.Label();
			this.charsLABEL = new System.Windows.Forms.Label();
			this.accLABEL = new System.Windows.Forms.Label();
			this.usersonLABEL = new System.Windows.Forms.Label();
			this.StatusLABEL = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.restoreMENU = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.exit2MENU = new System.Windows.Forms.MenuItem();
			this.statusbar = new System.Windows.Forms.StatusBar();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.newAccountMenu = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.usersBox.SuspendLayout();
			this.consoleBOX.SuspendLayout();
			this.statisticBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// usersBox
			// 
			this.usersBox.Controls.Add(this.usersLIST);
			this.usersBox.Location = new System.Drawing.Point(624, 32);
			this.usersBox.Name = "usersBox";
			this.usersBox.Size = new System.Drawing.Size(128, 616);
			this.usersBox.TabIndex = 0;
			this.usersBox.TabStop = false;
			this.usersBox.Text = "Users";
			// 
			// usersLIST
			// 
			this.usersLIST.Location = new System.Drawing.Point(8, 16);
			this.usersLIST.Name = "usersLIST";
			this.usersLIST.Size = new System.Drawing.Size(112, 589);
			this.usersLIST.TabIndex = 0;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileMENU,
																					  this.serverMENU,
																					  this.helpMENU});
			// 
			// fileMENU
			// 
			this.fileMENU.Index = 0;
			this.fileMENU.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.StartMENU,
																					 this.ShutdownMENU,
																					 this.menuItem4,
																					 this.confMENU,
																					 this.menuItem6,
																					 this.exitMENU});
			this.fileMENU.Text = "&File";
			// 
			// StartMENU
			// 
			this.StartMENU.Index = 0;
			this.StartMENU.Text = "&Start Server";
			this.StartMENU.Click += new System.EventHandler(this.StartMENU_Click);
			// 
			// ShutdownMENU
			// 
			this.ShutdownMENU.Index = 1;
			this.ShutdownMENU.Text = "S&hutdown Server";
			this.ShutdownMENU.Click += new System.EventHandler(this.ShutdownMENU_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// confMENU
			// 
			this.confMENU.Index = 3;
			this.confMENU.Text = "&Configuration";
			this.confMENU.Click += new System.EventHandler(this.confMENU_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "-";
			// 
			// exitMENU
			// 
			this.exitMENU.Index = 5;
			this.exitMENU.Text = "E&xit";
			this.exitMENU.Click += new System.EventHandler(this.exitMENU_Click);
			// 
			// serverMENU
			// 
			this.serverMENU.Index = 1;
			this.serverMENU.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.reloadWorldMENU,
																					   this.reloadLoginMENU,
																					   this.menuItem2,
																					   this.infoMENU,
																					   this.kickMENU,
																					   this.banMENU,
																					   this.menuItem3,
																					   this.newAccountMenu,
																					   this.menuItem8});
			this.serverMENU.Text = "&Server";
			// 
			// reloadWorldMENU
			// 
			this.reloadWorldMENU.Index = 0;
			this.reloadWorldMENU.Text = "Reload &World Scripts";
			this.reloadWorldMENU.Click += new System.EventHandler(this.reloadWorldMENU_Click);
			// 
			// reloadLoginMENU
			// 
			this.reloadLoginMENU.Index = 1;
			this.reloadLoginMENU.Text = "Reload &Login Scripts";
			this.reloadLoginMENU.Click += new System.EventHandler(this.reloadLoginMENU_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			// 
			// infoMENU
			// 
			this.infoMENU.Index = 3;
			this.infoMENU.Text = "Edit &User";
			this.infoMENU.Click += new System.EventHandler(this.infoMENU_Click);
			// 
			// kickMENU
			// 
			this.kickMENU.Index = 4;
			this.kickMENU.Text = "&Kick User";
			// 
			// banMENU
			// 
			this.banMENU.Index = 5;
			this.banMENU.Text = "&Ban User";
			this.banMENU.Click += new System.EventHandler(this.banMENU_Click);
			// 
			// helpMENU
			// 
			this.helpMENU.Index = 2;
			this.helpMENU.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.aboutMENU,
																					 this.menuItem1,
																					 this.wownetMENU});
			this.helpMENU.Text = "&Help";
			// 
			// aboutMENU
			// 
			this.aboutMENU.Index = 0;
			this.aboutMENU.Text = "&About";
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "-";
			// 
			// wownetMENU
			// 
			this.wownetMENU.Index = 2;
			this.wownetMENU.Text = "&WoWDaemon on NET";
			this.wownetMENU.Click += new System.EventHandler(this.wownetMENU_Click);
			// 
			// consoleBOX
			// 
			this.consoleBOX.Controls.Add(this.consoleLISTBOX);
			this.consoleBOX.Location = new System.Drawing.Point(200, 32);
			this.consoleBOX.Name = "consoleBOX";
			this.consoleBOX.Size = new System.Drawing.Size(408, 616);
			this.consoleBOX.TabIndex = 1;
			this.consoleBOX.TabStop = false;
			this.consoleBOX.Text = "Console Window";
			// 
			// consoleLISTBOX
			// 
			this.consoleLISTBOX.Location = new System.Drawing.Point(8, 16);
			this.consoleLISTBOX.Name = "consoleLISTBOX";
			this.consoleLISTBOX.Size = new System.Drawing.Size(392, 589);
			this.consoleLISTBOX.TabIndex = 0;
			// 
			// statisticBox1
			// 
			this.statisticBox1.Controls.Add(this.updateBUTTON);
			this.statisticBox1.Controls.Add(this.pictureBox1);
			this.statisticBox1.Controls.Add(this.ipTEXT);
			this.statisticBox1.Controls.Add(this.label1);
			this.statisticBox1.Controls.Add(this.itemnINFO);
			this.statisticBox1.Controls.Add(this.intemLABEL);
			this.statisticBox1.Controls.Add(this.spawnsINFO);
			this.statisticBox1.Controls.Add(this.charsnINFO);
			this.statisticBox1.Controls.Add(this.accnINFO);
			this.statisticBox1.Controls.Add(this.usernINFO);
			this.statisticBox1.Controls.Add(this.onoffINFO);
			this.statisticBox1.Controls.Add(this.spanwsLABEL);
			this.statisticBox1.Controls.Add(this.charsLABEL);
			this.statisticBox1.Controls.Add(this.accLABEL);
			this.statisticBox1.Controls.Add(this.usersonLABEL);
			this.statisticBox1.Controls.Add(this.StatusLABEL);
			this.statisticBox1.Location = new System.Drawing.Point(16, 32);
			this.statisticBox1.Name = "statisticBox1";
			this.statisticBox1.Size = new System.Drawing.Size(168, 616);
			this.statisticBox1.TabIndex = 2;
			this.statisticBox1.TabStop = false;
			this.statisticBox1.Text = "Statistics";
			// 
			// updateBUTTON
			// 
			this.updateBUTTON.Location = new System.Drawing.Point(24, 544);
			this.updateBUTTON.Name = "updateBUTTON";
			this.updateBUTTON.Size = new System.Drawing.Size(120, 32);
			this.updateBUTTON.TabIndex = 15;
			this.updateBUTTON.Text = "Update Info";
			this.updateBUTTON.Click += new System.EventHandler(this.updateBUTTON_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 440);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(152, 88);
			this.pictureBox1.TabIndex = 14;
			this.pictureBox1.TabStop = false;
			// 
			// ipTEXT
			// 
			this.ipTEXT.Location = new System.Drawing.Point(24, 408);
			this.ipTEXT.Name = "ipTEXT";
			this.ipTEXT.ReadOnly = true;
			this.ipTEXT.Size = new System.Drawing.Size(120, 20);
			this.ipTEXT.TabIndex = 13;
			this.ipTEXT.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(48, 392);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "IP Adress:";
			// 
			// itemnINFO
			// 
			this.itemnINFO.ForeColor = System.Drawing.Color.Blue;
			this.itemnINFO.Location = new System.Drawing.Point(120, 328);
			this.itemnINFO.Name = "itemnINFO";
			this.itemnINFO.Size = new System.Drawing.Size(32, 16);
			this.itemnINFO.TabIndex = 11;
			this.itemnINFO.Text = "0";
			// 
			// intemLABEL
			// 
			this.intemLABEL.Location = new System.Drawing.Point(8, 328);
			this.intemLABEL.Name = "intemLABEL";
			this.intemLABEL.Size = new System.Drawing.Size(48, 23);
			this.intemLABEL.TabIndex = 10;
			this.intemLABEL.Text = "Itens :";
			// 
			// spawnsINFO
			// 
			this.spawnsINFO.ForeColor = System.Drawing.Color.Blue;
			this.spawnsINFO.Location = new System.Drawing.Point(120, 264);
			this.spawnsINFO.Name = "spawnsINFO";
			this.spawnsINFO.Size = new System.Drawing.Size(40, 16);
			this.spawnsINFO.TabIndex = 9;
			this.spawnsINFO.Text = "0";
			// 
			// charsnINFO
			// 
			this.charsnINFO.ForeColor = System.Drawing.Color.Blue;
			this.charsnINFO.Location = new System.Drawing.Point(120, 200);
			this.charsnINFO.Name = "charsnINFO";
			this.charsnINFO.Size = new System.Drawing.Size(32, 16);
			this.charsnINFO.TabIndex = 8;
			this.charsnINFO.Text = "0";
			// 
			// accnINFO
			// 
			this.accnINFO.ForeColor = System.Drawing.Color.Blue;
			this.accnINFO.Location = new System.Drawing.Point(120, 144);
			this.accnINFO.Name = "accnINFO";
			this.accnINFO.Size = new System.Drawing.Size(32, 16);
			this.accnINFO.TabIndex = 7;
			this.accnINFO.Text = "0";
			// 
			// usernINFO
			// 
			this.usernINFO.ForeColor = System.Drawing.Color.Blue;
			this.usernINFO.Location = new System.Drawing.Point(120, 88);
			this.usernINFO.Name = "usernINFO";
			this.usernINFO.Size = new System.Drawing.Size(32, 16);
			this.usernINFO.TabIndex = 6;
			this.usernINFO.Text = "0";
			// 
			// onoffINFO
			// 
			this.onoffINFO.ForeColor = System.Drawing.Color.Red;
			this.onoffINFO.Location = new System.Drawing.Point(104, 32);
			this.onoffINFO.Name = "onoffINFO";
			this.onoffINFO.Size = new System.Drawing.Size(40, 16);
			this.onoffINFO.TabIndex = 5;
			this.onoffINFO.Text = "Offline";
			// 
			// spanwsLABEL
			// 
			this.spanwsLABEL.Location = new System.Drawing.Point(8, 264);
			this.spanwsLABEL.Name = "spanwsLABEL";
			this.spanwsLABEL.Size = new System.Drawing.Size(80, 23);
			this.spanwsLABEL.TabIndex = 4;
			this.spanwsLABEL.Text = "Total Spawns :";
			// 
			// charsLABEL
			// 
			this.charsLABEL.Location = new System.Drawing.Point(8, 200);
			this.charsLABEL.Name = "charsLABEL";
			this.charsLABEL.Size = new System.Drawing.Size(96, 16);
			this.charsLABEL.TabIndex = 3;
			this.charsLABEL.Text = "Total Characters :";
			// 
			// accLABEL
			// 
			this.accLABEL.Location = new System.Drawing.Point(8, 144);
			this.accLABEL.Name = "accLABEL";
			this.accLABEL.Size = new System.Drawing.Size(88, 16);
			this.accLABEL.TabIndex = 2;
			this.accLABEL.Text = "Total Accounts :";
			// 
			// usersonLABEL
			// 
			this.usersonLABEL.Location = new System.Drawing.Point(8, 88);
			this.usersonLABEL.Name = "usersonLABEL";
			this.usersonLABEL.Size = new System.Drawing.Size(80, 16);
			this.usersonLABEL.TabIndex = 1;
			this.usersonLABEL.Text = "Users Online :";
			// 
			// StatusLABEL
			// 
			this.StatusLABEL.Location = new System.Drawing.Point(8, 32);
			this.StatusLABEL.Name = "StatusLABEL";
			this.StatusLABEL.Size = new System.Drawing.Size(48, 16);
			this.StatusLABEL.TabIndex = 0;
			this.StatusLABEL.Text = "Status :";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "WoWDaemon Server";
			this.notifyIcon1.Visible = true;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.restoreMENU,
																						 this.menuItem5,
																						 this.exit2MENU});
			// 
			// restoreMENU
			// 
			this.restoreMENU.Index = 0;
			this.restoreMENU.Text = "&Restore";
			this.restoreMENU.Click += new System.EventHandler(this.restoreMENU_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "-";
			// 
			// exit2MENU
			// 
			this.exit2MENU.Index = 2;
			this.exit2MENU.Text = "E&xit";
			this.exit2MENU.Click += new System.EventHandler(this.exit2MENU_Click);
			// 
			// statusbar
			// 
			this.statusbar.Location = new System.Drawing.Point(0, 661);
			this.statusbar.Name = "statusbar";
			this.statusbar.Size = new System.Drawing.Size(776, 22);
			this.statusbar.TabIndex = 3;
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 6;
			this.menuItem3.Text = "-";
			// 
			// newAccountMenu
			// 
			this.newAccountMenu.Index = 7;
			this.newAccountMenu.Text = "New Account";
			this.newAccountMenu.Click += new System.EventHandler(this.newAccountMenu_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 8;
			this.menuItem8.Text = "Edit Account";
			// 
			// WinLoader
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 683);
			this.Controls.Add(this.statusbar);
			this.Controls.Add(this.statisticBox1);
			this.Controls.Add(this.consoleBOX);
			this.Controls.Add(this.usersBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "WinLoader";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WoWCraft 1.3";
			this.Load += new System.EventHandler(this.WinLoader_Load);
			this.usersBox.ResumeLayout(false);
			this.consoleBOX.ResumeLayout(false);
			this.statisticBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		
		static void Main() 
		{
			Application.Run(new WinLoader());
		}

		private void WinLoader_Load(object sender, System.EventArgs e)
		{
			
		}

		private void exit2MENU_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void exitMENU_Click(object sender, System.EventArgs e)
		{
			Info.StopLoginServer();
			Application.Exit();
		}

		private void restoreMENU_Click(object sender, System.EventArgs e)
		{
			this.Show();
		}

		private void StartMENU_Click(object sender, System.EventArgs e)
		{
			WinLoader wl = this;
			if(!Info.StartLoginServer(wl))
				return;
			if(true)
			{
				string Items = DataServer.Database.GetObjectCount(typeof(DBItemTemplate)).ToString();
				string Acc = DataServer.Database.GetObjectCount(typeof(DBAccount)).ToString();
				string Char = DataServer.Database.GetObjectCount(typeof(DBCharacter)).ToString();
				string IP = LoginServer.EndPoint.ToString();
				string Spawn = DataServer.Database.GetObjectCount(typeof(DBSpawn)).ToString();
				
				this.onoffINFO.ForeColor = System.Drawing.Color.Green;
				this.onoffINFO.Text = "Online";
				this.onoffINFO.Refresh();
				this.itemnINFO.Text = Items;
				this.itemnINFO.Refresh();
				this.accnINFO.Text = Acc;
				this.accnINFO.Refresh();
				this.charsnINFO.Text = Char;
				this.charsnINFO.Refresh();
				this.ipTEXT.Text = IP;
				this.ipTEXT.Refresh();
				this.spawnsINFO.Text = Spawn;
				this.spawnsINFO.Refresh();
			}
		}

		private void ShutdownMENU_Click(object sender, System.EventArgs e)
		{
			Info.StopLoginServer();
			this.onoffINFO.ForeColor = System.Drawing.Color.Red;
			this.onoffINFO.Text = "Offline";
			this.onoffINFO.Refresh();
			this.itemnINFO.Text = "0";
			this.itemnINFO.Refresh();
			this.accnINFO.Text = "0";
			this.accnINFO.Refresh();
			this.charsnINFO.Text = "0";
			this.charsnINFO.Refresh();
			this.usernINFO.Text = "0";
			this.usernINFO.Refresh();
			this.ipTEXT.Text = null;
			this.ipTEXT.Refresh();
		}

		private void reloadWorldMENU_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("WorldServer Scripts Reloaded");
			WorldServer.ReloadScripts();
		}

		private void reloadLoginMENU_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("LoginServer Scripts Reloaded");
			LoginServer.ReloadScripts();
		}

		private void consoleTextBOX_TextChanged(object sender, System.EventArgs e)
		{

		}

		private void updateBUTTON_Click(object sender, System.EventArgs e)
		{
		
			string Items = DataServer.Database.GetObjectCount(typeof(DBItemTemplate)).ToString();
			string Acc = DataServer.Database.GetObjectCount(typeof(DBAccount)).ToString();
			string Char = DataServer.Database.GetObjectCount(typeof(DBCharacter)).ToString();
			string IP = LoginServer.EndPoint.ToString();
			string User = LoginServer.CurrentUsers.ToString();
			string Spawn = DataServer.Database.GetObjectCount(typeof(DBSpawn)).ToString();
			
			this.onoffINFO.ForeColor = System.Drawing.Color.Green;
			this.onoffINFO.Text = "Online";
			this.onoffINFO.Refresh();
			this.itemnINFO.Text = Items;
			this.itemnINFO.Refresh();
			this.accnINFO.Text = Acc;
			this.accnINFO.Refresh();
			this.charsnINFO.Text = Char;
			this.charsnINFO.Refresh();
			this.ipTEXT.Text = IP;
			this.ipTEXT.Refresh();
			this.usernINFO.Text = User;
			this.usernINFO.Refresh();
			this.spawnsINFO.Text = Spawn;
			this.spawnsINFO.Refresh();
			this.usersLIST.Items.Clear();
		}

		private void confMENU_Click(object sender, System.EventArgs e)
		{
			WinConf frConf = new WinConf();
			frConf.Show();
			MessageBox.Show("Don modify the Setting while running the server!","Warning!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void infoMENU_Click(object sender, System.EventArgs e)
		{
			PlayerConfig frPlayer = new PlayerConfig();
			frPlayer.Show();
		}

		private void wownetMENU_Click(object sender, System.EventArgs e)
		{
			Process about = new Process();
			about.StartInfo.FileName = "iexplore.exe";
			about.StartInfo.Arguments = "http://www.worldofwowcraft.com";
			about.Start();
		}

		private void newAccountMenu_Click(object sender, System.EventArgs e)
		{
			AccountConfig frnewAccount = new AccountConfig();
			frnewAccount.Show();
		}

		private void banMENU_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}

