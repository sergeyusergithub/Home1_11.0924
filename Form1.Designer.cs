namespace Home1
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
            this.cmbMechanics = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picBoxAvatar = new System.Windows.Forms.PictureBox();
            this.btnAddMechanic = new System.Windows.Forms.Button();
            this.btnDeleteMechanic = new System.Windows.Forms.Button();
            this.tbNameMechanic = new System.Windows.Forms.TextBox();
            this.lstTmp = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMechanics
            // 
            this.cmbMechanics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbMechanics.FormattingEnabled = true;
            this.cmbMechanics.Location = new System.Drawing.Point(12, 49);
            this.cmbMechanics.Name = "cmbMechanics";
            this.cmbMechanics.Size = new System.Drawing.Size(192, 28);
            this.cmbMechanics.TabIndex = 0;
            this.cmbMechanics.SelectedValueChanged += new System.EventHandler(this.cmbMechanics_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя механика";
            // 
            // picBoxAvatar
            // 
            this.picBoxAvatar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picBoxAvatar.Location = new System.Drawing.Point(222, 49);
            this.picBoxAvatar.MaximumSize = new System.Drawing.Size(200, 150);
            this.picBoxAvatar.MinimumSize = new System.Drawing.Size(50, 50);
            this.picBoxAvatar.Name = "picBoxAvatar";
            this.picBoxAvatar.Size = new System.Drawing.Size(150, 150);
            this.picBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBoxAvatar.TabIndex = 2;
            this.picBoxAvatar.TabStop = false;
            this.picBoxAvatar.Click += new System.EventHandler(this.picBoxAvatar_Click);
            // 
            // btnAddMechanic
            // 
            this.btnAddMechanic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddMechanic.Location = new System.Drawing.Point(410, 95);
            this.btnAddMechanic.Name = "btnAddMechanic";
            this.btnAddMechanic.Size = new System.Drawing.Size(186, 33);
            this.btnAddMechanic.TabIndex = 3;
            this.btnAddMechanic.Text = "Добавить механика";
            this.btnAddMechanic.UseVisualStyleBackColor = true;
            this.btnAddMechanic.Click += new System.EventHandler(this.btnAddMechanic_Click);
            // 
            // btnDeleteMechanic
            // 
            this.btnDeleteMechanic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteMechanic.Location = new System.Drawing.Point(410, 156);
            this.btnDeleteMechanic.Name = "btnDeleteMechanic";
            this.btnDeleteMechanic.Size = new System.Drawing.Size(186, 32);
            this.btnDeleteMechanic.TabIndex = 4;
            this.btnDeleteMechanic.Text = "Удалить механика";
            this.btnDeleteMechanic.UseVisualStyleBackColor = true;
            // 
            // tbNameMechanic
            // 
            this.tbNameMechanic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNameMechanic.Location = new System.Drawing.Point(410, 49);
            this.tbNameMechanic.Name = "tbNameMechanic";
            this.tbNameMechanic.Size = new System.Drawing.Size(182, 26);
            this.tbNameMechanic.TabIndex = 5;
            // 
            // lstTmp
            // 
            this.lstTmp.FormattingEnabled = true;
            this.lstTmp.Location = new System.Drawing.Point(12, 116);
            this.lstTmp.Name = "lstTmp";
            this.lstTmp.Size = new System.Drawing.Size(120, 95);
            this.lstTmp.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 356);
            this.Controls.Add(this.lstTmp);
            this.Controls.Add(this.tbNameMechanic);
            this.Controls.Add(this.btnDeleteMechanic);
            this.Controls.Add(this.btnAddMechanic);
            this.Controls.Add(this.picBoxAvatar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMechanics);
            this.Name = "Form1";
            this.Text = "Автосервис";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMechanics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBoxAvatar;
        private System.Windows.Forms.Button btnAddMechanic;
        private System.Windows.Forms.Button btnDeleteMechanic;
        private System.Windows.Forms.TextBox tbNameMechanic;
        private System.Windows.Forms.ListBox lstTmp;
    }
}

