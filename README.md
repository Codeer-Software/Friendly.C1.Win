Friendly.C1.Win
============================

This library is a layer on top of
Friendly, so you must learn that first.
But it is very easy to learn.

https://github.com/Codeer-Software/Friendly.Windows 

## Getting Started
Install Friendly.C1.Win from NuGet

    Install-Package Friendly.C1.Win
https://www.nuget.org/packages/Friendly.C1.Win/

***
Friendly.C1.Win defines the following classes.   
They can operate the control easily from a separate process.  

* C1FlexGridDriver

***
```cs  
//sample  
var process = Process.GetProcessesByName("Target")[0];  
using (var app = new WindowsAppFriend(process))  
{  
    dynamic main = app.Type(typeof(Application)).OpenForms[0];  
    var grid = new C1FlexGridDriver(main._grid);
    
    //select cell.
    grid.EmulateSelect(1, 2);
    grid.EmulateSelect(1, 2, 5, 3);
    
    //get selection.
    int row = grid.Row;
    int col = grid.Col;
    int rowSel = grid.RowSel;
    int colSel = grid.ColSel;
    
    //add row selection.
    grid.EmulateAddSelectedRow(2);
    grid.EmulateAddSelectedRow(3);
    
    //get row selection.
    int[] rows = grid.SelectedRows;
    
    //get cell text.
    grid.GetCellText(1, 2);
    grid.GetCellTexts(0, 0, 2, 4);
    
    //get cell object.
    //it can use for serializasble objects.
    grid.GetCellObjects(0, 0, 2, 4);
    grid.GetCellObject(1, 2);
    
    //edit.
    grid.EmulateEditText("1-1");
    grid.EmulateEditCombo(2);
    grid.EmulateEditCheck(false);
}  
```
### More samples.
https://github.com/Codeer-Software/Friendly.C1.Win/tree/master/Project/Test

***
For other GUI types, use the following libraries:

* For Win32.  
https://www.nuget.org/packages/Codeer.Friendly.Windows.NativeStandardControls/  

* For WinForms.  
https://www.nuget.org/packages/Ong.Friendly.FormsStandardControls/  

* For WPF.  
https://www.nuget.org/packages/RM.Friendly.WPFStandardControls/  

* For getting the target window.  
https://www.nuget.org/packages/Codeer.Friendly.Windows.Grasp/  

* For 3d party.  
https://www.nuget.org/packages/Friendly.XamControls/  
https://www.nuget.org/packages/Friendly.C1.Win/  
https://www.nuget.org/packages/Friendly.FarPoint/  

***
If you use PinInterface, you map control simple.  
https://www.nuget.org/packages/VSHTC.Friendly.PinInterface/

