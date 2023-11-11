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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbxPtica = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPtica)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxPtica
            // 
            this.pbxPtica.BackColor = System.Drawing.Color.Transparent;
            this.pbxPtica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxPtica.BackgroundImage")));
            this.pbxPtica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxPtica.Location = new System.Drawing.Point(153, 133);
            this.pbxPtica.Margin = new System.Windows.Forms.Padding(2);
            this.pbxPtica.Name = "pbxPtica";
            this.pbxPtica.Size = new System.Drawing.Size(67, 45);
            this.pbxPtica.TabIndex = 0;
            this.pbxPtica.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 416);
            this.Controls.Add(this.pbxPtica);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPtica)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private PictureBox pbxPtica;
		private System.Windows.Forms.Timer timer1;
	}
}