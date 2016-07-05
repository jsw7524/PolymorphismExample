using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
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


        public static void 秀一下車庫裡面的東西能做什麼(奧迪R8[] 車庫)
        {
            foreach (奧迪R8 車 in 車庫)
            {
                車.移動();
                車.特殊功能();
                車.顯示車籍資料();
                Console.WriteLine();
            }
        }

        public static void 秀一下通用車庫裡的東西能做什麼(List<車> 通用車庫)
        {
            foreach (車 車 in 通用車庫)
            {
                車.移動();

                if (車 is 奧迪R8)
                    (車 as 奧迪R8).特殊功能();

                車.顯示車籍資料();
                Console.WriteLine();
            }
        }

        public static void 秀一下萬用倉庫理的東西能做什麼(ArrayList 萬用倉庫)
        {
            foreach (object 某個東西 in 萬用倉庫)
            {
                if (某個東西 is 車)
                {
                    var item = 某個東西 as 車;
                    item.顯示車籍資料();
                }
                else if (某個東西 is 飛機)
                {
                    飛機 item = 某個東西 as 飛機;
                    item.飛行();
                }

                Console.WriteLine();
            }
            //foreach (object 某個東西 in 萬用倉庫)
            //{
            //    if (某個東西 is I武器)
            //    {
            //        var item = 某個東西 as I武器;
            //        Console.Write($"這是一台{item.GetType().Name},");
            //        item.攻擊();
            //    }
            //}
        }
        public static void 秀一下有武器倉庫裡面物件都怎麼攻擊(I武器[] 武器倉庫)
        {
            Console.WriteLine("我不知道武器倉庫裡面裝的是什麼東西，但我知道它有實做I武器界面就一定會有攻擊的方法");    
            foreach (I武器 某個東西 in 武器倉庫)
            {
                Console.Write($"這是一台{某個東西.GetType().Name},");
                某個東西.攻擊();
            }
        }

        public static 奧迪R8[] 給我一個裝滿奧迪R8的車庫()
        {
            Random rand = new Random();
            奧迪R8[] 車庫 = new 奧迪R8[5];
            for (int i = 0; i < 車庫.Length; i++)
            {
                switch (rand.Next(0, 2))
                {
                    case 0:
                        車庫[i] = 汽車工廠.建立車("奧迪R8") as 奧迪R8;
                        break;

                    case 1:
                        車庫[i] = 汽車工廠.建立車("奧迪R8二代") as 奧迪R8二代;
                        break;
                }
            }
            return 車庫;
        }
        public static List<車> 給我一個裝滿車的通用車庫()
        {
            Random rand = new Random();
            List<車> 通用車庫 = new List<車>();
            for (int i = 0; i < 10; i++)
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        通用車庫.Add(汽車工廠.建立車("奧迪R8") as 奧迪R8);
                        break;

                    case 1:
                        通用車庫.Add(汽車工廠.建立車("奧迪R8二代") as 奧迪R8二代);
                        break;

                    case 2:
                        通用車庫.Add(汽車工廠.建立車("M1A1戰車") as M1A1戰車);
                        break;
                }
            }
            return 通用車庫;
        }

        public static ArrayList 給我一個裝滿萬物的萬用倉庫()
        {
            Random rand = new Random();
            ArrayList 萬用倉庫 = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                switch (rand.Next(0, 5))
                {
                    case 0:
                        萬用倉庫.Add(汽車工廠.建立車("奧迪R8") as 奧迪R8);
                        break;

                    case 1:
                        萬用倉庫.Add(汽車工廠.建立車("奧迪R8二代") as 奧迪R8二代);
                        break;

                    case 2:
                        萬用倉庫.Add(汽車工廠.建立車("M1A1戰車") as M1A1戰車);
                        break;

                    case 3:
                        萬用倉庫.Add(飛機工廠.建立飛機("F22") as F22);
                        break;

                    case 4:
                        萬用倉庫.Add(飛機工廠.建立飛機("波音787") as 波音787);
                        break;
                }
            }
            return 萬用倉庫;
        }

        private static void Main(string[] args)
        {
            //奧迪R8 R8 = 汽車工廠.建立車("奧迪R8") as 奧迪R8;
            //奧迪R8二代 R8二代 = 汽車工廠.建立車("奧迪R8二代") as 奧迪R8二代;

            #region 用奧迪R8的型別操作所有的奧迪R8物件
            //奧迪R8[] 車庫 = Program.給我一個裝滿奧迪R8的車庫();
            //Program.秀一下車庫裡面的東西能做什麼(車庫);
            #endregion

            #region 用車型別的型別操作所有的車物件，使用List容器
            //List<車> 通用車庫 = Program.給我一個裝滿車的通用車庫();
            //Program.秀一下通用車庫裡的東西能做什麼(通用車庫);
            #endregion

            //因為ArrayList這個容器裡面儲存的型別都是object，所以任何型別都能裝
            //跟List<T>比較，List<T>會限定該泛型型別T或有is-a關係的型別
            //ArrayList什麼東西都能裝，但是ArrayList使用前須轉型(因為他是object的情況下，你就只會知道他身為object的行為)
            //效能上會比List<T>差(因為轉型是額外動作)，所以請考量實際容器裝的物件決定要用哪種容器
            #region 使用ArrayList容器
            //ArrayList 萬用倉庫 = Program.給我一個裝滿萬物的萬用倉庫();
            //Program.秀一下萬用倉庫理的東西能做什麼(萬用倉庫);
            #endregion
            #region 多型使用interface界面操作範例
            //I武器[] 武器倉庫 = new I武器[2]
            //{
            //    飛機工廠.建立飛機("F22") as I武器,
            //    汽車工廠.建立車("M1A1戰車") as I武器
            //};
            //Program.秀一下有武器倉庫裡面物件都怎麼攻擊(武器倉庫);
            #endregion
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

    abstract class 車
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
        public override void 飛行()
        {
            引擎.啟動引擎();
            Console.WriteLine("波音787的飛行方式…");
        }
    }

    abstract class 飛機
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

    class 奧迪R8 : 車
    {
        public string 車牌號碼 { get; } = Guid.NewGuid().ToString().Substring(0, 6).Insert(3, "-").ToUpper();

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
}