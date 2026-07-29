namespace BRAMSELU.Entidades
{
    public class Inventario
    {
        private int _idProducto;
        private string _nombreProducto;
        private string _marca;
        private int _Idcategoria;
        private string _categoria;
        private decimal _precio;
        private int _stock;
        private byte[] _imagen;

        public Inventario()
        {
            _idProducto = 0;
            _nombreProducto = "";
            _marca = "";
            _Idcategoria = 0;
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

        public int IdCategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
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
    }
}