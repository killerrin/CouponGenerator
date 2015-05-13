using System;
using System.Collections.Generic;
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
    /// Interaction logic for CouponGenerationPage2x4.xaml
    /// </summary>
    public partial class CouponGenerationPage2x4 : Page
    {
        public CouponGenerationPage2x4()
        {
            Loaded += CouponGenerationPage2x4_Loaded;
            InitializeComponent();
        }

        void CouponGenerationPage2x4_Loaded(object sender, RoutedEventArgs e)
        {
            // Setup the Coupon Settings
            coupon11.CouponSettings = App.CurrentCouponSettings;
            coupon12.CouponSettings = App.CurrentCouponSettings;
            coupon21.CouponSettings = App.CurrentCouponSettings;
            coupon22.CouponSettings = App.CurrentCouponSettings;
            coupon31.CouponSettings = App.CurrentCouponSettings;
            coupon32.CouponSettings = App.CurrentCouponSettings;
            coupon41.CouponSettings = App.CurrentCouponSettings;
            coupon42.CouponSettings = App.CurrentCouponSettings;

            // Setup the CouponIDs
            coupon11.CouponID = App.CurrentCouponSettings.CouponIDStartIndex;
            coupon12.CouponID = App.CurrentCouponSettings.CouponIDStartIndex + 1;
            coupon21.CouponID = App.CurrentCouponSettings.CouponIDStartIndex + 2;
            coupon22.CouponID = App.CurrentCouponSettings.CouponIDStartIndex + 3;
            coupon31.CouponID = App.CurrentCouponSettings.CouponIDStartIndex + 4;
            coupon32.CouponID = App.CurrentCouponSettings.CouponIDStartIndex + 5;
            coupon41.CouponID = App.CurrentCouponSettings.CouponIDStartIndex + 6;
            coupon42.CouponID = App.CurrentCouponSettings.CouponIDStartIndex + 7;

            App.CurrentCouponSettings.CouponIDStartIndex += 8;
        }
    }
}
