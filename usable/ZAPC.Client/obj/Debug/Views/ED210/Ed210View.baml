   M S B A M L   `   `   `  ����Q  MZAPC.Client.Essentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqMclr-namespace:ZAPC.Client.Essentials.Bindings;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials.Bindings  5      N JClearableDatePicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:ClearableDatePicker;assembly=ClearableDatePickerClearableDatePicker 5      uOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials!ZAPC.Client.Essentials.Converters  5      _Dclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials  5	      F BZAPC.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ZAPC.Client.ResourcesZAPC.Client.Resources 5      ?$clr-namespace:ZAPC.Client.ViewModelsZAPC.Client.ViewModels 5      '   !ZAPC.Client.Views.ED210.Ed210View   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      bbindingsMclr-namespace:ZAPC.Client.Essentials.Bindings;assembly=ZAPC.Client.Essentials     5      ^clearableDatePicker>clr-namespace:ClearableDatePicker;assembly=ClearableDatePicker     5      f
convertersOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      [
essentialsDclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.Essentials     5	      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5
      9	resources#clr-namespace:ZAPC.Client.Resources     5      ;
viewModels$clr-namespace:ZAPC.Client.ViewModels     5      $	��700��5      $	��445��5        � 
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
��Auto �6   .+�5,   
   �� $��0��5-      $
��-1,0q�5.      $	��Top=�5/      ���#D6E0E550      � 51   
   $��0��6   $��0,0,0,5q�6   	 52      �� 53      $
��Auto �6    �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6    �� 5:      $
��Auto �6    �� 5;      $
��Auto �6    
 � ColumnDefinitions
 5=      �� 5>      $	��270 �6#   �� 5?      $��* �6#   .+�5A      �� $��0��5B      $��2��5C      $��15,10q�5D      $��17(�5E      !Общая информация5G      �� 5H      $��1��6   $��0��6%   1/Идентификатор получателя5J      �� 5K      $��1��5L      $��1��5M      $	��380��5N      {�5O      �� $ 	IsEnabled���5P      3   -ZAPC.Client.Essentials.Bindings.CustomBinding  :   4ZAPC.Client.Essentials.Bindings.BindingDecoratorBase   Path$ Model.EdReceiver��� 5Q      $��2��6   $��0��6%   Вид запроса *5S      �� 5T      $��2��5U      $��1��5V      $	��380��5W      {�5X      �� $ 	IsEnabled���5Y      �� *Model.AbstractRequests+ �� SelectedItem 5Z        $ Model.AbstractRequest�   Mode$ TwoWay=�   UpdateSourceTrigger$ PropertyChanged=��� 5]      $��3��6   $��0��6%   KIДата, на которую формируется извещение *5_      �� 5`      $��3��5a      $��1��5b      $	��380��5c      $
��Left=�5d         CustomWidth$	 150Q�5e      {�5f      �� $ 	IsEnabled���5g        $ Model.AbstractDate��� 5h      $��4��6   $��0��6%   :8Период формирования извещения5j      �� 5k      $��4��5l      $��1��5m       �� Orientation$ 
Horizontal=�5n      .+�5o        $��15,5,5,5q�5p      $
��Left=�5q      $	 160Q�5r      {�5s      �� $ 	IsEnabled�(  "System.Windows.Controls.DatePicker   SelectedDate 5t        $ Model.BeginTime��� 5u      $��5q�6   -6*     5v      $��5,5,15,5q�5w      $
��Left=�5x      $	 160Q�5y      {�5z      �� $ 	IsEnabled� 5{        $ Model.EndTime�5|      �� 5~      $��5��5      $��0��5�      $��2��5�      $��15,10q�5�      $
��Left=�5�      $��Center=�5�      $��Tahoma)�5�      $��11(�5�       d� 	IsChecked 5�        $ Model.PoolInfoFlag�{�5�      �� $ 	IsEnabled�.��66   WUПредоставление информации по всем счетам пула5�      �� 5�      $��6��6   $��0��6%   Бик участника5�      �� 5�      $��6��5�      $��1��5�      $	��380��5�      {�5�      �� $ 	IsEnabled���5�        $ 	Model.Bic��� 5�      $��7��6   $��0��6%   PNНомер счета, по которому проводится запрос5�      �� 5�      $��7��5�      $��1��5�      $	��380��5�      {�5�      �� $ 	IsEnabled���5�        $ 	Model.Acc��� 5�      $��8��6   $��0��6%   Номер сеанса5�      �� 5�      $��8��5�      $��1��5�      $	��380��5�      $
��Left=�5�      $	 150Q�5�      {�5�      �� $ 	IsEnabled���5�        $ Model.SessionId�5�      �� 5�   
   $��1��5�      $
��-1,0q�5�      $	��Top=�5�      ���#D6E0E55�      �� 5�   
   $��1��5�      $��10q�5�      $��Right=�5�      $ 
Horizontal=�5�      .+�5�      �� +  %ZAPC.Client.Resources.SharedResources   CreateCaption#��Z 5�      ��5�      �� *SaveDocumentCommand+y�5�      ��  �� ElementName$ 
ChargeFile��$ DataContext.IsEnabled� �� 	Converter# [ �� 5�         CancelCaption#��Z 5�       � DataContext# [  5�      ��5�      �� *#!CloseWithDialogResultFalseCommand+��5�      ��  �� RelativeSource ��  �� AncestorType" �5�      5�      5�      5�      