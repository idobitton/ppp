   M S B A M L   `   `   `  ����C  ?WpfApp50, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp50WpfApp50  5   	       WpfApp50.editShift   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp50     5   	   -   5          � Title$  	editShift��5   	   $	��800��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64    � WindowState$ 	Maximized=�6Y   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5       $
��100* �6   .+�5"   
   �� -   5         ��Name$ 
id_num_lbl��5"      $��
Id Number:��6$   $��	ExtraBold"�69   $��20(�6P   $��2��6^   $��2��6r   $��1��6   �� 5#   
   -   5         ��Name$ 
id_num_txb��5#      $��20(�6&   $��	ExtraBold"�64   $��2��6K   $��2��6_   $��3��6l    �� 
IsReadOnly . 6|   �� 5$   
   -   5        $ name_lbl��5$      $��Name:��6"   $��	ExtraBold"�62   $��20(�6I   $��2��6W   $��1��6k   $��1��6x   �� 5%   
   -   5        $ name_txb��5%      $��20(�6$   $��2��62   $��1��6F   $��3��6S    . $��	ExtraBold"�6u   �� 5&   
   -   5         ��Name$ sbmt_btn��5&      $��Submit��6#   $��20(�64   $��Italic$�6B   $��	ExtraBold"�6U   $��7��6l   $��8��6|   $��2��6�   6�   �� 5'   
   $��Select the shift:��6   $��	ExtraBold"�6,   $��20(�6C   $��3��6Q   $��2��6e   $��5��6r   �� 5(   
   -   5        $ time_lbl��5(      $��Time:��6"   $��	ExtraBold"�62   $��20(�6I   $��2��6W   $��3��6k   $��1��6x   �� 5)   
   $��Date:��6   $��	ExtraBold"�6!   $��20(�68   $��2��6F   $��5��6Z   $��1��6g   &   System.Windows.Controls.Calendar  5*   
   -   5        	  Name$	 calendar��5*      $��5��6%   $��2��62   $��3��6B   $��3��6V   $��	ExtraBold"�6g   $��20(�6~   	� 5+   
   -	   5        
 	�Name$
 
mornng_rdb��5+      $��Morning��6*   $��	ExtraBold"�6<   $��20(�6S   $��2��6a   $��3��6u   $��3��6�   	� 5,   
   -
   5        $
 	evnng_rdb��5,      $��Evening��6)   $��	ExtraBold"�6;   $��20(�6R   $��2��6`   $��4��6t   $��3��6�   �� 5-   
   -   5        $ dlt_lbl��5-      $��Delete?��6!   $��	ExtraBold"�63   $��20(�6J   $��7��6X   $��5��6e   �� 5.   
   -   5         ��Name$	 lsb��5.      $��7��6   $��6��6,   $��2��6<   $��20(�6M   $��	ExtraBold"�6[   .@�5/      �� -   5         ��Name$ yes_lsb��5/      $	��Yes��6+   �� 50      -   5        $ no_lsb��50      $��No��6*   51      &   System.Windows.Controls.DataGrid  52   
   -   5          Name$ shift_dtgrid��52      
���   �
���  ��
���  ��$��3��6_   $��5��6l   $��3��6|   $��4��6�   $��20(�6�   $��	ExtraBold"�6�   6�     53   
   -   5        $ 
emp_dtgrid��53      
���   �
���  ��
���  ��$��3��6]   $��8��6j   $��2��6z   $��4��6�   $��20(�6�   $��	ExtraBold"�6�   6�   �� 54   
   -   5        $ msg_lsb��54      
���   �
���  ��
���  ��$��9��6Y   $��0��6f   $��10��6v   $��20(�6�   $��	ExtraBold"�6�   55      56      