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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Coupon_Generator
{
    /// <summary>
    /// Interaction logic for CouponGenerationPage2x4.xaml
    /// </summary>
    public partial class CouponGenerationPage2x4 : Page
    {
        List<MemoryStream> m_imageMemoryStream;

        public CouponGenerationPage2x4()
        {
            Loaded += CouponGenerationPage2x4_Loaded;
            InitializeComponent();
        }

        void CouponGenerationPage2x4_Loaded(object sender, RoutedEventArgs e)
        {
            m_imageMemoryStream = new List<MemoryStream>();

            // Set the default Settings
            coupon11.CouponSettings = App.CurrentCouponSettings;
            coupon12.CouponSettings = App.CurrentCouponSettings;
            coupon21.CouponSettings = App.CurrentCouponSettings;
            coupon22.CouponSettings = App.CurrentCouponSettings;
            coupon31.CouponSettings = App.CurrentCouponSettings;
            coupon32.CouponSettings = App.CurrentCouponSettings;
            coupon41.CouponSettings = App.CurrentCouponSettings;
            coupon42.CouponSettings = App.CurrentCouponSettings;

            UpdateAllCoupons();
        }

        public void UpdateAllCoupons()
        {
            CouponGenerationPageHelper.UpdateSingleCoupon(coupon11);
            CouponGenerationPageHelper.UpdateSingleCoupon(coupon12);

            CouponGenerationPageHelper.UpdateSingleCoupon(coupon21);
            CouponGenerationPageHelper.UpdateSingleCoupon(coupon22);

            CouponGenerationPageHelper.UpdateSingleCoupon(coupon31);
            CouponGenerationPageHelper.UpdateSingleCoupon(coupon32);

            CouponGenerationPageHelper.UpdateSingleCoupon(coupon41);
            var couponResult = CouponGenerationPageHelper.UpdateSingleCoupon(coupon42);

            // Cache the Image
            m_imageMemoryStream.Add(CouponGenerationPageHelper.SaveCanvas(couponCanvas));

            if (couponResult && App.CurrentCouponSettings.NumberOfCouponsToGenerate > 0)
            {
                // Then Update all the Coupons Again
                UpdateAllCoupons();
            }
            else
            {
                // Get a Foldername of where to save
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Coupon Generation";
                dlg.DefaultExt = ".pdf";
                dlg.Filter = "PDF Documents (.pdf)|*.pdf";
                Nullable<bool> dlgResult = dlg.ShowDialog();
                if (dlgResult == true) {                    
                    // Save Images to PDF
                    PdfDocument document = new PdfDocument();
                    document.Info.Title = "Coupon Generation 2x4";
                    document.Info.Author = "...";
                    document.Info.Subject = "Coupons Generated using Coupon Generator";
                    document.Info.Keywords = "Coupons";

                    for (int i = 0; i < m_imageMemoryStream.Count; i++)
                    {
                        PdfPage page = document.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);

                        var container = gfx.BeginContainer();
                        gfx.RotateTransform(90.0);

                        System.Drawing.Image wpfImage = System.Drawing.Image.FromStream(m_imageMemoryStream[i]);
                        XImage pdfImage = XImage.FromGdiPlusImage(System.Drawing.Image.FromStream(m_imageMemoryStream[i]));
                        gfx.DrawImage(pdfImage, 0.0, 0.0); //i * pdfImage.VerticalResolution);
                        gfx.EndContainer(container);
                    }

                    document.Save(dlg.FileName);
                }

                // Clean up the Images
                for (int i = 0; i < m_imageMemoryStream.Count; i++)
                {
                    m_imageMemoryStream[i].Close();
                    m_imageMemoryStream[i].Dispose();
                }
                m_imageMemoryStream.Clear();

                var cc = CouponGenerationPageHelper.SaveCanvas(couponCanvas);
                cc.Close();
                System.IO.File.WriteAllBytes("C:\\Users\\Andrew\\Downloads\\testView.png", cc.ToArray());

                // Navigate Out
                //MainWindow.Current.mainFrame.GoBack();
            }
        }
    }
}
