using System.Collections.ObjectModel;
using Entities.Attributes;

namespace WpfFileManager.ViewModels.Core.SideSections;

public interface ISideSectionVm : IControlViewModel
{
    ReadOnlyObservableCollection<AttributeModel> Attributes { get; }
}