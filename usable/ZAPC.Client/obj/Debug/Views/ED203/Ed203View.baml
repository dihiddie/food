   M S B A M L   `   `   `  ����Q  MZAPC.Client.Essentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqMclr-namespace:ZAPC.Client.Essentials.Bindings;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials.Bindings  5      N JClearableDatePicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:ClearableDatePicker;assembly=ClearableDatePickerClearableDatePicker 5      uOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials!ZAPC.Client.Essentials.Converters  5      _Dclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials  5	      F BZAPC.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ZAPC.Client.ResourcesZAPC.Client.Resources 5      ?$clr-namespace:ZAPC.Client.ViewModelsZAPC.Client.ViewModels 5      '   !ZAPC.Client.Views.ED203.Ed203View   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      bbindingsMclr-namespace:ZAPC.Client.Essentials.Bindings;assembly=ZAPC.Client.Essentials     5      ^clearableDatePicker>clr-namespace:ClearableDatePicker;assembly=ClearableDatePicker     5      f
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
��Auto �6    
 � ColumnDefinitions
 59      �� 5:      $	��250 �6#   �� 5;      $��* �6#   .+�5=      �� $��0��5>      $��2��5?      $��15,10q�5@      $��17(�5A      !Общая информация5C      �� 5D      $��1��6   $��0��6%   1/Идентификатор получателя5F      �� 5G      $��1��5H      $��1��5I      {�5J      �� $ 	IsEnabled���5K      3   -ZAPC.Client.Essentials.Bindings.CustomBinding  :   4ZAPC.Client.Essentials.Bindings.BindingDecoratorBase   Path$ Model.EdReceiver��� 5L      $��2��6   $��0��6%   Номер счета5N      �� 5O      $��2��5P      $��1��5Q      {�5R      �� $ 	IsEnabled���5S        $ 	Model.Acc��� 5T      $��3��6   $��0��6%   Код запроса *5V      �� 5W      $��3��5X      $��1��5Y      {�5Z      �� $ 	IsEnabled���5[      �� *Model.GroupInquiryCodes+ �� SelectedItem 5\        $( "Model.GroupInquiryCodeSelectedItem�   Mode$ TwoWay=�   UpdateSourceTrigger$ PropertyChanged=�5_      � 5`   
   $��1��6   $��0,0,0,15q�6   	 5a      �� 5b      $
��Auto �6    �� 5c      $
��Auto �6    �� 5d      $
��Auto �6    �� 5e      $
��Auto �6    �� 5f      $
��Auto �6    
 5h      �� 5i      $	��250 �6#   �� 5j      $��* �6#   .+�5l      �� $��0��5m      $��2��5n      $��15,10q�5o      $��17(�5p      VTШаблон запроса встречных ЭПС в режиме МОП (О_О)5r      �� 5s      $��1��6   $��0��6%   *(БИК банка плательщика5u      �� 5v      $��1��5w      $��1��5x      {�5y      �� $ 	IsEnabled���5z        $  Model.EdQueryMask.PayerBic��� 5{      $��2��6   $��0��6%   !Счет плательщика5}      �� 5~      $��2��5      $��1��5�      {�5�      �� $ 	IsEnabled���5�        $( "Model.EdQueryMask.PayerPersonalAcc��� 5�      $��3��6   $��0��6%   Сумма платежа5�      �� 5�      $��3��5�      $��1��5�      {�5�      �� $ 	IsEnabled���5�        $ Model.EdQueryMask.Sum��� 5�      $��4��6   $��0��6%   Счет получателя5�      �� 5�      $��4��5�      $��1��5�      {�5�      �� $ 	IsEnabled���5�        $( "Model.EdQueryMask.PayeePersonalAcc�5�      �� 5�   
   $��2��5�      $
��-1,0q�5�      $	��Top=�5�      ���#D6E0E55�      �� 5�   
   $��2��5�      $��10q�5�      $��Right=�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� +  %ZAPC.Client.Resources.SharedResources   CreateCaption#��Z 5�      ��5�      �� *SaveDocumentCommand+y�5�      ��  �� ElementName$ 
ChargeFile��$ DataContext.IsEnabled� �� 	Converter# [ �� 5�         CancelCaption#��Z 5�       � DataContext# [  5�      ��5�      �� *#!CloseWithDialogResultFalseCommand+��5�      ��  �� RelativeSource ��  �� AncestorType" �5�      5�      5�      5�      