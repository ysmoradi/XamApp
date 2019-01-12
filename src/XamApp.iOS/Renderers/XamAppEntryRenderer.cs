using UIKit;
using XamApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(XamAppEntryRenderer))]

namespace XamApp.iOS.Renderers
{
public class XamAppEntryRenderer : EntryRenderer
{
    protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
    {
        base.OnElementChanged(e);

        if (e.NewElement != null) /* e.NewElement is a Xamarin Forms' Entry */
        {
            Control.ClearButtonMode = UITextFieldViewMode.WhileEditing; // Control is UITextField
        }
    }
}
}