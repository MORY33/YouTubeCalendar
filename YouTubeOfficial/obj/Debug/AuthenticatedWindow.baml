   M S B A M L   `   `   `  ����J  FYouTubeOfficial, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:YouTubeOfficialYouTubeOfficial  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35`Dclr-namespace:System.Windows.Controls;assembly=PresentationFrameworkSystem.Windows.Controls 5   	   )    #YouTubeOfficial.AuthenticatedWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:YouTubeOfficial     5   	   YcontrolsDclr-namespace:System.Windows.Controls;assembly=PresentationFramework     5   	   -   5          � Title$  AuthenticatedWindow��5	   	   $	��450��6%   $	��800��62   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��10q�6J   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ WatchDateDatePicker��5      $��0 0 10 0q�66   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��	VideoGrid��5   /      AutoGenerateColumns .  $	��800��6@    �� AlternationCount$ 2��6O   $��14(�6d      GridLinesVisibility$
 None=�6r   $��1��5      $��0��6    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value*  $System.Windows.Controls.DataGridCell   RoundButtonStyle �� 
TargetType��%
  '        '  �     '      &	  1    �� 5      "	  6   .�5      �� 
 � �� �#007ACC63   �� 5      
 � ��
 �����63   �� 5      
 � ��$
 Bold"�63   �� 5      
 � ��$	 6,3q�60   5      �� 5      "	  6   .�5       �� 
 � ��$	 6,3q�60   5!      �� 5"      "	  6   .�5#      �� 
 �@ RowHeaderWidth$ 0Q�67   �� 5$      
 �@ CanUserAddRows .  67   �� 5%      
 �@ SelectionMode$ Single=�66   �� 5&       
 �@ AlternatingRowBackground �#F2F2F26A   �� 5'      
 � ��$ Stretch=�6C   5(      �� 5)      "	 ��61   .�5*      �� 
 � �� �#007ACC63   �� 5+      
 � ��
 �����63   �� 5,      
 � ��$
 10,5q�60   �� 5-      
 � ��$ 0q�68   �� 5.      
 � ��
 ���� 64   �� 5/      
 � �� 50      �� 51      " ��6.   .R�52   "   � .+�53   &   A� #��z��6.   #��z��6R   #��z��6y   �� 54   &   $��Center=�67   $��Center=�6T   55   #   56      58      59      5:         Columns 5;      4  .System.Windows.Controls.DataGridTemplateColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ Video��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 68      MaxWidth$	 200Q�6E      CellTemplate 5?      �� 5@      .R�5A      �  5B   "   �� 5C   &   $
��Auto �64   �� 5D   &   $��* �64   �� 5E   &   $
��Auto �64   .+�5G   "   �� $	��Top=�6K   $
��Wrap=�6c   $��16(�6w   ��6,   �� *Snippet.Title+6w   � 5H   "   $��1��6'    5I   &   �� 5J   *   $��* �68   �� 5K   *   $
��Auto �68   .+�5N   &   �� $��	AddButton��6-   -   5        #��[  5N   >   $��1��6h   $��20��6u   $��20��6�   $��5q�6�   .��5O   *   �� $��+��64   $��14(�6=   $
��Bold"�6K   
�������6]   5P   '   5Q   #   �� 5R   "   $	��150��6Y   $	��100��6e   $��0,55,0,0q�6r   $	��Top=�6�   ��6(   �� *Snippet.Thumbnails.Medium.Url+6�   5S      5T         HeaderStyle 5W      �� 5X      "	  6    .�5Y      �� 
 � ��$ Stretch=�6K   5Z      5\        5]      $ Description��6)   $ * 6>    5^      �� 5_      .R�5`      �� $��1��6+   $
��Auto=�68   $	��150��6[   ��5a   "   �� 5b   &   "	 ��6,   .�5c   *   �� 
 � �� .  6M    �� Triggers 5d   *   �� 5e   .    �� Binding 6:   �� *IsKeyboardFocusWithin+ �� RelativeSource ��  �� AncestorType$ 	TextBlockL� �� Value True6�   .a�5f   2   �� 
 � �� . 6U   5g   /   5i   '   .��5k   "   �� $
��Wrap=�6Q   $��12(�6e   $��0,10,0,0q�6s   ��6,   �� *Snippet.Description+6s   5l      5m      5o      5u      �� 5v   
   -   5         ��Name$ LogoutButton��5v      $��Logout��6'   ���#007ACC
�������$��0q�6`   $
��10,5q�6t   $��
10,9,710,9q�6�   ��5w      �� 5x      " ��6"   .R�5y      �� #��z��6    �� Padding# z��6G   ._�5z      �� $��Center=�6+   $��Center=�6H   5{      5|      5~      �� 5   
   -   5         ��Name$ 	MovieList��5       �� DisplayMemberPath$ Login��6%   $y�	Collapsed=�6?   �� 5�   
   -   5        $ ScheduleButton��5�      $��Schedule��6)   ���#007ACC
�������$��0q�6d   $
��10,5q�6x   $��349,9,349,9q�6�   ��5�      �� 5�      " ��6"   .R�5�      �� #��z��6   # z��6G   ._�5�      �� $��Center=�6+   $��Center=�6H   5�      5�      5�      5�      5�      