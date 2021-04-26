using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.Classes
{
    public class InitialGrid : Grid
    {
        Random random = new Random();
        //public List<Square> grid;
        //public List<Square> shipsSquares;
        //public List<Square> hitSquares;

        public InitialGrid() : base()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    for(int j = 0; j<10; j++)
            //    {
            //        grid.Add(new Square(i, j));
            //    }
            //}
            ShipPlacement(2);
            ShipPlacement(3);
            ShipPlacement(3);
            ShipPlacement(4);
            ShipPlacement(5);

        }
        public void ShipPlacement(int size)
        {
            int x = random.Next(1, 11);
            int y = random.Next(1, 11);
            int direction = random.Next(0, 2);
            //0 horizontal
            //1 vertical

            if (direction == 0 && x + size <= 10)
            {
                //checks if squares are occupied
                foreach (Square item in shipsSquares.ToList())
                {
                    for (int i = 0; i < size; i++)
                    {
                        if ((x + i) == item.Getx() && (y) == item.Gety())
                        {
                            //if "yes" picks new spot
                            ShipPlacement(size);
                            return;
                        }
                    }
                }


                for (int i = 0; i < size; i++)
                {
                    shipsSquares.Add(new Square(x + i, y));
                }
            }
            else if (direction == 1 && y + size <= 10)
            {
                //checks if squares are occupied
                foreach (Square item in shipsSquares.ToList())
                {
                    for (int i = 0; i < size; i++)
                    {
                        if ((y + i) == item.Gety() && (x) == item.Getx())
                        {
                            //if "yes" picks new spot
                            ShipPlacement(size);
                            return;
                        }
                    }
                }

                for (int i = 0; i < size; i++)
                {
                    shipsSquares.Add(new Square(x, y + i));
                }
            }
            else
            {
                ShipPlacement(size);
                return;
            }
        }
    }
}
