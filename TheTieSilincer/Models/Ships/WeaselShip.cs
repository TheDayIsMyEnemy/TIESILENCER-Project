﻿using System;
using System.Collections.Generic;
using System.Linq;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models.Ships
{
    public class WeaselShip : EnemyShip
    {
        // \(|X|)/
        //    V

        public WeaselShip(List<Weapon> weapons) : base(weapons)
        {
            this.CollisionAOE = 5;
        }

        public override void ClearShip(bool destroyed = false)
        {
            if (this.PreviousPosition != null)
            {
                Console.SetCursorPosition(this.PreviousPosition.Y, this.PreviousPosition.X);
                Console.WriteLine(@"       ");
                Console.SetCursorPosition(this.PreviousPosition.Y + 3, this.PreviousPosition.X + 1);
                Console.WriteLine(" ");                
            }

            if(destroyed)
            {
                Console.SetCursorPosition(this.Position.Y, this.Position.X);
                Console.WriteLine(@"       ");
                Console.SetCursorPosition(this.Position.Y + 3, this.Position.X + 1);
                Console.WriteLine(" ");
            }
        }

        public override void DrawShip()
        {                               
            Console.SetCursorPosition(this.Position.Y, this.Position.X);
            Console.WriteLine(@"\(|X|)/");
            Console.SetCursorPosition(this.Position.Y+3, this.Position.X+1);
            Console.WriteLine("V");
        }

        public override void UpdateShip(Position nextDirection)
        {

            if(this.MovementTime % 2 == 0)
            {
                this.PreviousPosition = new Position(this.Position.X, this.Position.Y);
                this.Position.X++;           
            }

            this.MovementTime += 0.50;
        }

        public override bool InBounds(Position nextDirection)
        {
            if (Position.X == Console.WindowHeight - 2)
            {
                return false;
            }

            return true;
        }

        public override void GenerateBullets()
        {
            Weapon w = Weapons.First();
            w.AddBullets(this.Position.X + 2, this.Position.Y + 3);
        }
    }
}
