   M S B A M L   `   `   `  ����C  ?WpfApp50, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp50WpfApp50  5   	       WpfApp50.checkSupplier   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp50     5   	   -   5          � Title$  checkSupplier��5   	   $	��500��6    $	��500��6-    � WindowStartupLocation$ CenterScreen=�69    � WindowState$ 	Maximized=�6u   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $	��50* �6   �� 5      $	��50* �6   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   .+�5!   
   �� -   5         ��Name$ supplier_name_lbl��5!      $��Supplier name: ��6+   $��20(�6E   $��	ExtraBold"�6S   $��0��6j   $��1��6z   $��4��6�   �� 5"   
   -   5        $ 	notes_lbl��5"      $��Notes: ��6#   $��20(�65   $��	ExtraBold"�6C   $��3��6Z   $��7��6j   $��5��6w   �� 5#   
   -   5        $ payment_name_lbl��5#      $��The payment: ��6*   $��20(�6B   $��	ExtraBold"�6P   $��0��6g   $��8��6w   $��3��6�   �� 5$   
   -   5        $ 	dscnt_lbl��5$      $��	Discount:��6#   $��20(�67   $��	ExtraBold"�6E   $��0��6\   $��9��6l   $��2��6y   �� 5%   
   -   5        $ 	gdbye_lbl��5%      $(��"Goodbye! Have a nice day!☺☺☺��6#   $��20(�6J   $��	ExtraBold"�6X   $��1��6o   $��10��6   $��6��6�   &   System.Windows.Controls.DataGrid  5&   
   -   5          Name$ fprice_dtgrid��5&      $��3��6*   $��0��67   $��3��6G   $��5��6[   $��20(�6l   $��	ExtraBold"�6z     5'   
   -   5        $ order_details_dtgrid��5'      $��1��61   $��4��6>   $��2��6N   $��6��6b   $��20(�6s   $��	ExtraBold"�6�     5(   
   -	   5        $ products_dtgrid��5(      $��1��6,   $��6��69   $��2��6I   $��6��6]   $��20(�6n   $��	ExtraBold"�6|   �� 5)   
   -
   5         ��Name$ payment_btn��5)      $��Payment��6&   $��20(�68   $��	ExtraBold"�6F   $��3��6]   $��8��6m   $��2��6z   6�   5*      5+      