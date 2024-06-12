using CoreGraphics;
using NetMAUIDemoApp.Controls;
using Foundation;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;


namespace NetMAUIDemoApp.CustomRendererIOS
{
    class CustomButtonRenderer: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var button = Control;
                button.SetTitleColor(UIColor.White, UIControlState.Normal);
                button.TitleLabel.Font = UIFont.BoldSystemFontOfSize(button.TitleLabel.Font.PointSize);
                button.ContentEdgeInsets = new UIEdgeInsets(20, 0, 0, 0);

                button.Layer.CornerRadius = 75;
                button.Layer.BackgroundColor = UIColor.FromRGB(0, 122, 255).CGColor;
                button.ClipsToBounds = true;
            }
        }
    }
}