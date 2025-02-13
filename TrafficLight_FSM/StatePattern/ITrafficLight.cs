namespace TrafficLight_FSM.StatePattern
{
    public interface ITrafficLight
    {
        void Start();

        void Stop();

        void Pause();

        void Exit();

        void SetDurations(int red, int green, int yellow);
    }
}