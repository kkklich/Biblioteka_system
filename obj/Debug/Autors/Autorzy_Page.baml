   M S B A M L   `   `   `  ����L  HBiblioteka_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Biblioteka_systemBiblioteka_system  5      $    Biblioteka_system.Autorzy_Page   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Biblioteka_system     5        N� Title$  Autorzy_Page��5	      .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Autorzy��6   $
��Left=�61   $��67��6L   $��
344,10,0,0q�6X   $	��Top=�6l   $	��134��6�   $��36(�6�   ���	#FF5A8B50$��Sitka Heading)�6�   �� 5   
   -   5        $ label2��5      $��Wyszukaj autorów:��6    $
��Left=�6<   $��29��6W   $��
10,288,0,0q�6c   $	��Top=�6w   $	��112��6�   �� 5   
   -   5         ��Name$ 
txt_search��5      $
��Left=�6&   $��30��6A   $��
10,322,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��148��6�   6�   �� 5   
   -   5         ��Name$ listView_authors��5      $
��Left=�6-   $	��206��6H   $��	10,77,0,0q�6U   $	��Top=�6h   $	��527��6�    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$
 auto��6[    �� DisplayMemberBinding 61   �� *
IdAuthor+6[   �� 5      $
��Imie��6%   $
 auto��6^    63   �� *	FirstName+6^   �� 5      $��Nazwisko��6%   $
 auto��6b    68   �� *
Surename+6b   5      5      �� 5   
   -   5         ��Name$ btn_Add_Author��5      $��Dodaj autora��6)   $
��Left=�6@   $��35��6[   $��
587,93,0,0q�6g   $	��Top=�6{   $	��173��6�   6�   �� 5   
   -   5        $ btn_Edit_Author��5      $��Edytuj autora��6*   $
��Left=�6B   $��35��6]   $��587,145,0,0q�6i   $	��Top=�6~   $	��173��6�   6�   �� 5   
   -   5        $ btn_Delete_Author��5      $��Usuń autora��6,   $
��Left=�6B   $��35��6]   $��587,200,0,0q�6i   $	��Top=�6~   $	��173��6�   6�   �� 5   
   -   5        $ 
lbl_number��5      $
��Left=�6$   $��29��6?   $��484,288,0,0q�6K   $	��Top=�6`   $��53��6x   5      5!      