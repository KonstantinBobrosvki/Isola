using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_logic
{
    public class GameController
    {
        public Game_board Board { get; private set; }
        public Player Player_One { get; private set; }
        public Player Player_Two { get; private set; }

        public enum Turn_State
        {
            Move=1,
            Block=2
        }

        public GameController(Player one,Player two,Game_board board)
        {
            Player_One = one;
            Player_Two = two;
            Board = board;
        }

        public void BlocTile(int x,int y)
        {
            Board[x , y] = Game_board.Tile_State.Blocked;
        }

        public void Player_Move(Player p, int x, int y)
        {
            if (x > 50 || x < 0 || y > 50 || y < 0)
                throw new ArgumentOutOfRangeException();

            Board[p.X, p.Y] = Game_board.Tile_State.Free;

            p.X = x;
            p.Y = y;

            Board[p.X, p.Y] = Game_board.Tile_State.Player;

        }

    }
}
