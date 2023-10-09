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
            this.guestListView = new System.Windows.Forms.ListView();
            this.dataLanel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guestListView
            // 
            this.guestListView.HideSelection = false;
            this.guestListView.Location = new System.Drawing.Point(27, 128);
            this.guestListView.Name = "guestListView";
            this.guestListView.Size = new System.Drawing.Size(1130, 635);
            this.guestListView.TabIndex = 6;
            this.guestListView.UseCompatibleStateImageBehavior = false;
            this.guestListView.SelectedIndexChanged += new System.EventHandler(this.guestListView_SelectedIndexChanged_1);
            // 
            // dataLanel
            // 
            this.dataLanel.AutoSize = true;
            this.dataLanel.BackColor = System.Drawing.Color.Transparent;
            this.dataLanel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLanel.ForeColor = System.Drawing.Color.Black;
            this.dataLanel.Location = new System.Drawing.Point(17, 46);
            this.dataLanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataLanel.Name = "dataLanel";
            this.dataLanel.Size = new System.Drawing.Size(184, 55);
            this.dataLanel.TabIndex = 7;
            this.dataLanel.Text = "Guests";
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1202, 860);
            this.Controls.Add(this.dataLanel);
            this.Controls.Add(this.guestListView);
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
        private System.Windows.Forms.ListView guestListView;
        private System.Windows.Forms.Label dataLanel;
    }
}

