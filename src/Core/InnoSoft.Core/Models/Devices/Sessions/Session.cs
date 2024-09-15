using InnoSoft.Core.Constants;
using Prism.Mvvm;

namespace InnoSoft.Core.Models.Devices.Sessions
{
    public abstract class Session : BindableBase
    {
        private int timeOut;
        private State state;
        private ResultType result;

        public Guid ID { get; set; }
        public ResultType Result { get => result; set => SetProperty(ref result, value); }
        public State State { get => state; set => SetProperty(ref state, value); }
        public int TimeOut { get => timeOut; set => SetProperty(ref timeOut, value); }

        protected Session()
        {
            ID = Guid.NewGuid();
            Result = ResultType.UNDEFINED;
            State = State.UNDEFINED;
            TimeOut = 1000;
        }
    }
}