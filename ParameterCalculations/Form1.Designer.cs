namespace ParameterCalculations
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.l1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.myDGV = new System.Windows.Forms.DataGridView();
            this.r77 = new System.Windows.Forms.RadioButton();
            this.r4 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.saveList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(775, 88);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(233, 280);
            this.richTextBox1.TabIndex = 24;
            this.richTextBox1.Text = "";
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Location = new System.Drawing.Point(772, 55);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(142, 15);
            this.l1.TabIndex = 23;
            this.l1.Text = "参数计算结果如下：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "新坐标";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "旧坐标";
            // 
            // myDGV
            // 
            this.myDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.myDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.myDGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.myDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.myDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDGV.Location = new System.Drawing.Point(12, 88);
            this.myDGV.Name = "myDGV";
            this.myDGV.RowTemplate.Height = 27;
            this.myDGV.Size = new System.Drawing.Size(699, 251);
            this.myDGV.TabIndex = 20;
            this.myDGV.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.myDGV_UserAddedRow_1);
            // 
            // r77
            // 
            this.r77.AutoSize = true;
            this.r77.Location = new System.Drawing.Point(12, 55);
            this.r77.Name = "r77";
            this.r77.Size = new System.Drawing.Size(103, 19);
            this.r77.TabIndex = 19;
            this.r77.TabStop = true;
            this.r77.Text = "三维七参数";
            this.r77.UseVisualStyleBackColor = true;
            this.r77.CheckedChanged += new System.EventHandler(this.r77_CheckedChanged_1);
            // 
            // r4
            // 
            this.r4.AutoSize = true;
            this.r4.Location = new System.Drawing.Point(12, 12);
            this.r4.Name = "r4";
            this.r4.Size = new System.Drawing.Size(103, 19);
            this.r4.TabIndex = 18;
            this.r4.TabStop = true;
            this.r4.Text = "二维四参数";
            this.r4.UseVisualStyleBackColor = true;
            this.r4.CheckedChanged += new System.EventHandler(this.r4_CheckedChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 48);
            this.button1.TabIndex = 17;
            this.button1.Text = "求转换参数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveList
            // 
            this.saveList.Location = new System.Drawing.Point(173, 364);
            this.saveList.Name = "saveList";
            this.saveList.Size = new System.Drawing.Size(97, 48);
            this.saveList.TabIndex = 25;
            this.saveList.Text = "保存参数";
            this.saveList.UseVisualStyleBackColor = true;
            this.saveList.Click += new System.EventHandler(this.saveList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 562);
            this.Controls.Add(this.saveList);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myDGV);
            this.Controls.Add(this.r77);
            this.Controls.Add(this.r4);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.myDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveList;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView myDGV;
        private System.Windows.Forms.RadioButton r77;
        private System.Windows.Forms.RadioButton r4;
        private System.Windows.Forms.Button button1;
    }
}

