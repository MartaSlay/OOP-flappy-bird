using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_bird
{
	public class Cev
	{
		private int X;
		private int sirinaCevi;
		public PictureBox GornjaCev { get; set; }
		public PictureBox DonjaCev { get; set; }
		private Form form;

		public Cev( Form form )
		{
			GornjaCev = new PictureBox();
			DonjaCev = new PictureBox();
			this.form = form;
			GornjaCev.TabStop = false;
			DonjaCev.TabStop = false;
			DonjaCev.Paint += new System.Windows.Forms.PaintEventHandler(DonjaCev1_Paint);
			GornjaCev.Paint += new System.Windows.Forms.PaintEventHandler(GornjaCev1_Paint);

			GornjaCev.BackColor = Color.Transparent;
			DonjaCev.BackColor = Color.Transparent;
			
			form.Controls.Add( GornjaCev );
			form.Controls.Add( DonjaCev );
		}
		private void DonjaCev1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			var ukupnaVisinaCevi = form.ClientSize.Height; 
			var visinaGornjegDela = ukupnaVisinaCevi/12;
			var visinaDonjegDela = ukupnaVisinaCevi - visinaGornjegDela;
			var Xdonje = sirinaCevi/14;
			var sirinaDonje = sirinaCevi-Xdonje*2;
			var sirinaSenke = sirinaCevi/5;

			Color zelena = ColorTranslator.FromHtml("#7FCD4A");
			Color senka = ColorTranslator.FromHtml("#32531C");
			Color senka2 = ColorTranslator.FromHtml("#4C7E29");

			//donji deo cevi
			g.FillRectangle(new SolidBrush(zelena), new Rectangle(Xdonje, visinaGornjegDela, sirinaDonje, visinaDonjegDela));
			g.FillRectangle(new SolidBrush(senka), new Rectangle(Xdonje, visinaGornjegDela, sirinaSenke, visinaDonjegDela));
			g.FillRectangle(new SolidBrush(senka2), new Rectangle(Xdonje+sirinaSenke, visinaGornjegDela, sirinaSenke, visinaDonjegDela));
			g.FillRectangle(new SolidBrush(senka), new Rectangle(Xdonje, visinaGornjegDela, sirinaDonje, visinaGornjegDela/4));
			g.DrawRectangle(new Pen(Color.Black), new Rectangle(Xdonje, visinaGornjegDela, sirinaDonje, visinaDonjegDela));
			//gornji deo cevi
			g.FillRectangle(new SolidBrush(zelena), new Rectangle(0, 0, sirinaCevi, visinaGornjegDela));
			g.FillRectangle(new SolidBrush(senka), new Rectangle(0, 0, sirinaSenke, visinaGornjegDela));			
			g.FillRectangle(new SolidBrush(senka2), new Rectangle(sirinaSenke, 0, sirinaSenke, visinaGornjegDela));			
			g.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, sirinaCevi, visinaGornjegDela));
		}
		private void GornjaCev1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			var ukupnaVisinaCevi = form.ClientSize.Height;
			var visinaDonjegDela = ukupnaVisinaCevi/12;
			var visinaGornjegDela = ukupnaVisinaCevi - visinaDonjegDela;
			var Xgornje = sirinaCevi/14;
			var sirinaGornje = sirinaCevi-Xgornje*2;
			var sirinaSenke = sirinaCevi/5;

			Color zelena = ColorTranslator.FromHtml("#7FCD4A");
			Color senka = ColorTranslator.FromHtml("#32531C");
			Color senka2 = ColorTranslator.FromHtml("#4C7E29");

			//gornji deo cevi
			g.FillRectangle(new SolidBrush(zelena), new Rectangle(Xgornje, 0, sirinaGornje, visinaGornjegDela));
			g.FillRectangle(new SolidBrush(senka), new Rectangle(Xgornje, 0, sirinaSenke, visinaGornjegDela));
			g.FillRectangle(new SolidBrush(senka2), new Rectangle(Xgornje+sirinaSenke, 0, sirinaSenke, visinaGornjegDela));
			g.FillRectangle(new SolidBrush(senka), new Rectangle(Xgornje, visinaGornjegDela-visinaDonjegDela/4, sirinaGornje, visinaDonjegDela/4));
			g.DrawRectangle(new Pen(Color.Black), new Rectangle(Xgornje, 0, sirinaGornje, visinaGornjegDela));
			//gornji deo cevi
			g.FillRectangle(new SolidBrush(zelena), new Rectangle(0, visinaGornjegDela, sirinaCevi, visinaDonjegDela));
			g.FillRectangle(new SolidBrush(senka), new Rectangle(0, visinaGornjegDela, sirinaSenke, visinaDonjegDela));
			g.FillRectangle(new SolidBrush(senka2), new Rectangle(sirinaSenke, visinaGornjegDela, sirinaSenke,	visinaDonjegDela));
			g.DrawRectangle(new Pen(Color.Black), new Rectangle(0, visinaGornjegDela, sirinaCevi, visinaDonjegDela));
		}
		public PaintEventHandler PaintEvent { get; set; }
		public void PostaviRupu( int cevX, int sirinaCevi )
		{
			X = cevX;
			this.sirinaCevi = sirinaCevi;
			int visinaForm = form.ClientSize.Height;
			var duzinaCevi = visinaForm;

			int razmakIzmedjuGornjeIDonje = visinaForm/3;
			var random = new Random();

			var cevYdole = random.Next(visinaForm/10+razmakIzmedjuGornjeIDonje, visinaForm - visinaForm/6);
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
