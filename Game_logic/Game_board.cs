using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_logic
{
    public class Game_board
    {
        public enum Tile_State
        {
            Free=1,
            Blocked=2,
            Player=4
        }

        public int Size { get; }

        public Tile_State[,] Board { get; private set; }

        public Game_board (int size)
        {
            if (size > 50 || size <= 1 || size % 2 == 0)
                throw new ArgumentException("Size is not correct");

            Board = new Tile_State[size, size];
        }
    }
}
