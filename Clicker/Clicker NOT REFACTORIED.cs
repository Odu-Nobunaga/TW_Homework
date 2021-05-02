using System;
namespace Лаба_6._1
{
    class Program
    {
        enum GameState
        {
            Init,
            Play,
            Menu,
            Exit
        }
        struct Company
        {
            public string name;
            public int price;
            public int money;
            public int delay;
        }
        struct Game
        {
            public static Company UserCompany;
            public static int capital = 0;
            public static int playClick = 0;
            public static int spentMoney = 0;
        }
        public static void Main(string[] args)
        {
            Company[] companies = new Company[]
            {
                new Company()
                {
                    name = "Valve",
                    price =15,
                    money = 1000,
                    delay = 1000
                },
                new Company()
                {
                    name = "Nintendo",
                    price = 120,
                    money = 9,
                    delay = 3000
                },
                new Company()
                {
                    name = "Microsoft",
                    price = 800,
                    money = 50,
                    delay = 7000
                },
                new Company()
                {
                    name = "Sony",
                    price = 4000,
                    money = 3500,
                    delay = 22000
                },
            };
            GameState gameState = GameState.Init;
            do
            {
                Console.Clear();
                switch (gameState)
                {
                    case GameState.Init:
                        Game.UserCompany = companies[0];
                        Game.capital = 0;
                        gameState = GameState.Play;
                        break;
                    case GameState.Menu:
                        Console.Clear();
                        Console.WriteLine("Заработанные деньги: {0}$ \nКоличество нажатий: {1} \nПотраченные деньги: {2}$", Game.capital, Game.playClick, Game.spentMoney);
                        Console.WriteLine("Выберите действие: \nESC - Выход из игры \nG - Возврат в игру \nR - Сбросить игру \nB - Купить новую фабрику");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Escape:
                                Environment.Exit(0);
                                break;
                            case ConsoleKey.G:
                                gameState = GameState.Play;
                                break;
                            case ConsoleKey.R:
                                gameState = GameState.Init;
                                break;
                            case ConsoleKey.B:
                                Console.Clear();
                                Console.WriteLine("Заработанные деньги: {0}$", Game.capital);
                                Console.WriteLine("1 - {0}; цена: {1}$; доход: {2}$; задержка: {3} сек", companies[0].name, companies[0].price, companies[0].money, (companies[0].delay / 1000));
                                Console.WriteLine("2 - {0}; цена: {1}$; доход: {2}$; задержка: {3} сек", companies[1].name, companies[1].price, companies[1].money, (companies[1].delay / 1000));
                                Console.WriteLine("3 - {0}; цена: {1}$; доход: {2}$; задержка: {3} сек", companies[2].name, companies[2].price, companies[2].money, (companies[2].delay / 1000));
                                Console.WriteLine("4 - {0}; цена: {1}$; доход: {2}$; задержка: {3} сек", companies[3].name, companies[3].price, companies[3].money, (companies[3].delay / 1000));
                                switch (Console.ReadKey().KeyChar)
                                {
                                    case '1':
                                        if (Game.capital >= companies[0].price)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Вы купили компанию");
                                            Game.capital -= companies[0].price;
                                            Game.UserCompany = companies[0];
                                            Game.spentMoney += companies[0].price;
                                            Console.ReadKey(true);
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Иди работай");
                                            Console.ReadKey(true);
                                        }
                                        break;
                                    case '2':
                                        if (Game.capital >= companies[1].price)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Вы купили компанию");
                                            Game.capital -= companies[1].price;
                                            Game.UserCompany = companies[1];
                                            Game.spentMoney += companies[1].price;
                                            Console.ReadKey(true);
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Иди работай");
                                            Console.ReadKey(true);
                                        }
                                        break;
                                    case '3':
                                        if (Game.capital >= companies[2].price)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Вы купили компанию");
                                            Game.capital -= companies[2].price;
                                            Game.UserCompany = companies[2];
                                            Game.spentMoney += companies[2].price;
                                            Console.ReadKey(true);
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Иди работай");
                                            Console.ReadKey(true);
                                        }
                                        break;
                                    case '4':
                                        if (Game.capital >= companies[3].price)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Вы купили компанию");
                                            Game.capital -= companies[3].price;
                                            Game.UserCompany = companies[3];
                                            Game.spentMoney += companies[3].price;
                                            Console.ReadKey(true);
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Иди работай");
                                            Console.ReadKey(true);
                                        }
                                        break;
                                }
                                break;

                        }

                        break;
                    case GameState.Play:
                        Console.WriteLine("Текущий завод: {0} \nДеньги: {1}$ \nЗадержка: {2} сек", Game.UserCompany.name, Game.capital, (Game.UserCompany.delay / 1000));
                        Console.WriteLine("M - Меню игры");
                        Console.WriteLine("0%__________________________________________________100%");
                        Console.Write("  ");
                        for (int i = 0; i < 50; i++)
                        {
                            Console.Write("*");
                            System.Threading.Thread.Sleep(Game.UserCompany.delay / 50);
                        }
                        Game.capital += Game.UserCompany.money;
                        while (Console.KeyAvailable)
                            Console.ReadKey(true);
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.M:
                                gameState = GameState.Menu;
                                break;
                            default: break;
                        }
                        Game.playClick++;
                        break;
                }
            } while (gameState != GameState.Exit);
        }

    }
}