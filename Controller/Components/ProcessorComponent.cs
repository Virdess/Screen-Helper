using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace RoboMate.Controller.Components
{
    [Component("Processor")]
    public class ProcessorComponent : ComponentBase
    {

        private int counter;
        PerformanceCounter CPUPerformance;
        public override void InitComponent()
        {
            CPUPerformance = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            counter = 0;
            base.InitComponent();
        }

        public override void RunComponent()
        {
            //must sleep
            Thread.Sleep(100);
            var CPUPercentage= CPUPerformance.NextValue();
            Debug.WriteLine($"CPUPercentage: {CPUPercentage}");
            if (CPUPercentage > configurations.ProcessorThreshold && counter < 25)
                counter++;
            else
                counter = Math.Max(0, --counter);
            mate.IsProcessor = counter > 20;

            if (mate.IsProcessor && !mate.IsIdle)
                mate.CurrentSpriteRow = mate.IsRam ? 6 : 5;

            Debug.WriteLine($"Processor: {mate.IsProcessor}");
        }

        public override void SuspendComponent()
        {
            base.SuspendComponent();
            counter = 0;
            mate.IsProcessor = false;
        }
    }
}
