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
	/// Summary description for AccountConfig.
	/// </summary>
	public class AccountConfig : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button Create;
		private System.Windows.Forms.TextBox passbox;
		private System.Windows.Forms.TextBox namebox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AccountConfig()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AccountConfig));
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.passbox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.namebox = new System.Windows.Forms.TextBox();
			this.Cancel = new System.Windows.Forms.Button();
			this.Create = new System.Windows.Forms.Button();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.namebox);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.passbox);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Location = new System.Drawing.Point(-2, 16);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(296, 136);
			this.groupBox4.TabIndex = 31;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Create New Account";
			this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(56, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Name";
			// 
			// passbox
			// 
			this.passbox.Location = new System.Drawing.Point(56, 88);
			this.passbox.MaxLength = 16;
			this.passbox.Name = "passbox";
			this.passbox.Size = new System.Drawing.Size(104, 20);
			this.passbox.TabIndex = 2;
			this.passbox.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(56, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "Password";
			// 
			// namebox
			// 
			this.namebox.Location = new System.Drawing.Point(56, 40);
			this.namebox.MaxLength = 16;
			this.namebox.Name = "namebox";
			this.namebox.Size = new System.Drawing.Size(104, 20);
			this.namebox.TabIndex = 1;
			this.namebox.Text = "";
			this.namebox.TextChanged += new System.EventHandler(this.namebox_TextChanged);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(112, 176);
			this.Cancel.Name = "Cancel";
			this.Cancel.TabIndex = 4;
			this.Cancel.Text = "Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// Create
			// 
			this.Create.Location = new System.Drawing.Point(16, 176);
			this.Create.Name = "Create";
			this.Create.TabIndex = 3;
			this.Create.Text = "Create";
			this.Create.Click += new System.EventHandler(this.Create_Click);
			// 
			// AccountConfig
			// 
			this.AcceptButton = this.Create;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(216, 229);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.Create);
			this.Controls.Add(this.Cancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AccountConfig";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Account";
			this.Load += new System.EventHandler(this.AccountConfig_Load);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void groupBox4_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		private void AccountConfig_Load(object sender, System.EventArgs e)
		{
		
		}

		private void label26_Click(object sender, System.EventArgs e)
		{
		
		}

		private void namebox_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Cancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Create_Click(object sender, System.EventArgs e)
		{
			string name = Convert.ToString(this.namebox.Text);
			string pass = Convert.ToString(this.passbox.Text);

			if (name == string.Empty)
			{
				MessageBox.Show("No username entered");
			}

			else if (pass == string.Empty)
			{
				MessageBox.Show("No password entered");
			}

			else
			{
				DBAccount account = new DBAccount();
				account.Name = name;
				account.Password = pass;
				DataServer.Database.AddNewObject(account);
				MessageBox.Show("Account created");
                
			}
		}

		private void label5_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
