using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.API_s
{
    public class Query
    {
        string conStr = @"Dsn=DNS";
        DataTable ds;
        public string GetAccount()
        {
            string query = "select * from Account";
            DataTable data= new DataTable();
            using (OdbcConnection connection = new OdbcConnection(conStr))
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adapter.Fill(data);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            }

            return JsonConvert.SerializeObject(data);

        }
        public string GetAccountByID(int id)
        {


            string query = "select * from Account acc where acc.id=" + id;

            ds = new DataTable();
            using (OdbcConnection connection = new OdbcConnection(conStr))
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adapter.Fill(ds);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            }

            return JsonConvert.SerializeObject(ds);
        }
        public string Login( string username, string password,int id)
        {


            string query = "select * from Account acc where acc.username='" + username + "'and password='" + password+"'and id="+id;

            ds = new DataTable();
            using (OdbcConnection connection = new OdbcConnection(conStr))
            {
                OdbcDataAdapter adapter = new OdbcDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adapter.Fill(ds);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            }

            return JsonConvert.SerializeObject(ds);
        }
        public void AddAccount(string username, string password)
        {


            string query = "insert into dbo.Account(username,password) values('" + username + "', '" + password + "')";

            OdbcCommand command = new OdbcCommand(query);

            using (OdbcConnection connection = new OdbcConnection(conStr))
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }


            }
        }
        public void UpdateAccount(string username, string password)
        {


            string query = "update dbo.Account set password = '" + password + "' where username = '" + username + "'";

            OdbcCommand command = new OdbcCommand(query);

            using (OdbcConnection connection = new OdbcConnection(conStr))
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }


            }
        }
    }
}
