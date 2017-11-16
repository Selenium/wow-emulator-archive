using System;
using System.Reflection;
namespace WoWDaemon.Common
{
	/// <summary>
	/// Summary description for IScriptAssembly.
	/// </summary>
	public interface IScriptAssembly
	{
		void AddAssembly(Assembly assembly);
		bool Load(out string error);
		void Unload();
	}
}
