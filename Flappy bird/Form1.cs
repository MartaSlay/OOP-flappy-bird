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

		int indexPrveCevi;
		int indexCeviIspredPtice;
		int ideGore;
		int ubrzavanje;
		int Highscore;
		bool gameOver;
		private void Form1_Load(object sender, EventArgs e)
		{
			ideGore = 0;
			ubrzavanje = 0;
			gameOver = false;

			var x = Width;
			var sirinaCevi = Width/8;
			razmak = (Width - 3*sirinaCevi)/3;
			pticaX = Width / 8;
			pticaY = Height / 2;
			PostaviPticu();
			for ( int i = 0; i < 4; i++ )
			{
				var cev = new Cev(this);
				cev.PostaviRupu(x, sirinaCevi);
				Cevi.Add(cev);

				x += razmak+sirinaCevi;
			}
			indexPrveCevi = 0;
			indexCeviIspredPtice = 0;

			timer1.Start();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
            //Score i provera udarca
            if (pbxPtica.Right >= Cevi[indexCeviIspredPtice].GornjaCev.Left && pbxPtica.Left <= Cevi[indexCeviIspredPtice].GornjaCev.Right)
            {
				if (pbxPtica.Top+5 <= Cevi[indexCeviIspredPtice].GornjaCev.Bottom ||
					pbxPtica.Bottom-5 >= Cevi[indexCeviIspredPtice].DonjaCev.Top)
				{
					gameOver = true;
				}
            }
			else if (pbxPtica.Left > Cevi[indexCeviIspredPtice].GornjaCev.Right)
            {
				indexCeviIspredPtice++;

				if (indexCeviIspredPtice == Cevi.Count) indexCeviIspredPtice = 0;
            }
			//pomeranje cevi
			if(!gameOver)PomeranjeCevi();
			//kretanje ptice
			if (ideGore > 0 && !gameOver)
			{
				ubrzavanje = 0;
				pbxPtica.Top -= ideGore;//koristim trajanje koliko dugo treba da ide gore da bi postigao blago usporavanje
				ideGore--;
			}
			else if(pbxPtica.Top <= ClientSize.Height)
            {
				pbxPtica.Top+=ubrzavanje;
				if(ubrzavanje !=5)ubrzavanje++;//blago ubrzavanje
            }
			else gameOver = true;

		}

		private void PomeranjeCevi()
        {
			foreach (var cev in Cevi)
			{
				cev.PomeriCevLevo(5);
			}
			if (Cevi[indexPrveCevi].DaLiJeIzaslo(razmak))
			{
				var prva = Cevi[indexPrveCevi];
				prva.PomeriSkrozDesno();
				indexPrveCevi++;
				if (indexPrveCevi == Cevi.Count)
				{
					indexPrveCevi = 0;
				}
			}
		}
		private void PostaviPticu()
		{
			//pocetna pozicija i velicina ptice
			int sirinaPtice = Width /12;
			int duzinaPtice = sirinaPtice - sirinaPtice/10;
			pbxPtica.SetBounds(pticaX, pticaY-duzinaPtice, sirinaPtice, duzinaPtice);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Space)
            {
				ideGore = 10;//koliko dugo ce ici ka gore nakon pritiska spejsa
            }
        }
    }
}