   M S B A M L   `   `   `  ����J  FKGNGorceryStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:KGNGorceryStoreKGNGorceryStore  5   	        KGNGorceryStore.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:KGNGorceryStore     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      � 
������� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��40* �6   �� 5      $
��365* �6   �� 5      $
��393* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $��4��6'   $��15(�6;   $
��Bold"�6I   
���   �
����ح� �� Padding$ 20,20q�6�   $��50��6�    �� TextAlignment$ Center=�6�    �� 
LineHeight$
 Auto��6�   $��0,0,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��Century Gothic)�6	  �� 6&   � Language$ en-in�6*  $�KGN Grocery Store��6;  6W  �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��7,87,0,0q�6>   $�� ��6P   $��30��6X    � ToolTip$/ )Enter the name of item you want to search��6d   $
��Bold"�6�   	 �� TextWrapping$
	 Wrap=�6�   $	��Top=�6�   $	��318��6�   $��2��6�   �� 5   
   -   5        
 ��Name$
 label��5      $��Enter Item to Search ��6   $
��Left=�6?   $��7,61,0,0q�6Z   $	��Top=�6l   $	��167��6�   $��2��6�   $��26��6�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $��/menuicon.jpg��6:   $��30��6Q   $��
325,87,0,0q�6]   $	��Top=�6q   $��30��6�   $��2��6�   �� 5   
   -   5         ��Name$ itemlistbox��5      $��Stretch=�6(   $��10,131,11,73q�6F   $��2��6\   �� 5   
   -   5        $ itemcollectionbox��5      $��10,131,10,73q�6-   $��3��6D   � 5   
   -   5         �Name$ SlidingMenu��5   #   $��3��6   $��	0,61,0,73q�68   $��20��6K   $
��Left=�6V   
����ح�.+�5      �� -   5        $
 Menu��5      $��/menuicon.jpg��6#   $��20��6:   $��20��6E   $	��Top=�6Q   $��Right=�6i   �� 5      -	   5         ��Name$ managebilling��5      $��Manage Billing��6,   $��Right=�6F   $��
10,75,60,0q�6b   $	��Top=�6v   $��34��6�   $	��120��6�   �� 5      -
   5        $ managestock��5      $��Manage Stock��6*   $��Right=�6B   $��10,150,60,0q�6^   $	��Top=�6s   $��34��6�   $	��120��6�   5"      5<      5=      