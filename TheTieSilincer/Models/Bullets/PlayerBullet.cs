﻿using System;

namespace TheTieSilincer.Models.Bullets
{
    using System.Collections.Generic;

    public class PlayerBullet : Bullet
    {
        private const char bulletType = '^';

        public PlayerBullet(int x, int y) : base(x, y)
        {
        }

        public override void UpdatePositionByX()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X--;
        }

        public override void UpdatePositionByY(List<Position> positions)
        {

        }

        public override void DrawBullet()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.WriteLine(bulletType);
        }

        public override bool InBounds()
        {
            if(Position.X > 0)
            {
                return true;
            }

            return false;
        }
    }
}
