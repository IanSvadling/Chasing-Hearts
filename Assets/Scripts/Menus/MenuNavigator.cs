using System.Collections.Generic;

public class MenuNavigator
{
    private Stack<MenuType> menuHistory;
    private MenuType currentMenu;

    public MenuType CurrentMenu
    {
        get
        {
            return currentMenu;
        }
    }

    public int HistoryCount
    {
        get
        {
            return menuHistory.Count;
        }
    }

    // constructor
    public MenuNavigator() 
    {
        // initialize the navigator on Main
        menuHistory = new Stack<MenuType>();
        currentMenu = MenuType.Main; 
    }

    public void OpenMenu(MenuType menu)
    {
        // 1. ignore the request if menu is already active
        // 2. Save the current menu
        // 3. Open the requested menu
        if(menu != currentMenu)
        {
            menuHistory.Push(currentMenu);
            currentMenu = menu;
        } 
    }

    public bool GoBack()
    {
        // 1. return to the previous menu, when possible
        // 2. return true if navigation occurred
        if(menuHistory.Count > 0)
        {
            currentMenu = menuHistory.Pop();
            return true;
        } 
        return false;
    }

    public void Reset()
    {
        // clear history and return to Main
        menuHistory.Clear();
        currentMenu = MenuType.Main;
    }
}