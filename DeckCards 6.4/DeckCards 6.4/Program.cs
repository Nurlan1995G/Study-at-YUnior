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
            string exit = "2";
            string menuShowInfo = "3";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Главное меню.");
                Console.WriteLine($"\n{menuAddCards} - взять карту;\n{exit} - выход из программы");

                string userInput = Console.ReadLine();

                if(userInput == menuAddCards)
                {
                    player.TakeCardFromDeck(deck);
                }
                else if(userInput == exit)
                {
                    Console.WriteLine("Вы вели команду завершения программы!");
                    isWorking = false;
                }
                else if(userInput == menuShowInfo)
                {
                    player.ShowInfoCards();
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
            Suit = suit;
            Number = number;
        }

        public string Suit { get; private set; }
        public int Number { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Suit} - {Number} очков");
        }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            CreateCard();
        }

        private void CreateCard()
        {
            int minValue = 1;
            int maxValue = 10;

            _cards.Add(new Card("Черви", _random.Next(minValue, maxValue)));
            _cards.Add(new Card("Бубна", _random.Next(minValue, maxValue)));
            _cards.Add(new Card("Крести", _random.Next(minValue, maxValue)));
            _cards.Add(new Card("Пика", _random.Next(minValue, maxValue)));
        }

        public bool TryTakeCard(out Card card)
        {
            if(_cards.Count > 0)
            {
                card = _cards[0];
                _cards.Remove(card);
                return true;
            }
            else
            {
                card = null;
                return false;
            }
        }
    }

    class Player
    {
        private List<Card> _cardsParticipant = new List<Card>();

        public void TakeCardFromDeck(Deck deck)
        {
            if (deck.TryTakeCard(out Card card))
            {
                Console.WriteLine($"Карта успешно взята.\nВам выпала - {card.Suit}");
                _cardsParticipant.Add(card);
            }
            else
            {
                Console.WriteLine($"Партия закончилась!");
                ShowAllCardsInfo();
            }
        }

        public void ShowInfoCards()
        {
            foreach (var card in _cardsParticipant)
            {
                card.ShowInfo();
            }
        }

        private void ShowAllCardsInfo()
        {
            int scoreCard = 0;

             for (int i = 0; i < _cardsParticipant.Count; i++)
             {
                _cardsParticipant[i].ShowInfo();
                scoreCard += _cardsParticipant[i].Number;
             }

             Console.WriteLine($"\nВсего очков: {scoreCard}");
        }
    }
}