   M S B A M L   `   `   `  ���� K  GCoupon Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Coupon_GeneratorCoupon_Generator  &     Coupon_Generator.CouponSetupPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4:
wpftoolkit)http://schemas.xceed.com/wpf/xaml/toolkit  2couponControlclr-namespace:Coupon_Generator    N� Title$  Coupon Setup Page�� N� 
Background
 �����.��� 
�������$��20,20,20,20q� � RowDefinitions �� $��* ��� $
��Auto � � ColumnDefinitions �� $��* �.+���  �� Orientation$ Vertical=�$��0��.+��� $��24(�$��Coupon Settings���� .@��� $��
Background��.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�$��0,0,0,0q�.+��� $��Background Colour��$��Center=�#  Xceed.Wpf.Toolkit.ColorPicker  -     Name$! couponBackgroundColorPicker��$��20,0,0,0q�   SelectedColor$ Black���� $ 
Horizontal=�.+��� $��Background Image��$��Center=��� -    ��Name$ couponImage��$	��100��$��50��$��20,0,0,0q��� -   $��Select Image��$��20,0,0,0q�$	��100��$��25��$
��Left=�$��Center=��� -   $��Clear���� $��Border��.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�$��0,0,0,0q�.+��� $��Background Colour��$��Center=�  -   $! borderBackgroundColorPicker��$��20,0,0,0q�$ Black���� $ 
Horizontal=�$��0,10,0,0q�.+��� $��Border Thickness���� -    ��Name$ borderThicknessTextBox��$��2��$��50��$��20,0,0,0q��� $��Header��.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�.+�	� -   	 	�Name$	 headerEnabledRadioButton��$��0,0,0,0q�
 	� 	GroupName$
 HeaderEnable�� d� 	IsChecked$
 TrueY�.��	Enabled	� -   $	 headerDisabledRadioButton��$��20,0,0,0q�$
 HeaderEnable��.��
Disabled�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Header Text���� -	   $ headerTextBox��$�� ��$	��250��$��20,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $ Vertical=�.+��� $��Margin��]� $	��150��$
��Left=�$��0,0,0,0q�.+��� $ Vertical=�$	��Top=�.+��� $	��Top��$��Center=��� -
   $ headerMarginTextBlockTop��$��Center=�$��50���� $ Vertical=�$��Bottom=�.+��� $��Bottom��$��Center=��� -   $! headerMarginTextBlockBottom��$��Center=�$��50���� $ Vertical=�$
��Left=�.+��� $
��Left��$��Center=��� -   $ headerMarginTextBlockLeft��$��Center=�$��50���� $ Vertical=�$��Right=�.+��� $��Right��$��Center=��� -   $  headerMarginTextBlockRight��$��Center=�$��50���� $�� ���� $ Vertical=�$��20,0,0,0q�.+��� $��Horizontal Alignment���� -    ��Name$&  headerCurrentHorizontalAlignment��$��Center��$��Center=�]� .+��� -   $��Stretch��$��Bottom=��� -   $
��Left��$
��Left=��� -   $��Right��$��Right=��� -   $��Center���� $ Vertical=�$��20,0,0,0q�.+��� $��Vertical Alignment���� -   $$ headerCurrentVerticalAlignment��$��Bottom��$��Center=�]� .+��� -   $��Stretch��$��Right=��� -   $	��Top��$	��Top=��� -   $��Bottom��$��Bottom=��� -   $��Center���� $
��Body��.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�.+�	� -   $	 bodyEnabledRadioButton��$��0,0,0,0q�$
 
BodyEnable��$
 TrueY�.��	Enabled	� -   $	 bodyDisabledRadioButton��$��20,0,0,0q�$
 
BodyEnable��.��
Disabled�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��	Body Text���� -   $ bodyTextBox��$�� ��$	��250��$��20,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $ Vertical=�.+��� $��Margin��]� $	��150��$
��Left=�$��0,0,0,0q�.+��� $ Vertical=�$	��Top=�.+��� $	��Top��$��Center=��� -   $ bodyMarginTextBlockTop��$��Center=�$��50���� $ Vertical=�$��Bottom=�.+��� $��Bottom��$��Center=��� -   $ bodyMarginTextBlockBottom��$��Center=�$��50���� $ Vertical=�$
��Left=�.+��� $
��Left��$��Center=��� -   $ bodyMarginTextBlockLeft��$��Center=�$��50���� $ Vertical=�$��Right=�.+��� $��Right��$��Center=��� -   $ bodyMarginTextBlockRight��$��Center=�$��50���� $�� ���� $ Vertical=�$��20,0,0,0q�.+��� $��Horizontal Alignment���� -   $$ bodyCurrentHorizontalAlignment��$��Center��$��Center=�]� .+��� -    $��Stretch��$��Bottom=��� -!   $
��Left��$
��Left=��� -"   $��Right��$��Right=��� -#   $��Center���� $ Vertical=�$��20,0,0,0q�.+��� $��Vertical Alignment���� -$   $" bodyCurrentVerticalAlignment��$��Bottom��$��Center=�]� .+��� -%   $��Stretch��$��Right=��� -&   $	��Top��$	��Top=��� -'   $��Bottom��$��Bottom=��� -(   $��Center���� $��Expiry Date��.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�.+�	� -)   $"	 expiryDateEnabledRadioButton��$��0,0,0,0q�$
 ExpiryDateEnable��$
 TrueY�.��	Enabled	� -*   $#	 expiryDateDisabledRadioButton��$��20,0,0,0q�$
 ExpiryDateEnable��.��
Disabled�� $ 
Horizontal=�.+�	� -+   $"	 expiryDateDefaultRadioButton��$��0,0,0,0q�$
 ExpiryDateDisplay��$
 TrueY�.��	Default	� -,   $'	 !expiryDateAllUpperCaseRadioButton��$��24,0,0,0q�$
 ExpiryDateDisplay��.��Display as Uppercase	� --   $'	 !expiryDateAllLowerCaseRadioButton��$��20,0,0,0q�$
 ExpiryDateDisplay��.��Display as Lowercase�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Expiry Text���� -.   $ expiryTextBox��$	��200��$��34,0,0,0q��� $ 
Horizontal=�$��0,10,0,0q�.+��� $��Expirary Date��(  "System.Windows.Controls.DatePicker  -/     Name$ expiryDatePicker��   SelectedDateFormat$
 Long=�$	��250��$��20,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $ Vertical=�.+��� $��Margin��]� $	��150��$
��Left=�$��0,0,0,0q�.+��� $ Vertical=�$	��Top=�.+��� $	��Top��$��Center=��� -0   $" expiryDateMarginTextBlockTop��$��Center=�$��50���� $ Vertical=�$��Bottom=�.+��� $��Bottom��$��Center=��� -1   $% expiryDateMarginTextBlockBottom��$��Center=�$��50���� $ Vertical=�$
��Left=�.+��� $
��Left��$��Center=��� -2   $# expiryDateMarginTextBlockLeft��$��Center=�$��50���� $ Vertical=�$��Right=�.+��� $��Right��$��Center=��� -3   $$ expiryDateMarginTextBlockRight��$��Center=�$��50���� $�� ���� $ Vertical=�$��20,0,0,0q�.+��� $��Horizontal Alignment���� -4   $* $expiryDateCurrentHorizontalAlignment��$��Center��$��Center=�]� .+��� -5   $��Stretch��$��Bottom=��� -6   $
��Left��$
��Left=��� -7   $��Right��$��Right=��� -8   $��Center���� $ Vertical=�$��20,0,0,0q�.+��� $��Vertical Alignment���� -9   $( "expiryDateCurrentVerticalAlignment��$��Bottom��$��Center=�]� .+��� -:   $��Stretch��$��Right=��� -;   $	��Top��$	��Top=��� -<   $��Bottom��$��Bottom=��� -=   $��Center���� $��	Coupon ID��.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�.+�	� ->   $ 	 couponIDEnabledRadioButton��$��0,0,0,0q�$
 CouponIDEnable��$
 TrueY�.��	Enabled	� -?   $!	 couponIDDisabledRadioButton��$��20,0,0,0q�$
 CouponIDEnable��.��
Disabled�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Coupon ID Starting Number���� -@   $% couponIDStartingNumberTextBlock��$��1��$	��100��$��20,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $ Vertical=�.+��� $��Margin��]� $	��150��$
��Left=�$��0,0,0,0q�.+��� $ Vertical=�$	��Top=�.+��� $	��Top��$��Center=��� -A   $  couponIDMarginTextBlockTop��$��Center=�$��50���� $ Vertical=�$��Bottom=�.+��� $��Bottom��$��Center=��� -B   $# couponIDMarginTextBlockBottom��$��Center=�$��50���� $ Vertical=�$
��Left=�.+��� $
��Left��$��Center=��� -C   $! couponIDMarginTextBlockLeft��$��Center=�$��50���� $ Vertical=�$��Right=�.+��� $��Right��$��Center=��� -D   $" couponIDMarginTextBlockRight��$��Center=�$��50���� $�� ���� $ Vertical=�$��20,0,0,0q�.+��� $��Horizontal Alignment���� -E   $( "couponIDCurrentHorizontalAlignment��$��Center��$��Center=�]� .+��� -F   $��Stretch��$��Bottom=��� -G   $
��Left��$
��Left=��� -H   $��Right��$��Right=��� -I   $��Center���� $ Vertical=�$��20,0,0,0q�.+��� $��Vertical Alignment���� -J   $&  couponIDCurrentVerticalAlignment��$��Bottom��$��Center=�]� .+��� -K   $��Stretch��$��Right=��� -L   $	��Top��$	��Top=��� -M   $��Bottom��$��Bottom=��� -N   $��Center���� $��Generate��.��� .+��� $ Vertical=�.+��� $ 
Horizontal=�$��0,00,0,0q�.+��� $#��Number of Coupons to Generate���� -O   $0 *generateNumberOfCouponsToGenerateTextBlock��$��1��$	��100��$��20,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+�	� -P   $	 generate2x4RadioButton��$��0,0,0,0q�$
 GenerateSize��$
 TrueY�.���  �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� 
���   �$��2��$��50��$��25��$��0��$��0���� 
���   �$��2��$��50��$��25��$��1��$��0���� 
���   �$��2��$��50��$��25��$��0��$��1���� 
���   �$��2��$��50��$��25��$��1��$��1���� 
���   �$��2��$��50��$��25��$��0��$��2���� 
���   �$��2��$��50��$��25��$��1��$��2���� 
���   �$��2��$��50��$��25��$��0��$��3���� 
���   �$��2��$��50��$��25��$��1��$��3��	� -Q   $	 generate1x3RadioButton��$��20,0,0,0q�$
 GenerateSize��.���  �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� 
���   �$��2��$	��100��$��33��$��0��$��0���� 
���   �$��2��$	��100��$��33��$��0��$��1���� 
���   �$��2��$	��100��$��33��$��0��$��2���� -R    ��Name$ generateButton��$��Generate���� $ Vertical=�$��1��$��0,0,0,0q�.+��� $��24(�$��Preview��� $��0,20,0,0q�$	��400��$	��150�� �� $��* ��� $
��Auto ��� $��* �.+�   Coupon_Generator.Coupon  -S     Name$ previewCoupon��$��1��