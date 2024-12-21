using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;
using Folio.Public.Classes;
using Folio.Public.Langs;
using Folio.Public.Module.Page.Create;

namespace Folio.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<IPage> Pages { get; set; } = [];
    private IPage _selectedPage = null!;

    public IPage SelectedPage
    {
        get => _selectedPage;
        set => SetField(ref _selectedPage, value);
    }

    [RelayCommand]
    public async Task OpenFile()
    {
        var desktopPath =
            await TopLevel.GetTopLevel(App.UiRoot)!.StorageProvider.TryGetWellKnownFolderAsync(WellKnownFolder.Desktop);
        var files = await TopLevel.GetTopLevel(App.UiRoot)!.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions()
            {
                AllowMultiple = true,
                Title = MainLang.OpenFile,
                SuggestedStartLocation = desktopPath
            });
        foreach (var file in files)
        {
            var i = App.UiRoot.ViewModel.Pages.FirstOrDefault(obj => obj.Path == file.Path.LocalPath);
            if (i != null)
            {
                i.Select();
                continue;
            }

            NewPage.CreateNewPage(file);
        }

        await Task.Delay(20);
        var maxHorizontalOffset = App.UiRoot.ScrollViewer.Extent.Width - App.UiRoot.ScrollViewer.Viewport.Width;
        App.UiRoot.ScrollViewer.Offset = new Vector(maxHorizontalOffset, App.UiRoot.ScrollViewer.Offset.Y);
    }
}