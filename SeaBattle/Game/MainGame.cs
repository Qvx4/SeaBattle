using System;


namespace SeaBattle
{
    public class MainGame
    {
        public Bot Bot { get; set; }
        public Player Player { get; set; }
        public MainGame()
        {
            Player = new Player();
            Bot = new Bot();
        }
        //Правила игры
        public void Regulations()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Морской бой (игра)");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
                "0------------------------------------------------------------------------------------------------------------------0\n" +
                "|                                                 Правила игры                                                     |\n" +
                "0------------------------------------------------------------------------------------------------------------------0\n" +
                "| 1-(Каждый игрок говорит кординаты по очереди)                                                                    |\n" +
                "| 2-(У каждого игрока есть такие судна как                                        __/___                           |\n" +
                "|   (1 корабль — ряд из 4 клеток («четырёхпалубный» линкор)                 _____/______|                          |\n" +
                "|   (2 корабля — ряд из 3 клеток («трёхпалубные»; крейсера)         _______/_____\\_______\\_____                    |\n" +
                "|   (3 корабля — ряд из 2 клеток («двухпалубные»; эсминцы)         \\  p o l i c        < < <    |                  |\n" +
                "|   (4 корабля — 1 клетка («однопалубные»; торпедные катера))      ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~              |\n" +
                "| 3-(Каждый игрок должен правильно раставить судна по карте что бы судна не ксались друг друга )                   |\n" +
                "| 4-(В случаи попадания по судну если судно однопалубное то оно сразу тонет в ином случаи получает повреждение)    |\n" +
                "0------------------------------------------------------------------------------------------------------------------0\n");
        }
        //Настройки 
        public void Settings(SettingsMenuEnum settingsMenuEnum, string name)
        {
            switch (settingsMenuEnum)
            {
                case SettingsMenuEnum.BotNicknameChange:
                    {
                        Bot.Name = name;
                    }
                    break;
                case SettingsMenuEnum.ChangeYourNickname:
                    {
                        Player.Login = name;
                    }
                    break;
            }
        }
        //Начало игры 
        public void StartGame()
        {
            int numberX = 0, numberY = 0;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                ShowWhoseField($"Поле Противника (Bot) с ником [ {Bot.Name} ]", true);
                Console.ForegroundColor = ConsoleColor.Gray;
                Player.EnemyFild();
                Bot.MyField.ShowField();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(
                    "        ↑\n" +
                    "0--------------0\n" +
                    "| Игровые Поля |\n" +
                    "0--------------0\n" +
                    "        ↓\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Player.ShowField();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                //под вывод
                ShowWhoseField($"Поле игрока (Player) с ником [ {Player.Login} ]", false);
                //под вывод
                Console.WriteLine("Введите кординаты куда хотите стрельнуть ");
                Console.Write("Ввод кординаты X > { ");
                int.TryParse(Console.ReadLine(), out numberX);
                while (numberX > Player.MyField.GameField.Count - 2 || numberX < 0 || numberX == 0)
                {
                    Console.Beep();
                    Console.Write("Введите повторно кординату X > { ");
                    int.TryParse(Console.ReadLine(), out numberX);
                }
                Console.Write("Ввод кординаты Y > { ");
                int.TryParse(Console.ReadLine(), out numberY);
                while (numberY > Player.MyField.GameField.Count - 2 || numberY < 0 || numberY == 0)
                {
                    //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\sudik\Downloads\drake.mp3");
                    //player.Play();
                    //player.Play();
                    //Console.Beep();
                    Console.Write("Введите повторно кординату Y > { ");
                    int.TryParse(Console.ReadLine(), out numberY);
                }
                while (CheckHitBotField(numberX, numberY))
                {
                    if (CheckWinPlayer())
                    {
                        ShowWinPlayer();
                        GameWinMenuEnum gameWinMenuEnum;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("Ввод > ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Enum.TryParse(Console.ReadLine(), out gameWinMenuEnum);
                        while ((int)gameWinMenuEnum < 1 || (int)gameWinMenuEnum > 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Ввод > ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Enum.TryParse(Console.ReadLine(), out gameWinMenuEnum);
                        }
                        switch (gameWinMenuEnum)
                        {
                            case GameWinMenuEnum.SeePlayingFields:
                                {
                                    Console.Clear();
                                    Bot.ShowField();
                                    Player.ShowField();
                                    Console.Write("Нажмите любую кнопку что бы выйти в главное меню... ");
                                    Console.ReadLine();
                                    ResetGame();
                                    return;
                                }
                                break;
                            case GameWinMenuEnum.ExitToMainMenu:
                                {
                                    ResetGame();
                                    return;
                                }
                                break;
                        }
                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    ShowWhoseField($"Поле Противника (Bot) с ником [ {Bot.Name} ]", true);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Player.EnemyFild();
                    Bot.MyField.ShowField();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(
                        "        ↑\n" +
                        "0--------------0\n" +
                        "| Игровые Поля |\n" +
                        "0--------------0\n" +
                        "        ↓\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Player.ShowField();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    //под вывод
                    ShowWhoseField($"Поле игрока (Player) с ником [ {Player.Login} ]", false);
                    //под вывод
                    Console.Write("Ввод кординаты X > { ");
                    int.TryParse(Console.ReadLine(), out numberX);
                    while (numberX > Player.MyField.GameField.Count - 1 || numberX < 0)
                    {
                        Console.Beep();
                        Console.Write("Введите повторно кординату X > { ");
                        int.TryParse(Console.ReadLine(), out numberX);
                    }
                    Console.Write("Ввод кординаты Y > { ");
                    int.TryParse(Console.ReadLine(), out numberY);
                    while (numberY > Player.MyField.GameField.Count - 1 || numberY < 0)
                    {
                        //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\sudik\Downloads\drake.mp3");
                        //player.Play();
                        //player.Play();
                        //Console.Beep();
                        Console.Write("Введите повторно кординату Y > { ");
                        int.TryParse(Console.ReadLine(), out numberY);
                    }
                }
                while (CheckHitPlayerField(Bot.BotShooting()))
                {
                    //CheckHitPlayerField(Bot.BotShooting());
                }
                if (CheckWinBot())
                {
                    ShowWinBot();
                    Bot.ShowField();
                    Player.ShowField();
                    Console.Write("Нажмите любую кнопку что бы выйти в главное меню... ");
                    Console.ReadLine();
                    ResetGame();
                    return;
                }
            }
        }
        //Проверка стрельбы по полю бота / противнка
        public bool CheckHitBotField(int numberX, int numberY)
        {
            bool check = false;
            if (Bot.MyField.GameField[numberX][numberY].Type == CellType.Emptiness)
            {
                Player.EnemyField.GameField[numberX][numberY].Type = CellType.Miss;
                Bot.MyField.GameField[numberX][numberY].Type = CellType.Miss;
                return false;
            }
            if (Bot.MyField.GameField[numberX][numberY].Type == CellType.Padded ||
                Bot.MyField.GameField[numberX][numberY].Type == CellType.Destroyed ||
                Bot.MyField.GameField[numberX][numberY].Type == CellType.Miss)
            {
                return true;
            }
            for (int i = 0; i < Bot.MyField.Ships.Count; i++)
            {
                for (int j = 0; j < Bot.MyField.Ships[i].Point.Count; j++)
                {
                    if (Bot.MyField.Ships[i].Point[j].X == numberX &&
                        Bot.MyField.Ships[i].Point[j].Y == numberY)
                    {
                        Player.EnemyField.GameField[numberX][numberY].Type = CellType.Padded;
                        Bot.MyField.GameField[numberX][numberY].Type = CellType.Padded;
                        for (int k = 0; k < Bot.MyField.Ships[i].Point.Count; k++)
                        {
                            if (Bot.MyField.GameField[Bot.MyField.Ships[i].Point[k].X][Bot.MyField.Ships[i].Point[k].Y].Type != CellType.Padded)
                            {
                                check = true;
                                break;
                            }
                        }
                        if (check)
                        {
                            return true;
                        }
                        else
                        {
                            DestrayTheShipBot(Bot.MyField.Ships[i]);
                            return true;
                        }
                    }

                }
            }
            return false;
        }
        //Уничтожить весь корабль бота 
        public void DestrayTheShipBot(Ship ship)
        {
            for (int i = 0; i < ship.Point.Count; i++)
            {
                Player.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.Destroyed;
                Bot.MyField.GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.Destroyed;
            }
            for (int i = 0; i < ship.Point.Count; i++)
            {
                if (Player.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type != CellType.Border &&
                    Player.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type != CellType.Destroyed)
                {
                    Player.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type = CellType.Miss;
                    Bot.MyField.GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type = CellType.Miss;
                }

                if (Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y - 1].Type != CellType.Border &&
                    Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y - 1].Type != CellType.Destroyed)
                {
                    Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y - 1].Type = CellType.Miss;
                    Bot.MyField.GameField[ship.Point[i].X -1][ship.Point[i].Y - 1].Type = CellType.Miss;
                }

                if (Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type != CellType.Border &&
                    Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type != CellType.Destroyed)
                {
                    Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type = CellType.Miss;
                    Bot.MyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type = CellType.Miss;
                }

                if (Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type != CellType.Border &&
                    Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type != CellType.Destroyed)
                {
                    Player.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type = CellType.Miss;
                    Bot.MyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type = CellType.Miss;
                }

                if (Player.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type != CellType.Border &&
                    Player.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type != CellType.Destroyed)
                {
                    Player.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type = CellType.Miss;
                    Bot.MyField.GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type = CellType.Miss;
                }

                if (Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type != CellType.Border &&
                    Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type != CellType.Destroyed)
                {
                    Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type = CellType.Miss;
                    Bot.MyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type = CellType.Miss;
                }

                if (Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type != CellType.Border &&
                    Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type != CellType.Destroyed)
                {
                    Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type = CellType.Miss;
                    Bot.MyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type = CellType.Miss;
                }

                if (Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type != CellType.Border &&
                    Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type != CellType.Destroyed)
                {
                    Player.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type = CellType.Miss;
                    Bot.MyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type = CellType.Miss;
                }

            }
        }
        //Проверка стрельбы бота по полю игрока / противника
        public bool CheckHitPlayerField(Point point)
        {
            if (Bot.NeedShoot.Count > 0)
            {
                Random rnd = new Random();

                int number = rnd.Next(0, Bot.NeedShoot.Count); ;
                if (Player.MyField.GameField[Bot.NeedShoot[number].X][Bot.NeedShoot[number].Y].Type == CellType.Emptiness)
                {
                    Bot.EnemyField.GameField[Bot.NeedShoot[number].X][Bot.NeedShoot[number].Y].Type = CellType.Miss;
                    Player.MyField.GameField[Bot.NeedShoot[number].X][Bot.NeedShoot[number].Y].Type = CellType.Miss;
                    Bot.NeedShoot.RemoveAt(number);
                    return false;
                }
                if (Player.MyField.GameField[Bot.NeedShoot[number].X][Bot.NeedShoot[number].Y].Type == CellType.PartOfTheShip)
                {
                    Bot.WereShotDead.Add(new Point(Bot.NeedShoot[number].X, Bot.NeedShoot[number].Y));
                    Bot.EnemyField.GameField[Bot.NeedShoot[number].X][Bot.NeedShoot[number].Y].Type = CellType.Padded;
                    Player.MyField.GameField[Bot.NeedShoot[number].X][Bot.NeedShoot[number].Y].Type = CellType.Padded;
                    bool check = false;
                    for (int i = 0; i < Player.MyField.Ships.Count; i++)
                    {
                        if (check)
                        {
                            break;
                        }
                        for (int j = 0; j < Player.MyField.Ships[i].Point.Count; j++)
                        {
                            if (Player.MyField.Ships[i].Point[j].X == Bot.NeedShoot[number].X && Player.MyField.Ships[i].Point[j].Y == Bot.NeedShoot[number].Y)
                            {
                                for (int k = 0; k < Player.MyField.Ships[i].Point.Count; k++)
                                {
                                    if (Player.MyField.GameField[Player.MyField.Ships[i].Point[k].X][Player.MyField.Ships[i].Point[k].Y].Type != CellType.Padded)
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                                if (check)
                                {
                                    break;
                                }
                                DestrayTheShipPlayer(Player.MyField.Ships[i]);
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < Bot.WereShotDead.Count; i++)
                    {
                        if (Bot.WereShotDead[i].X == Bot.WereShotDead[0].X)
                        {
                            check = false;
                        }
                        else
                        {
                            check = true;
                            break;
                        }
                    }
                    Bot.NeedShoot.Clear();
                    int max = 0, min = int.MaxValue;
                    if (!check)
                    {
                        for (int i = 0; i < Bot.WereShotDead.Count; i++)
                        {
                            if (max < Bot.WereShotDead[i].Y)
                            {
                                max = Bot.WereShotDead[i].Y;
                            }
                            if (min > Bot.WereShotDead[i].Y)
                            {
                                min = Bot.WereShotDead[i].Y;
                            }
                        }
                        if (Player.MyField.GameField[Bot.WereShotDead[0].X][max + 1].Type != CellType.Miss)
                        {
                            Bot.NeedShoot.Add(new Point(Bot.WereShotDead[0].X, max + 1));
                        }
                        if (Player.MyField.GameField[Bot.WereShotDead[0].X][min - 1].Type != CellType.Miss)
                        {
                            Bot.NeedShoot.Add(new Point(Bot.WereShotDead[0].X, min - 1));
                        }
                        return true;
                    }
                    else
                    {
                        max = 0;
                        min = int.MaxValue;
                        for (int i = 0; i < Bot.WereShotDead.Count; i++)
                        {
                            if (max < Bot.WereShotDead[i].X)
                            {
                                max = Bot.WereShotDead[i].X;
                            }
                            if (min > Bot.WereShotDead[i].X)
                            {
                                min = Bot.WereShotDead[i].X;
                            }
                        }
                        if (Player.MyField.GameField[max + 1][Bot.WereShotDead[0].Y].Type != CellType.Miss)
                        {
                            Bot.NeedShoot.Add(new Point(max + 1, Bot.WereShotDead[0].Y));
                        }
                        if (Player.MyField.GameField[min - 1][Bot.WereShotDead[0].Y].Type != CellType.Miss)
                        {
                            Bot.NeedShoot.Add(new Point(min - 1, Bot.WereShotDead[0].Y));
                        }
                    }
                    return true;
                }
            }
            else
            {
                if (Player.MyField.GameField[point.X][point.Y].Type == CellType.Emptiness)
                {
                    Player.MyField.GameField[point.X][point.Y].Type = CellType.Miss;
                    Bot.EnemyField.GameField[point.X][point.Y].Type = CellType.Miss;
                    return false;
                }
                if (Player.MyField.GameField[point.X][point.Y].Type == CellType.PartOfTheShip)
                {
                    for (int i = 0; i < Player.MyField.Ships.Count; i++)
                    {
                        for (int j = 0; j < Player.MyField.Ships[i].Point.Count; j++)
                        {
                            if (Player.MyField.Ships[i].Point[j].X == point.X &&
                                Player.MyField.Ships[i].Point[j].Y == point.Y)
                            {
                                Player.MyField.GameField[point.X][point.Y].Type = CellType.Padded;
                                Bot.EnemyField.GameField[point.X][point.Y].Type = CellType.Padded;
                                Bot.WereShotDead.Add(point);
                                for (int k = 0; k < Player.MyField.Ships[i].Point.Count; k++)
                                {
                                    if (Player.MyField.GameField[Player.MyField.Ships[i].Point[k].X][Player.MyField.Ships[i].Point[k].Y].Type != CellType.Padded)
                                    {
                                        if (CordinateCheck(point.X, point.Y - 1))
                                        {
                                            Bot.NeedShoot.Add(new Point(point.X, point.Y - 1));
                                        }
                                        if (CordinateCheck(point.X, point.Y + 1))
                                        {
                                            Bot.NeedShoot.Add(new Point(point.X, point.Y + 1));
                                        }
                                        if (CordinateCheck(point.X - 1, point.Y))
                                        {
                                            Bot.NeedShoot.Add(new Point(point.X - 1, point.Y));
                                        }
                                        if (CordinateCheck(point.X + 1, point.Y))
                                        {
                                            Bot.NeedShoot.Add(new Point(point.X + 1, point.Y));
                                        }
                                        return true;
                                    }
                                }
                                DestrayTheShipPlayer(Player.MyField.Ships[i]);
                                break;
                            }

                        }
                    }
                    return true;
                }
            }
            return false;
        }//fix
        //Уничтожить весь корабль игрока
        public void DestrayTheShipPlayer(Ship ship)
        {
            for (int i = 0; i < ship.Point.Count; i++)
            {
                Player.MyField.GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.Destroyed;
                Bot.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y].Type = CellType.Destroyed;
            }
            Bot.NeedShoot.Clear();
            Bot.WereShotDead.Clear();
            for (int i = 0; i < ship.Point.Count; i++)
            {
                if (Bot.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type != CellType.Border &&
                    Bot.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type != CellType.Destroyed)
                {
                    Bot.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type = CellType.Miss;
                    Player.MyField.GameField[ship.Point[i].X][ship.Point[i].Y - 1].Type = CellType.Miss;
                }

                if (Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y - 1].Type != CellType.Border &&
                    Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y - 1].Type != CellType.Destroyed)
                {
                    Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y - 1].Type = CellType.Miss;
                    Player.MyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y - 1].Type = CellType.Miss;
                }

                if (Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type != CellType.Border &&
                    Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type != CellType.Destroyed)
                {
                    Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type = CellType.Miss;
                    Player.MyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y].Type = CellType.Miss;
                }

                if (Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type != CellType.Border &&
                    Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type != CellType.Destroyed)
                {
                    Bot.EnemyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type = CellType.Miss;
                    Player.MyField.GameField[ship.Point[i].X - 1][ship.Point[i].Y + 1].Type = CellType.Miss;
                }

                if (Bot.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type != CellType.Border &&
                    Bot.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type != CellType.Destroyed)
                {
                    Bot.EnemyField.GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type = CellType.Miss;
                    Player.MyField.GameField[ship.Point[i].X][ship.Point[i].Y + 1].Type = CellType.Miss;
                }

                if (Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type != CellType.Border &&
                    Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type != CellType.Destroyed)
                {
                    Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type = CellType.Miss;
                    Player.MyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y + 1].Type = CellType.Miss;
                }

                if (Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type != CellType.Border &&
                    Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type != CellType.Destroyed)
                {
                    Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type = CellType.Miss;
                    Player.MyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y].Type = CellType.Miss;
                }

                if (Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type != CellType.Border &&
                    Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type != CellType.Destroyed)
                {
                    Bot.EnemyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type = CellType.Miss;
                    Player.MyField.GameField[ship.Point[i].X + 1][ship.Point[i].Y - 1].Type = CellType.Miss;
                }

            }

        }
        public bool CordinateCheck(int numberX, int numberY)
        {
            if (Player.MyField.GameField[numberX][numberY].Type == CellType.Border ||
                Player.MyField.GameField[numberX][numberY].Type == CellType.Miss ||
                Player.MyField.GameField[numberX][numberY].Type == CellType.Padded ||
                Player.MyField.GameField[numberX][numberY].Type == CellType.Destroyed)
            {
                return false;
            }
            return true;
        }
        //Проверки всех разбитых кораблей У Бота 
        public bool CheckWinPlayer()
        {
            for (int i = 0; i < Bot.MyField.Ships.Count; i++)
            {
                for (int j = 0; j < Bot.MyField.Ships[i].Point.Count; j++)
                {
                    if (Bot.MyField.GameField[Bot.MyField.Ships[i].Point[j].X][Bot.MyField.Ships[i].Point[j].Y].Type != CellType.Destroyed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Проверка всех разбитых кораблей у Игрока 
        public bool CheckWinBot()
        {
            for (int i = 0; i < Player.MyField.Ships.Count; i++)
            {
                for (int j = 0; j < Player.MyField.Ships[i].Point.Count; j++)
                {
                    if (Player.MyField.GameField[Player.MyField.Ships[i].Point[j].X][Player.MyField.Ships[i].Point[j].Y].Type != CellType.Destroyed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Вывод победы у бота
        public void ShowWinBot()
        {
            Console.Clear();
            Console.WriteLine(
                "                           ?\n" +
                "~~~~~~~~~~~~~~~~~~~~~~~~~~~|^~~~~~~~~~~~~~~~~~~~~~~~~~o~~~~~~~~~~~\n" +
                "       o                   |                  o      __o\n" +
                "        o                  |                 o     |X__>\n" +
                "      ___o                 |                __o\n" +
                "     (X___>--             __|__            |X__>     o\n" +
                "                         |     \\                   __o\n" +
                "                         |      \\                |X__>\n" +
                "  _______________________|_______\\________________\n" +
                " <                                                \\____________  _\n" +
                "  \\                  W i N  B O T                            \\ (_)\n" +
                "   \\    O       O       O                                       >=)\n" +
                "    \\__________________________________________________________/(_)\n" +
                "" +
                "                            ___\n" +
                "                           / o \\\n" +
                "                      __   \\   /   _\n" +
                "                        \\__/ | \\__/ \\\n" +
                "                       \\___//|\\___/\\\n" +
                "                        ___/ | \\___\n" +
                "                             |     \\\n" +
                "                            /\n");
        }
        //Вывод победы у игрока
        public void ShowWinPlayer()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"                              |  W I N {Player.Login} |");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(
                "                                   _o\n"+
                "                                  .#$?\\\n"+
                "                                .'##$ ?$\\\n"+
                "                              .'.###$  ?$$\\\n"+
                "                            .' .####$   ?$$$\\\n"+
                "                          .'  +#####$   `$$$$$\\\n"+
                "                        .'   d######$    `$$$$$$\\\n"+
                "                      .'   .########$     ?$$$$$$$\\\n"+
                "                    .'    .#########$      ?$$$$$$$$\\\n"+
                "                  .'     ,##########$       ?$$$$$$$$$\\\n"+
                "                .'      +###########$       `?$$$$$$$$$$\\\n"+
                "             ..'      .;############$        `$$$$$$$$$$$$\\\n"+
                "             |'       ;    ````\"\"\"\"?$         ?$$$$??\"\"\" ? $$$\\\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
                "             |_/_____;._______._____$_________)?;__________?;X\\___.-.\n" +
                "             /'_____;_|______,|ooooo$oo|o,,,,/..|..___      |`'+\\.\\.'\n" +
                "          .'||  ,ooooo|ooooodS|SSSSSSSS|SSS/'SSS|SSSSSSSSSSS|SSSS|/\n" +
                "      .  .; |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~/'");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(
                ".,;.;';`'(`;|',.;'.'.,,,+','+.,'+,.+,'+..^+,','+.,',.';.'.,+'`;'.';,:'';,:.'\n" +
                ";'.';,:'.,;.;';`'(`;|',.;'.'.,,,+','+.,'+,.+,'+..^+,','+.,',.';.'.,+'`.';,:'\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(
                "| 1 - Посмотреть игровые поля \n" +
                "| 2 - Выйти в главное меню ");
        }
        //Метод для очистки поля рестарт игры 
        public void ResetGame()
        {
            Player.MyField = new Field();
            Bot.MyField = new Field();
            Bot.EnemyField = new Field();
            Player.EnemyField = new Field();
            Bot.WereShotDead.Clear();
            Bot.NeedShoot.Clear();
        }
        //Метод для рисовки вывода чьё поле
        public void ShowWhoseField(string text, bool check)
        {
            string a = $"Поле игрока (Player) с ником [ {text} ]";
            if (!check)
            {
                Console.WriteLine("                      ↑                          ");
            }
            Console.Write("0");
            for (int i = 0; i < text.Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("0");
            Console.Write("|");
            for (int i = 0; i < text.Length + 2; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
            Console.Write("| ");
            Console.Write(text);
            Console.Write(" |\n");
            Console.Write("|");
            for (int i = 0; i < text.Length + 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("|\n");
            Console.Write("0");
            for (int i = 0; i < text.Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("0\n");
            if (check)
            {
                Console.WriteLine($"                      ↓                        ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
