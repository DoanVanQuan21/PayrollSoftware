using PayrollSoftware.Core.Constants;
using Prism.Mvvm;

namespace PayrollSoftware.Core.Settings.Videos
{
    public class AlgorithmFlowSetting : BindableBase
    {
        private TaskProcess algorithm;

        private string modelPath;

        public AlgorithmFlowSetting()
        {
            ID = Guid.NewGuid();
            Algorithms = new() {
            { TaskProcess.CLASSIFICATION, "Classification" },
            { TaskProcess.OBJECT_DETECTION, "Object Detection" },
            { TaskProcess.OBB_DETECTION, "OBB Detection" },
            { TaskProcess.SEGMENTATION, "Segmentation" },
            { TaskProcess.POSE_ESTIMATION, "Pose Estimation" } };
            ImageProcessSetting = new();
        }

        public Dictionary<TaskProcess, string> Algorithms { get; set; }
        public ImageProcessSetting ImageProcessSetting { get; set; }

        public TaskProcess Algorithm
        {
            get { return algorithm; }
            set { SetProperty(ref algorithm, value); }
        }

        public Guid ID { get; }

        public string ModelPath
        {
            get { return modelPath; }
            set { SetProperty(ref modelPath, value); }
        }
    }
}