   M S B A M L   `   `   `  ����N  JClearableDatePicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:ClearableDatePicker;assembly=ClearableDatePickerClearableDatePicker  5      F BZAPC.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ZAPC.Client.ConvertersZAPC.Client.Converters 5      Q MZAPC.Client.Essentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089B   <ZAPC.Client.Converters.ValidationErrorTemplateWidthConverter    ValidationErrorTemplateWidth  ClearableDatePickerStyle  �� 
TargetType-   'ClearableDatePicker.ClearableDatePicker �� Property �� Value `� 	Converter �� Path �� RelativeSource(  "System.Windows.Controls.DatePicker �� Triggers P� Property P� Value  ValidationFailed	 �� Self
 ]� 
Conditions �� Property �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      VclearableDatePicker>clr-namespace:ClearableDatePicker;assembly=ClearableDatePicker  5      3
converters$clr-namespace:ZAPC.Client.Converters  5      S
essentialsDclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.Essentials  5      %�  &	        &	      7   7     5      67   �� 5      "   6-   .�5	   
   ��  � ��$ 28��6#   �� 5
   
    � ��$
 15,5q�6#   �� 5   
    � �� 5      `� 5      8   .1�5      �� $	 Tag�6    6)   �� *Self+�� 5      $! (essentials:Ex.CustomWidth)�6    6A   �� *Self+5      5      �� 5   
    �@ IsTodayHighlighted . 6/   �� 5   
    �@ SelectedDateFormat$ Short=�6/   �� 5   
    � ��$ Tahoma)�6'   �� 5   
    � ��$ 12(�6%   �� 5   
    � ��$ Regular"�6'   �� 5   
    �@=�ErrorTemplate 65   Z�  5   
   P� 5       �@=�HasError . . �5      ��  � ��$ 0q�64   �� 5       � �� �#E2574C6/   �� 5       �@=�ErrorTemplate8  6=   �� 5       �@^�	IsEnabled . 6=   �� 5       �@�ToolTip 6,   �� # Z	 $) #(Validation.Errors)[0].ErrorContent�5       ]� 5!      
 5"      �� 5#       �@ SelectedDate 68   Z� �� 5$       �@�Tag 6/   Z� /�5&      �� 5'       � ��$ 1q�68   �� 5(       �@=�ErrorTemplate 6A   Z� �� 5)       � ��
 �   �63   �� 5*       �@^�	IsEnabled .  6A   5,      5.      5/      