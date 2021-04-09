using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace BookAPI.API_s
{
    public class Query
    {
        //string conStr = "Dsn=post";
        string conStr = "Server= 172.16.8.20;Port=5432;Database=Schedule;Uid=POSMAN;Pwd=apzon123;";
        string connectionString = string.Format("Sever={0};Port={1};User Id={2};Password={3};Database={4}", "172.16.8.20","5432","dangph@apzon.com", "123456", "Schedule");
        NpgsqlConnection conn = null;
        
        DataTable ds;
        // câu truy vấn có dữ liệu trả về
        public void connectQuery(string query)
        {
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
        }
        // câu truy vấn không có dữ liệu trả về
        public void connectNonQuery(string query)
        {
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
        public string GetAccount()
        {
            ds = new DataTable();
            string query = "select * from Account";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            conn.Open();
            adapter.Fill(ds);
            NpgsqlDataReader dRead = cmd.ExecuteReader();
            return JsonConvert.SerializeObject(ds);                     
            
        }
        public string GetAccountByID(int id)
        {
            string query = "select * from Account acc where acc.id=" + id;
            ds = new DataTable();            
            connectQuery(query);
            return JsonConvert.SerializeObject(ds);
        }
        public string Login( string username, string password)
        {
            string query = "select * from Account acc where acc.username='" + username + "'and password='" + password+"'";
            ds = new DataTable();
            connectQuery(query);
            return JsonConvert.SerializeObject(ds);
        }
        public void AddAccount(string username, string password)
        {
            string query = "insert into Account(username,password) values('" + username + "', '" + password + "')";
            connectNonQuery(query);           
        }
        public void UpdateAccount(string username, string password)
        {
            string query = "update Account set password = '" + password + "' where username = '" + username + "'";
            connectNonQuery(query);
        }
    }
}
