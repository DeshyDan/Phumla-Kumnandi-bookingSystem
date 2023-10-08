﻿namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    partial class BookingsForm
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
            this.promotionNavLabel = new System.Windows.Forms.Label();
            this.roomNavLabel = new System.Windows.Forms.Label();
            this.guestNavLabel = new System.Windows.Forms.Label();
            this.bookingNavLabel = new System.Windows.Forms.Label();
            this.homeNavLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.Filter = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.promotionNavLabel);
            this.panel1.Controls.Add(this.roomNavLabel);
            this.panel1.Controls.Add(this.guestNavLabel);
            this.panel1.Controls.Add(this.bookingNavLabel);
            this.panel1.Controls.Add(this.homeNavLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 1123);
            this.panel1.TabIndex = 1;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(137)))), ((int)(((byte)(165)))));
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.ForeColor = System.Drawing.Color.White;
            this.logoutButton.Location = new System.Drawing.Point(70, 1008);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(266, 68);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            // 
            // promotionNavLabel
            // 
            this.promotionNavLabel.AutoSize = true;
            this.promotionNavLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promotionNavLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.promotionNavLabel.Location = new System.Drawing.Point(130, 672);
            this.promotionNavLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.promotionNavLabel.Name = "promotionNavLabel";
            this.promotionNavLabel.Size = new System.Drawing.Size(312, 65);
            this.promotionNavLabel.TabIndex = 0;
            this.promotionNavLabel.Text = "Promotions";
            // 
            // roomNavLabel
            // 
            this.roomNavLabel.AutoSize = true;
            this.roomNavLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNavLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.roomNavLabel.Location = new System.Drawing.Point(132, 555);
            this.roomNavLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roomNavLabel.Name = "roomNavLabel";
            this.roomNavLabel.Size = new System.Drawing.Size(205, 65);
            this.roomNavLabel.TabIndex = 0;
            this.roomNavLabel.Text = "Rooms";
            // 
            // guestNavLabel
            // 
            this.guestNavLabel.AutoSize = true;
            this.guestNavLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNavLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.guestNavLabel.Location = new System.Drawing.Point(132, 431);
            this.guestNavLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.guestNavLabel.Name = "guestNavLabel";
            this.guestNavLabel.Size = new System.Drawing.Size(206, 65);
            this.guestNavLabel.TabIndex = 0;
            this.guestNavLabel.Text = "Guests";
            // 
            // bookingNavLabel
            // 
            this.bookingNavLabel.AutoSize = true;
            this.bookingNavLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingNavLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.bookingNavLabel.Location = new System.Drawing.Point(132, 312);
            this.bookingNavLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookingNavLabel.Name = "bookingNavLabel";
            this.bookingNavLabel.Size = new System.Drawing.Size(282, 65);
            this.bookingNavLabel.TabIndex = 0;
            this.bookingNavLabel.Text = "Bookings";
            this.bookingNavLabel.Click += new System.EventHandler(this.bookingNavLabel_Click);
            // 
            // homeNavLabel
            // 
            this.homeNavLabel.AutoSize = true;
            this.homeNavLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeNavLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.homeNavLabel.Location = new System.Drawing.Point(132, 198);
            this.homeNavLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.homeNavLabel.Name = "homeNavLabel";
            this.homeNavLabel.Size = new System.Drawing.Size(177, 65);
            this.homeNavLabel.TabIndex = 0;
            this.homeNavLabel.Text = "Home";
            this.homeNavLabel.Click += new System.EventHandler(this.homeNavLabel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(507, 312);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1234, 752);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.White;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.searchBox.Location = new System.Drawing.Point(1016, 89);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(392, 54);
            this.searchBox.TabIndex = 11;
            this.searchBox.Text = "Search by Id";
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(1464, 89);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(249, 58);
            this.Filter.TabIndex = 13;
            this.Filter.Text = "Filter";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // BookingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1776, 1050);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BookingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookingsForm";
            this.Load += new System.EventHandler(this.BookingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label promotionNavLabel;
        private System.Windows.Forms.Label roomNavLabel;
        private System.Windows.Forms.Label guestNavLabel;
        private System.Windows.Forms.Label bookingNavLabel;
        private System.Windows.Forms.Label homeNavLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button Filter;
    }
}