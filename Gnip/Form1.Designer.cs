namespace Gnip
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.label_ping = new System.Windows.Forms.Label();
            this.label_bajo = new System.Windows.Forms.Label();
            this.label_medio = new System.Windows.Forms.Label();
            this.label_alto = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_showHideHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerPing
            // 
            this.timerPing.Enabled = true;
            this.timerPing.Interval = 800;
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick);
            // 
            // label_ping
            // 
            this.label_ping.AutoSize = true;
            this.label_ping.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ping.Location = new System.Drawing.Point(12, 9);
            this.label_ping.Name = "label_ping";
            this.label_ping.Size = new System.Drawing.Size(94, 24);
            this.label_ping.TabIndex = 0;
            this.label_ping.Text = "xxxx ms";
            // 
            // label_bajo
            // 
            this.label_bajo.AutoSize = true;
            this.label_bajo.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bajo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_bajo.Location = new System.Drawing.Point(12, 44);
            this.label_bajo.Name = "label_bajo";
            this.label_bajo.Size = new System.Drawing.Size(94, 24);
            this.label_bajo.TabIndex = 1;
            this.label_bajo.Text = "xxxx ms";
            // 
            // label_medio
            // 
            this.label_medio.AutoSize = true;
            this.label_medio.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_medio.ForeColor = System.Drawing.Color.Fuchsia;
            this.label_medio.Location = new System.Drawing.Point(12, 68);
            this.label_medio.Name = "label_medio";
            this.label_medio.Size = new System.Drawing.Size(94, 24);
            this.label_medio.TabIndex = 2;
            this.label_medio.Text = "xxxx ms";
            // 
            // label_alto
            // 
            this.label_alto.AutoSize = true;
            this.label_alto.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_alto.ForeColor = System.Drawing.Color.Red;
            this.label_alto.Location = new System.Drawing.Point(12, 92);
            this.label_alto.Name = "label_alto";
            this.label_alto.Size = new System.Drawing.Size(94, 24);
            this.label_alto.TabIndex = 3;
            this.label_alto.Text = "xxxx ms";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(122, 9);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(335, 130);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Hora";
            this.columnHeader1.Width = 148;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tipo";
            this.columnHeader2.Width = 77;
            // 
            // button_showHideHistory
            // 
            this.button_showHideHistory.Location = new System.Drawing.Point(70, 119);
            this.button_showHideHistory.Name = "button_showHideHistory";
            this.button_showHideHistory.Size = new System.Drawing.Size(34, 20);
            this.button_showHideHistory.TabIndex = 5;
            this.button_showHideHistory.Text = "--->";
            this.button_showHideHistory.UseVisualStyleBackColor = true;
            this.button_showHideHistory.Click += new System.EventHandler(this.button_showHideHistory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(117, 148);
            this.Controls.Add(this.button_showHideHistory);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label_alto);
            this.Controls.Add(this.label_medio);
            this.Controls.Add(this.label_bajo);
            this.Controls.Add(this.label_ping);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Gnip";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.Label label_ping;
        private System.Windows.Forms.Label label_bajo;
        private System.Windows.Forms.Label label_medio;
        private System.Windows.Forms.Label label_alto;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button_showHideHistory;
    }
}

