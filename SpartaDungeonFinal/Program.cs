using static SpartaDungeon.Program;

namespace SpartaDungeon;
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        Item[] items = new Item[2]; // 2개의 변수 생성

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Item();
        }

        // ITEM 01) 
        items[0].name = "무쇠갑옷";
        items[0].ability = "방어력";
        items[0].stat = 5;
        items[0].description = "무쇠로 만들어져 튼튼한 갑옷입니다.";

        // ITEM 02) 
        items[1].name = "낡은 검";
        items[1].ability = "공격력";
        items[1].stat = 2;
        items[1].description = "쉽게 볼 수 있는 낡은 검입니다.";


        //1. 게임 시작 화면
        ShowStartWindow(player, items);
    }

    // 게임 시작 화면
    static void ShowStartWindow(Player player, Item[] items)
    {
        Console.Clear();

        bool isTrue = true;

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        
        do
        {
            Console.WriteLine("");

            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");

            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int startCheck = int.Parse(Console.ReadLine());

            switch (startCheck)
            {
                case 1: ShowState(player, items); isTrue = false; break;
                case 2: ShowInventory(player, items); isTrue = false; break;
                default : Console.WriteLine("잘못된 입력입니다."); break;
            }
        }
        while (isTrue);
    }

    // 2. 상태보기화면
    static void ShowState(Player player, Item[] items)
    {
        bool isTrue = true;

        Console.Clear();

        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");

        Console.WriteLine("");

        // 플레이어 정보
        player.ShowPlayerInfo();

        do
        {
            Console.WriteLine("");

            Console.WriteLine("0. 나가기");

            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int startCheck = int.Parse(Console.ReadLine());

            switch (startCheck)
            {
                case 0: ShowStartWindow(player, items); isTrue = false; break;
                default: Console.WriteLine("잘못된 입력입니다."); break;
            }
        }
        while (isTrue);
    }

    public class Player
    {
        public int lv = 1;
        public string name = "까미";
        public string job = "전사";
        public int attak = 10;
        public int defense = 5;
        public int hp = 100;
        public int gold = 1500;

        public void ShowPlayerInfo()
        {
            Console.WriteLine("플레이어 기본 정보");
            Console.WriteLine("LV      : {0}", lv);
            Console.WriteLine("NAME    : {0}", name);
            Console.WriteLine("JOB     : {0}", job);
            Console.WriteLine("ATTACK  : {0}", attak);
            Console.WriteLine("DEFENSE : {0}", defense);
            Console.WriteLine("HP      : {0}", hp);
            Console.WriteLine("GOLD    : {0} G", gold);
        }
    }

    //3. 인벤토리화면
    static void ShowInventory(Player player, Item[] items)
    {
        bool isTrue = true;

        Console.Clear();

        Console.WriteLine("인벤토리");
        Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");

        Console.WriteLine("");

        Console.WriteLine("[ 아이템 목록 ]");

        Console.WriteLine("");

        for (int i = 0; i < items.Length; i++)
        {
            items[i].ShowItemInfo();
        }

        do
        {
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착관리");

            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int startCheck = int.Parse(Console.ReadLine());

            switch (startCheck)
            {
                case 0: ShowStartWindow(player, items); isTrue = false; break;

                case 1: ShowEquipmentWindow(player, items); isTrue = false; break;

                default: Console.WriteLine("잘못된 입력입니다."); break;
            }
        }
        while (true);

    }


    public class Item
    {
        public bool isWear = false;
        public string name = "";
        public string ability = "";
        public int stat = 0;
        public string description = "";

        public void ShowItemInfo()
        {
            if(isWear == true)
            {
                Console.WriteLine("- [E] {0}     | {1} + {2} | {3}", name, ability, stat, description);
            }
            else
            {
                Console.WriteLine("- {0}     | {1} + {2} | {3}", name, ability, stat, description);
            }
            
        }

        public void ChooseItem(int i)
        {
            if(isWear == true)
            {
                Console.WriteLine("- [E] {0}.{1}     | {2} + {3} | {4}", i, name, ability, stat, description);
            }
            else
            {
                Console.WriteLine("- {0}.{1}     | {2} + {3} | {4}", i, name, ability, stat, description);
            }
            
        }
    }

    static void ShowEquipmentWindow(Player player, Item[] items)
    {
        bool isTrue = true;
        do
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine("");

            Console.WriteLine("[ 아이템 목록 ]");

            Console.WriteLine("");

            for (int i = 0; i < items.Length; i++)
            {
                items[i].ChooseItem(i + 1);
            }


            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int startCheck = int.Parse(Console.ReadLine());

            switch (startCheck)
            {
                case 0: ShowInventory(player, items); isTrue = false; break;

                case 1: items[0].isWear = !items[0].isWear; 
                        ApplyStat(player, items[0], items[0].isWear);
                        break;

                case 2: items[1].isWear = !items[1].isWear; 
                        ApplyStat(player, items[1], items[1].isWear);
                        break;

                default: Console.WriteLine("잘못된 입력입니다."); break;
            }
        }
        while (true);

    }

    static void ApplyStat(Player player, Item item, bool isWear)
    {
        if(isWear == true)
        {
            if (item.ability == "공격력")
            {
                player.attak += item.stat;
                Console.Write("Player attak = {0}", player.attak);
            }
            else if (item.ability == "방어력")
            {
                player.defense += item.stat;
                Console.Write("Player defense = {0}", player.defense);
            }
        }
        else
        {
            if (item.ability == "공격력")
            {
                player.attak -= item.stat;
            }
            else if (item.ability == "방어력")
            {
                player.defense -= item.stat;
            }

        }
    }
}

