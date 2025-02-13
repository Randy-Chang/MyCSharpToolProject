namespace TrafficLight_FSM.StatePattern
{
    public enum ES1
    {
        Idle,
        Pause,
        Active,
        Exit
    }

    public enum ETrafficLightState
    {
        Red,
        Green,
        Yellow
    }

    public interface ITrafficLightState
    {
        void EnterState(TrafficLight_StatePattern context);
        void UpdateState(TrafficLight_StatePattern context);
    }

    public interface ITrafficLight
    {
        void Start();

        void Stop();

        void Pause();

        void Exit();

        void SetDurations(int red, int green, int yellow);
    }
}