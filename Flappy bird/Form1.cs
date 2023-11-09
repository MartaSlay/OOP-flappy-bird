using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Flappy_bird
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		public static int pticaX;
		public static int pticaY;
		public static int razmak;
		public static List<Cev> Cevi = new List<Cev>();

		private void Form1_Load(object sender, EventArgs e)
		{
			var x = Width;
			var sirinaCevi = Width/8;
			razmak = (Width - 3*sirinaCevi)/3;
			PostaviPticu();
			for ( int i = 0; i < 4; i++ )
			{
				var cev = new Cev(this);
				cev.PostaviRupu(x, sirinaCevi);
				Cevi.Add(cev);

				x += razmak+sirinaCevi;
			}

			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			foreach ( var cev in Cevi )
			{
				cev.PomeriCevLevo(5);
			}
			if ( Cevi[0].DaLiJeIzaslo(razmak) )
			{
				var prva = Cevi[0];
				prva.PomeriSkrozDesno();
				Cevi.RemoveAt(0);
				Cevi.Add(prva);
			}

			Refresh();
		}

		private void PostaviPticu()
		{
			int visinaForm = Height;
			int sirinaForm = Width;
			//pocetna pozicija i velicina ptice
			int sirinaPtice = sirinaForm/12;
			int duzinaPtice = sirinaPtice - sirinaPtice/10;
			pticaX = sirinaForm/8;
			pticaY = visinaForm/2 - duzinaPtice;
			pbxPtica.SetBounds(pticaX, pticaY, sirinaPtice, duzinaPtice);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}


	}
}