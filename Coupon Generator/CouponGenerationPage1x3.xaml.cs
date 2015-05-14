using System;
using System.Collections.Generic;
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

namespace Coupon_Generator
{
    /// <summary>
    /// Interaction logic for CouponGenerationPage1x3.xaml
    /// </summary>
    public partial class CouponGenerationPage1x3 : Page
    {
        List<MemoryStream> m_imageMemoryStream;

        public CouponGenerationPage1x3()
        {
            Loaded += CouponGenerationPage1x3_Loaded;
            InitializeComponent();
        }

        void CouponGenerationPage1x3_Loaded(object sender, RoutedEventArgs e)
        {
            m_imageMemoryStream = new List<MemoryStream>();

            // Set the default Settings
            coupon11.CouponSettings = App.CurrentCouponSettings;
            coupon21.CouponSettings = App.CurrentCouponSettings;
            coupon31.CouponSettings = App.CurrentCouponSettings;

            UpdateAllCoupons();
        }

        public void UpdateAllCoupons()
        {
            CouponGenerationPageHelper.UpdateSingleCoupon(coupon11);
            CouponGenerationPageHelper.UpdateSingleCoupon(coupon21);
            var couponResult = CouponGenerationPageHelper.UpdateSingleCoupon(coupon31);

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

                // Navigate Out
                MainWindow.Current.mainFrame.GoBack();
            }
        }
    }
}
