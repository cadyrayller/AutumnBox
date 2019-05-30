﻿using AutumnBox.Basic.Calling;
using AutumnBox.GUI.View.Windows;
using AutumnBox.Logging;
using AutumnBox.OpenFramework.Extension;
using AutumnBox.OpenFramework.LeafExtension;
using AutumnBox.OpenFramework.LeafExtension.Attributes;
using AutumnBox.OpenFramework.LeafExtension.Fast;
using AutumnBox.OpenFramework.LeafExtension.Kit;
using AutumnBox.OpenFramework.Open;
using AutumnBox.OpenFramework.Util;
using System.Net;
using System.Threading.Tasks;

namespace AutumnBox.CoreModules.Extensions.Hidden
{
    [ExtName("Connect to net device", "zh-cn:网络设备连接")]
    [ExtHide]
    [ExtText("Fail", "Can not connect to this device", "zh-cn:连接失败")]
    [ExtText("ConnectingDevice", "Connecting to the device", "zh-cn:正在尝试连接这个设备...")]
    [ExtText("PleaseInputRightIP", "Please input a right ip address and port", "zh-cn:请输入正确的IP和端口号")]
    class ENetDeviceConnecter : LeafExtensionBase
    {
        [LMain]
        private void EntryPoint(ILeafUI ui, IClassTextManager texts)
        {
            using (ui)
            {
                ui.Title = this.GetName();
                ui.Show();
                if (TryGetInputEndPoint(ui, texts, out IPEndPoint endpoint))
                {
                    using (var executor = new CommandExecutor())
                    {
                        ui.Tip = texts["ConnectingDevice"];
                        ui.WriteLine(texts["ConnectingDevice"]);
                        executor.To(e => ui.WriteOutput(e.Text));
                        var result = executor.Adb($"connect {endpoint.Address}:{endpoint.Port}");
                        if (result.Output.Contains("fail", true))
                        {
                            ui.WriteLine(texts["fail"]);
                            ui.Finish(texts["Fail"]);
                        }
                        else
                        {
                            ui.Finish(result.ExitCode);
                        }
                    }
                }
                else
                {
                    ui.Shutdown();
                }
            }
        }

        private bool TryGetInputEndPoint(ILeafUI ui, IClassTextManager texts, out IPEndPoint endPoint)
        {
            Task<object> dialogTask = ui.ShowDialogById("inputIpEndPoint");
            dialogTask.Wait();
            while (dialogTask.Result != null)
            {
                dynamic result = dialogTask.Result;
                SLogger<ENetDeviceConnecter>.Info(result.Result);
                if (result.IsInputRight == false)
                {
                    ui.ShowMessage(texts["PleaseInputRightIP"]);
                    dialogTask = ui.ShowDialogById("inputIpEndPoint");
                    dialogTask.Wait();
                }
                else
                {
                    endPoint = (IPEndPoint)result.Result;
                    return true;
                }
            }
            endPoint = null;
            return false;
        }
    }
}
