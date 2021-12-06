using System;
using System.Collections.Generic;

namespace Factory {
    public class Field {
        static void Main(string[] args) {
            int zcount = 0, scount = 0;
            Summon[] summons = new Summon[3];
            summons[0] = new Zom();
            summons[1] = new Sli();
            summons[2] = new Kni();

            List<Entity> _entity = new List<Entity>();
            _entity.Add(summons[0].MakeEntity("좀비"));
            _entity.Add(summons[1].MakeEntity("슬라임"));
            _entity.Add(summons[2].MakeEntity("기사"));

            Entity attack = _entity[2];
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "좀비")
                    if (zcount != 3)
                    {
                        _entity[0].Attacked(ref attack);
                        
                    }
                    else
                        Console.WriteLine("좀비가 필드에 없습니다.");
                if (input == "슬라임")
                    if (scount != 2)
                    {
                        _entity[1].Attacked(ref attack);
                        
                    }
                    else
                        Console.WriteLine("슬라임이 필드에 없습니다.");
                
            }
        }
    }

    interface IAttackable {
        void Attacked(ref Entity Target);
    }

    public enum EntityType {
        Zombie,
        Slime,
        Knight
    }

    abstract class Entity : IAttackable {
        protected EntityType Type;
        protected string Name;
        protected int Hp;
        public int Atk;
        public abstract void Attacked(ref Entity Target);
    }

    class Knight : Entity {
        public Knight(string Name) {
            this.Type = EntityType.Knight;
            this.Name = Name;
            this.Hp = 40;
            this.Atk = 8;

            Console.WriteLine(Name + " 소환\n");
        }

        public override void Attacked(ref Entity Target) {
            this.Hp -= Target.Atk;
            Console.WriteLine(Name + " 공격, 남은 체력: " + this.Hp.ToString());
        }
    }
    class Zombie : Entity {
        public Zombie(string Name) {
            this.Type = EntityType.Zombie;
            this.Name = Name;
            this.Hp = 20;
            this.Atk = 3;

            Console.WriteLine("{0} 출현\n", this.Name);
        }
        public override void Attacked(ref Entity Target) {
            this.Hp -= Target.Atk;
            if (Hp > 0)
                Console.WriteLine(Name + " 공격, 남은 체력: " + this.Hp + "\n");

            else
            {
                Console.WriteLine(Name + " 처치");
                this.Hp = 20;
            }
        }
    }
    class Slime : Entity {
        public Slime(string Name) {
            this.Type = EntityType.Slime;
            this.Name = Name;
            this.Hp = 16;
            this.Atk = 6;

            Console.WriteLine(Name + " 출현\n");
        }
        public override void Attacked(ref Entity Target) {
            this.Hp -= Target.Atk;
            if (Hp > 0)
                Console.WriteLine(Name + " 공격, 남은 체력: " + this.Hp + "\n");
            else
            {
                Console.WriteLine(Name + " 처치");
                this.Hp = 16;
            }
        }
    }
    abstract class Summon {
        public abstract Entity MakeEntity(string Name);
    }

    class Zom : Summon {
        public override Entity MakeEntity(string Name) {
            return new Zombie(Name);
        }
    }
    class Sli : Summon {
        public override Entity MakeEntity(string Name) {
            return new Slime(Name);
        }
    }
    class Kni : Summon {
        public override Entity MakeEntity(string Name) {
            return new Knight(Name);
        }
    }
}
