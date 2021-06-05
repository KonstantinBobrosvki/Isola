
namespace WindowsFormsApp1
{
    partial class WinnerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelWinnerName = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(241, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Победител е ";
            // 
            // labelWinnerName
            // 
            this.labelWinnerName.AutoSize = true;
            this.labelWinnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinnerName.Location = new System.Drawing.Point(487, 131);
            this.labelWinnerName.Name = "labelWinnerName";
            this.labelWinnerName.Size = new System.Drawing.Size(0, 39);
            this.labelWinnerName.TabIndex = 1;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackColor = System.Drawing.Color.LightYellow;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGame.Location = new System.Drawing.Point(74, 268);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(221, 57);
            this.buttonNewGame.TabIndex = 2;
            this.buttonNewGame.Text = "Нова игра";
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Pink;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(532, 268);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(262, 57);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Приключи играта";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // WinnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(944, 357);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.labelWinnerName);
            this.Controls.Add(this.label1);
            this.Name = "WinnerForm";
            this.Text = "Победител";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelWinnerName;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonClose;
    }
}

