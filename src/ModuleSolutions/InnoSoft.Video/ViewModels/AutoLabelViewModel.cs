using InnoSoft.Core.Helpers;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Settings.Videos;
using InnoSoft.Video.Contracts;
using InnoSoft.Video.Models;
using InnoSoft.Video.Models;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace InnoSoft.Video.ViewModels
{
    internal class AutoLabelViewModel : BaseRegionViewModel
    {
        private readonly IImageProcess _imageProcess;
        private readonly int PAGE_SIZE = 12;
        private AutoLabel currentAutoLabel;
        private List<string> filePaths;
        private int maxPage;
        private int pageIndex;

        public AutoLabelViewModel()
        {
            _imageProcess = Ioc.Resolve<IImageProcess>();
            AutoLabels = new();
            filePaths = new();
            Config = new();
            ImageProcessSetting = new();
        }

        public ObservableCollection<AutoLabel> AutoLabels { get; set; }
        public YoloInfo Config { get; set; }
        public AutoLabel CurrentAutoLabel { get => currentAutoLabel; set => SetProperty(ref currentAutoLabel, value); }
        public ImageProcessSetting ImageProcessSetting { get; set; }

        public int MaxPage
        {
            get { return maxPage; }
            set { SetProperty(ref maxPage, value); }
        }

        public int PageIndex
        {
            get { return pageIndex; }
            set { SetProperty(ref pageIndex, value); }
        }

        public ICommand PageUpdatedCommand { get; set; }
        public ICommand StartAutoLabelCommand { get; set; }
        public ICommand InitModelCommand { get; set; }
        public override string Title => "Auto Label";
        public ICommand UploadFilesCommand { get; set; }

        protected override void RegisterCommand()
        {
            UploadFilesCommand = new DelegateCommand(OnUploadFilesAsync);
            PageUpdatedCommand = new DelegateCommand(OnPageUpdate);
            StartAutoLabelCommand = new DelegateCommand(OnStartAutoLabel);
            InitModelCommand = new DelegateCommand(OnInitModel);
        }

        private void OnInitModel()
        {
            _imageProcess.InitModel(Config);
        }

        private void OnStartAutoLabel()
        {
        }

        private void AddImages(List<string> files)
        {
            foreach (var file in files)
            {
                AutoLabels.Add(new()
                {
                    FileName = FileHelper.GetFileName(file),
                    FilePath = file,
                    Image = new ImageCV(file)
                });
            }
        }

        private void DefaultPage()
        {
            PageIndex = 1;
        }

        private Task Dispose()
        {
            return Task.Factory.StartNew(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach (var autoLabel in AutoLabels)
                    {
                        autoLabel.Image?.Dispose();
                        autoLabel.Image = null;
                    }
                    AutoLabels.Clear();
                });
            });
        }

        private async void OnPageUpdate()
        {
            await Dispose();
            var files = filePaths.Skip((PageIndex - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            AddImages(files);
        }

        private async void OnUploadFilesAsync()
        {
            filePaths.Clear();
            filePaths.AddRange(FileHelper.ChoosePathsDialog());
            ShowProgressBar();
            await Task.Delay(1000);
            DefaultPage();
            await Dispose();
            UpdateMaxPage(filePaths.Count);
            var files = filePaths.Take(PAGE_SIZE).ToList();
            AddImages(files);
            CloseDialog();
        }

        private void UpdateMaxPage(int totalElement)
        {
            if (totalElement % PAGE_SIZE == 0)
            {
                MaxPage = totalElement / PAGE_SIZE;
                return;
            }
            MaxPage = totalElement / PAGE_SIZE + 1;
        }
    }
}