   M S B A M L   `   `   `  ����N  JClearableDatePicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:ClearableDatePicker;assembly=ClearableDatePickerClearableDatePicker  5      Q MZAPC.Client.Essentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulluOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials!ZAPC.Client.Essentials.Converters 5      F BZAPC.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ZAPC.Client.ResourcesZAPC.Client.Resources 5
      ?$clr-namespace:ZAPC.Client.ViewModelsZAPC.Client.ViewModels 5      1   +ZAPC.Client.Views.ChargeFile.ChargeFileView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^clearableDatePicker>clr-namespace:ClearableDatePicker;assembly=ClearableDatePicker     5      f
convertersOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      I EZAPC.Documents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null,	documentshttp://icl.ru/zapc/documents  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      3	resources#clr-namespace:ZAPC.Client.Resources  5
      5
viewModels$clr-namespace:ZAPC.Client.ViewModels  5      /zapc$http://icl.ru/zapc/client/essentials  5      -   5          �Name$  
ChargeFile��5       � SizeToContent$ Width=�5      ��5      ��  �� Path$ Width� �� ElementName$ 
ChargeFile����5      �� $ Width�$ 
ChargeFile�� � 	Resources 5      -  'ZAPC.Client.ViewModels.ControlViewModel   ClosingControlViewModel  	BoolToVis6  0ZAPC.Client.Essentials.Converters.TitleConverter  TitleConverter �� 
TargetType �� Property �� Value  LocalDefaultLabelStyle  DefaultLabelStyle �� BasedOn  SmallComboBoxStyle  ChargeComboBoxStyle  ZAPC.Client.Essentials.Ex  BigComboBoxStyle  SmallTextBoxStyle 	 DefaultTextBoxStyle 
 BigTextBoxStyle  ClearableDatePickerStyle-   'ClearableDatePicker.ClearableDatePicker��%5  &	        &	      &	 &     '�� 9     &	 �     7  &	 �     7  &	 E    7  &	 �    7 	 &	
     7 	 '  _    7    5   
   6&   �� 5   
   6'     5   
   6$   �� 5   
   " ��6   .�5      ��  �@��Orientation$ 
Horizontal=�6,   5      �� 5   
   8   " ��5      .�5      ��  � ��$	 250��6&   5      �� 5   
   8   " ��5"      .�5#      ��  �@ CustomWidth$	 150Q�64   5$      �� 5%   
   8   " ��5(      .�5)      ��  �@ CustomWidth$	 385Q�64   5*      �� 5+   
   8   " ��5.      .�5/      ��  �@ CustomWidth$	 150Q�64   50      �� 51   
   8   " ��54      .�55      ��  �@ CustomWidth$	 385Q�64   56      �� 57   
   8   "  6D   .�58      ��  �@ CustomWidth$	 150Q�64   59      5:      	 � Title	 5;      `� 5<   
   
 `� 	Converter#
 [ 6   .1�5=      �� $ FileName�6   �� 5>      $ TextDescriptionOfMode�6   5?      .��5A      �  � RowDefinitions 5B   
   �� 5C      $
��Auto �6   �� 5D      $��* �6   �� 5E      $
��Auto �6   �� 5F      $
��Auto �6    � ColumnDefinitions 5H   
   �� 5I      $
��Auto �6   .+�5K   
   �� $��0��6   ���#D6E0E56!   �� 5L   
   $��1��5M      $��Hidden=�5N      $
��Auto=�5O      .��5P      �  5Q      �� 5R      $
��Auto �6$   �� 5S      $
��Auto �6$   �� 5T      $
��Auto �6$   �� 5U      $
��Auto �6$   �� 5V      $
��Auto �6$   �� 5W      $
��Auto �6$   �� 5X      $
��Auto �6$   �� 5Y      $
��Auto �6$   �� 5Z      $
��Auto �6$   �� 5[      $
��Auto �6$   �� 5\      $
��Auto �6$   �� 5]      $
��Auto �6$   �� 5^      $
��Auto �6$   �� 5_      $
��Auto �6$   �� 5`      $
��Auto �6$   �� 5a      $
��Auto �6$   �� 5b      $
��Auto �6$   �� 5c      $
��Auto �6$   �� 5d      $
��Auto �6$   �� 5e      $
��Auto �6$   �� 5f      $
��Auto �6$   �� 5g      $
��Auto �6$   �� 5h      $
��Auto �6$   �� 5i      $
��Auto �6$   �� 5j      $
��Auto �6$   �� 5k      $
��Auto �6$   �� 5l      $
��Auto �6$   �� 5m      $
��Auto �6$   �� 5n      $
��Auto �6$   .+�5p      �� $��0��5q        HeaderLabelStyle#���  5s      ��5r      9  3ZAPC.Client.Essentials.MarkupExtentions.Description     Type   ZAPC.Documents.Ed101.Ed101"  5s      �� 5t      $��1��6   .+�5u      �� #���  6n   ��6        PropertyName$ PaytKind��"  6n   �� 5v      #  ZAPC.Documents.Ed101.PaytKind   Items#��Z 5x      #���  5z      {�5w      �� *	IsEnabled+ �� SelectedItem 5y      3  -ZAPC.Client.Essentials.Bindings.CustomBinding  :	  4ZAPC.Client.Essentials.Bindings.BindingDecoratorBase 	  Path$ Model.PaytKind�5z      5{      �� 5|      $��2��6   .+�5}      �� #���  6l   ��6     $ Amount��"  6l   �� 5~      #��� 
 5�      {�5      �� *	IsEnabled+��5�        $ Model.Amount�5�      �� 5�      $��3��6   .+�5�      �� #���  6m   ��6     $ Purpose��"  6m   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Purpose�5�      �� 5�      $��4��6   .+�5�      �� #���  6n   ��6     $ Priority��"  6n   �� 5�      #
  ZAPC.Documents.Ed101.Priority 
  Items#��Z 5�      #���  5�      {�5�      �� *	IsEnabled+ 5�        $ Model.Priority�5�      5�      �� 5�      $��5��6   .+�5�      �� #���  6p   ��6     $ 
SystemCode��"  6p   �� 5�      -   5         ��Name$ SystemCodes��5�      ��5�      �� $ Items�%  ZAPC.Documents.Ed101.SystemCode   Instance �� Source# Z  5�        $ Model.SystemCode���5�      �� 5�      # [ 6$   " ��6R   �5�   "   �� 5�   &    � {� 6B   �� *	IsEnabled+ �� Triggers 5�   "   �� 5�   &    �� Binding 62   �� $ Model.PaytKind.Code� �� Value 46_   .a�5�   *   ��  � {� .  6F   5�   '   5�      5�      5�      �� 5�      $��6��5�      #���  5�      ��5�        $ Payer��"  5�      �� 5�      $��7��6   .+�5�      �� #���  6q   ��6     $	 Inn��(  "ZAPC.Documents.Ed101.PaymentMember"  6q   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payer.Inn�5�      �� 5�      $��8��6   .+�5�      �� #���  6q   ��6     $	 Kpp��"  6q   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payer.Kpp�5�      �� 5�      $��9��6   .+�5�      �� #���  6r   ��6     $
 Name��"  6r   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payer.Name�5�      �� 5�      $��10��6   .+�5�      �� #���  6{   ��6     $ AccountNumber��"  6{   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payer.AccountNumber�5�      �� 5�      $��11��6   .+�5�      �� #���  6h   ��6     $	 Bic��  ZAPC.Documents.Ed101.Bank"  6h   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payer.Bank.Bic�5�      �� 5�      $��12��6   .+�5�      �� #���  6r   ��6     $ AccountNumber��"  6r   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $$ Model.Payer.Bank.AccountNumber�5�      �� 5�      $��13��5�      #���  5�      ��5�        $ Payee��"  5�      �� 5�      $��14��6   .+�5�      �� #���  6q   ��6     $	 Inn��"  6q   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payee.Inn�5�      �� 5�      $��15��6   .+�5�      �� #���  6q   ��6     $	 Kpp��"  6q   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payee.Kpp�5�      �� 5�      $��16��6   .+�5�      �� #���  6r   ��6     $
 Name��"  6r   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payee.Name�5�      �� 5�      $��17��6   .+�5�      �� #���  6{   ��6     $ AccountNumber��"  6{   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payee.AccountNumber�5�      �� 5�      $��18��6   .+�5�      �� #���  6h   ��6     $	 Bic��"  6h   �� 5�      #��� 
 5�      {�5�      �� *	IsEnabled+��5�        $ Model.Payee.Bank.Bic�5�      �� 5�      $��19��6   .+�5�      �� #���  6r   ��6     $ AccountNumber��"  6r   �� 5�      #��� 
 5     {�5      �� *	IsEnabled+��5       $$ Model.Payee.Bank.AccountNumber�5     �� 5     $��20��5     #���  5     ��5       $ DepartmentalInfo��"  5     �� 5	     $��21��6   .+�5
     �� #���  6}   ��6     $ DrawerStatus��+  %ZAPC.Documents.Ed101.DepartmentalInfo"  6}   �� 5     #���  5     {�5     �� *	IsEnabled+��5       $) #Model.DepartmentalInfo.DrawerStatus�5     �� 5     $��22��6   .+�5     �� #���  6t   ��6     $	 Cbc��"  6t   �� 5     #���  5     {�5     �� *	IsEnabled+��5       $  Model.DepartmentalInfo.Cbc�5     �� 5     $��23��6   .+�5     �� #���  6v   ��6     $ Okato��"  6v   �� 5     #���  5     {�5     �� *	IsEnabled+��5       $" Model.DepartmentalInfo.Okato�5     �� 5     $��24��6   .+�5     �� #���  6{   ��6     $ 
PaytReason��"  6{   �� 5      #���  5"     {�5!     �� *	IsEnabled+��5#       $' !Model.DepartmentalInfo.PaytReason�5$     �� 5%     $��25��6   .+�5&     �� #���  6z   ��6     $ 	TaxPeriod��"  6z   �� 5'     #���  5)     {�5(     �� *	IsEnabled+��5*       $&  Model.DepartmentalInfo.TaxPeriod�5+     �� 5,     $��26��6   .+�5-     �� #���  6v   ��6     $ DocNo��"  6v   �� 5.     #���  50     {�5/     �� *	IsEnabled+��51       $" Model.DepartmentalInfo.DocNo�52     �� 53     $��27��6   .+�54     �� #���  6x   ��6     $ DocDate��"  6x     55     {�6>   �� *	IsEnabled+(  "System.Windows.Controls.DatePicker   SelectedDate 6^     $$ Model.DepartmentalInfo.DocDate�56     �� 57     $��28��6   $��0,0,0,10q�6+   .+�58     �� #���  6|   ��6     $ TaxPaytKind��"  6|   �� 59     #���  5;     {�5:     �� *	IsEnabled+��5<       $( "Model.DepartmentalInfo.TaxPaytKind�5=     5>     5?     �� 5@  
   $��2��6   ���#D6E0E56!   �� 5A  
   $��3��5B     $��
0,15,15,15q�5C     $��Right=�5D     .+�5E     �� +  %ZAPC.Client.Resources.SharedResources   	OkCaption#��Z 5H     ��5F     �� *" SendDocumentToServerCommandAsync+��5G     ��  �� RelativeSource ��  �� AncestorType" �y�5I     �� *DataContext.IsEnabled+ �� 	Converter# [ $ 
ChargeFile���� 5J     $��0q�5K        CloseCaption#��Z 5N      � DataContext# [  5O     ��5L     �� *#!CloseWithDialogResultFalseCommand+��5M     ��  �� " �5O     5P     5Q     5R     