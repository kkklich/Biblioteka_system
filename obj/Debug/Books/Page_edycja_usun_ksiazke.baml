   M S B A M L   `   `   `  ����L  HBiblioteka_system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Biblioteka_systemBiblioteka_system  5      0    *Biblioteka_system.Page_edycja_usun_ksiazke   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Biblioteka_system     5        N� Title$  Page_edycja_usun_ksiazke��5	      .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Edytowanie książek��6   $
��Left=�6<   $��67��6W   $��
236,10,0,0q�6c   $	��Top=�6w   $	��331��6�   $��36(�6�   ���	#FF5A8B50$��Sitka Heading)�6�   �� 5   
   -   5        $ label1��5      $��Tytuł��6    $
��Left=�60   $��40��6K   $��	28,99,0,0q�6W   $	��Top=�6j   $��75��6�   �� 5   
   -   5        $ label1_Copy��5      $��Autor��6%   $
��Left=�65   $��40��6P   $��
28,144,0,0q�6\   $	��Top=�6p   $��75��6�   �� 5   
   -   5         ��Name$ 	txt_title��5      $
��Left=�6%   $��26��6@   $��135,103,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6v   $	��130��6�   �� 5   
   -   5         ��Name$ btn_EditTitle��5      $��Zmień tytuł��6(   $
��Left=�6>   $��26��6Y   $��298,103,0,0q�6e   $	��Top=�6z   $	��110��6�   6�   �� 5   
   -   5         ��Name$ 
cmb_Author��5       �� SelectedIndex$ 0��6'   $
��Left=�69   $��135,144,0,0q�6T   $	��Top=�6i   $	��130��6�   $��26��6�   ��5   
   �� 5      .R�5      �� ��5      `� 5       �� StringFormat$ {0} {1}��6'   .1�5   "   ��  �� Path$ 	FirstName�6*   �� 5   "   $ 	Surename �6*   5      5      5      5      �� 5#   
   -   5        $ btn_delete_CoAuthor��5#      $��Usuń współautora��6.   $
��Left=�6I   $��26��6d   $��298,144,0,0q�6p   $	��Top=�6�   $	��110��6�   6�   �� 5$   
   -   5        $ btn_DeleteBook��5$      $��Usuń książkę��6)   $
��Left=�6@   $��42��6[   $��298,287,0,0q�6g   $	��Top=�6|   $	��110��6�   6�   �� 5%   
   -	   5        $ btnBack��5%      $
��Back��6"   $
��Left=�61   $��33��6L   $��	28,22,0,0q�6X   $	��Top=�6k   $��55��6�   6�   5(      5)      