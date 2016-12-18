using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boweling.Service
{
    public class GameService
    {
        int[] Rolled = new int[22]; // 20 + 2 ponus
        int currentBall = 0;


        public void Roll(int pins)
        {
            Rolled[currentBall] = pins;
            currentBall++;
        }

        public int Score
        {
            get
            {
                int score = 0;
                int thisBall = 0;

                for (int i = 0; i < 10; i++)
                {
                    if (IsStrike(thisBall))
                    {
                        score += 10 + Rolled[thisBall + 1] + Rolled[thisBall + 2];
                        thisBall++;
                    }
                    else if (IsSpare(thisBall))
                    {
                        score += 10 + Rolled[thisBall + 2];
                        thisBall += 2;
                    }
                    else // Open Frame
                    {
                        score += Rolled[thisBall] + Rolled[thisBall + 1];
                        thisBall += 2;
                    }
                }
                return score;
            }
        }

        private bool IsSpare(int thisBall)
        {
            return Rolled[thisBall] + Rolled[thisBall + 1] == 10;
        }

        private bool IsStrike(int thisBall)
        {
            return Rolled[thisBall] == 10;
        }
    }
}
