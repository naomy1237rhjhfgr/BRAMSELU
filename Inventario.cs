namespace BRAMSELU.Entidades
{
    public class Inventario
    {
        private int _idProducto;
        private string _nombreProducto;
        private string _marca;
        private string _categoria;
        private decimal _precio;
        private int _stock;
        private byte[] _imagen;

        public Inventario()
        {
            _idProducto = 0;
            _nombreProducto = "";
            _marca = "";
            _categoria = "";
            _precio = 0;
            _stock = 0;
            _imagen = null;
        }

        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        public string NombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public byte[] Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        private bool Validar()
        {
            if (_nombreProducto == "")
                return false;

            if (_marca == "")
                return false;

            // Validación rigurosa de los items del ComboBox
            if (_categoria != "Limpiadores" &&
                _categoria != "Exfoliantes" &&
                _categoria != "Tónicos" &&
                _categoria != "Esencias" &&
                _categoria != "Sérums y Ampollas" &&
                _categoria != "Mascarillas" &&
                _categoria != "Contorno de Ojos" &&
                _categoria != "Hidratantes" &&
                _categoria != "Protector Solar" &&
                _categoria != "Tratamientos" &&
                _categoria != "Cuidado de Labios" &&
                _categoria != "Maquillaje Coreano" &&
                _categoria != "Cuidado Corporal" &&
                _categoria != "Cuidado Capilar" &&
                _categoria != "Accesorios")
            {
                return false;
            }

            if (_precio <= 0)
                return false;

            if (_stock < 0)
                return false;

            return true;
        }

        public bool Guardar()
        {
            if (Validar())
            {
                string sqlImagen = _imagen != null ? $"0x{BitConverter.ToString(_imagen).Replace("-", "")}" : "NULL";

                string SQL = $"INSERT INTO Productos(NombreProducto,Marca,Categoria,Precio,Stock,Imagen) VALUES('{_nombreProducto}','{_marca}','{_categoria}',{_precio.ToString(System.Globalization.CultureInfo.InvariantCulture)},{_stock},{sqlImagen})";

                _conexion.EjecutarSQL(SQL);

                return true;
            }

            return false;
        }

        public bool Actualizar()
        {
            if (Validar())
            {
                string sqlImagen = _imagen != null ? $"0x{BitConverter.ToString(_imagen).Replace("-", "")}" : "NULL";

                string SQL = $"UPDATE Productos SET NombreProducto='{_nombreProducto}',Marca='{_marca}',Categoria='{_categoria}',Precio={_precio.ToString(System.Globalization.CultureInfo.InvariantCulture)},Stock={_stock},Imagen={sqlImagen} WHERE IdProducto={_idProducto}";

                _conexion.EjecutarSQL(SQL);

                return true;
            }

            return false;
        }

        public bool Eliminar()
        {
            string SQL = $"DELETE FROM Productos WHERE IdProducto={_idProducto}";

            _conexion.EjecutarSQL(SQL);

            return true;
        }

        public List<Empleado> Listar()
        {
            List<Empleado> lista = new List<Empleado>();

            string SQL = "SELECT * FROM Empleados";

            SqlDataReader dr = _conexion.EjecutarConsulta(SQL);

            while (dr.Read())
            {
                Empleado emp = new Empleado();

                emp.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                emp.Nombre = dr["Nombre"].ToString();
                emp.Apellido = dr["Apellido"].ToString();

                lista.Add(emp);
            }

            dr.Close();

            return lista;
        }

        public bool BuscarPorId(int id)
        {
            string SQL = $"SELECT * FROM Productos WHERE IdProducto={id}";

            SqlDataReader reader = _conexion.EjecutarConsultaUno(SQL);

            if (reader != null)
            {
                _idProducto = reader.GetInt32(0);
                _nombreProducto = reader.GetString(1);
                _marca = reader.GetString(2);
                _categoria = reader.GetString(3);
                _precio = reader.GetDecimal(4);
                _stock = reader.GetInt32(5);

                if (!reader.IsDBNull(6))
                    _imagen = (byte[])reader.GetValue(6);
                else
                    _imagen = null;

                reader.Close();

                return true;
            }

            return false;
        }

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdProducto, NombreProducto, Marca, Categoria, Precio, Stock, Imagen FROM Productos",
                    _conexion.Abrir());

                da.Fill(tabla);

                _conexion.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return tabla;
        }
    }
}