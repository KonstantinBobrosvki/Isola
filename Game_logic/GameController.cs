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

        public bool Game_ended = false;
        public enum Turn_State
        {
            Move=1,
            Block=2
        }

        public Turn_State Current_State { get; private set; }

        public Player Current_Player { get; private set; }

        public GameController(Player one,Player two,Game_board board)
        {
            Player_One = one;
            Player_Two = two;

            Random rnd = new Random();

            Current_Player = Player_One;

            Board = board;

            while (Player_One.X==Player_Two.X && Player_Two.Y == Player_One.Y)
            {
                Player_One.X = rnd.Next(0, Board.Size);
                Player_One.Y = rnd.Next(0, Board.Size);
                Player_Two.X = rnd.Next(0, Board.Size);
                Player_One.Y = rnd.Next(0, Board.Size);
            }
            

            
        }

        public void BlocTile(int x,int y)
        {
            if (Current_State != Turn_State.Block)
                throw new Exception("NOT BLOCK STATE");
            ChangeState();
            ChangePlayer();
            
        }

        public void Player_Move(int x, int y)
        {
            if(Current_State!=Turn_State.Move)
                throw new Exception("NOT MOVE STATE");

            if (x > 50 || x < 0 || y > 50 || y < 0)
                throw new ArgumentOutOfRangeException();

            Player p = Current_Player;

            Board[p.X, p.Y] = Game_board.Tile_State.Free;

            p.X = x;
            p.Y = y;

            Board[p.X, p.Y] = Game_board.Tile_State.Player;

            ChangeState();
        }

        public event EventHandler Current_Player_Changed;
        public event EventHandler Current_State_Changed;

        public event EventHandler Current_State_Lose;


        private void ChangeState()
        {
            Current_State = Current_State == Turn_State.Block ? Turn_State.Move : Turn_State.Block;
            Current_State_Changed?.Invoke(this, new EventArgs());
        }

        private void ChangePlayer()
        {
            Current_Player = Current_Player == Player_One ? Player_Two : Player_One;

          if(Check_Lose())
          {
                Current_State_Lose?.Invoke(this, new EventArgs());
                Game_ended = true;
                return;
          }

            Current_Player_Changed?.Invoke(this, new EventArgs());

        }

        public bool Check_Lose()
        {

            for (int x_offset = -1; x_offset < 2; x_offset++)
            {
                for (int y_offset = -1; y_offset < 2; y_offset++)
                {
                    if (Current_Player.X + x_offset < 0 || Current_Player.Y + y_offset < 0)
                        continue;
                  var cell= Board[Current_Player.X + x_offset, Current_Player.Y + y_offset];
                    if (cell == Game_board.Tile_State.Free)
                        return false;

                    
                }
            }

            return true;
        }
    }
}
