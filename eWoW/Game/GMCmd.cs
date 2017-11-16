using System;
using System.Collections;

namespace eWoW
{
	public class GMCmd
	{
		Hashtable cmdhelp=new Hashtable();
		Hashtable cmdfunc=new Hashtable();

		delegate void RunFunction(Character c, string[] argv);

		private GameServer gameServer;
		public GMCmd(GameServer gs)
		{
			gameServer = gs;
			Add("help", "help", new RunFunction(Help));
			Add("add", "create a item in bag", new RunFunction(Add));
			Add("test", "test", new RunFunction(Test));
			Add("save", "save data", new RunFunction(Save));
			Add("strip", "strips all items", new RunFunction(Strip));
		}

		void Test(Character c, string[] argv)
		{
			if(argv.Length<3)
			{
				Echo(c, "Error: .test flag value");
				return;
			}
			UpdateFields n=(UpdateFields)int.Parse(argv[1]);
			uint v=(uint)int.Parse(argv[2]);
			c.SetUpdateValue(n, v);
		}

		void Strip(Character c, string[] argv)
		{
			for (int i=0;i<c.items.Length;i++)
			{
				c.items[i] = null;
			}
		}

		void Save(Character c, string[] argv)
		{
			gameServer.SaveWorld();
		}

		void Add(Character c, string[] argv)
		{
			if(argv.Length<2)
			{
				Echo(c, "Error: .add itemid [count]");
				return;
			}

			int cnt=1;
			if(argv.Length==3)cnt=int.Parse(argv[2]);

			for(int i=0; i<cnt; i++)
			{
				uint id=uint.Parse(argv[1]);
				if(!c.AddItem( id ))break;
				Echo(c, "item {0} create", id);
			}
		}


		void Help(Character c, string[] argv)
		{
			ArrayList cmds=new ArrayList();
			cmds.AddRange(cmdhelp.Keys);
			cmds.Sort();

			foreach(string cmd in cmds)
			{
				int len=20-cmd.Length; 
				if(len<0)len=0;
				string p=cmd + new string(' ', len);

				Echo(c, ".{0} {1}", p, cmdhelp[cmd] as string);
			}
		}

		void Add(string cmd, string help, RunFunction func)
		{
			cmdhelp[cmd]=help;
			cmdfunc[cmd]=func;
		}

		static void Echo(Character c, string fmt, params object[] obs)
		{
			string str=String.Format(fmt, obs);

			foreach(string s in str.Split('\n'))
			{
				if(s=="")continue;
				c.MessageChat(CHAT.SYSTEM, 0, s, c.Name);
			}
		}

		public bool Parse(Character c, string text)
		{
			if(!text.StartsWith("."))return false;

			string[] cmds=text.Substring(1).Split(' ', '\t');
			if(cmds.Length==0)return false;

			RunFunction func=cmdfunc[cmds[0]] as RunFunction;
			if(func==null)
			{
				Echo(c, "unknown cmd {0}, use .help to see GMCmd list", cmds[0]);
				return true;
			}
			try 
			{
				func(c, cmds);
			}
			catch(FormatException e)
			{
				Echo(c, "Input format error : {0}", e.Message);
			}
			return true;
		}
	}
}
