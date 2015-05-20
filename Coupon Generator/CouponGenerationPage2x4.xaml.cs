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
            m_imageMemoryStream.Add(CouponGenerationPageHelper.SaveCanvasToStream(couponCanvas));

            if (couponResult && App.CurrentCouponSettings.NumberOfCouponsToGenerate > 0)
            {
                // Then Update all the Coupons Again
                UpdateAllCoupons();
            }
            else
            {
                CouponGenerationPageHelper.SaveToFile(ref m_imageMemoryStream);

                // Save the Coupon Settings
                if (App.CurrentCouponSettings.SaveLocation != null)
                {
                    //MainWindow.Current.mainWindow_File_Save_Click(null, null);
                }

                // Navigate Out
                MainWindow.Current.mainFrame.GoBack();
            }
        }
    }
}
