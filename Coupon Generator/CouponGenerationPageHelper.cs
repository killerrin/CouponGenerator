using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Coupon_Generator
{
    public class CouponGenerationPageHelper
    {
        public static bool UpdateSingleCoupon(Coupon coupon)
        {
            Debug.WriteLine(App.CurrentCouponSettings.NumberOfCouponsToGenerate);
            if (App.CurrentCouponSettings.NumberOfCouponsToGenerate == 0)
            {
                coupon.Visibility = System.Windows.Visibility.Collapsed;
                return false;
            }

            coupon.Visibility = System.Windows.Visibility.Visible;
            coupon.CouponID = App.CurrentCouponSettings.CouponIDStartIndex;

            App.CurrentCouponSettings.CouponIDStartIndex++;
            App.CurrentCouponSettings.NumberOfCouponsToGenerate--;
            return true;
        }

        public static MemoryStream SaveCanvas(Canvas canvas)
        {
            canvas.UpdateLayout();
            canvas.InvalidateVisual();
            
            Rect rect = new Rect(canvas.Margin.Left, canvas.Margin.Top, canvas.ActualWidth, canvas.ActualHeight);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,
              (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);

            rtb.Render(canvas);
            //endcode as PNG
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
            
            //save to memory stream
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            pngEncoder.Save(ms);
            //ms.Close();

            //System.IO.File.WriteAllBytes("C:\\Users\\Andrew\\Downloads\\logo.png", ms.ToArray());
            //Console.WriteLine("Done");
            return ms;
        }
    }
}
