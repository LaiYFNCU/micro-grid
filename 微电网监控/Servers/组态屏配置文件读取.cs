using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using 微电网监控.Models;

namespace 微电网监控.Servers
{
    public class 组态屏配置文件读取
    {
        public static List<组态屏Model> Get组态屏Models()
        {
            XmlDocument xml = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(@"..\..\组态屏配置文件\组态屏配置文件.xml", settings);
            xml.Load(reader);
            XmlNode xmlNode = xml.SelectSingleNode("组态屏配置");
            XmlNodeList xmlNodeList = xmlNode.ChildNodes;
            List<组态屏Model> list = new List<组态屏Model>();
            foreach (var node in xmlNodeList)
            {
                XmlElement xe = (XmlElement)node;
                Dictionary<string, 数据信息> 配置文件内容 = new Dictionary<string, 数据信息>();
                组态屏Model model = new 组态屏Model(xe.GetAttribute("Name"), IPAddress.Parse(xe.GetAttribute("IPAdress")), int.Parse(xe.GetAttribute("Port")), 配置文件内容);
                XmlNode 继电器0区 = xe.SelectSingleNode("输出继电器0区");
                XmlNodeList 继电器0区数据 = 继电器0区.ChildNodes;
                foreach (var 数据 in 继电器0区数据)
                {
                    XmlElement 数据x = (XmlElement)数据;
                    var 数据i = 数据x.ChildNodes;
                    数据信息 数据信息x = new 数据信息(int.Parse(数据i.Item(1).InnerText),
                                                      int.Parse(数据i.Item(2).InnerText),
                                                      数据区域.输出继电器0区,
                                                      (数据类型)Enum.Parse(typeof(数据类型),
                                                       数据i.Item(3).InnerText));
                    配置文件内容.Add(数据i.Item(0).InnerText, 数据信息x);
                }
                XmlNode 继电器1区 = xe.SelectSingleNode("输入继电器1区");
                XmlNodeList 继电器1区数据 = 继电器1区.ChildNodes;
                foreach (var 数据 in 继电器1区数据)
                {
                    XmlElement 数据x = (XmlElement)数据;
                    var 数据i = 数据x.ChildNodes;
                    数据信息 数据信息x = new 数据信息(int.Parse(数据i.Item(1).InnerText),
                                                      int.Parse(数据i.Item(2).InnerText),
                                                      数据区域.输入继电器1区,
                                                      (数据类型)Enum.Parse(typeof(数据类型),
                                                       数据i.Item(3).InnerText));
                    配置文件内容.Add(数据i.Item(0).InnerText, 数据信息x);
                }
                XmlNode 输入寄存器3区 = xe.SelectSingleNode("输入寄存器3区");
                XmlNodeList 输入寄存器3区数据 = 输入寄存器3区.ChildNodes;
                foreach (var 数据 in 输入寄存器3区数据)
                {
                    XmlElement 数据x = (XmlElement)数据;
                    var 数据i = 数据x.ChildNodes;
                    数据信息 数据信息x = new 数据信息(int.Parse(数据i.Item(1).InnerText),
                                                      int.Parse(数据i.Item(2).InnerText),
                                                      数据区域.输入寄存器3区,
                                                      (数据类型)Enum.Parse(typeof(数据类型),
                                                       数据i.Item(3).InnerText));
                    配置文件内容.Add(数据i.Item(0).InnerText, 数据信息x);
                }
                XmlNode 输出寄存器4区 = xe.SelectSingleNode("输出寄存器4区");
                XmlNodeList 输出寄存器4区数据 = 输出寄存器4区.ChildNodes;
                foreach (var 数据 in 输出寄存器4区数据)
                {
                    XmlElement 数据x = (XmlElement)数据;
                    var 数据i = 数据x.ChildNodes;
                    数据信息 数据信息x = new 数据信息(int.Parse(数据i.Item(1).InnerText),
                                                      int.Parse(数据i.Item(2).InnerText),
                                                      数据区域.输出寄存器4区,
                                                      (数据类型)Enum.Parse(typeof(数据类型),
                                                       数据i.Item(3).InnerText));
                    配置文件内容.Add(数据i.Item(0).InnerText, 数据信息x);
                }
                list.Add(model);
            }
            reader.Close();
            return list;
        }
    }
}
