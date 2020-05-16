/*

* ==============================================================================
*
* Filename: CoreVersionInfo
* Description: 
*
* Version: 1.0
* Created: 2020/5/16 18:54:15
* Compiler: Visual Studio 2019
*
* Author: zsh2401
*
* ==============================================================================
*/
using System;

namespace AutumnBox.Core
{
    public static class MINF
    {
        /// <summary>
        /// 指示AutumnBox.Basic的版本
        /// </summary>
        public static Version Version => Version.Parse(VERSION_STR);
        const string VERSION_STR = "2020.5.16";
    }
}
