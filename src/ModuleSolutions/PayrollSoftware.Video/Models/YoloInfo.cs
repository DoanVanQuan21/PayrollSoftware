using Prism.Mvvm;
using YoloDotNet.Enums;

namespace PayrollSoftware.Video.Models
{
    internal class YoloInfo : BindableBase
    {
        private int gpuId;
        private string modelPath;

        private ModelType modelType;

        private bool useCuda;

        public int GpuId
        {
            get { return gpuId; }
            set { SetProperty(ref gpuId, value); }
        }

        public string ModelPath
        {
            get { return modelPath; }
            set { SetProperty(ref modelPath, value); }
        }

        public ModelType ModelType
        {
            get { return modelType; }
            set { SetProperty(ref modelType, value); }
        }

        public bool UseCuda
        {
            get { return useCuda; }
            set { SetProperty(ref useCuda, value); }
        }
    }
}