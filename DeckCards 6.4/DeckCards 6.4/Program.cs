using System;

namespace DeckCards
{
    class Program  
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Deck deck = new Deck();

            string menuAddCards = "1";
            string menuShowInfo = "2";
            string menuExit = "3";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Главное меню.");
                Console.WriteLine($"\nКрупье предлагает вам выполнить действие:\n{menuAddCards} - взять карту;" +
                    $"\n{menuShowInfo} - Показать информацию о картах;\n{menuExit} - выход из программы");

                string userInput = Console.ReadLine();

                if(userInput == menuAddCards)
                {
                    player.GetCards();
                }
                else if(userInput == menuShowInfo)
                {
                    player.ShowInfo();
                }
                else if (userInput == menuExit)
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
        public Card( int index, string suit, int point)
        {
            Index = index;
            Suit = suit;
            Point = point;
        }

        public int Index { get; set; }
        public string Suit { get; private set; }
        public int Point { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Index}) Масть - {Suit} / {Point} очков");
        }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _cards = new List<Card>();
        private int _number = 6;

        public Deck()
        {
            CreateCards();
        }

        public bool TryGetCard(out Card card)
        {
            if (_cards.Count > 0)
            {
                card = _cards[ShuffleCards(_cards)];
                _cards.Remove(card);
                return true;
            }
            else
            {
                card = null;
                return false;
            }
        }

        private void CreateCards()
        {
            _cards.Add(new Card(0,"Шестёрка", GetPoints()));
            _cards.Add(new Card(1,"Семёрка", GetPoints()));
            _cards.Add(new Card(2,"Восьмёрка", GetPoints()));
            _cards.Add(new Card(3,"Девятка", GetPoints()));
            _cards.Add(new Card(4,"Десятка", GetPoints()));
            _cards.Add(new Card(5,"Валет", GetPoints()));
            _cards.Add(new Card(6,"Дама", GetPoints()));
            _cards.Add(new Card(7,"Король", GetPoints()));
            _cards.Add(new Card(8,"Туз", GetPoints()));
        }

        private int GetPoints()
        {
            int number = 6;

            for (int i = 0; i < _cards.Count; i++)
            {
                number++;
            }

            return number;
        }

        private int ShuffleCards(List<Card> cards)
        {
            int number = 2;
            int randomIndex;
            int shuffleElement = 0;

            for (int i = _cards.Count - number; i >= 0; i--)
            {
                randomIndex = _random.Next(i);
                shuffleElement = cards[randomIndex].Index;
                cards[randomIndex].Index = cards[i].Index;
                cards[i].Index = shuffleElement;

                return shuffleElement;
            }

            return shuffleElement;
        }
    }

    class Croupier
    {
        private List<Card> _cards = new List<Card>();
        private Deck _deck = new Deck();

        public void TakeCardFromDeck()
        {
            int maxCountCard = 4;

            if (_deck.TryGetCard(out Card card) && _cards.Count + 1 <= maxCountCard)
            {
                if (card != null)
                {
                    Console.WriteLine($"Карта успешно выдана вам.\nВам выпала - {card.Suit}");
                    _cards.Add(card);
                }
            }
            else
            {
                Console.WriteLine($"Крупье заканчил партию и подводит итог игры!");
                ShowAllCardsInfo();
            }
        }

        public void ShowInfoCards()
        {
            if (_cards.Count > 0)
            {
                foreach (Card card in _cards)
                {
                    card.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("У вас пока нет карт");
            }
        }

        private void ShowAllCardsInfo()
        {
            int scoreCard = 0;

            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].ShowInfo();
                scoreCard += _cards[i].Point;
            }

            Console.WriteLine($"\nВсего очков: {scoreCard}");
        }
    }

    class Player
    {
        private List<Card> _cardsParticipant = new List<Card>();
        private Croupier _croupier = new Croupier();

        public void GetCards()
        {
            _croupier.TakeCardFromDeck();
        }

        public void ShowInfo()
        {
            _croupier.ShowInfoCards();
        }
    }
}