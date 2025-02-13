using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight_FSM.StatePattern;
using TrafficLight_FSM;

namespace TrafficLight_FSM_Project.Scopes
{
    public partial class Scope
    {
        public static ITrafficLight trafficLight;

        public static void InitTrafficLight()
        {
            trafficLight = new TrafficLight2(mainForm);
        }

    }
}
