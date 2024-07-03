using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Geo;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using PayrollSoftware.Core.Mvvms;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace PayrollSoftware.LiveChart.ViewModels
{
    internal class LiveChartViewModel : BaseRegionViewModel
    {
        public override string Title => "Live chart";
        private readonly Random _random = new();
        private readonly List<DateTimePoint> _values = new();
        private readonly DateTimeAxis _customAxis;
        private bool _isBrazilInChart = true;
        private readonly IWeigthedMapLand _brazil;
        private readonly Random _r = new();
        public LiveChartViewModel()
        {
            var lands = new HeatLand[]
            {
                new() { Name = "bra", Value = 13 },
                new() { Name = "mex", Value = 10 },
                new() { Name = "usa", Value = 15 },
                new() { Name = "can", Value = 8 },
                new() { Name = "ind", Value = 12 },
                new() { Name = "deu", Value = 13 },
                new() { Name= "jpn", Value = 15 },
                new() { Name = "chn", Value = 14 },
                new() { Name = "rus", Value = 11 },
                new() { Name = "fra", Value = 8 },
                new() { Name = "esp", Value = 7 },
                new() { Name = "kor", Value = 10 },
                new() { Name = "zaf", Value = 12 },
                new() { Name = "are", Value = 13 },
                new() { Name = "vn", Value = 10 }
            };
            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<DateTimePoint>
                {
                    Values = _values,
                    LineSmoothness = 30,
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null
                }
            };
            HeatLandSeries = new HeatLandSeries[] { new HeatLandSeries { Lands = lands } };

            _brazil = lands.First(x => x.Name == "bra");
            DoRandomChanges();
            _customAxis = new DateTimeAxis(TimeSpan.FromSeconds(1), Formatter)
            {
                CustomSeparators = GetSeparators(),
                AnimationsSpeed = TimeSpan.FromMilliseconds(0),
                SeparatorsPaint = new SolidColorPaint(SKColors.Black.WithAlpha(100))
            };

            XAxes = new Axis[] { _customAxis };

            _ = ReadData();
        }
        public HeatLandSeries[] HeatLandSeries { get; set; }
        public ObservableCollection<ISeries> Series { get; set; }

        public Axis[] XAxes { get; set; }

        public object Sync { get; } = new object();

        public bool IsReading { get; set; } = true;
        public void ToggleBrazil()
        {
            var lands = HeatLandSeries[0].Lands;
            if (lands is null) return;

            if (_isBrazilInChart)
            {
                HeatLandSeries[0].Lands = lands.Where(x => x != _brazil).ToArray();
                _isBrazilInChart = false;
                return;
            }

            HeatLandSeries[0].Lands = lands.Concat(new[] { _brazil }).ToArray();
            _isBrazilInChart = true;
        }

        private async void DoRandomChanges()
        {
            await Task.Delay(1000);

            while (true)
            {
                foreach (var shape in HeatLandSeries[0].Lands ?? Enumerable.Empty<IWeigthedMapLand>())
                {
                    shape.Value = _r.Next(0, 20);
                }

                await Task.Delay(500);
            }
        }
        private async Task ReadData()
        {
            int i = 1;
            while (IsReading)
            {
                await Task.Delay(100);

                lock (Sync)
                {
                    if (i % 2 == 0)
                    {
                        _values.Add(new DateTimePoint(DateTime.Now, -8));
                    }
                    else
                    {
                        _values.Add(new DateTimePoint(DateTime.Now, 8));
                    }
                    if (_values.Count > 30) _values.RemoveAt(0);

                    _customAxis.CustomSeparators = GetSeparators();
                }
                i++;
            }
        }

        private double[] GetSeparators()
        {
            var now = DateTime.Now;

            return new double[]
            {
            now.AddSeconds(-25).Ticks,
            now.AddSeconds(-20).Ticks,
            now.AddSeconds(-15).Ticks,
            now.AddSeconds(-10).Ticks,
            now.AddSeconds(-5).Ticks,
            now.Ticks
            };
        }

        private static string Formatter(DateTime date)
        {
            var secsAgo = (DateTime.Now - date).TotalSeconds;

            return secsAgo < 1
                ? "now"
                : $"{secsAgo:N0}s ago";
        }

    }
}