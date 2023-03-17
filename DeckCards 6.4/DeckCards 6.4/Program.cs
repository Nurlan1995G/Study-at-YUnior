using System;

namespace DeckCards
{
    class CardsDeck  //Есть колода с картами. Игрок достает карты, пока не решит, что ему хватит карт (может быть как выбор пользователя, так и количество сколько карт надо взять). После выводиться вся информация о вытянутых картах.
                     //Возможные классы: Карта, Колода, Игрок.
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            string addCards = "1";
            string showAllInfoCards = "2";
            string exit = "3";
            int addCard = 1;
            int showAllInfoCard = 2;
            int exitCard = 3;
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("1 - Взять карту; 2 - Посмотреть полную информацию; 3 - выход из игры.");

                string userInput = Console.ReadLine();

                    if(userInput == addCards)
                    {
                        player.GetCard();
                    }
                    else if(userInput == showAllInfoCards)
                    {
                        player.ShowIfoCards();
                    }
                    else if(userInput == exit)
                    {
                        Console.WriteLine("Вы вели команду выхода из программы!");
                        isWorking = false;
                    }

                Console.ReadKey();
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
        private Random random = new Random();
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            AddCard();
        }

        public void AddCard()
        {
            _cards.Add(new Card("Черви", random.Next(1, 10)));
            _cards.Add(new Card("Крести", random.Next(1, 10)));
            _cards.Add(new Card("Пика", random.Next(1, 10)));
            _cards.Add(new Card("Бубна", random.Next(1, 10)));
        }

        public bool TryTakeCards(out Card card)
        {
            if(_cards.Count > 0)
            {
                card = _cards[GetSuitCards()];
                _cards.Remove(card);
                return true;
            }
            else
            {
                card = null;
                return false;
            }
        }

        public int GetSuitCards()
        {
            int suitCard = 0;
            int minSuitCard = 1;
            int maxSuitCard = 4;

            if(_cards.Count >= maxSuitCard)
            {
                suitCard = random.Next(minSuitCard, maxSuitCard);
                maxSuitCard--;
            }

            return suitCard;
        }
    }

    class Player
    {
        private List<Card> _cardsPlayer = new List<Card>();
        private Deck _decks = new Deck();

        public void GetCard()
        {
            if(_decks.TryTakeCards(out Card card))
            {
                _cardsPlayer.Add(card);
            }
            else
            {
                Console.WriteLine("Карты закончились!");
                ShowIfoCards();
            }
        }

        public void ShowIfoCards()
        {
            int cardNumber = 0;

            if (_cardsPlayer.Count > 0)
            {
                for (int i = 0; i < _cardsPlayer.Count; i++)
                {
                    Console.WriteLine($"{_cardsPlayer[i].Suit} : {_cardsPlayer[i].Number} очков");
                    cardNumber += _cardsPlayer[i].Number;
                }
            }
            else
            {
                Console.WriteLine("Больше карт нет!");
                Console.WriteLine($"Кол-во очков - {cardNumber}");
            }
        }

    }
}