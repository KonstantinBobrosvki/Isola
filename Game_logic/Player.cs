﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_logic
{
    public class Player
    {
        public string Name { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public Player(string name)
        {
            Name = name;
            
        }



    }
}
