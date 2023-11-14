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
			pocetnaPozPtice = new Bitmap(pbxPtica.BackgroundImage);
		}
		int razmak;
		List<Cev> Cevi = new List<Cev>();

		Label lblBrojacPoena=new Label();
		Label lblMaxPoena = new Label();
		Bitmap pocetnaPozPtice;
		Bitmap pticaPoz45 = new Bitmap(Properties.Resources.pbxPtica_BackgroundImage45);
		Bitmap pticaPoz315 = new Bitmap(Properties.Resources.pbxPtica_BackgroundImage315);
		PictureBox pbxZemlja = new PictureBox();
		PictureBox pbxKrajIgre = new PictureBox();

		int brzinaPtice = 20;
		int jacinaSkoka = 15;
		int brzinaCevi = 12;
		int ubrzanjePtice = 2;

		int indexPrveCevi;
		int indexCeviIspredPtice;
		int ideGore;//koliko dugo ptica treba da ide ka gore
		int brzinaKaDole;
		int highScore;
		int score;
		bool gameOver;
		bool igraPocela;
		private void Form1_Load(object sender, EventArgs e)
		{
			this.Width = 1200;
			this.Height = 800;

			this.MinimumSize = new Size(640,480);

			Label lblKrajIgre = new Label();
			Bitmap bmpKrajIgre;

			//namestanje labele za brojac
			lblBrojacPoena.BackColor = Color.White;
			lblBrojacPoena.ForeColor = Color.Black;
			lblBrojacPoena.BorderStyle = BorderStyle.FixedSingle;
			lblBrojacPoena.Font = new Font("Copperplate Gothic Bold", 23,FontStyle.Bold);
			lblBrojacPoena.SetBounds(0, 0, 170, 40);
			lblMaxPoena.TextAlign = ContentAlignment.MiddleLeft;
			Controls.Add(lblBrojacPoena);


			//namestanje labele za ispis najveceg ostvarenog broja poena
			lblMaxPoena.BackColor = Color.White;
			lblMaxPoena.ForeColor = Color.Black;
			lblMaxPoena.BorderStyle = BorderStyle.FixedSingle;
			lblMaxPoena.Font = new Font("Copperplate Gothic Bold", 23, FontStyle.Bold);
			lblMaxPoena.SetBounds(0, 0 + lblBrojacPoena.Height, 200, 40);
			lblMaxPoena.TextAlign = ContentAlignment.MiddleLeft;
			lblMaxPoena.Text = "Rekord: 0";
			Controls.Add(lblMaxPoena);

			//namestanje labele za kraj igre
			lblKrajIgre.BackColor = Color.White;
			lblKrajIgre.ForeColor = Color.Black;
			lblKrajIgre.BorderStyle = BorderStyle.FixedSingle;
			lblKrajIgre.Text = "KRAJ IGRE";
			lblKrajIgre.Font = new Font("Copperplate Gothic Bold", 50, FontStyle.Bold);
			lblKrajIgre.SetBounds(Width / 2 - Width / 4, Height / 3, Width / 2, Height / 9);
			lblKrajIgre.TextAlign = ContentAlignment.MiddleCenter;
			//pretvaranje labele u pbx zbog skaliranja
			bmpKrajIgre = new Bitmap(lblKrajIgre.Width, lblKrajIgre.Height);
			lblKrajIgre.DrawToBitmap(bmpKrajIgre, new Rectangle(0, 0, lblKrajIgre.Width, lblKrajIgre.Height));
			pbxKrajIgre = new PictureBox();
			pbxKrajIgre.SetBounds(Width / 2 - Width/4, Height / 3, Width/2, Height/9);
			pbxKrajIgre.BackgroundImage = bmpKrajIgre;
			pbxKrajIgre.BackgroundImageLayout = ImageLayout.Stretch;
			Controls.Add(pbxKrajIgre);

			//namestanje zemlje
			pbxZemlja.BackgroundImage = Properties.Resources.ground;
			pbxZemlja.BackgroundImageLayout = ImageLayout.Tile;
			pbxZemlja.Anchor = AnchorStyles.Bottom;
			Controls.Add(pbxZemlja);
			PocetnaPozicija();
		}
		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			pbxKrajIgre.SetBounds(Width / 2 - Width / 4, Height / 3, Width / 2, Height / 9);
			PocetnaPozicija();
		}
		private void PocetnaPozicija()
		{
			brzinaPtice = (int)Math.Round(Height /40.0);
			jacinaSkoka = (int)Math.Round(Height /40.0);
			brzinaCevi = (int)Math.Round(Width /100.0);
			ubrzanjePtice = (int)Math.Round(brzinaPtice/10.0);

			pbxKrajIgre.Visible = false;
			igraPocela = false;
			ideGore = 0;
			brzinaKaDole = 0;
			gameOver = false;
			score = 0;

			lblBrojacPoena.Text = "Poeni: 0";
			lblBrojacPoena.SetBounds(0, 0, 170, 40);

			pbxZemlja.SetBounds(0, Height - Height / 8, Width * 2, Height / 8);

			this.FormBorderStyle = FormBorderStyle.Sizable;

			var x = Width;
			var sirinaCevi = Width / 8;
			razmak = (Width - 3 * sirinaCevi) / 3;
			PostaviPticu();

			lblBrojacPoena.BringToFront();
			lblMaxPoena.BringToFront();//da bi ptica isla iza brojaca

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
		private void PostaviPticu()
		{
			int pticaX = Width / 8;
			int pticaY = Height / 2;
			//pocetna pozicija i velicina ptice
			int sirinaPtice = Width / 14;
			int duzinaPtice = Height/10;
			pbxPtica.SetBounds(pticaX, pticaY - duzinaPtice, sirinaPtice, duzinaPtice);
			pbxPtica.BackgroundImage = pocetnaPozPtice;
			pbxPtica.BackgroundImageLayout = ImageLayout.Stretch;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
            if (!gameOver)
            {
				PomeranjeZemlje();
				//Score i provera udarca
				if (pbxPtica.Right >= Cevi[indexCeviIspredPtice].GornjaCev.Left && pbxPtica.Left <= Cevi[indexCeviIspredPtice].GornjaCev.Right)
				{
					if (pbxPtica.Top <= Cevi[indexCeviIspredPtice].GornjaCev.Bottom ||
						pbxPtica.Bottom >= Cevi[indexCeviIspredPtice].DonjaCev.Top)
					{
						gameOver = true;
					}
				}
				else if (pbxPtica.Left > Cevi[indexCeviIspredPtice].GornjaCev.Right)
				{
					int prethodnaSirinaBrojaca = 25 *(score.ToString().Length - 1);
					indexCeviIspredPtice++;
					score++;
					int sirinaBrojaca =  23 * (score.ToString().Length - 1);
					if (prethodnaSirinaBrojaca < sirinaBrojaca)
					{
						lblBrojacPoena.Width += sirinaBrojaca;
						if(score>highScore)
							lblMaxPoena.Width += 23 * (score.ToString().Length - 1);
					}
					lblBrojacPoena.Text = $"Poeni: {score}";

					if (score > highScore)
					{
						highScore = score;
						lblMaxPoena.Text = $"Rekord: {highScore}";
					}
					if (indexCeviIspredPtice == Cevi.Count) indexCeviIspredPtice = 0;
				}
                if (igraPocela)
                {
					PomeranjeCevi();
					PomeranjePtice();
				}
                else
                {
					PasivnoPomeranjePtice();
                }
			}
            else
            {
				pbxKrajIgre.Visible = true;
                if (pbxPtica.Top <= ClientSize.Height)
                {
					pbxPtica.Top += brzinaKaDole;
					if (brzinaKaDole != brzinaPtice) brzinaKaDole++;
				}
            }
		}
		bool rotirajKaZemlji = true;
		private void PomeranjePtice()
        {
			if (ideGore > 0)
			{
				brzinaKaDole = 0;
				pbxPtica.Top -= ideGore;//koristim trajanje koliko dugo treba da ide gore da bi postigao blago usporavanje
				ideGore-= ubrzanjePtice;

                if (!rotirajKaZemlji)//kad se prvi put pritisne gore treba da se okrene ka gore
				{
					pbxPtica.BackgroundImage = pticaPoz315;
					rotirajKaZemlji = true;
				}
				if(ideGore <= 0)//kada krene da pada okrene se ka napred
					pbxPtica.BackgroundImage = pocetnaPozPtice;
			}
			else if (pbxPtica.Top <= ClientSize.Height - pbxZemlja.Height)
			{
				pbxPtica.Top += brzinaKaDole;
				if (brzinaKaDole < brzinaPtice) brzinaKaDole+= ubrzanjePtice;//blago raste brzinaKaDole

                else if (rotirajKaZemlji)//okrene se ka dole tek kada dodje do maksimalne brzine
                {
					pbxPtica.BackgroundImage = pticaPoz45;
					rotirajKaZemlji = false;
				}
			}
			else gameOver = true;
		}
		private void PasivnoPomeranjePtice()
        {

			if(brzinaKaDole > 0)
            {
				ideGore = brzinaPtice;
				pbxPtica.Top += ubrzanjePtice;
				brzinaKaDole -= 1;
            }
            else if(ideGore > 0)
            {
				pbxPtica.Top -= ubrzanjePtice;
				ideGore -= 1;
			}
			else brzinaKaDole = brzinaPtice;
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
		private void PomeranjeZemlje()
        {
            if (pbxZemlja.Right >= Width)
            {
				pbxZemlja.Left -= brzinaCevi;
            }
            else
            {
				pbxZemlja.Left = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
			if (e.KeyCode == Keys.Space && !gameOver && igraPocela)
			{
				rotirajKaZemlji = false;//ako se prekine kod za padanje pre stizanja maksimalne brzine
				ideGore = jacinaSkoka;//koliko dugo ce ici ka gore nakon pritiska spejsa
            }
            else if (e.KeyCode == Keys.Space && !igraPocela)
            {
				this.FormBorderStyle = FormBorderStyle.FixedSingle;
				ideGore = jacinaSkoka;
				igraPocela = true;
            }
			else if (e.KeyCode == Keys.Space && gameOver)
			{
				PocetnaPozicija();
            }
		}
    }
}