   M S B A M L   `   `   `  ����  
lab2prn222    FetchDataApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Fetch Data from URL��5   	   $	��400��6%   $	��600��62   .��5      � $��10q�6   .+�5   
   �� -   5        $��
UrlTextBox��5      $	��400��6$   $��30��60   $
��Left=�6<   $	��Top=�6W   $��0,10,0,0q�6o   .��6�   ��5      �� 5	       �� 
TargetType" ��6   .�5
      ��  �� Property � �� �� Value
 �   �63    �� Triggers 5      P� 5       P� Property � �� P� Value$  ��62   . �5      ��  � ��
 �����6;   5      5      .��5      5      �� 5   
   -   5        $��FetchButton��5      $��
Fetch Data��6$   $	��100��69   $��30��6E   $
��Left=�6Q   $	��Top=�6l   $��
420,10,0,0q�6�   6�   �� 5   
   -   5        $��OutputTextBox��5      $	��550��6'   $	��200��63   $
��Left=�6@   $	��Top=�6[   $��0,50,0,0q�6s    �� AcceptsReturn$
 True��6�    �� 
IsReadOnly$
 True��6�   "	 �� VerticalScrollBarVisibility$
	 Auto=�6�   �� 5   
   -   5        $��ClearButton��5      $��Clear��6$   $	��100��64   $��30��6@   $
��Left=�6L   $	��Top=�6g   $��	0,270,0,0q�6   6�   �� 5   
   -   5        $��CloseButton��5      $��Close��6$   $	��100��64   $��30��6@   $
��Left=�6L   $	��Top=�6g   $��420,270,0,0q�6   6�   5       5!      