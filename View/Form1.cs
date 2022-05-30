using RoboMate.Controller;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;
using System.Net;
using RoboMate.Extensions;
using Newtonsoft.Json;
using System.Diagnostics;

namespace RoboMate
{
    public partial class Form1 : Form
    {
        private MateController mateController = MateController.GetMateController();
        protected Timer timer;
        SpeechSynthesizer speak = new SpeechSynthesizer();
        public Form1()
        {
            //убираем ненуженые элементы формы по типу окна, фона, оставляя только элементы внутри формы видимыми
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            ShowInTaskbar = false;
            //создание метода подгрузки персонажа
            mateController.LoadSprites();
            //скорость озвучки
            speak.Rate = 4;
            InitializeComponent();
            //первоначальная позиция персонажа
            pictureBox1.SetBounds(mateController.Mate.Position.X, mateController.Mate.Position.Y, mateController.Mate.SpriteWidth, mateController.Mate.SpriteHeight);
            //первоначальная инструкция
            speak.SpeakAsync("Чтобы увидеть список команд, введите 'Help' в поле слева сверху. Нажмите на Скрин Хелпера, чтоб скрыть и показать поле ввода. А выключить его можно в панели задач - пкм, эксит.");
            DialogResult d_r = MessageBox.Show("Чтобы увидеть список команд, введите 'Help' в поле слева сверху. Нажмите на ScreenHelper-a, чтоб скрыть и показать поле ввода. А выключить его можно в панели задач - пкм, exit.");

            if (d_r == DialogResult.OK)
            {
                speak.SpeakAsyncCancelAll();
            }
            timer = timer1;

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LimeGreen, e.ClipRectangle);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            pictureBox1.Image = mateController.NextImage();
            base.OnPaint(e);
        }

        //скрыть/показать кнопку "ок" и текстовое поле (чтоб не мешались)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            speak.SpeakAsync("Ай");

