using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.API_s
{
    public class QuerySchedule
    {
       
        string conStr = "Dsn=post";
        DataTable ds;
        // các câu truy vấn có dữ liệu trả về
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
        // các câu truy vấn không có dữ liệu trả về
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
        public string GetAllSchedule()
        {           
            string query = "select * from Schedule";
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
        public string GetScheduleByID(int id, int userID)
        {            
            string query = "select * from Schedule where id=" + id + "and userID=" + userID;
            ds = new DataTable();
            connectQuery(query);
            return JsonConvert.SerializeObject(ds);
        }
        public string GetScheduleByUserID(string username,string password)
        {
            string query = "select * from schedule left join Account on Account.id = schedule.userid where username ='"+username+ "'and password = '"+password+"'" ;
            ds = new DataTable();
            connectQuery(query);
            return JsonConvert.SerializeObject(ds);
        }
        public void AddSchedule(int userid, string day, string time, string job)
        {
            string query = "insert into schedule(userID,day,time,job) values(" + userid + ",'" + day + "','" + time + "','" + job + "')";
            connectNonQuery(query);
        }
        public void UpdateSchedule(int id, int userID, string day, string time, string job)
        {
            string query = "update Schedule set day = '" + day + "', time = '" + time + "', job = '" + job + "' where userID = " + userID + " and id = " + id + "";
            connectNonQuery(query);
        }       

        public void DeleteSchedule(int id)
        {
            string query = "delete from Schedule where id = " + id + "";
            connectNonQuery(query);
        }
    }
}
