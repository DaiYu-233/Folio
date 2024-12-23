using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;
using Folio.Public.Classes;
using Folio.Public.Const;
using Folio.Public.Langs;
using Folio.Public.PageTemplate;
using Folio.ViewModels;

namespace Folio.Views;

public partial class MainView : UserControl
{
    public MainViewModel ViewModel { get; } = new();
    public Home home { get; } = new();

    public MainView()
    {
        InitializeComponent();
        BindingEvent();
        DataContext = ViewModel;
    }

    private void BindingEvent()
    {
        var c = (DrawingImage)AvaloniaRuntimeXamlLoader.Load(
            "<DrawingImage xmlns=\"https://github.com/avaloniaui\">\n  <DrawingImage.Drawing>\n    <DrawingGroup >\n      <DrawingGroup.Children>\n        <DrawingGroup>\n          <DrawingGroup.Children>\n            <GeometryDrawing Brush=\"#FF333333\">\n              <GeometryDrawing.Geometry>\n                <PathGeometry Figures=\"M516.29,164.37C557.66,162.87 599.18,168.82 638.67,181.13 696.62,199.14 749.32,232.95 790.92,277.01 826.04,314.33 852.85,359.32 869.41,407.79 869.96,409.92 871.74,411.33 873.4,412.63 899.89,431.33 925.17,451.95 947.6,475.42 965.88,494.6 982.29,515.72 995.13,538.94 1005.57,557.95 1013.47,578.58 1016.42,600.15 1019.96,625.19 1016.16,651.28 1005.14,674.09 992.91,699.64 972.08,720.16 948.6,735.56 921.21,753.53 890.37,765.68 858.79,774.01 830.75,781.36 802.03,785.81 773.21,788.68 770.11,788.64 767.35,790.1 765.21,792.26 719.57,832.63 663.16,860.49 603.49,872.69 504.35,894.32 396.62,870.18 315.58,809.32 259.67,767.22 215.88,708.77 192.71,642.62 191.37,639.11 190.9,634.78 187.59,632.47 156.42,610.18 126.55,585.66 101.24,556.76 75.88,527.72 54.32,494 45.63,456.02 39.45,429.83 41.42,401.75 51.81,376.88 62.84,349.83 83.57,327.77 107.44,311.42 132.89,294.04 161.56,281.79 191.01,272.99 221.27,264.01 252.56,258.86 283.96,255.96 287.39,255.62 291.25,255.53 293.9,252.98 354.94,199.13 434.84,166.85 516.29,164.37 M510.59,188.87C446.61,192.8 383.77,215.16 332.05,253.1 272.59,296.76 228.18,360.65 208.56,431.81 206.59,438.36 205.6,445.25 206.27,452.09 207.63,464.93 213.46,476.81 220.7,487.33 230.33,501.66 242.62,513.97 255.52,525.35 285.85,551.54 320.67,571.97 356.6,589.46 392.84,606.91 430.56,621.21 468.99,633.01 515.08,646.96 562.27,657.38 610.07,663.32 654.05,668.6 698.7,670.97 742.8,665.79 769.62,662.35 796.68,656.58 820.73,643.78 834,636.4 846.89,625.82 851.59,610.83 855.95,597.27 858.46,583.19 860.56,569.14 866.08,529.94 864.5,489.77 856.19,451.08 840.02,376.47 797.5,307.77 737.41,260.59 673.95,210.06 591.58,183.88 510.59,188.87 M158.87,309.94C135.87,320.03 113.94,333.34 96.28,351.38 78.89,369.67 67.18,393.92 66.09,419.33 64.6,443.68 71.89,467.72 82.81,489.24 102.45,526.93 132.2,558.32 164.63,585.32 224.4,634.98 293.98,671.5 365.95,700.06 384.7,707.75 404.04,713.83 423.13,720.56 449.15,728.56 475.4,735.79 501.87,742.12 523.22,747.41 544.92,751.09 566.49,755.38 630.35,765.32 695.25,770.88 759.84,766.16 792.45,763.51 825.02,758.91 856.63,750.28 890.99,740.68 924.97,726.68 952.41,703.37 967.49,690.62 980.21,674.68 987.19,656.07 996.94,630.69 995.51,601.95 986.29,576.64 976.81,550.21 960.86,526.57 942.78,505.28 925.14,484.55 904.76,466.34 883.42,449.51 882.42,448.53 881.13,448.09 879.77,448.08 880.02,452.2 881.08,456.21 881.79,460.28 891.54,514.4 888.32,570.79 872.63,623.49 871.3,628.3 867.72,631.9 864.9,635.86 850.62,656.05 827.79,667.9 805.03,676.02 787.55,682.35 769.18,685.7 750.84,688.36 713.43,693.31 675.52,693.13 637.97,690.07 592.48,686.23 547.4,678.2 503.17,667.01 462.28,656.58 422.1,643.32 383.17,627.03 345.36,611.13 308.65,592.29 274.71,569.19 247.17,550.07 220.62,528.32 201.54,500.42 190.46,484.08 181.91,465.05 182.52,444.93 182.79,438.12 184,431.37 186.09,424.89 200.72,373.49 226.97,325.39 262.63,285.55 263.67,284.66 263.85,283.35 263.81,282.07 227.92,287.17 192.19,295.4 158.87,309.94 M224.29,656.67C252.03,720.28 300.52,774.46 360.17,809.8 420.02,844.83 490.86,861.46 560.03,854.8 620.07,849.2 678.86,827.6 727.33,791.56 712.54,791.51 697.74,791.85 682.96,791.3 652.58,789.68 622.16,787.74 592.07,783.14 579.38,781.26 566.61,779.85 554.04,777.22 541.71,774.66 529.28,772.55 516.95,769.96 499.7,766.07 482.52,761.86 465.39,757.49 442.9,750.83 420.29,744.54 398.21,736.59 380.31,730.7 362.72,723.94 345.31,716.73 306.36,700.71 268.26,682.47 232.03,660.94 229.52,659.4 227.04,657.77 224.29,656.67z\" />\n              </GeometryDrawing.Geometry>\n            </GeometryDrawing>\n          </DrawingGroup.Children>\n        </DrawingGroup>\n        <DrawingGroup>\n          <DrawingGroup.Children>\n            <GeometryDrawing Brush=\"#FF00FCFC\">\n              <GeometryDrawing.Geometry>\n                <PathGeometry Figures=\"M510.59,188.87C591.58,183.88 673.95,210.06 737.41,260.59 797.5,307.77 840.02,376.47 856.19,451.08 864.5,489.77 866.08,529.94 860.56,569.14 858.46,583.19 855.95,597.27 851.59,610.83 846.89,625.82 834,636.4 820.73,643.78 796.68,656.58 769.62,662.35 742.8,665.79 698.7,670.97 654.05,668.6 610.07,663.32 562.27,657.38 515.08,646.96 468.99,633.01 430.56,621.21 392.84,606.91 356.6,589.46 320.67,571.97 285.85,551.54 255.52,525.35 242.62,513.97 230.33,501.66 220.7,487.33 213.46,476.81 207.63,464.93 206.27,452.09 205.6,445.25 206.59,438.36 208.56,431.81 228.18,360.65 272.59,296.76 332.05,253.1 383.77,215.16 446.61,192.8 510.59,188.87z\" />\n              </GeometryDrawing.Geometry>\n            </GeometryDrawing>\n            <GeometryDrawing Brush=\"#FF00FCFC\">\n              <GeometryDrawing.Geometry>\n                <PathGeometry Figures=\"M224.29,656.67C227.04,657.77 229.52,659.4 232.03,660.94 268.26,682.47 306.36,700.71 345.31,716.73 362.72,723.94 380.31,730.7 398.21,736.59 420.29,744.54 442.9,750.83 465.39,757.49 482.52,761.86 499.7,766.07 516.95,769.96 529.28,772.55 541.71,774.66 554.04,777.22 566.61,779.85 579.38,781.26 592.07,783.14 622.16,787.74 652.58,789.68 682.96,791.3 697.74,791.85 712.54,791.51 727.33,791.56 678.86,827.6 620.07,849.2 560.03,854.8 490.86,861.46 420.02,844.83 360.17,809.8 300.52,774.46 252.03,720.28 224.29,656.67z\" />\n              </GeometryDrawing.Geometry>\n            </GeometryDrawing>\n          </DrawingGroup.Children>\n        </DrawingGroup>\n        <DrawingGroup>\n          <DrawingGroup.Children>\n            <GeometryDrawing Brush=\"#FFFFFF46\">\n              <GeometryDrawing.Geometry>\n                <PathGeometry Figures=\"M158.87,309.94C192.19,295.4 227.92,287.17 263.81,282.07 263.85,283.35 263.67,284.66 262.63,285.55 226.97,325.39 200.72,373.49 186.09,424.89 184,431.37 182.79,438.12 182.52,444.93 181.91,465.05 190.46,484.08 201.54,500.42 220.62,528.32 247.17,550.07 274.71,569.19 308.65,592.29 345.36,611.13 383.17,627.03 422.1,643.32 462.28,656.58 503.17,667.01 547.4,678.2 592.48,686.23 637.97,690.07 675.52,693.13 713.43,693.31 750.84,688.36 769.18,685.7 787.55,682.35 805.03,676.02 827.79,667.9 850.62,656.05 864.9,635.86 867.72,631.9 871.3,628.3 872.63,623.49 888.32,570.79 891.54,514.4 881.79,460.28 881.08,456.21 880.02,452.2 879.77,448.08 881.13,448.09 882.42,448.53 883.42,449.51 904.76,466.34 925.14,484.55 942.78,505.28 960.86,526.57 976.81,550.21 986.29,576.64 995.51,601.95 996.94,630.69 987.19,656.07 980.21,674.68 967.49,690.62 952.41,703.37 924.97,726.68 890.99,740.68 856.63,750.28 825.02,758.91 792.45,763.51 759.84,766.16 695.25,770.88 630.35,765.32 566.49,755.38 544.92,751.09 523.22,747.41 501.87,742.12 475.4,735.79 449.15,728.56 423.13,720.56 404.04,713.83 384.7,707.75 365.95,700.06 293.98,671.5 224.4,634.98 164.63,585.32 132.2,558.32 102.45,526.93 82.81,489.24 71.89,467.72 64.6,443.68 66.09,419.33 67.18,393.92 78.89,369.67 96.28,351.38 113.94,333.34 135.87,320.03 158.87,309.94z\" />\n              </GeometryDrawing.Geometry>\n            </GeometryDrawing>\n          </DrawingGroup.Children>\n        </DrawingGroup>\n      </DrawingGroup.Children>\n      <DrawingGroup.ClipGeometry>\n        <RectangleGeometry Rect=\"0,0,1067,1067\" />\n      </DrawingGroup.ClipGeometry>\n    </DrawingGroup>\n  </DrawingImage.Drawing>\n</DrawingImage>\n\n");

        ViewModel.Pages.Add(new IPage("Folio", home, "Home", c, true, "home"));
        ViewModel.SelectedPage = ViewModel.Pages[0];
    }


