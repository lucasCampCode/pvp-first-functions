using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }
    struct Item
    {
        public int healthBoost;
        public int damageBoost;
    }
    class Game
    {
        bool _gameOver = false;
        Player _player1, _player2;
        Item sword, dagger;

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

        public void InitializePlayers()
        {
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;

        }
        public void InitializeItems()
        {
            sword.healthBoost = 10;
            sword.damageBoost = 20;

            dagger.healthBoost = 20;
            dagger.damageBoost = 10;
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
        public void EquipItems()
        {
            char input;
            GetInput(out input, "sword", "dagger", "choose your weapon! player one");
            if (input == '1')
            {
                _player1.damage += sword.damageBoost;
            }
            else if(input == '2')
            {
                _player1.damage += dagger.damageBoost;
            }

            Console.WriteLine("player 1");
            PrintStats(_player1);

            GetInput(out input, "sword", "dagger", "choose your weapon! player two");
            if (input == '1')
            {
                _player2.damage += sword.damageBoost;
            }
            else if (input == '2')
            {
                _player2.damage += dagger.damageBoost;
            }
            Console.WriteLine("player 2");
            PrintStats(_player2);
            ClearScreen();

        }
        public void PrintStats(Player player)
        {
            Console.WriteLine("health: " + player.health);
            Console.WriteLine("damage: " + player.damage);
            Console.WriteLine();
        }
        public void StartBattle()
        {
            Console.WriteLine("Battle begin");

            while(_player1.health > 0 && _player2.health > 0)
            {
                Console.WriteLine("player one stats");
                PrintStats(_player1);
                Console.WriteLine("player two stats");
                PrintStats(_player2);
                Console.WriteLine();
                char input;
                GetInput(out input, "Attack","defend","your turn player one!");
                if (input == '1')
                {
                    _player2.health -= _player1.damage;
                }else if (input == '2')
                {
                    Console.WriteLine("you can't defend");
                    Console.ReadKey();
                }

                GetInput(out input, "Attack", "defend", "your turn player two!");
                if (input == '1')
                {
                    _player1.health -= _player2.damage;
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
            if(_player1.health > 0)
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
            InitializeItems();
            InitializePlayers();
            EquipItems();
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
