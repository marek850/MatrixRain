using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixV2
{
    internal class Kvapka
    {
        private int dlzka;
        private Kvapka[] teloKvapky;
        private string znaky;
        public int Length { get => dlzka; set => dlzka = value; }
        public Kvapka[] TeloKvapky { get => teloKvapky; set => teloKvapky = value; }
        public char Znak { get => znak; set => znak = value; }
        private bool up;
        public int X
        {
            get => x; set
            {
                x = value;

            }
        }
        public int Y
        {
            get => y; set
            {
                y = value;

            }
        }

        public bool Up { get => up; set => up = value; }
        public string Znaky { get => znaky; set => znaky = value; }

        private int x;
        private int y;
        private char znak = 'a';
        public Kvapka(int length, int x, int y, bool up, string znaky)
        {
            Random r = new Random();
            Length = length;
            Up = up;
            X = x;
            Y = y;
            Znaky = znaky;
            Znak = znaky[r.Next(Znaky.Length)];
            TeloKvapky = new Kvapka[length - 1];
            if (length - 1 > 0)
            {

                for (int i = 0; i < TeloKvapky.Length; i++)
                {
                    TeloKvapky[i] = new Kvapka(1, X, Y - (i + 1), Up, Znaky);
                    TeloKvapky[i].Znak = znaky[r.Next(Znaky.Length)];
                }
            }


        }
        public void setLength(int len)
        {
            Random r = new Random();
            TeloKvapky = new Kvapka[len - 1];
            if (len - 1 > 0)
            {

                for (int i = 0; i < TeloKvapky.Length; i++)
                {
                    TeloKvapky[i] = new Kvapka(1, X, Y - (i + 1), Up, Znaky);
                    TeloKvapky[i].Znak = znaky[r.Next(Znaky.Length)];
                }
            }
        }
        public void setY(int _y)
        {
            Y = _y;
            if (Length - 1 > 0)
            {
                foreach (var item in TeloKvapky)
                {
                    item.Y = Y - 1;
                }
            }
        }
        public void setX(int _x)
        {
            X = _x;
            if (Length - 1 > 0)
            {
                foreach (var item in TeloKvapky)
                {
                    item.X = X;
                }
            }
        }
        public void posun()
        {
            Random r = new Random();
            Y = Y + 1;
            if (r.Next(100) > 80)
            {
                Znak = znaky[r.Next(Znaky.Length)];
            }
            //if (TeloKvapky.Length > 0)
            //{
            //    foreach (Kvapka a in TeloKvapky)
            //    {
            //        a.posun();
            //    }
            //}
        }
    }
}
