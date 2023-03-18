using System;

namespace DeckCards
{
    class CardsDeck  
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            string addCards = "1";
            string showAllInfoCards = "2";
            string exit = "3";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Главное меню.");
                Console.WriteLine("\n1 - взять карту;\n2 - посмотреть всю информацию о картах;\n3 - выход из программы");

                string userInput = Console.ReadLine();

                if(userInput == addCards)
                {
                    player.TakeCardFromDeck();
                }
                else if(userInput == showAllInfoCards)
                {
                    player.ShowAllCardsInfo();
                }
                else if(userInput == exit)
                {
                    Console.WriteLine("Вы вели команду завершения программы!");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Вы вели неверную команду!");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public int Number { get; private set; }

        public Card(string suit, int number)
        {
            Suit = suit;
            Number = number;
        }
    }

    class Deck
    {
        Random random = new Random();
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            TakeCard();
        }

        public void TakeCard()
        {
            int minValue = 1;
            int maxValue = 10;

            _cards.Add(new Card("Черви", random.Next(minValue, maxValue)));
            _cards.Add(new Card("Бубна", random.Next(minValue, maxValue)));
            _cards.Add(new Card("Крести", random.Next(minValue, maxValue)));
            _cards.Add(new Card("Пика", random.Next(minValue, maxValue)));
        }

        public bool TryTakeCard(out Card card)
        {
            if(_cards.Count > 0)
            {
                card = _cards[GetNumberCard()];
                _cards.Remove(card);
                return true;
            }
            else
            {
                card = null;
                return false;
            }
        }

        private int GetNumberCard()
        {
            int cardNumber = 0;
            int minSuitNumber = 1;
            int maxSuitNumber = 4;

            if(_cards.Count >= maxSuitNumber)
            {
                cardNumber = random.Next(minSuitNumber, maxSuitNumber);
                maxSuitNumber--;
            }

            return cardNumber;
        }
    }

    class Player
    {
        private List<Card> _cardsPlayer = new List<Card>();
        private Deck _deck = new Deck();

        public void TakeCardFromDeck()
        {
            if(_deck.TryTakeCard(out Card card))
            {
                _cardsPlayer.Add(card);
            }
            else
            {
                Console.WriteLine("Колода карт пуста!");
            }
        }

        public void ShowAllCardsInfo()
        {
            int scoreCard = 0;

            if (_cardsPlayer.Count > 0)
            {
                for (int i = 0; i < _cardsPlayer.Count; i++)
                {
                    Console.WriteLine($"{_cardsPlayer[i].Suit} : {_cardsPlayer[i].Number} очков");
                    scoreCard += _cardsPlayer[i].Number;
                }
            }
            else
            {
                Console.WriteLine("Карт в колоде нет!");
                Console.WriteLine($"{scoreCard} очков");
            }
        }
    }
}