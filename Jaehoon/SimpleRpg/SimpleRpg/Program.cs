using System.Reflection;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SimpleRpg
{
    interface ICharacter
    {
        string Name { get; set; }
        int Health { get; set; }
        int Attack { get; set; }
        bool IsDead { get; set; }

        void TakeDamage(int damage);

        void Dead(bool dead);
    }
    interface IItem
    {
        string Name { get; set; }
        void Use(Warrior warrior);
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {

            Warrior player = new Warrior("player");
            Goblin goblin = new Goblin(100, new Random().Next(10, 20), "고블린");
            Dragon dragon = new Dragon(140, new Random().Next(25, 30), "드래곤");
            Console.WriteLine("Hello, World!");
            //Stage stage1 = new Stage(player,goblin );
            //stage1.Start();
            Stage stage2 = new Stage(player, dragon);
            stage2.Start();
        }
    }
    public class Warrior : ICharacter  //플레이어를 나타내는 클래스
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }

        public bool IsDead { get; set; }

        public Warrior(String name) 
        {
            Name = name;
            Health = 100;
            Attack = 10;
        
        }
        public void TakeDamage(int damage) 
        {
            Health -= damage;
            Console.WriteLine("플레이어가" + damage + "만큼 데미지를 입었습니다");
            Console.WriteLine("남은 체력:{0}",Health );
            if (Health <= 0)
            {
                IsDead = true;
            }
        }
        public void Dead(bool dead)
        {
            if (dead)
            {
                Console.WriteLine("플레이어가 죽었습니다");
            }
        }
    }
    public class Monster : ICharacter   //몬스터를 나타내는 클래스
    {
        //public Monster(int _Atack,  int _Health, String _Name)
        //{
        //    Attack = _Atack;
        //    Health = _Health;
        //    Name = _Name;
        //}



        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }
        public void TakeDamage(int damage) 
        {
            Health -= damage;
            Console.WriteLine(Name + damage + "만큼 데미지를 입었습니다");
            Console.WriteLine("남은 체력:{0}", Health);
            if (Health <= 0)
            {
                IsDead = true;
            }

        }
        public void Dead(bool dead)
        {
            if (dead)
            {
                Console.WriteLine("몬스터가 죽었습니다");
            }
        }
    }
    public class Goblin : Monster
    {
        public Goblin(int _Health, int _Attack, string _Name) 
        {
            Health = _Health;
            Attack = _Attack;
            Name = _Name;

        }
        //public int Health = 100;
       // public int Attack = new Random().Next(10, 20);

    }
    public class Dragon : Monster
    {
        public Dragon(int _Health, int _Attack, string _Name)
        {
            Health = _Health;
            Attack = _Attack;
            Name = _Name;

        }
        
    }
    public class HealthPoion : IItem
    {
        public string Name { get; set; }
        public void Use(Warrior warrior) { }
    }
    public class StrengthPotion : IItem
    {
        public string Name { get; set; }
        public void Use(Warrior warrior) { }
    }
    public class Stage
    {
        List<Monster> monsters = new List<Monster>();
        public Warrior player = new Warrior("player");
        public Monster monster = new Goblin(100, new Random().Next(10, 20),"고블린");
        public Monster monster1 = new Dragon(140, new Random().Next(25, 30),"드래곤");

        public Stage(Warrior _player, Monster _monster)
        {
            player = _player;
            monster = _monster;
        }
        public void Start()
        {
            player.Health = 100;
            Console.WriteLine("게임을 시작합니다.");


            while (monster.IsDead==false && player.IsDead==false) {
               // monster.Attack = new Random().Next(10, 20);
                Console.WriteLine("플레이어가 공격을 시작합니다.");
                monster.TakeDamage(player.Attack);  // 플레이어가 공격
                monster.Dead(monster.IsDead);//여기에 break
                Thread.Sleep(1000);  // 턴 사이에 1초 대기
                Console.WriteLine("");

                Console.WriteLine(monster.Name + "이 공격을 시작합니다.");
                player.TakeDamage(monster.Attack);  // 플레이어가 공격
                player.Dead(player.IsDead);
                Thread.Sleep(1000);  // 턴 사이에 1초 대기
                Console.WriteLine("");

            }









        }
        public void ChageMonster(Monster monster )
        {
            if (monster.Health <= 0)
            {
                player.TakeDamage(monster.Attack);
            }
        }
        //public void CheckDead(bool IsDead)
        //{
        //    if (IsDead)
        //    {
        //        player.Dead(IsDead);
        //    }
        //}

        //public void TakeDamage(int damage)
        //{

        //}

    }
}