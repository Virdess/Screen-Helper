using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Threading;

namespace RoboMate.Controller.Components
{
    
    public abstract class MovementComponentBase : ComponentBase
    {
        protected Point destination = new Point(0, 0);
        protected float stoppingDistance = 10f;
        protected int speed = 15;

        //Form1 clickMove = new Form1();
        

        public override void RunComponent()
        {
            
            Thread.Sleep(100);
            if (mate.IsProcessor || mate.IsIdle || mate.IsRam)
                return;
            var distance = GetDistanceFromMate(destination);
            Debug.WriteLine($"Distance: {distance}");
            Debug.WriteLine($"mate.Position: {mate.Position}");
            if (distance < stoppingDistance)
            {
                mate.CurrentSpriteRow = 7;
                return;
            }
            //Form1.MousePosition;
            //Form1.Position point = GetNewPosition();
            //mate.Position = GetNewPosition();

        }

       private Point GetNewPosition()
        {
            var dirNormalized = Vector2.Normalize(new Vector2(destination.X - mate.Position.X, destination.Y - mate.Position.Y));
            SetMateDirection(dirNormalized);
            return new Point(Convert.ToInt32(mate.Position.X + dirNormalized.X * speed), Convert.ToInt32(mate.Position.Y + dirNormalized.Y * speed));
            
        }

        
        private void SetMateDirection(Vector2 dirNormalized)
        {
            if(MathF.Abs(dirNormalized.X) > MathF.Abs(dirNormalized.Y))
            {
                mate.CurrentSpriteRow = dirNormalized.X > 0 ? 2 : 1;
            }
            else
            {
                mate.CurrentSpriteRow = dirNormalized.Y > 0 ? 0 : 3;
            }
        }

        protected float GetDistanceFromMate(Point p)
        {
            return 0;/*(float)Math.Sqrt((mate.Position.X - p.X) * (mate.Position.X - p.X) + (mate.Position.Y - p.Y) * (mate.Position.Y - p.Y));*/
        }
    }
}
