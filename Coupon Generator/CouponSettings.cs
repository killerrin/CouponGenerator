using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Coupon_Generator
{
    public class CouponSettings
    {
        public Color BackgroundColor;
        public Uri ImageLocation;

        public Color BorderColor;
        public int BorderThickness;

        public bool HeaderEnabled;
        public string HeaderText;
        public Thickness HeaderMargin;
        public HorizontalAlignment HeaderHorizontalAlignment;
        public VerticalAlignment HeaderVerticalAlignment;

        public bool BodyEnabled;
        public string BodyText;
        public Thickness BodyMargin;
        public HorizontalAlignment BodyHorizontalAlignment;
        public VerticalAlignment BodyVerticalAlignment;

        public bool ExpiryDateEnabled;
        public ExpiryDateCase ExpiryDateCase;
        public string ExpiryText;
        public DateTime ExpiryDate;
        public Thickness ExpiryDateMargin;
        public HorizontalAlignment ExpiryDateHorizontalAlignment;
        public VerticalAlignment ExpiryDateVerticalAlignment;

        public bool CouponIDEnabled;
        public Thickness CouponIDMargin;
        public HorizontalAlignment CouponIDHorizontalAlignment;
        public VerticalAlignment CouponIDVerticalAlignment;
        
        public int CouponIDStartIndex;
        public int NumberOfCouponsToGenerate;
        public SaveAsSettings SaveAsSettings;

        public CouponSettings()
        {
            BackgroundColor = Color.FromArgb(255, 197, 228, 255);
            ImageLocation = null;

            BorderColor = Color.FromArgb(255, 0, 0, 0);
            BorderThickness = 2;

            HeaderEnabled = true;
            HeaderText = "";
            HeaderMargin = new Thickness(0, 0, 0, 0);
            HeaderHorizontalAlignment = HorizontalAlignment.Center;
            HeaderVerticalAlignment = VerticalAlignment.Top;

            BodyEnabled = true;
            BodyText = "";
            BodyMargin = new Thickness(0, 0, 0, 0);
            BodyHorizontalAlignment = HorizontalAlignment.Center;
            BodyVerticalAlignment = VerticalAlignment.Center;

            ExpiryDateEnabled = true;
            ExpiryDateCase = Coupon_Generator.ExpiryDateCase.Default;
            ExpiryText = "Expires";
            ExpiryDate = new DateTime(DateTime.Now.Year, 12, 31);
            ExpiryDateMargin = new Thickness(0, 0, 0, 10);
            ExpiryDateHorizontalAlignment = HorizontalAlignment.Center;
            ExpiryDateVerticalAlignment = VerticalAlignment.Bottom;

            CouponIDEnabled = true;
            CouponIDStartIndex = 1;
            CouponIDMargin = new Thickness(0, 0, 40, 10);
            CouponIDHorizontalAlignment = HorizontalAlignment.Right;
            CouponIDVerticalAlignment = VerticalAlignment.Bottom;

            NumberOfCouponsToGenerate = 8;
            SaveAsSettings = Coupon_Generator.SaveAsSettings.Any;
        }
    }
}
