using AvaloniaApplication6.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaApplication6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Record> Records { get; }

        // How do I keep Total up to date with the correct value, In a reactive UI/MVVM way?
        // This cannot be [Reactive]
        // It has no setter, therefore it is not possible for the property to change, and thus should not be marked with[Reactive]
        public int Total => Records.Where(r => r.ShouldBeIncluded).Select(r => r.Size).Sum();

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

            // Can this do it?
            //records.ToObservableChangeSet(x => x.Id).Filter(x=> x.ShouldBeIncluded). What's next? Is this right?;

            //What about?
            // this.WhenAnyValue ?
        }

    }
}