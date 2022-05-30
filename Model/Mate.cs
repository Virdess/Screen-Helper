using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RoboMate;

namespace RoboMate.Model
{


	public class Mate
	{
		//static Form1 Form1 = new Form1();
		static int width = Screen.PrimaryScreen.Bounds.Width; //получение разрешения экрана
		static int height = Screen.PrimaryScreen.Bounds.Height;
		

		public Point Position { get; set; } = new Point(width-100, height-100);
		public bool IsRam { get; set; } = false;
		public bool IsProcessor { get; set; } = false;
		public bool IsIdle { get; set; } = false;
		public int SpriteWidth { get; set; } = 53;
		public int SpriteHeight { get; set; } = 62;
		public int NumOfSprites { get; set; } = 4;
		public int NumOfRows { get; set; } = 9;
		public List<List<Image>> Sprites { get; set; } = new List<List<Image>>();
		public int CurrentSpriteCol { get; set; } = 0;
		public int CurrentSpriteRow { get; set; } = 7;

	}
}
