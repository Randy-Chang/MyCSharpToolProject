using CoffeeMachineProject.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace CoffeeMachineProject.Tasks
{
    public enum CoffeeState
    {
        SelectCoffeeMachine,
        SelectCoffeeBean,
        MakingCoffee,
        DoneAndWaitingForPickup,
    }

    internal partial class CoffeeMachineTask
    {
        ICoffeeMachineTaskPack pack;
        Thread thread;
        private CoffeeState currentState;
        string stateDescripe = "";
        bool isResponded = false;
        Timer timer;

        public CoffeeMachineTask(ICoffeeMachineTaskPack pack)
        {
            this.pack = pack;

            timer = new Timer();
            currentState = CoffeeState.SelectCoffeeMachine;
            isResponded = false;
            thread = new Thread(RunStateMachine);
            thread.Start();
        }

        public void Response()
        {
            isResponded = true;
        }

        private void SetState(CoffeeState state)
        {
            currentState = state;
        }

        private void SetStateAndResetRespond(CoffeeState state)
        {
            isResponded = false;
            SetState(state);
        }

        private void RunStateMachine()
        {
            while (true)
            {
                Thread.Sleep(20);

                UpdateUIEnableState(currentState);
                UpdateCoffeeMachineStateDescripe(stateDescripe);
                Console.WriteLine(stateDescripe);

                switch (currentState)
                {
                    case CoffeeState.SelectCoffeeMachine:
                        {
                            stateDescripe = "請選擇咖啡機...";

                            if (isResponded)
                            {
                                CreateCoffeeMachine();
                                SetStateAndResetRespond(CoffeeState.SelectCoffeeBean);
                            }
                        }
                        break;

                    case CoffeeState.SelectCoffeeBean:
                        {
                            stateDescripe = "請選擇咖啡豆...";
                            
                            if (isResponded)
                            {
                                SetStateAndResetRespond(CoffeeState.MakingCoffee);
                                timer.Start(3000);
                            }
                        }
                        break;

                   

                    // 正在製作咖啡
                    case CoffeeState.MakingCoffee:
                        {
                            stateDescripe = GetCoffeeMachineMakingDescripe();

                            if (timer.HasReachedDuration())
                            {
                                SetState(CoffeeState.DoneAndWaitingForPickup);
                            }    
                        }
                        break;

                    case CoffeeState.DoneAndWaitingForPickup:
                        {
                            stateDescripe = "請取走咖啡...";

                            if (isResponded)
                            {
                                SetStateAndResetRespond(CoffeeState.SelectCoffeeMachine);
                            }
                        }
                        break;
                }
            }
        }
    }

    // 實作 ICoffeeMachineTaskPack
    internal partial class CoffeeMachineTask : ICoffeeMachineTaskPack
    {
        #region ICoffeeMachineTaskPack 實作介面
        public void UpdateUIEnableState(CoffeeState state)
        {
            pack.UpdateUIEnableState(state);
        }

        public void UpdateCoffeeMachineStateDescripe(string stateDescripe)
        {
            pack.UpdateCoffeeMachineStateDescripe(stateDescripe);
        }

        public string GetCoffeeMachineMakingDescripe()
        {
            return pack.GetCoffeeMachineMakingDescripe();
        }

        public void CreateCoffeeMachine()
        {
            pack.CreateCoffeeMachine();
        }
        #endregion
    }

    public interface ICoffeeMachineTaskPack
    {
        void CreateCoffeeMachine();
        void UpdateCoffeeMachineStateDescripe(string stateDescripe);
        void UpdateUIEnableState(CoffeeState state);
        string GetCoffeeMachineMakingDescripe();
    }

    internal class Timer
    {
        private int duration;
        private DateTime startTime;

        public Timer()
        {
        }

        public void Start(int duration)
        {
            this.duration = duration;
            startTime = DateTime.Now;
        }

        public bool HasReachedDuration()
        {
            return (DateTime.Now - startTime).TotalMilliseconds >= duration;
        }
    }

}
