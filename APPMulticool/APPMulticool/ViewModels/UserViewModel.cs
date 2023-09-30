using System;
using System.Collections.Generic;
using System.Text;
using APPMulticool.Models;
using System.Threading.Tasks;

namespace APPMulticool.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public Usuario MyUsuario { get; set; }
        public UsuarioDTO MyUsuarioDTO { get; set; }
        public TipoUsuario MyTipoUsuario { get; set; }
        public Cliente MyCliente { get; set; }
        public Pedido MyPedido { get; set; }
        public Repuesto MyRepuesto { get; set; }
        public Herramienta MyHerramienta { get; set; }
        public TipoRepuesto MyTipoRepuesto { get; set; }
        public Producto MyProducto { get; set; }
        public TipoProducto MyTipoProducto { get; set; }
        public CodigoRecuperacion MyCodigoRec { get; set; }
        public Models.Email MyEmail { get; set; }
        public UserViewModel()
        {
            MyUsuario = new Usuario();
            MyUsuarioDTO = new UsuarioDTO();
            MyTipoUsuario = new TipoUsuario();
            MyCliente = new Cliente();
            MyPedido = new Pedido();
            MyRepuesto = new Repuesto();
            MyHerramienta = new Herramienta();
            MyTipoRepuesto = new TipoRepuesto();
            MyProducto = new Producto();
            MyTipoProducto = new TipoProducto();
            MyCodigoRec = new CodigoRecuperacion();
            MyEmail = new Models.Email();
        }
        public async Task<UsuarioDTO> GetUsuarioData(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                UsuarioDTO usuario = new UsuarioDTO();
                usuario = await MyUsuarioDTO.GetUsuarioData(pNombre);
                if (usuario == null)
                {
                    return null;
                }
                else
                {
                    return usuario;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> UsuarioAccessValidation(string pNombre, string pContra)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUsuario.NombreUs = pNombre;
                MyUsuario.ContrasUs = pContra;
                bool R = await MyUsuario.ValidateLogin();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<List<TipoUsuario>> GetTipoUsuario()
        {
            try
            {
                List<TipoUsuario> tipoUs = new List<TipoUsuario>();
                tipoUs = await MyTipoUsuario.GetAllTipoUsuarioList();
                if (tipoUs == null)
                {
                    return null;
                }
                else
                {
                    return tipoUs;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Usuario>> GetNombreUsuario(string pNombre)
        {
            try
            {
                List<Usuario> nombreUs = new List<Usuario>();
                nombreUs = await MyUsuario.GetAllUserNameList(pNombre);
                if (nombreUs == null)
                {
                    return null;
                }
                else
                {
                    return nombreUs;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Usuario>> GetUsuario()
        {
            try
            {
                List<Usuario> us = new List<Usuario>();
                us = await MyUsuario.GetAllUsuarioList();
                if (us == null)
                {
                    return null;
                }
                else
                {
                    return us;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Repuesto>> GetRepuesto()
        {
            try
            {
                List<Repuesto> rep = new List<Repuesto>();
                rep = await MyRepuesto.GetAllRepuestoList();
                if (rep == null)
                {
                    return null;
                }
                else
                {
                    return rep;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Cliente>> GetCliente()
        {
            try
            {
                List<Cliente> cli = new List<Cliente>();
                cli = await MyCliente.GetAllClienteList();
                if (cli == null)
                {
                    return null;
                }
                else
                {
                    return cli;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Herramienta>> GetHerramienta()
        {
            try
            {
                List<Herramienta> her = new List<Herramienta>();
                her = await MyHerramienta.GetAllHerramientaList();
                if (her == null)
                {
                    return null;
                }
                else
                {
                    return her;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<TipoRepuesto>> GetTipoRepuesto()
        {
            try
            {
                List<TipoRepuesto> tr = new List<TipoRepuesto>();
                tr = await MyTipoRepuesto.GetAllTipoRepuestoList();
                if (tr == null)
                {
                    return null;
                }
                else
                {
                    return tr;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Producto>> GetProducto()
        {
            try
            {
                List<Producto> prod = new List<Producto>();
                prod = await MyProducto.GetAllProductoList();
                if (prod == null)
                {
                    return null;
                }
                else
                {
                    return prod;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> AddUsuario(string pNombreUs, 
            string pContraUs, int pTipo)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUsuario.NombreUs = pNombreUs;
                MyUsuario.ContrasUs = pContraUs;
                MyUsuario.FKTipoUsuario = pTipo;
                bool R = await MyUsuario.AddUsuario();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddTipoUsuario(string pNombreTU)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoUsuario.NombreTU = pNombreTU;
                bool R = await MyTipoUsuario.AddTipoUsuario();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddCliente(string pNombreCli, string pApellido,
            int pCedula, string pDireccion)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCliente.NombreCli = pNombreCli;
                MyCliente.ApellidoCli = pApellido;
                MyCliente.CedulaCli = pCedula;
                MyCliente.DireccionCli = pDireccion;
                bool R = await MyCliente.AddCliente();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddPedido(string pDescripcionPed, DateTime pFecha,
            int pRep, int pCli, int pUs, int pProd)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyPedido.DescripcionPed = pDescripcionPed;
                MyPedido.FechaPed = pFecha;
                MyPedido.FKRep = pRep;
                MyPedido.FKCli = pCli;
                MyPedido.FKUs = pUs;
                MyPedido.FKProd = pProd;
                bool R = await MyPedido.AddPedido();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddRepuesto(bool pCompletoRep, string pDescripcionRep, int pTR,
            int pHer)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyRepuesto.CompletoRep = pCompletoRep;
                MyRepuesto.DescripcionRep = pDescripcionRep;
                MyRepuesto.FKTipoRep = pTR;
                MyRepuesto.FKHerramientas = pHer;
                bool R = await MyRepuesto.AddRepuesto();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddHerramienta(string pNombreHer, int pNumero)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyHerramienta.NombreHer = pNombreHer;
                MyHerramienta.NumeroHer = pNumero;
                bool R = await MyHerramienta.AddHerramienta();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddTipoRepuesto(string pDescripcionTR)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoRepuesto.DescripcionTR = pDescripcionTR;
                bool R = await MyTipoRepuesto.AddTipoRepuesto();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddProducto(string pNombreProd, int pTP)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyProducto.NombreProd = pNombreProd;
                MyProducto.FKTipoProd = pTP;
                bool R = await MyProducto.AddProducto();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddTipoProducto(string pNombreTP)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoProducto.NombreTP = pNombreTP;
                bool R = await MyTipoProducto.AddTipoProducto();
                return R;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> AddCodigoRecuperacion(string pEmail)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCodigoRec.Email = pEmail;
                var rand = new Random();
                var letras = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var numeros = ("123456789");
                string randLetras = "";
                string randNumeros = "";
                for (int i = 0; i < 3; i++)
                {
                    int o = rand.Next(26);
                    randLetras += letras[o];
                }
                for (int i = 0; i < 3; i++)
                {
                    int o = rand.Next(9);
                    randLetras += numeros[o];
                }
                string codigo = randLetras + randNumeros;
                MyCodigoRec.CodigoRec = codigo;
                MyCodigoRec.IDCR = 0;
                MyCodigoRec.FechaCR = DateTime.Now;
                bool R = await MyCodigoRec.AddCodigoRecuperacion();
                if (R)
                {
                    MyEmail.SendTo = pEmail;
                    MyEmail.Subject = "Codigo de recuperacion - Multicool";
                    MyEmail.Message = string.Format("El codigo es: {0}", codigo);
                    R = MyEmail.SendEmail();
                }
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> ValidacionCodigoRecuperacion(string pEmail, string pCodigo)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCodigoRec.Email = pEmail;
                MyCodigoRec.CodigoRec = pCodigo;
                bool R = await MyCodigoRec.ValidarCodigoRec();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<bool> UpdateUsuario(UsuarioDTO pUsuario)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyUsuario.AddUsuario();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
