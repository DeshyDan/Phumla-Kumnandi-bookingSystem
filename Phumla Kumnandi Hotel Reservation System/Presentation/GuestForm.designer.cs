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
            this.guestSelectionLabel = new System.Windows.Forms.Label();
            this.Filter = new System.Windows.Forms.Button();
            this.guestListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.White;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.searchBox.Location = new System.Drawing.Point(561, 75);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(349, 46);
            this.searchBox.TabIndex = 2;
            this.searchBox.Text = "Search by id";
            this.searchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // guestSelectionLabel
            // 
            this.guestSelectionLabel.AutoSize = true;
            this.guestSelectionLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestSelectionLabel.Location = new System.Drawing.Point(21, 131);
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
            // 
            // guestListView
            // 
            this.guestListView.HideSelection = false;
            this.guestListView.Location = new System.Drawing.Point(27, 213);
            this.guestListView.Name = "guestListView";
            this.guestListView.Size = new System.Drawing.Size(1130, 635);
            this.guestListView.TabIndex = 6;
            this.guestListView.UseCompatibleStateImageBehavior = false;
            this.guestListView.SelectedIndexChanged += new System.EventHandler(this.guestListView_SelectedIndexChanged_1);
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1202, 860);
            this.Controls.Add(this.guestListView);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.guestSelectionLabel);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GuestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.GuestForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GuestForm_FormClosed);
            this.Load += new System.EventHandler(this.Guest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label guestSelectionLabel;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.ListView guestListView;
    }
}

