using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using Unity;
using 微电网监控.Models;
using 微电网监控.Servers;

namespace 微电网监控.ViewModels
{
    class 组态屏视图控件ViewModel : BindableBase
    {
        public 组态屏视图控件ViewModel()
        {
            所有组态屏 = new ObservableCollection<组态屏内容控件ViewModel>();
            //在这里读取配置文件循环创建组态屏包含组态屏名字、ipadress、
            //port、Dictionary<string, 数据信息> 配置文件
            //模拟读取配置文件
            //var dic = new Dictionary<string, 数据信息>();
            //dic.Add("开关11111111111111111111", new 数据信息(0, 1, 数据区域.输出继电器0区, 数据类型.开关量));
            //dic.Add("开关2", new 数据信息(1, 1, 数据区域.输出继电器0区, 数据类型.开关量));
            //dic.Add("开关3", new 数据信息(2, 1, 数据区域.输出继电器0区, 数据类型.开关量));
            //dic.Add("开关4", new 数据信息(0, 1, 数据区域.输入继电器1区, 数据类型.开关量));
            //dic.Add("A相电压", new 数据信息(0, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("B相电压", new 数据信息(2, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("C相电压", new 数据信息(4, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("A相电流", new 数据信息(6, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("B相电流", new 数据信息(8, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("C相电流", new 数据信息(10, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("AB线电压", new 数据信息(12, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("BC线电压", new 数据信息(14, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("CA线电压", new 数据信息(16, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("A相功率", new 数据信息(18, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("B相功率", new 数据信息(20, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("C相功率", new 数据信息(22, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("总功率", new 数据信息(24, 2, 数据区域.输出寄存器4区, 数据类型.单精度浮点数));
            //dic.Add("整数16", new 数据信息(26, 1, 数据区域.输出寄存器4区, 数据类型.无符号16位整型));
            //dic.Add("整数162", new 数据信息(27, 1, 数据区域.输出寄存器4区, 数据类型.有符号16位整型));
            //dic.Add("整数32", new 数据信息(28, 2, 数据区域.输出寄存器4区, 数据类型.无符号32位整型));
            //dic.Add("整数322", new 数据信息(30, 2, 数据区域.输出寄存器4区, 数据类型.有符号32位整型));
            //所有组态屏.Add(new 组态屏内容控件ViewModel("组态屏1", IPAddress.Parse("127.0.0.1"), 502, dic));
            List<组态屏Model> list = 组态屏配置文件读取.Get组态屏Models();
            foreach (var item in list)
            {
                组态屏内容控件ViewModel vm = new 组态屏内容控件ViewModel(item.Name, item.IP, item.Port, item.配置文件内容);
                所有组态屏.Add(vm);
            }
        }
        public ObservableCollection<组态屏内容控件ViewModel> 所有组态屏 { get; set; }

    }
}
