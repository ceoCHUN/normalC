namespace SpartaDungeon;
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();

        //1. 게임 시작 화면
        ShowStartWindow(player);
    }

    // 1. 게임 시작 화면
    static void ShowStartWindow(Player player)
    {
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
                case 1: ShowState(player); isTrue = false; break;
                case 2: ShowInventory(); isTrue = false; break;
                default : Console.WriteLine("잘못된 입력입니다."); break;
            }
        }
        while (isTrue);
    }

    // 2. 상태보기화면
    static void ShowState(Player player)
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
                case 0: ShowState(player); isTrue = false; break;
                default: Console.WriteLine("잘못된 입력입니다."); break;
            }
        }
        while (isTrue);
    }

    public class Player
    {
        public int lv;
        public string name;
        public string job;
        public int attak;
        public int defense;
        public int hp;
        public int gold;

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
    static void ShowInventory()
    {
        Console.Clear();

        Console.WriteLine("인벤토리");
        Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");

        Console.WriteLine("");

        Console.WriteLine("[ 아이템 목록 ]");
        Console.WriteLine("-");

        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
    }
}

