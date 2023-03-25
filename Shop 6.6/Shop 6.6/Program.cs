using System;

namespace Program
{
    class ShopTaskProgram  //Существует продавец, он имеет у себя список товаров, и при нужде, может вам его показать, также продавец может продать вам товар. После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
                           //Возможные классы – игрок, продавец, товар.
                           //Вы можете сделать так, как вы видите это.
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Work();
        }
    }

    class Shop
    {
        private Player _player = new Player();
        private Seller _seller = new Seller();

        public void Work()
        {
            string menuShowListProducts = "1";
            string menuMakingPurchase = "2";
            string menuViewingPurchasedProducts = "3";
            string menuExit = "4";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Добро пожаловать в продуктовый магазин.");
                Console.WriteLine($"Касса продавца: {_seller.Money}");
                Console.WriteLine($"\n{menuShowListProducts} - Вывод списка продуктов продавца;\n{menuMakingPurchase} - Совершение покупки;" +
                    $"\n{menuViewingPurchasedProducts} - Просмотр купленных продуктов;\n{menuExit} - Выход из программы.");

                string userInput = Console.ReadLine();

                if (userInput == menuShowListProducts)
                {
                    _seller.ShowInfoProducts();
                }
                else if (userInput == menuMakingPurchase)
                {
                    MakingPurchase();
                }
                else if (userInput == menuViewingPurchasedProducts)
                {
                    _player.ShowInventory();
                }
                else if (userInput == menuExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы.");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Вы вели неверную команду. Попробуйте еще раз.");
                }

                Console.WriteLine("Нажмите на любую клавишу для продолжения.");
                Console.ReadKey();
            }
        }

        private void MakingPurchase()
        {
            if(_seller.TryGetProduct(out Product product))
            {
                if(_player.Money >= product.Price)
                {
                    _player.BuyProduct(product);
                    _seller.Sell(product);

                    Console.WriteLine("Покупка пройдена успешно!");
                    Console.WriteLine($"Баланс у покупателя - {_player.Money}");
                    Console.WriteLine($"Касса у продавца - {_seller.Money}");
                }
                else
                {
                    Console.WriteLine("У покупателя недостаточно денег.");
                }
            }
        }
    }

    class Person
    {
        protected List<Product> Products = new List<Product>();
        public int Money { get; protected set; }
    }

    class Player : Person
    {
        int sumMoney = 50;

        public Player()
        {
            Money = sumMoney;
        }

        public void ShowInventory()
        {
            if (Products.Count != 0)
            {
                foreach (var product in Products)
                {
                    Console.WriteLine($"В сумке: {product.Title}");
                }
            }
            else
            {
                Console.WriteLine("У вас пока пустая сумка.");
            }
        }

        public void BuyProduct(Product product)
        {
            Products.Add(product);
            Money -= product.Price;
        }
    }

    class Seller : Person
    {
        public Seller()
        {
            AddProduct();
            Money = 0;
        }

        public void ShowInfoProducts()
        {
            Console.WriteLine("Добро пожаловать в мой магазин! Вот мой список продуктов.");

            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{Products[i].Number}  {Products[i].Title} - {Products[i].Price} рублей");
            }
        }

        public bool TryGetProduct(out Product product)
        {
            product = null;
            bool isFound = false;

            Console.Write("Введите номер команды из меню: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int numberToFind);

            if (isNumber)
            {
                if (Products.Count == 0)
                {
                    Console.WriteLine("У продавца нет продуктов!");
                }
                else
                {
                    for (int i = 0; i < Products.Count; i++)
                    {
                        if (numberToFind == Products[i].Number)
                        {
                            product = Products[i];
                            isFound = true;
                            return true;
                        }
                    }
                }

                 if (isFound == false)
                 {
                     Console.WriteLine("Такого продукта нет");
                 }
            }
            else
            {
                Console.WriteLine("Такой каманды нет.");
            }

            return false;
        }

        public void Sell(Product product)
        {
            Money += product.Price;
            Products.Remove(product);
        }

        private void AddProduct()
        {
            Products.Add(new Product(0, "Яблоки", 15));
            Products.Add(new Product(1, "Бананы", 17));
            Products.Add(new Product(2, "Груши", 16));
            Products.Add(new Product(3, "Хлеб", 8));
            Products.Add(new Product(4, "Молоко", 12));
            Products.Add(new Product(5, "Мясо", 25));
            Products.Add(new Product(6, "Макароны", 10));
            Products.Add(new Product(7, "Огурцы", 11));
            Products.Add(new Product(8, "Помидоры", 11));
            Products.Add(new Product(9, "Картофель", 10));
        }
    }

    class Product
    {
        public Product(int number, string title, int price)
        {
            Title = title;
            Price = price;
            Number = number;
        }

        public string Title { get; private set; }
        public int Price { get; private set; }
        public int Number { get; private set; }
    }
}

