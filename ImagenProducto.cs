using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BRAMSELU.ClasesProducto
{
    class ImagenProducto
    {
        public byte[] ImagenABytes(Image imagen)
        {
            if (imagen == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                
                imagen.Save(ms, ImageFormat.Png);

                return ms.ToArray();
            }
        }

        public Image BytesAImagen(byte[] datos)
        {
            if (datos == null || datos.Length == 0)
                return null;

            MemoryStream ms = new MemoryStream(datos);

            return Image.FromStream(ms);
        }
    }
}