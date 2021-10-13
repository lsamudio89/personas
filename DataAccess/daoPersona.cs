using DataAccess.Contract;
using DataAccess.Repository;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class daoPersona : OracleConexion, OperacionCrud<PersonaBO>
    {
        public string Actualizar(PersonaBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConexion cn = new OracleConexion(strOracle))
                {
                    cn.Open();

                    using (OracleCommand command = new OracleCommand("SP_UPDATE_PERSONAS", cn))
                    {
                        command.ComandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_DNI", Oracletype.Varchar)).Value = dto.DNI;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE_APELLIDO", Oracletype.Varchar)).Value = dto.NOMBRE_APELLIDO;
                        command.Parameters.Add(new OracleParameter("P_EMAIL", Oracletype.Varchar)).Value = dto.EMAIL;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO", Oracletype.Varchar)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("P_FECHA_NACIMIENTO", Oracletype.Date)).Value = dto.FECHA_NACIMIENTO;
                        command.Parameters.Add(new OracleParameter("P_RESULT", Oracletype.Varchar)).Direction = System.Data.ParameterDirection.Output;

                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public string Eliminar(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConexion cn = new OracleConexion(strOracle))
                {
                    cn.Open();

                    using (OracleCommand command = new OracleCommand("SP_DELETE_PERSONAS", cn))
                    {

                        command.ComandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_DNI", Oracletype.Varchar)).Value = dto.DNI;
                        command.Parameters.Add(new OracleParameter("P_RESULT", Oracletype.Varchar)).Direction = System.Data.ParameterDirection.Output;

                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public string Insertar(PersonaBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConexion cn = new OracleConexion(strOracle))
                {
                    cn.Open();

                    using (OracleCommand command = new OracleCommand("SP_INSERT_PERSONAS", cn))
                    {
                        command.Parameters.Add(new OracleParameter("P_DNI", Oracletype.Varchar)).Value = dto.DNI;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE_APELLIDO", Oracletype.Varchar)).Value = dto.NOMBRE_APELLIDO;
                        command.Parameters.Add(new OracleParameter("P_EMAIL", Oracletype.Varchar)).Value = dto.EMAIL;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO", Oracletype.Varchar)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("P_FECHA_NACIMIENTO", Oracletype.Date)).Value = dto.FECHA_NACIMIENTO;
                        command.Parameters.Add(new OracleParameter("P_RESULT", Oracletype.Varchar)).Direction = System.Data.ParameterDirection.Output;

                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public List<PersonaBO> Listar()
        {
            List<PersonaBO> list = new List<PersonaBO>();
            PersonaBO dto = null;

            try
            {
                using (OracleConexion cn = new OracleConexion(strOracle))
                {
                    cn.Open();

                    using (OracleCommand command = new OracleCommand("SP_SELECT_PERSONAS", cn))
                    {
                        command.ComandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        
                        using (OracleDataReader dr = command.ExecuteReader (System.Data.CommandBehavior.CloseConnection))
                        {
                            while(dr.Read())
                            {
                                dto = new PersonaBO();
                                dto.DNI             = dr["DNI"].ToString ();
                                dto.NOMBRE_APELLIDO = Convert.ToString(dr["NOMBRE_APELLIDO"]);
                                dto.EMAIL           = Convert.ToString(dr["EMAIL"]);
                                dto.TELEFONO        = Convert.ToString(dr["TELEFONO"]); 
                                dto.FECHA_NACIMIENTO= Convert.ToString(dr["FECHA_NACIMIENTO"]);
                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception("Error en el metodo listar" + ex.Message);
            }
            return list;


        }
    }
}
