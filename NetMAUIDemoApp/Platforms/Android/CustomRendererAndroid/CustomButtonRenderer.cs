using Android.Content;
using Android.Graphics.Drawables;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.FastRenderers;
using Microsoft.Maui.Controls.Platform;

namespace NetMAUIDemoApp.CustomRendererAndroid
{
    class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var button = Control;

                button.SetTextColor(Android.Graphics.Color.White);
                button.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
                button.SetPadding(0, 40, 0, 40);

                GradientDrawable drawable = new GradientDrawable();
                drawable.SetCornerRadius(75);
                drawable.SetColor(Android.Graphics.Color.ParseColor("#007AFF"));
                button.SetBackground(drawable);
            }
        }
    }
}