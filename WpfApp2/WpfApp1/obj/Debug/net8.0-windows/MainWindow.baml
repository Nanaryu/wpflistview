   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   o� -   5         o�Name$
 menu��5
      $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� -   5        $	��New��5      6(   m� 5      -   5        $
��Open��5      6)   m� 5      -   5        $
��Save��5      6)   �� 5      m� 5      -   5        $
��Exit��5      6)   5      m� 5      $
��Edit��6   .@�5      m� -   5        $��Remove Selected��5      64   5      5      �� 5   
   -   5         ��Name$ mainList��5      $��	0,20,0,20q�6%    � 	Resources 5       �� 
TargetType �� Property �� Value��%#  '��       '�� �     �� 5      " ��6   .�5      ��  � ��$
 Left=�6C   �� 5       � ��$ 5,0,0,0q�60   �� 5       � ��$ 0,0,0,0q�6/   5      �� 5      " ��6   .�5      ��  � ��$
 Left=�6C   �� 5       � ��$ 5,0,0,0q�60   5       5!       �� View 5"      �� 5#      .P�5$      �� $��PESEL��6%    �� Width$	 100��6`   	 �� DisplayMemberBinding	 64   �� *
m_strPESEL+6`   �� 5%      $��Imię��6%   $	 100��6^   	 63   �� *	m_strName+6^   �� 5&      $��Drugie imię��6%   $	 100��6h   	 6:   �� *m_strSecName+6h   �� 5'      $��Nazwisko��6%   $	 100��6f   	 67   �� *m_strLastName+6f   �� 5(      $��Data urodzenia��6%   $	 100��6i   	 6=   �� *
m_strBirth+6i   �� 5)      $��Telefon��6%   $	 100��6b   	 66   �� *
m_strPhone+6b   �� 5*      $��Adres��6%   $	 100��6_   	 64   �� *	m_strAddr+6_   �� 5+      $��Miejscowość��6%   $	 100��6e   	 6:   �� *	m_strTown+6e   �� 5,      $��Kod pocztowy��6%   $	 100��6e   	 6;   �� *
m_strPst+6e   5-      5/      51      52      