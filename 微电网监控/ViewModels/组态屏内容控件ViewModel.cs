using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Timers;
using System.Windows;
using 微电网监控.Models;
using 微电网监控.Servers;

namespace 微电网监控.ViewModels
{
    public class 组态屏内容控件ViewModel : BindableBase
    {
        public 组态屏Model 组态屏 { get; set; }
        private string tempValue = "0";
        public string TempValue
        {
            get { return tempValue; }
            set { SetProperty(ref tempValue, value); }
        }

        组态屏Client client;
        public DelegateCommand ReadCommand { get; set; }
        public DelegateCommand SetCommand { get; set; }

        Timer timer;

        public 组态屏内容控件ViewModel(string name, IPAddress iPAddress, int port, Dictionary<string, 数据信息> 配置文件内容)
        {
            ReadCommand = new DelegateCommand(new Action(ExecuteReadCommand));
            SetCommand = new DelegateCommand(new Action(ExecuteSetCommand));
            组态屏 = new 组态屏Model(name, iPAddress, port, 配置文件内容);
            client = new 组态屏Client(组态屏);
            组态屏.client = client;

            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void ExecuteSetCommand()
        {
            if (组态屏.SelectedItem.Value == null) { MessageBox.Show("请先选中想要修改的项。"); return; };
            组态屏.SelectedItem.Value.ChangeValueEvent -= client.ValueChangedEventHandler;
            组态屏.SelectedItem.Value.ChangeValueEvent += client.ValueChangedEventHandler;
            if (组态屏.配置文件内容[组态屏.SelectedItem.Key].数据类型 == 数据类型.开关量)
            {
                组态屏.DicData[组态屏.SelectedItem.Key].SwitchCommand.Execute();
            }
            else
            {
                组态屏.DicData[组态屏.SelectedItem.Key].TempValue = tempValue;
                组态屏.DicData[组态屏.SelectedItem.Key].SetPreValueCommand.Execute();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ExecuteReadCommand();
        }

        private void ExecuteReadCommand()
        {
            try
            {
                client.UpdateData();
            }
            catch (Exception)
            {
            }
        }
    }
}
