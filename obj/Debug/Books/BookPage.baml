   M S B A M L   `   `   `  ����L  HBiblioteka_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Biblioteka_systemBiblioteka_system  5          Biblioteka_system.Page2   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Biblioteka_system     5        N� Title$  Page2��5	   	   .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��	Książki��6   $
��Left=�61   $��67��6L   $��
344,10,0,0q�6X   $	��Top=�6l   $	��120��6�   $��36(�6�   ���	#FF5A8B50$��Sitka Heading)�6�   �� 5   
   -   5        $ label2��5      $��Wyszukaj książkę:��6    $
��Left=�6<   $��29��6W   $��
10,288,0,0q�6c   $	��Top=�6w   $	��112��6�   �� 5   
   -   5         ��Name$ txt_szukaj_ksiazke��5      $
��Left=�6.   $��30��6I   $��
10,322,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��148��6�   6�   �� 5   
   -   5         ��Name$ listView_ksiazka��5      $
��Left=�6.   $	��206��6I   $��	10,77,0,0q�6V   $	��Top=�6i   $	��527��6�    �� View 5      �� 5      .P�5      �� $��	idksiazki��6%    �� Width$
 auto��6c    �� DisplayMemberBinding 68   �� *IdBook+6c   �� 5      $��Tytul��6%   $
 auto��6[    64   �� *Title+6[   �� 5      $��Imię��6%   $
 auto��6`    64   �� *	Firstname+6`   �� 5      $��Nazwisko��6%   $
 auto��6a    67   �� *
SureName+6a   5      5      �� 5   
   -   5         ��Name$ btn_dodaj_ksiazke��5      $��Dodaj książkę��6,   $
��Left=�6D   $��35��6_   $��
587,93,0,0q�6k   $	��Top=�6   $	��173��6�   6�   �� 5   
   -   5        $ btn_edytuj_ksiazke��5      $��Edytuj książkę ��6-   $
��Left=�6G   $��35��6b   $��587,145,0,0q�6n   $	��Top=�6�   $	��173��6�   6�   �� 5    
   -   5        $ btn_usun_ksiazke��5       $��Usuń książkę ��6+   $
��Left=�6C   $��35��6^   $��587,200,0,0q�6j   $	��Top=�6   $	��173��6�   6�   �� 5!   
   -   5        $ btn_kolejny_autor��5!      $��Dodaj współautora��6,   $
��Left=�6H   $��35��6c   $��587,248,0,0q�6o   $	��Top=�6�   $	��173��6�   6�   �� 5"   
   -	   5        $ 	lbl_ilosc��5"      $
��Left=�6#   $��29��6>   $��490,288,0,0q�6J   $	��Top=�6_   $��47��6w   5#      5%      