using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject.Scopes
{
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
