namespace TrafficLight_FSM
{
    public interface ITrafficLightUIController
    {
        void ShowTimerState(string timeState);
        void ShowRedLight();
        void ShowYellowLight();
        void ShowGreenLight();
        void EnableStartButton(bool enable);
        void EnablePauseButton(bool enable);
        void EnableStopButton(bool enable);
    }
}