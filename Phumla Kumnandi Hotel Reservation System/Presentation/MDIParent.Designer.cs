namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    partial class MDIParent
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.guestNavLabel = new System.Windows.Forms.Label();
            this.bookingNavLabel = new System.Windows.Forms.Label();
            this.homeNavLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.guestNavLabel);
            this.panel1.Controls.Add(this.bookingNavLabel);
            this.panel1.Controls.Add(this.homeNavLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 898);
            this.panel1.TabIndex = 3;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(137)))), ((int)(((byte)(165)))));
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.ForeColor = System.Drawing.Color.White;
            this.logoutButton.Location = new System.Drawing.Point(63, 806);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(236, 54);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // guestNavLabel
            // 
            this.guestNavLabel.AutoSize = true;
            this.guestNavLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNavLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.guestNavLabel.Location = new System.Drawing.Point(117, 345);
            this.guestNavLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.guestNavLabel.Name = "guestNavLabel";
            this.guestNavLabel.Size = new System.Drawing.Size(173, 53);
            this.guestNavLabel.TabIndex = 0;
            this.guestNavLabel.Text = "Guests";
            this.guestNavLabel.Click += new System.EventHandler(this.guestNavLabel_Click);
            // 
            // bookingNavLabel
            // 
            this.bookingNavLabel.AutoSize = true;
            this.bookingNavLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingNavLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.bookingNavLabel.Location = new System.Drawing.Point(117, 250);
            this.bookingNavLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookingNavLabel.Name = "bookingNavLabel";
            this.bookingNavLabel.Size = new System.Drawing.Size(215, 53);
            this.bookingNavLabel.TabIndex = 0;
            this.bookingNavLabel.Text = "Bookings";
            this.bookingNavLabel.Click += new System.EventHandler(this.bookingNavLabel_Click);
            // 
            // homeNavLabel
            // 
            this.homeNavLabel.AutoSize = true;
            this.homeNavLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeNavLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.homeNavLabel.Location = new System.Drawing.Point(117, 159);
            this.homeNavLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.homeNavLabel.Name = "homeNavLabel";
            this.homeNavLabel.Size = new System.Drawing.Size(154, 55);
            this.homeNavLabel.TabIndex = 0;
            this.homeNavLabel.Text = "Home";
            this.homeNavLabel.Click += new System.EventHandler(this.homeNavLabel_Click);
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1608, 895);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.Name = "MDIParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDIParent";
            this.Load += new System.EventHandler(this.MDIParent_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label guestNavLabel;
        private System.Windows.Forms.Label bookingNavLabel;
        private System.Windows.Forms.Label homeNavLabel;
    }
}