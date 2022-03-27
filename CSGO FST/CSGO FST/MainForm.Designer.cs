namespace CSGOFST
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chk_flash = new System.Windows.Forms.CheckBox();
            this.btn_dump = new System.Windows.Forms.Button();
            this.chk_mvplogger = new System.Windows.Forms.CheckBox();
            this.chk_reloadflash = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chk_flash
            // 
            this.chk_flash.AutoSize = true;
            this.chk_flash.Location = new System.Drawing.Point(12, 12);
            this.chk_flash.Name = "chk_flash";
            this.chk_flash.Size = new System.Drawing.Size(154, 17);
            this.chk_flash.TabIndex = 2;
            this.chk_flash.Text = "Kill Sounds (While Flashed)";
            this.chk_flash.UseVisualStyleBackColor = true;
            // 
            // btn_dump
            // 
            this.btn_dump.Location = new System.Drawing.Point(12, 82);
            this.btn_dump.Name = "btn_dump";
            this.btn_dump.Size = new System.Drawing.Size(320, 23);
            this.btn_dump.TabIndex = 4;
            this.btn_dump.Text = "Dump GS";
            this.btn_dump.UseVisualStyleBackColor = true;
            this.btn_dump.Click += new System.EventHandler(this.btn_dump_Click);
            // 
            // chk_mvplogger
            // 
            this.chk_mvplogger.AutoSize = true;
            this.chk_mvplogger.Location = new System.Drawing.Point(12, 36);
            this.chk_mvplogger.Name = "chk_mvplogger";
            this.chk_mvplogger.Size = new System.Drawing.Size(85, 17);
            this.chk_mvplogger.TabIndex = 5;
            this.chk_mvplogger.Text = "MVP Logger";
            this.chk_mvplogger.UseVisualStyleBackColor = true;
            // 
            // chk_reloadflash
            // 
            this.chk_reloadflash.AutoSize = true;
            this.chk_reloadflash.Location = new System.Drawing.Point(12, 59);
            this.chk_reloadflash.Name = "chk_reloadflash";
            this.chk_reloadflash.Size = new System.Drawing.Size(134, 17);
            this.chk_reloadflash.TabIndex = 6;
            this.chk_reloadflash.Text = "Reload Flash Message";
            this.chk_reloadflash.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(344, 113);
            this.Controls.Add(this.chk_reloadflash);
            this.Controls.Add(this.chk_mvplogger);
            this.Controls.Add(this.btn_dump);
            this.Controls.Add(this.chk_flash);
            this.ForeColor = System.Drawing.Color.LawnGreen;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CSGO FST";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chk_flash;
        private System.Windows.Forms.Button btn_dump;
        private System.Windows.Forms.CheckBox chk_mvplogger;
        private System.Windows.Forms.CheckBox chk_reloadflash;
    }
}

