   M S B A M L   `   `   `  ���� J  FLab5_CSharp_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Lab5_CSharp_WPFLab5_CSharp_WPF       Lab5_CSharp_WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Lab5_CSharp_WPF       � Title$  
MainWindow��$	��450��$	��800��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�o� $	��Top=�$��0��$��0��$��3��.@�m� -   $��	mn_delete��$0��*Удалить выбранный файл��m� -   $��mn_about��$��Об авторе��m� -   $��mn_exit��$��
Выход���� $��0��$��1��$��5q� �� Orientation$ 
Horizontal=�$��2��.+��� Путь поиска:�� -   $��tb_path��$��9,0,0,0q�$	��100��.��C:/�� -   $��btn_selectPath��$	��7,1q�.��Выбрать путь�� -   $��
btn_search��$��10,0,0,0q�$	��7,1q�.��Искать� $��0��$��2�� � ColumnDefinitions �� $��* ��� $
��Auto ��� $��* � �� $
��122* ��� $
��249* �.+��� $��1��$��0�� �� ShowsPreview .  $��10��$��Center=�$��Stretch=�$��2���� -   $��lv_files��$��0��$��0��$��5q�$��2�� �� View �� .P���  �� DisplayMemberBinding ��  �� Path$ FileName�.��
Файл��  �� $ FileAttribute�.��Атрибуты��  �� $ 
createTime�.��Время создания�� -   $��
lv_folders��$��0��$��2��$��5q�$��2�� �� .P���  �� $ FileName�.��
Папка��  �� $ FileAttribute�.��Атрибуты��  �� $ 
createTime�.��Время создания