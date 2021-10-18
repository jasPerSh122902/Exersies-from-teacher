using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class PlayerHud : Actor
    {
        private Player _player;
        private UIText _health;

        //Dont know why that is sayign I have no arguments
        public PlayerHud(Player player, UIText Health)
        {
            _player = player;
            _health = Health;
        }

        public override void Start()
        {
            base.Start();
            _health.Start();

        }

        public override void Update()
        {
            _health.Text = "Lives: " + _player.Health.ToString();
        }

        public override void Draw()
        {
            _health.Draw();
        }
    }
}
