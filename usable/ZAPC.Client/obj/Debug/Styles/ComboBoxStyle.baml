   M S B A M L   `   `   `  ����F  BZAPC.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ZAPC.Client.ConvertersZAPC.Client.Converters  5      Q MZAPC.Client.Essentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBoxNormalBorderBrush  �� Color ! ComboBoxNormalBackgroundBrush # ComboBoxDisabledForegroundBrush # ComboBoxDisabledBackgroundBrush  ComboBoxDisabledBorderBrushB    <ZAPC.Client.Converters.ValidationErrorTemplateWidthConverter   ValidationErrorTemplateWidth   ComboBoxToggleButtonTemplate �� 
TargetType � ColumnDefinitions �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value  ComboBoxStyle
 �� 
TargetType `� 	Converter �� Path �� RelativeSource �� 	ClickMode d� 	IsChecked �� Mode �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible �� 
IsReadOnly �� 
IsReadOnly � AllowsTransparency �� IsDropDownOpen � ActualWidth �� MaxDropDownHeight J� SnapsToDevicePixels-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers  ValidationFailed �� Self ]� 
Conditions �� Property  �� Value! :� RoutedEvent" �� TargetProperty# R� KeyTime$ R� Value% �� AncestorType& ��Name' �� Padding�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      3
converters$clr-namespace:ZAPC.Client.Converters  5      S
essentialsDclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.Essentials  5      %�  &	        &	 !     &	 ?     &	 ]     &	 {     &	 �     &	 �     7  7   7  7  7  7  7  &	 "    7  7  7   7  7  '�� �    �� 5      $  #707070��68   �� 5      $
  #fff��6<   �� 5	      $
  #888��6>   �� 5
      $
  #eee��6>   �� 5      $
  #888��6:      5      67   �� 5      " d�6;   .R�5   
   �  5      �� 5      �� 5      $��20 �6#   .+�5      �� $��Border��5      $��2��5      8��  8�� #��z��5      $ 0��5      �� 5      $��ButtonBorder��5      $��1��5      $��1,1,1,1q�5      8�� ���#444$��0,0,0,0q�5       $ 
0, 0, 0, 0��5!      F� 5#      $��Arrow��5$      $��1��5%      $��Center=�5&      $��Center=�5'      =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	���#4445)      5*       5+   
   P� 5,       �@J�IsMouseOver . . �5-      �� $ ButtonBorder��6    � ��
	 �����6O   5.      P� 5/       �@d�	IsChecked$
 TrueY�68   . �50      �� $ ButtonBorder��6    � ��
	 �����6O   �� 51      $ Arrow��6    � ��	 �	#FF8D979E6B   52      P� 53       � {� .  . �54      �� $ Border��6   8	   � ��6I   �� 55      $ ButtonBorder��6   8	   � ��6O   �� 56      $ ButtonBorder��6   8	   � ��6Q   �� 57      8	   � ��6;   �� 58      $ Arrow��6    � ��	 �#9996B   59      5;      �� 5=      "
 ��6"   .�5>   
   ��  � ��	 5?      `� 5@      8   .1�5A      �� $	 Tag�6    6)   �� *Self+�� 5B      $! (essentials:Ex.CustomWidth)�6    6A   �� *Self+5C      5E      �� 5F   
    � ��$	 28��6#   �� 5G   
    � ��$	 Tahoma)�6'   �� 5H   
    � ��$
	 15,5q�6#   �� 5I   
    � ��$
	 Left=�60   �� 5J   
    � ��$	 11(�6%   �� 5K   
    � ��$	 1q�6,   �� 5L   
    � ��$	 Regular"�6'   �� 5M   
    �@J�SnapsToDevicePixels	 . 60   �� 5N   
    �@�OverridesDefaultStyle	 . 62   �� 5O   
    � ��$
	 Auto=�6G   �� 5P   
    � ��$
	 Auto=�6E   �� 5Q   
    � ��	 . 6:   �� 5R   
    � ��
	 �   �63   �� 5S   
    �@�FocusVisualStyle	 6-   Z� �� 5T   
    � ��	 5U      �� 5V      " ��6"   .R�5W      � .+�5X      d� $��ToggleButton��5Y      #��z��5Z      $ Press=�5[      |�.  8��  5]      �� $ IsDropDownOpen� �� *TemplatedParent+$ TwoWay=�5^      �� 5`      $��ContentSite��5a      $��
-10,3,23,3q�5b      $
��Left=�5c      $��Center=�5d      #��z 5e      #��z 5f      #��z��5g       .  5h      �� 5i      $��PART_EditableTextBox��5j      $��3,3,23,3q�5k      $
��Left=�5l      $��Center=�5m      
������ |�. # z 5p      $y�Hidden=�5q      .��61   ��5r      �� 5s   "   " ��62   .R�5t   &   �� $��PART_ContentHost��6-   |�.  6E   5u   #   .��5v   0   5w      � 5y      $��Popup��5z       . |�.  #��z 5}      $��Bottom=�5~      $��Slide=�5      .��5�      � $��DropDown��5�   !   #��z 5�   !   #��z 5�   !    . .+�5�   "   �� $��DropDownBorder��5�   %   $��0,1,0,0q�5�   %   
�������8�� $��1,1,1,1q�5�   %   $ 0��5�   %   �� 5�   "   $��4q�6/    . .��5�   &   �� $ 	Contained=�65   5�   #   5�      5�      5�       5�      P� 5�       �@��HasItems .  . �5�      �� $ DropDownBorder��6%    � ��$	 95��6g   5�      P� 5�       � {� .  . �5�      �� 8	   � ��6G   5�      P� 5�       �@��
IsGrouping . . �5�      ��  � ��	 .  6N   5�      P� 5�       �@��
IsEditable . . �5�      ��  �@ 	IsTabStop	 .  6M   �� 5�      $ PART_EditableTextBox��6%    � y�$	 Visible=�6g   �� 5�      $ ContentSite��6%    � y�$	 Hidden=�6^   5�      5�      5�       5�   
   P� 5�       �@=�HasError . . �5�      ��  � ��$	 0q�64   �� 5�       �@=�ErrorTemplate8	  6=   �� 5�       �@^�	IsEnabled	 . 6=   �� 5�       �@�ToolTip	 6,   �� # Z $) #(Validation.Errors)[0].ErrorContent�5�      ]� 5�       5�      �� 5�       �@��SelectedItem  68   Z� �� 5�       �@�Tag  6/   Z� /�5�      �� 5�       � ��$	 1q�68   �� 5�       �@=�ErrorTemplate	 6A   Z� �� 5�       � ��
	 �   �63   �� 5�       �@^�	IsEnabled	 .  6A   5�      :� 5�      $! SelectionChanged��6   [�5�      �� 5�      .��5�      �� .��5�      T� $	" Tag�6<   ..�5�   "   i� $# 0��69   $ 6E   Z� 5�      5�      5�      5�      5�      �� 5�      "
 ��6   .�5�   
   ��  � ��	 67   �� *HorizontalContentAlignment+ �� "% ���� 5�   
    � ��	 65   �� *VerticalContentAlignment+ �� "% ���� 5�   
    � ��$	 3,0,3,0q�6$   �� 5�   
    � ��
	 ���� 6'   �� 5�   
    � ��	 5�      �� 5�      " ��6"   .R�5�      �� $& Bd��5�      #' z��5�      #��z��5�      #��z��5�      #��z��5�       . ._�5�      �� $��	-14,0,0,0q�5�      #��z��5�      #��z��5�      # z 5�      5�       5�      P� 5�       �@��IsHighlighted . . �5�      �� $ Bd��6%   #	 � ��6K    � ���� 5�      #	 � ��6;    � ��5�      P� 5�       � {� .  . �5�      �� #	 � ��6;    � ��5�      5�      5�      5�      5�      