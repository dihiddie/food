   M S B A M L   `   `   `  ����]  YICSharpCode.AvalonEdit, Version=5.0.3.0, Culture=neutral, PublicKeyToken=9cc39be672370310_Dclr-namespace:ICSharpCode.AvalonEdit;assembly=ICSharpCode.AvalonEditICSharpCode.AvalonEdit  5      F BZAPC.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ZAPC.Client.ViewModelsZAPC.Client.ViewModels 5      ?$clr-namespace:ZAPC.Client.ConvertersZAPC.Client.Converters 5      Q MZAPC.Client.Essentials, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulluOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials!ZAPC.Client.Essentials.Converters 5	      =#clr-namespace:ZAPC.Client.ResourcesZAPC.Client.Resources 5      /   )ZAPC.Client.Views.UfebsFile.UfebsFileView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      WavalonDclr-namespace:ICSharpCode.AvalonEdit;assembly=ICSharpCode.AvalonEdit     5      :	controlvm$clr-namespace:ZAPC.Client.ViewModels     5      ;
converters$clr-namespace:ZAPC.Client.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      nexternalconvertersOclr-namespace:ZAPC.Client.Essentials.Converters;assembly=ZAPC.Client.Essentials     5	      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      3	resources#clr-namespace:ZAPC.Client.Resources  5      X TXceed.Wpf.Toolkit, Version=3.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      $	��750��5      $	��450��5        � WindowStartupLocation$  CenterScreen=�5       � Title 5      �� *
FileName+ � 	Resources 5      -  'ZAPC.Client.ViewModels.ControlViewModel   ControlViewModel:  4ZAPC.Client.Converters.StringToTextDocumentConverter ! StringToTextDocumentConverter?  9ZAPC.Client.Essentials.Converters.InverseBooleanConverter  InverseBooleanConverter  	BoolToVis��%t   &	        &	      &	 &     &	 9       5   
   6%     5   
   63     5   
   65   �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   '   !ICSharpCode.AvalonEdit.TextEditor  $��0��5      $��0q�5       $
��10,5q�5!      ���#F7F7F7���#D6E0E5$	��0,1q�5$      $   HorizontalScrollBarVisibility$
 Auto=�5&         
IsReadOnly .    SyntaxHighlightingM   GICSharpCode.AvalonEdit.Highlighting.HighlightingDefinitionTypeConverter$	 XML 5(         WordWrap .    Document 5%      �� 	 �� Path$	 FileContent�
 �� 	Converter#
 [ 5)      %  Xceed.Wpf.Toolkit.BusyIndicator  5*   
   $��0��5+         BusyContent$" Идет загрузка...��5,         IsBusy 5-      �� *(&GetFileContentCommandAsync.IsExecuting+� 5.   
   $��1��6    � ColumnDefinitions 5/      �� 50      $��* �6#   �� 51      $
��Auto �6#   .+�53      �� $
��10,5q�54      $
��Left=�55      $��Center=�56      ��57      �� *CurrentOperationText+�� 58      $��1��59      $
��5,10q�5:       �� Orientation$ 
Horizontal=�5;      .+�5<      �� $
��Auto��5=      $��70��5>      +  %ZAPC.Client.Resources.SharedResources   SignCaption#��Z 5@      $��Tahoma)�5A      $��11(�5B      ��5?      �� *SignCommandAsync+{�5C      �� $,	 &GetFileContentCommandAsync.IsExecuting�#
 [ y�5D      �� $	 	NotSigned�#
 [ �� 5E      $
��Auto��5F      $	��100��5G         SaveAsCaption#��Z 5I      $��Tahoma)�5J      $��11(�5K      ��5H      �� *SaveFileCommandAsync+{�5L      �� $,	 &GetFileContentCommandAsync.IsExecuting�#
 [ �� 5M      $
��Auto��5N      $��60��5O      $��Right=�5P         CloseCaption#��Z 5S       � DataContext# [  5T      $��Tahoma)�5U      $��11(�5V      ��5Q      �� *CloseWindowCommand+��5R      ��  �� RelativeSource ��  �� AncestorType" �5V      5W      5X      5Y      .  (System.Windows.Interactivity.Interaction   Triggers 5Z      /	  )System.Windows.Interactivity.EventTrigger	  5[   
    	  	EventName$ Closing��6   .
  (System.Windows.Interactivity.TriggerBase 
  Actions. 5\      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� **(GetFileContentCommandAsync.CancelCommand+  5]       6$   �� * SignCommandAsync.CancelCommand+  5^       6$   �� *$"SaveFileCommandAsync.CancelCommand+5_      5a      