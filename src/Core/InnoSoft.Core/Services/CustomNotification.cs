using HandyControl.Controls;
using System.Threading;

namespace InnoSoft.Core.Services
{
    public class CustomNotification
    {
        public static async Task Info(string message, string token = "", int timeout = 2)
        {
            Growl.Info(message, token);
            await CloseNotification(timeout);
        }

        public static async Task Success(string message, string token = "", int timeout = 2)
        {
            Growl.Success(message, token);
            await CloseNotification(timeout);
        }

        private static async Task CloseNotification(int timeout)
        {
            var time = timeout * 1000;
            while (time >= 0)
            {
                time -= 100;
                await Task.Delay(100);
            }
            Growl.Clear();
        }

        public static async Task Error(string message, string token = "", int timeout = 2)
        {
            Growl.Error(message, token);
            await CloseNotification(timeout);
        }

        public static async Task Falta(string message, string token = "", int timeout = 2)
        {
            Growl.Fatal(message, token);
            await CloseNotification(timeout);
        }

        public static async Task Warning(string message, string token = "", int timeout = 2)
        {
            Growl.Warning(message, token);
            await CloseNotification(timeout);
        }

        public static async Task Ask(string message, Func<bool, bool> actionBeforeClose, string token = "", int timeout = 3)
        {
            Growl.Ask(message, actionBeforeClose, token);
            await CloseNotification(timeout);
        }

        public static void Clear(string message, string token = "", int timeout = 2)
        {
            Growl.Clear(token);
        }
    }
}