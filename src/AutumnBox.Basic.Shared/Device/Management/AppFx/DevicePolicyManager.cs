﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/9/28 4:14:43 (UTC +8:00)
** desc： ...
*************************************************/
using System.Text;
using AutumnBox.Basic.Calling;
using AutumnBox.Basic.Device.Management.OS;
using AutumnBox.Basic.Util;

namespace AutumnBox.Basic.Device.Management.AppFx
{
    /// <summary>
    /// 没错,这就是DPM!
    /// </summary>
    public sealed class DevicePolicyManager : DeviceCommander
    {
        /// <summary>
        /// 构造DPM实例
        /// </summary>
        /// <param name="device"></param>
        public DevicePolicyManager(IDevice device) : base(device)
        {
            //ShellCommandHelper.CommandExistsCheck(device, "dpm");
        }

        /// <summary>
        /// 设置ActiveAdmin
        /// </summary>
        /// <param name="cn">组件名</param>
        /// <param name="uid">UID,不填则将对全部用户起效</param>
        /// <exception cref="Exceptions.AdbShellCommandFailedException"></exception>
        public void SetActiveAdmin(ComponentName cn, int? uid = null)
        {
            SetActiveAdmin(cn.ToString(), uid);
        }

        /// <summary>
        /// Set active admin
        /// </summary>
        /// <param name="componentName"></param>
        /// <param name="uid"></param>
        public void SetActiveAdmin(string componentName, int? uid = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("dpm set-active-admin ");
            if (uid != null)
            {
                sb.Append($"--user {uid} ");
            }
            sb.Append(componentName);
            Executor.AdbShell(Device, sb.ToString()).
                ThrowIfShellExitCodeNotEqualsZero();
        }

        /// <summary>
        /// 设置ActiveAdmin
        /// </summary>
        /// <param name="cn">组件名</param>
        /// <param name="uid">UID,不填则将对全部用户起效</param>
        /// <param name="name">易读的别名(the human-readable organization name)</param>
        /// <exception cref="Exceptions.AdbShellCommandFailedException"></exception>
        public void SetProfileOwner(ComponentName cn, int? uid = null, string name = null)
        {
            SetProfileOwner(cn.ToString(), uid, name);
        }

        /// <summary>
        /// Set Profile Owner
        /// </summary>
        /// <param name="componentName"></param>
        /// <param name="uid"></param>
        /// <param name="name"></param>
        public void SetProfileOwner(string componentName, int? uid = null, string name = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("dpm set-profile-owner ");
            if (uid != null)
            {
                sb.Append($"--user {uid} ");
            }
            if (name != null)
            {
                sb.Append($"--name {name} ");
            }
            sb.Append(componentName);
            Executor.AdbShell(Device, sb.ToString()).
                ThrowIfShellExitCodeNotEqualsZero();
        }

        /// <summary>
        /// 设置Device Owner
        /// </summary>
        /// <param name="cn">组件名</param>
        /// <param name="uid">UID,不填则将对全部用户起效</param>
        /// <param name="name">易读的别名(the human-readable organization name)</param>
        /// <exception cref="Exceptions.AdbShellCommandFailedException"></exception>
        public void SetDeviceOwner(ComponentName cn, int? uid = null, string name = null)
        {
            SetDeviceOwner(cn.ToString(), uid, name);
        }

        /// <summary>
        /// 设置Device Owner
        /// </summary>
        /// <param name="componentName">组件名</param>
        /// <param name="uid">UID,不填则将对全部用户起效</param>
        /// <param name="name">易读的别名(the human-readable organization name)</param>
        /// <exception cref="Exceptions.AdbShellCommandFailedException"></exception>
        public void SetDeviceOwner(string componentName, int? uid = null, string name = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("dpm set-device-owner ");
            if (uid != null)
            {
                sb.Append($"--user {uid} ");
            }
            if (name != null)
            {
                sb.Append($"--name {name} ");
            }
            sb.Append(componentName);
            Executor.AdbShell(Device, sb.ToString()).
                ThrowIfShellExitCodeNotEqualsZero();
        }

        /// <summary>
        /// 移除ActiveAdmin
        /// </summary>
        /// <param name="cn">组件名</param>
        /// <param name="uid">UID,不填则将对全部用户起效</param>
        /// <exception cref="Exceptions.AdbShellCommandFailedException"></exception>
        public void RemoveActiveAdmin(ComponentName cn, int? uid = null)
        {
            RemoveActiveAdmin(cn.ToString(), uid);
        }

        /// <summary>
        /// 移除ActiveAdmin
        /// </summary>
        /// <param name="componentName">组件名</param>
        /// <param name="uid">UID,不填则将对全部用户起效</param>
        /// <exception cref="Exceptions.AdbShellCommandFailedException"></exception>
        public void RemoveActiveAdmin(string componentName, int? uid = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("dpm remove-device-owner ");
            if (uid != null)
            {
                sb.Append($"--user {uid} ");
            }
            sb.Append(componentName);
            Executor.AdbShell(Device, sb.ToString()).
                ThrowIfShellExitCodeNotEqualsZero();
        }
    }
}
