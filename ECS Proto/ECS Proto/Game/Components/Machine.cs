﻿using ECS_Proto.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Components
{
    class Machine : IComponent
    {
        public override void Start()
        {
            baseObject.RequireComponent<Container>();
            baseObject.RequireComponent<Electrified>();
        }
    }
}