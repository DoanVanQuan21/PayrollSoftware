namespace Management.Core.Models.Devices.Sessions
{
    public class TextSession : Session
    {
        private string command;
        private string response;

        public string Response { get => response; set => SetProperty(ref response, value); }
        public string Command { get => command; set => SetProperty(ref command, value); }

        public TextSession() : base()
        {
            Response = string.Empty;
            Command = string.Empty;
        }
    }
}