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
			pbxPrvaCevDole=new PictureBox();
			pbxPrvaCevGore=new PictureBox();
			pbxDrugaCevDole=new PictureBox();
			pbxDrugaCevGore=new PictureBox();
			pbxTrecaCevGore=new PictureBox();
			pbxCetvrtaCevGore=new PictureBox();
			pbxTrecaCevDole=new PictureBox();
			pbxCetvrtaCevDole=new PictureBox();
			timer1=new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)pbxPtica).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbxPrvaCevDole).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbxPrvaCevGore).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbxDrugaCevDole).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbxDrugaCevGore).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbxTrecaCevGore).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbxCetvrtaCevGore).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbxTrecaCevDole).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbxCetvrtaCevDole).BeginInit();
			SuspendLayout();
			// 
			// pbxPtica
			// 
			pbxPtica.BackgroundImage=(Image)resources.GetObject("pbxPtica.BackgroundImage");
			pbxPtica.BackgroundImageLayout=ImageLayout.Zoom;
			pbxPtica.Location=new Point(82, 160);
			pbxPtica.Name="pbxPtica";
			pbxPtica.Size=new Size(115, 75);
			pbxPtica.TabIndex=0;
			pbxPtica.TabStop=false;
			pbxPtica.ClientSizeChanged+=Form1_Load;
			pbxPtica.Click+=pictureBox1_Click;
			// 
			// pbxPrvaCevDole
			// 
			pbxPrvaCevDole.Location=new Point(289, 334);
			pbxPrvaCevDole.Name="pbxPrvaCevDole";
			pbxPrvaCevDole.Size=new Size(108, 75);
			pbxPrvaCevDole.TabIndex=1;
			pbxPrvaCevDole.TabStop=false;
			// 
			// pbxPrvaCevGore
			// 
			pbxPrvaCevGore.Location=new Point(289, -7);
			pbxPrvaCevGore.Name="pbxPrvaCevGore";
			pbxPrvaCevGore.Size=new Size(108, 75);
			pbxPrvaCevGore.TabIndex=2;
			pbxPrvaCevGore.TabStop=false;
			// 
			// pbxDrugaCevDole
			// 
			pbxDrugaCevDole.Location=new Point(431, 334);
			pbxDrugaCevDole.Name="pbxDrugaCevDole";
			pbxDrugaCevDole.Size=new Size(108, 75);
			pbxDrugaCevDole.TabIndex=3;
			pbxDrugaCevDole.TabStop=false;
			// 
			// pbxDrugaCevGore
			// 
			pbxDrugaCevGore.Location=new Point(431, -7);
			pbxDrugaCevGore.Name="pbxDrugaCevGore";
			pbxDrugaCevGore.Size=new Size(108, 75);
			pbxDrugaCevGore.TabIndex=4;
			pbxDrugaCevGore.TabStop=false;
			// 
			// pbxTrecaCevGore
			// 
			pbxTrecaCevGore.Location=new Point(577, -7);
			pbxTrecaCevGore.Name="pbxTrecaCevGore";
			pbxTrecaCevGore.Size=new Size(108, 75);
			pbxTrecaCevGore.TabIndex=5;
			pbxTrecaCevGore.TabStop=false;
			// 
			// pbxCetvrtaCevGore
			// 
			pbxCetvrtaCevGore.Location=new Point(714, -7);
			pbxCetvrtaCevGore.Name="pbxCetvrtaCevGore";
			pbxCetvrtaCevGore.Size=new Size(108, 75);
			pbxCetvrtaCevGore.TabIndex=6;
			pbxCetvrtaCevGore.TabStop=false;
			pbxCetvrtaCevGore.Click+=pbxCetvrtaCevGore_Click;
			// 
			// pbxTrecaCevDole
			// 
			pbxTrecaCevDole.Location=new Point(577, 334);
			pbxTrecaCevDole.Name="pbxTrecaCevDole";
			pbxTrecaCevDole.Size=new Size(108, 75);
			pbxTrecaCevDole.TabIndex=7;
			pbxTrecaCevDole.TabStop=false;
			// 
			// pbxCetvrtaCevDole
			// 
			pbxCetvrtaCevDole.Location=new Point(714, 334);
			pbxCetvrtaCevDole.Name="pbxCetvrtaCevDole";
			pbxCetvrtaCevDole.Size=new Size(108, 75);
			pbxCetvrtaCevDole.TabIndex=8;
			pbxCetvrtaCevDole.TabStop=false;
			// 
			// timer1
			// 
			timer1.Tick+=timer1_Tick;
			// 
			// Form1
			// 
			AutoScaleDimensions=new SizeF(10F, 25F);
			AutoScaleMode=AutoScaleMode.Font;
			BackgroundImage=(Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout=ImageLayout.Stretch;
			ClientSize=new Size(790, 409);
			Controls.Add(pbxCetvrtaCevDole);
			Controls.Add(pbxTrecaCevDole);
			Controls.Add(pbxCetvrtaCevGore);
			Controls.Add(pbxTrecaCevGore);
			Controls.Add(pbxDrugaCevGore);
			Controls.Add(pbxDrugaCevDole);
			Controls.Add(pbxPrvaCevGore);
			Controls.Add(pbxPrvaCevDole);
			Controls.Add(pbxPtica);
			DoubleBuffered=true;
			Name="Form1";
			Text="Form1";
			Load+=Form1_Load;
			Paint+=Form1_Paint;
			((System.ComponentModel.ISupportInitialize)pbxPtica).EndInit();
			((System.ComponentModel.ISupportInitialize)pbxPrvaCevDole).EndInit();
			((System.ComponentModel.ISupportInitialize)pbxPrvaCevGore).EndInit();
			((System.ComponentModel.ISupportInitialize)pbxDrugaCevDole).EndInit();
			((System.ComponentModel.ISupportInitialize)pbxDrugaCevGore).EndInit();
			((System.ComponentModel.ISupportInitialize)pbxTrecaCevGore).EndInit();
			((System.ComponentModel.ISupportInitialize)pbxCetvrtaCevGore).EndInit();
			((System.ComponentModel.ISupportInitialize)pbxTrecaCevDole).EndInit();
			((System.ComponentModel.ISupportInitialize)pbxCetvrtaCevDole).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox pbxPtica;
		private PictureBox pbxPrvaCevDole;
		private PictureBox pbxPrvaCevGore;
		private PictureBox pbxDrugaCevDole;
		private PictureBox pbxDrugaCevGore;
		private PictureBox pbxTrecaCevGore;
		private PictureBox pbxCetvrtaCevGore;
		private PictureBox pbxTrecaCevDole;
		private PictureBox pbxCetvrtaCevDole;
		private System.Windows.Forms.Timer timer1;
	}
}