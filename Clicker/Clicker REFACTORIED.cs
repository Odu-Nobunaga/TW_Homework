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
            public string Сompany_name;
            public int Сompany_price;
            public int Сompany_money;
            public int Сompany_delay;
        }
        struct Game
        {
            public static Company UserCompany;
            public static int capital = 0;
            public static int playClick = 0;
            public static int spentMoney = 0;
        }
        public static void Message()
        {
            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите там куда-нибудь");
            Console.ReadKey(true);
        }
        public static void Main(string[] args)
        {
            Company[] companies = new Company[]
            {
                new Company()
                {
                    Сompany_name = "Valve",
                    Сompany_price =15000,
                    Сompany_money = 1000,
                    Сompany_delay = 1000
                },
                new Company()
                {
                    Сompany_name = "Nintendo",
                    Сompany_price = 50000,
                    Сompany_money = 3000,
                    Сompany_delay = 3000
                },
                new Company()
                {
                    Сompany_name = "Microsoft",
                    Сompany_price = 500000,
                    Сompany_money = 5000,
                    Сompany_delay = 7000
                },
                new Company()
                {
                    Сompany_name = "Sony",
                    Сompany_price = 20000000,
                    Сompany_money = 20000,
                    Сompany_delay = 22000
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
                                Console.WriteLine("1 - {0}; цена: {1}$; доход: {2}$; задержка: {3} сек", companies[0].Сompany_name, companies[0].Сompany_price, companies[0].Сompany_money, (companies[0].Сompany_delay / 1000));
                                Console.WriteLine("2 - {0}; цена: {1}$; доход: {2}$; задержка: {3} сек", companies[1].Сompany_name, companies[1].Сompany_price, companies[1].Сompany_money, (companies[1].Сompany_delay / 1000));
                                Console.WriteLine("3 - {0}; цена: {1}$; доход: {2}$; задержка: {3} сек", companies[2].Сompany_name, companies[2].Сompany_price, companies[2].Сompany_money, (companies[2].Сompany_delay / 1000));
                                Console.WriteLine("4 - {0}; цена: {1}$; доход: {2}$; задержка: {3} сек", companies[3].Сompany_name, companies[3].Сompany_price, companies[3].Сompany_money, (companies[3].Сompany_delay / 1000));
                                try
                                {
                                    int companyID = int.Parse(Console.ReadKey(true).KeyChar.ToString());
                                    if (Game.capital >= companies[companyID - 1].Сompany_price)
                                    {
                                        Console.WriteLine("Вы купили компанию");
                                        Game.capital -= companies[companyID - 1].Сompany_price;
                                        Game.UserCompany = companies[companyID - 1];
                                        Game.spentMoney += companies[companyID - 1].Сompany_price;
                                        Message();                                //Рефакторинг проходил тут
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Иди работай");
                                        Message();
                                    }
                                }
                                catch ( FormatException wrong_format)
                                {
                                    Console.Clear();
                                    Console.WriteLine("У вас мисклик,внимательно читайте меню");
                                    Message();
                                }
                                break;
                        }

                        break;
                    case GameState.Play:
                        Console.WriteLine("Текущий завод: {0} \nДеньги: {1}$ \nЗадержка: {2} сек", Game.UserCompany.Сompany_name, Game.capital, (Game.UserCompany.Сompany_delay / 1000));
                        Console.WriteLine("M - Меню игры");
                        Console.WriteLine("0%__________________________________________________100%");
                        Console.Write("  ");
                        for (int i = 0; i < 50; i++)
                        {
                            Console.Write("*");
                            System.Threading.Thread.Sleep(Game.UserCompany.Сompany_delay / 50);
                        }
                        Game.capital += Game.UserCompany.Сompany_money;
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