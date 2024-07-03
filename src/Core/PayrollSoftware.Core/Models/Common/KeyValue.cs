using Prism.Mvvm;

namespace PayrollSoftware.Core.Models.Common
{
    public class KeyValue : BindableBase
    {
        private string key;
        private string _value;

        public string Key { get => key; set => SetProperty(ref key, value); }
        public string Value { get => _value; set => SetProperty(ref _value, value); }
    }
}