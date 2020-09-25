using System;

namespace HelloWorld
{
    struct Item
    {
        public string name;
        public int cost;
        public int statBoost;
    }

    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item _sword;
        private Item _dagger;
        private Item _bow;
        private Item _crossBow;
        private Item _cherryBomb;
        private Item _mace;

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

        private void InitWeapons()
        {
            _sword.name = "sword";
            _sword.statBoost = 20;
            _dagger.name = "dagger";
            _dagger.statBoost = 10;
            _bow.name = "bow";
            _bow.statBoost = 12;
            _crossBow.name = "crossBow";
            _crossBow.statBoost = 34;
            _cherryBomb.name = "cherryBomb";
            _cherryBomb.statBoost = 24;
            _mace.name = "mace";
            _mace.statBoost = 15;
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
            Console.WriteLine();
        }
        public void GetInput(out char input, string option1, string option2,string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("invalid input!");
                }
            }
            Console.WriteLine();
        }
        public void GetInput(out char input, string option1, string option2, string option3, string query,bool messUp)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write("> ");

            input = ' ';
            if(messUp == false)
            {
                while (input != '1' && input != '2' && input != '3')
                {
                    input = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (input != '1' && input != '2' && input != '3')
                    {
                        Console.WriteLine("invalid input!");
                    }
                }
            }
            else
            {
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        //equips items to players
        public void SelectLoadout(Player player)
        {
            Console.Clear();
            Console.WriteLine("Loadout 1: ");
            Console.WriteLine(_sword.name);
            Console.WriteLine(_cherryBomb.name);
            Console.WriteLine(_dagger.name);

            Console.WriteLine("\nLoadout 2: ");
            Console.WriteLine(_bow.name);
            Console.WriteLine(_mace.name);
            Console.WriteLine(_crossBow.name);
            Console.WriteLine();
            char input;
            GetInput(out input, "loadout 1", "loadout 2", "choose your weapon!");
            if (input == '1')
            {
                player.AddItemToInv(_sword, 0);
                player.AddItemToInv(_cherryBomb, 1);
                player.AddItemToInv(_dagger, 2);
            }
            else if (input == '2')
            {
                player.AddItemToInv(_bow, 0);
                player.AddItemToInv(_mace, 1);
                player.AddItemToInv(_crossBow, 2);
            }
            Console.WriteLine("player " + player.GetName());
            player.PrintStats();
            ClearScreen();

        }
        public Player CreateCharater()
        {
            Console.WriteLine("what is your name?");
            Player player = new Player(Console.ReadLine(),100,10,3);
            SelectLoadout(player);
            return player;
        }
        public void SwitchWeapons(Player player)
        {
            Console.Clear();
            Item[] inventory = player.GetInventory();

            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + " \n Damage: " + inventory[i].statBoost);
            }
            Console.WriteLine();

            char input;
            GetInput(out input, inventory[0].name, inventory[1].name, inventory[2].name, "choose your weapon",true);
            switch (input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("you equiped " + inventory[0].name);
                        Console.WriteLine("base damage increased by " + inventory[0].statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("you equiped " + inventory[1].name);
                        Console.WriteLine("base damage increased by " + inventory[1].statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("you equiped " + inventory[2].name);
                        Console.WriteLine("base damage increased by " + inventory[2].statBoost);
                        break;
                    }
                default:
                    {
                        player.UnequipItem();
                        Console.WriteLine("you equiped hands");
                        break;
                    }
            }
        }
        
        public void StartBattle()
        {
            Console.WriteLine("Battle begin");

            while(_player1.IsAlive() && _player2.IsAlive())
            {
                Console.WriteLine(_player1.GetName() + " stats");
                _player1.PrintStats();
                Console.WriteLine(_player2.GetName() + " stats");
                _player2.PrintStats();
                Console.WriteLine();
                char input;
                GetInput(out input, "Attack", "change weapons", "your turn " + _player1.GetName());
                if (input == '1')
                {
                    _player1.Attack(_player2);
                }
                else if (input == '2')
                {
                    SwitchWeapons(_player1);
                    Console.ReadKey();
                }

                GetInput(out input, "Attack", "change weapons", "your turn " + _player2.GetName());
                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else if (input == '2')
                {
                    SwitchWeapons(_player2);
                    Console.ReadKey();
                }
                Console.Clear();
            }
            _gameOver = true;
        }

        public void battleOver()
        {
            if(_player1.IsAlive())
            { 
                Console.WriteLine("player "+ _player1.GetName() +" wins!!!");
            }
            else
            {
                Console.WriteLine("player "+ _player2.GetName() +" wins!!!");
            }
            ClearScreen();
        }

        //Performed once when the game begins
        public void Start()
        {
            InitWeapons();
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
