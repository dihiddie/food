   M S B A M L   `   `   `  ����F  BFood.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Food.Client.ViewModel.ContainerFood.Client.ViewModel.Container  5      A%clr-namespace:Food.Client.ControllersFood.Client.Controllers  5      =#clr-namespace:Food.Client.ResourcesFood.Client.Resources  5	      $    Food.Client.Controls.Container   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Econtainervm-clr-namespace:Food.Client.ViewModel.Container     5      =controllers%clr-namespace:Food.Client.Controllers     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      9	resources#clr-namespace:Food.Client.Resources     5	        � 	Resources  5         GroupTextBlockStyle �� 
TargetType �� Property �� Value  MenuItemTextBlockStyle �� BasedOn��%(  &	        &	 �     7   �� 5   
   " ��6,   .�5      ��  � ��$ Tahoma)�6+   �� 5       � ��$ 18(�6)   �� 5       � ��
 �����6+   �� 5       � ��$ 5,5,0,5q�6'   5      �� 5   
   8   " ��5      .�5      ��  � ��$ 14(�6)   5      5       � DataContext 5      S� 5   
    S� 
ObjectType8   2Food.Client.ViewModel.Container.ContainerViewModel"  6    S� ConstructorParameters 5      6   0Food.Client.Controllers.CreateMenuItemController  5      5      .��5       �  � ColumnDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $��* �6   .+�5%   
   �� $��0��5&      
�������$��0,0,2,0q�5(      ._�5)      �� $��
10,10,20,0q�6   	 �� Orientation$	 Vertical=�6-   .+�5*      �� $
��Left=�6   $	 
Horizontal=�68   .+�5+      �� $��Center=�5,      $��Tahoma)�5-      $��28(�5.      $
��Bold"�5/      
�������+   %Food.Client.Resources.SharedResources
   AppTitleCaption#��Z
 51      �� 52      $��28��53      $��28��54      $��5,0,0,0q�55      $,��&pack://application:,,,/Icons/donut.png��56      57      �� 59      $��0,10,0,0q�6   $	 Vertical=�6/   .+�5:      �� $��0,0,0,10q�6    �� 5;       �� TextDecorations$
 None{�6M    �� Command 6$   �� *OpenDashboardCommand+.�6d   .�5<      �� #��[  6(   $��
ДОСКА��6U   5=      5>      �� 5?      #��[  6    $��ЕДА��6M   �� 5@      �� 5A      $
 None{�6N    6$   �� *OpenWeeklyMenuCommand+.�6e   .�5B      �� #��[  6(   $!��Недельное меню��6U   5C      5D      �� 5E      �� 5F      $
 None{�6$   .�6;   .�5G      �� #��[  6(   $��Рецепты��6U   5H      5I      �� 5J      �� 5K      $
 None{�6$   .�6;   .�5L      �� #��[  6(   $!��Список покупок��6U   5M      5N      �� 5P      �� 5Q      $
 None{�6$   .�6;   .�5R      �� $��5,10,0,0q�5S   !   #��[  5T   !   $��ТРЕНИРОВКИ��5U   !   5V      5W      �� 5Y      $��0,10,0,0q�6    �� 5Z      $
 None{�6$   .�6;   .�5[      �� #��[  6(   $��
Выход��6U   5\      5^      5`      5a      5b      �� 5c   
   $��1��5d      
������ ��5f      �� *SomeItemSource+ �� SelectedItem 5g      �� *SelectedItem+5h      5i      