   M S B A M L   `   `   `  ����C  ?WpfApp50, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp50WpfApp50  5   	       WpfApp50.allOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp50     5   	   -   5          � Title$  	allWindow��5   	   $
��1000��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�6M    � WindowState$ 	Maximized=�6r   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ordr_dtgrid��5      $��20(�6(   $��	ExtraBold"�66   $��2��6M     5   
   -   5        $ price_dtgrid��5      $��2��6)   $��20(�69   $��	ExtraBold"�6G     5   
   -   5        $ expense_dtgrid��5      $��3��6+   $��20(�6;   $��	ExtraBold"�6I     5   
   -   5        $ 
emp_dtgrid��5      $��1��6'   $��20(�64   $��	ExtraBold"�6B     5   
   -   5        $ c_or_s_dtgrid��5      $��1��6*   $��1��67   $��20(�6G   $��	ExtraBold"�6U     5   
   -   5        $ client_dtgrid��5      $��1��6*   $��2��67   $��20(�6G   $��	ExtraBold"�6U   �� 5   
   -   5         ��Name$ 	ac_bc_lbl��5      $��Account balance:��6#   $��20(�6>   $��	ExtraBold"�6L   $��4��6c   $��1��6s   5      5      