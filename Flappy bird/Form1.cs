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
		public static double sirinaCevi;
		public static double duzinaGornjeCevi;
		public static double duzinaDonjeCevi;
		public static int sirinaPtice;
		public static int duzinaPtice;
		public static int cevX;
		public static int cevY;

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void pbxCetvrtaCevGore_Click(object sender, EventArgs e)
		{

		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			int visinaForm = this.Height;
			int sirinaForm = this.Width;
			var random = new Random();
			sirinaCevi = sirinaForm/10;
			//generisanje pozicije cevi
			duzinaDonjeCevi = random.Next(visinaForm/10, visinaForm - visinaForm/10);
			duzinaGornjeCevi = visinaForm-duzinaGornjeCevi-(visinaForm/10);
			//pozicija i velicina ptice
			sirinaPtice = sirinaForm/12;
			duzinaPtice = sirinaPtice - sirinaPtice/10;
			int xPtice = sirinaForm/10;
			int yPtice = visinaForm/2 - duzinaPtice;
			pbxPtica.SetBounds(xPtice, yPtice, sirinaPtice, duzinaPtice);
			pbxPtica.Size = new System.Drawing.Size(duzinaPtice,sirinaPtice);
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
            /*if ( )
			{
				autoX = autoX + 3;
			}*/
		}
		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
		public int ideGore = 0;
		private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
				ideGore = 10;
            }
        }
    }
}