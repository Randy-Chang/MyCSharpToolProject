namespace TrafficLight_FSM.StatePattern
{
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
}