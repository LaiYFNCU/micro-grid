using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 微电网监控.Models
{
    public class StringClass : BindableBase
    {
        public DelegateCommand SwitchCommand { get; set; }
        public DelegateCommand SetPreValueCommand { get; set; }
        public event Action<string,string> ChangeValueEvent;

        public string Name { get; set; }
        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public StringClass(string name,string value)
        {
            Name = name;
            Value = value;
            SwitchCommand = new DelegateCommand(new Action(ExecuteSwitchCommand));
            SetPreValueCommand = new DelegateCommand(new Action(ExecuteSetPreValueCommand));
        }

        private void ExecuteSetPreValueCommand()
        {
            PreValue = TempValue;
        }

        private void ExecuteSwitchCommand()
        {
            if (Value == "关") PreValue = "1";
            else PreValue = "0";
        }

        private string preValue;
        public string PreValue
        {
            get { return preValue; }
            set { SetProperty(ref preValue, value); ChangeValueEvent(Name,preValue); }
        }

        private string tempValue;
        public string TempValue
        {
            get { return tempValue; }
            set { SetProperty(ref tempValue, value); }
        }
    }
}
