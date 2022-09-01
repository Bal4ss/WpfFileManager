using System.Collections.ObjectModel;
using Entities.Attributes;

namespace WpfFileManager.ViewModels.Core.SideSections;

/// <summary>
///     Side section view model
/// </summary>
public interface ISideSectionVm : IControlViewModel
{
    ReadOnlyObservableCollection<AttributeModel> Attributes { get; }
}