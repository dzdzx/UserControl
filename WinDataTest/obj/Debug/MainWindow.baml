   M S B A M L   `   `   `  ����F  BWinDataTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WinDataTestWinDataTest  5   	   A =AGauge, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:AGauge;assembly=AGaugeAGauge 5
   	   C ?MyAgaue2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:MyAgaue2;assembly=MyAgaue2MyAgaue2 5   	   C ?MyGauge3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:MyGauge3;assembly=MyGauge3MyGauge3 5   	       WinDataTest.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WinDataTest     5   	   6gauge$clr-namespace:AGauge;assembly=AGauge     5
   	   ;gauge2(clr-namespace:MyAgaue2;assembly=MyAgaue2     5   	   ;gauge3(clr-namespace:MyGauge3;assembly=MyGauge3     5   	   -   5          �Name$  userInformation��5	   	    � Title$ 
MainWindow��5   	   $
��1200��6   $
��1200��6*   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
     MyAgaue2.GaugeControl  -   5          Name$	 one��5      $	��300��6+   $	��300��67      MaxValue$	 100Q�6D      MajorTickCount$ 10��6S      MinValue$ 0Q�6g      ScaleMargin$ 15Q�6t      PointerL$	 0.9Q�6�   	   ScaleLabelMargin$	 35Q�6�   $��0��6�   $��0��6�   
   Value
 6�   ��  �� Path$ Value�   MajorTickMarkColor 5      �� 5      .��5      �  � Color$ 	Gainsboro��6#    � Offset$ 0.462Q�65   6F   � 5      $ Silver��6#   $ 0.552Q�62   6C   5         MinorTickMarkColor 5      �� 5      .��5      � $ 	#FFF1DFDF��6#   $ 0.832Q�65   � 5      $ 	#FF301F1F��6#   5         ValueLabelStyle 5      �� 5        �� 
TargetType" ��6   .�5!      ��  �� Property � �� �� Value
 �����6C   �� 5"       � ��$
 18px(�61   6@   5#         TickLabelStyle 5%      �� 5&      " ��6   .�5'      ��  � ��
 ��  �6B   5(      5*        5+   
   -   5        $	 two��5+      $	��200��6+   $	��200��67   $	 200Q�6D   $ 10��6S   $ 0Q�6g   $ 15Q�6t   $	 0.9Q�6�   $	 35Q�6�   $��0��6�   $��1��6�   
 6�   �� $ Value� 5,      �� 5-      .��5.      � $ 	Gainsboro��6#   $ 0.462Q�65   6F   � 5/      $ Silver��6#   $ 0.552Q�62   6C   50       52      �� 53      .��54      � $ 	#FFF1DFDF��6#   $ 0.832Q�65   � 55      $ 	#FF301F1F��6#   56       58      �� 59      " ��6   .�5:      ��  � ��
 �����6C   �� 5;       � ��$
 18px(�61   6@   5<       5>      �� 5?      " ��6   .�5@      ��  � ��
 ��� �6F   �� 5A       � ��$ 10(�61   6>   5B      5D      5E      5F      