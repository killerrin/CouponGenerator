using PdfSharp.Drawing;
using PdfSharp.Pdf;
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

        public static MemoryStream SaveCanvasToStream(Canvas canvas)
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

        public static bool SaveToFile(ref List<MemoryStream> imageMemoryStreamList)
        {
            bool savedSuccessfully = false;

            // Display the save Dialog so an option can be chosen
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Coupon Generation";
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF Documents (.pdf)|*.pdf|Series Of Images (.png)|*.png";
            Nullable<bool> dlgResult = dlg.ShowDialog();

            if (dlgResult == true)
            {
                savedSuccessfully = true;

                string fileName = dlg.FileName;
                switch (dlg.FilterIndex)
                {
                    #region PDF
                    case 1:
                        System.IO.Path.ChangeExtension(fileName, "pdf");

                        PdfDocument document = new PdfDocument();
                        document.Info.Title = "Coupon Generation 2x4";
                        document.Info.Author = "...";
                        document.Info.Subject = "Coupons Generated using Coupon Generator";
                        document.Info.Keywords = "Coupons";

                        for (int i = 0; i < imageMemoryStreamList.Count; i++)
                        {
                            PdfPage page = document.AddPage();
                            XGraphics gfx = XGraphics.FromPdfPage(page);
                            
                            System.Drawing.Image wpfImage = System.Drawing.Image.FromStream(imageMemoryStreamList[i]);
                            XImage pdfImage = XImage.FromGdiPlusImage(System.Drawing.Image.FromStream(imageMemoryStreamList[i]));
                            gfx.DrawImage(pdfImage, 0.0, 0.0);

                            // Cleanup and Destroy
                            imageMemoryStreamList[i].Close();
                            imageMemoryStreamList[i].Dispose();
                        }

                        document.Save(dlg.FileName);
                        Process.Start(dlg.FileName);
                        break;
                    #endregion

                    #region Series of Images (PNG)
                    case 2: // Series of Images (PNG)
                        System.IO.Path.ChangeExtension(fileName, "png");

                        string path = System.IO.Path.GetFullPath(fileName);
                        path = path.Substring(0, path.Length - System.IO.Path.GetFileName(fileName).Length);
                        Debug.WriteLine(path);

                        string extension = System.IO.Path.GetExtension(fileName);
                        Debug.WriteLine(extension);

                        string dateFormat = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "-" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;

                        for (int i = 0; i < imageMemoryStreamList.Count; i++)
                        {
                            imageMemoryStreamList[i].Close();

                            string nameOfFile = System.IO.Path.GetFileNameWithoutExtension(fileName) + "_" + dateFormat +"_" + i;
                            Debug.WriteLine(nameOfFile);

                            System.IO.File.WriteAllBytes(path + nameOfFile + extension, imageMemoryStreamList[i].ToArray());

                            imageMemoryStreamList[i].Dispose();
                        }
                        break;
                    #endregion

                    default: savedSuccessfully = false; break;
                }
            }

            imageMemoryStreamList.Clear();
            return savedSuccessfully;
        }
    }
}
