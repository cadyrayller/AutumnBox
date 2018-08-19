﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/15 17:51:33 (UTC +8:00)
** desc： ...
*************************************************/

using AutumnBox.Basic.Device;
using AutumnBox.GUI.MVVM;
using AutumnBox.GUI.Util.Bus;

namespace AutumnBox.GUI.ViewModel
{
    class VMDeviceDetails : ViewModelBase
    {
        #region MVVM
        #endregion
        public VMDeviceDetails()
        {
            DeviceSelectionObserver.Instance.SelectedDevice += SelectedDevice;
            DeviceSelectionObserver.Instance.SelectedNoDevice += SelectedNoDevice;
        }

        private void SelectedNoDevice(object sender, System.EventArgs e)
        {
            Reset();
        }

        private void SelectedDevice(object sender, System.EventArgs e)
        {
            By(DeviceSelectionObserver.Instance.CurrentDevice);
        }

        private void Reset() { }

        private void By(DeviceBasicInfo device) { }

        ~VMDeviceDetails()
        {
            DeviceSelectionObserver.Instance.SelectedDevice -= SelectedDevice;
            DeviceSelectionObserver.Instance.SelectedNoDevice -= SelectedNoDevice;
        }
    }
}
