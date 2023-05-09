using System;

namespace DeckCards
{
    class CardsDeck  
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Deck deck = new Deck();

            string menuAddCards = "1";
            string menuShowInfo = "2";
            string exit = "3";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Главное меню.");
                Console.WriteLine($"\n{menuAddCards} - взять карту;\n{menuShowInfo} - Показать информацию о картах;" +
                    $"\n{exit} - выход из программы");

                string userInput = Console.ReadLine();

                if(userInput == menuAddCards)
                {
                    player.TakeCardFromDeck(deck);
                }
                else if(userInput == menuShowInfo)
                {
                    player.ShowInfoCards();
                }
                else if (userInput == exit)
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
        public Card(string suit, int number)
        {
            Name = suit;
            Point = number;
        }

        public string Name { get; private set; }
        public int Point { get;  set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Point} очков");
        }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            CreateCards();
        }

        public bool TryGetCard(out Card card)
        {
            if (_cards.Count > 0)
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

        private void CreateCards()
        {
            _cards.Add(new Card("Шестёрка", GetPoints()));
            _cards.Add(new Card("Семёрка", GetPoints()));
            _cards.Add(new Card("Восьмёрка", GetPoints()));
            _cards.Add(new Card("Девятка", GetPoints()));
            _cards.Add(new Card("Десятка", GetPoints()));
            _cards.Add(new Card("Валет", GetPoints()));
            _cards.Add(new Card("Дама", GetPoints()));
            _cards.Add(new Card("Король", GetPoints()));
            _cards.Add(new Card("Туз", GetPoints()));
        }

        private int GetNumberCard()
        {
            int randomIndex = 0;

            if(_cards.Count > 0)
            {
                randomIndex = _random.Next(0, _cards.Count);
            }

            return randomIndex;
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
    }

    class Player
    {
        private List<Card> _cardsParticipant = new List<Card>();

        public void TakeCardFromDeck(Deck deck)
        {
            int maxCountCart = 4;

            if (deck.TryGetCard(out Card card) && _cardsParticipant.Count + 1 <= maxCountCart)
            {
                if (card != null)
                {
                    Console.WriteLine($"Карта успешно взята.\nВам выпала - {card.Name}");
                    _cardsParticipant.Add(card);
                }
            }
            else
            {
                Console.WriteLine($"Партия закончилась!");
                ShowAllCardsInfo();
            }
        }

        public void ShowInfoCards()
        {
            if (_cardsParticipant.Count > 0)
            {
                foreach (var card in _cardsParticipant)
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

             for (int i = 0; i < _cardsParticipant.Count; i++)
             {
                _cardsParticipant[i].ShowInfo();
                scoreCard += _cardsParticipant[i].Point;
             }

             Console.WriteLine($"\nВсего очков: {scoreCard}");
        }
    }
}