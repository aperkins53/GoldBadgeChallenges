using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch1_Cafe
{
    public class MenuRepository
    {
        //methods go here
        private List<Menu> _menuItems = new List<Menu>();

        //add menu item
        public void AddItemToMenu(Menu menu)
        {
            _menuItems.Add(menu);
        }

        //print menu
        public List<Menu> GetMenuItems()
        {
            return _menuItems;
        }

        //delete menu item
        public bool DeleteItemFromMenu(int itemNumber)
        {
            Menu item = GetItemByNumber(itemNumber);

            if(item == null)
            {
                return false;
            }

            int initialCount = _menuItems.Count;
            _menuItems.Remove(item);

            if (initialCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //helper method (checks to see if item number is correct and returns it)
        public Menu GetItemByNumber(int itemNumber)
        {
            foreach(Menu item in _menuItems)
            {
                if(item.MealNumber == itemNumber)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
