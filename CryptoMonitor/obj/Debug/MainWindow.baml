   M S B A M L   `   `   `  ����H  DCryptoMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CryptoMonitorCryptoMonitor  5   	       CryptoMonitor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CryptoMonitor     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��750��6)    � DataContext 65   �� *Main+ �� Mode$ OneWay=�   Locator �� Source# [  .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��250* �6   �� 5      $
��250* �6   �� 5      $
��250* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   .+�5      �� $��Watt Verbrauch��6   $��Center=�6-   $
��Bold"�6Q   $��0 0 0 10q�6c   �� 5      $ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $	��GPU��6   $��80��6*   �� 5      $��Center=�6   $��Center=�6B   $��70��6}   ��6d   �� *	Gpuwatt+6}   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��CPU��6   $��80��6*   �� 5      $��Center=�6   $��Center=�6B    �� TextWrapping$
 Wrap=�6d   $��70��6�   ��6x   �� *	Cpuwatt+6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Festplatten��6   $��80��62   �� 5      $��Center=�6   $��Center=�6B   $
 Wrap=�6d   $��70��6�   ��6x   �� *Festplattenwatt+6�   5      �� 5      $ 
Horizontal=�6   .+�5       �� $	��RAM��6   $��80��6*   �� 5!      $��Center=�6   $��Center=�6B   $
 Wrap=�6d   $��70��6�   ��6x   �� *	Ramwatt+6�   5"      �� 5#      $ 
Horizontal=�6   .+�5$      �� $��Lüfter��6   $��80��6-   �� 5%      $��Center=�6   $��Center=�6B   $
 Wrap=�6d   $��70��6�   ��6x   �� *Luefterwatt+6�   5&      �� 5'      $ 
Horizontal=�6   .+�5(      �� $��
Monitor(e)��6   $��80��61   �� 5)      $��Center=�6   $��Center=�6B   $
 Wrap=�6d   $��70��6�   ��6x   �� *Monitorwatt+6�   5*      �� 5+      $ 
Horizontal=�6   $��0 5 0 0q�66   .+�5,      �� $��	PC Total:��6   $��80��60   $
��Bold"�6;   �� 5-      $��Center=�6   $��Center=�6@   $��70��6�   $
��Bold"�6�   ��6b   �� *TotalWattShow+6�   5.      5/      50      �� 52   
   $ Vertical=�6   $��1��6,   .+�53      �� $��PROFIT��6   $��Center=�6%   $��Center=�6I   $��20(�6k   �� 55      $ Vertical=�6   .+�56      �� $	��Tag��6   $��Center=�6&   $
��Bold"�6C   $��16(�6U   �� 57      $ 
Horizontal=�6   .+�58      �� $ Vertical=�6!   $��83��68   .+�59      �� $��Profit��6    $��Center=�61   $
��Bold"�6U   �� 5:      $��Center=�6T   ��6    �� *!SelectedCrypto.ProfitPerDayShow+6T   5;      �� 5<      $ Vertical=�6!   $��83��68   .+�5=      �� $��Mined��6    $��Center=�60   $
��Bold"�6T   �� 5>      $��Center=�6S   ��6    �� * SelectedCrypto.MinedPerDayShow+6S   5?      �� 5@      $ Vertical=�6!   $��83��68   .+�5A      �� $��Stromkosten��6    $��Center=�66   $
��Bold"�6Z   �� 5B      $��Center=�6W   ��6    �� *$"SelectedCrypto.PowerCostPerDayShow+6W   5C      5D      5E      �� 5G      $ Vertical=�6   .+�5H      �� $��Monat��6   $��Center=�6(   $
��Bold"�6E   $��16(�6W   �� 5I      $ 
Horizontal=�6   .+�5J      �� $ Vertical=�6!   $��83��68   .+�5K      �� $��Profit��6    $��Center=�61   $
��Bold"�6U   �� 5L      $��Center=�6V   ��6    �� *#!SelectedCrypto.ProfitPerMonthShow+6V   5M      �� 5N      $ Vertical=�6!   $��83��68   .+�5O      �� $��Mined��6    $��Center=�60   $
��Bold"�6T   �� 5P      $��Center=�6U   ��6    �� *" SelectedCrypto.MinedPerMonthShow+6U   5Q      �� 5R      $ Vertical=�6!   $��83��68   .+�5S      �� $��Stromkosten��6    $��Center=�66   $
��Bold"�6Z   �� 5T      $��Center=�6Y   ��6    �� *&$SelectedCrypto.PowerCostPerMonthShow+6Y   5U      5V      5W      �� 5Y      $ Vertical=�6   .+�5Z      �� $
��Jahr��6   $��Center=�6'   $
��Bold"�6D   $��16(�6V   �� 5[      $ 
Horizontal=�6   .+�5\      �� $ Vertical=�6!   $��83��68   .+�5]      �� $��Profit��6    $��Center=�61   $
��Bold"�6U   �� 5^      $��Center=�6b   ��6    �� *" SelectedCrypto.ProfitPerYearShow+$ TwoWay=�6b   5_      �� 5`      $ Vertical=�6!   $��83��68   .+�5a      �� $��Mined��6    $��Center=�60   $
��Bold"�6T   �� 5b      $��Center=�6T   ��6    �� *!SelectedCrypto.MinedPerYearShow+6T   5c      �� 5d      $ Vertical=�6!   $��83��68   .+�5e      �� $��Stromkosten��6    $��Center=�66   $
��Bold"�6Z   �� 5f      $��Center=�6X   ��6    �� *%#SelectedCrypto.PowerCostPerYearShow+6X   5g      5h      5i      5k      �� 5m   
   $ Vertical=�6   $��2��6,   .+�5n      �� $ ��Zusätzliche Informationen��6   $��Center=�69   $
��Bold"�6]   $��0 0 0 10q�6o   �� 5p      $ Vertical=�6   $��Right=�60   $��0 0 5 0q�6L   .+�5q      �� $ 
Horizontal=�6   .+�5r      �� $��Center=�6   $��Center=�6B   $��70��6�   ��6d   �� *Stromkosten+6�   �� 5s      $��Stromkosten (c/kWh)��6   $	��125��6:   5t      �� 5u      $ 
Horizontal=�6   .+�5v      �� $��Center=�6   $��Center=�6B   $��70��6}   ��6d   �� *	Poolfee+6}   �� 5w      $��Poolgebühr (%)��6   $	��125��65   5x      �� 5y      $ 
Horizontal=�6   .+�5z      �� $��Center=�6   $��Center=�6B   $��70��6}   ��6d   �� *	Gpuhash+6}   �� 5{      $��GPU Hashrate (MH/s)��6   $	��125��6:   5|      �� 5~      $��0 10 0 0q�6>   ��6   �� *
ListCrypto+ �� SelectedItem 6P   �� *SelectedCrypto+$ TwoWay=���5      �� 5�      .R�5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��Center=�6B   $��Center=�6f   $��70��6�   ��6(   �� *Price+6�   �� 5�   "   ��6(   �� *
NameKurz+�� 5�   "   $��Preis (€)��6(   5�      5�      5�      5�      5�      5�      5�      