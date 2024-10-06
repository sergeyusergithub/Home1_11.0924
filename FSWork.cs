using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Home1
{
    internal class FSWork
    {
        // проверка существует ли указанный файл
        static public bool IsFileExists(string path)
        {
            bool result = false;
            if (File.Exists(path))
            {
                result = true;
            }

            return result;
        }

        // получаем массив байт выбранного изображения
        static public byte[] GetImage()
        {
            byte[] result = null;
            string filename = "";

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "JPG files (*.jpg)|*.jpg|All files(*.txt)|*/*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            else
            {
                return result;
            }

            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                result = new byte[fs.Length];
                fs.Read(result,0,result.Length);
            }

                return result;
        }
    }
}
