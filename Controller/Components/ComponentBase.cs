using RoboMate.Model;
using System.Threading;

namespace RoboMate.Controller.Components
{
    public abstract class ComponentBase : IComponent
    {
        protected Mate mate;
        private Thread thread;
        private bool running;
        private ManualResetEvent manualResetEvent;
        protected Configurations configurations;
        public virtual void InitComponent()
        {
            mate = MateController.GetMateController().Mate;
            manualResetEvent = new ManualResetEvent(true);
            UpdateComponentConfiguration();
            thread = new Thread(RunThread);
            running = true;
            ResumeComponent();
            thread.Start();
        }
        public void FinalizeComponent()
        {
            SuspendComponent();
            running = false;
            manualResetEvent.Set();
        }

        public virtual void ResumeComponent() => manualResetEvent.Set();

        private void RunThread()
        {
            while (running)
            {
                RunComponent();
                manualResetEvent.WaitOne();
            }
        }
        public abstract void RunComponent();
        
        public virtual void SuspendComponent() => manualResetEvent.Reset();

        public virtual void UpdateComponentConfiguration()
        {
            configurations = ConfigController.GetConfigController().Configurations;
        }
    }
}
