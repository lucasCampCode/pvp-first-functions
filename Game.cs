using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public int statBoost;
    }

    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item _sword;
        private Item _dagger;

        //Run the game
        public void Run()
        {
            Start();

            while(_gameOver == false)
            {
                Update();
            }

            End();
        }

        public void InitializeWeapons()
        {
            _sword.statBoost = 20;

            _dagger.statBoost = 10;
        }

        
        public void ClearScreen()
        {
            Console.WriteLine("press any key to continue!");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        //universal player input
        public void GetInput(out char input,string option1,string option2,string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write("> ");
            
            input = ' ';
            while(input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if(input != '1' && input != '2')
                {
                    Console.WriteLine("invalid input!");
                }
            }
            
        }
        //equips items to players
        public void SelectItem(Player player)
        {
            char input;
            GetInput(out input, "sword", "dagger", "choose your weapon! player one");
            if (input == '1')
            {
                player.EquipItem(_sword);
            }
            else if(input == '2')
            {
                player.EquipItem(_dagger);
            }

            Console.WriteLine("player 1");
            player.PrintStats();
            ClearScreen();

        }
        public Player CreateCharater()
        {
            Console.WriteLine("what is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name,100,10);
            SelectItem(player);
            return player;
        }
        
        public void StartBattle()
        {
            Console.WriteLine("Battle begin");

            while(_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                Console.WriteLine("player one stats");
                _player1.PrintStats();
                Console.WriteLine("player two stats");
                _player2.PrintStats();
                Console.WriteLine();
                char input;
                GetInput(out input, "Attack","defend","your turn player one!");
                if (input == '1')
                {
                    _player1.Attack(_player2);
                }
                else if (input == '2')
                {
                    Console.WriteLine("you can't defend");
                    Console.ReadKey();
                }

                GetInput(out input, "Attack", "defend", "your turn player two!");
                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else if (input == '2')
                {
                    Console.WriteLine("you can't defend");
                    Console.ReadKey();
                }
                Console.Clear();
            }
            _gameOver = true;
        }

        public void battleOver()
        {
            if(_player1.GetIsAlive())
            {
                Console.WriteLine("player one wins!!!");
            }
            else
            {
                Console.WriteLine("player two wins!!!");
            }
            ClearScreen();
        }

        //Performed once when the game begins
        public void Start()
        {
            InitializeWeapons();
            _player1 = CreateCharater();
            _player2 = CreateCharater();

        }

        //Repeated until the game ends
        public void Update()
        {
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            battleOver();
        }
    }
}
