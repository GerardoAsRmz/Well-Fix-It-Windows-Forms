using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Well_Fix_It_Forms
{
    internal class Conexion
    {
        private SqlConnection conectada = new SqlConnection("Data Source =.;" + "Initial Catalog = We_ll_Fix_It;" + "Integrated Security = true");
        public void Conectar()
        {
            try
            {
                conectada.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos:" + ex.Message, "Error de conexion: ",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Desconectar()
        {
            conectada.Close();
        }
        public bool RegistroUsuario(string nombre, string apellido, string correo, string telefono, string calle, string nomenclatura, string colonia, 
                                    string entrecalles,string codigopostal, string municipio, string estado, string contraseña, string hash, string salt)
        {
            bool resultado = false;
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("sp_insert_usuario", conectada);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = apellido;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = correo;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 10).Value = telefono;
                cmd.Parameters.Add("@calle", SqlDbType.VarChar, 100).Value = calle;
                cmd.Parameters.Add("@nomenclatura", SqlDbType.VarChar, 5).Value = nomenclatura;
                cmd.Parameters.Add("@colonia", SqlDbType.VarChar, 100).Value = colonia;
                cmd.Parameters.Add("@entrecalles", SqlDbType.VarChar, 150).Value = entrecalles;
                cmd.Parameters.Add("@codigopostal", SqlDbType.VarChar, 5).Value = codigopostal;
                cmd.Parameters.Add("@municipio", SqlDbType.VarChar, 50).Value = municipio;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 50).Value = estado;
                cmd.Parameters.Add("@contraseña", SqlDbType.VarChar, 50).Value = contraseña;
                cmd.Parameters.Add("@hash", SqlDbType.NVarChar, -1).Value = hash;
                cmd.Parameters.Add("@salt", SqlDbType.NVarChar, -1).Value = salt;
                cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }
            return resultado;
        }
        public bool RegistroTecnico(string nombre, string apellidos, string correo, string telefono, string calle, string nomenclatura, string colonia, string entrecalles,string codigpostal,
                                    string municipio,string estado, string especialidad, string añosdeexperiencia, string genero, string contraseña, string hash, string salt, byte[] fotopersonal)
        {
            bool resultado = false;
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("INSERT INTO Tecnicos (Nombre, Apellidos, Correo, Telefono, Calle,Nomenclatura,Colonia,Entrecalles, Codigpostal, Municipio,Estado, Especialidad, Añosdeexperiencia, Genero, Contraseña,Hash,Salt,Foto,Fotopersonal)" +
                                                "VALUES (@nombre, @apellidos, @correo, @telefono, @calle,@nomenclatura,@colonia,@entrecalles,@codigpostal,  @municipio,@estado, @especialidad, @añosdeexperiencia, @genero, @contraseña,@hash,@salt,@foto,@fotopersonal)", conectada);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 50).Value = apellidos;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = correo;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 10).Value = telefono;
                cmd.Parameters.Add("@calle", SqlDbType.VarChar, 50).Value = calle;
                cmd.Parameters.Add("@nomenclatura", SqlDbType.VarChar, 5).Value = nomenclatura;
                cmd.Parameters.Add("@colonia", SqlDbType.VarChar, 100).Value = colonia;
                cmd.Parameters.Add("@entrecalles", SqlDbType.VarChar, 150).Value = entrecalles;
                cmd.Parameters.Add("@codigpostal", SqlDbType.VarChar, 5).Value = codigpostal;
                cmd.Parameters.Add("@municipio", SqlDbType.VarChar, 50).Value = municipio;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 50).Value = estado;
                cmd.Parameters.Add("@especialidad", SqlDbType.VarChar, 50).Value = especialidad;
                cmd.Parameters.Add("@añosdeexperiencia", SqlDbType.VarChar, 50).Value = añosdeexperiencia;
                cmd.Parameters.Add("@genero", SqlDbType.VarChar, 30).Value = genero;
                cmd.Parameters.Add("@contraseña", SqlDbType.VarChar, 50).Value = contraseña;
                cmd.Parameters.Add("@hash", SqlDbType.NVarChar, -1).Value = hash;
                cmd.Parameters.Add("@salt", SqlDbType.NVarChar, -1).Value = salt;
                cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                cmd.Parameters.Add("@fotopersonal", SqlDbType.VarBinary, -1).Value =(object) fotopersonal;
                cmd.Parameters.Add("@id_Tecnicos", SqlDbType.Int).Value = TecnicoSesion.IdTecnico;        
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }
            return resultado;
        }
        public bool Solicitud_Servicios(string categoria, string descripcionproblema, string tiposervicio, string antiguedadequipo, string tipopago, DateTime fechasolicitud, string horavisita, string marcaequipo)
        {
            bool resultado = false;
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("INSERT INTO Solicitud_Servicios (Categoria,Descripcionproblema,Tipodeservicio,Antiguedadequipo,Tipopago,Fechasolicitud,Horavisita,Marcaequipo,id_Usuarios,id_Estatus)" +
                                                "VALUES (@categoria,@descripcionproblema,@tipodeservicio,@antiguedadequipo,@tipopago,@fechasolicitud,@horavisita,@marcaequipo,@id_Usuarios,@id_Estatus)", conectada);
                cmd.Parameters.Add("@categoria", SqlDbType.VarChar, 30).Value = categoria;
                cmd.Parameters.Add("@descripcionproblema", SqlDbType.VarChar, 200).Value = descripcionproblema;
                cmd.Parameters.Add("@tipodeservicio", SqlDbType.VarChar, 50).Value = tiposervicio;
                cmd.Parameters.Add("@antiguedadequipo", SqlDbType.VarChar, 20).Value = antiguedadequipo;
                cmd.Parameters.Add("@tipopago", SqlDbType.VarChar, 20).Value = tipopago;
                cmd.Parameters.Add("@fechasolicitud", SqlDbType.Date).Value = fechasolicitud;
                cmd.Parameters.Add("@horavisita", SqlDbType.VarChar, 25).Value = horavisita;
                cmd.Parameters.Add("@marcaequipo", SqlDbType.VarChar, 25).Value = marcaequipo;
                cmd.Parameters.Add("@id_Estatus", SqlDbType.Int).Value = 1; //  1 (Pendiente)
                cmd.Parameters.Add("@id_Usuarios", SqlDbType.Int).Value = UsuarioSesion.IdUsuario;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no se pueden guardar los datos:" + ex.Message, "Error de datos: ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Desconectar();
            }
            return resultado;
        }
        public DataTable InicioSesionUsuario(string correo, string contraseña)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("SELECT Hash, Salt,nombre, apellido, id_Usuarios FROM Usuarios WHERE Correo = @correo", conectada);
                cmd.Parameters.AddWithValue("@correo", correo);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader["Hash"].ToString().Trim();
                        string storedSalt = reader["Salt"].ToString().Trim();
                        if (PasswordHelper.VerifyPassword(contraseña, storedHash, storedSalt))
                        {
                            UsuarioSesion.NombreUsuario = reader["nombre"].ToString();
                            UsuarioSesion.ApellidoUsuario = reader["apellido"].ToString();
                            UsuarioSesion.IdUsuario = (int)reader["id_Usuarios"];
                            dt.Columns.Add("Status");
                            dt.Rows.Add("OK");
                            MessageBox.Show("Inicio de Sesion con Exito: " + UsuarioSesion.NombreUsuario +" "+ UsuarioSesion.ApellidoUsuario, "Perfil de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta. Inténtalo de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión:" + ex.Message, "Error de inicio de sesión: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }
        public DataTable InicioSesionTecnico(string correo, string contraseña)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("SELECT Hash, Salt,nombre, apellidos, id_Tecnicos FROM Tecnicos WHERE Correo = @correo", conectada);
                cmd.Parameters.AddWithValue("@correo", correo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader["Hash"].ToString().Trim();
                        string storedSalt = reader["Salt"].ToString().Trim();
                        if (PasswordHelper.VerifyPassword(contraseña, storedHash, storedSalt))
                        {
                            TecnicoSesion.NombreTecnico = reader["nombre"].ToString();
                            TecnicoSesion.ApellidoTecnico = reader["apellidos"].ToString();
                            TecnicoSesion.IdTecnico = (int)reader["id_tecnicos"];
                            dt.Columns.Add("Status");
                            dt.Rows.Add("OK");
                            MessageBox.Show("Inicio de Sesion con Exito: " + TecnicoSesion.NombreTecnico +" "+ TecnicoSesion.ApellidoTecnico, " Perfil de Tecnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión:" + ex.Message, "Error de inicio de sesión: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }
        public DataTable MostrarSolicitudServicios()
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                string query = @"
                SELECT 
                ss.id_Solicitud_Servicios,
                U.nombre + ' ' + U.apellido AS [Cliente],
                U.calle AS [Calle],
                U.nomenclatura AS [Num Ext],
                U.colonia AS [Colonia],
                U.entrecalles AS [Entre Calles],
                U.codigopostal AS [CP],
                U.municipio AS [Municipio],
                U.telefono AS [Teléfono],
                U.correo AS [Correo],
                ss.Categoria AS [Equipo],
                ss.tipodeservicio AS [Servicio],
                ss.descripcionproblema AS [Falla],
                ss.antiguedadequipo AS [Antigüedad],
                ss.tipopago AS [Pago],
                ss.fechasolicitud AS [Fecha Visita],
                ss.horavisita AS [Hora Visita],
                ss.marcaequipo AS [Marca]
                FROM Solicitud_Servicios ss
                INNER JOIN Usuarios U ON ss.id_Usuarios = U.id_Usuarios
                WHERE ss.id_Estatus = 1";

                SqlCommand cmd = new SqlCommand(query, conectada);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no se puede realizar la consulta " + ex.Message, "Error de datos: ",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }
        public DataTable BuscarPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                SqlCommand cmd = new SqlCommand("Select * From Solicitud_Servicios Where id_Solicitud_Servicios = @id", conectada);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no se puede ejecutar la busqueda:" + ex.Message, "Error de datos: ",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }
        public DataTable MostrarSolicitudServiciosPorTecnico(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                string sql = @"SELECT 
                S.id_Solicitud_Servicios,
                U.nombre + ' ' + U.apellido AS [Cliente],
                U.calle AS [Calle],
                U.nomenclatura AS [Num Exterior],
                U.colonia AS [Colonia],
                U.entrecalles AS [Entre Calles],
                U.codigopostal AS [CP],
                U.municipio AS [Municipio],
                U.telefono AS [Teléfono],
                U.correo AS [Correo],
                S.Categoria AS [Equipo],
                S.tipodeservicio AS [Servicio],
                S.descripcionproblema AS [Falla],
                S.antiguedadequipo AS [Antigüedad],
                S.tipopago AS [Pago],
                S.fechasolicitud AS [Fecha Visita],
                S.horavisita AS [Hora Visita],
                S.marcaequipo AS [Marca],
                PA.costoreparacion AS [Costo]
                FROM Solicitud_Servicios S
                INNER JOIN Usuarios U ON S.id_Usuarios = U.id_Usuarios
                INNER JOIN Pedidos_Agendados PA ON S.id_Solicitud_Servicios = PA.id_Solicitud_Servicios
                WHERE PA.id_Tecnicos = @id AND S.id_Estatus = 2";

                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no se puede realizar la consulta " + ex.Message, "Error de datos: ",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }
        public void AgendarServicio(int id_Solicitud_Servicios, int id_Tecnicos, double costoreparacion)
        {
            try
            {
                DataTable dt = new DataTable();
                Conectar();
                SqlCommand cmdExistePedidoParaSolicitud = new SqlCommand("Select * FROM Pedidos_Agendados WHERE id_Solicitud_Servicios = @id_Solicitud_Servicios", conectada);
                cmdExistePedidoParaSolicitud.Parameters.AddWithValue("@id_Solicitud_Servicios", id_Solicitud_Servicios);
                SqlDataAdapter sdaExistePedidoParaSolicitud = new SqlDataAdapter(cmdExistePedidoParaSolicitud);
                sdaExistePedidoParaSolicitud.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe un pedido agendado para esta solicitud de servicio.", "Error de agendamiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Pedidos_Agendados (id_Solicitud_Servicios, id_Tecnicos, costoreparacion) VALUES (@id_Solicitud_Servicios, @id_Tecnicos, @costoreparacion)", conectada);
                    cmd.Parameters.Add("@id_Solicitud_Servicios", SqlDbType.Int).Value = id_Solicitud_Servicios;
                    cmd.Parameters.Add("@id_Tecnicos", SqlDbType.Int).Value = id_Tecnicos;
                    cmd.Parameters.Add("@costoreparacion", SqlDbType.Float).Value = costoreparacion;
                    cmd.ExecuteNonQuery();
                    string sqlUpdate = "UPDATE Solicitud_Servicios SET id_Estatus = 2 WHERE id_Solicitud_Servicios = @idSol";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conectada);
                    cmdUpdate.Parameters.AddWithValue("@idSol", id_Solicitud_Servicios);
                    cmdUpdate.ExecuteNonQuery();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión:" + ex.Message, "Error de inicio de sesión: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Desconectar();
            }
        }
        public void CancelarPedido(int id_Solicitud_Servicios)
        {
            try
            {
                Conectar();
                string sqlDelete = "DELETE FROM Pedidos_Agendados WHERE id_Solicitud_Servicios = @id";
                SqlCommand cmd1 = new SqlCommand(sqlDelete, conectada);
                cmd1.Parameters.AddWithValue("@id", id_Solicitud_Servicios);
                cmd1.ExecuteNonQuery();

                string sqlUpdate = "UPDATE Solicitud_Servicios SET id_Estatus = 1 WHERE id_Solicitud_Servicios = @id";
                SqlCommand cmd2 = new SqlCommand(sqlUpdate, conectada);
                cmd2.Parameters.AddWithValue("@id", id_Solicitud_Servicios);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar el pedido:" + ex.Message, "Error de cancelación: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Desconectar();
            }
        }
        public void FinalizarServicio(int id)
        {
            try
            {
                Conectar();
                string sql = "UPDATE Solicitud_Servicios SET id_Estatus = 3 WHERE id_Solicitud_Servicios = @id";

                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Servicio finalizado con éxito! Se guardó en el historial.","Servicio finalizado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public DataTable MostrarSolicitudesPropias(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                // Agregamos el INNER JOIN con la tabla Estatus
                string sql = @"SELECT 
                        S.id_Solicitud_Servicios AS [ID], 
                        S.Categoria AS [Categoría],
                        S.descripcionproblema AS [Falla],
                        S.marcaequipo AS [Marca], 
                        S.tipodeservicio AS [Servicio],
                        S.fechasolicitud AS [Fecha], 
                        S.horavisita AS [Hora], 
                        E.Nombre AS [Estado], 
                        S.id_Estatus 
                        FROM Solicitud_Servicios S
                        INNER JOIN Estatus E ON S.id_Estatus = E.id_Estatus
                        WHERE S.id_Usuarios = @idUsu AND S.id_Estatus IN (1, 2)";
                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.AddWithValue("@idUsu", idUsuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { Desconectar(); }
            return dt;
        }
        public DataTable MostrarHistorialFinalizado(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                string sql = @"SELECT 
                            S.id_Solicitud_Servicios AS [ID],
                            S.Categoria AS [Categoria],
                            S.descripcionproblema AS [Falla],
                            S.marcaequipo AS [Marca],
                            S.tipodeservicio AS [Servicio],
                            S.fechasolicitud AS [Fecha], 
                            S.horavisita AS [Hora],
                            E.Nombre AS [Estado],
                            S.id_Estatus
                            FROM Solicitud_Servicios S
                            INNER JOIN Estatus E ON S.id_Estatus = E.id_Estatus
                            WHERE S.id_Usuarios = @idUsu AND S.id_Estatus IN (3, 4, 5)
                            ORDER BY S.id_Estatus ASC"; 
                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.AddWithValue("@idUsu", idUsuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Error: " + ex.Message);
            }
            finally 
            { 
                Desconectar(); 
            }
            return dt;
        }
        public bool CancelarSolicitudPorCliente(int idSol, string motivo)
        {
            try
            {
                Conectar();
                // Cambiamos el estatus a 4 (Cancelado por Cliente)
                string sql = @"UPDATE Solicitud_Servicios 
                            SET id_Estatus = 4, 
                            motivo_cancelacion = @motivo 
                            WHERE id_Solicitud_Servicios = @id";
                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.AddWithValue("@id", idSol);
                cmd.Parameters.AddWithValue("@motivo", motivo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar: " + ex.Message);
                return false;
            }
            finally { Desconectar(); }
        }
        public static class PasswordHelper
        {
            // Genera hash y sal a partir de la contraseña
            public static (string hash, string salt) HashPassword(string password)
            {
                // Crear sal aleatoria de 16 bytes
                byte[] saltBytes = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(saltBytes);
                }
                // Generar hash con PBKDF2
                var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
                byte[] hashBytes = pbkdf2.GetBytes(32);
                // Convertir a Base64 para guardar en la BD
                string saltBase64 = Convert.ToBase64String(saltBytes);
                string hashBase64 = Convert.ToBase64String(hashBytes);
                return (hashBase64, saltBase64);
            }
            // Verifica si la contraseña ingresada coincide con hash y sal guardados
            public static bool VerifyPassword(string password, string storedHash, string storedSalt)
            {
                byte[] saltBytes = Convert.FromBase64String(storedSalt);
                var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
                byte[] hashBytes = pbkdf2.GetBytes(32);
                string hashBase64 = Convert.ToBase64String(hashBytes);
                return hashBase64 == storedHash;
            }
        }
        public DataTable BuscarDetallesCompletos(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                string sql = @"SELECT S.*, U.* 
                             FROM Solicitud_Servicios S
                             INNER JOIN Usuarios U ON S.id_Usuarios = U.id_Usuarios
                             WHERE S.id_Solicitud_Servicios = @id";
                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar detalles: " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }
        public bool GuardarReseña(int calificacion, string comentario, int idPedido, string emisor)
        {
            try
            {
                Conectar();
                string sqlGetId = "SELECT id_Pedidos_Agendados FROM Pedidos_Agendados WHERE id_Solicitud_Servicios = @idSol";
                SqlCommand cmdId = new SqlCommand(sqlGetId, conectada);
                cmdId.Parameters.AddWithValue("@idSol", idPedido);
                object result = cmdId.ExecuteScalar();
                if (result != null)
                {
                    int idAgendado = Convert.ToInt32(result);
                    string sqlInsert = @"INSERT INTO [Reseña] 
                                      ([calificacion], [comentario], [fecha], [emisor], [id_Pedidos_Agendados]) 
                                      VALUES 
                                      (@cal, @com, GETDATE(), @emi, @idAgendado)";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conectada);
                    cmd.Parameters.AddWithValue("@cal", calificacion);
                    cmd.Parameters.AddWithValue("@com", comentario);
                    cmd.Parameters.AddWithValue("@emi", emisor);
                    cmd.Parameters.AddWithValue("@idAgendado", idAgendado); 
                    cmd.ExecuteNonQuery();

                    string sqlUpdateEstatus = "UPDATE Solicitud_Servicios SET id_Estatus = 5 WHERE id_Solicitud_Servicios = @idSol";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdateEstatus, conectada);
                    cmdUpdate.Parameters.AddWithValue("@idSol", idPedido); 
                    cmdUpdate.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No se encontró el registro de agenda para esta solicitud.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al guardar reseña: " + ex.Message);
                return false;
            }
            finally
            {
                Desconectar();
            }
        }
        public DataTable MostrarServiciosParaCalificar(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                string sql = @"SELECT id_Solicitud_Servicios AS [ID], fechasolicitud AS [Fecha], 
                             marcaequipo AS [Aparato], tipodeservicio AS [Servicio]
                             FROM Solicitud_Servicios 
                             WHERE id_Usuarios = @idUsu AND id_Estatus = 3";
                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.AddWithValue("@idUsu", idUsuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                Desconectar();
            }
            return dt;
        }
        public DataTable HistorialFinalizadoTecnico(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                string sql = @"
                SELECT 
                S.id_Solicitud_Servicios,
                U.nombre + ' ' + U.apellido AS [Cliente],
                U.calle AS [Calle],
                U.nomenclatura AS [Num Exterior],
                U.colonia AS [Colonia],
                U.entrecalles AS [Entre Calles],
                U.codigopostal AS [CP],
                U.municipio AS [Municipio],
                U.telefono AS [Teléfono],
                U.correo AS [Correo],
                S.Categoria AS [Equipo],
                S.tipodeservicio AS [Servicio],
                S.descripcionproblema AS [Falla],
                S.antiguedadequipo AS [Antigüedad],
                S.tipopago AS [Pago],
                S.fechasolicitud AS [Fecha Visita],
                S.horavisita AS [Hora Visita],
                S.marcaequipo AS [Marca],
                PA.costoreparacion AS [Costo]
                FROM Solicitud_Servicios S
                INNER JOIN Usuarios U ON S.id_Usuarios = U.id_Usuarios
                INNER JOIN Pedidos_Agendados PA ON S.id_Solicitud_Servicios = PA.id_Solicitud_Servicios
                WHERE PA.id_Tecnicos = @id AND (S.id_Estatus = 3 OR S.id_Estatus = 5)
                ORDER BY S.id_Solicitud_Servicios DESC"; 

                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            { 
                Desconectar();
            }
            return dt;
        }
        public Image ObtenerFotoPerfilUsuario(int idUsuario)
        {
            string query = "SELECT foto FROM Usuarios WHERE id_Usuarios = @id";
            using (SqlConnection con = new SqlConnection(conectada.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                con.Open();

                object resultado = cmd.ExecuteScalar();
                if (resultado != DBNull.Value && resultado != null)
                {
                    byte[] imagenBytes = (byte[])resultado;
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            return null;
        }
        public void ActualizarFotoPerfilUsuario(int idUsuario, Image imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convertimos la imagen a bytes
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imagenBytes = ms.ToArray();
                string query = "UPDATE Usuarios SET foto = @foto WHERE id_Usuarios = @id";
                using (SqlConnection con = new SqlConnection(conectada.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = imagenBytes;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Image ObtenerFotoPerfilTecnico(int idUsuario)
        {
            string query = "SELECT foto FROM Tecnicos WHERE id_Tecnicos = @id";
            using (SqlConnection con = new SqlConnection(conectada.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                con.Open();
                object resultado = cmd.ExecuteScalar();
                if (resultado != DBNull.Value && resultado != null)
                {
                    byte[] imagenBytes = (byte[])resultado;
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            return null;
        }
        public void ActualizarFotoPerfilTecnico(int idUsuario, Image imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imagenBytes = ms.ToArray();
                string query = "UPDATE Tecnicos SET foto = @foto WHERE id_Tecnicos = @id";
                using (SqlConnection con = new SqlConnection(conectada.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = imagenBytes;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable ObtenerPerfilTecnicoAsignado(int idSolicitud)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT T.nombre, T.apellidos, T.correo, T.telefono, 
                         T.añosdeexperiencia, T.Genero, T.fotopersonal 
                         FROM Pedidos_Agendados P
                         INNER JOIN Tecnicos T ON P.id_Tecnicos = T.id_Tecnicos
                         WHERE P.id_Solicitud_Servicios = @id";
            try
            {
                if (conectada.State == ConnectionState.Closed) conectada.Open();
                SqlCommand cmd = new SqlCommand(sql, conectada);
                cmd.Parameters.AddWithValue("@id", idSolicitud);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {
            }
            finally 
            {
                Desconectar();
            }
            return dt;
        }
        public bool RestablecerPasswordTecnico(string nombre, string apellidos, string correo,string telefono, string contraseña )
        {
            var resultado = PasswordHelper.HashPassword(contraseña);
            string nuevoHash = resultado.hash; 
            string nuevoSalt = resultado.salt;
            try
            {
                Conectar();
                string query = "UPDATE Tecnicos SET Contraseña = @contraseña, Hash = @hash, Salt = @salt " +
                               "WHERE nombre = @nom AND apellidos = @ape AND Telefono =@tel AND correo = @corr  ";
                SqlCommand cmd = new SqlCommand(query, conectada);
                cmd.Parameters.AddWithValue("@hash", nuevoHash);
                cmd.Parameters.AddWithValue("@salt", nuevoSalt);
                cmd.Parameters.AddWithValue("@nom", nombre);
                cmd.Parameters.AddWithValue("@ape", apellidos);
                cmd.Parameters.AddWithValue("@tel", telefono);
                cmd.Parameters.AddWithValue("@corr", correo);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                              
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                Desconectar();
            }
        }
        public bool RestablecerPasswordUsuario(string nombre, string apellidos, string correo,string telefono, string contraseña)
        {
            var resultado = PasswordHelper.HashPassword(contraseña);
            string nuevoHash = resultado.hash; 
            string nuevoSalt = resultado.salt;
            try
            {
                Conectar();
                string query = "UPDATE Usuarios SET Contraseña = @contraseña, Hash = @hash, Salt = @salt " +
                               "WHERE nombre = @nombre AND apellido = @apellido AND Telefono = @telefono AND correo = @correo ";
                SqlCommand cmd = new SqlCommand(query, conectada);
                cmd.Parameters.AddWithValue("@hash", nuevoHash);
                cmd.Parameters.AddWithValue("@salt", nuevoSalt);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellidos);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                Desconectar();
            }
        }
        public void messageinfo()
        {
            MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }       
}
