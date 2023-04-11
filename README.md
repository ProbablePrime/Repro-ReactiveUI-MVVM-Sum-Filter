# Repro-ReactiveUI-MVVM-Sum-Filter
I'm working on a system that has a list of Records displayed in a list.

| Name    | Should be Included| Size |
|---------|-------------------|------|
| Record 1| [ ]               |5     |
| Record 2| [ ]               |5     |


Each item has the following properties:
- Name
- Id
- Size
- A Boolean indicating if this item should be included or not - ShouldBeIncluded

A user can check a checkbox to change the boolean of the item from false to true. etc.

Based on a user changing various item's checkboxes I need to keep a "TotalSize" property up to date so that it reflects the sum of all item's size property in the list where the item's "ShouldBeIncluded" property is true.

I'm trying to do this within a UI based app running ReactiveUI/Dynamic Data in an MVVM way. 

For the purposes of this question I've minimised this all down to a simple reproduction though.

I think I need to Observe property changes on the ObservableCollection but I cannot figure out how to then bind this back to the ReactiveUI property.

- I've tried various DynamicData methods, including the ones I've commented out.
- I've tried ObservableAsAProperty helpers
- I've tried doing this manually
- I've tried [Reactive] stuff.
- 
But I want to understand the most Idiomatic way to do this, but everything I'm trying to do seems to overcomplicate it.

You can find the main heavy lifters in the only MVVM View Model [here](https://github.com/ProbablePrime/Repro-ReactiveUI-MVVM-Sum-Filter/blob/main/AvaloniaApplication6/ViewModels/MainWindowViewModel.cs)

![](https://i.probableprime.co.uk/230411-Mq5Zkl8eWq8AuLZFI2Bj.gif)