            if (toggle == true)
            {
                textBox1.Visible = true;
                button1.Visible = true;
                toggle = false;
            }
            else
            {
                textBox1.Visible = false;
                button1.Visible = false;
                toggle = true;
            }
        }

        bool move;
        bool move1;
        Point current;
        Point current2;
        //перемещение персонажа по экрану
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            {
                move1 = true;
                current2 = new Point(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            move1 = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move1)
            {
                Point thenLocation = pictureBox1.Location;
                thenLocation.X += e.X - current2.X;
                thenLocation.Y += e.Y - current2.Y;
                Task.Delay(0).Wait(0);
                pictureBox1.SetBounds(thenLocation.X + 15, thenLocation.Y + 15, mateController.Mate.SpriteWidth, mateController.Mate.SpriteHeight);
                pictureBox1.Image = mateController.NextImage2();
            }
        }

        //перемещение поля ввода вместе с кнопкой "ОК"
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (e.Button == MouseButtons.Left)
                {
                    move = true;
                    current = new Point(e.X, e.Y);
                }
            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                Point thenLocation = button1.Location;
                Point newlocation = textBox1.Location;
                thenLocation.X += e.X - current.X;
                thenLocation.Y += e.Y - current.Y;
                newlocation.X += e.X - current.X;
                newlocation.Y += e.Y - current.Y;
                button1.Location = thenLocation;
                textBox1.Location = newlocation;
                textBox1.Location = newlocation;
                button1.Location = thenLocation;
            }
        }

        //список запросов для ScreenHelper
        string[] help = { "help", "помощь" };
        string[] hello = { "привет", "здаров" };
        string[] weather = { "погода", "покажи погоду" };
        string[] finances = { "курс валют" };
        string[] find = { "find:" };
        string[] browse = { "браузер", "поиск в интернете", "найти в интернете" };

        //Массив ответов на запросы
        string[] hellpReplies = { "Приветствую вас, хозяин!", "Здравствуйте, хозяин, как поживаете?", "Доброго времени суток, хозяин." };

        bool toggle = false;
        bool search = false;
        bool isBrowsing = false;
        string query;
        int count;
        private void button1_Click(object sender, EventArgs e)
        {
            string request = textBox1.Text;
            request = request.ToLower();
            speak.SpeakAsyncCancelAll();
            if (search == false)
            {
                if (hello.Any(str => str == request))
                {
                    count++;
                    if (count >= 10)
                    {
                        speak.SpeakAsync("Сколько можно здороваться?");
                    }
                    else
                    {
                        Random x = new Random();
                        int n = x.Next(0, 2);
                        speak.SpeakAsync(hellpReplies[n]);
                    }
                }
                else if (weather.Any(str => str == request))
                {
                    weather_answer();

                }
                else if (request == "")
                {
                    empty_request();
                }
                else if (help.Any(str => str == request))
                {
                    help_answer();
                }
                else if (finances.Any(str => str == request))
                {
                    speak.SpeakAsync("Пока не умею, потом, когда парсить научусь...");
                }
                else if (find.Any(str => str == request))//поиск файла(пока не работает)
                {
                    speak.SpeakAsync("Укажите имя искомого файла");
                    MessageBox.Show("Укажите имя искомого файла");
                    textBox1.Text = "";
                    search = true;
                }
                else if (browse.Any(str => str == request))
                {
                    //открыть браузер и задать туда вопрос
                    isBrowsing = true;
                    speak.Speak("Введите поисковый запрос");
                }
                else
                {
                    speak.SpeakAsyncCancelAll();
                    speak.SpeakAsync("Хозяин лентяй, не пришил способность понимать что-то, кроме команд из списка 'Help'");
                }
            }

            textBox1.Text = "";

        }

        //эмуляция нажатия кнопки "ок" при нажатии "enter"
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (search == true)
                {
                    fsearch();
                }
                else if (isBrowsing)
                {
                    browsing();
                }
                else
                {
                    button1.PerformClick();
                }

            }
        }


        //выполнение команд

        //показать пользователю список доступных команд
        private void help_answer()
        {
            speak.SpeakAsync("Команды: Поздороваться - Привет, узнать погоду - Погода, найти в интернете - открыть браузер и искать");
            MessageBox.Show("Команды: Поздороваться - 'Привет', узнать погоду - 'Погода', 'найти в интернете' - открыть браузер и искать");
        }

        //парсинг погоды и выдача результатов в messageBox
        private void weather_answer()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Nur-Sultan&units=metric&lang=ru&appid=29ec7364a8c3317da7914c96b461542c";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            float temp = weatherResponse.Main.Temp;
            string feels_like = Convert.ToString(weatherResponse.Main.feels_like);
            float wind_speed = weatherResponse.wind.speed;
            feels_like = feels_like.Replace("-", "минус ");
            speak.SpeakAsync($"Погода в Астане на данный момент. {weatherResponse.Name} {temp} ° по цельсию, ощущается как {feels_like} °, ветер {wind_speed} метров в секунду");
            feels_like = feels_like.Replace("минус ", "-");
            MessageBox.Show($"Температура в {weatherResponse.Name} {temp} °C, ощущается как: {feels_like}°C, скорость ветра: {wind_speed} м/с");
        }

        //запрос с пустой строкой
        private void empty_request()
        {
            speak.SpeakAsync("Ээээ, строка пустая");
        }

        //поиск файлов по имени (пока не работает)
        private void fsearch()
        {
            string searcherText = textBox1.Text;
            string[] dirs = Directory.GetFiles(@"c:\\", $"*{searcherText}*.*", SearchOption.AllDirectories);
            string saerchRes = Convert.ToString(dirs);
            MessageBox.Show(saerchRes);
            textBox1.Text = "";
            search = false;

        }

        //браузинг
        private void browsing()
        {
            query = textBox1.Text;
            //задаём два возможных варианта используемых браузеров и задаём по умолчанию Хром
            string Chrome = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            string Firefox = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
            string browserToUse = Chrome;
            string browsing_url = Convert.ToString(textBox1.Text);
            browsing_url = textBox1.Text;
            //в случае, если Хром будет отсутствовать на компе в стандартном пути установки, то программа будет искать Файрфокс, если и его нет, то выдаст ошибку
            //так же идёт грубая проверка на то, ссылка ли введена или обычный запрос
            try
            {
                if (browsing_url.Contains(".com") || browsing_url.Contains(".ru"))
                {
                    Process.Start(browserToUse, browsing_url);
                }
                else if (browsing_url.Contains(".kz"))
                {
                    Process.Start(browserToUse, browsing_url);
                }
                else
                {
                    query = query.Replace(" ", "+");
                    string browsing = "https://www.google.com/search?q=" + query;
                    Process.Start(browserToUse, browsing);
                    textBox1.Text = "";
                }
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                {
                    browserToUse = Firefox;
                }
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
            try
            {

                if (browsing_url.Contains(".com") || browsing_url.Contains(".ru"))
                {
                    Process.Start(browserToUse, browsing_url);
                }
                else
                {
                    query = query.Replace(" ", "+");
                    string browsing = "https://www.google.com/search?q=" + query;
                    Process.Start(browserToUse, browsing);

                }
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                {
                    browserToUse = Chrome;
                }
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
            //очистка строки
            textBox1.Text = "";
            isBrowsing = false;
        }
    }
}
