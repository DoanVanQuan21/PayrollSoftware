using Prism.Mvvm;

namespace PayrollSoftware.Core.Models.Common
{
    public class KeyValue<TKEY,TVALUE> : BindableBase
    {
        private TKEY key;
        private TVALUE _value;

        public TKEY Key { get => key; set => SetProperty(ref key, value); }
        public TVALUE Value { get => _value; set => SetProperty(ref _value, value); }
    }
}