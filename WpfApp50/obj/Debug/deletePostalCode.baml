   M S B A M L   `   `   `  ����C  ?WpfApp50, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp50WpfApp50  5   	       WpfApp50.deletePostalCode   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp50     5   	   -   5          � Title$  deletePostalCode��5   	   $	��500��6"   $	��500��6/    � WindowStartupLocation$ CenterScreen=�6;    � WindowState$ 	Maximized=�6`   .��5	      � -   5         �Name$	 grd��5	       � RowDefinitions 5
   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   .+�5   
   �� $5��/Select the postal code that you want to delete:��6   $��20(�6J   $��	ExtraBold"�6X   $��5��6o   �� 5   
   -   5         ��Name$ dlt_pc��5      $��Delete this postal code��6!   $��20(�6C   $��	ExtraBold"�6Q   $��1��6h   $��3��6x   $��3��6�   $��Italic$�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	pc_dtgrid��5      $��1��6&   $��1��63   $��3��6C   $��2��6W   $��20(�6�   $��	ExtraBold"�6�   5      5      