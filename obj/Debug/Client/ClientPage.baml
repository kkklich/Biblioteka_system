   M S B A M L   `   `   `  ����L  HBiblioteka_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Biblioteka_system.ClientBiblioteka_system.Client  5      )    #Biblioteka_system.Client.ClientPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Biblioteka_system.Client     5        N� Title$  	Książki��5	      .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Klienci��6   $
��Left=�61   $��67��6L   $��
344,10,0,0q�6X   $	��Top=�6l   $	��120��6�   $��36(�6�   ���	#FF5A8B50$��Sitka Heading)�6�   �� 5   
   -   5        $ label2��5      $��Wyszukaj klienta:��6    $
��Left=�6<   $��29��6W   $��
10,288,0,0q�6c   $	��Top=�6w   $	��112��6�   �� 5   
   -   5         ��Name$ 
txt_search��5      $
��Left=�6&   $��30��6A   $��
10,322,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��148��6�   6�   �� 5   
   -   5         ��Name$ listView��5      $
��Left=�6%   $	��206��6@   $��	10,77,0,0q�6M   $	��Top=�6`   $	��527��6x    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$
 auto��6[    �� DisplayMemberBinding 61   �� *
IdClient+6[   �� 5      $
��Imie��6%   $
 auto��6_    63   �� *	Firstname+6_   �� 5      $��Nazwisko��6%   $
 auto��6b    68   �� *
Surename+6b   �� 5      $��Numer telefonu��6%   $
 auto��6h    6>   �� *	NrPhone+6h   �� 5      $��Uwagi��6%   $
 auto��6Z    64   �� *Info+6Z   �� 5      $��Ilość książek��6%   $
 auto��6g    6<   �� *
quantity+6g   5      5      �� 5   
   -   5         ��Name$ btn_dodaj_klienta��5      $��Dodaj klienta��6,   $
��Left=�6D   $��35��6_   $��
587,93,0,0q�6k   $	��Top=�6   $	��173��6�   6�   �� 5   
   -   5        $ btn_edytuj_klienta��5      $��Edytuj klienta ��6-   $
��Left=�6G   $��35��6b   $��587,145,0,0q�6n   $	��Top=�6�   $	��173��6�   6�   �� 5   
   -   5        $ btn_usun_klienta��5      $��Usuń klienta ��6+   $
��Left=�6C   $��35��6^   $��587,200,0,0q�6j   $	��Top=�6   $	��173��6�   6�   �� 5    
   -   5        $ 	lbl_ilosc��5       $
��Left=�6$   $��29��6?   $��487,288,0,0q�6K   $	��Top=�6`   $��50��6x   5!      5"      