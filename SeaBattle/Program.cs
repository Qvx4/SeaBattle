using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Program
    {
        public static void DisplayOfTheShipInTheMainMenu()
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                              W E L C O M E ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
                "                                  |__\n" +
                "                                   |\\/\n" +
                "                                    ---\n" +
                "                                    / | [\n" +
                "                             !      | |||\n" +
                "                           _/|     _/|-++'\n" +
                "                       +  +--|    |--|--|_ |-\n" +
                "                    { /|__|  |/\\__|  |--- |||__/\n" +
                "                   +---------------___[}-_===_.'____                 /\\\n" +
                "               ____`-' ||___-{]_| _[}-  |     |_[___\\==--            \\/   _\n" +
                "__..._____--==/___]_|__|_____________________________[___\\==--____,------' .7\n" +
                "|                                                                     BB-61/\n" +
                " \\_________________________________________________________________________|");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(
            " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
            "     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void ShipOutputInSetup()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                                    Настройки ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
                "                                     # #  ( )\n" +
                "                                  ___#_#___|__\n" +
                "                              _  |____________|  _\n" +
                "                       _=====| | |            | | |==== _\n" +
                "                 =====| |.---------------------------. | |====\n" +
                "   <--------------------'   .  .  .  .  .  .  .  .   '--------------/\n" +
                "     \\                                                             /\n" +
                "      \\_______________________________________________WWS_________/");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(
            "    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
            "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void ShowShipStartGameMenu()
        {
            Console.WriteLine(
                "                           |`-:_\n" +
                "  ,----....____            |    `+.\n" +
                " (             ````----....|___   |\n" +
                "  \\     _                      ````----....____\n" +
                "   \\    _)                                     ```---.._\n" +
                "    \\                                                   \\");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(
                "  )`.\\  )`.   )`.   )`.   )`.   )`.   )`.   )`.   )`.   )`.   )hh\n" +
                "-'   `-'   `-'   `-'   `-'   `-'   `-'   `-'   `-'   `-'   `-'   `\n");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Main(string[] args)
        {
            MainGame mainGame = new MainGame();
            while (true)
            {
                Console.Clear();
                DisplayOfTheShipInTheMainMenu();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(" 1 -  Правила игры");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(" 2 -  Настройки игры");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" 3 -  Начать игру");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" Ввод > ");
                MainMenuEnum mainMenuEnum;
                Enum.TryParse(Console.ReadLine(), out mainMenuEnum);
                switch (mainMenuEnum)
                {
                    case MainMenuEnum.Regulations:
                        {
                            Console.Clear();
                            mainGame.Regulations();
                            Console.Write("Нажмите люьую кнопку чтобы вернуться назад ... ");
                            Console.ReadLine();
                        }
                        break;
                    case MainMenuEnum.Setting:
                        {
                            Console.Clear();
                            ShipOutputInSetup();
                            String name;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(" 1 - Поменять никнейм боту ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" 2 - Поменять свой никнейм ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" Ввод > ");
                            SettingsMenuEnum settingsMenuEnum;
                            Enum.TryParse(Console.ReadLine(), out settingsMenuEnum);
                            while ((int)settingsMenuEnum < 1 || (int)settingsMenuEnum > 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(" Ввод > ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Enum.TryParse(Console.ReadLine(), out settingsMenuEnum);
                            }
                            switch (settingsMenuEnum)
                            {
                                case SettingsMenuEnum.BotNicknameChange:
                                    {
                                        Console.Write("Введите Новое имя Боту > ");
                                        name = Console.ReadLine();
                                        mainGame.Settings(settingsMenuEnum, name);
                                    }
                                    break;
                                case SettingsMenuEnum.ChangeYourNickname:
                                    {
                                        Console.Write("Введите новое своё новое имя > ");
                                        name = Console.ReadLine();
                                        mainGame.Settings(settingsMenuEnum, name);
                                    }
                                    break;
                            }
                        }
                        break;
                    case MainMenuEnum.StartTheGame:
                        {
                            Console.Clear();
                            Console.WriteLine(
                                "0-----------------------------------------------0\n" +
                                "| Выберите варинат растановки кораблей на карте |\n" +
                                "| Есть такие варинаты как показано снизу        |\n" +
                                "0-----------------------------------------------0\n");
                            ShowShipStartGameMenu();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" 1 - Поставить корабли рандомно");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" 2 - Поставить корабли вручную");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" Ввод >  ");
                            MenuStartGame menuStartGame;
                            Enum.TryParse(Console.ReadLine(), out menuStartGame);
                            while ((int)menuStartGame < 1 || (int)menuStartGame > 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(" Ввод >  ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Enum.TryParse(Console.ReadLine(), out menuStartGame);
                            }
                            switch (menuStartGame)
                            {
                                case MenuStartGame.Random:
                                    {
                                        Console.Clear();
                                        RandomMenu randomMenu;
                                        mainGame.Player.MyField.RandomPlacementOfShips();
                                        mainGame.Player.MyField.ShowField();
                                        Console.WriteLine("[1] > Оставить такую расстановку кораблей ");
                                        Console.WriteLine("[2] > Пересоздать расстановку кораблей ");
                                        Console.Write("Ввод > ");
                                        Enum.TryParse(Console.ReadLine(), out randomMenu);
                                        while ((int)randomMenu < 1 ||
                                            (int)randomMenu > 2)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.Write("Ввод > ");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Enum.TryParse(Console.ReadLine(), out randomMenu);
                                        }
                                        while ((int)randomMenu == 2)
                                        {
                                            Console.Clear();
                                            mainGame.Player.MyField = new Field();
                                            mainGame.Player.MyField.RandomPlacementOfShips();
                                            mainGame.Player.MyField.ShowField();
                                            Console.WriteLine("[1] > Оставить такую расстановку кораблей ");
                                            Console.WriteLine("[2] > Пересоздать расстановку кораблей ");
                                            Console.Write("Ввод > ");
                                            Enum.TryParse(Console.ReadLine(), out randomMenu);
                                            if ((int)randomMenu == 1)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case MenuStartGame.ByHand:
                                    {
                                        Console.Clear();
                                        int[] shipCount = { 4, 3, 2, 1 };
                                        ShipClassEnum shipClassEnum;
                                        Directions directions;
                                        int numberX = 0, numberY = 0, summa = 0;
                                        while (true)
                                        {
                                            Console.Clear();
                                            mainGame.Player.MyField.ShowField();
                                            summa += shipCount[3] + shipCount[2] + shipCount[1] + shipCount[0];
                                            if (summa == 0)
                                            {
                                                break;
                                            }
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine(
                                                "0-------------------------------------------0\n" +
                                                "|                                           |\n" +
                                                "| Выберите корабль который хотите поставить |\n" +
                                                "|                                           |\n" +
                                                "0-------------------------------------------0\n");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.WriteLine($"[ {shipCount[3]} ] «Четырёхпалубный» Линкор)        - 1");
                                            Console.WriteLine($"[ {shipCount[2]} ] «Tрёхпалубные» Крейсера)         - 2");
                                            Console.WriteLine($"[ {shipCount[1]} ] «Двухпалубные» Эсминцы)          - 3");
                                            Console.WriteLine($"[ {shipCount[0]} ] «Oднопалубные» Торпедные Катера) - 4");
                                            Console.Write("Ввод > ");
                                            Enum.TryParse(Console.ReadLine(), out shipClassEnum);
                                            while ((int)shipClassEnum < 1 || (int)shipClassEnum > 4)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("Ввод > ");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                Enum.TryParse(Console.ReadLine(), out shipClassEnum);
                                            }
                                            bool check = false;
                                            switch (shipClassEnum)
                                            {
                                                case ShipClassEnum.FourDeck:
                                                    {
                                                        if (shipCount[3] == 0)
                                                        {
                                                            check = true;
                                                        }
                                                    }
                                                    break;
                                                case ShipClassEnum.ThreeDeck:
                                                    {
                                                        if (shipCount[2] == 0)
                                                        {
                                                            check = true;
                                                        }
                                                    }
                                                    break;
                                                case ShipClassEnum.TwoDeck:
                                                    {
                                                        if (shipCount[1] == 0)
                                                        {
                                                            check = true;
                                                        }
                                                    }
                                                    break;
                                                case ShipClassEnum.SingleDeck:
                                                    {
                                                        if (shipCount[0] == 0)
                                                        {
                                                            check = true;
                                                        }
                                                    }
                                                    break;
                                            }
                                            if (check)
                                            {
                                                Console.Write("Введите Новое Судно >> ");
                                                Enum.TryParse(Console.ReadLine(), out shipClassEnum);
                                            }
                                            Console.Clear();
                                            if (shipClassEnum == ShipClassEnum.SingleDeck)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine(
                                                    "0--------------------------------------------------0\n" +
                                                    "|                                                  |\n" +
                                                    "| Введите кординаты куда вы хотите поставить судно |\n" +
                                                    "|                                                  |\n" +
                                                    "0--------------------------------------------------0\n");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.Write("Ввод первой кординаты X >> { ");
                                                int.TryParse(Console.ReadLine(), out numberX);
                                                while (numberX < 1 ||
                                                    numberX > mainGame.Player.MyField.GameField.Count - 1)
                                                {
                                                    Console.Write("Ввод первой кординаты X >> { ");
                                                    int.TryParse(Console.ReadLine(), out numberX);
                                                }
                                                Console.Write("Ввод второй кординаты Y >> { ");
                                                int.TryParse(Console.ReadLine(), out numberY);
                                                while (numberY < 1 ||
                                                    numberY > mainGame.Player.MyField.GameField.Count - 1)
                                                {
                                                    Console.Write("Ввод первой кординаты Y >> { ");
                                                    int.TryParse(Console.ReadLine(), out numberY);
                                                }
                                                shipCount = mainGame.Player.MyField.ByHandShipP(shipClassEnum, directions = Directions.Left, numberX, numberY, shipCount);
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine(
                                                    "0----------------------------0\n" +
                                                    "|                            |\n" +
                                                    "| Выберите направления судна |\n" +
                                                    "|                            |\n" +
                                                    "0----------------------------0\n");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.WriteLine("[1] > Вверх");
                                                Console.WriteLine("[2] > Вниз");
                                                Console.WriteLine("[3] > Вправо");
                                                Console.WriteLine("[4] > Влево");
                                                Console.Write("Ввод > ");
                                                Enum.TryParse(Console.ReadLine(), out directions);
                                                while ((int)directions < 1 || (int)directions > 4)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.Write("Ввод > ");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Enum.TryParse(Console.ReadLine(), out directions);
                                                }
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine(
                                                    "0--------------------------------------------------0\n" +
                                                    "|                                                  |\n" +
                                                    "| Введите кординаты куда вы хотите поставить судно |\n" +
                                                    "|                                                  |\n" +
                                                    "0--------------------------------------------------0\n");
                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.Write("Ввод первой кординаты X >> { ");
                                                int.TryParse(Console.ReadLine(), out numberX);
                                                while (numberX < 1 ||
                                                    numberX > mainGame.Player.MyField.GameField.Count - 1)
                                                {
                                                    Console.Write("Ввод первой кординаты X >> { ");
                                                    int.TryParse(Console.ReadLine(), out numberX);
                                                }
                                                Console.Write("Ввод второй кординаты Y >> { ");
                                                int.TryParse(Console.ReadLine(), out numberY);
                                                while (numberY < 1 ||
                                                    numberY > mainGame.Player.MyField.GameField.Count - 1)
                                                {
                                                    Console.Write("Ввод первой кординаты X >> { ");
                                                    int.TryParse(Console.ReadLine(), out numberY);
                                                }
                                                shipCount = mainGame.Player.MyField.ByHandShipP(shipClassEnum, directions, numberX, numberY, shipCount);
                                            }
                                        }
                                    }
                                    break;
                            }
                            Console.Clear();
                            mainGame.Bot.MyField.RandomPlacementOfShips();
                            mainGame.StartGame();
                        }
                        break;
                }
            }

        }
    }
}
