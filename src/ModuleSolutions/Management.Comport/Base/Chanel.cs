using Prism.Mvvm;

namespace Management.Comport.Base
{
    internal class Chanel : BindableBase
    {
        private string? name;
        private double _value;
        private bool isChecked = false;

        public string? Name { get => name; set { SetProperty(ref name, value); } }
        public double Value { get => _value; set { SetProperty(ref _value, value); } }
        public bool IsChecked { get => isChecked; set { SetProperty(ref isChecked, value); } }
    }
}
