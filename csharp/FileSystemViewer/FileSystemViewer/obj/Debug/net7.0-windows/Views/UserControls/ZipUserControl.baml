   M S B A M L   `   `   `  ����K  GFileSystemViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:FileSystemViewer.Views.UserControls#FileSystemViewer.Views.UserControls  5      c6clr-namespace:FileSystemViewer.ViewModels.UserControls(FileSystemViewer.ViewModels.UserControls  5      8    2FileSystemViewer.Views.UserControls.ZipUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:FileSystemViewer.Views.UserControls     5      Ivmodel6clr-namespace:FileSystemViewer.ViewModels.UserControls     5        � DataContext  5      F   @FileSystemViewer.ViewModels.UserControls.ZipUserControlViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value��%t   '��       �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 0q�60   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $	��0.5q�5      
���   �6'   �� 5    
   $��0��6   .+�5!      �� $��Создать архив��6   ��6-   �� *CreateZipCommand+�� 5"      $��Добавить файл��6   ��6-   �� *AddFileCommand+�� 5#      $$��Разархивировать��6   ��6/   �� *UnzipCommand+�� 5$      $+��%Удалить файл и архив��6   ��64   �� *RemoveFileCommand+5%      �� 5'   
   $��1��6   .+�5(      ��  �� Orientation$ 
Horizontal=�6   .+�5)      �� $��Архив: ��6   �� 5*      ��66   �� *	ZipPath+5+      �� 5-      $ 
Horizontal=�6   .+�5.      �� $��
Файл: ��6   �� 5/      ��6;   �� *
FilePath+50      �� 52      $ 
Horizontal=�6   .+�53      �� $!��Размер архива: ��6   �� 54      ��6   �� *CompressedFileSize+55      �� 57      $ 
Horizontal=�6   .+�58      �� $��Размер файла: ��6   �� 59      ��6   �� *DecompressedFileSize+5:      5<      5>      5?      