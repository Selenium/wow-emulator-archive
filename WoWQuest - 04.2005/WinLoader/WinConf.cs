using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
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
	/// Summary description for WinConf.
	/// </summary>
	public class WinConf : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl configTABCONTROL;
		private System.Windows.Forms.TabPage loginserverPAGE;
		private System.Windows.Forms.TabPage worldserverPAGE;
		private System.Windows.Forms.TabPage realmlistPAGE;
		private System.Windows.Forms.GroupBox configBOX;
		private System.Windows.Forms.Button OKconfigBUTTON;
		private System.Windows.Forms.Button CANCELconfigBUTTON;
		private System.Windows.Forms.Label SERVERloginLABEL;
		private System.Windows.Forms.Label IPloginLABEL;
		private System.Windows.Forms.Label HOSTloginLABEL;
		private System.Windows.Forms.TextBox serverBOX;
		private System.Windows.Forms.TextBox PORTloginBOX;
		private System.Windows.Forms.TextBox REDPORTloginBOX;
		private System.Windows.Forms.Label PORTloginLABEL;
		private System.Windows.Forms.Label REDPORTloginLABEL;
		private System.Windows.Forms.Label WORLOUTloginLABEL;
		private System.Windows.Forms.TextBox WORLDOUTloginBOX;
		private System.Windows.Forms.Label OUTREALMloginLABEL;
		private System.Windows.Forms.TextBox EHOSTloginBOX;
		private System.Windows.Forms.Label IPrealmLABEL;
		private System.Windows.Forms.Label PORTrealmLABEL;
		private System.Windows.Forms.Label UPDATEPORTrealmLABEL;
		private System.Windows.Forms.Label EHOSTrealmLABEL;
		private System.Windows.Forms.TextBox PORTrealmBOX;
		private System.Windows.Forms.TextBox UPORTrealmBOX;
		private System.Windows.Forms.TextBox EHOSTrealmBOX;
		private System.Windows.Forms.Label IPworldLABEL;
		private System.Windows.Forms.TextBox PORTworldBOX;
		private System.Windows.Forms.Label PORTworldLABEL;
		private System.Windows.Forms.TextBox IPloginBOX;
		private System.Windows.Forms.TextBox IPworldBOX;
		private System.Windows.Forms.TextBox IPrealmBOX;
		private System.Windows.Forms.TextBox REALMOUTloginBOX;
		private System.Windows.Forms.CheckBox LOGINexternalCHECKBOX;
		private System.Windows.Forms.CheckBox REALMexternalCHECKBOX;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinConf()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			LoadLoginConfig();
			LoadRealmConfig();
			LoadWorldConfig();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(WinConf));
			this.configTABCONTROL = new System.Windows.Forms.TabControl();
			this.loginserverPAGE = new System.Windows.Forms.TabPage();
			this.LOGINexternalCHECKBOX = new System.Windows.Forms.CheckBox();
			this.IPloginBOX = new System.Windows.Forms.TextBox();
			this.EHOSTloginBOX = new System.Windows.Forms.TextBox();
			this.REDPORTloginBOX = new System.Windows.Forms.TextBox();
			this.REDPORTloginLABEL = new System.Windows.Forms.Label();
			this.PORTloginBOX = new System.Windows.Forms.TextBox();
			this.PORTloginLABEL = new System.Windows.Forms.Label();
			this.serverBOX = new System.Windows.Forms.TextBox();
			this.HOSTloginLABEL = new System.Windows.Forms.Label();
			this.IPloginLABEL = new System.Windows.Forms.Label();
			this.SERVERloginLABEL = new System.Windows.Forms.Label();
			this.WORLDOUTloginBOX = new System.Windows.Forms.TextBox();
			this.REALMOUTloginBOX = new System.Windows.Forms.TextBox();
			this.WORLOUTloginLABEL = new System.Windows.Forms.Label();
			this.OUTREALMloginLABEL = new System.Windows.Forms.Label();
			this.worldserverPAGE = new System.Windows.Forms.TabPage();
			this.IPworldBOX = new System.Windows.Forms.TextBox();
			this.PORTworldLABEL = new System.Windows.Forms.Label();
			this.PORTworldBOX = new System.Windows.Forms.TextBox();
			this.IPworldLABEL = new System.Windows.Forms.Label();
			this.realmlistPAGE = new System.Windows.Forms.TabPage();
			this.REALMexternalCHECKBOX = new System.Windows.Forms.CheckBox();
			this.IPrealmBOX = new System.Windows.Forms.TextBox();
			this.EHOSTrealmBOX = new System.Windows.Forms.TextBox();
			this.UPORTrealmBOX = new System.Windows.Forms.TextBox();
			this.PORTrealmBOX = new System.Windows.Forms.TextBox();
			this.EHOSTrealmLABEL = new System.Windows.Forms.Label();
			this.UPDATEPORTrealmLABEL = new System.Windows.Forms.Label();
			this.PORTrealmLABEL = new System.Windows.Forms.Label();
			this.IPrealmLABEL = new System.Windows.Forms.Label();
			this.configBOX = new System.Windows.Forms.GroupBox();
			this.CANCELconfigBUTTON = new System.Windows.Forms.Button();
			this.OKconfigBUTTON = new System.Windows.Forms.Button();
			this.configTABCONTROL.SuspendLayout();
			this.loginserverPAGE.SuspendLayout();
			this.worldserverPAGE.SuspendLayout();
			this.realmlistPAGE.SuspendLayout();
			this.configBOX.SuspendLayout();
			this.SuspendLayout();
			// 
			// configTABCONTROL
			// 
			this.configTABCONTROL.Controls.Add(this.loginserverPAGE);
			this.configTABCONTROL.Controls.Add(this.worldserverPAGE);
			this.configTABCONTROL.Controls.Add(this.realmlistPAGE);
			this.configTABCONTROL.Location = new System.Drawing.Point(16, 16);
			this.configTABCONTROL.Name = "configTABCONTROL";
			this.configTABCONTROL.SelectedIndex = 0;
			this.configTABCONTROL.Size = new System.Drawing.Size(384, 224);
			this.configTABCONTROL.TabIndex = 0;
			// 
			// loginserverPAGE
			// 
			this.loginserverPAGE.Controls.Add(this.LOGINexternalCHECKBOX);
			this.loginserverPAGE.Controls.Add(this.IPloginBOX);
			this.loginserverPAGE.Controls.Add(this.EHOSTloginBOX);
			this.loginserverPAGE.Controls.Add(this.REDPORTloginBOX);
			this.loginserverPAGE.Controls.Add(this.REDPORTloginLABEL);
			this.loginserverPAGE.Controls.Add(this.PORTloginBOX);
			this.loginserverPAGE.Controls.Add(this.PORTloginLABEL);
			this.loginserverPAGE.Controls.Add(this.serverBOX);
			this.loginserverPAGE.Controls.Add(this.HOSTloginLABEL);
			this.loginserverPAGE.Controls.Add(this.IPloginLABEL);
			this.loginserverPAGE.Controls.Add(this.SERVERloginLABEL);
			this.loginserverPAGE.Controls.Add(this.WORLDOUTloginBOX);
			this.loginserverPAGE.Controls.Add(this.REALMOUTloginBOX);
			this.loginserverPAGE.Controls.Add(this.WORLOUTloginLABEL);
			this.loginserverPAGE.Controls.Add(this.OUTREALMloginLABEL);
			this.loginserverPAGE.Location = new System.Drawing.Point(4, 22);
			this.loginserverPAGE.Name = "loginserverPAGE";
			this.loginserverPAGE.Size = new System.Drawing.Size(376, 198);
			this.loginserverPAGE.TabIndex = 0;
			this.loginserverPAGE.Text = "LoginServer";
			// 
			// LOGINexternalCHECKBOX
			// 
			this.LOGINexternalCHECKBOX.Location = new System.Drawing.Point(184, 80);
			this.LOGINexternalCHECKBOX.Name = "LOGINexternalCHECKBOX";
			this.LOGINexternalCHECKBOX.TabIndex = 8;
			this.LOGINexternalCHECKBOX.Text = "External Host";
			this.LOGINexternalCHECKBOX.CheckedChanged += new System.EventHandler(this.LOGINexternalCHECKBOX_CheckedChanged);
			// 
			// IPloginBOX
			// 
			this.IPloginBOX.Location = new System.Drawing.Point(184, 32);
			this.IPloginBOX.MaxLength = 15;
			this.IPloginBOX.Name = "IPloginBOX";
			this.IPloginBOX.Size = new System.Drawing.Size(120, 20);
			this.IPloginBOX.TabIndex = 2;
			this.IPloginBOX.Text = "";
			// 
			// EHOSTloginBOX
			// 
			this.EHOSTloginBOX.Enabled = false;
			this.EHOSTloginBOX.Location = new System.Drawing.Point(184, 128);
			this.EHOSTloginBOX.MaxLength = 15;
			this.EHOSTloginBOX.Name = "EHOSTloginBOX";
			this.EHOSTloginBOX.Size = new System.Drawing.Size(120, 20);
			this.EHOSTloginBOX.TabIndex = 5;
			this.EHOSTloginBOX.Text = "";
			// 
			// REDPORTloginBOX
			// 
			this.REDPORTloginBOX.Location = new System.Drawing.Point(312, 72);
			this.REDPORTloginBOX.MaxLength = 4;
			this.REDPORTloginBOX.Name = "REDPORTloginBOX";
			this.REDPORTloginBOX.Size = new System.Drawing.Size(32, 20);
			this.REDPORTloginBOX.TabIndex = 6;
			this.REDPORTloginBOX.Text = "";
			// 
			// REDPORTloginLABEL
			// 
			this.REDPORTloginLABEL.Location = new System.Drawing.Point(312, 56);
			this.REDPORTloginLABEL.Name = "REDPORTloginLABEL";
			this.REDPORTloginLABEL.Size = new System.Drawing.Size(64, 16);
			this.REDPORTloginLABEL.TabIndex = 7;
			this.REDPORTloginLABEL.Text = "Red. Port :";
			// 
			// PORTloginBOX
			// 
			this.PORTloginBOX.Location = new System.Drawing.Point(312, 32);
			this.PORTloginBOX.MaxLength = 4;
			this.PORTloginBOX.Name = "PORTloginBOX";
			this.PORTloginBOX.Size = new System.Drawing.Size(32, 20);
			this.PORTloginBOX.TabIndex = 3;
			this.PORTloginBOX.Text = "";
			// 
			// PORTloginLABEL
			// 
			this.PORTloginLABEL.Location = new System.Drawing.Point(312, 16);
			this.PORTloginLABEL.Name = "PORTloginLABEL";
			this.PORTloginLABEL.Size = new System.Drawing.Size(40, 16);
			this.PORTloginLABEL.TabIndex = 5;
			this.PORTloginLABEL.Text = "Port :";
			// 
			// serverBOX
			// 
			this.serverBOX.Location = new System.Drawing.Point(8, 32);
			this.serverBOX.MaxLength = 25;
			this.serverBOX.Name = "serverBOX";
			this.serverBOX.Size = new System.Drawing.Size(168, 20);
			this.serverBOX.TabIndex = 1;
			this.serverBOX.Text = "";
			// 
			// HOSTloginLABEL
			// 
			this.HOSTloginLABEL.Location = new System.Drawing.Point(184, 112);
			this.HOSTloginLABEL.Name = "HOSTloginLABEL";
			this.HOSTloginLABEL.Size = new System.Drawing.Size(80, 16);
			this.HOSTloginLABEL.TabIndex = 2;
			this.HOSTloginLABEL.Text = "External IP :";
			// 
			// IPloginLABEL
			// 
			this.IPloginLABEL.Location = new System.Drawing.Point(184, 16);
			this.IPloginLABEL.Name = "IPloginLABEL";
			this.IPloginLABEL.Size = new System.Drawing.Size(64, 16);
			this.IPloginLABEL.TabIndex = 1;
			this.IPloginLABEL.Text = "IP Adress :";
			// 
			// SERVERloginLABEL
			// 
			this.SERVERloginLABEL.Location = new System.Drawing.Point(8, 16);
			this.SERVERloginLABEL.Name = "SERVERloginLABEL";
			this.SERVERloginLABEL.Size = new System.Drawing.Size(80, 16);
			this.SERVERloginLABEL.TabIndex = 0;
			this.SERVERloginLABEL.Text = "Server Name :";
			// 
			// WORLDOUTloginBOX
			// 
			this.WORLDOUTloginBOX.Enabled = false;
			this.WORLDOUTloginBOX.Location = new System.Drawing.Point(8, 88);
			this.WORLDOUTloginBOX.MaxLength = 15;
			this.WORLDOUTloginBOX.Name = "WORLDOUTloginBOX";
			this.WORLDOUTloginBOX.Size = new System.Drawing.Size(120, 20);
			this.WORLDOUTloginBOX.TabIndex = 4;
			this.WORLDOUTloginBOX.Text = "Not implemented yet";
			// 
			// REALMOUTloginBOX
			// 
			this.REALMOUTloginBOX.Enabled = false;
			this.REALMOUTloginBOX.Location = new System.Drawing.Point(8, 136);
			this.REALMOUTloginBOX.Name = "REALMOUTloginBOX";
			this.REALMOUTloginBOX.Size = new System.Drawing.Size(120, 20);
			this.REALMOUTloginBOX.TabIndex = 7;
			this.REALMOUTloginBOX.Text = "Not implemented yet";
			// 
			// WORLOUTloginLABEL
			// 
			this.WORLOUTloginLABEL.Location = new System.Drawing.Point(8, 72);
			this.WORLOUTloginLABEL.Name = "WORLOUTloginLABEL";
			this.WORLOUTloginLABEL.Size = new System.Drawing.Size(136, 23);
			this.WORLOUTloginLABEL.TabIndex = 0;
			this.WORLOUTloginLABEL.Text = "Outside WorldServer IP :";
			// 
			// OUTREALMloginLABEL
			// 
			this.OUTREALMloginLABEL.Location = new System.Drawing.Point(8, 120);
			this.OUTREALMloginLABEL.Name = "OUTREALMloginLABEL";
			this.OUTREALMloginLABEL.Size = new System.Drawing.Size(136, 16);
			this.OUTREALMloginLABEL.TabIndex = 2;
			this.OUTREALMloginLABEL.Text = "Outside RealmList IP :";
			// 
			// worldserverPAGE
			// 
			this.worldserverPAGE.Controls.Add(this.IPworldBOX);
			this.worldserverPAGE.Controls.Add(this.PORTworldLABEL);
			this.worldserverPAGE.Controls.Add(this.PORTworldBOX);
			this.worldserverPAGE.Controls.Add(this.IPworldLABEL);
			this.worldserverPAGE.Location = new System.Drawing.Point(4, 22);
			this.worldserverPAGE.Name = "worldserverPAGE";
			this.worldserverPAGE.Size = new System.Drawing.Size(376, 198);
			this.worldserverPAGE.TabIndex = 1;
			this.worldserverPAGE.Text = "WorldServer";
			// 
			// IPworldBOX
			// 
			this.IPworldBOX.Location = new System.Drawing.Point(88, 80);
			this.IPworldBOX.MaxLength = 15;
			this.IPworldBOX.Name = "IPworldBOX";
			this.IPworldBOX.TabIndex = 1;
			this.IPworldBOX.Text = "";
			// 
			// PORTworldLABEL
			// 
			this.PORTworldLABEL.Location = new System.Drawing.Point(232, 64);
			this.PORTworldLABEL.Name = "PORTworldLABEL";
			this.PORTworldLABEL.Size = new System.Drawing.Size(32, 16);
			this.PORTworldLABEL.TabIndex = 2;
			this.PORTworldLABEL.Text = "Port :";
			// 
			// PORTworldBOX
			// 
			this.PORTworldBOX.Location = new System.Drawing.Point(232, 80);
			this.PORTworldBOX.MaxLength = 4;
			this.PORTworldBOX.Name = "PORTworldBOX";
			this.PORTworldBOX.Size = new System.Drawing.Size(32, 20);
			this.PORTworldBOX.TabIndex = 2;
			this.PORTworldBOX.Text = "";
			// 
			// IPworldLABEL
			// 
			this.IPworldLABEL.Location = new System.Drawing.Point(88, 64);
			this.IPworldLABEL.Name = "IPworldLABEL";
			this.IPworldLABEL.Size = new System.Drawing.Size(72, 16);
			this.IPworldLABEL.TabIndex = 0;
			this.IPworldLABEL.Text = "IP Adress :";
			// 
			// realmlistPAGE
			// 
			this.realmlistPAGE.Controls.Add(this.REALMexternalCHECKBOX);
			this.realmlistPAGE.Controls.Add(this.IPrealmBOX);
			this.realmlistPAGE.Controls.Add(this.EHOSTrealmBOX);
			this.realmlistPAGE.Controls.Add(this.UPORTrealmBOX);
			this.realmlistPAGE.Controls.Add(this.PORTrealmBOX);
			this.realmlistPAGE.Controls.Add(this.EHOSTrealmLABEL);
			this.realmlistPAGE.Controls.Add(this.UPDATEPORTrealmLABEL);
			this.realmlistPAGE.Controls.Add(this.PORTrealmLABEL);
			this.realmlistPAGE.Controls.Add(this.IPrealmLABEL);
			this.realmlistPAGE.Location = new System.Drawing.Point(4, 22);
			this.realmlistPAGE.Name = "realmlistPAGE";
			this.realmlistPAGE.Size = new System.Drawing.Size(376, 198);
			this.realmlistPAGE.TabIndex = 2;
			this.realmlistPAGE.Text = "ReamList";
			// 
			// REALMexternalCHECKBOX
			// 
			this.REALMexternalCHECKBOX.Location = new System.Drawing.Point(56, 88);
			this.REALMexternalCHECKBOX.Name = "REALMexternalCHECKBOX";
			this.REALMexternalCHECKBOX.TabIndex = 5;
			this.REALMexternalCHECKBOX.Text = "External Host";
			this.REALMexternalCHECKBOX.CheckedChanged += new System.EventHandler(this.REALMexternalCHECKBOX_CheckedChanged);
			// 
			// IPrealmBOX
			// 
			this.IPrealmBOX.Location = new System.Drawing.Point(56, 48);
			this.IPrealmBOX.MaxLength = 15;
			this.IPrealmBOX.Name = "IPrealmBOX";
			this.IPrealmBOX.Size = new System.Drawing.Size(112, 20);
			this.IPrealmBOX.TabIndex = 1;
			this.IPrealmBOX.Text = "";
			// 
			// EHOSTrealmBOX
			// 
			this.EHOSTrealmBOX.Enabled = false;
			this.EHOSTrealmBOX.Location = new System.Drawing.Point(56, 136);
			this.EHOSTrealmBOX.MaxLength = 15;
			this.EHOSTrealmBOX.Name = "EHOSTrealmBOX";
			this.EHOSTrealmBOX.Size = new System.Drawing.Size(112, 20);
			this.EHOSTrealmBOX.TabIndex = 4;
			this.EHOSTrealmBOX.Text = "";
			// 
			// UPORTrealmBOX
			// 
			this.UPORTrealmBOX.Enabled = false;
			this.UPORTrealmBOX.Location = new System.Drawing.Point(192, 136);
			this.UPORTrealmBOX.MaxLength = 4;
			this.UPORTrealmBOX.Name = "UPORTrealmBOX";
			this.UPORTrealmBOX.Size = new System.Drawing.Size(32, 20);
			this.UPORTrealmBOX.TabIndex = 3;
			this.UPORTrealmBOX.Text = "";
			// 
			// PORTrealmBOX
			// 
			this.PORTrealmBOX.Location = new System.Drawing.Point(192, 48);
			this.PORTrealmBOX.MaxLength = 4;
			this.PORTrealmBOX.Name = "PORTrealmBOX";
			this.PORTrealmBOX.Size = new System.Drawing.Size(32, 20);
			this.PORTrealmBOX.TabIndex = 2;
			this.PORTrealmBOX.Text = "";
			// 
			// EHOSTrealmLABEL
			// 
			this.EHOSTrealmLABEL.Location = new System.Drawing.Point(56, 120);
			this.EHOSTrealmLABEL.Name = "EHOSTrealmLABEL";
			this.EHOSTrealmLABEL.Size = new System.Drawing.Size(80, 16);
			this.EHOSTrealmLABEL.TabIndex = 3;
			this.EHOSTrealmLABEL.Text = "External IP :";
			// 
			// UPDATEPORTrealmLABEL
			// 
			this.UPDATEPORTrealmLABEL.Location = new System.Drawing.Point(192, 120);
			this.UPDATEPORTrealmLABEL.Name = "UPDATEPORTrealmLABEL";
			this.UPDATEPORTrealmLABEL.Size = new System.Drawing.Size(72, 16);
			this.UPDATEPORTrealmLABEL.TabIndex = 2;
			this.UPDATEPORTrealmLABEL.Text = "Update Port :";
			// 
			// PORTrealmLABEL
			// 
			this.PORTrealmLABEL.Location = new System.Drawing.Point(192, 32);
			this.PORTrealmLABEL.Name = "PORTrealmLABEL";
			this.PORTrealmLABEL.Size = new System.Drawing.Size(32, 16);
			this.PORTrealmLABEL.TabIndex = 1;
			this.PORTrealmLABEL.Text = "Port :";
			// 
			// IPrealmLABEL
			// 
			this.IPrealmLABEL.Location = new System.Drawing.Point(56, 32);
			this.IPrealmLABEL.Name = "IPrealmLABEL";
			this.IPrealmLABEL.Size = new System.Drawing.Size(64, 16);
			this.IPrealmLABEL.TabIndex = 0;
			this.IPrealmLABEL.Text = "IP Adress :";
			// 
			// configBOX
			// 
			this.configBOX.Controls.Add(this.CANCELconfigBUTTON);
			this.configBOX.Controls.Add(this.OKconfigBUTTON);
			this.configBOX.Controls.Add(this.configTABCONTROL);
			this.configBOX.Location = new System.Drawing.Point(8, 16);
			this.configBOX.Name = "configBOX";
			this.configBOX.Size = new System.Drawing.Size(416, 288);
			this.configBOX.TabIndex = 1;
			this.configBOX.TabStop = false;
			this.configBOX.Text = "Configuration";
			// 
			// CANCELconfigBUTTON
			// 
			this.CANCELconfigBUTTON.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CANCELconfigBUTTON.Location = new System.Drawing.Point(336, 248);
			this.CANCELconfigBUTTON.Name = "CANCELconfigBUTTON";
			this.CANCELconfigBUTTON.Size = new System.Drawing.Size(64, 32);
			this.CANCELconfigBUTTON.TabIndex = 2;
			this.CANCELconfigBUTTON.Text = "&Cancel";
			this.CANCELconfigBUTTON.Click += new System.EventHandler(this.CANCELconfigBUTTON_Click);
			// 
			// OKconfigBUTTON
			// 
			this.OKconfigBUTTON.Location = new System.Drawing.Point(256, 248);
			this.OKconfigBUTTON.Name = "OKconfigBUTTON";
			this.OKconfigBUTTON.Size = new System.Drawing.Size(64, 32);
			this.OKconfigBUTTON.TabIndex = 1;
			this.OKconfigBUTTON.Text = "&Save";
			this.OKconfigBUTTON.Click += new System.EventHandler(this.OKconfigBUTTON_Click);
			// 
			// WinConf
			// 
			this.AcceptButton = this.OKconfigBUTTON;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CANCELconfigBUTTON;
			this.ClientSize = new System.Drawing.Size(432, 310);
			this.Controls.Add(this.configBOX);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WinConf";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuration";
			this.TopMost = true;
			this.configTABCONTROL.ResumeLayout(false);
			this.loginserverPAGE.ResumeLayout(false);
			this.worldserverPAGE.ResumeLayout(false);
			this.realmlistPAGE.ResumeLayout(false);
			this.configBOX.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void CANCELconfigBUTTON_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		LoginServerConfig config = new LoginServerConfig(Application.StartupPath + "loginserver.config");
		
		private string loginserverconfig = Application.StartupPath + @"\LoginServer.config";
		private void LoadLoginConfig()
		{

			XmlReader xml = null;
			try
			{
				xml = new XmlTextReader ( loginserverconfig );
				while (xml.Read())
				{
					switch (xml.Name)
					{
						case "ServerName":
							serverBOX.Text = xml.ReadString();
							break;
						case "Address":
							IPloginBOX.Text = xml.ReadString();
							break;
						case "Port":
							PORTloginBOX.Text = xml.ReadString();
							break;
						case "RedirectPort":
							REDPORTloginBOX.Text = xml.ReadString();
							break;
						case "ExternalHost":
							EHOSTloginBOX.Text = xml.ReadString();
							break;
					}
				}
			}
			catch ( Exception ex)
			{
				MessageBox.Show ( "Error reading config file: "+ ex.ToString());
			}
		}


		private string realmlistconfig = Application.StartupPath + @"\Realmlist.config";
		private void LoadRealmConfig()
		{

			XmlReader xml = null;
			try
			{

				xml = new XmlTextReader ( realmlistconfig );
				while (xml.Read())
				{
					switch (xml.Name)
					{
						case "Address":
							IPrealmBOX.Text = xml.ReadString();
							break;
						case "Port":
							PORTrealmBOX.Text = xml.ReadString();
							break;
						case "UpdatePort":
							UPORTrealmBOX.Text = xml.ReadString();
							break;
						case "ExternalHost":
							EHOSTrealmBOX.Text = xml.ReadString();
							break;
					}
				}
			}
			catch ( Exception ex)
			{
				MessageBox.Show ( "Error reading config file: "+ ex.ToString());
			}
		}


		private string worldserverconfig = Application.StartupPath + @"\worldserver.config";
		private void LoadWorldConfig()
		{

			XmlReader xml = null;
			try
			{
				xml = new XmlTextReader ( worldserverconfig );
				while (xml.Read())
				{
					switch (xml.Name)
					{
						case "Address":
							IPworldBOX.Text = xml.ReadString();
							break;
						case "Port":
							PORTworldBOX.Text = xml.ReadString();
							break;
					}
				}
			}
			catch ( Exception ex)
			{
				MessageBox.Show ( "Error reading config file: "+ ex.ToString());
			}
		}

		private void OKconfigBUTTON_Click(object sender, System.EventArgs e)
		{
			XmlTextWriter xml = null;
			try
			{
				xml = new XmlTextWriter(loginserverconfig, null);
				xml.Formatting = Formatting.Indented;
				xml.Indentation = 2;
				xml.Namespaces = false;
				xml.WriteStartDocument();

				xml.WriteStartElement("LoginServerConfig");
				
				xml.WriteStartElement("ScriptReference");
				xml.WriteString("System.dll");
				xml.WriteEndElement();
				xml.Flush();
				xml.WriteStartElement("ScriptReference");
				xml.WriteString("WoWDaemon.Common.dll");
				xml.WriteEndElement();
				xml.Flush();
				xml.WriteStartElement("ScriptReference");
				xml.WriteString("WoWDaemon.Database.dll");
				xml.WriteEndElement();
				xml.Flush();
				xml.WriteStartElement("ScriptReference");
				xml.WriteString("WoWDaemon.LoginServer.dll");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("WorldServer");
				
				xml.WriteStartElement("Address");
				xml.WriteString("local");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("Worldmaps");
				xml.WriteString("all");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("RealmList");
				
				xml.WriteStartElement("ClassType");
				xml.WriteString("WoWDaemon.Login.RealmListUpdater");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("Address");
				xml.WriteString("local");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("Password");
				xml.WriteString(string.Empty);
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("ServerName");
				xml.WriteString(serverBOX.Text);
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("Address");
				xml.WriteString(IPloginBOX.Text);
				xml.WriteEndElement();
				xml.Flush();

				if (this.LOGINexternalCHECKBOX.Checked == true)
				{
					xml.WriteStartElement("ExternalHost");
					xml.WriteString(EHOSTloginBOX.Text);
					xml.WriteEndElement();
					xml.Flush();
				}

				xml.WriteStartElement("Port");
				xml.WriteString(PORTloginBOX.Text);
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("RedirectPort");
				xml.WriteString(REDPORTloginBOX.Text);
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteEndDocument();
				xml.Flush();


				xml = new XmlTextWriter(realmlistconfig, null);
				xml.Formatting = Formatting.Indented;
				xml.Indentation = 2;
				xml.Namespaces = false;
				xml.WriteStartDocument();

				xml.WriteStartElement("RealmListConfig");
				
				xml.WriteStartElement("Address");
				xml.WriteString(IPrealmBOX.Text);
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("Port");
				xml.WriteString(PORTrealmBOX.Text);
				xml.WriteEndElement();
				xml.Flush();

				
				xml.WriteStartElement("Password");
				xml.WriteString(string.Empty);
				xml.WriteEndElement();
				xml.Flush();
				
				if (this.REALMexternalCHECKBOX.Checked == true)
				{
					xml.WriteStartElement("ExternalHost");
					xml.WriteString(EHOSTrealmBOX.Text);
					xml.WriteEndElement();
					xml.Flush();

					xml.WriteStartElement("UpdatePort");
					xml.WriteString(UPORTrealmBOX.Text);
					xml.WriteEndElement();
					xml.Flush();

				}

				xml.WriteEndDocument();
				xml.Flush();


				xml = new XmlTextWriter(worldserverconfig, null);
				xml.Formatting = Formatting.Indented;
				xml.Indentation = 2;
				xml.Namespaces = false;
				xml.WriteStartDocument();

				xml.WriteStartElement("WorldServerConfig");
				
				xml.WriteStartElement("Address");
				xml.WriteString(IPworldBOX.Text);
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("Port");
				xml.WriteString(PORTworldBOX.Text);
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("Scripts");
				xml.WriteString("scripts/world/");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("ScriptReference");
				xml.WriteString("System.dll");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("ScriptReference");
				xml.WriteString("WoWDaemon.Common.dll");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("ScriptReference");
				xml.WriteString("WoWDaemon.Database.dll");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteStartElement("ScriptReference");
				xml.WriteString("WoWDaemon.WorldServer.dll");
				xml.WriteEndElement();
				xml.Flush();

				xml.WriteEndDocument();
				xml.Flush();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void LOGINexternalCHECKBOX_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.LOGINexternalCHECKBOX.Checked == true)
			{
				this.EHOSTloginBOX.Enabled = true;
				this.EHOSTloginBOX.Update();
			}
			else
			{
				this.EHOSTloginBOX.Enabled = false;
				this.EHOSTloginBOX.Update();
			}
		}

		private void REALMexternalCHECKBOX_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.REALMexternalCHECKBOX.Checked == true)
			{
				this.EHOSTrealmBOX.Enabled = true;
				this.EHOSTrealmLABEL.Update();
				this.UPORTrealmBOX.Enabled = true;
				this.UPORTrealmBOX.Update();
			}
			else
			{
				this.EHOSTrealmBOX.Enabled = false;
				this.EHOSTrealmLABEL.Update();
				this.UPORTrealmBOX.Enabled = false;
				this.UPORTrealmBOX.Update();
			}
		}
	}

	#region CONFIG
	public class Config
	{
		public XmlDocument m_document = new XmlDocument();
		string m_file;
		public Config(string file)
		{
			m_file = file;
			try
			{
				m_document.Load(file);
			}
			catch(Exception)
			{
				SetDefaultValues();
				Save();
				return;
			}
		}

		public XmlDocument Document
		{
			get { return m_document;}
		}

		public void Save()
		{
			m_document.Save(m_file);
		}

		public virtual void SetDefaultValues()
		{
		}
	}

	public class RealmListConfig : Config
	{
		public RealmListConfig(string file) : base(file)
		{
		}

		public override void SetDefaultValues()
		{
			XmlElement child;
			XmlElement root = m_document.CreateElement("RealmListConfig");
			child = m_document.CreateElement("Address");
			child.InnerText = "any";
			root.AppendChild(child);

			child = m_document.CreateElement("Port");
			child.InnerText = "3724";
			root.AppendChild(child);

			child = m_document.CreateElement("UpdatePort");
			child.InnerText = "3725";
			root.AppendChild(child);

			child = m_document.CreateElement("Password");
			child.InnerText = "";
			root.AppendChild(child);

			child = m_document.CreateElement("ExternalHost");
			child.InnerText = "";
			root.AppendChild(child);

			m_document.AppendChild(root);
		}

		public string Address
		{
			get 
			{
				try
				{
					return m_document["RealmListConfig"]["Address"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public int Port
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["RealmListConfig"]["Port"].InnerText);
				}
				catch(Exception)
				{
					return 3724;
				}
			}
		}

		public int UpdatePort
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["RealmListConfig"]["UpdatePort"].InnerText);
				}
				catch(Exception)
				{
					return 3725;
				}
			}
		}

		public string ExternalHost
		{
			get 
			{
				try
				{
					return m_document["LoginServerConfig"]["ExternalHost"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public string Password
		{
			get
			{
				try
				{
					return m_document["RealmListConfig"]["Password"].InnerText;
				}
				catch(Exception)
				{
					return string.Empty;
				}
			}
		}
	}


	public class WorldServerConfig : Config
	{
		public WorldServerConfig(string file) : base(file)
		{
		}

		public override void SetDefaultValues()
		{
			XmlElement child;
			XmlElement root = m_document.CreateElement("WorldServerConfig");
			child = m_document.CreateElement("Address");
			child.InnerText = "any";
			root.AppendChild(child);

			child = m_document.CreateElement("Port");
			child.InnerText = "9003";
			root.AppendChild(child);

			child = m_document.CreateElement("Scripts");
			child.InnerText = "scripts/world/";
			root.AppendChild(child);
			m_document.AppendChild(root);

			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "System.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.Common.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.Database.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.WorldServer.dll";
			root.AppendChild(child);

		}

		public string Address
		{
			get 
			{
				try
				{
					return m_document["WorldServerConfig"]["Address"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public int Port
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["WorldServerConfig"]["Port"].InnerText);
				}
				catch(Exception)
				{
					return 9000;
				}
			}
		}


		public string Scripts
		{
			get
			{
				try
				{
					return m_document["WorldServerConfig"]["Scripts"].InnerText;
				}
				catch(Exception)
				{
					return "scripts/world/";
				}
			}
		}
	}

	public class LoginServerConfig : Config
	{
		public LoginServerConfig(string file) : base(file)
		{
		}

		public override void SetDefaultValues()
		{
			XmlElement child;
			XmlElement root = m_document.CreateElement("LoginServerConfig");
			child = m_document.CreateElement("ServerName");
			child.InnerText = "WoWDaemon Server";
			root.AppendChild(child);

			child = m_document.CreateElement("Address");
			child.InnerText = "any";
			root.AppendChild(child);

			child = m_document.CreateElement("ExternalHost");
			child.InnerText = "";
			root.AppendChild(child);

			child = m_document.CreateElement("Port");
			child.InnerText = "9001";
			root.AppendChild(child);

			child = m_document.CreateElement("RedirectPort");
			child.InnerText = "9002";
			root.AppendChild(child);

			child = m_document.CreateElement("Scripts");
			child.InnerText = "scripts/login/";
			root.AppendChild(child);

			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "System.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.Common.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.Database.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.LoginServer.dll";
			root.AppendChild(child);


			XmlElement server = m_document.CreateElement("WorldServer");
			XmlComment comment = m_document.CreateComment("Use 'local' to start up a worldserver in the same process.");
			server.AppendChild(comment);
			comment = m_document.CreateComment("For remote server type address[:port] like 123.123.123.123:5123");
			server.AppendChild(comment);
			child = m_document.CreateElement("Address");
			child.InnerText = "local";
			server.AppendChild(child);
			
			comment = m_document.CreateComment("Use 'all' to set this server to handle all the worldmaps in the database.");
			server.AppendChild(comment);
			comment = m_document.CreateComment("Otherwise type the ids like so: 1 2 3 4 5");
			server.AppendChild(comment);
			child = m_document.CreateElement("Worldmaps");
			child.InnerText = "all";
			server.AppendChild(child);

			root.AppendChild(server);

			server = m_document.CreateElement("RealmList");
			child = m_document.CreateElement("ClassType");
			child.InnerText = "WoWDaemon.Login.RealmListUpdater";
			server.AppendChild(child);
			child = m_document.CreateElement("Address");
			child.InnerText = "local";
			server.AppendChild(child);
			child = m_document.CreateElement("Password");
			child.InnerText = string.Empty;
			server.AppendChild(child);
			root.AppendChild(server);
			m_document.AppendChild(root);
		}

		public string ServerName
		{
			get 
			{
				try
				{
					return m_document["LoginServerConfig"]["ServerName"].InnerText;
				}
				catch(Exception)
				{
					return "John Error's Server";
				}
			}
		}

		public string Address
		{
			get 
			{
				try
				{
					return m_document["LoginServerConfig"]["Address"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public string ExternalHost
		{
			get 
			{
				try
				{
					return m_document["LoginServerConfig"]["ExternalHost"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public int Port
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["LoginServerConfig"]["Port"].InnerText);
				}
				catch(Exception)
				{
					return 9001;
				}
			}
		}

		public int RedirectPort
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["LoginServerConfig"]["RedirectPort"].InnerText);
				}
				catch(Exception)
				{
					return 9002;
				}
			}
		}

		public string Scripts
		{
			get
			{
				try
				{
					return m_document["LoginServerConfig"]["Scripts"].InnerText;
				}
				catch(Exception)
				{
					return "scripts/login/";
				}
			}
		}
	}
	#endregion
}
							
				