﻿using System;

namespace TheTieSilincer.Models.Bullets
{
    public class MSBullet : Bullet
    {
        private const char bulletType = 'x';

        public MSBullet(int x, int y) : base(x, y)
        {
        }

        public override void DrawBullet()
        {
            Console.SetCursorPosition(Position.Y, Position.X);
            Console.WriteLine(bulletType);
        }

        public override bool InBounds()
        {
            if (Position.X == Console.WindowHeight - 2)
            {
                return false;
            }

            return true;
        }

        public override void UpdatePosition()
        {
            this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
            this.Position.X++;
        }
    }
}