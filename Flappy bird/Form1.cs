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
		public static int razmak;
		public static List<Cev> Cevi = new List<Cev>();
		Label brojacPoena,maxPoena,krajIgre;

		int brzinaPtice = 6;
		int jacinaSkoka = 1;

		int brzinaCevi = 3;

		int indexPrveCevi;
		int indexCeviIspredPtice;
		int ideGore;
		int ubrzavanje;
		int highScore;
		int score;
		bool gameOver;
		private void Form1_Load(object sender, EventArgs e)
		{

			this.Width = 900;
			this.Height = 500;

			brojacPoena = new Label();
			brojacPoena.BackColor = Color.White;
			brojacPoena.ForeColor = Color.Black;
			brojacPoena.BorderStyle = BorderStyle.Fixed3D;
			brojacPoena.Text = "0";
			brojacPoena.Font = new Font("Arial",30,FontStyle.Bold);
			brojacPoena.SetBounds(Width/2-20,Height/10,40,45);
			Controls.Add(brojacPoena);

			krajIgre = new Label();
			krajIgre.BackColor = Color.White;
			krajIgre.ForeColor = Color.Black;
			krajIgre.BorderStyle = BorderStyle.FixedSingle;
			krajIgre.Text = "KRAJ IGRE";
			krajIgre.Font = new Font("Gill Sans Ultra Bold", 50, FontStyle.Bold);
			krajIgre.SetBounds(Width / 2-250, Height / 3, 500, 90);
			Controls.Add(krajIgre);

			maxPoena = new Label();
			maxPoena.BackColor = Color.White;
			maxPoena.ForeColor = Color.Black;
			maxPoena.BorderStyle = BorderStyle.Fixed3D;
			maxPoena.Font = new Font("Arial", 30, FontStyle.Bold);
			maxPoena.SetBounds(Width / 2 - 100, Height / 3+100, 200, 45);
			Controls.Add(maxPoena);

			PocetnaPozicija();
		}
		private void PocetnaPozicija()
		{
			maxPoena.Visible = false;
			krajIgre.Visible = false;
			ideGore = 0;
			ubrzavanje = 0;
			gameOver = false;
			score = 0;

			brojacPoena.Text = "0";
			brojacPoena.SetBounds(Width / 2 - 20, Height / 10, 40, 45);

			var x = Width;
			var sirinaCevi = Width / 8;
			razmak = (Width - 3 * sirinaCevi) / 3;
			PostaviPticu();
            if (Cevi.Count == 0)
            {
                for (int i = 0; i < 4; i++)
                {
					Cevi.Add(new Cev(this));
                }
            }
			for (int i = 0; i < 4; i++)
			{
                Cevi[i].PostaviRupu(x, sirinaCevi);
				x += razmak + sirinaCevi;
			}
			indexPrveCevi = 0;
			indexCeviIspredPtice = 0;

			timer1.Start();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
            if (!gameOver)
            {
				//Score i provera udarca
				if (pbxPtica.Right >= Cevi[indexCeviIspredPtice].GornjaCev.Left && pbxPtica.Left <= Cevi[indexCeviIspredPtice].GornjaCev.Right)
				{
					if (pbxPtica.Top + 5 <= Cevi[indexCeviIspredPtice].GornjaCev.Bottom ||
						pbxPtica.Bottom - 5 >= Cevi[indexCeviIspredPtice].DonjaCev.Top)
					{
						gameOver = true;
					}
				}
				else if (pbxPtica.Left > Cevi[indexCeviIspredPtice].GornjaCev.Right)
				{
					indexCeviIspredPtice++;
					score++;
					if (score > highScore) highScore = score;
					brojacPoena.Text = score.ToString();
					int sirinaBrojaca = 40 + (30 * (brojacPoena.Text.Length-1));
					brojacPoena.SetBounds(Width / 2 - sirinaBrojaca/2, Height / 10, sirinaBrojaca, 45);
					if (indexCeviIspredPtice == Cevi.Count) indexCeviIspredPtice = 0;
				}
				PomeranjeCevi();
				PomeranjePtice();
			}
            else
            {
				krajIgre.Visible = true;
				maxPoena.Text = $"Rekord: {highScore}";
				maxPoena.Width = 200 + brojacPoena.Width;
				maxPoena.Visible = true;
                if (pbxPtica.Top <= ClientSize.Height)
                {
					pbxPtica.Top += ubrzavanje;
					if (ubrzavanje != brzinaPtice) ubrzavanje++;
				}
            }
		}
		private void PomeranjePtice()
        {
			if (ideGore > 0)
			{
				ubrzavanje = 0;
				pbxPtica.Top -= ideGore;//koristim trajanje koliko dugo treba da ide gore da bi postigao blago usporavanje
				ideGore--;
			}
			else if (pbxPtica.Top <= ClientSize.Height)
			{
				pbxPtica.Top += ubrzavanje;
				if (ubrzavanje != brzinaPtice) ubrzavanje++;//blago ubrzavanje
			}
			else gameOver = true;
		}

		private void PomeranjeCevi()
        {
			foreach (var cev in Cevi)
			{
				cev.PomeriCevLevo(brzinaCevi);
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
			int pticaX = Width / 8;
			int pticaY = Height / 2;
			//pocetna pozicija i velicina ptice
			int sirinaPtice = Width /14;
			int duzinaPtice = sirinaPtice - sirinaPtice/10;
			pbxPtica.SetBounds(pticaX, pticaY-duzinaPtice, sirinaPtice, duzinaPtice);
		}
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Space && !gameOver)
            {
				ideGore = brzinaPtice*jacinaSkoka;//koliko dugo ce ici ka gore nakon pritiska spejsa
            }else if (e.KeyCode == Keys.Space)
            {
				PocetnaPozicija();
            }
        }
    }
}