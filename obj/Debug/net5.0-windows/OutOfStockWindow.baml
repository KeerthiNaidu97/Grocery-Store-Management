   M S B A M L   `   `   `  ����J  FKGNGroceryStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:KGNGroceryStoreKGNGroceryStore  5   	   K*clr-namespace:KGNGroceryStore.OtherClassesKGNGroceryStore.OtherClasses  65   &     KGNGroceryStore.OutOfStockWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:KGNGroceryStore     5   	   =local1*clr-namespace:KGNGroceryStore.OtherClasses     65     � Title$  OutOfStockWindow��5   	   $	��450��6"   $	��800��6/   .��5	      � 
������� � 	Resources 5
   
   2   ,KGNGroceryStore.OtherClasses.ActualImagePath   	imagePath��%   &	          5      6%   5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��40* �6   �� 5      $
��365* �6   �� 5      $
��393* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $��4��6'   $��15(�6;   $
��Bold"�6I   
���   �
����ح� �� Padding$ 20,20q�6�   $��50��6�    �� TextAlignment$ Center=�6�    �� 
LineHeight$
 Auto��6�   $��0,0,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��Century Gothic)�6	  �� 6&   � Language$ en-in�6*  $�KGN Grocery Store��6;  6W  �� 5   
   -   5         ��Name$ 	pageTitle��5      $��Out of Stock Products ��6#   $��Center=�6D   $	��Top=�6a   $	��220��6y   $��35��6�   $��0,70,0,0q�6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5        	 ��Name$	 Filter_textBox��5      $
��Left=�6*   $��
43,101,0,0q�6E   $�� ��6Y   $��30��6a   
 � ToolTip$/
 )Enter the name of item you want to search��6m   $
��Bold"�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��579��6�   $��2��6�   $��2��6�   6  �� 5   
   -   5        $ label��5      $��Enter Item to Search ��6   $
��Left=�6?   $��	43,75,0,0q�6Z   $	��Top=�6m   $	��167��6�   $��2��6�   $��26��6�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $��/menuicon.jpg��6:   $��30��6Q   $��256,102,0,0q�6]   $	��Top=�6r   $��30��6�   $��3��6�   � 5   
   -   5         �Name$ SlidingMenu��5   #   $��3��6   $��	0,61,0,73q�68   $��20��6K   $
��Left=�6V   
����ح�.+�5      �� -   5        $
 Menu��5      $��/menuicon.jpg��6#   $��20��6:   $��20��6E   $	��Top=�6Q   $��Right=�6i   �� 5      -   5         ��Name$ managebilling��5      $��Store��6,   $��Right=�6=   $��
10,75,60,0q�6Y   $	��Top=�6m   $��34��6�   $	��120��6�   �� 5      -	   5        $ managestock��5      $��Manage Stock��6*   $��Right=�6B   $��10,150,60,0q�6^   $	��Top=�6s   $��34��6�   $	��120��6�   5       �� 5!   
   -
   5         ��Name$ itemlistbox��5!      $��4��6'   $��90,195,80,56q�6;   ��5"      �� 5#      .R�5$      ��  �� Orientation$ 
Horizontal=�6!   .+�5%      �� $��80��6_   $��90��6k   $��0,0,30,0q�6v   $
��Left=�6�   $
��Fill=�6�   ��6    �� *image+ �� 	Converter# [  6�   �� 5&      $��	50,0,10,0q�6A   $��39.683��6T   $��90��6d   ��6$   �� *productName+6d   �� 5'      $��	40,0,10,0q�6M   $��39.683��6`   $��90��6q   ��6$   �� *price+ �� StringFormat$
 0.00��6q   �� 5(      $��	40,0,30,0q�6>   $��39.683��6Q   $��90��6b   ��6$   �� *
quantity+6b   �� 5)      $
 edit��6!   -   5        $
��Edit��5)   /   $��	40,0,10,0q�6?   $��39.683��6R   $��90��6b   6m   5+      5,      5.      51      52      