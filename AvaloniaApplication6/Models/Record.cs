using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaApplication6.Models
{
    public class Record : ReactiveObject
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        [Reactive]
        public int Size { get; set; } = 0;

        [Reactive]
        public bool ShouldBeIncluded { get; set; } = false;

        public Record(string id, string name, int size)
        {
            Id = id;
            Name = name;
            Size = size;
        }
    }
}
