﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Snake.GameLogic
{
    public class Snake
    {
        public int x;
        public int y;
        public int direction; //-2 Up, 2 Down, -1 left, 1 right
        public List<Vector2> tail = new List<Vector2>();
        public bool isAlive;
        //int direction, List<Vector2> snake
        public Snake()
        { 
        }
    }
}