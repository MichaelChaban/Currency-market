   M S B A M L   `   `   `  ����D  @Test_Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Test_Task	Test_Task  5   	       Test_Task.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Test_Task     5   	     � Title$
  Home��5   	   $	��450��6   $	��800��6#   $
��Left=�6/   $	��Top=�6Q   $��Center=�6p   $��Center=�6�    � UseLayoutRounding$ False��6�    � 
ResizeMode$ 	CanResize=�6�    � SizeToContent$ Manual=�6�    � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ Normal=�6  .��5	      � -   5         � ColumnDefinitions 5
   
   �� 5      .+�5   
   c� -   5         c�Name$
 menu��5      $��Center=�6    $��29��6=   $	��Top=�6I   $��Center=�6a    J� SnapsToDevicePixels$
 True��6�   $��Hidden=�6�   $ False��6�   $��Hidden=�6�   $��Normal$�6   $��Arial Rounded MT Bold)�63  $��Center=�6V  $��LeftToRight=�6x  ���	#FFA1CDFF.@�5      �� -   5        	 ��Name$	 exchange��5      $��Exchange��6'   
�������6M   5      �� 5   
   -   5        
 ��Name$
 searchInput��5       �� TextWrapping$
 Wrap=�6'   $��Center=�6;   ���	#FFABADB3$��0,69,0,0q�6�   $��Center=�6�   $	��Top=�6�   $	��400��6�   $��25��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	coinsList��5      $	��Top=�6Q   $��Center=�6�   $	��582��6�      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�      CanUserReorderColumns$ False��6�      
IsReadOnly$
 True��6  !   EnableColumnVirtualization$
 True��6      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6B  $��0,99,0,0q�6R     CanUserSortColumns$
 True��6d  ��6i   Z� ��6�   Z�    Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� $		 Btn��6%   -   5        $��Details��5   2   6D   5      5      5      5      5      