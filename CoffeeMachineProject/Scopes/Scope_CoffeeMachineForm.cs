using MyCSharpToolProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject.Scopes
{
    internal partial class Scope
    {

        public static CoffeeMachineForm mainForm = null;

        public static void InitForm()
        {
            mainForm = new CoffeeMachineForm(new CoffeeMachineFormPack());
            mainForm.InitUI();
        }


        public class CoffeeMachineFormPack : ICoffeeMachineFormPack
        {
            public void InitCmbCoffeeMachineType()
            {
                ToolFunctions.FillComboBoxWithEnum<ECoffeeMachineType>(mainForm.CmbCoffeeMachineType);
            }

            public void InitCmbCoffeeBean()
            {
                ToolFunctions.FillComboBoxWithEnum<ECoffeeBeanType>(mainForm.CmbCoffeeBean);
            }

            public void ResponseMachine()
            {
                coffeeMachineTask.Response();
            }

            public string ShowCoffeeBeamInfo(string bean)
            {
                ECoffeeBeanType coffeeBeanType = (ECoffeeBeanType)Enum.Parse(typeof(ECoffeeBeanType), bean);

                switch (coffeeBeanType)
                {
                    case ECoffeeBeanType.Arabica:
                        coffeeBean = new ArabicaBean();
                        break;

                    case ECoffeeBeanType.Ethiopia:
                    default:
                        coffeeBean = new EthiopiaBean();
                        break;
                }

                return coffeeBean.GetInfo();
            }

            public void ChangeCoffeeMachineType(string type)
            {
                coffeeMachineType = (ECoffeeMachineType)Enum.Parse(typeof(ECoffeeMachineType), type);
            }
        }
    }

    
}
