namespace TextRpg
{
    using System;
    using System.Collections.Generic;
    using static TextRpg.Program;

    internal class Program
    {
       // 플레이어 정보
        public interface ICharacter
        {
            int Level { get; set; }
            string Name { get; }
            int Attack { get; set; }
            int Health { get; set; }
            int Defense { get; set; }
            int Gold { get; set; }

            void ShowInfo();
        }

        public class Character : ICharacter
        {
            public int Level { get; set; }
            public string Name { get; }
            public int Attack { get; set; }
            public int Health { get; set; }
            public int Defense { get; set; }
            public int Gold { get; set; }

            public Character(string name)
            {
                Name = name;
                Level = 01;
                Attack = 10;
                Health = 50;
                Defense = 0;
                Gold = 1500;
            }

            public void ShowInfo()
            {
                Console.WriteLine(" ");
                Console.WriteLine($"Lv.{Level}");
                Console.WriteLine($"Chad: {Name}");
                Console.WriteLine($"공격력: {Attack}");
                Console.WriteLine($"체력: {Health}");
                Console.WriteLine($"체력: {Defense}");
                Console.WriteLine($"Gold: {Gold}G");
        
            }
        }

        // 아이템 리스트
        static List<Item> items = new List<Item>
        {
            new Item("수련자 갑옷", "방어력 +5, 수련에 도움을 주는 갑옷입니다.", 0 , 5, 1000),
            new Item("무쇠 갑옷", "방어력 +9, 무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, 2200),
            new Item("스파르타의 갑옷", "방어력 +15, 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15, 3500),
            new Item("낡은 검", "공격력 +2, 쉽게 볼 수 있는 낡은 검입니다.", 2, 0, 600),
            new Item("청동 도끼", "공격력 +5, 어디선가 사용됐던 거 같은 도끼입니다.", 5, 0, 1500),
            new Item("스파르타의 창", "공격력 +7, 스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, 3800)
        };
        
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


       // 초기 선택 화면
        static void ChoiceNumber(Character player)
        {
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 휴식하기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            bool isValid = false;
            while (!isValid)
            {
                Console.Write(">>>");
                int userChoice;
                
                if (int.TryParse(Console.ReadLine(), out userChoice) && userChoice > 0 && userChoice < 5)
                {
                    switch (userChoice)
                    {
                        case 1:
                            PlayerInfo(player);
                            break;
                        case 2:
                            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                            Inventory(player);
                            
                            break;
                        case 3:
                            Shop(player);
                            break;

                        case 4:
                            Rest(player);
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


       
        // 플레이어 정보
        static void PlayerInfo(ICharacter player)
        {
            player.ShowInfo();
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            bool exit = false;
            while (!exit)
            {
                Console.Write(">>>");
                int userChoice;
                if (int.TryParse(Console.ReadLine(), out userChoice) && userChoice == 0)
                {
                    ChoiceNumber((Character)player);
                    exit = true;
                }
                else
                {
                    Console.WriteLine("다시 입력해주세요.");
                }
            }

        }



        //인벤토리
        static List<Item> equippedItems = new List<Item>();

        static void Inventory(Character player)
        {
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine("\n[ 아이템 목록 ]");
            for (int i = 0; i < purchasedItems.Count; i++)
            {
                bool isEquipped = equippedItems.Any(item => item.ItemName == purchasedItems[i].ItemName);
                string equippedMark = isEquipped ? "[E] " : "";
                Console.WriteLine($"{i + 1}. {equippedMark}{purchasedItems[i].ItemName} | {purchasedItems[i].ItemExplanation}");
            }

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.Write(">> ");
            int action;
            if (int.TryParse(Console.ReadLine(), out action))
            {
                switch (action)
                {
                    case 1:
                        ManageEquipment(player);
                        break;
                    case 0:
                        ChoiceNumber(player);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }

        static void ManageEquipment(Character player)
        {
            Console.WriteLine("** 장착 관리 **");

            Console.WriteLine("\n[ 아이템 목록 ]");
            for (int i = 0; i < purchasedItems.Count; i++)
            {
                bool isEquipped = equippedItems.Any(item => item.ItemName == purchasedItems[i].ItemName);
                string equippedMark = isEquipped ? "[E] " : "";
                Console.WriteLine($"{i + 1}. {equippedMark}{purchasedItems[i].ItemName} | {purchasedItems[i].ItemExplanation}");
            }

            Console.WriteLine("0. 나가기");
            Console.Write(">> ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= purchasedItems.Count)
            {
                Item selectedItem = purchasedItems[choice - 1];

                bool isEquipped = equippedItems.Any(item => item.ItemName == selectedItem.ItemName);
                if (isEquipped)
                {
                    equippedItems.RemoveAll(item => item.ItemName == selectedItem.ItemName);
                    player.Attack -= selectedItem.Attack;
                    player.Defense -= selectedItem.Defense;
                    Console.WriteLine($"{selectedItem.ItemName}을(를) 장착 해제했습니다.");
                }
                else
                {
                    equippedItems.Add(selectedItem);
                    player.Attack += selectedItem.Attack;
                    player.Defense += selectedItem.Defense;
                    Console.WriteLine($"{selectedItem.ItemName}을(를) 장착했습니다.");
                }
                Inventory(player);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }




        // 상점
        static void Shop(Character player)
        {
            Console.WriteLine($"현재 보유 골드: {player.Gold}G");

            Console.WriteLine("[ 아이템 목록 ]");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"- {items[i].ItemName} | {items[i].ItemExplanation} | {items[i].Price}G{(items[i].Buy ? " - 구매 완료" : "")}");
            }

            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요.\n");
            Console.WriteLine(" 0. 나가기\n 1. 아이템 구매\n");

            bool store = false;
            while (!store)
            {
                Console.Write(">>>");
                int storeInput = int.Parse(Console.ReadLine());

                if (storeInput == 0 || storeInput == 1)
                {
                    switch (storeInput)
                    {
                        case 0:
                            ChoiceNumber(player);
                            store = true;
                            break;
                        case 1:
                            BuyItem(player);
                            store = true;
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 유효한 번호를 입력하세요.\n");
                }

            }
        }
        static List<Item> purchasedItems = new List<Item>();
        static void BuyItem(Character player)
        {

            Console.WriteLine("[ 아이템 목록 ]");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].ItemName} | {items[i].ItemExplanation} | {items[i].Price}G{(items[i].Buy ? " - 구매 완료" : "")}");
            }

            bool buying = true;
            while (buying)
            {
                Console.Write(">>> ");
                int buyItem;
                if (int.TryParse(Console.ReadLine(), out buyItem) && buyItem > 0 && buyItem <= items.Count)
                {
                    Item selectedItem = items[buyItem - 1];

                    if (selectedItem.Buy)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다!");
                    }
                    else if (player.Gold >= selectedItem.Price)
                    {
                        player.Gold -= selectedItem.Price;
                        selectedItem.Buy = true;
                        purchasedItems.Add(selectedItem);
                        Console.WriteLine($"{selectedItem.ItemName}을(를) 구매했습니다! 남은 골드: {player.Gold}G");

                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다!");
                    }


                    Console.WriteLine("\n[ 아이템 목록 ]");
                    for (int i = 0; i < items.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {items[i].ItemName} | {items[i].ItemExplanation} | {items[i].Price}G{(items[i].Buy ? " - 구매 완료" : "")}");
                    }
                }
                else
                {
                    Console.WriteLine("다시 입력해주세요.");
                }

                Console.WriteLine("\n0. 나가기\n1. 계속 구매");
                Console.Write(">>> ");
                int nextAction;
                if (int.TryParse(Console.ReadLine(), out nextAction) && nextAction == 0)
                {
                    buying = false;
                    Shop(player);
                }
            }

        }

        static void Rest(Character player)
        {
            Console.WriteLine($"500G를 지불하면 체력을 100까지 회복할 수 있습니다. (보유 골드: {player.Gold}G)");

            bool restSelect = false;

            while (!restSelect)
            {
                Console.WriteLine("\n0. 나가기 \n1. 휴식하기\n  ");
                Console.Write(">>>");
                
                int num;
                if(int.TryParse(Console.ReadLine(), out num)&&num<2)
                {
                    if (num == 1)
                    {
                        if (player.Gold >= 500)
                        {
                            if (player.Health < 100)
                            {
                                player.Gold -= 500;
                                player.Health = 100;
                                Console.WriteLine("체력을 회복했습니다.");
                            }
                            else
                            {
                                Console.WriteLine("이미 체력이 100입니다.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        Rest(player);
                    }
                    else 
                    {
                        ChoiceNumber(player);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Character player = new Character("전사");
          
            ChoiceNumber(player);
        }
    }
}
