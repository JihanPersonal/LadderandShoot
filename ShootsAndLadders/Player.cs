using System;
using System.Collections.Generic;
using System.Text;

namespace ShootsAndLadders
{
    public class Player
    {
        public Player()
        {
            currentPostion = 0;
        }
        private int currentPostion;
        public int CurrentPostion
        {
            get
            {
                return currentPostion;
            }
            set
            {
                currentPostion = value;
            }
        }
        private int Number;

        public int GetNumber()
        {
            return Number;
        }

        public void SetNumber(int value)
        {
            Number = value;
        }

        //Player call the core logic of game to update its position
        public void Play(Game game)
        {
            game.MovePlayer(this);
        }
    }
}
