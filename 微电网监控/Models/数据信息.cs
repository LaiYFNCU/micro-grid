using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 微电网监控.Models
{
    public enum 数据区域 { 输出继电器0区, 输入继电器1区, 输入寄存器3区, 输出寄存器4区 }
    public enum 数据类型 { 开关量, 无符号16位整型, 有符号16位整型, 无符号32位整型, 有符号32位整型, 单精度浮点数, 字符串 }
    public class 数据信息
    {
        public 数据信息(int startAddress,int length, 数据区域 数据区域, 数据类型 数据类型)
        {
            StartAddress = startAddress;
            Length = length;
            this.数据区域 = 数据区域;
            this.数据类型 = 数据类型;
        }

        public int StartAddress { get; set; }
        public int Length { get; set; }
        public 数据区域 数据区域 { get; set; }
        public 数据类型 数据类型 { get; set; }
    }
}
