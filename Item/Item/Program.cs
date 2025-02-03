using System.Numerics;

namespace Item
{
    internal class Program
    {
        public class Item
        {
            public string ItemName { get; set; }  // 아이템 이름
            public string ToolTip { get; set; }   // 아이템 설명
            public int Attack { get; set; }   // 공격력
            public int Defense { get; set; }  // 방어력
            public int Price { get; set; }    // 템 가격
            public bool Purchase { get; set; }

            public Item(string itemName, string toolTip, int attack, int defense, int price) // 아이템 클래스 생성자
            {
                ItemName = itemName;
                ToolTip = toolTip;
                Attack = attack;
                Defense = defense;
                Price = price;
                Purchase = false;
            }
        }
        
        static void Shop()
        {
            Console.Clear();
            Console.WriteLine("[ 상점 ]\n보유 중인 아이템을 관리 할 수 있습니다.\n");
            Console.WriteLine("[보유 골드]");


            List<Item> items = new List<Item>  // 아이템 리스트
{
    new Item(" 너덜너덜한 갑옷 ", "방어력 +3, 너무 오래 되서 다 뜯어져 있다.", 0 , 2, 1000),
    new Item(" 평범한 갑옷 ", "방어력 +6, 그럭저럭 입을만해 보인다.", 0, 6, 1500),
    new Item(" 고오급 갑옷 ", "방어력 +10, 그나마 괜찮아보이는 갑옷이다.", 0, 10, 3000),
    new Item(" 나뭇가지 ", "공격력 +2, 회초리로는 쓸만한 것 같다.", 2, 0, 500),
    new Item(" 살짝 휜 목검 ", "공격력 +5, 몇 번 휘두르면 부러질 것 같다 .", 5, 0, 1000),
    new Item(" 날카로운 죽창 ", "공격력 +7, 너도 나도 한 방에 갈 것 같은 대나무 창이다.", 7, 0, 2000)
};
            Console.WriteLine("[ 아이템 목록 ]");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].ItemName} | {items[i].ToolTip} | {items[i].Price}G{(items[i].Purchase ? " - 구매 완료" : "")}");
            }

            foreach (var item in items) // purchase 구매 기능 초기화
            {
                item.Purchase = false;
            }

            Console.WriteLine();
            Console.WriteLine(" 원하시는 행동을 입력해주세요.\n");
            Console.WriteLine(" 0. 나가기\n 1. 아이템 구매\n");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int storeInput)) // 0,1 중에 택1
                {
                    switch (storeInput)
                    {
                        case 0:
                            //getSelect(); // 0. 나가기
                            break;
                        case 1:
                           // BuyItem(items); // 3-1. 아이템 구매  ()에 items 넣어줌
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 유효한 번호를 입력하세요.\n");
                            continue; // 다시 루프
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Shop();
        }
    }
}