    private void PageEntry_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            var uuid = (sender as Border)!.Tag;
            var entry = ViewModel.Pages.FirstOrDefault(page => page.Uuid == (string)uuid!);
            if (entry == null || entry == ViewModel.SelectedPage) return;
            Application.Current!.Resources.TryGetResource("PageItemBg", Application.Current.ActualThemeVariant,
                out var n);
            Application.Current!.Resources.TryGetResource("SelectedPageItemBg", Application.Current.ActualThemeVariant,
                out var a);
            foreach (var page in ViewModel.Pages)
            {
                page.Bg = (SolidColorBrush)n!;
            }

            entry.Bg = (SolidColorBrush)a!;
            ViewModel.SelectedPage = entry;
        }
        else if (e.GetCurrentPoint(this).Properties.IsMiddleButtonPressed)
        {
            var uuid = (sender as Border)!.Tag;
            var entry = ViewModel.Pages.FirstOrDefault(page => page.Uuid == (string)uuid!);
            if (entry == null || entry.Uuid == "home") return;
            if (entry == ViewModel.SelectedPage)
            {
                ViewModel.Pages[0].Select();
            }

            ViewModel.Pages.Remove(entry);
        }
        else if (e.GetCurrentPoint(this).Properties.IsRightButtonPressed)
        {
            var uuid = (sender as Border)!.Tag;
            var entry = ViewModel.Pages.FirstOrDefault(page => page.Uuid == (string)uuid!);
            (sender as Border)!.ContextFlyout!.ShowAt((sender as Border)!);
            if (entry!.Uuid == "home")
            {
                ((sender as Border)!.ContextFlyout as MenuFlyout)!.Items.Cast<MenuItem>()
                    .FirstOrDefault(item => item.Tag as string == "CloseTabMenuItem")!.IsEnabled = false;
            }
        }
    }

    private void ScrollViewer_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.Pointer.Type != PointerType.Mouse) return;
        if (sender is ScrollViewer control)
        {
            if (control.GetVisualRoot() is not Window window) return;
            window.BeginMoveDrag(e);
        }

        e.Handled = true;
    }

    private void CloseTabMenuItem_OnClick(object? sender, RoutedEventArgs e)
    {
        var tag = ((sender as MenuItem)!.Parent!.Parent!.Parent! as Border)!.Tag;
        var entry = ViewModel.Pages.FirstOrDefault(page => page.Uuid == (string)tag!);
        if (entry == null || entry.Uuid == "home") return;
        if (entry == ViewModel.SelectedPage)
        {
            ViewModel.Pages[0].Select();
        }

        ViewModel.Pages.Remove(entry);
    }
}