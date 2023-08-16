using System;
using System.Collections.Generic;

namespace SeaBattle
{
    public class Field
    {
        public List<List<Cell>> GameField { get; set; }
        public List<Ship> Ships { get; set; }
        public Field()
        {
            GameField = new List<List<Cell>>();
            for (int i = 0; i < 12; i++)
            {
                GameField.Add(new List<Cell>());
                for (int j = 0; j < 12; j++)
                {
                    GameField[i].Add(new Cell());
                }
            }

            Ships = new List<Ship>();

        }

        //Вывод поля игры 
        public void ShowField()
        {
            //Border сверху
            for (int i = 0; i < GameField.Count; i++)
            {
                GameField[0][i].Type = CellType.Border;
            }
            //Border Слево
            for (int i = 0; i < GameField.Count; i++)
            {
                GameField[i][0].Type = CellType.Border;
            }
            //Border Справо
            for (int i = 0; i < GameField.Count; i++)
            {
                GameField[i][GameField.Count - 1].Type = CellType.Border;
            }
            //Border снизу
            for (int i = 0; i < GameField.Count; i++)
            {
                GameField[GameField.Count - 1][i].Type = CellType.Border;
            }
            //Вывод цифр сверху
            for (int i = 0; i < GameField.Count - 1; i++)
            {
                if (i == 0)
                {
                    Console.Write("    ");
                }
                else
                {

                    Console.Write($" {i}");
                }
            }
            Console.WriteLine();
            //Вывод поля вцелом
            for (int i = 0; i < GameField.Count; i++)
            {
                if (i < 10)
                {
                    if (i == 0)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.Write($"{i}  ");
                    }
                }
                else
                {
                    if (i == 11)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.Write($"{i} ");
                    }
                }
                for (int j = 0; j < GameField[i].Count; j++)
                {
                    //Проверка пустоты 
                    if (GameField[i][j].Type == CellType.Emptiness)
                    {

                        Console.Write("  ");


                    }
                    //Проверка Границ
                    if (GameField[i][j].Type == CellType.Border)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("▼ ");
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }
                    //Проверка раненой палубы 
                    if (GameField[i][j].Type == CellType.Padded)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("X ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    //Проверка уничтоженного судна
                    if (GameField[i][j].Type == CellType.Destroyed)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("X ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    //Проверка судна
                    if (GameField[i][j].Type == CellType.PartOfTheShip)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("■ ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    //Проверка на промах
                    if (GameField[i][j].Type == CellType.Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("* ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write("");
                }
                Console.WriteLine();
            }
        }
        //Рандомное расставление кораблей 
        public void RandomPlacementOfShips()
        {
            //Console.Beep();
            int[] array = { 4, 3, 2, 1 };
            int n = 0;
            Random random = new Random();
            while (true)
            {
                int numberX = random.Next(1, 11);
                int numberY = random.Next(1, 11);
                n = array[0] + array[1] + array[2] + array[3];
                if (n == 0)
                {
                    break;
                }

                ShipClassEnum shipClassEnum;
                shipClassEnum = (ShipClassEnum)random.Next(1, 5);
                switch (shipClassEnum)
                {
                    case ShipClassEnum.FourDeck:
                        {
                            if (array[3] != 0)
                            {
                                Ship ship = new Ship();
                                ship.Point.Add(new Point(numberX, numberY));
                                Directions directions = (Directions)random.Next(1, 5);
                                switch (directions)
                                {
                                    case Directions.Up:
                                        {
                                            for (int i = 0; i < 4; i++)
                                            {
                                                ship.Point.Add(new Point(numberX - i, numberY));
                                            }
                                        }
                                        break;
                                    case Directions.Down:
                                        {
                                            for (int i = 0; i < 4; i++)
                                            {
                                                ship.Point.Add(new Point(numberX + i, numberY));
                                            }
                                        }
                                        break;
                                    case Directions.Left:
                                        {
                                            for (int i = 0; i < 4; i++)
                                            {
                                                ship.Point.Add(new Point(numberX, numberY - i));
                                            }
                                        }
                                        break;
                                    case Directions.Right:
                                        {
                                            for (int i = 0; i < 4; i++)
                                            {
                                                ship.Point.Add(new Point(numberX, numberY + i));
                                            }
                                        }
                                        break;
                                }

                                if (IsItPossibleToPutAShip(ship))
                                {
                                    for (int i = 0; i < ship.Point.Count; i++)
                                    {
                                        GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.PartOfTheShip;
                                    }
                                    array[3] -= 1;
                                    Ships.Add(ship);
                                }

                            }
                        }
                        break;
                    case ShipClassEnum.ThreeDeck:
                        {
                            if (array[2] != 0)
                            {
                                Ship ship = new Ship();
                                ship.Point.Add(new Point(numberX, numberY));
                                Directions directions = (Directions)random.Next(1, 5);
                                switch (directions)
                                {
                                    case Directions.Up:
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {
                                                ship.Point.Add(new Point(numberX - i, numberY));
                                            }
                                        }
                                        break;
                                    case Directions.Down:
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {
                                                ship.Point.Add(new Point(numberX + i, numberY));
                                            }
                                        }
                                        break;
                                    case Directions.Left:
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {
                                                ship.Point.Add(new Point(numberX, numberY - i));
                                            }
                                        }
                                        break;
                                    case Directions.Right:
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {
                                                ship.Point.Add(new Point(numberX, numberY + i));
                                            }
                                        }
                                        break;
                                }

                                if (IsItPossibleToPutAShip(ship))
                                {
                                    for (int i = 0; i < ship.Point.Count; i++)
                                    {
                                        GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.PartOfTheShip;
                                    }
                                    array[2] -= 1;
                                    Ships.Add(ship);
                                }
                            }
                        }
                        break;
                    case ShipClassEnum.TwoDeck:
                        {
                            if (array[1] != 0)
                            {
                                Ship ship = new Ship();
                                ship.Point.Add(new Point(numberX, numberY));
                                Directions directions = (Directions)random.Next(1, 5);
                                switch (directions)
                                {
                                    case Directions.Up:
                                        {
                                            for (int i = 0; i < 2; i++)
                                            {
                                                ship.Point.Add(new Point(numberX - i, numberY));
                                            }
                                        }
                                        break;
                                    case Directions.Down:
                                        {
                                            for (int i = 0; i < 2; i++)
                                            {
                                                ship.Point.Add(new Point(numberX + i, numberY));
                                            }
                                        }
                                        break;
                                    case Directions.Left:
                                        {
                                            for (int i = 0; i < 2; i++)
                                            {
                                                ship.Point.Add(new Point(numberX, numberY - i));
                                            }
                                        }
                                        break;
                                    case Directions.Right:
                                        {
                                            for (int i = 0; i < 2; i++)
                                            {
                                                ship.Point.Add(new Point(numberX, numberY + i));
                                            }
                                        }
                                        break;
                                }

                                if (IsItPossibleToPutAShip(ship))
                                {
                                    for (int i = 0; i < ship.Point.Count; i++)
                                    {
                                        GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.PartOfTheShip;
                                    }
                                    array[1] -= 1;
                                    Ships.Add(ship);
                                }
                            }
                        }
                        break;
                    case ShipClassEnum.SingleDeck:
                        {
                            if (array[0] != 0)
                            {

                                Ship ship = new Ship();
                                ship.Point.Add(new Point(numberX, numberY));
                                if (IsItPossibleToPutAShip(ship))
                                {
                                    for (int i = 0; i < ship.Point.Count; i++)
                                    {
                                        GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.PartOfTheShip;
                                    }
                                    array[0] -= 1;
                                    Ships.Add(ship);
                                }
                            }
                        }
                        break;
                }
            }
        }
        public bool IsItPossibleToPutAShip(Ship ship)
        {
            for (int i = 0; i < ship.Point.Count; i++)
            {
                if (ship.Point[i].X >= GameField.Count - 1 ||
                    ship.Point[i].Y >= GameField.Count - 1 ||
                    ship.Point[i].X < 1 ||
                    ship.Point[i].Y < 1)
                {
                    return false;
                }
            }
            for (int i = 0; i < ship.Point.Count; i++)
            {
                if (GameField[ship.Point[i].X][ship.Point[i].Y].Type == CellType.PartOfTheShip ||
                    GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type == CellType.PartOfTheShip ||
                    GameField[ship.Point[i].X - 1][ship.Point[i].Y - 1].Type == CellType.PartOfTheShip ||
                    GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type == CellType.PartOfTheShip ||
                    GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type == CellType.PartOfTheShip ||
                    GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type == CellType.PartOfTheShip ||
                    GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type == CellType.PartOfTheShip ||
                    GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type == CellType.PartOfTheShip ||
                    GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type == CellType.PartOfTheShip)
                {
                    return false;
                }
            }
            return true;
        }
        public int[] ByHandShipP(ShipClassEnum shipClassEnum, Directions directions, int numberX, int numberY, int[] array)
        {
            switch (shipClassEnum)
            {
                case ShipClassEnum.FourDeck:
                    {
                        if (array[3] != 0)
                        {
                            Ship ship = new Ship();
                            ship.Point.Add(new Point(numberX, numberY));
                            switch (directions)
                            {
                                case Directions.Up:
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            ship.Point.Add(new Point(numberX - i, numberY));
                                        }
                                    }
                                    break;
                                case Directions.Down:
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            ship.Point.Add(new Point(numberX + i, numberY));
                                        }
                                    }
                                    break;
                                case Directions.Left:
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            ship.Point.Add(new Point(numberX, numberY - i));
                                        }
                                    }
                                    break;
                                case Directions.Right:
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            ship.Point.Add(new Point(numberX, numberY + i));
                                        }
                                    }
                                    break;
                            }
                            if (IsItPossibleToPutAShip(ship))
                            {
                                for (int i = 0; i < ship.Point.Count; i++)
                                {
                                    GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.PartOfTheShip;
                                }
                                array[3] -= 1;
                                Ships.Add(ship);
                            }
                        }
                    }
                    break;
                case ShipClassEnum.ThreeDeck:
                    {
                        if (array[2] != 0)
                        {
                            Ship ship = new Ship();
                            ship.Point.Add(new Point(numberX, numberY));
                            switch (directions)
                            {
                                case Directions.Up:
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            ship.Point.Add(new Point(numberX - i, numberY));
                                        }
                                    }
                                    break;
                                case Directions.Down:
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            ship.Point.Add(new Point(numberX + i, numberY));
                                        }
                                    }
                                    break;
                                case Directions.Left:
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            ship.Point.Add(new Point(numberX, numberY - i));
                                        }
                                    }
                                    break;
                                case Directions.Right:
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            ship.Point.Add(new Point(numberX, numberY + i));
                                        }
                                    }
                                    break;
                            }
                            if (IsItPossibleToPutAShip(ship))
                            {
                                for (int i = 0; i < ship.Point.Count; i++)
                                {
                                    GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.PartOfTheShip;
                                }
                                array[2] -= 1;
                                Ships.Add(ship);
                            }
                        }
                    }
                    break;
                case ShipClassEnum.TwoDeck:
                    {
                        if (array[1] != 0)
                        {
                            Ship ship = new Ship();
                            ship.Point.Add(new Point(numberX, numberY));
                            switch (directions)
                            {
                                case Directions.Up:
                                    {
                                        for (int i = 0; i < 2; i++)
                                        {
                                            ship.Point.Add(new Point(numberX - i, numberY));
                                        }
                                    }
                                    break;
                                case Directions.Down:
                                    {
                                        for (int i = 0; i < 2; i++)
                                        {
                                            ship.Point.Add(new Point(numberX + i, numberY));
                                        }
                                    }
                                    break;
                                case Directions.Left:
                                    {
                                        for (int i = 0; i < 2; i++)
                                        {
                                            ship.Point.Add(new Point(numberX, numberY - i));
                                        }
                                    }
                                    break;
                                case Directions.Right:
                                    {
                                        for (int i = 0; i < 2; i++)
                                        {
                                            ship.Point.Add(new Point(numberX, numberY + i));
                                        }
                                    }
                                    break;
                            }
                            if (IsItPossibleToPutAShip(ship))
                            {
                                for (int i = 0; i < ship.Point.Count; i++)
                                {
                                    GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.PartOfTheShip;
                                }
                                array[1] -= 1;
                                Ships.Add(ship);
                            }
                        }
                    }
                    break;
                case ShipClassEnum.SingleDeck:
                    {
                        if (array[0] != 0)
                        {
                            Ship ship = new Ship();
                            ship.Point.Add(new Point(numberX, numberY));
                            if (IsItPossibleToPutAShip(ship))
                            {
                                for (int i = 0; i < ship.Point.Count; i++)
                                {
                                    GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.PartOfTheShip;
                                }
                                array[0] -= 1;
                                Ships.Add(ship);
                            }
                        }
                    }
                    break;
            }
            return array;
        }
    }
}
