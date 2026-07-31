using System;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace BRAMSELU.Ventas
{
    public class GeneradorFactura
    {
        public void GenerarYMostrar(DataTable dtCarrito, decimal totalGeneral, decimal efectivoRecibido, decimal cambio)
        {
            try
            {
                string rutaArchivo = Path.Combine(Path.GetTempPath(), $"Factura_{DateTime.Now:yyyyMMdd_HHmmss}.html");

                // Diseño optimizado con estilo de factura formal listo para imprimir o guardar como PDF
                string html = @"
                <html>
                <head>
                    <meta charset='utf-8'>
                    <style>
                        body {
                            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                            margin: 30px;
                            color: #333;
                            background-color: #fff;
                        }
                        .factura-box {
                            max-width: 700px;
                            margin: auto;
                            padding: 30px;
                            border: 1px solid #e0e0e0;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.05);
                            border-radius: 8px;
                        }
                        .encabezado {
                            text-align: center;
                            border-bottom: 2px solid #2980b9;
                            padding-bottom: 15px;
                            margin-bottom: 20px;
                        }
                        .encabezado h1 {
                            margin: 0;
                            color: #2c3e50;
                            font-size: 26px;
                            letter-spacing: 1px;
                        }
                        .encabezado p {
                            margin: 4px 0;
                            color: #7f8c8d;
                            font-size: 13px;
                        }
                        .info-factura {
                            margin-bottom: 20px;
                            font-size: 14px;
                            color: #555;
                        }
                        .info-factura table {
                            width: 100%;
                            border: none;
                        }
                        .info-factura td {
                            border: none;
                            padding: 2px 0;
                        }
                        table.tabla-productos {
                            width: 100%;
                            border-collapse: collapse;
                            margin-top: 10px;
                        }
                        table.tabla-productos th, table.tabla-productos td {
                            border: 1px solid #dfe6e9;
                            padding: 10px;
                            font-size: 13px;
                        }
                        table.tabla-productos th {
                            background-color: #2980b9;
                            color: white;
                            text-transform: uppercase;
                            font-size: 12px;
                        }
                        table.tabla-productos tr:nth-child(even) {
                            background-color: #f8f9fa;
                        }
                        .seccion-totales {
                            margin-top: 20px;
                            float: right;
                            width: 280px;
                            font-size: 14px;
                        }
                        .seccion-totales table {
                            width: 100%;
                            border-collapse: collapse;
                        }
                        .seccion-totales td {
                            padding: 6px 8px;
                            border: 1px solid #dfe6e9;
                        }
                        .seccion-totales td.etiqueta {
                            font-weight: bold;
                            background-color: #f1f2f6;
                        }
                        .limpiar {
                            clear: both;
                        }
                        .footer {
                            text-align: center;
                            margin-top: 40px;
                            border-top: 1px dashed #bdc3c7;
                            padding-top: 15px;
                            color: #7f8c8d;
                            font-size: 12px;
                        }
                    </style>
                </head>
                <body>
                    <div class='factura-box'>
                        <div class='encabezado'>
                            <h1>BRAMSELÚ</h1>
                            <p>Sistema de Ventas e Inventario</p>
                            <p>Teléfono: +504 0000-0000 | Correo: ventas@bramselu.com</p>
                        </div>

                        <div class='info-factura'>
                            <table>
                                <tr>
                                    <td><b>Comprobante:</b> Venta Física</td>
                                    <td style='text-align: right;'><b>Fecha:</b> " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + @"</td>
                                </tr>
                                <tr>
                                    <td><b>Tipo de Pago:</b> Contado / Efectivo</td>
                                    <td style='text-align: right;'><b>Cajero:</b> Principal</td>
                                </tr>
                            </table>
                        </div>

                        <table class='tabla-productos'>
                            <tr>
                                <th style='width: 10%; text-align: center;'>Cód</th>
                                <th style='width: 45%;'>Descripción del Producto</th>
                                <th style='width: 15%; text-align: center;'>Cant</th>
                                <th style='width: 15%; text-align: right;'>Precio</th>
                                <th style='width: 15%; text-align: right;'>Subtotal</th>
                            </tr>";

                // Agregar cada producto del carrito dinámicamente
                foreach (DataRow row in dtCarrito.Rows)
                {
                    html += "<tr>";
                    html += $"<td style='text-align: center;'>{row["IdProducto"]}</td>";
                    html += $"<td>{row["Producto"]}</td>";
                    html += $"<td style='text-align: center;'>{row["Cantidad"]}</td>";
                    html += $"<td style='text-align: right;'>L. {Convert.ToDecimal(row["Precio"]):N2}</td>";
                    html += $"<td style='text-align: right;'>L. {Convert.ToDecimal(row["Subtotal"]):N2}</td>";
                    html += "</tr>";
                }

                html += @"
                        </table>

                        <div class='seccion-totales'>
                            <table>
                                <tr>
                                    <td class='etiqueta'>Total a Pagar</td>
                                    <td style='text-align: right;'><b>L. " + totalGeneral.ToString("N2") + @"</b></td>
                                </tr>
                                <tr>
                                    <td class='etiqueta'>Efectivo Recibido</td>
                                    <td style='text-align: right;'>L. " + efectivoRecibido.ToString("N2") + @"</td>
                                </tr>
                                <tr>
                                    <td class='etiqueta'>Cambio (Vuelto)</td>
                                    <td style='text-align: right;'>L. " + cambio.ToString("N2") + @"</td>
                                </tr>
                            </table>
                        </div>

                        <div class='limpiar'></div>

                        <div class='footer'>
                            <p>¡Gracias por su compra en BRAMSELÚ!</p>
                            <p>Conserve este comprobante para cualquier cambio o garantía.</p>
                        </div>
                    </div>
                </body>
                </html>";

                File.WriteAllText(rutaArchivo, html);

                
                Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el comprobante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}