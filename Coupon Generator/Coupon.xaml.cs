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
    /// Interaction logic for Coupon.xaml
    /// </summary>
    public partial class Coupon : UserControl
    {
        #region Fields/Properties
        CouponSettings m_couponSettings;
        public CouponSettings CouponSettings 
        {
            get { return m_couponSettings; }
            set
            {
                m_couponSettings = value;
                UpdateCoupon();
            }
        }

        int m_couponID;
        public int CouponID
        {
            get { return m_couponID; }
            set
            {
                m_couponID = value;
                UpdateCoupon();
            }
        }
        #endregion

        public Coupon()
        {
            Loaded += Coupon_Loaded;
            InitializeComponent();
        }

        void Coupon_Loaded(object sender, RoutedEventArgs e)
        {
            m_couponSettings = new CouponSettings();
            m_couponID = 1;

            UpdateCoupon();
        }

        public void UpdateCoupon()
        {
            // Background
            Background = new SolidColorBrush(m_couponSettings.BackgroundColor);

            if (m_couponSettings.ImageLocation != null)
                backgroundImage.Source = new BitmapImage(m_couponSettings.ImageLocation);
            else backgroundImage.Source = new BitmapImage();

            // Border
            BorderBrush = new SolidColorBrush(m_couponSettings.BorderColor);
            BorderThickness = new Thickness(m_couponSettings.BorderThickness);

            // Header
            if (m_couponSettings.HeaderEnabled)
            {
                headerTextBlock.Text = m_couponSettings.HeaderText;
                headerTextBlock.Margin = m_couponSettings.HeaderMargin;
                headerTextBlock.HorizontalAlignment = m_couponSettings.HeaderHorizontalAlignment;
                headerTextBlock.VerticalAlignment = m_couponSettings.HeaderVerticalAlignment;
            }
            else headerTextBlock.Text = "";

            // Body
            if (m_couponSettings.BodyEnabled)
            {
                bodyTextBlock.Text = m_couponSettings.BodyText;
                bodyTextBlock.Margin = m_couponSettings.BodyMargin;
                bodyTextBlock.HorizontalAlignment = m_couponSettings.BodyHorizontalAlignment;
                bodyTextBlock.VerticalAlignment = m_couponSettings.BodyVerticalAlignment;
            }
            else bodyTextBlock.Text = "";

            // Expiry Date
            if (m_couponSettings.ExpiryDateEnabled)
            {
                expiryDateTextBlock.Text = m_couponSettings.ExpiryDate.ToLongDateString();
                expiryDateTextBlock.Margin = m_couponSettings.ExpiryDateMargin;
                expiryDateTextBlock.HorizontalAlignment = m_couponSettings.ExpiryDateHorizontalAlignment;
                expiryDateTextBlock.VerticalAlignment = m_couponSettings.ExpiryDateVerticalAlignment;
            }
            else expiryDateTextBlock.Text = "";

            // Coupon ID
            if (m_couponSettings.CouponIDEnabled)
            {
                couponIDTextBlock.Text = m_couponID.ToString();
                couponIDTextBlock.Margin = m_couponSettings.CouponIDMargin;
                couponIDTextBlock.HorizontalAlignment = m_couponSettings.CouponIDHorizontalAlignment;
                couponIDTextBlock.VerticalAlignment = m_couponSettings.CouponIDVerticalAlignment;
            }
            else couponIDTextBlock.Text = "";
        }
    }
}
