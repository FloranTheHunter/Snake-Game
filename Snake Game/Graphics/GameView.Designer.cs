namespace Snake_Game
{
    partial class GameView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadMap
            // 
            this.LoadMap.AutoSize = true;
            this.LoadMap.BackColor = System.Drawing.Color.White;
            this.LoadMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoadMap.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LoadMap.FlatAppearance.BorderSize = 0;
            this.LoadMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LoadMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LoadMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadMap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoadMap.Location = new System.Drawing.Point(0, 474);
            this.LoadMap.Name = "LoadMap";
            this.LoadMap.Size = new System.Drawing.Size(1067, 80);
            this.LoadMap.TabIndex = 0;
            this.LoadMap.Text = "Load Level";
            this.LoadMap.UseVisualStyleBackColor = false;
            this.LoadMap.Click += new System.EventHandler(this.LoadMap_Click);
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.LoadMap);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GameView";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameView_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadMap;
    }
}

