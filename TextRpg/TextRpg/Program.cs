namespace TextRpg
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        public interface ICharacter
        {
            int Level { get; set; }
            string Name { get; }
            int Attack { get; set; }
            int Health { get; set; }
            int Gold { get; set; }

            void ShowInfo();
        }

        public class Warrior : ICharacter
        {
            public int Level { get; set; }
            public string Name { get; }
            public int Attack { get; set; }
            public int Health { get; set; }
            public int Gold { get; set; }

            public Warrior(string name)
            {
                Name = name;
                Level = 01;
                Attack = 10;
                Health = 100;
                Gold = 1500;
            }

            public void ShowInfo()
            {
                Console.WriteLine(" ");
                Console.WriteLine($"Lv.{Level}");
                Console.WriteLine($"Chad: {Name}");
                Console.WriteLine($"공격력: {Attack}");
                Console.WriteLine($"체력: {Health}");
                Console.WriteLine($"Gold: {Gold}G");
        
            }
        }
        public class Item
        {
            public string ItemName { get; set; }
            public string ItemExplanation { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }
            public int Price { get; set; }
            public bool Buy { get; set; }

            public Item(string itemName, string itemExplanation, int attack, int defense, int price) // 아이템 클래스 생성자
            {
                ItemName = itemName;
                ItemExplanation = itemExplanation;
                Attack = attack;
                Defense = defense;
                Price = price;
                Buy = false;
            }

        }

       
        static void ChoiceNumber(Warrior player)
        {
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            bool isValid = false;
            while (!isValid)
            {
                Console.Write(">>>");
                int userChoice;
                if (int.TryParse(Console.ReadLine(), out userChoice) && userChoice > 0 && userChoice < 4)
                {
                    switch (userChoice)
                    {
                        case 1:
                            PlayerInfo(player);
                            break;
                        case 2:
                            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                            Exit(player);
                            break;
                        case 3:
                            Shop(player);
                            break;
                    }
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("1~3까지 중에서 골라주세요.");
                }
            }
        }

        static void Exit(Warrior player)
        {
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            bool exit = false;
            while (!exit)
            {
                Console.Write(">>>");
                int userChoice;
                if (int.TryParse(Console.ReadLine(), out userChoice) && userChoice == 0)
                {
                    ChoiceNumber(player);
                    exit = true;
                }
                else
                {
                    Console.WriteLine("다시 입력해주세요.");
                }
            }
        }

        static void PlayerInfo(ICharacter player)
        {
            player.ShowInfo();
            Exit((Warrior)player);
        }

        static void Shop(Warrior player)
        {
            Console.WriteLine($"현재 보유 골드: {player.Gold}G");
            Console.WriteLine("- 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.|  1000 G");
            Console.WriteLine("- 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.|  2200 G");
            Console.WriteLine("- 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  3500 G");
            Console.WriteLine("- 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.|  600 G");
            Console.WriteLine("- 청동 도끼     | 공격력 +5  | 어디선가 사용됐던거 같은 도끼입니다.|  1500 G");
            Console.WriteLine("- 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다.|  2500 G");
            Console.WriteLine("1. 구매");
            Exit(player);
        }

        static void Inventory()
        {
            Console.WriteLine();


        }

        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Warrior player = new Warrior("전사");
           
            ChoiceNumber(player);
        }
    }
}
