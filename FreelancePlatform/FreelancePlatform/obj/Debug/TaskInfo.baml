   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FreelancePlatformFreelancePlatform  5           FreelancePlatform.TaskInfo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:FreelancePlatform     5        N? Title$  TaskInfo??5	      .??5      ? 
??????? ? RowDefinitions 5   
   ?? 5      $
??0.5* ?6   ?? 5      ?? 5      ?? 5      .+?5   
   ? $??0??6    ? ColumnDefinitions 5      ?? 5      $
??2.5* ?6#   ?? 5      .+?5      ?? -   5        $??TaskInfoTitle??5      $??0??6-   Title6D   ?? 5      $??1??6   $
??left=?6)   .+?5      ?? -   5        $??CreatedTimeInfo??5      Created Time:6C   ?? 5      -   5        $??DeadlineTimeInfo??5      Deadline Time:6D   5      5       ?? 5!   
   -   5        $??AboutTaskInfo??5!      $??1??6)   About6=   ?? 5"   
   $??2??6    ?? Orientation$ 
Horizontal=?6"   $
??Left=?6;   $	??600??6V   .+?5#      ?? -   5        $??SkillsTaskInfo??5#      $??2??6.    ?? TextAlignment$
 Left=?6;   Skills6X   5$      ?? 5%   
   $??2??6   $ Vertical=?6"   $??Center=?69   $??Right=?6T   $	??200??6p   .+?5&      ?? -   5        $??CustomerTaskInfo??5&      
Customer6:   ?? 5'      -   5        $??ExecutorTaskInfo??5'      
Executor6:   ?? 5(      -   5        $??PriceTaskInfo??5(      Price64   ?? 5)      -	   5        $??ActiveTaskInfo??5)      Active66   5*      5-      5.      