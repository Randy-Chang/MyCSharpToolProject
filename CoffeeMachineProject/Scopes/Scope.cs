using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject.Scopes
{
    public enum ECoffeeBeanType
    {
        Arabica,           // 阿拉比卡（Arabica）
        Ethiopia,          // 衣索比亞咖啡豆
    }

    internal partial class Scope
    {
        public Scope() 
        {
            InitForm();
            InitTask();
        }
    }

    #region 咖啡豆

    // 定義ICoffeeBean介面
    public interface ICoffeeBean
    {
        string Aroma { get; }  // 香氣屬性
        string Description { get; } // 描述屬性
        double PricePerKg { get; } // 每公斤價格屬性
        void DisplayInfo();    // 顯示咖啡豆資訊
        string GetInfo();
    }

    // 實作ICoffeeBean介面的ArabicaBean類別
    public class ArabicaBean : ICoffeeBean
    {
        public string Aroma { get; private set; }  // 咖啡豆的香氣
        public string Description { get; private set; } // 描述
        public double PricePerKg { get; private set; } // 每公斤價格

        public ArabicaBean()
        {
            Aroma = "輕微的果香和花香";
            Description = "阿拉比卡（Arabica）咖啡豆，口感較為柔和，酸味明顯，咖啡因含量較低。";
            PricePerKg = 800;
        }

        // 顯示咖啡豆的詳細資料
        public void DisplayInfo()
        {
            Console.WriteLine($"咖啡豆類型: Arabica");
            Console.WriteLine($"描述: {Description}");
            Console.WriteLine($"每公斤價格: {PricePerKg:C} 元");
            Console.WriteLine($"香氣: {Aroma}");
        }

        public string GetInfo()
        {
            return $"咖啡豆類型: Arabica\n描述: {Description}\n每公斤價格: {PricePerKg:C} 元\n香氣: {Aroma}";
        }
    }

    // 實作ICoffeeBean介面的EthiopiaBean類別
    public class EthiopiaBean : ICoffeeBean
    {
        public string Aroma { get; private set; }
        public string Description { get; private set; }
        public double PricePerKg { get; private set; }

        public EthiopiaBean()
        {
            Aroma = "明亮的花香與莓果香氣";
            Description = "衣索比亞咖啡豆，擁有水果與花香的複雜風味，酸度較高，風味獨特。";
            PricePerKg = 1000;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"咖啡豆類型: Ethiopia");
            Console.WriteLine($"描述: {Description}");
            Console.WriteLine($"每公斤價格: {PricePerKg:C} 元");
            Console.WriteLine($"香氣: {Aroma}");
        }

        public string GetInfo()
        {
            return $"咖啡豆類型: Ethiopia\n描述: {Description}\n每公斤價格: {PricePerKg:C} 元\n香氣: {Aroma}";
        }
    }
    #endregion

    #region 咖啡機 CoffeeMachin
    public interface ICoffeeMachine
    {
        string BrewCoffee();  // 舊的沖泡咖啡的方法
    }

    public class EspressoMachine : ICoffeeMachine
    {
        public string BrewCoffee()
        {
            return "濃縮咖啡機正在沖泡...";
        }
    }

    public class DripCoffeeMachine : ICoffeeMachine
    {
        public string BrewCoffee()
        {
            return "滴濾咖啡機正在沖泡...";
        }
    }

    public enum ECoffeeMachineType
    {
        Espresso,  // 濃縮咖啡機
        Drip      // 滴漏式咖啡機
    }

    public class CoffeeMachineFactory
    {
        // 工廠方法，根據選擇的咖啡機類型創建不同的咖啡機
        public static ICoffeeMachine CreateCoffeeMachine(ECoffeeMachineType type)
        {
            switch (type)
            {
                case ECoffeeMachineType.Espresso:
                    return new EspressoMachine();  // 使用適配器將濃縮咖啡機轉換為統一接口
                case ECoffeeMachineType.Drip:
                    return new DripCoffeeMachine();  // 使用適配器將滴漏式咖啡機轉換為統一接口
                default:
                    throw new ArgumentException("未知的咖啡機類型");
            }
        }
    }

    #endregion

}
