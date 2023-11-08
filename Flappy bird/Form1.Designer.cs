namespace Flappy_bird
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if ( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components=new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			pbxPtica=new PictureBox();
			timer1=new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)pbxPtica).BeginInit();
			SuspendLayout();
			// 
			// pbxPtica
			// 
			pbxPtica.BackColor=Color.Transparent;
			pbxPtica.BackgroundImage=(Image)resources.GetObject("pbxPtica.BackgroundImage");
			pbxPtica.BackgroundImageLayout=ImageLayout.Zoom;
			pbxPtica.Location=new Point(82, 160);
			pbxPtica.Name="pbxPtica";
			pbxPtica.Size=new Size(115, 75);
			pbxPtica.TabIndex=0;
			pbxPtica.TabStop=false;
			pbxPtica.Click+=pictureBox1_Click;
			// 
			// timer1
			// 
			timer1.Interval=16;
			timer1.Tick+=timer1_Tick;
			// 
			// Form1
			// 
			AutoScaleDimensions=new SizeF(10F, 25F);
			AutoScaleMode=AutoScaleMode.Font;
			BackgroundImage=(Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout=ImageLayout.Stretch;
			ClientSize=new Size(1178, 694);
			Controls.Add(pbxPtica);
			DoubleBuffered=true;
			FormBorderStyle=FormBorderStyle.FixedSingle;
			MaximizeBox=false;
			Name="Form1";
			Text="Form1";
			Load+=Form1_Load;
			((System.ComponentModel.ISupportInitialize)pbxPtica).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox pbxPtica;
		private System.Windows.Forms.Timer timer1;
	}
}