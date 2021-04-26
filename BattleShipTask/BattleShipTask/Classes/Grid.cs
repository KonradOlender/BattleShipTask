using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.Classes
{
    public class Grid
    {
        Random random = new Random();
        
        //List of every square in the grid
        public List<Square> grid { get; set; }
        //List of squares that ships occupy
        public List<Square> shipsSquares { get; set; }
        //List of squares that was already hit
        public List<Square> hitSquares { get; set; }

        public Square lastHit, firstHit;

        public bool gameOver { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public int direction = 0;
        //0 - nothing
        //1 - up
        //2 - down
        //3 - right
        //4 - left
        public Square hitSquare;

        public Grid()
        {
            grid = new List<Square>();
            shipsSquares = new List<Square>();
            hitSquares = new List<Square>();

            gameOver = false;
        }

        //Places ships of size = size on the random spot on the grid
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
                //if "no" add squares to shipsSquares List and set that square to occupied in gridList
                for (int i = 0; i < size; i++)
                {
                    shipsSquares.Add(new Square(x + i, y));
                    SetOccupiedGrid(x + i, y);
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
                //if "no" add squares to shipsSquares List and set that square to occupied in gridList
                for (int i = 0; i < size; i++)
                {
                    shipsSquares.Add(new Square(x, y + i));
                    SetOccupiedGrid(x, y + i);
                }
            }
            else
            {
                ShipPlacement(size);
                return;
            }
        }

        public void shot()
        {
            //if direction = 0: pick random square
            if (direction == 5)
                direction = 0;

            if (direction == 0)
            {
                x = random.Next(1, 11);
                y = random.Next(1, 11);
            }
            //if direction = 1: pick square 1 up from last hit
            //up
            else if (direction == 1)
            {
                if (lastHit.Gety() - 1 < 1)
                {
                    lastHit = firstHit;
                    direction++;
                    shot();
                    return;
                }
                x = lastHit.Getx();
                y = lastHit.Gety() - 1;

            }
            //if direction = 2: pick square 1 down from last hit
            //down
            else if (direction == 2)
            {
                if (lastHit.Gety() + 1 > 10)
                {
                    lastHit = firstHit;
                    direction++;
                    shot();
                    return;
                }
                x = lastHit.Getx();
                y = lastHit.Gety() + 1;
            }
            //if direction = 3: pick square 1 right from last hit
            //right
            else if (direction == 3)
            {
                if (lastHit.Getx() + 1 > 10)
                {
                    lastHit = firstHit;
                    direction++;
                    shot();
                    return;
                }
                x = lastHit.Getx() + 1;
                y = lastHit.Gety();
            }
            //if direction = 4: pick square 1 left from last hit
            //left
            else if (direction == 4)
            {
                if (lastHit.Getx() - 1 < 1)
                {
                    lastHit = firstHit;
                    direction++;
                    shot();
                    return;
                }
                x = lastHit.Getx() - 1;
                y = lastHit.Gety();
            }

            foreach (Square item in hitSquares.ToList())
            {
                //checks if this space was hit already
                if (x == item.Getx() && y == item.Gety())
                {
                    //if "yes" shoot agine
                    if (direction != 0)
                    {
                        lastHit = firstHit;
                        direction++;
                    }
                        
                    shot();
                    return;
                }
            }

            //if "no" add this square to hitSquares List and mark is as hit in grid List
            hitSquares.Add(new Square(x, y));
            SetHitGrid(x, y);

            hitSquare = Find();

            //hit
            if (hitSquare != null)
            {
                hitSquare.SetHit(true);
                lastHit = hitSquare;
                if (direction == 0)
                {
                    firstHit = hitSquare;
                    direction = 1;
                }

            }
            //miss
            else
            {
                if (direction == 0)
                    direction = 0;
                else
                {
                    lastHit = firstHit;
                    direction++;
                }

            }

        }

        public void CheckGameOver()
        {
            if (GameOver())
            {
                gameOver = true;
            }
        }

        //if every suqare from shipsSquares id hit: return true
        public bool GameOver()
        {
            foreach (Square item in shipsSquares.ToList())
            {
                if(item.hit == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void SetOccupiedGrid(int x, int y)
        {
            foreach (Square item in grid.ToList())
            {
                if (x == item.Getx() && y == item.Gety())
                {
                    item.SetOccupied(true);
                }
            }
        }

        public void SetHitGrid(int x, int y)
        {
            foreach (Square item in grid.ToList())
            {
                if (x == item.Getx() && y == item.Gety())
                {
                    item.SetHit(true);
                }
            }
        }

        //finds and returns square from shipsSquares List
        public Square Find()
        {
            foreach (Square item in shipsSquares.ToList())
            {
                if (x == item.Getx() && y == item.Gety())
                {
                    return item;
                }
            }
            return null;
        }



        public void Init()
        {
            for (int i = 1; i<11; i++)
            {
                for (int j = 1; j<11; j++)
                {
                    grid.Add(new Square(i, j));
                }
            }
            ShipPlacement(2);
            ShipPlacement(3);
            ShipPlacement(3);
            ShipPlacement(4);
            ShipPlacement(5);
        }
    }
}
