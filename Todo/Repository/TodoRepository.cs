using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Todo.Models;

namespace Todo.Repository
{
    public class TodoRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getcon"].ToString();
            con = new SqlConnection(constr);
        }

        public bool AddTodo(Todolist todo)
        {
            connection();
            SqlCommand com = new SqlCommand("Add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@title", todo.title);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Todolist> GetAllTodo()
        {
            connection();
            List<Todolist> lst = new List<Todolist>();
            SqlCommand com = new SqlCommand("Get", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            //Hiển thị
            foreach(DataRow dr in dt.Rows)
            {
                lst.Add(
                    new Todolist
                    {
                        id = Convert.ToInt32(dr["id"]),
                        title = Convert.ToString(dr["title"])
                    }
                );
            }
            return lst;
        }

        public bool UpdateTodo(Todolist todo)
        {
            connection();
            SqlCommand com = new SqlCommand("Update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", todo.id);
            com.Parameters.AddWithValue("@title", todo.title);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTodo(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("Delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}