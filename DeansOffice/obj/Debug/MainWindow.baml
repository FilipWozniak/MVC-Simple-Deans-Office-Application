   M S B A M L   `   `   `  ����G  CDeansOffice5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DeansOffice5DeansOffice5  5   	       DeansOffice5.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:DeansOffice5     5   	     � Title$  Deans Office��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��2* �6   �� 5      $��10 �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6    $��24(�6-   .��6;   Students' List6K   &   System.Windows.Controls.DataGrid  5   
   -   5        $��StudentDataGrid��5   �      CanUserAddRows .     
IsReadOnly .    CanUserDeleteRows .  $��1��6V   $��0��6c   $��4��6s      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *	FirstName+  5      $ 	Last Name��6%   	 68   �� *
LastName+  5      $ Index Number��6%   	 6;   �� *IndexNumber+  5      $ Studies��6%   	 66   �� *
Study.Name+5      �� 5   
   -   5        $��rowcount��5      $��2��6    $��0��6-   .��6=   You chose x rows.6P   �� 5   
   -   5        $��2��5      $��1��6   $
��20 2q�6C   .��6Q   Add6V   �� 5    
   -   5        $��2��5       $��3��6   $
��20 2q�6E   .��6S   Delete6[   5!      5"      