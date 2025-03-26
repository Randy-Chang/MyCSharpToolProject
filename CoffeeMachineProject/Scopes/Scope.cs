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

    

    

}
