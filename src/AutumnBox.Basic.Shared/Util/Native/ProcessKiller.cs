/*

* ==============================================================================
*
* Filename: ProcessKiller
* Description: 
*
* Version: 1.0
* Created: 2020/5/16 16:23:51
* Compiler: Visual Studio 2019
*
* Author: zsh2401
*
* ==============================================================================
*/

using System;
using System.Diagnostics;

namespace AutumnBox.Basic.Util.Native
{
    /// <summary>
    /// 进程销毁器
    /// </summary>
    public static class ProcessKiller
    {
        /// <summary>
        /// 尽可能干净地释放一个进程
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">平台不受支持</exception>
        /// <param name="pid"></param>
        public static void FKill(int pid)
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    Win32(pid);
                    break;
                case PlatformID.Unix:
                    Unix(pid);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }
        private static void Win32(int pid)
        {
            Process.GetProcessById(pid).Kill();
            //try
            //{
            //    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
            //    ManagementObjectCollection moc = searcher.Get();
            //    foreach (ManagementObject mo in moc)
            //    {
            //        Win32(Convert.ToInt32(mo["ProcessID"]));
            //    }
            //    Process.GetProcessById(pid);
            //}
            //catch
            //{
            //    /* process already exited */
            //}
        }
        private static void Unix(int pid)
        {
            throw new PlatformNotSupportedException();
        }
    }
}
