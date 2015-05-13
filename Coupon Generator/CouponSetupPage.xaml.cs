using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CouponSetupPage.xaml
    /// </summary>
    public partial class CouponSetupPage : Page
    {
        public CouponSetupPage()
        {
            Loaded += CouponSetupPage_Loaded;
            InitializeComponent();
        }

        void CouponSetupPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Background Defaults
            couponBackgroundColorPicker.SelectedColor = App.CurrentCouponSettings.BackgroundColor;

            if (App.CurrentCouponSettings.ImageLocation != null)
                couponImage.Source = new BitmapImage(App.CurrentCouponSettings.ImageLocation);
            else couponImage.Source = new BitmapImage();

            // Border Defaults
            borderThicknessTextBox.Text = App.CurrentCouponSettings.BorderThickness.ToString();

            // Header Defaults
            headerTextBox.Text = App.CurrentCouponSettings.HeaderText;
            headerMarginTextBlockLeft.Text = App.CurrentCouponSettings.HeaderMargin.Left.ToString();
            headerMarginTextBlockRight.Text = App.CurrentCouponSettings.HeaderMargin.Right.ToString();
            headerMarginTextBlockTop.Text = App.CurrentCouponSettings.HeaderMargin.Top.ToString();
            headerMarginTextBlockBottom.Text = App.CurrentCouponSettings.HeaderMargin.Bottom.ToString();
            headerCurrentHorizontalAlignment.Text = App.CurrentCouponSettings.HeaderHorizontalAlignment.ToString();
            headerCurrentVerticalAlignment.Text = App.CurrentCouponSettings.HeaderVerticalAlignment.ToString();

            if (App.CurrentCouponSettings.HeaderEnabled)
                headerEnabledRadioButton.IsChecked = true;
            else headerDisabledRadioButton.IsChecked = true;

            // Body Defaults
            bodyTextBox.Text = App.CurrentCouponSettings.BodyText;
            bodyMarginTextBlockLeft.Text = App.CurrentCouponSettings.BodyMargin.Left.ToString();
            bodyMarginTextBlockRight.Text = App.CurrentCouponSettings.BodyMargin.Right.ToString();
            bodyMarginTextBlockTop.Text = App.CurrentCouponSettings.BodyMargin.Top.ToString();
            bodyMarginTextBlockBottom.Text = App.CurrentCouponSettings.BodyMargin.Bottom.ToString();
            bodyCurrentHorizontalAlignment.Text = App.CurrentCouponSettings.BodyHorizontalAlignment.ToString();
            bodyCurrentVerticalAlignment.Text = App.CurrentCouponSettings.BodyVerticalAlignment.ToString();
            
            if (App.CurrentCouponSettings.BodyEnabled)
                bodyEnabledRadioButton.IsChecked = true;
            else bodyDisabledRadioButton.IsChecked = true;

            // Expiry Defaults
            expiryDatePicker.SelectedDate = App.CurrentCouponSettings.ExpiryDate;
            expiryDateMarginTextBlockLeft.Text = App.CurrentCouponSettings.ExpiryDateMargin.Left.ToString();
            expiryDateMarginTextBlockRight.Text = App.CurrentCouponSettings.ExpiryDateMargin.Right.ToString();
            expiryDateMarginTextBlockTop.Text = App.CurrentCouponSettings.ExpiryDateMargin.Top.ToString();
            expiryDateMarginTextBlockBottom.Text = App.CurrentCouponSettings.ExpiryDateMargin.Bottom.ToString();
            expiryDateCurrentHorizontalAlignment.Text = App.CurrentCouponSettings.ExpiryDateHorizontalAlignment.ToString();
            expiryDateCurrentVerticalAlignment.Text = App.CurrentCouponSettings.ExpiryDateVerticalAlignment.ToString();

            if (App.CurrentCouponSettings.ExpiryDateEnabled)
                expiryDateEnabledRadioButton.IsChecked = true;
            else expiryDateDisabledRadioButton.IsChecked = true;

            // Coupon ID Defaults
            couponIDStartingNumberTextBlock.Text = App.CurrentCouponSettings.CouponIDStartIndex.ToString();
            couponIDMarginTextBlockLeft.Text = App.CurrentCouponSettings.CouponIDMargin.Left.ToString();
            couponIDMarginTextBlockRight.Text = App.CurrentCouponSettings.CouponIDMargin.Right.ToString();
            couponIDMarginTextBlockTop.Text = App.CurrentCouponSettings.CouponIDMargin.Top.ToString();
            couponIDMarginTextBlockBottom.Text = App.CurrentCouponSettings.CouponIDMargin.Bottom.ToString();
            couponIDCurrentHorizontalAlignment.Text = App.CurrentCouponSettings.CouponIDHorizontalAlignment.ToString();
            couponIDCurrentVerticalAlignment.Text = App.CurrentCouponSettings.CouponIDVerticalAlignment.ToString();

            if (App.CurrentCouponSettings.CouponIDEnabled)
                couponIDEnabledRadioButton.IsChecked = true;
            else couponIDDisabledRadioButton.IsChecked = true;

            // Update the Preview
            UpdatePreviewImage();
        }

        public bool OnlyContainsNumbers(string textToCheck)
        {
            Regex regex = new Regex("[^0-9]+");
            return regex.IsMatch(textToCheck);
        }

        #region Tab Control
        private void textBox_NumberValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = OnlyContainsNumbers(e.Text);
        }

        #region Background Tab
        private void couponBackgroundColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            App.CurrentCouponSettings.BackgroundColor = e.NewValue;
            UpdatePreviewImage();
        }

        private void selectImage_Clicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.JPG; *.jpeg; *.JPEG; *.jpe; *.jfif; *.png; *.PNG |All Files (*.*)|*.*";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                App.CurrentCouponSettings.ImageLocation = new Uri(dlg.FileName, UriKind.Absolute);
                couponImage.Source = new BitmapImage(App.CurrentCouponSettings.ImageLocation);
                UpdatePreviewImage();
            }
        }
        private void backgroundClear_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ImageLocation = null;
            couponImage.Source = new BitmapImage();
            UpdatePreviewImage();
        }
        #endregion

        #region Border Tab
        private void borderThickness_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Int32.TryParse(borderThicknessTextBox.Text, out App.CurrentCouponSettings.BorderThickness))
            {
                App.CurrentCouponSettings.BorderThickness = 0;
            }

            UpdatePreviewImage();
        }
        #endregion

        #region Header Tab
        private void headerText_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(headerTextBox.Text))
                App.CurrentCouponSettings.HeaderText = "";
            else
                App.CurrentCouponSettings.HeaderText = headerTextBox.Text;
            UpdatePreviewImage();
        }

        private void HeaderEnabledRadioButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderEnabled = true;
            UpdatePreviewImage();
        }
        private void HeaderDisabledRadioButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderEnabled = false;
            UpdatePreviewImage();
        }

        #region Margin
        private void headerMarginTop_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(headerMarginTextBlockTop.Text, out value))
                App.CurrentCouponSettings.HeaderMargin.Top = value;
            else
                App.CurrentCouponSettings.HeaderMargin.Top = 0;

            UpdatePreviewImage();
        }

        private void headerMarginBottom_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(headerMarginTextBlockBottom.Text, out value))
                App.CurrentCouponSettings.HeaderMargin.Bottom = value;
            else
                App.CurrentCouponSettings.HeaderMargin.Bottom = 0;

            UpdatePreviewImage();
        }

        private void headerMarginLeft_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(headerMarginTextBlockLeft.Text, out value))
                App.CurrentCouponSettings.HeaderMargin.Left = value;
            else
                App.CurrentCouponSettings.HeaderMargin.Left = 0;

            UpdatePreviewImage();
        }

        private void headerMarginRight_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(headerMarginTextBlockRight.Text, out value))
                App.CurrentCouponSettings.HeaderMargin.Right = value;
            else
                App.CurrentCouponSettings.HeaderMargin.Right = 0;

            UpdatePreviewImage();
        }
        #endregion
        #region Horizontal Alignment
        private void headerHorizontalAlignmentStretch_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderHorizontalAlignment = HorizontalAlignment.Stretch;
            UpdatePreviewImage();
        }

        private void headerHorizontalAlignmentLeft_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderHorizontalAlignment = HorizontalAlignment.Left;
            UpdatePreviewImage();
        }

        private void headerHorizontalAlignmentRight_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderHorizontalAlignment = HorizontalAlignment.Right;
            UpdatePreviewImage();
        }

        private void headerHorizontalAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderHorizontalAlignment = HorizontalAlignment.Center;
            UpdatePreviewImage();
        }
        #endregion
        #region Vertical Alignment
        private void headerVerticalAlignmentStretch_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderVerticalAlignment = VerticalAlignment.Stretch;
            UpdatePreviewImage();
        }

        private void headerVerticalAlignmentTop_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderVerticalAlignment = VerticalAlignment.Top;
            UpdatePreviewImage();
        }

        private void headerVerticalAlignmentBottom_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderVerticalAlignment = VerticalAlignment.Bottom;
            UpdatePreviewImage();
        }

        private void headerVerticalAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.HeaderVerticalAlignment = VerticalAlignment.Center;
            UpdatePreviewImage();
        }
        #endregion
        #endregion

        #region Body Tab
        private void bodyText_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(bodyTextBox.Text))
                App.CurrentCouponSettings.BodyText = "";
            else
                App.CurrentCouponSettings.BodyText = bodyTextBox.Text;
            UpdatePreviewImage();
        }
        private void bodyEnabledRadioButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyEnabled = true;
            UpdatePreviewImage();
        }
        private void bodyDisabledRadioButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyEnabled = false;
            UpdatePreviewImage();
        }
        
        #region Margin
        private void bodyMarginTop_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(bodyMarginTextBlockTop.Text, out value))
                App.CurrentCouponSettings.BodyMargin.Top = value;
            else
                App.CurrentCouponSettings.BodyMargin.Top = 0;
        
            UpdatePreviewImage();
        }
        
        private void bodyMarginBottom_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(bodyMarginTextBlockBottom.Text, out value))
                App.CurrentCouponSettings.BodyMargin.Bottom = value;
            else
                App.CurrentCouponSettings.BodyMargin.Bottom = 0;
        
            UpdatePreviewImage();
        }
        
        private void bodyMarginLeft_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(bodyMarginTextBlockLeft.Text, out value))
                App.CurrentCouponSettings.BodyMargin.Left = value;
            else
                App.CurrentCouponSettings.BodyMargin.Left = 0;
        
            UpdatePreviewImage();
        }
        
        private void bodyMarginRight_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(bodyMarginTextBlockRight.Text, out value))
                App.CurrentCouponSettings.BodyMargin.Right = value;
            else
                App.CurrentCouponSettings.BodyMargin.Right = 0;
        
            UpdatePreviewImage();
        }
        #endregion
        #region Horizontal Alignment
        private void bodyHorizontalAlignmentStretch_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyHorizontalAlignment = HorizontalAlignment.Stretch;
            UpdatePreviewImage();
        }
        
        private void bodyHorizontalAlignmentLeft_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyHorizontalAlignment = HorizontalAlignment.Left;
            UpdatePreviewImage();
        }
        
        private void bodyHorizontalAlignmentRight_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyHorizontalAlignment = HorizontalAlignment.Right;
            UpdatePreviewImage();
        }
        
        private void bodyHorizontalAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyHorizontalAlignment = HorizontalAlignment.Center;
            UpdatePreviewImage();
        }
        #endregion
        #region Vertical Alignment
        private void bodyVerticalAlignmentStretch_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyVerticalAlignment = VerticalAlignment.Stretch;
            UpdatePreviewImage();
        }
        
        private void bodyVerticalAlignmentTop_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyVerticalAlignment = VerticalAlignment.Top;
            UpdatePreviewImage();
        }
        
        private void bodyVerticalAlignmentBottom_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyVerticalAlignment = VerticalAlignment.Bottom;
            UpdatePreviewImage();
        }
        
        private void bodyVerticalAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.BodyVerticalAlignment = VerticalAlignment.Center;
            UpdatePreviewImage();
        }
        #endregion 
        #endregion

        #region Expiry Date Tab
        private void expiryDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!expiryDatePicker.SelectedDate.HasValue) return;
            App.CurrentCouponSettings.ExpiryDate = expiryDatePicker.SelectedDate.Value;
            UpdatePreviewImage();
        }
        private void expiryDateEnabledRadioButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateEnabled = true;
            UpdatePreviewImage();
        }
        private void expiryDateDisabledRadioButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateEnabled = false;
            UpdatePreviewImage();
        }

        #region Margin
        private void expiryDateMarginTop_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(expiryDateMarginTextBlockTop.Text, out value))
                App.CurrentCouponSettings.ExpiryDateMargin.Top = value;
            else
                App.CurrentCouponSettings.ExpiryDateMargin.Top = 0;

            UpdatePreviewImage();
        }

        private void expiryDateMarginBottom_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(expiryDateMarginTextBlockBottom.Text, out value))
                App.CurrentCouponSettings.ExpiryDateMargin.Bottom = value;
            else
                App.CurrentCouponSettings.ExpiryDateMargin.Bottom = 0;

            UpdatePreviewImage();
        }

        private void expiryDateMarginLeft_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(expiryDateMarginTextBlockLeft.Text, out value))
                App.CurrentCouponSettings.ExpiryDateMargin.Left = value;
            else
                App.CurrentCouponSettings.ExpiryDateMargin.Left = 0;

            UpdatePreviewImage();
        }

        private void expiryDateMarginRight_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(expiryDateMarginTextBlockRight.Text, out value))
                App.CurrentCouponSettings.ExpiryDateMargin.Right = value;
            else
                App.CurrentCouponSettings.ExpiryDateMargin.Right = 0;

            UpdatePreviewImage();
        }
        #endregion
        #region Horizontal Alignment
        private void expiryDateHorizontalAlignmentStretch_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateHorizontalAlignment = HorizontalAlignment.Stretch;
            UpdatePreviewImage();
        }

        private void expiryDateHorizontalAlignmentLeft_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateHorizontalAlignment = HorizontalAlignment.Left;
            UpdatePreviewImage();
        }

        private void expiryDateHorizontalAlignmentRight_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateHorizontalAlignment = HorizontalAlignment.Right;
            UpdatePreviewImage();
        }

        private void expiryDateHorizontalAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateHorizontalAlignment = HorizontalAlignment.Center;
            UpdatePreviewImage();
        }
        #endregion
        #region Vertical Alignment
        private void expiryDateVerticalAlignmentStretch_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateVerticalAlignment = VerticalAlignment.Stretch;
            UpdatePreviewImage();
        }

        private void expiryDateVerticalAlignmentTop_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateVerticalAlignment = VerticalAlignment.Top;
            UpdatePreviewImage();
        }

        private void expiryDateVerticalAlignmentBottom_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateVerticalAlignment = VerticalAlignment.Bottom;
            UpdatePreviewImage();
        }

        private void expiryDateVerticalAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.ExpiryDateVerticalAlignment = VerticalAlignment.Center;
            UpdatePreviewImage();
        }
        #endregion
        #endregion

        #region Coupon ID Tab
        private void couponIDStartingNumberTextBlock_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Int32.TryParse(couponIDStartingNumberTextBlock.Text, out App.CurrentCouponSettings.CouponIDStartIndex))
            {
                App.CurrentCouponSettings.CouponIDStartIndex = 1;
            }

            UpdatePreviewImage();
        }
        private void couponIDEnabledRadioButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDEnabled = true;
            UpdatePreviewImage();
        }

        private void couponIDDisabledRadioButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDEnabled = false;
            UpdatePreviewImage();
        }

        #region Margin
        private void couponIDMarginTop_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(couponIDMarginTextBlockTop.Text, out value))
                App.CurrentCouponSettings.CouponIDMargin.Top = value;
            else
                App.CurrentCouponSettings.CouponIDMargin.Top = 0;

            UpdatePreviewImage();
        }

        private void couponIDMarginBottom_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(couponIDMarginTextBlockBottom.Text, out value))
                App.CurrentCouponSettings.CouponIDMargin.Bottom = value;
            else
                App.CurrentCouponSettings.CouponIDMargin.Bottom = 0;

            UpdatePreviewImage();
        }

        private void couponIDMarginLeft_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(couponIDMarginTextBlockLeft.Text, out value))
                App.CurrentCouponSettings.CouponIDMargin.Left = value;
            else
                App.CurrentCouponSettings.CouponIDMargin.Left = 0;

            UpdatePreviewImage();
        }

        private void couponIDMarginRight_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(couponIDMarginTextBlockRight.Text, out value))
                App.CurrentCouponSettings.CouponIDMargin.Right = value;
            else
                App.CurrentCouponSettings.CouponIDMargin.Right = 0;

            UpdatePreviewImage();
        }
        #endregion
        #region Horizontal Alignment
        private void couponIDHorizontalAlignmentStretch_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDHorizontalAlignment = HorizontalAlignment.Stretch;
            UpdatePreviewImage();
        }

        private void couponIDHorizontalAlignmentLeft_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDHorizontalAlignment = HorizontalAlignment.Left;
            UpdatePreviewImage();
        }

        private void couponIDHorizontalAlignmentRight_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDHorizontalAlignment = HorizontalAlignment.Right;
            UpdatePreviewImage();
        }

        private void couponIDHorizontalAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDHorizontalAlignment = HorizontalAlignment.Center;
            UpdatePreviewImage();
        }
        #endregion
        #region Vertical Alignment
        private void couponIDVerticalAlignmentStretch_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDVerticalAlignment = VerticalAlignment.Stretch;
            UpdatePreviewImage();
        }

        private void couponIDVerticalAlignmentTop_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDVerticalAlignment = VerticalAlignment.Top;
            UpdatePreviewImage();
        }

        private void couponIDVerticalAlignmentBottom_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDVerticalAlignment = VerticalAlignment.Bottom;
            UpdatePreviewImage();
        }

        private void couponIDVerticalAlignmentCenter_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings.CouponIDVerticalAlignment = VerticalAlignment.Center;
            UpdatePreviewImage();
        }
        #endregion
        #endregion
        #endregion

        #region Preview
        public void UpdatePreviewImage()
        {
            previewBackgroundColor.Fill = new SolidColorBrush(App.CurrentCouponSettings.BackgroundColor);

            // Background Image
            if (App.CurrentCouponSettings.ImageLocation != null)
                previewImage.Source = new BitmapImage(App.CurrentCouponSettings.ImageLocation);
            else previewImage.Source = new BitmapImage();

            // Border
            previewBorderRectangle.StrokeThickness = App.CurrentCouponSettings.BorderThickness;

            // Header
            if (App.CurrentCouponSettings.HeaderEnabled)
            {
                previewHeaderTextBlock.Text = App.CurrentCouponSettings.HeaderText;
                previewHeaderTextBlock.Margin = App.CurrentCouponSettings.HeaderMargin;
                previewHeaderTextBlock.HorizontalAlignment = App.CurrentCouponSettings.HeaderHorizontalAlignment;
                previewHeaderTextBlock.VerticalAlignment = App.CurrentCouponSettings.HeaderVerticalAlignment;
            }
            else previewHeaderTextBlock.Text = "";

            // Body
            if (App.CurrentCouponSettings.BodyEnabled)
            {
                previewBodyTextBlock.Text = App.CurrentCouponSettings.BodyText;
                previewBodyTextBlock.Margin = App.CurrentCouponSettings.BodyMargin;
                previewBodyTextBlock.HorizontalAlignment = App.CurrentCouponSettings.BodyHorizontalAlignment;
                previewBodyTextBlock.VerticalAlignment = App.CurrentCouponSettings.BodyVerticalAlignment;
            }
            else previewBodyTextBlock.Text = "";

            // Expiry Date
            if (App.CurrentCouponSettings.ExpiryDateEnabled) 
            {
                previewExpiryDateTextBlock.Text = App.CurrentCouponSettings.ExpiryDate.ToLongDateString();
                previewExpiryDateTextBlock.Margin = App.CurrentCouponSettings.ExpiryDateMargin;
                previewExpiryDateTextBlock.HorizontalAlignment = App.CurrentCouponSettings.ExpiryDateHorizontalAlignment;
                previewExpiryDateTextBlock.VerticalAlignment = App.CurrentCouponSettings.ExpiryDateVerticalAlignment;
            }
            else previewExpiryDateTextBlock.Text = "";

            // Coupon ID
            if (App.CurrentCouponSettings.CouponIDEnabled)
            {
                previewCouponNumberTextBlock.Text = App.CurrentCouponSettings.CouponIDStartIndex.ToString();
                previewCouponNumberTextBlock.Margin = App.CurrentCouponSettings.CouponIDMargin;
                previewCouponNumberTextBlock.HorizontalAlignment = App.CurrentCouponSettings.CouponIDHorizontalAlignment;
                previewCouponNumberTextBlock.VerticalAlignment = App.CurrentCouponSettings.CouponIDVerticalAlignment;
            }
            else previewCouponNumberTextBlock.Text = "";
        }
        #endregion
    }
}
