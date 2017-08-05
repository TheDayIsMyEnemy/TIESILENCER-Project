﻿using System;

namespace TheTieSilincer.Core
{
    using TheTieSilincer.Collisions;
    using TheTieSilincer.Enums;
    using TheTieSilincer.Support;
    using TheTieSilincer.Core.Managers;
    using TheTieSilincer.Models.Satellite;

    public class Game
    {
        private Satellite satellite;

        private ShipManager shipManager;
        private PlayerManager playerManager;

        private BulletManager bulletManager;

        private BulletCollision bulletCollision;
        private ShipCollision shipCollision;

        public Game()
        {
            this.satellite = new Satellite();
            this.shipManager = new ShipManager();
            this.playerManager = new PlayerManager();
            this.bulletManager = new BulletManager();
            this.bulletCollision = new BulletCollision(shipManager, playerManager);
            this.shipCollision = new ShipCollision(shipManager);
            this.shipManager.GenerateShips();
            this.playerManager.CreatePlayer(shipManager.BuildShip(ShipType.PlayerShip));

            this.satellite.StartTransmittingMessages(playerManager, shipManager, bulletManager);
        }

        public void Clear()
        {
            playerManager.Clear();
            shipManager.Clear();
            bulletManager.Clear();
        }

        public void CheckForCollisions()
        {
            bulletCollision.CheckForCollisions(BulletManager.bullets);
            shipCollision.CheckForCollisions();
        }

        public void Update()
        {
            playerManager.Update();
            shipManager.Update();
            bulletManager.Update();
        }

        public void Draw()
        {
            playerManager.Draw();
            shipManager.Draw();
            bulletManager.Draw();
        }

        public void InitialiseSettings()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowHeight = Constants.WindowHeight;
            Console.WindowWidth = Constants.WindowWidth;
            Console.BufferHeight = Constants.WindowHeight;
            Console.BufferWidth = Constants.WindowWidth;

            playerManager.Draw();
        }
    }
}