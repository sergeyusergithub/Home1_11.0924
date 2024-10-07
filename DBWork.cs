using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Home1
{
    internal class DBWork
    {
        static private string path = $"Data Source=AutoService.db";
        // создание таблиц в базе данных и наполнение и данными
        static public bool MakeDB(string _dbname = "AutoService.db")
        {

            bool result = false;
            string path = $"Data Source={_dbname}";
            string create_table_mechanics = "CREATE TABLE IF NOT EXISTS " +
                "Mechanics " +
                "(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "number INTEGER," +
                "name VARCHAR," +
                "avatar BLOB);";

            string init_data_mechanics = "INSERT INTO " +
                "Mechanics(number,name) " +
                "VALUES " +
                "(1, 'Иванов')," +
                "(2, 'Петров')," +
                "(3, 'Сидоров')," +
                "(4, 'Кузнецов');";

            string create_table_jobs = "CREATE TABLE IF NOT EXISTS " +
                "Jobs " +
                "(jobs_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "number INTEGER," +
                "name VARCHAR," +
                "standard_hours REAL," +
                "cost DECIMAL," +
                "client VARCHAR," +
                "mechanics_id INTEGER," +
                "FOREIGN KEY (mechanics_id) " +
                "REFERENCES Mechanics(id));";

            string init_data_jobs = "INSERT INTO " +
                "Jobs(number,name,standard_hours,cost,client,mechanics_id) " +
                "VALUES " +
                "(1, 'Прокачка тормозной системы',1.5,3000,'x001xx',1)," +
                "(2, 'Замена масла', 1, 3000,'x001xx',3), " +
                "(3, 'Консультация',0.5,3000,'x741xx',2), " +
                "(4, 'Замена лампочки поворотника',0.5,3000,'x001xx',4);";

            SQLiteConnection conn = new SQLiteConnection(path);
            SQLiteCommand cmd_cr_tbl_mch = conn.CreateCommand();
            SQLiteCommand cmd_init_tbl_mch = conn.CreateCommand();
            SQLiteCommand cmd_cr_tbl_jobs = conn.CreateCommand();
            SQLiteCommand cmd_init_tbl_jobs = conn.CreateCommand();

            cmd_cr_tbl_mch.CommandText = create_table_mechanics;
            cmd_init_tbl_mch.CommandText = init_data_mechanics;
            cmd_cr_tbl_jobs.CommandText = create_table_jobs;
            cmd_init_tbl_jobs.CommandText= init_data_jobs;

            conn.Open();
            cmd_cr_tbl_mch.ExecuteNonQuery();
            cmd_init_tbl_mch.ExecuteNonQuery();
            cmd_cr_tbl_jobs.ExecuteNonQuery();
            cmd_init_tbl_jobs.ExecuteNonQuery();

            conn.Close();

            result = true;


            return result;
        }

        // получить список имен механиков из базы данных
        static public List<string> GetMechanics()
        {
            List<string> result = new List<string>();

            string get_mechanics = "SELECT name FROM Mechanics;";
            using(SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand cmd_get_mch = conn.CreateCommand();
                cmd_get_mch.CommandText = get_mechanics;

                conn.Open();

                SQLiteDataReader reader = cmd_get_mch.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }


            }

            return result;
        }

        // добавление картинки "аватара" в БД для заданного "имени" механика
        static public void AddAvatar(string _name, byte[] _image)
        {
            using(SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = $"UPDATE Mechanics SET avatar = @avatar " +
                    $"WHERE name LIKE '{_name}%';";
                command.Parameters.Add(new SQLiteParameter("@avatar",_image));
                conn.Open();
                command.ExecuteNonQuery();
            }

        }

        // получение картирки "аватара" из БД для заданного "имени" механика
        static public MemoryStream GetAvatar(string _name)
        {
            MemoryStream result = null;
            byte[] _image = null;
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand command = new SQLiteCommand(conn);
                string get_image = $"SELECT avatar FROM Mechanics " +
                    $"WHERE name LIKE '{_name}%';";

                command.CommandText= get_image;
                conn.Open();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if(!reader.IsDBNull(0))
                        {
                            _image = (byte[])reader.GetValue(0);
                        }
                    }
                }

            }

            if(_image != null)
            {
                result = new MemoryStream(_image);
            }

            return result;

        }

        // вставить данные в таблицу: имя таблицы, строка параметров, строка с данными
        static public void InsertData(string table_name,string parameter_name,string insert_data)
        {
            string cmd_insert_data = $"INSERT INTO {table_name} " +
                    $"({parameter_name}) " +
                    "VALUES " +
                    $"({insert_data});";

            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = cmd_insert_data;
                conn.Open();
                command.ExecuteNonQuery();

            }

        }

        // получить данные из таблицы: имя таблицы, строка параметров
        static public List<Mechanics> SelectDataMechanics()
        {
            string cmd_select_data = $"SELECT number,name,avatar " +
                $"FROM  Mechanics;";


            List<Mechanics> result = new List<Mechanics>();

            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = cmd_select_data;
                conn.Open();
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Mechanics tmp;
                        if (reader.GetValue(2).Equals(null))
                        {
                            tmp = new Mechanics{ Number = (long)reader.GetValue(0), Name = (string)reader.GetValue(1), Avatar = (byte[])reader.GetValue(2) };

                        } else
                        {
                            tmp = new Mechanics { Number = (long)reader.GetValue(0), Name = (string)reader.GetValue(1) };
                        }
                        
                        if (tmp != null)
                        {
                            result.Add(tmp);

                        } else
                        {
                            
                            
                        }

                    }
                }
            }

            return result;

        }

        public static void DeleteMechanics(int number, string name)
        {
            string cmd_delete_data = $"DELETE FROM  Mechanics" +
                $" WHERE (name = '{name}') AND (number = {number});";


            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = cmd_delete_data;
                conn.Open();
                command.ExecuteNonQuery();

            }

        } 

    }
}