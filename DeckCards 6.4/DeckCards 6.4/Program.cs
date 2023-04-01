using System;

namespace DeckCards
{
    class CardsDeck  
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            string menuAddCards = "1";
            string exit = "2";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Главное меню.");
                Console.WriteLine($"\n{menuAddCards} - взять карту;\n{exit} - выход из программы");

                string userInput = Console.ReadLine();

                if(userInput == menuAddCards)
                {
                    player.TakeCardFromDeck();
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
        public Card(string suit, int number)
        {
            Suit = suit;
            Number = number;
        }

        public string Suit { get; private set; }
        public int Number { get; private set; }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            AddCard();
        }

        private void AddCard()
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
            int maxSuitNumber = 6;

            if(_cards.Count >= maxSuitNumber)
            {
                cardNumber = _random.Next(minSuitNumber, maxSuitNumber);
            }

            return cardNumber;
        }
    }

    class Player
    {
        private List<Card> _cardsParticipant = new List<Card>();
        private Deck _deck = new Deck();

        public void TakeCardFromDeck()
        {
            if (_deck.TryTakeCard(out Card card))
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

        private void ShowAllCardsInfo()
        {
            int scoreCard = 0;

             for (int i = 0; i < _cardsParticipant.Count; i++)
             {
                Console.WriteLine($"{_cardsParticipant[i].Suit} - {_cardsParticipant[i].Number} очков");
                scoreCard += _cardsParticipant[i].Number;
             }

             Console.WriteLine($"\nВсего очков: {scoreCard}");
        }
    }
}