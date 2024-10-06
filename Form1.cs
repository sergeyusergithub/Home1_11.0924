using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!FSWork.IsFileExists("AutoService.db"))
                MakeStore();
            FillMechanicsName();

        }

        private void MakeStore()
        {
            if (DBWork.MakeDB())
                MessageBox.Show("База данных создана.");
        }

        private void FillMechanicsName()
        {
            foreach (string name in DBWork.GetMechanics())
            {
                cmbMechanics.Items.Add(name);
            }
        }

        private void picBoxAvatar_Click(object sender, EventArgs e)
        {
          
            if (cmbMechanics.Text != string.Empty)
            {
                byte[] _image = FSWork.GetImage();

                string mch_name = cmbMechanics.Text;
                DBWork.AddAvatar(mch_name,_image);


                MemoryStream ms = new MemoryStream(_image);
              
                if (ms != null)
                {
                    picBoxAvatar.Image = Image.FromStream(ms);
                }
                else
                {
                    picBoxAvatar.BackColor = Color.Gray;
                    picBoxAvatar.Image = null;
                }

            }
        }

        private void SetImage2PictureBox()
        {
            string _name = cmbMechanics.SelectedItem.ToString();
            MemoryStream ms = DBWork.GetAvatar(_name);
            if (ms != null)
            {
                picBoxAvatar.Image = Image.FromStream(ms);
            }
            else
            {
                picBoxAvatar.BackColor = Color.Black;
                picBoxAvatar.Image = null;
            }

        }

        private void cmbMechanics_SelectedValueChanged(object sender, EventArgs e)
        {
            SetImage2PictureBox();
           
        }

        private void btnAddMechanic_Click(object sender, EventArgs e)
        {
            if (tbNameMechanic.Text != string.Empty)
            {
                List<long> _number;
                _number = DBWork.SelectData<long>("Mechanics", "number");

                foreach (int item in _number)
                {
                    lstTmp.Items.Add(item);
                }

                DBWork.InsertData("Mechanics", "number,name", $"6,'{tbNameMechanic.Text}'");
                cmbMechanics.Items.Clear();
                FillMechanicsName();
            }
        }
    }
}
