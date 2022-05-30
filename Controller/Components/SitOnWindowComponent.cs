using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RoboMate.Controller.Components
{
    [Component("SitOnWindow")]
    public class SitOnWindowComponent : MovementComponentBase
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        private Rectangle position;
        private Process top;
        private Thread searchThread;
        private bool search;
        public override void ResumeComponent()
        {
            searchThread = new Thread(SetTopProcess);
            search = true;
            searchThread.Start();
            base.ResumeComponent();
        }

        public override void RunComponent()
        {
            FindDestination();
            Debug.WriteLine($"SitOnWindow");
            base.RunComponent();
        }

        private void SetTopProcess()
        {
            while (search)
            {
                top = FindTopProcess();
            }
        }

        private Process FindTopProcess()
        {
            var openWindowProcesses = Process.GetProcesses()
                    .Where(p => p.MainWindowTitle != "" && p.ProcessName != "RoboMate").ToList();

            Process newTop = null;
            int topz = int.MaxValue;
            foreach (Process p in openWindowProcesses)
            {
                IntPtr handle = p.MainWindowHandle;
                int z = 0;
                do
                {
                    z++;
                    handle = GetWindow(handle, 3);
                } while (handle != IntPtr.Zero);

                if (z < topz)
                {
                    newTop = p;
                    topz = z;
                }
            }

            return newTop;
        }

        private void FindDestination()
        {
            if (top != null)
            {
                Debug.WriteLine(top.ProcessName);
                var windowHandler = top.MainWindowHandle;
                GetWindowRect(windowHandler, out position);
                var bounds = Screen.PrimaryScreen.Bounds;
                if (position.Y > 60 && position.Y < bounds.Height - 10)
                {
                    destination = new Point(Math.Min(bounds.Width - 10, Math.Max(10, position.X + ((position.Width - position.X) / 2))), position.Location.Y - mate.SpriteHeight);
                }
            }
            else
            {
                destination = mate.Position;
            }
        }

        public override void SuspendComponent()
        {
            search = false;
            base.SuspendComponent();
        }
    }
}
