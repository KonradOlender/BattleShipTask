using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.Classes
{
    public class Square
    {
        public int x { get; set; }
        public int Getx()
        {
            return x;
        }
        public int y { get; set; }
        public int Gety()
        {
            return y;
        }
        public bool hit { get; set; }
        public bool IsFit()
        {
            return hit;
        }
        public void SetHit(bool b)
        {
            hit = b;
        }

        public bool occupied { get; set; }
        public void SetOccupied(bool b)
        {
            occupied = b;
        }

        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;
            hit = false;
        }
    }
}
