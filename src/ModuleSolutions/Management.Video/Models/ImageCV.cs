using Emgu.CV;
using Emgu.CV.Structure;

namespace Management.Video.Models
{
    public class ImageCV : Image<Bgr, byte>
    {
        public ImageCV(int width, int height) : base(width, height)
        {
        }

        public ImageCV(int width, int height, int stride, IntPtr scan) : base(width, height, stride, scan)
        {
        }

        public ImageCV(string file) : base(file)
        {
        }

        public ImageCV(Mat mat) : base(mat)
        {
        }

        public ImageCV(ImageCV img) : base(img.Width, img.Height)
        {
            Bytes = img.Bytes;
        }
    }
}