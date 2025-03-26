using CoffeeMachineProject.Tasks;
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
        private static ICoffeeBean coffeeBean { get; set; } = null; // Added static field
        static ECoffeeMachineType coffeeMachineType { get; set; }
        static ICoffeeMachine coffeeMachine { get; set; } = null;

        static CoffeeMachineTask coffeeMachineTask { get; set; }

        static void InitTask()
        {
            coffeeMachineTask = new CoffeeMachineTask(new CoffeeMachineTaskPack());
        }

        public class CoffeeMachineTaskPack : ICoffeeMachineTaskPack
        {
            public void CreateCoffeeMachine()
            {
                coffeeMachine = CoffeeMachineFactory.CreateCoffeeMachine(coffeeMachineType);
            }

            public string GetCoffeeMachineMakingDescripe()
            {

                return coffeeMachine.BrewCoffee();
            }

            public void UpdateCoffeeMachineStateDescripe(string stateDescripe)
            {
                ToolFunctions.AsyncSetText(mainForm.LbCoffeeMachineState, stateDescripe);
            }

            public void UpdateUIEnableState(CoffeeState state)
            {
                switch (state)
                {
                    case CoffeeState.SelectCoffeeMachine:
                        {
                            
                        }
                        break;

                        case CoffeeState.SelectCoffeeBean:
                        {
                            
                        }
                        break;

                }
            }
        }
    }
}
