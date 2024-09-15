namespace InnoSoft.Core.Helpers
{
    public class Untils
    {
        public static async Task<bool> WaitAsync(int timeout, Func<bool> action)
        {
            while (timeout >= 0)
            {
                if (action.Invoke())
                {
                    return true;
                }
                timeout -= 100;
                await Task.Delay(100);
            }
            return false;
        }
    }
}