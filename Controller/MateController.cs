using RoboMate.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RoboMate.Controller
{
    public class MateController
    {
        public Mate Mate { get; }

        private static MateController mateController;
        public static MateController GetMateController()
        {
            mateController ??= new MateController();
            return mateController;
        }
        private MateController()
        {
            Mate = new Mate();
        }

        public bool LoadSprites()
        {
            int requiredWidth = Mate.SpriteWidth * Mate.NumOfSprites;
            int requiredHeight = Mate.SpriteHeight;

            try
            {
                var configsurations = ConfigController.GetConfigController().Configurations;
                Image image = Bitmap.FromFile(configsurations.ImagePath);
                for (int j = 0; j < Mate.NumOfRows; j++)
                {
                    List<Image> rowList = new List<Image>();
                    for (int i = 0; i < Mate.NumOfSprites; i++)
                    {
                        System.Threading.Thread.Sleep(200);
                        rowList.Add(new Bitmap(Mate.SpriteWidth, Mate.SpriteHeight));
                        using (Graphics g = Graphics.FromImage(rowList[i]))
                            g.DrawImage(image, new Rectangle(0, 0, Mate.SpriteWidth, Mate.SpriteHeight), new Rectangle(i * Mate.SpriteWidth, j* Mate.SpriteHeight, Mate.SpriteWidth, Mate.SpriteHeight), GraphicsUnit.Pixel);
                    }
                    Mate.Sprites.Add(rowList);
                }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading file." + Environment.NewLine + ex.Message, "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public Image NextImage()
        {
            
            var image = Mate.Sprites[Mate.CurrentSpriteRow][Mate.CurrentSpriteCol];

            Mate.CurrentSpriteCol++;
            Mate.CurrentSpriteCol %= Mate.NumOfSprites;
            return image;
        }

        public Image NextImage2()
        {
            var image = Mate.Sprites[Mate.CurrentSpriteRow][Mate.CurrentSpriteCol];

            Mate.CurrentSpriteCol++;
            Mate.CurrentSpriteCol %= Mate.NumOfSprites;
            System.Threading.Thread.Sleep(0);
            return image;
        }

    }
}
