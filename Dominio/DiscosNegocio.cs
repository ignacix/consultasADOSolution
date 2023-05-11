using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dominio
{
    public class DiscosNegocio
    {
        public List<Discos> Listar()
        {

            List<Discos> lista = new List<Discos> ();
            SqlConnection con = new SqlConnection ();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                con.ConnectionString = "server=.\\SQLEXPRESS ; database=DISCOS_DB ; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select Id, Titulo,FechaLanzamiento from DISCOS";
                cmd.Connection = con;

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Discos aux = new Discos();
                    aux.Id = dr.GetInt32(0);
                    aux.Titulo = (string)dr["Titulo"];                    
                    aux.FechaLanzamiento = (DateTime)dr["FechaLanzamiento"];
                    

                    lista.Add (aux);
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close (); 
            }


            
        }
    }
}
