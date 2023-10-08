namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    partial class GuestForm
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guestSelectionLabel = new System.Windows.Forms.Label();
            this.Filter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.White;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.searchBox.Location = new System.Drawing.Point(561, 75);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(349, 46);
            this.searchBox.TabIndex = 2;
            this.searchBox.Text = "Search by id";
            this.searchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(60, 208);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 601);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // guestSelectionLabel
            // 
            this.guestSelectionLabel.AutoSize = true;
            this.guestSelectionLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestSelectionLabel.Location = new System.Drawing.Point(54, 136);
            this.guestSelectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.guestSelectionLabel.Name = "guestSelectionLabel";
            this.guestSelectionLabel.Size = new System.Drawing.Size(161, 35);
            this.guestSelectionLabel.TabIndex = 4;
            this.guestSelectionLabel.Text = "All Rooms";
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(987, 75);
            this.Filter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(170, 43);
            this.Filter.TabIndex = 5;
            this.Filter.Text = "Filter";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1202, 860);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.guestSelectionLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GuestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GuestForm_FormClosed);
            this.Load += new System.EventHandler(this.Guest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label guestSelectionLabel;
        private System.Windows.Forms.Button Filter;
    }
}

