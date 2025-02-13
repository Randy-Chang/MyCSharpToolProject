namespace TrafficLight_FSM.StatePattern
{
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
}