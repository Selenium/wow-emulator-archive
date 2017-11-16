using System;
using System.Text.RegularExpressions;
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
	/// Summary description for PlayerConfig.
	/// </summary>
	public class PlayerConfig : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button savePLAYECONF;
		private System.Windows.Forms.Button cancelPLAYERCONF;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Button searchPLAYERCONF;
		private System.Windows.Forms.TextBox genderUSER;
		private System.Windows.Forms.TextBox classUSER;
		private System.Windows.Forms.TextBox raceUSER;
		private System.Windows.Forms.TextBox nameUSER;
		private System.Windows.Forms.TextBox mhealtUSER;
		private System.Windows.Forms.TextBox healthUSER;
		private System.Windows.Forms.TextBox mpowerUSER;
		private System.Windows.Forms.TextBox spiUSER;
		private System.Windows.Forms.TextBox staUSER;
		private System.Windows.Forms.TextBox agilUSER;
		private System.Windows.Forms.TextBox intUSER;
		private System.Windows.Forms.TextBox strUSER;
		private System.Windows.Forms.TextBox bspiUSER;
		private System.Windows.Forms.TextBox bstaUSER;
		private System.Windows.Forms.TextBox bagilUSER;
		private System.Windows.Forms.TextBox bintUSER;
		private System.Windows.Forms.TextBox bstrUSER;
		private System.Windows.Forms.TextBox resholyUSER;
		private System.Windows.Forms.TextBox resfrostUSER;
		private System.Windows.Forms.TextBox resnatuUSER;
		private System.Windows.Forms.TextBox resshadUSER;
		private System.Windows.Forms.TextBox resfireUSER;
		private System.Windows.Forms.TextBox resphysUSER;
		private System.Windows.Forms.TextBox expUSER;
		private System.Windows.Forms.TextBox attpwrUSER;
		private System.Windows.Forms.TextBox attpowrmodUSER;
		private System.Windows.Forms.TextBox skillUSER;
		private System.Windows.Forms.TextBox moneyUSER;
		private System.Windows.Forms.TextBox talentUSER;
		private System.Windows.Forms.TextBox searchnameUSER;
		private System.Windows.Forms.Label powerUSERtext;
		private System.Windows.Forms.TextBox powerUSER;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PlayerConfig()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PlayerConfig));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.genderUSER = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.classUSER = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.raceUSER = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nameUSER = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.savePLAYECONF = new System.Windows.Forms.Button();
			this.cancelPLAYERCONF = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.mhealtUSER = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.healthUSER = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.powerUSERtext = new System.Windows.Forms.Label();
			this.mpowerUSER = new System.Windows.Forms.TextBox();
			this.powerUSER = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.spiUSER = new System.Windows.Forms.TextBox();
			this.staUSER = new System.Windows.Forms.TextBox();
			this.agilUSER = new System.Windows.Forms.TextBox();
			this.intUSER = new System.Windows.Forms.TextBox();
			this.strUSER = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.bspiUSER = new System.Windows.Forms.TextBox();
			this.bstaUSER = new System.Windows.Forms.TextBox();
			this.bagilUSER = new System.Windows.Forms.TextBox();
			this.bintUSER = new System.Windows.Forms.TextBox();
			this.bstrUSER = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.resholyUSER = new System.Windows.Forms.TextBox();
			this.resfrostUSER = new System.Windows.Forms.TextBox();
			this.resnatuUSER = new System.Windows.Forms.TextBox();
			this.resshadUSER = new System.Windows.Forms.TextBox();
			this.resfireUSER = new System.Windows.Forms.TextBox();
			this.resphysUSER = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.expUSER = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.attpwrUSER = new System.Windows.Forms.TextBox();
			this.attpowrmodUSER = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.skillUSER = new System.Windows.Forms.TextBox();
			this.moneyUSER = new System.Windows.Forms.TextBox();
			this.talentUSER = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.searchPLAYERCONF = new System.Windows.Forms.Button();
			this.searchnameUSER = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.genderUSER);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.classUSER);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.raceUSER);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.nameUSER);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(416, 72);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Information";
			// 
			// genderUSER
			// 
			this.genderUSER.BackColor = System.Drawing.SystemColors.Menu;
			this.genderUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.genderUSER.ForeColor = System.Drawing.Color.Brown;
			this.genderUSER.Location = new System.Drawing.Point(328, 40);
			this.genderUSER.Name = "genderUSER";
			this.genderUSER.ReadOnly = true;
			this.genderUSER.Size = new System.Drawing.Size(72, 20);
			this.genderUSER.TabIndex = 7;
			this.genderUSER.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(328, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Gender";
			// 
			// classUSER
			// 
			this.classUSER.BackColor = System.Drawing.SystemColors.Menu;
			this.classUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.classUSER.ForeColor = System.Drawing.Color.Brown;
			this.classUSER.Location = new System.Drawing.Point(240, 40);
			this.classUSER.Name = "classUSER";
			this.classUSER.ReadOnly = true;
			this.classUSER.Size = new System.Drawing.Size(64, 20);
			this.classUSER.TabIndex = 5;
			this.classUSER.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(240, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Class";
			// 
			// raceUSER
			// 
			this.raceUSER.BackColor = System.Drawing.SystemColors.Menu;
			this.raceUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.raceUSER.ForeColor = System.Drawing.Color.Brown;
			this.raceUSER.Location = new System.Drawing.Point(152, 40);
			this.raceUSER.Name = "raceUSER";
			this.raceUSER.ReadOnly = true;
			this.raceUSER.Size = new System.Drawing.Size(64, 20);
			this.raceUSER.TabIndex = 3;
			this.raceUSER.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(152, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Race :";
			// 
			// nameUSER
			// 
			this.nameUSER.BackColor = System.Drawing.SystemColors.Menu;
			this.nameUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nameUSER.ForeColor = System.Drawing.Color.Brown;
			this.nameUSER.Location = new System.Drawing.Point(8, 40);
			this.nameUSER.MaxLength = 20;
			this.nameUSER.Name = "nameUSER";
			this.nameUSER.ReadOnly = true;
			this.nameUSER.Size = new System.Drawing.Size(120, 20);
			this.nameUSER.TabIndex = 2;
			this.nameUSER.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name :";
			// 
			// savePLAYECONF
			// 
			this.savePLAYECONF.Location = new System.Drawing.Point(568, 368);
			this.savePLAYECONF.Name = "savePLAYECONF";
			this.savePLAYECONF.Size = new System.Drawing.Size(75, 32);
			this.savePLAYECONF.TabIndex = 1;
			this.savePLAYECONF.Text = "&Save";
			this.savePLAYECONF.Click += new System.EventHandler(this.savePLAYECONF_Click);
			// 
			// cancelPLAYERCONF
			// 
			this.cancelPLAYERCONF.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelPLAYERCONF.Location = new System.Drawing.Point(648, 368);
			this.cancelPLAYERCONF.Name = "cancelPLAYERCONF";
			this.cancelPLAYERCONF.Size = new System.Drawing.Size(72, 32);
			this.cancelPLAYERCONF.TabIndex = 2;
			this.cancelPLAYERCONF.Text = "&Cancel";
			this.cancelPLAYERCONF.Click += new System.EventHandler(this.cancelPLAYERCONF_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Max Health";
			// 
			// mhealtUSER
			// 
			this.mhealtUSER.Location = new System.Drawing.Point(16, 40);
			this.mhealtUSER.MaxLength = 3;
			this.mhealtUSER.Name = "mhealtUSER";
			this.mhealtUSER.Size = new System.Drawing.Size(40, 20);
			this.mhealtUSER.TabIndex = 9;
			this.mhealtUSER.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(88, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Health";
			// 
			// healthUSER
			// 
			this.healthUSER.Location = new System.Drawing.Point(88, 40);
			this.healthUSER.MaxLength = 3;
			this.healthUSER.Name = "healthUSER";
			this.healthUSER.Size = new System.Drawing.Size(40, 20);
			this.healthUSER.TabIndex = 11;
			this.healthUSER.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(160, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "Max Power";
			// 
			// powerUSERtext
			// 
			this.powerUSERtext.Location = new System.Drawing.Point(240, 24);
			this.powerUSERtext.Name = "powerUSERtext";
			this.powerUSERtext.Size = new System.Drawing.Size(40, 16);
			this.powerUSERtext.TabIndex = 13;
			this.powerUSERtext.Text = "Power";
			// 
			// mpowerUSER
			// 
			this.mpowerUSER.Location = new System.Drawing.Point(168, 40);
			this.mpowerUSER.MaxLength = 3;
			this.mpowerUSER.Name = "mpowerUSER";
			this.mpowerUSER.Size = new System.Drawing.Size(40, 20);
			this.mpowerUSER.TabIndex = 14;
			this.mpowerUSER.Text = "";
			// 
			// powerUSER
			// 
			this.powerUSER.Location = new System.Drawing.Point(240, 40);
			this.powerUSER.MaxLength = 3;
			this.powerUSER.Name = "powerUSER";
			this.powerUSER.Size = new System.Drawing.Size(40, 20);
			this.powerUSER.TabIndex = 15;
			this.powerUSER.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.spiUSER);
			this.groupBox2.Controls.Add(this.staUSER);
			this.groupBox2.Controls.Add(this.agilUSER);
			this.groupBox2.Controls.Add(this.intUSER);
			this.groupBox2.Controls.Add(this.strUSER);
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.bspiUSER);
			this.groupBox2.Controls.Add(this.bstaUSER);
			this.groupBox2.Controls.Add(this.bagilUSER);
			this.groupBox2.Controls.Add(this.bintUSER);
			this.groupBox2.Controls.Add(this.bstrUSER);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Location = new System.Drawing.Point(16, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(416, 152);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Status";
			// 
			// spiUSER
			// 
			this.spiUSER.Location = new System.Drawing.Point(352, 120);
			this.spiUSER.MaxLength = 3;
			this.spiUSER.Name = "spiUSER";
			this.spiUSER.Size = new System.Drawing.Size(32, 20);
			this.spiUSER.TabIndex = 19;
			this.spiUSER.Text = "";
			// 
			// staUSER
			// 
			this.staUSER.Location = new System.Drawing.Point(272, 120);
			this.staUSER.MaxLength = 3;
			this.staUSER.Name = "staUSER";
			this.staUSER.Size = new System.Drawing.Size(32, 20);
			this.staUSER.TabIndex = 18;
			this.staUSER.Text = "";
			// 
			// agilUSER
			// 
			this.agilUSER.Location = new System.Drawing.Point(192, 120);
			this.agilUSER.MaxLength = 3;
			this.agilUSER.Name = "agilUSER";
			this.agilUSER.Size = new System.Drawing.Size(32, 20);
			this.agilUSER.TabIndex = 17;
			this.agilUSER.Text = "";
			// 
			// intUSER
			// 
			this.intUSER.Location = new System.Drawing.Point(112, 120);
			this.intUSER.MaxLength = 3;
			this.intUSER.Name = "intUSER";
			this.intUSER.Size = new System.Drawing.Size(32, 20);
			this.intUSER.TabIndex = 16;
			this.intUSER.Text = "";
			// 
			// strUSER
			// 
			this.strUSER.Location = new System.Drawing.Point(24, 120);
			this.strUSER.MaxLength = 3;
			this.strUSER.Name = "strUSER";
			this.strUSER.Size = new System.Drawing.Size(32, 20);
			this.strUSER.TabIndex = 15;
			this.strUSER.Text = "";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(352, 96);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(40, 16);
			this.label18.TabIndex = 14;
			this.label18.Text = "Spirit";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(264, 96);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 16);
			this.label17.TabIndex = 13;
			this.label17.Text = "Stamina";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(192, 96);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 16);
			this.label16.TabIndex = 12;
			this.label16.Text = "Agility";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(96, 96);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(64, 16);
			this.label15.TabIndex = 11;
			this.label15.Text = "Inteligence";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(24, 96);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(48, 16);
			this.label14.TabIndex = 10;
			this.label14.Text = "Strenght";
			// 
			// bspiUSER
			// 
			this.bspiUSER.Location = new System.Drawing.Point(352, 48);
			this.bspiUSER.MaxLength = 3;
			this.bspiUSER.Name = "bspiUSER";
			this.bspiUSER.Size = new System.Drawing.Size(32, 20);
			this.bspiUSER.TabIndex = 9;
			this.bspiUSER.Text = "";
			// 
			// bstaUSER
			// 
			this.bstaUSER.Location = new System.Drawing.Point(272, 48);
			this.bstaUSER.MaxLength = 3;
			this.bstaUSER.Name = "bstaUSER";
			this.bstaUSER.Size = new System.Drawing.Size(32, 20);
			this.bstaUSER.TabIndex = 8;
			this.bstaUSER.Text = "";
			// 
			// bagilUSER
			// 
			this.bagilUSER.Location = new System.Drawing.Point(192, 48);
			this.bagilUSER.MaxLength = 3;
			this.bagilUSER.Name = "bagilUSER";
			this.bagilUSER.Size = new System.Drawing.Size(32, 20);
			this.bagilUSER.TabIndex = 7;
			this.bagilUSER.Text = "";
			// 
			// bintUSER
			// 
			this.bintUSER.Location = new System.Drawing.Point(112, 48);
			this.bintUSER.MaxLength = 3;
			this.bintUSER.Name = "bintUSER";
			this.bintUSER.Size = new System.Drawing.Size(32, 20);
			this.bintUSER.TabIndex = 6;
			this.bintUSER.Text = "";
			// 
			// bstrUSER
			// 
			this.bstrUSER.Location = new System.Drawing.Point(24, 48);
			this.bstrUSER.MaxLength = 3;
			this.bstrUSER.Name = "bstrUSER";
			this.bstrUSER.Size = new System.Drawing.Size(32, 20);
			this.bstrUSER.TabIndex = 5;
			this.bstrUSER.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(344, 24);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 16);
			this.label13.TabIndex = 4;
			this.label13.Text = "Base Spirit";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(256, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(80, 16);
			this.label12.TabIndex = 3;
			this.label12.Text = "Base Stamina";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(176, 24);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 2;
			this.label11.Text = "Base Agility";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(104, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 16);
			this.label10.TabIndex = 1;
			this.label10.Text = "Base Int";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 0;
			this.label9.Text = "Base Strenght";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.resholyUSER);
			this.groupBox3.Controls.Add(this.resfrostUSER);
			this.groupBox3.Controls.Add(this.resnatuUSER);
			this.groupBox3.Controls.Add(this.resshadUSER);
			this.groupBox3.Controls.Add(this.resfireUSER);
			this.groupBox3.Controls.Add(this.resphysUSER);
			this.groupBox3.Controls.Add(this.label24);
			this.groupBox3.Controls.Add(this.label23);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.label21);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Location = new System.Drawing.Point(16, 272);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(192, 136);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Resistances";
			// 
			// resholyUSER
			// 
			this.resholyUSER.Location = new System.Drawing.Point(144, 104);
			this.resholyUSER.MaxLength = 2;
			this.resholyUSER.Name = "resholyUSER";
			this.resholyUSER.Size = new System.Drawing.Size(32, 20);
			this.resholyUSER.TabIndex = 11;
			this.resholyUSER.Text = "";
			// 
			// resfrostUSER
			// 
			this.resfrostUSER.Location = new System.Drawing.Point(80, 104);
			this.resfrostUSER.MaxLength = 2;
			this.resfrostUSER.Name = "resfrostUSER";
			this.resfrostUSER.Size = new System.Drawing.Size(32, 20);
			this.resfrostUSER.TabIndex = 10;
			this.resfrostUSER.Text = "";
			// 
			// resnatuUSER
			// 
			this.resnatuUSER.Location = new System.Drawing.Point(16, 104);
			this.resnatuUSER.MaxLength = 2;
			this.resnatuUSER.Name = "resnatuUSER";
			this.resnatuUSER.Size = new System.Drawing.Size(32, 20);
			this.resnatuUSER.TabIndex = 9;
			this.resnatuUSER.Text = "";
			// 
			// resshadUSER
			// 
			this.resshadUSER.Location = new System.Drawing.Point(144, 48);
			this.resshadUSER.MaxLength = 2;
			this.resshadUSER.Name = "resshadUSER";
			this.resshadUSER.Size = new System.Drawing.Size(32, 20);
			this.resshadUSER.TabIndex = 8;
			this.resshadUSER.Text = "";
			// 
			// resfireUSER
			// 
			this.resfireUSER.Location = new System.Drawing.Point(80, 48);
			this.resfireUSER.MaxLength = 2;
			this.resfireUSER.Name = "resfireUSER";
			this.resfireUSER.Size = new System.Drawing.Size(32, 20);
			this.resfireUSER.TabIndex = 7;
			this.resfireUSER.Text = "";
			// 
			// resphysUSER
			// 
			this.resphysUSER.Location = new System.Drawing.Point(16, 48);
			this.resphysUSER.MaxLength = 2;
			this.resphysUSER.Name = "resphysUSER";
			this.resphysUSER.Size = new System.Drawing.Size(32, 20);
			this.resphysUSER.TabIndex = 6;
			this.resphysUSER.Text = "";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(80, 80);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(32, 16);
			this.label24.TabIndex = 5;
			this.label24.Text = "Frost";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(136, 24);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(48, 16);
			this.label23.TabIndex = 4;
			this.label23.Text = "Shadow";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(144, 80);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(32, 16);
			this.label22.TabIndex = 3;
			this.label22.Text = "Holy";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(88, 24);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(32, 16);
			this.label21.TabIndex = 2;
			this.label21.Text = "Fire";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(16, 80);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(40, 16);
			this.label20.TabIndex = 1;
			this.label20.Text = "Nature";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 24);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(48, 16);
			this.label19.TabIndex = 0;
			this.label19.Text = "Physical";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(32, 80);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(64, 16);
			this.label25.TabIndex = 18;
			this.label25.Text = "Experience";
			// 
			// expUSER
			// 
			this.expUSER.Location = new System.Drawing.Point(40, 104);
			this.expUSER.MaxLength = 4;
			this.expUSER.Name = "expUSER";
			this.expUSER.Size = new System.Drawing.Size(40, 20);
			this.expUSER.TabIndex = 19;
			this.expUSER.Text = "";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(120, 80);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(56, 16);
			this.label26.TabIndex = 20;
			this.label26.Text = "Att Power";
			// 
			// attpwrUSER
			// 
			this.attpwrUSER.Location = new System.Drawing.Point(128, 104);
			this.attpwrUSER.MaxLength = 4;
			this.attpwrUSER.Name = "attpwrUSER";
			this.attpwrUSER.Size = new System.Drawing.Size(40, 20);
			this.attpwrUSER.TabIndex = 21;
			this.attpwrUSER.Text = "";
			// 
			// attpowrmodUSER
			// 
			this.attpowrmodUSER.Location = new System.Drawing.Point(216, 104);
			this.attpowrmodUSER.MaxLength = 4;
			this.attpowrmodUSER.Name = "attpowrmodUSER";
			this.attpowrmodUSER.Size = new System.Drawing.Size(40, 20);
			this.attpowrmodUSER.TabIndex = 22;
			this.attpowrmodUSER.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(192, 80);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(96, 16);
			this.label27.TabIndex = 23;
			this.label27.Text = "Att Power Modifer";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(32, 144);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(64, 16);
			this.label28.TabIndex = 24;
			this.label28.Text = "Skill Points";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(208, 144);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(72, 16);
			this.label29.TabIndex = 25;
			this.label29.Text = "Talent Points";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(128, 144);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(40, 16);
			this.label30.TabIndex = 26;
			this.label30.Text = "Money";
			// 
			// skillUSER
			// 
			this.skillUSER.Location = new System.Drawing.Point(40, 168);
			this.skillUSER.MaxLength = 4;
			this.skillUSER.Name = "skillUSER";
			this.skillUSER.Size = new System.Drawing.Size(40, 20);
			this.skillUSER.TabIndex = 27;
			this.skillUSER.Text = "";
			// 
			// moneyUSER
			// 
			this.moneyUSER.Location = new System.Drawing.Point(128, 168);
			this.moneyUSER.MaxLength = 4;
			this.moneyUSER.Name = "moneyUSER";
			this.moneyUSER.Size = new System.Drawing.Size(40, 20);
			this.moneyUSER.TabIndex = 28;
			this.moneyUSER.Text = "";
			// 
			// talentUSER
			// 
			this.talentUSER.Location = new System.Drawing.Point(216, 168);
			this.talentUSER.MaxLength = 4;
			this.talentUSER.Name = "talentUSER";
			this.talentUSER.Size = new System.Drawing.Size(40, 20);
			this.talentUSER.TabIndex = 29;
			this.talentUSER.Text = "";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.powerUSER);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.powerUSERtext);
			this.groupBox4.Controls.Add(this.label29);
			this.groupBox4.Controls.Add(this.moneyUSER);
			this.groupBox4.Controls.Add(this.attpowrmodUSER);
			this.groupBox4.Controls.Add(this.healthUSER);
			this.groupBox4.Controls.Add(this.mpowerUSER);
			this.groupBox4.Controls.Add(this.skillUSER);
			this.groupBox4.Controls.Add(this.expUSER);
			this.groupBox4.Controls.Add(this.talentUSER);
			this.groupBox4.Controls.Add(this.mhealtUSER);
			this.groupBox4.Controls.Add(this.label28);
			this.groupBox4.Controls.Add(this.attpwrUSER);
			this.groupBox4.Controls.Add(this.label27);
			this.groupBox4.Controls.Add(this.label26);
			this.groupBox4.Controls.Add(this.label30);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.label25);
			this.groupBox4.Location = new System.Drawing.Point(440, 16);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(296, 240);
			this.groupBox4.TabIndex = 30;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Epecifiques";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.searchPLAYERCONF);
			this.groupBox5.Controls.Add(this.searchnameUSER);
			this.groupBox5.Controls.Add(this.label31);
			this.groupBox5.Location = new System.Drawing.Point(216, 272);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(216, 136);
			this.groupBox5.TabIndex = 31;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Search";
			// 
			// searchPLAYERCONF
			// 
			this.searchPLAYERCONF.Location = new System.Drawing.Point(64, 88);
			this.searchPLAYERCONF.Name = "searchPLAYERCONF";
			this.searchPLAYERCONF.Size = new System.Drawing.Size(88, 32);
			this.searchPLAYERCONF.TabIndex = 4;
			this.searchPLAYERCONF.Text = "Sea&rch";
			this.searchPLAYERCONF.Click += new System.EventHandler(this.searchPLAYERCONF_Click);
			// 
			// searchnameUSER
			// 
			this.searchnameUSER.Location = new System.Drawing.Point(64, 56);
			this.searchnameUSER.MaxLength = 8;
			this.searchnameUSER.Name = "searchnameUSER";
			this.searchnameUSER.Size = new System.Drawing.Size(88, 20);
			this.searchnameUSER.TabIndex = 1;
			this.searchnameUSER.Text = "";
			this.searchnameUSER.TextChanged += new System.EventHandler(this.searchnameUSER_TextChanged);
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(80, 24);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(64, 16);
			this.label31.TabIndex = 0;
			this.label31.Text = "By Name :";
			// 
			// PlayerConfig
			// 
			this.AcceptButton = this.searchPLAYERCONF;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelPLAYERCONF;
			this.ClientSize = new System.Drawing.Size(752, 422);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.cancelPLAYERCONF);
			this.Controls.Add(this.savePLAYECONF);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "PlayerConfig";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "User Information";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void searchPLAYERCONF_Click(object sender, System.EventArgs e)
		{
			string name = this.searchnameUSER.Text;
			DBCharacter c = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name);

			if (c == null)
			{
				MessageBox.Show("User not found");
			}
			else
			{

				this.nameUSER.Text = c.Name;
				this.nameUSER.Update();
				switch((RACE)c.Race)
				{
					case RACE.HUMAN:
						this.raceUSER.Text = "Human";
						this.raceUSER.Update();
						break;
					case RACE.DWARF:
						this.raceUSER.Text = "Dwarf";
						this.raceUSER.Update();
						break;
					case RACE.GNOME:
						this.raceUSER.Text = "Gnome";
						this.raceUSER.Update();
						break;
					case RACE.GOBLIN:
						this.raceUSER.Text = "Goblin";
						this.raceUSER.Update();
						break;
					case RACE.NIGHTELF:
						this.raceUSER.Text = "Night Elf";
						this.raceUSER.Update();
						break;
					case RACE.ORC:
						this.raceUSER.Text = "Orc";
						this.raceUSER.Update();
						break;
					case RACE.TAUREN:
						this.raceUSER.Text = "Tauren";
						this.raceUSER.Update();
						break;
					case RACE.TROLL:
						this.raceUSER.Text = "Troll";
						this.raceUSER.Update();
						break;
					case RACE.UNDEAD:
						this.raceUSER.Text = "Undead";
						this.raceUSER.Update();
						break;
				}
				switch((CLASS)c.Class)
				{
					case CLASS.DRUID:
						this.classUSER.Text = "Druid";
						this.classUSER.Update();
						break;

					case CLASS.HUNTER:
						this.classUSER.Text = "Hunter";
						this.classUSER.Update();
						break;
					case CLASS.MAGE:
						this.classUSER.Text = "Mage";
						this.classUSER.Update();
						break;
					case CLASS.PALADIN:
						this.classUSER.Text = "Paladin";
						this.classUSER.Update();
						break;
					case CLASS.PRIEST:
						this.classUSER.Text = "Priest";
						this.classUSER.Update();
						break;
					case CLASS.ROGUE:
						this.classUSER.Text = "Rogue";
						this.classUSER.Update();
						break;
					case CLASS.SHAMAN:
						this.classUSER.Text = "Shaman";
						this.classUSER.Update();
						break;
					case CLASS.WARLOCK:
						this.classUSER.Text = "Warlock";
						this.classUSER.Update();
						break;
					case CLASS.WARRIOR:
						this.classUSER.Text = "Warrior";
						this.classUSER.Update();
						break;
				}

				if (c.Gender == 0)
				{
					this.genderUSER.Text = "Male";
					this.genderUSER.Update();
				}
				else
				{
					this.genderUSER.Text = "Female";
					this.genderUSER.Update();
				}

				this.mhealtUSER.Text = c.MaxHealth.ToString();
				this.mhealtUSER.Update();
				this.healthUSER.Text = c.Health.ToString();
				this.healthUSER.Update();
				this.mpowerUSER.Text = c.MaxPower.ToString();
				this.mpowerUSER.Update();
				this.powerUSER.Text = c.Power.ToString();
				this.powerUSER.Update();
				this.expUSER.Text = c.Exp.ToString();
				this.expUSER.Update();
				this.attpwrUSER.Text = c.AttackPower.ToString();
				this.attpwrUSER.Update();
				this.attpowrmodUSER.Text = c.AttackPowerModifier.ToString();
				this.attpowrmodUSER.Update();
				this.skillUSER.Text = c.SkillPoints.ToString();
				this.skillUSER.Update();
				this.moneyUSER.Text = c.Money.ToString();
				this.moneyUSER.Update();
				this.talentUSER.Text = c.TalentPoints.ToString();
				this.talentUSER.Update();
				this.bstrUSER.Text = c.BaseStrength.ToString();
				this.bstrUSER.Update();
				this.bintUSER.Text = c.BaseIntellect.ToString();
				this.bintUSER.Update();
				this.bagilUSER.Text = c.BaseAgility.ToString();
				this.bagilUSER.Update();
				this.bstaUSER.Text = c.BaseStamina.ToString();
				this.bstaUSER.Update();
				this.bspiUSER.Text = c.BaseSpirit.ToString();
				this.bstrUSER.Update();
				this.resfireUSER.Text = c.Resist_Fire.ToString();
				this.resfireUSER.Update();
				this.resfrostUSER.Text = c.Resist_Frost.ToString();
				this.resfrostUSER.Update();
				this.resholyUSER.Text = c.Resist_Holy.ToString();
				this.resholyUSER.Update();
				this.resnatuUSER.Text = c.Resist_Nature.ToString();
				this.resnatuUSER.Update();
				this.resphysUSER.Text = c.Resist_Physical.ToString();
				this.resphysUSER.Update();
				this.resshadUSER.Text = c.Resist_Shadow.ToString();
				this.resshadUSER.Update();
			}
		}

		private void cancelPLAYERCONF_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		static Regex itemCheck = new Regex(@"[^1-99]", RegexOptions.Compiled);
		private void savePLAYECONF_Click(object sender, System.EventArgs e)
		{
			string name = this.nameUSER.Text;
			if (name == string.Empty)
			{
				MessageBox.Show("Can not save empty info");
			}
			else
			{
				
				DBCharacter c = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), name);
				
				WorldClient client = WorldServer.GetClientByCharacterID(c.ObjectId);

				client.Player.MaxHealth = Convert.ToInt32(this.mhealtUSER.Text);
				client.Player.Health = Convert.ToInt32(this.healthUSER.Text);
				client.Player.MaxPower = Convert.ToInt32(this.mpowerUSER.Text);
				client.Player.Power = Convert.ToInt32(this.powerUSER.Text);
				client.Player.Exp = Convert.ToInt32(this.expUSER.Text);
				client.Player.AttackPower = Convert.ToInt32(this.attpwrUSER.Text);
				client.Player.AttackPowerModifier = Convert.ToInt32(this.attpowrmodUSER.Text);
				client.Player.AttackPowerModifier = Convert.ToInt32(this.skillUSER.Text);
				client.Player.TalentPoints = Convert.ToInt32(this.talentUSER.Text);
				client.Player.Money = Convert.ToInt32(this.moneyUSER.Text);
				client.Player.BaseAgility = Convert.ToInt32(this.bagilUSER.Text);
				client.Player.BaseIntellect = Convert.ToInt32(this.bintUSER.Text);
				client.Player.BaseSpirit = Convert.ToInt32(this.bspiUSER.Text);
				client.Player.BaseStamina = Convert.ToInt32(this.bstaUSER.Text);
				client.Player.BaseStrength = Convert.ToInt32(this.bstrUSER.Text);
				client.Player.Resist_Fire = Convert.ToInt32(this.resfireUSER.Text);
				client.Player.Resist_Frost = Convert.ToInt32(this.resfrostUSER.Text);
				client.Player.Resist_Holy = Convert.ToInt32(this.resholyUSER.Text);
				client.Player.Resist_Nature = Convert.ToInt32(this.resnatuUSER.Text);
				client.Player.Resist_Physical = Convert.ToInt32(this.resphysUSER.Text);
				client.Player.Resist_Shadow = Convert.ToInt32(this.resshadUSER.Text);
				client.Player.UpdateData();
				
				MessageBox.Show("Character Sucessfully Saved");
			}
		}

		private void searchnameUSER_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

