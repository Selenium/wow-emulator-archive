/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace RegistryManager
{
    class RegistryManager
    {
        public static string ReturnRegistry()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\HKEY_PROGRAM_DATA_CLASS\\PROGRAM_DATA", true);
            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\HKEY_PROGRAM_DATA_CLASS\\PROGRAM_DATA");
                return "0";
            }
            else if ((string)key.GetValue("RegistryKey") == null)
            {
                return "0";
            }
                return (string)key.GetValue("RegistryKey");
        }
        public static bool RegisterKey(string key)
        {
            if (IsKeyValid(key) == true)
            {
                RegistryKey RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\HKEY_PROGRAM_DATA_CLASS\\PROGRAM_DATA", true);
                if (RegKey == null)
                {
                    RegKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\HKEY_PROGRAM_DATA_CLASS\\PROGRAM_DATA");
                }
                RegKey.SetValue("RegistryKey", key);
                MessageBox.Show("Thank you for buying a valid licence key. Enjoy this program! =)");
                return true;
            }
            Server.ColoredConsole.ConsoleWriteErrorWithOut("Invalid key: " + key);
            return false;
        }
        public static bool UnRegisterKey()
        {
            RegistryKey RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\HKEY_PROGRAM_DATA_CLASS\\PROGRAM_DATA", true);
                if (RegKey == null)
                {
                    RegKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\HKEY_PROGRAM_DATA_CLASS\\PROGRAM_DATA");
                }
                RegKey.DeleteValue("RegistryKey");
                MessageBox.Show("Successfully unregistred the key! (the unregister feature is only for testing purposes and will not be present in the final version)");
                return true;
        }
        public static bool IsKeyValid(string key)
        {
            if (key == "testkey")
                return true;
            else 
                return false;
        }
    }
}