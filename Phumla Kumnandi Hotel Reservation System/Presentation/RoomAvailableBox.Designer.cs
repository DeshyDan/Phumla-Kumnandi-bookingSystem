namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    partial class RoomAvailableBox
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.createBookingButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bookingPriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(137)))), ((int)(((byte)(165)))));
            this.cancelButton.FlatAppearance.BorderSize = 2;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(120, 257);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(236, 54);
            this.cancelButton.TabIndex = 33;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createBookingButton
            // 
            this.createBookingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(137)))), ((int)(((byte)(165)))));
            this.createBookingButton.FlatAppearance.BorderSize = 0;
            this.createBookingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createBookingButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBookingButton.ForeColor = System.Drawing.Color.White;
            this.createBookingButton.Location = new System.Drawing.Point(89, 195);
            this.createBookingButton.Margin = new System.Windows.Forms.Padding(4);
            this.createBookingButton.Name = "createBookingButton";
            this.createBookingButton.Size = new System.Drawing.Size(310, 54);
            this.createBookingButton.TabIndex = 34;
            this.createBookingButton.Text = "Create Booking";
            this.createBookingButton.UseVisualStyleBackColor = false;
            this.createBookingButton.Click += new System.EventHandler(this.createBookingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 27);
            this.label1.TabIndex = 35;
            this.label1.Text = "The Deluxe Suite is available for ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 27);
            this.label2.TabIndex = 35;
            this.label2.Text = "the selected dates ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 27);
            this.label3.TabIndex = 35;
            this.label3.Text = "Total Price: R";
            // 
            // bookingPriceLabel
            // 
            this.bookingPriceLabel.AutoSize = true;
            this.bookingPriceLabel.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingPriceLabel.Location = new System.Drawing.Point(236, 105);
            this.bookingPriceLabel.Name = "bookingPriceLabel";
            this.bookingPriceLabel.Size = new System.Drawing.Size(51, 27);
            this.bookingPriceLabel.TabIndex = 35;
            this.bookingPriceLabel.Text = "950";
            // 
            // RoomAvailableBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 331);
            this.Controls.Add(this.bookingPriceLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createBookingButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RoomAvailableBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomAvailableBox";
            this.Load += new System.EventHandler(this.RoomAvailableBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createBookingButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label bookingPriceLabel;
    }
}