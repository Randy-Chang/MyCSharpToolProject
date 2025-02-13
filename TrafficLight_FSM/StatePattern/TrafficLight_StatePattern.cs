using System;
using System.Diagnostics;
using System.Threading;

namespace TrafficLight_FSM.StatePattern
{
    #region 紅燈狀態機

    public class RedState : ITrafficLightState
    {
        public void EnterState(TrafficLight_StatePattern trafficLight)
        {
            trafficLight.stopwatch.Restart();
            trafficLight.uIController.ShowRedLight();
        }

        public void UpdateState(TrafficLight_StatePattern trafficLight)
        {
            if (trafficLight.stopwatch.Elapsed.TotalSeconds >= trafficLight.redDuration)
                trafficLight.SetState(ES1.Active, new GreenState());
        }
    }

    #endregion

    #region 綠燈狀態機

    public class GreenState : ITrafficLightState
    {
        public void EnterState(TrafficLight_StatePattern trafficLight)
        {
            trafficLight.stopwatch.Restart();
            trafficLight.uIController.ShowGreenLight();
        }

        public void UpdateState(TrafficLight_StatePattern trafficLight)
        {
            if (trafficLight.stopwatch.Elapsed.TotalSeconds >= trafficLight.greenDuration)
                trafficLight.SetState(ES1.Active, new YellowState());
        }
    }

    #endregion

    #region 黃燈狀態機

    public class YellowState : ITrafficLightState
    {
        public void EnterState(TrafficLight_StatePattern trafficLight)
        {
            trafficLight.stopwatch.Restart();
            trafficLight.uIController.ShowYellowLight();
        }

        public void UpdateState(TrafficLight_StatePattern trafficLight)
        {
            if (trafficLight.stopwatch.Elapsed.TotalSeconds >= trafficLight.yellowDuration)
                trafficLight.SetState(ES1.Active, new RedState());
        }
    }

    #endregion

    #region 暫停狀態

    public class PauseState : ITrafficLightState
    {
        private ITrafficLightState previousState;

        public PauseState(ITrafficLightState previousState)
        {
            this.previousState = previousState;
        }

        public void EnterState(TrafficLight_StatePattern trafficLight)
        {
            trafficLight.stopwatch.Stop();
            trafficLight.uIController.ShowTimerState("⏸ 暫停中");
        }

        public void UpdateState(TrafficLight_StatePattern trafficLight)
        {
            // 暫停狀態不做任何動作，等候 Resume
        }
    }

    #endregion

    #region 待機狀態

    public class IdleState : ITrafficLightState
    {
        public void EnterState(TrafficLight_StatePattern trafficLight)
        {
            trafficLight.uIController.ShowTimerState("Idle");
        }

        public void UpdateState(TrafficLight_StatePattern trafficLight)
        {
            // Idle 不做任何事
        }
    }

    #endregion

    #region 離開狀態

    public class ExitState : ITrafficLightState
    {
        public void EnterState(TrafficLight_StatePattern trafficLight)
        {
            trafficLight.uIController.ShowTimerState("Exit");
        }

        public void UpdateState(TrafficLight_StatePattern trafficLight)
        {
            // Idle 不做任何事
        }
    }

    #endregion

    public class TrafficLight_StatePattern : ITrafficLight
    {
        internal int greenDuration = 5;

        private bool IsFirst = true;
        private readonly bool IsRunning = true;
        internal int redDuration = 5;

        private ITrafficLightState stateNow;
        internal ITrafficLightState stateSave = new IdleState();
        internal Stopwatch stopwatch;
        private readonly Thread thread;
        internal ITrafficLightUIController uIController;
        internal int yellowDuration = 5;

        public TrafficLight_StatePattern(ITrafficLightUIController uIController)
        {
            this.uIController = uIController;

            S1 = ES1.Idle; // 初始狀態為 Idle
            stateNow = new IdleState(); // 初始燈號狀態

            stopwatch = new Stopwatch();

            thread = new Thread(RunFSM);
            thread.IsBackground = true;
            thread.Start();
        }

        private ES1 S1 { get; set; } // 維持系統模式

        public void SetDurations(int red, int green, int yellow)
        {
            redDuration = red > 0 ? red : 5;
            greenDuration = green > 0 ? green : 5;
            yellowDuration = yellow > 0 ? yellow : 5;
        }

        public void Start()
        {
            if (IsFirst)
                SetState(ES1.Active, new RedState());
            else
                SetState(ES1.Active, stateSave);
            stopwatch.Start();
        }

        public void Stop()
        {
            SetState(ES1.Idle, new IdleState());
            IsFirst = true;
            stopwatch.Reset();
        }

        public void Pause()
        {
            SetState(ES1.Pause, new PauseState(stateNow));
            stopwatch.Stop();
        }

        public void Exit()
        {
            SetState(ES1.Exit, new ExitState());
            stopwatch.Stop();
        }

        internal void SetState(ES1 s1, ITrafficLightState state)
        {
            S1 = s1;
            stateNow = state;
            stateSave = state;
            stateNow.EnterState(this); // 進入狀態時執行初始化
        }

        private void RunFSM()
        {
            while (IsRunning)
            {
                Thread.Sleep(20);

                switch (S1)
                {
                    case ES1.Idle:
                        uIController.ShowTimerState("Idle");
                        break;

                    case ES1.Pause:
                        uIController.ShowTimerState("Pause");
                        break;

                    case ES1.Active:
                        var timeNow = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
                        uIController.ShowTimerState($"Timer: {timeNow}");
                        stateNow.UpdateState(this);
                        break;
                }
            }
        }
    }
}