using System;
using System.Collections.Generic;
using System.Text;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;

namespace APPMulticool
{
    public class GlobalObjects
    {
        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";
        public static UsuarioDTO LocalUsuario = new UsuarioDTO();

        public static UsuarioDTO LocalUs = new UsuarioDTO();
        public static TipoUsuarioDTO LocalTipoUsuario = new TipoUsuarioDTO();
        public static ClienteDTO LocalCliente = new ClienteDTO();
        public static PedidoDTO LocalPedido = new PedidoDTO();
        public static RepuestoDTO LocalRepuesto = new RepuestoDTO();
        public static TipoRepuestoDTO LocalTipoRepuesto = new TipoRepuestoDTO();
        public static HerramientaDTO LocalHerramienta = new HerramientaDTO();
        public static ProductoDTO LocalProducto = new ProductoDTO();
        public static TipoProductoDTO LocalTipoProducto = new TipoProductoDTO();
    }
}
