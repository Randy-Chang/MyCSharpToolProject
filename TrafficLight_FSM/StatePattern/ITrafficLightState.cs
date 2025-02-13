namespace TrafficLight_FSM.StatePattern
{
    public interface ITrafficLightState
    {
        void EnterState(TrafficLight_StatePattern context);
        void UpdateState(TrafficLight_StatePattern context);
    }
}