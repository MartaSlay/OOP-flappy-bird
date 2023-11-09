using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_bird
{
	public class Cev
	{
		private int X;
		private int sirinaCevi;
		public PictureBox GornjaCev { get; set; }
		public PictureBox DonjaCev { get; set; }
		private int y;
		private Form form;

		public Cev( Form form )
		{
			GornjaCev = new PictureBox();
			DonjaCev = new PictureBox();
			this.form = form;
			GornjaCev.TabStop = false;
			DonjaCev.TabStop = false;
			GornjaCev.Image = Image.FromFile("gornjaCev.png");
			DonjaCev.Image = Image.FromFile("donjaCev.png");
			GornjaCev.BackColor = Color.Transparent;
			DonjaCev.BackColor = Color.Transparent;
			DonjaCev.SizeMode = PictureBoxSizeMode.StretchImage;
			GornjaCev.SizeMode = PictureBoxSizeMode.StretchImage;
			
			form.Controls.Add( GornjaCev );
			form.Controls.Add( DonjaCev );
		}

		public void PostaviRupu( int cevX, int sirinaCevi )
		{
			X = cevX;
			this.sirinaCevi = sirinaCevi;
			int visinaForm = form.ClientSize.Height;
			var duzinaCevi = visinaForm;

			int razmakIzmedjuGornjeIDonje = visinaForm/3;
			var random = new Random();

			var cevYdole = random.Next(visinaForm/10+razmakIzmedjuGornjeIDonje, 
					visinaForm - visinaForm/10);
			var cevYgore = cevYdole - razmakIzmedjuGornjeIDonje - duzinaCevi;


			DonjaCev.SetBounds(cevX, cevYdole, sirinaCevi, duzinaCevi);
			GornjaCev.SetBounds(cevX, cevYgore, sirinaCevi, duzinaCevi);

		}

		public void PomeriCevLevo( int delta )
		{
			X -= delta;
			GornjaCev.Left = X;
			DonjaCev.Left = X;
		}

		public bool DaLiJeIzaslo( int razmak )
		{
			return GornjaCev.Right + razmak < 0;
		}

		public void PomeriSkrozDesno()
		{
			X = form.Width;
			PostaviRupu(X, sirinaCevi);
		}
	}
}
