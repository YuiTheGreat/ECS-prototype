﻿using ECS_Proto.Core.GUI;
using ECS_Proto.Core.Input;
using ECS_Proto.Core.Render;
using ECS_Proto.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECS_Proto.Core
{
    class MainTick
    {
        GameObjectManager goManager;
        RenderManager renderManager;
        InputBridge inputBridge;
        GameManager gameManager;
        UIManager uiManager;
        public MainTick()
        {
            goManager = new Core.GameObjectManager();
            renderManager = new Render.RenderManager(goManager);
            inputBridge = new Input.InputBridge(renderManager);
            gameManager = new Game.GameManager();
            uiManager = new GUI.UIManager();
            renderManager.SetUIManager(uiManager);
            Update();
        }
        double computedDeltaTime = 0;
        double targetFPS = 60;
        void Update()
        {
            while (true)
            {
                DateTime start = DateTime.Now;
                // Do stuff
                gameManager.Update((float)computedDeltaTime);
                goManager.Update((float)computedDeltaTime);
                uiManager.Update((float)computedDeltaTime);
                renderManager.Update();
                DateTime end = DateTime.Now;

                computedDeltaTime = (end - start).TotalSeconds;
                if (computedDeltaTime < 1.00 / targetFPS)
                {
                    Thread.Sleep((int)((1.00 / targetFPS - computedDeltaTime) * 1000));
                    computedDeltaTime = (1.00 / targetFPS);
                }
            }
        }
    }
}
