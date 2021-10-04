using System;
using System.Collections.Generic;
using System.Text;

namespace This_is_the_shop
{
    public struct Item
    {
        public string Name;
        public float Gold;
    }
    class Game
    {
        private Item[] _playerItems;
        private bool _gameOver;
        private int  _currentScene;
        private string _playerName;
        public void Run()
        {

        }

        

        public void ShopItems()
        {
            Item bigGun = new Item { Name = "Big Gud", Gold = 17 };
            Item bigShield = new Item { Name = "Big Shield", Gold = 10 };

            //Raider items
            Item bigAxe = new Item { Name = "Big Axe ", Gold = 15 };
            Item forceShield = new Item { Name = "Force Shield ", Gold = 20 };

            _playerItems = new Item[] { bigGun, bigShield, bigAxe, forceShield };
        }

        public void Update()
        {
            DisplayCurrentScene();
        }

        public void DisplayCurrentScene()
        {
            //most lily be a switch
        }

        public void DisplayOpeningMenu()
        {
            //Will display the player and get 
            //and set current scene
        }

        public void GetShopMenuOptions()
        {
            //this will be the shop and so just make the play have the item all ready but play to use them
            //the shop is just text
        }

        public void DIsplayShopMenu()
        {
            //Persily like the getshop menu
        }
 
    }
}
