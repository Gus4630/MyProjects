   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FreelancePlatformFreelancePlatform  5      "    FreelancePlatform.CreateTask   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:FreelancePlatform     5        N? Title$  
CreateTask??5	      .??5      ? 
??????? ? RowDefinitions 5   
   ?? 5      $
??0.5* ?6   ?? 5      ?? 5      ?? 5      .+?5   
   ? $??0??6    ? ColumnDefinitions 5      ?? 5      $
??2.5* ?6#   ?? 5      .+?5      ?? -   5        $??TaskInfoTitle??5      $??0??6+   $	??400??6;   $??30??6G   .??6S   Title6Z   ?? 5      $??1??6   $
??left=?6)   .+?5      ?? -   5        $??CreatedTimeInfo??5      .??62   Created Time:6A   ?? 5      -   5        $??DeadlineTimeInfo??5      .??62   Deadline Time:6B   5      5       ?? 5!   
   -   5        $??AboutTaskInfo??5!      $	??100??6'   $	??700??64   $??Center=?6@   $??1??6d   .??6q   About6x   ?? 5"   
   $??2??6    ?? Orientation$ 
Horizontal=?6"   $
??Left=?6;   $	??600??6V   .+?5#      ?? -   5        $??SkillsTaskInfo??5#   /   $	??100??6   $	??400??6#   $??2??6E    ?? TextAlignment$
 Left=?6R   .??6g   Skills6o   5$      ?? 5%   
   $??2??6   $ Vertical=?6"   $??Center=?69   $??Right=?6T   $	??200??6p   .+?5&      ?? -   5        $??PriceTaskInfo??5&      .??6+   Price62   ?? 5'      -   5        $??ActiveTaskInfo??5'      .??6,   Active64   5(      ?? 5)   
   -   5        $??3??5)      $	??200??6   $??Center=?6*   .??6Z   Submit6c   5,      5.      