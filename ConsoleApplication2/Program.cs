using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{

    public abstract class 機器
    {
        protected string 製造者 { get; set; }
        public 機器()
        {

        }
        public 機器(string s)
        {
            製造者 = s;
        }

    }

    public enum 顏色
    {
        銀色,
        白色,
        黑色,
        紅色,
        綠色,
        灰色
    }

    internal interface I武器
    {
        void 攻擊();
    }

    class F22 : 飛機, I武器
    {
        public F22()
        {
            製造者 = "洛克希德馬丁";
        }
        public override 顏色 外殼顏色 { get; } = 顏色.灰色;

        public void 攻擊()
        {
            Console.WriteLine("可發射空對地飛彈、可發射空對空飛彈");
        }

        public override void 飛行()
        {
            引擎.啟動引擎();
            Console.WriteLine("F22的飛行方式，可啟動後燃器");
        }
    }

    class M1A1戰車 : 車, I武器
    {
        public M1A1戰車()
        {
            製造者 = "克萊斯勒";
        }
        public void 攻擊()
        {
            Console.WriteLine("戰車攻擊方式是使用砲管發射砲彈");
        }

        public override void 移動()
        {
            引擎.啟動引擎();
            Console.WriteLine("戰車的移動方式…使用履帶");
        }

        public override void 顯示車籍資料()
        {
            Console.WriteLine($"這是一台{GetType().Name}");
            Console.WriteLine($"重量:{重量}Kg");
            Console.WriteLine($"時速上限:{時速上限}km/h");
            Console.WriteLine($"顏色:{烤漆顏色}");
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {

            Random rand = new Random();

            倉庫<機器> 倉庫一號 = new 倉庫<機器>("雜貨商的倉庫");
            
            for (int i = 0; i < 10; i++)
            {
                switch (rand.Next(0, 5))
                {
                    case 0:
                        倉庫一號.放東西(汽車工廠.建立車("奧迪R8") as 奧迪R8);
                        break;

                    case 1:
                        倉庫一號.放東西(汽車工廠.建立車("奧迪R8二代") as 奧迪R8二代);
                        break;

                    case 2:
                        倉庫一號.放東西(汽車工廠.建立車("M1A1戰車") as M1A1戰車);
                        break;

                    case 3:
                        倉庫一號.放東西(飛機工廠.建立飛機("F22") as F22);
                        break;

                    case 4:
                        倉庫一號.放東西(飛機工廠.建立飛機("波音787") as 波音787);
                        break;
                }
            }
            Console.WriteLine(倉庫一號.顯示名稱());
            foreach (var 東西 in 倉庫一號)
            {
                Console.WriteLine($"這是一台{東西.GetType().Name}");
            }

            倉庫<車> 倉庫二號 = new 倉庫<車>("車的倉庫");

            for (int i = 0; i < 10; i++)
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        倉庫二號.放東西(汽車工廠.建立車("奧迪R8") as 奧迪R8);
                        break;
                    case 1:
                        倉庫二號.放東西(汽車工廠.建立車("奧迪R8二代") as 奧迪R8二代);
                        break;
                    case 2:
                        倉庫二號.放東西(汽車工廠.建立車("M1A1戰車") as M1A1戰車);
                        break;
                }
            }
            Console.WriteLine(倉庫二號.顯示名稱());
            foreach (var 東西 in 倉庫二號)
            {
                Console.WriteLine($"這是一台{東西.GetType().Name}");
            }

            跑車倉庫<奧迪R8> 倉庫三號 = new 跑車倉庫<奧迪R8>("奧迪R8跑車倉庫");
            for (int i = 0; i < 10; i++)
            {
                switch (rand.Next(0, 2))
                {
                    case 0:
                        倉庫三號.放東西(汽車工廠.建立車("奧迪R8") as 奧迪R8);
                        break;
                    case 1:
                        倉庫三號.放東西(汽車工廠.建立車("奧迪R8二代") as 奧迪R8二代);
                        break;
                }
            }
            倉庫三號.排序();
            Console.WriteLine(倉庫三號.顯示名稱());
            foreach (var 東西 in 倉庫三號)
            {
                Console.WriteLine($"這是一台{東西.GetType().Name}    {東西.車牌號碼}");
            }

            Console.ReadKey();
        }
    }

    class 引擎
    {
        public 引擎(string 引擎名稱)
        {
            this.引擎名稱 = 引擎名稱;
        }

        public string 引擎名稱 { get; set; }

        public void 啟動引擎()
        {
            Console.WriteLine($"發動{引擎名稱}");
        }
    }

    class 汽車工廠
    {
        public static 車 建立車(string 車的名稱)
        {
            switch (車的名稱)
            {
                case "奧迪R8":
                    return new 奧迪R8()
                    {
                        引擎 = new 引擎("V8發動機"),
                        重量 = 1456,
                        時速上限 = 301,
                        烤漆顏色 = 顏色.白色
                    };

                case "奧迪R8二代":
                    return new 奧迪R8二代()
                    {
                        引擎 = new 引擎("V10發動機"),
                        重量 = 1485,
                        時速上限 = 316,
                        烤漆顏色 = 顏色.銀色
                    };

                case "M1A1戰車":
                    return new M1A1戰車()
                    {
                        引擎 = new 引擎("AGT-1500燃氣渦輪發動機"),
                        重量 = 63000,
                        時速上限 = 72,
                        烤漆顏色 = 顏色.綠色
                    };

                default:
                    return null;
            }
        }
    }

    abstract class 車 : 機器
    {
        public 引擎 引擎 { get; set; }
        public int 重量 { get; set; }
        public int 時速上限 { get; set; }
        public 顏色 烤漆顏色 { get; set; }

        abstract public void 移動();

        abstract public void 顯示車籍資料();
    }

    class 波音787 : 飛機
    {
        public 波音787()
        {
            製造者 = "波音";
        }

        public override void 飛行()
        {
            引擎.啟動引擎();
            Console.WriteLine("波音787的飛行方式…");
        }
    }

    abstract class 飛機 : 機器
    {
        public 引擎 引擎 { get; set; }
        public virtual 顏色 外殼顏色 { get; } = 顏色.白色;

        abstract public void 飛行();
    }

    class 飛機工廠
    {
        public static 飛機 建立飛機(string 飛機的名稱)
        {
            switch (飛機的名稱)
            {
                case "F22":
                    return new F22() { 引擎 = new 引擎("F119-PW-100渦扇發動機") };

                case "波音787":
                    return new 波音787() { 引擎 = new 引擎("奇異GEnx發動機") };

                default:
                    return null;
            }
        }
    }

    class 奧迪R8 : 車, IComparable<奧迪R8>
    {
        public 奧迪R8()
        {
            製造者 = "奧迪";
        }
        public string 車牌號碼 { get; } = Guid.NewGuid().ToString().Substring(0, 6).Insert(3, "-").ToUpper();

        public int CompareTo(奧迪R8 other)
        {
            return string.Compare(this.車牌號碼,other.車牌號碼);
        }

        public virtual void 特殊功能()
        {
            Console.WriteLine("宣告我真的很有錢!");
            Console.WriteLine();
        }

        public override void 移動()
        {
            引擎.啟動引擎();
            Console.WriteLine($"奧迪R8自己的移動方式…");
        }

        public override void 顯示車籍資料()
        {
            Console.WriteLine($"這是一台{GetType().Name}");
            Console.WriteLine($"重量:{重量}Kg");
            Console.WriteLine($"時速上限:{時速上限}km/h");
            Console.WriteLine($"顏色:{烤漆顏色}");
            Console.WriteLine($"車牌號碼:{車牌號碼}");
        }
    }

    class 奧迪R8二代 : 奧迪R8
    {
        public override void 特殊功能()
        {
            Console.WriteLine("宣告我真的靠北有錢!!!");
            Console.WriteLine();
        }

        public override void 移動()
        {
            base.移動();
            Console.WriteLine("並且可以打開推進器!!!");
            Console.WriteLine();
        }
    }

    public class 倉庫<T> : IEnumerable<T>
    {
        protected string 名稱;
        protected int position;
        protected T[] array = new T[256];

        public void 放東西(T obj)
        {
            position++;
            array[position] = obj;

        }

        public string 顯示名稱()
        {
            return 名稱;
        }

        public 倉庫(string s)
        {
            名稱 = s;
            position = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new 列舉者<T>(array, position);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


    public class 跑車倉庫<奧迪R8> : 倉庫<奧迪R8>
    {
        public 跑車倉庫(string s):base(s)
        {
        }

        public void 排序()
        {
            Array.Sort<奧迪R8>(array,0,position+1);
        }
    }

    class 列舉者<T> : IEnumerator<T>
    {
        T[] array;
        int position;
        int length;

        public 列舉者(T[] p, int l)
        {
            position = -1;
            array = p;
            length = l;
        }

        public T Current
        {
            get
            {
                return array[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return array[position];
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return position <= length;
        }

        public void Reset()
        {
            position = -1;
        }
    }


}
