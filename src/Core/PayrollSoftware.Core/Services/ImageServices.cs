using System.Drawing;
using System.IO;

namespace PayrollSoftware.Core.Services
{
    public class ImageServices
    {
        public Bitmap LoadImage(string filename)
        {
            if (!File.Exists(filename))
            {
                return new Bitmap(0, 0);
            }
            return new Bitmap(filename);
        }

        public bool SaveImage(string filename)
        {
            if (File.Exists(filename))
            {
                return false;
            }
            return true;
        }
    }
}