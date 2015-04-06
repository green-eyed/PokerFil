namespace TestForm
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPwin = new System.Windows.Forms.Label();
            this.lblPsplit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPlayersCard = new System.Windows.Forms.TextBox();
            this.tbxCommonCards = new System.Windows.Forms.TextBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(31, 80);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 2;
            this.btnCalc.Text = "Calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "P win";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "P split";
            // 
            // lblPwin
            // 
            this.lblPwin.AutoSize = true;
            this.lblPwin.Location = new System.Drawing.Point(71, 119);
            this.lblPwin.Name = "lblPwin";
            this.lblPwin.Size = new System.Drawing.Size(35, 13);
            this.lblPwin.TabIndex = 5;
            this.lblPwin.Text = "label3";
            // 
            // lblPsplit
            // 
            this.lblPsplit.AutoSize = true;
            this.lblPsplit.Location = new System.Drawing.Point(71, 145);
            this.lblPsplit.Name = "lblPsplit";
            this.lblPsplit.Size = new System.Drawing.Size(35, 13);
            this.lblPsplit.TabIndex = 6;
            this.lblPsplit.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Player Cards";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Common Cards";
            // 
            // tbxPlayersCard
            // 
            this.tbxPlayersCard.Location = new System.Drawing.Point(110, 6);
            this.tbxPlayersCard.Name = "tbxPlayersCard";
            this.tbxPlayersCard.Size = new System.Drawing.Size(162, 20);
            this.tbxPlayersCard.TabIndex = 0;
            this.tbxPlayersCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPlayersCard_KeyDown);
            // 
            // tbxCommonCards
            // 
            this.tbxCommonCards.Location = new System.Drawing.Point(110, 39);
            this.tbxCommonCards.Name = "tbxCommonCards";
            this.tbxCommonCards.Size = new System.Drawing.Size(162, 20);
            this.tbxCommonCards.TabIndex = 1;
            this.tbxCommonCards.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCommonCards_KeyDown);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(172, 80);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.tbxCommonCards);
            this.Controls.Add(this.tbxPlayersCard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPsplit);
            this.Controls.Add(this.lblPwin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPwin;
        private System.Windows.Forms.Label lblPsplit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPlayersCard;
        private System.Windows.Forms.TextBox tbxCommonCards;
        private System.Windows.Forms.Button btnClean;
    }
}

