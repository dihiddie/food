   M S B A M L   `   `   `  ����Q  MZAPC.Client.Essentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqMclr-namespace:ZAPC.Client.Essentials.Bindings;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials.Bindings  5      N JClearableDatePicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:ClearableDatePicker;assembly=ClearableDatePickerClearableDatePicker 5      uOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials!ZAPC.Client.Essentials.Converters  5      _Dclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials  5	      F BZAPC.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ZAPC.Client.ResourcesZAPC.Client.Resources 5      ?$clr-namespace:ZAPC.Client.ViewModelsZAPC.Client.ViewModels 5      '   !ZAPC.Client.Views.ED301.Ed301View   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      bbindingsMclr-namespace:ZAPC.Client.Essentials.Bindings;assembly=ZAPC.Client.Essentials     5      ^clearableDatePicker>clr-namespace:ClearableDatePicker;assembly=ClearableDatePicker     5      f
convertersOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      [
essentialsDclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.Essentials     5	      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5
      9	resources#clr-namespace:ZAPC.Client.Resources     5      ;
viewModels$clr-namespace:ZAPC.Client.ViewModels     5      $	��700��5      $	��465��5        � 
ResizeMode$  NoResize=�5       � 	Resources 5      -  'ZAPC.Client.ViewModels.ControlViewModel   ControlViewModel  	BoolToVis6   0ZAPC.Client.Essentials.Converters.TitleConverter  TitleConverter  DefaultTextBoxStyle �� BasedOn �� 
TargetType   ZAPC.Client.Essentials.Ex �� Property �� Value  ClearableDatePickerStyle-  'ClearableDatePicker.ClearableDatePicker  ComboBoxStyle  DefaultTextBlockStyle��%�  &	        &	      &	 &     '�� 9     7  '  �     7  '�� �     7  '�� G    7    5   
   6&   �� 5   
   6'     5   
   6$   �� 5   
   8   " ��6?   .�5      ��  �@ CustomWidth$	 404Q�6:   5      �� 5   
   8   "  6D   .�5      ��  �@ CustomWidth$	 200Q�6:   5      �� 5   
   8   " ��69   .�5      ��  �@ CustomWidth$	 404Q�6:   5      �� 5   
   8   " ��6A   5       � Title 5       `� 5!   
    `� 	Converter# [ 6   .1�5"      ��  �� Path$ FileName�6   �� 5#      $ TextDescriptionOfMode�6   5$      .��5&      � 	 � RowDefinitions	 5'   
   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   .+�5-   
   �� $��0��5.      $
��-1,0q�5/      $	��Top=�50      ���#D6E0E551      � 52   
   $��0��6   $��0,0,0,5q�6   	 53      �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    
 � ColumnDefinitions
 5:      �� 5;      $	��250 �6#   �� 5<      $��* �6#   .+�5>      �� $��0��5?      $��2��5@      $��15,10q�5A      $��17(�5B      !Общая информация5D      �� 5E      $��1��6   $��0��6%   1/Идентификатор получателя5G      �� 5H      $��1��5I      $��1��5J      {�5K      �� $ 	IsEnabled���5L      3   -ZAPC.Client.Essentials.Bindings.CustomBinding  :   4ZAPC.Client.Essentials.Bindings.BindingDecoratorBase   Path$ Model.EdReceiver��� 5M      $��2��6   $��0��6%   БИК ПУР *5O      �� 5P      $��2��5Q      $��1��5R      {�5S      �� $ 	IsEnabled���5T        $ 	Model.Bic��� 5U      $��3��6   $��0��6%   Сумма операции *5W      �� 5X      $��3��5Y      $��1��5Z      {�5[      �� $ 	IsEnabled���5\        $ 	Model.Sum��� 5]      $��4��6   $��0��6%   Код операции *5_      �� 5`      $��4��5a      $��1��5b      {�5c      �� $ 	IsEnabled���5d      �� *Model.LiquidityTransKinds+ �� SelectedItem 5e        $* $Model.LiquidityTransKindSelectedItem�   Mode$ TwoWay=�   UpdateSourceTrigger$ PropertyChanged=�5h      � 5i   
   $��1��6   $��0,0,0,15q�6   	 5j      �� 5k      $��* �6    �� 5l      $��* �6    �� 5m      $��* �6    �� 5n      $��* �6    
 5p      �� 5q      $	��250 �6#   �� 5r      $��* �6#   .+�5t      �� $��0��5u      $��2��5v      $��15,10q�5w      $��17(�5x      64Идентификаторы исходного ЭС5z      �� 5{      $��1��6   $��0��6%   53Номер ЭС в течение опердня **5}      �� 5~      $��1��5      $��1��5�      {�5�      �� $ 	IsEnabled���5�        $ Model.EdRefId.EdNo��� 5�      $��2��6   $��0��6%   $"Дата составления **5�        5�      $��2��5�      $��1��5�      $
��Left=�5�      {�5�      �� $ 	IsEnabled�(  "System.Windows.Controls.DatePicker   SelectedDate 5�        $ Model.EdRefId.EdDate��� 5�      $��3��6   $��0��6%   64Идентификатор составителя **5�      �� 5�      $��3��5�      $��1��5�      {�5�      �� $ 	IsEnabled���5�        $ Model.EdRefId.EdAuthor�5�      �� 5�   
   $��2��5�      $
��-1,0q�5�      $	��Top=�5�      ���#D6E0E55�      �� 5�   
   $��2��5�      $��10q�5�      $��Right=�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� +  %ZAPC.Client.Resources.SharedResources   CreateCaption#��Z 5�      ��5�      �� *SaveDocumentCommand+y�5�      ��  �� ElementName$ 
ChargeFile��$ DataContext.IsEnabled� �� 	Converter# [ �� 5�         CancelCaption#��Z 5�       � DataContext# [  5�      ��5�      �� *#!CloseWithDialogResultFalseCommand+��5�      ��  �� RelativeSource ��  �� AncestorType" �5�      5�      5�      5�      