   M S B A M L   `   `   `  ����K  GFileSystemViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:FileSystemViewer.Views.UserControls#FileSystemViewer.Views.UserControls  5      c6clr-namespace:FileSystemViewer.ViewModels.UserControls(FileSystemViewer.ViewModels.UserControls  5      9    3FileSystemViewer.Views.UserControls.FileUserControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:FileSystemViewer.Views.UserControls     5      Ivmodel6clr-namespace:FileSystemViewer.ViewModels.UserControls     5        � DataContext  5      G   AFileSystemViewer.ViewModels.UserControls.FileUserControlViewModel  5   
    � 	Resources 5       !  ContactsEditingTextBlockStyle �� Property �� Value  ContactsEditingTextBoxStyle  ContactsActionButtonStyle��%�  &	        &	 �     &	 c    �� 5   
   .�5      ��  � ��$ Center=�6>   �� 5       � ��$ 15(�63   �� 5       � ��$ 0,0,0,3q�61   5      �� 5   
   .�5      ��  � ��$ 0q�68   �� 5       � ��
 �����63   �� 5       � ��$ 3,0,3,0q�6/   �� 5       � ��$ 20��62   �� 5       � ��$ 15(�61   5      �� 5   
   .�5      ��  � ��$ 3q�6.   5      5       .��5"      �  � RowDefinitions 5#   
   �� 5$      $��* �6   �� 5%      $	��17* �6   �� 5&      $
��1.2* �6    � ColumnDefinitions 5(   
   �� 5)      �� 5*      .+�5-   
   o� $��0��6   $��0��6   $��2��6,   
�������.@�5/      m� $
��File��6   .@�50      m� $	��New��6    m� Command 6'   �� *CreateNewPhoneBookCommand+m� 51      $
��Open��6    6(   �� *OpenPhoneBookCommand+m� 52      $��Save as��6   .@�53      m� $
��JSON��6    m� CommandParameter$
 json��54       53   ,   �� *SavePhoneBookCommand+54      m� 55      $	��XML��6   $	 xml��56       55   +   �� *SavePhoneBookCommand+56      57      58      59      &   System.Windows.Controls.DataGrid  5;   
   $��1��6   $��0��6    
�������   AutoGenerateColumns$ False��5<      	   CanUserAddRows$	 False��5=      
   SelectionMode$
 Extended=�6*   $��3q�5>      ��5?      �� *
Contacts+ �� SelectedItem 5@      �� *SelectedContacts+   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5C      $ Phone number��6%    6;   �� *PhoneNumber+  5D      $ Email��6%    64   �� *Email+  5E      $ Address��6%    66   �� *	Address+5G      �� 5I   
   $��1��6   $��1��6   $��3q�6.   
���   �$	��0.5q�5J   %   ._�5K      �� .+�5L      �� $
��Name��6   #��[  6(   �� 5M      #��[ 6   ��5N      �� *SelectedContacts.Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5Q      $��Phone number��6   #��[  60   �� 5R      #��[ 6   ��5S      �� *SelectedContacts.PhoneNumber+$ PropertyChanged=��� 5V      $��Email��6   #��[  6)   �� 5W      #��[ 6   ��5X      �� *SelectedContacts.Email+$ PropertyChanged=��� 5[      $��Address��6   #��[  6+   �� 5\      #��[ 6   ��5]      �� *SelectedContacts.Address+$ PropertyChanged=�5`      5a      � 5c   
   $��2��6   $��0��6    5d      �� 5e      �� 5f      .+�5i      �� $��0��6   #��[ 6%   $��+��5j      ��5k      �� *AddContactsCommand+�� 5l      $��1��6   #��[ 6%   $��-��5m      ��5n      �� *RemoveContactsCommand+5o      5q      5r      