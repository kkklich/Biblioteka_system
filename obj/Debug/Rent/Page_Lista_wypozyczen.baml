   M S B A M L   `   `   `  ����L  HBiblioteka_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Biblioteka_systemBiblioteka_system  5      -    'Biblioteka_system.Page_Lista_wypozyczen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Biblioteka_system     5        N� Title$  Page_Lista_wypozyczen��5	      .��5      � .+�5   
   �� -   5         ��Name$ listViewRent1��5      $
��Left=�6*   $	��246��6E   $��	56,46,0,0q�6R   $	��Top=�6e   $	��510��6}    �� View 5      �� 5      .P�5      �� $��id��6&    �� Width$ 30��6\    �� DisplayMemberBinding 62   �� *	id_rent+6\   �� 5      $
��Imie��6%   $ 90��6_    63   �� *	firstname+6_   �� 5      $��Nazwisko��6%   $ 90��6a    67   �� *
surename+6a   �� 5      $��tytul��6%   $	 120��6^    64   �� *title+6^   �� 5      $��Czas zwrotu��6%   $	 150��6g    6:   �� *
dateReturn+6g   5      5      �� 5   
   -   5         ��Name$ 	btn_close��5      $��Zamknij wypożyczenie��6$   $
��Left=�6C   $��43��6^   $��
589,46,0,0q�6j   $	��Top=�6~   $	��174��6�   6�   �� 5   
   -   5        $ 
btn_upadte��5      $��Przedłuż wypożyczenie��6%   $
��Left=�6E   $��41��6`   $��
589,94,0,0q�6l   $	��Top=�6�   $	��174��6�   6�   �� 5   
   -   5        $ btn_over��5      $#��Wypożyczenia przeterminowane��6#   $
��Left=�6J   $��59��6e   $��589,140,0,0q�6q   $	��Top=�6�   $	��174��6�   6�   �� 5   
   -   5        $ Btn_details��5      $��Wyświetl szczegóły��6&   $
��Left=�6C   $��44��6^   $��589,204,0,0q�6j   $	��Top=�6   $	��174��6�   6�   �� 5   
   -   5         ��Name$ lbl_info��5      $��Wszystkie zamówienia��6"   $
��Left=�6A   $��31��6\   $��	56,10,0,0q�6h   $	��Top=�6{   $	��232��6�   �� 5   
   -   5         ��Name$ 
txt_Search��5      $
��Left=�6&   $��39��6A   $��
56,348,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6v   $	��213��6�   6�   �� 5   
   -   5        $ label��5      $��Wyszukaj wypożyczenie��6   $
��Left=�6?   $��41��6Z   $��
56,302,0,0q�6f   $	��Top=�6z   $	��213��6�   $��18(�6�   �� 5   
   -	   5        $ lbl_much��5      $
��Left=�6#   $��28��6>   $��474,302,0,0q�6J   $	��Top=�6_   $��92��6w   5       5#      