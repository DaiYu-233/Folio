using CommunityToolkit.Mvvm.ComponentModel;
using Folio.ViewModels;

namespace Folio.Public.PageTemplate.ViewModels;

public partial class MarkdownViewModel : ViewModelBase
{
    private string _mdText = string.Empty;
   
    public string MdText
    {
        get => _mdText;
        set => SetField(ref _mdText, value);
    }
}