namespace PrizePlanning
{
    partial class Prizes
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.myFlowPanel1 = new PrizePlanning.MyFlowPanel();
            this.SuspendLayout();
            // 
            // myFlowPanel1
            // 
            this.myFlowPanel1.AutoScroll = true;
            this.myFlowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myFlowPanel1.Location = new System.Drawing.Point(0, 0);
            this.myFlowPanel1.Name = "myFlowPanel1";
            this.myFlowPanel1.Size = new System.Drawing.Size(1161, 748);
            this.myFlowPanel1.TabIndex = 2;
            // 
            // Prizes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.Controls.Add(this.myFlowPanel1);
            this.Name = "Prizes";
            this.Size = new System.Drawing.Size(1161, 748);
            this.ResumeLayout(false);

        }

        #endregion
        private MyFlowPanel myFlowPanel1;
    }
}
