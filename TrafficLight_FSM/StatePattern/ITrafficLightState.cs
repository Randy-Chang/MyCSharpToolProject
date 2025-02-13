using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight_FSM.StatePattern
{
    public enum ES1 { Idle, Pause, Active, Exit }

    public enum ETrafficLightState { Red, Green, Yellow }

    public interface ITrafficLightState
    {
        void EnterState(TrafficLight2 context);
        void UpdateState(TrafficLight2 context);
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
