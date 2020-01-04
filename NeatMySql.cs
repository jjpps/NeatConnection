using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeatConnection
{
    public class NeatMySql : ConConfig
    {
        private MySqlConnection connection;
        public NeatMySql() : base(ConConfig.MontaJson())
        {
            connection = new MySqlConnection(connectionString);
        }

        private void OpenConnection()
        {
            
            try
            {
                connection.Open();
               
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {               
                return false;
            }
        }

        public bool TestaConnection()
        {
            try
            {
                OpenConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}
