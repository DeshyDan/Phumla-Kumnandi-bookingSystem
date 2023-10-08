using Phumla_Kumnandi_Hotel_Reservation_System.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Hotel_Reservation_System.Presentation
{
    public partial class RoomsForm : Form
    {
        public RoomsForm()
        {
            InitializeComponent();
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            PopulateRooms();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                string stringRoomID = searchBox.Text;
                int roomId = int.Parse(stringRoomID);
                RoomController roomcontroller = new RoomController();
                 
                Room aRoom = roomcontroller.Find(roomId);

                if (string.IsNullOrEmpty(stringRoomID))
                {
                    MessageBox.Show("Please enter a GuestID to searc", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (aRoom == null)
                {
                    MessageBox.Show("Guest does not exist in our system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(aRoom.Id, aRoom.RoomNumber, aRoom.RoomDescription, aRoom.RoomAvailability, aRoom.Rate);

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure all fields are correctly flled in before proceeding", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }
        public void PopulateRooms()
        {
            try
            {
                RoomController roomcontroller = new RoomController();
                Collection<Room> allRooms = roomcontroller.AllRooms;
                dataGridView1.Rows.Clear();

                foreach (Room room in allRooms)
                {
                    dataGridView1.Rows.Add(
                        room.RoomAvailibility,
                        room.RoomDescription,
                        room.rate,
                        room.Id);
                      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error occured while listing all guests{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
