   M S B A M L   `   `   `  ����Q  MZAPC.Client.Essentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqMclr-namespace:ZAPC.Client.Essentials.Bindings;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials.Bindings  5      uOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials!ZAPC.Client.Essentials.Converters  5      _Dclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.EssentialsZAPC.Client.Essentials  5      F BZAPC.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ZAPC.Client.ResourcesZAPC.Client.Resources 5
      ?$clr-namespace:ZAPC.Client.ViewModelsZAPC.Client.ViewModels 5      '   !ZAPC.Client.Views.ED499.Ed499View   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      bbindingsMclr-namespace:ZAPC.Client.Essentials.Bindings;assembly=ZAPC.Client.Essentials     5      f
convertersOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      [
essentialsDclr-namespace:ZAPC.Client.Essentials;assembly=ZAPC.Client.Essentials     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      9	resources#clr-namespace:ZAPC.Client.Resources     5
      ;
viewModels$clr-namespace:ZAPC.Client.ViewModels     5      $	��715��5      $	��190��5        � 
ResizeMode$  NoResize=�5       � 	Resources 5      -  'ZAPC.Client.ViewModels.ControlViewModel   ControlViewModel  	BoolToVis6   0ZAPC.Client.Essentials.Converters.TitleConverter  TitleConverter  DefaultTextBoxStyle �� BasedOn �� 
TargetType   ZAPC.Client.Essentials.Ex �� Property �� Value  DefaultTextBlockStyle��%�   &	        &	      &	 &     '�� 9     7  '�� �     7    5   
   6&   �� 5   
   6'     5   
   6$   �� 5   
   8   " ��6?   .�5      ��  �@ CustomWidth$	 404Q�6:   5      �� 5   
   8   " ��6A   5       � Title 5      `� 5   
    `� 	Converter# [ 6   .1�5      ��  �� Path$ FileName�6   �� 5      $ TextDescriptionOfMode�6   5      .��5      � 	 � RowDefinitions	 5    
   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   .+�5%   
   �� $��0��5&      $
��-1,0q�5'      $	��Top=�5(      ���#D6E0E55)      � 5*   
   $��0��6   $��0,0,0,15q�6   	 5+      �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    
 � ColumnDefinitions
 5/      �� 50      $	��265 �6#   �� 51      $��* �6#   .+�54      �� $��0��55      $��2��56      $��15,10q�57      $��17(�58      !Общая информация5:      �� 5<      $��1��6   $��0��6%   MKУникальный идентификатор получателя ЭС *5>      �� 5?      $��1��5@      $��1��5A      {�5B      �� $ 	IsEnabled���5C      3   -ZAPC.Client.Essentials.Bindings.CustomBinding  :   4ZAPC.Client.Essentials.Bindings.BindingDecoratorBase   Path$ Model.EdReceiver�5D      �� 5F   
   $��1��5G      $
��-1,0q�5H      $	��Top=�5I      ���#D6E0E55J      �� 5K   
   $��1��5L      $��
10,10,8,10q�5M      $��Right=�5N       �� Orientation$ 
Horizontal=�5O      .+�5P      �� +  %ZAPC.Client.Resources.SharedResources   CreateCaption#��Z 5R      ��5Q      �� *SaveDocumentCommand+y�5S      ��  �� ElementName$ 
ChargeFile��$ DataContext.IsEnabled� �� 	Converter# [ �� 5T         CancelCaption#��Z 5W       � DataContext# [  5X      ��5U      �� *#!CloseWithDialogResultFalseCommand+��5V      ��  �� RelativeSource ��  �� AncestorType" �5X      5Y      5Z      5[      