using System;

namespace SuperMarket
{
    class Program  
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.Work();
        }
    }

    class Shop
    {
        private Random _random = new Random();
        private Queue<Buyer> _buyers = new Queue<Buyer>();
        private List<Product> _products = new List<Product>();
        
        public Shop()
        {
            AddProducts();
        }

        public void Work()
        {
            string commandCreateQueue = "1";
            string commandServerQueue = "2";
            string commandExit = "3";
            bool isWorking = true;

            while (isWorking) 
            {
                Console.WriteLine($"\n{commandCreateQueue} - Создать очередь;\n{commandServerQueue} - Обслужить очередь;\n{commandExit} - Выход.");
                string userInput = Console.ReadLine();

                if (userInput == commandCreateQueue)
                {
                    CreateCustomerQueue();
                }
                else if (userInput == commandServerQueue)
                {
                    ServerCustomerQueue();
                }
                else if (userInput == commandExit)
                {
                    Console.WriteLine("Вы вели команду выхода из программы.");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Вы вели неверную команду");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddProducts()
        {
            _products.Add(new Product("Огурцы", GetPriceProducts()));
            _products.Add(new Product("Молоко", GetPriceProducts()));
            _products.Add(new Product("Помидоры", GetPriceProducts()));
            _products.Add(new Product("Мясо", GetPriceProducts()));
            _products.Add(new Product("Чипсы", GetPriceProducts()));
            _products.Add(new Product("Сыр", GetPriceProducts()));
            _products.Add(new Product("Колбаса", GetPriceProducts()));
            _products.Add(new Product("Мука", GetPriceProducts()));
            _products.Add(new Product("Макароны", GetPriceProducts()));
            _products.Add(new Product("Печеньки", GetPriceProducts()));
            _products.Add(new Product("Мороженное", GetPriceProducts()));
        }

        private void CreateCustomerQueue()
        {
            int minNumberQueue = 2;
            int maxNumberQueue = 10;

            int countBuyer = _random.Next(minNumberQueue, maxNumberQueue);

            for (int i = 0; i < countBuyer; i++)
            {
                _buyers.Enqueue(CreateBuyer());
            }

            Console.Clear();
            Console.WriteLine($"Очередь клиентов создана. В очереди {countBuyer} покупателей.");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
        }

        private Buyer CreateBuyer()
        {
            List<Product> products = new List<Product>();

            int minCountMoney = 200;
            int maxCountMoney = 600;
            int minCountProduct = 5;
            int maxCountProduct = 15;

            int countProducts = _random.Next(minCountProduct, maxCountProduct);
            int countMoney = _random.Next(minCountMoney, maxCountMoney);

            for (int i = 0; i < countProducts; i++)
            {
                products.Add(_products[_random.Next(0, _products.Count - 1)]);
            }

            return new Buyer(countMoney, products);
        }

        private void ServerCustomerQueue()
        {
            if(_buyers.Count > 0)
            {
                while(_buyers.Count > 0)
                {
                    _buyers.Dequeue().BuyProducts();
                }

                Console.WriteLine("Очередь обслужена!");
            }
            else
            {
                Console.WriteLine("Клиентов нет.");
            }
        }

        private int GetPriceProducts()
        {
            int minValue = 10;
            int maxValue = 100;
            int priceProduct = _random.Next(minValue,maxValue);

            return priceProduct;
        }
    }

    class Product
    {
        public Product(string title, int price)
        {
            Title = title;
            Price = price;
        }

        public string Title { get; private set; }
        public int Price { get; private set; }
    }

    class Buyer
    {
        private List<Product> _products;
        private int _money;

        public Buyer(int money, List<Product> products)
        {
            _products = products;
            _money = money;
        }
        
        public void BuyProducts()
        {
            Console.Clear();
            Console.WriteLine("---- Корзина покупок ----\n");
            ShowBasketProducts();
            Console.WriteLine($"\nСтоимость всей корзины покупок - {GetPurchaseAmount()}, у клиента {_money} рублей\n");

            if(_money >= GetPurchaseAmount())
            {
                Console.WriteLine($"\nКлиент приобрел покупку на {GetPurchaseAmount()} рублей");
            }
            else
            {
                RemoveUnwantedProducts();
                Console.WriteLine($"\nКлиент приобрел продукты, на что хватило!\n");
                Console.WriteLine("---- В пакете у покупателя ----\n");
                ShowBasketProducts();
            }

            Console.ReadKey();
            Console.Clear();
        }

        private int GetPurchaseAmount()
        {
            int purchaseAmount = 0;

            foreach (Product product in _products)
            {
                purchaseAmount += product.Price;
            }

            return purchaseAmount;
        }

        private void RemoveProducts()
        {
            Random random = new Random(); 

            int indexProduct = random.Next(0, _products.Count);
            Product product = _products[indexProduct];

            Console.WriteLine($"Клиент выложил с корзины: {product.Title}, стоимость - {product.Price} рублей");
            _products.Remove(product);
        }

        private void RemoveUnwantedProducts()
        {
            while(GetPurchaseAmount() >= _money)
                RemoveProducts();
        }

        private void ShowBasketProducts()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine($"{product.Title} - {product.Price}");
            }
        }
    }
}
