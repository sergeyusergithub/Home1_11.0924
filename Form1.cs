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
            List<Mechanics> count_data = DBWork.SelectDataMechanics();
            

            foreach (var item in count_data)
            {
                cmbMechanics.Items.Add(item.Name);
            }

            /*foreach (string name in DBWork.GetMechanics())
            {
                cmbMechanics.Items.Add(name);
            }*/
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

        // выбор свободного номера механика, который добавляется в таблицу
        private  long GetNumber(List<long> numb)
        {
            long result = 0;
            var _numb = numb.OrderBy(x=>x).ToList();
            result = numb[0];

            foreach (long num in _numb)
            {
                if (num != result)
                {
                    return result;
                } else
                {
                    result++;
                }
            }

            return result;
        }

        // добавление механика в БД
        private void btnAddMechanic_Click(object sender, EventArgs e)
        {
            if (tbNameMechanic.Text != string.Empty)
            {
                List<Mechanics> _list_mch;
                _list_mch = DBWork.SelectDataMechanics();
                List<long> ints = new List<long>();
                
                foreach(var item in _list_mch)
                {
                    ints.Add(item.Number);
                }

                long mch_numb = GetNumber(ints);

                

                DBWork.InsertData("Mechanics", "number,name", $"{mch_numb},'{tbNameMechanic.Text}'");
                cmbMechanics.Items.Clear();
                FillMechanicsName();
            }
        }

        // удаление механика из БД
        private void btnDeleteMechanic_Click(object sender, EventArgs e)
        {         
           
            int _mch_number = cmbMechanics.SelectedIndex;
            List<Mechanics> count_data = DBWork.SelectDataMechanics();

            DBWork.DeleteMechanics(Convert.ToInt32(count_data[_mch_number].Number), count_data[_mch_number].Name);

            
            cmbMechanics.Items.Clear();
            cmbMechanics.Text = string.Empty;
            picBoxAvatar.BackColor = Color.Black;
            picBoxAvatar.Image = null;
            FillMechanicsName();

        }
    }
}
