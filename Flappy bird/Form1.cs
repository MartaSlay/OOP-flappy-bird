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
		public static int razmak;
		public static List<Cev> Cevi = new List<Cev>();

		Label lblBrojacPoena=new Label(),lblMaxPoena=new Label(),lblKrajIgre = new Label();
		Bitmap pocetnaPozPtice;
		Bitmap pticaPoz45 = new Bitmap(Properties.Resources.pbxPtica_BackgroundImage45);
		PictureBox pbxZemlja = new PictureBox();

		int brzinaPtice = 20;
		int jacinaSkoka = 20;
		int brzinaCevi = 12;

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
			//namestanje labele za brojac
			lblBrojacPoena.BackColor = Color.White;
			lblBrojacPoena.ForeColor = Color.Black;
			lblBrojacPoena.BorderStyle = BorderStyle.Fixed3D;
			lblBrojacPoena.Font = new Font("Arial",25,FontStyle.Bold);
			Controls.Add(lblBrojacPoena);

			//namestanje labele za kraj igre
			lblKrajIgre.BackColor = Color.White;
			lblKrajIgre.ForeColor = Color.Black;
			lblKrajIgre.BorderStyle = BorderStyle.FixedSingle;
			lblKrajIgre.Text = "KRAJ IGRE";
			lblKrajIgre.Font = new Font("Copperplate Gothic Bold", 50, FontStyle.Bold);
			lblKrajIgre.SetBounds(Width / 2- 250, Height / 3, 500, 100);
			lblKrajIgre.TextAlign = ContentAlignment.MiddleCenter;
			Controls.Add(lblKrajIgre);

			//namestanje labele za ispis najveceg ostvarenog broja poena
			lblMaxPoena.BackColor = Color.White;
			lblMaxPoena.ForeColor = Color.Black;
			lblMaxPoena.BorderStyle = BorderStyle.FixedSingle;
			lblMaxPoena.Font = new Font("Copperplate Gothic Bold", 25, FontStyle.Bold);
			lblMaxPoena.SetBounds(Width / 2 - 200, Height / 3+110, 350, 60);
			lblMaxPoena.TextAlign = ContentAlignment.MiddleCenter;
			Controls.Add(lblMaxPoena);

			//namestanje pbx
			pbxZemlja.BackgroundImage = Properties.Resources.ground;
			pbxZemlja.BackgroundImageLayout = ImageLayout.Tile;
			pbxZemlja.SetBounds(0, 700, Width * 2, 100);
			Controls.Add(pbxZemlja);

			PocetnaPozicija();
		}
		private void PocetnaPozicija()
		{
			lblMaxPoena.Visible = false;
			lblKrajIgre.Visible = false;
			igraPocela = false;
			ideGore = 0;
			brzinaKaDole = 0;
			gameOver = false;
			score = 0;

			lblBrojacPoena.Text = "0";
			lblBrojacPoena.SetBounds(Width/2-20, Height/10, 50, 40);

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
				PomeranjeZemlje();
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
					int prethodnaSirinaBrojaca = 23 *(score.ToString().Length - 1);
					indexCeviIspredPtice++;
					score++;
					if (score > highScore) highScore = score;
					lblBrojacPoena.Text = score.ToString();
					int sirinaBrojaca =  23 * (lblBrojacPoena.Text.Length-1);
					if (prethodnaSirinaBrojaca < sirinaBrojaca)
					{
						lblBrojacPoena.SetBounds(Width / 2 - sirinaBrojaca/2, Height / 10, 50 + sirinaBrojaca, 40);
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
				lblKrajIgre.Visible = true;
				lblMaxPoena.Text = $"Rekord: {highScore}";
				lblMaxPoena.Width = 350 + lblBrojacPoena.Width;
				lblMaxPoena.Visible = true;
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
				ideGore-=2;
                if (!rotirajKaZemlji)//kad se prvi put pritisne gore treba da se okrene ka gore
				{
					pticaPoz45.RotateFlip(RotateFlipType.Rotate270FlipNone);
					pbxPtica.BackgroundImage = new Bitmap(pticaPoz45);
					pticaPoz45.RotateFlip(RotateFlipType.Rotate90FlipNone);
					rotirajKaZemlji = true;
				}
				if(ideGore <= 0)//kada krene da pada okrene se ka napred
					pbxPtica.BackgroundImage = new Bitmap(pocetnaPozPtice);
			}
			else if (pbxPtica.Top <= ClientSize.Height - pbxZemlja.Height)
			{
				pbxPtica.Top += brzinaKaDole;
				if (brzinaKaDole < brzinaPtice) brzinaKaDole+=2;//blago brzinaKaDole
                else if (rotirajKaZemlji)//okrene se ka dole tek kada dodje do maksimalne brzine
                {
					pbxPtica.BackgroundImage = new Bitmap(pticaPoz45);
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
				pbxPtica.Top += 1;
				brzinaKaDole -= 1;
            }
            else if(ideGore > 0)
            {
				pbxPtica.Top -= 1;
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
		private void PostaviPticu()
		{
			int pticaX = Width / 8;
			int pticaY = Height / 2;
			//pocetna pozicija i velicina ptice
			int sirinaPtice = Width /14;
			int duzinaPtice = sirinaPtice - sirinaPtice/10;
			pbxPtica.SetBounds(pticaX, pticaY-duzinaPtice, sirinaPtice, duzinaPtice); 
			pbxPtica.BackgroundImage = new Bitmap(pocetnaPozPtice);
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
				igraPocela = true;
            }
			else if (e.KeyCode == Keys.Space)
            {
				PocetnaPozicija();
            }
		}
    }
}