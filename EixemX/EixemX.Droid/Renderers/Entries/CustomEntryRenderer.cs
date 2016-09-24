using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content.Res;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using EixemX.Controls.Entries;
using EixemX.Droid.Constants;
using EixemX.Droid.Renderers.Entries;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace EixemX.Droid.Renderers.Entries
{
    public class CustomEntryRenderer : EntryRenderer
    { 

        private bool IsRegular;
         
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e); 

            if (Control != null)
            { 
                EditText textField = (EditText)Control;
                var customEntry = e.NewElement as CustomEntry;

                textField.Ellipsize = TextUtils.TruncateAt.End;
                // Set colors
                textField.SetBackgroundResource(Resource.Drawable.entry_default);
                textField.SetTextColor(Xamarin.Forms.Color.White.ToAndroid());
                textField.SetHintTextColor(Xamarin.Forms.Color.White.ToAndroid());
                textField.SetHighlightColor(Xamarin.Forms.Color.FromHex("53c6c1").ToAndroid());

                // Set font  
                SetFontLight(textField);
                // Misc
                textField.SetSingleLine(true);
                textField.SetHorizontallyScrolling(false);
                textField.SetSelectAllOnFocus(false);
               // textField.SetPadding(10, 10, 10, 10);
                  
                textField.TextChanged += (sender, args) =>
                {
                    if (!string.IsNullOrWhiteSpace(customEntry.Text))
                    {
                        if (!IsRegular)
                        {
                            IsRegular = true;
                            textField.SetTypeface(Fonts.FontRegular, TypefaceStyle.Normal);
                        }

                        string text = customEntry.Text;
                        if (text.Length > customEntry.MaxLength)
                        {
                            text = text.Remove(text.Length - 1);
                            customEntry.Text = text;
                        }
                    }
                    else
                    {
                        SetFontLight(textField);
                    }
                }; 
            }
        }

        private void SetFontLight(EditText textField)
        {
            IsRegular = false;
            textField.SetTypeface(Fonts.FontLight, TypefaceStyle.Normal);
        }
    }
}