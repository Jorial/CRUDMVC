using CRUDMVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDMVC.Datos
{
    public class ContactoDatos
    {
        ConnectionSQL conn = new ConnectionSQL();
       
        public DataSet GetAllContat()
        {
            
            SqlConnection ReadConnection = new SqlConnection(conn.GetConnectionString());
            ReadConnection.Open();
            string Query = "exec sp_ReadContact";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, ReadConnection);
            DataSet ds = new DataSet(); // no usamos dataser si no datatable
            adapter.Fill(ds);
            return ds;
        }

        public void SaveContact(ContactModel cm)
        {
            SqlConnection SaveConnection = new SqlConnection(conn.GetConnectionString());
            SaveConnection.Open();
            string query = "sp_CreateContact '" + cm.Nombre + "',"+ cm.Telefono+ ";";
            SqlCommand cmd = new SqlCommand(query, SaveConnection);
            cmd.ExecuteNonQuery();
            SaveConnection.Close(); 

        }

        public void UpdateContact(ContactModel cm)
        {
            SqlConnection UpdateConnection = new SqlConnection(conn.GetConnectionString());
            UpdateConnection.Open();
            string query = "exec sp_UpdateContact " + cm.Idcontacto + ",'" + cm.Nombre + "'," + cm.Telefono;
            SqlCommand cmd = new SqlCommand(query,UpdateConnection);
            cmd.ExecuteNonQuery();
            UpdateConnection.Close();
        }

        public void DeleteContact(ContactModel cm)
        {
            SqlConnection DeleteConnection = new SqlConnection(conn.GetConnectionString());
            DeleteConnection.Open();
            string query = "exec sp_DeleteContact " + cm.Idcontacto;
            SqlCommand cmd = new SqlCommand(query,DeleteConnection);
            cmd.ExecuteNonQuery();
            DeleteConnection.Close();
        }

        public DataSet GetOnlyOneContat(int dato)
        {

            SqlConnection ReadConnection = new SqlConnection(conn.GetConnectionString());
            ReadConnection.Open();
            string Query = "exec sp_OnlyOneRegister " + dato;
            SqlDataAdapter adapter = new SqlDataAdapter(Query, ReadConnection);
            DataSet ds = new DataSet(); // no usamos dataser si no datatable
            adapter.Fill(ds);
            return ds;
        }


    }
}
