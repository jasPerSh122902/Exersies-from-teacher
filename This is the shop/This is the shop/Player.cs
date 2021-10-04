using System;
using System.Collections.Generic;
using System.Text;

namespace This_is_the_shop
{
    class Player
    {
        private Item[] _items;
        private Item _currentItem;
        private int _currentItemIndex;
       

        
        public string[] GetItemNames()
        {
            string[] itemNames = new string[_items.Length];

            for (int i = 0; i < _items.Length; i++)
            {
                itemNames[i] = _items[i].Name;
            }

            return itemNames;
        }

        public bool TryToBuyItem(int Index)
        {
            if (Index >= _items.Length || Index <0)
                return false;
            _currentItemIndex = Index;

            _currentItem = _items[_currentItemIndex];

            return true;

        }
        public Player(string name, float health, float attackPower, float defensePower, Item[] items)
        {
            _items = items;
            _currentItem.Name = "Nothing";
            _currentItemIndex = -1;
        }

    }
}




    

