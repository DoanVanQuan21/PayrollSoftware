using System.Collections.ObjectModel;

namespace Management.Core.Models.Devices.Sessions
{
    public class ByteSession : Session
    {
        public List<byte> ResponseBytes { get; set; }
        public List<byte> CommandBytes { get; set; }
        public ByteSession() : base()
        {
            ResponseBytes = new();
            CommandBytes = new();
        }
    }
}