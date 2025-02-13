namespace TrafficLight_FSM.StatePattern
{
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
}