using AvaloniaApplication6.Models;
using DynamicData;
using DynamicData.Aggregation;
using DynamicData.Binding;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace AvaloniaApplication6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Record> Records { get; }

        [ObservableAsProperty]
        public int Total { get; } = 0;

        public MainWindowViewModel()
        {
            Records = new ObservableCollection<Record>();

            // Add 10 records to it, each with a size of 5
            Random rnd = new Random();
            for (var i = 0; i < 10; i++)
            {
               Records.Add(new Record(i.ToString(), $"Record {i}", rnd.Next(1,20)));
            }

            // Mark 3 records as needing to be "Included"
            Records[0].ShouldBeIncluded = true;
            Records[3].ShouldBeIncluded = true;
            Records[5].ShouldBeIncluded = true;

            Records
                .ToObservableChangeSet(x => x.Id)
                .AutoRefresh(x => x.ShouldBeIncluded)
                .Filter(x => x.ShouldBeIncluded)
                .Sum(x => x.Size)
                .ToPropertyEx(this, x => x.Total);

        }

    }
}