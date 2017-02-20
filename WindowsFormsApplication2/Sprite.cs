using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class Sprite
    {
        private Sprite parent = null;

        //instance variable
        private float x = 0;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        private float y = 0;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        private float scale = 1;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        private float rotation = 0;

        /// <summary>
        /// The rotation in degrees.
        /// </summary>
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }


        public List<Sprite> children = new List<Sprite>();


        public void Kill()
        {
            parent.children.Remove(this);
        }

        //methods
        public void render(Graphics g)
        {
            Matrix original = g.Transform.Clone();
            g.TranslateTransform(x, y);
            g.ScaleTransform(scale, scale);
            g.RotateTransform(rotation);
            paint(g);
            foreach (Sprite s in children)
            {
                s.render(g);
            }
            g.Transform = original;
        }

        public void update()
        {
            act();
            foreach (Sprite s in children)
            {
                s.update();
            }
        }

        public virtual void paint(Graphics g)
        {

        }

        public virtual void act()
        {

        }

        public void add(Sprite s)
        {
            s.parent = this;
            children.Add(s);
        }
    }

    public class TextSprite : Sprite
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public string str;

        public TextSprite(int h, int w) : base()
        {
            Random rand = new Random();
            x = rand.Next(w);
            y = rand.Next(w);
            width = w;
            height = h;
            str = "heck yeah";
        }

        public TextSprite(int h, int w, String str) : base()
        {
            Random rand = new Random();
            x = rand.Next(w);
            y = rand.Next(w);
            height = h;
            width = w;
            this.str = str;
        }

        public TextSprite(int h, int w, String str, int i) : base()
        {
            Random rand = new Random();
            x = (rand.Next(w)+10*i)%w;
            y = i%h;
            height = h;
            width = w;
            this.str = str;
        }

        public override void act()
        {
            x=(x+1)%(width-50);
            y=(y+1)%(height-50);
        }

        public override void paint(Graphics g)
        {
            g.DrawString(str, new Font("Comic Sans MS", 10), Brushes.LawnGreen, x, y);
        }
    }

}
