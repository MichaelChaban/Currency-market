   M S B A M L   `   `   `  ����D  @Test_Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Test_Task	Test_Task  5   	       Test_Task.Exchange   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Test_Task     5   	   -   5          � Title$  Exchange��5   	   $	��450��6   $	��800��6'   $��Center=�63   $��Center=�6P    � WindowStartupLocation$ CenterScreen=�6k    � WindowState$ Normal=�6�   .��5	      � .+�5
   
   �� -   5         ��Name$ convert��5
      $
��Left=�6#   $��280,136,0,0q�6>    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $��80��6   $��Right=�6�   6�   �� 5   
   -   5         ��Name$ conversionList��5      $
��Left=�6+   $��123,134,0,0q�6F   $	��Top=�6[   $	��120��6s   �� 5   
   -   5        $ conversionInList��5      $
��Left=�6-   $��620,135,0,0q�6H   $	��Top=�6]   $	��120��6u   �� 5   
   -   5         ��Name$ 	convertIn��5      $��_��6#   $
��Left=�6/   $��460,132,0,0q�6J   $	��Top=�6_   $	��155��6w   $��26��6�   $��Right=�6�   $��Center=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��170,199,170,115q�6P      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6i   	   CanUserReorderColumns$	 False��6y   
   CanUserResizeColumns$
 False��6�   �� 5   
   -   5        $ label��5      $��	Exchanges��6   $��Center=�63   $��0,53,0,0q�6P   $	��Top=�6b   $��20(�6z   �� 5   
   -   5        $ label1��5      $��N=��6    $
��Left=�6-   $��248,132,0,0q�6H   $	��Top=�6]   �� 5   
   -	   5         ��Name$ 
convertBtn��5      $��Convert��6%   $
��Left=�67   $��385,136,0,0q�6R   $	��Top=�6g   $��70��6   6�   c� 5   
   -
   5         c�Name$
 menu��5      $��Center=�6    $��29��6=   $	��Top=�6I   $��Center=�6a    J� SnapsToDevicePixels$
 True��6�   $��Hidden=�6�    � UseLayoutRounding$ False��6�   $��Hidden=�6�   $��Normal$�6   $��Arial Rounded MT Bold)�63  $��Center=�6V  $��LeftToRight=�6x  ���	#FFA1CDFF.@�5      �� -   5        $
 home��5      $
��Home��6#   
�������6E   5      5      5      