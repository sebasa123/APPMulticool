using System;
using System.Collections.Generic;
using System.Text;
using APPMulticool.Models;
using APPMulticool.ModelsDTO;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace APPMulticool.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        #region Modelos
        public Usuario MyUsuario { get; set; }
        public UsuarioDTO MyUsuarioDTO { get; set; }
        public TipoUsuario MyTipoUsuario { get; set; }
        public TipoUsuarioDTO MyTipoUsuarioDTO { get; set; }
        public Cliente MyCliente { get; set; }
        public ClienteDTO MyClienteDTO { get; set; }
        public Pedido MyPedido { get; set; }
        public PedidoDTO MyPedidoDTO { get; set; }
        public Repuesto MyRepuesto { get; set; }
        public RepuestoDTO MyRepuestoDTO { get; set; }
        public Herramienta MyHerramienta { get; set; }
        public HerramientaDTO MyHerramientaDTO { get; set; }
        public TipoRepuesto MyTipoRepuesto { get; set; }
        public TipoRepuestoDTO MyTipoRepuestoDTO { get; set; }
        public Producto MyProducto { get; set; }
        public ProductoDTO MyProductoDTO { get; set; }
        public TipoProducto MyTipoProducto { get; set; }
        public TipoProductoDTO MyTipoProductoDTO { get; set; }
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
        #endregion

        #region Usuario
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
        #endregion

        #region GetNombre
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
        public async Task<List<TipoUsuario>> GetNombreTipoUsuario(string pNombre)
        {
            try
            {
                List<TipoUsuario> nombreTu = new List<TipoUsuario>();
                nombreTu = await MyTipoUsuario.GetAllTipoUsuarioNameList(pNombre);
                if (nombreTu == null)
                {
                    return null;
                }
                else
                {
                    return nombreTu;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<TipoRepuesto>> GetNombreTipoRepuesto(string pDescripcion)
        {
            try
            {
                List<TipoRepuesto> descTR = new List<TipoRepuesto>();
                descTR = await MyTipoRepuesto.GetAllTipoRepuestoNameList(pDescripcion);
                if (descTR == null)
                {
                    return null;
                }
                else
                {
                    return descTR;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<TipoProducto>> GetNombreTipoProducto(string pNombre)
        {
            try
            {
                List<TipoProducto> nom = new List<TipoProducto>();
                nom = await MyTipoProducto.GetAllTipoProductoNameList(pNombre);
                if (nom == null)
                {
                    return null;
                }
                else
                {
                    return nom;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Repuesto>> GetNombreRepuesto(string pDesc)
        {
            try
            {
                List<Repuesto> desc = new List<Repuesto>();
                desc = await MyRepuesto.GetAllRepuestoNameList(pDesc);
                if (desc == null)
                {
                    return null;
                }
                else
                {
                    return desc;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Producto>> GetNombreProducto(string pNombre)
        {
            try
            {
                List<Producto> nom = new List<Producto>();
                nom = await MyProducto.GetAllProductoNameList(pNombre);
                if (nom == null)
                {
                    return null;
                }
                else
                {
                    return nom;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Pedido>> GetNombrePedido(string pDesc)
        {
            try
            {
                List<Pedido> desc = new List<Pedido>();
                desc = await MyPedido.GetAllPedidoNameList(pDesc);
                if (desc == null)
                {
                    return null;
                }
                else
                {
                    return desc;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Herramienta>> GetNombreHerramienta(string pNombre)
        {
            try
            {
                List<Herramienta> nom = new List<Herramienta>();
                nom = await MyHerramienta.GetAllHerramientaNameList(pNombre);
                if (nom == null)
                {
                    return null;
                }
                else
                {
                    return nom;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Cliente>> GetNombreCliente(string pNombre)
        {
            try
            {
                List<Cliente> nom = new List<Cliente>();
                nom = await MyCliente.GetAllClienteNameList(pNombre);
                if (nom == null)
                {
                    return null;
                }
                else
                {
                    return nom;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetID
        public async Task<Usuario> GetUsuarioID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                Usuario us = new Usuario();
                us = await MyUsuario.GetUsuarioID(pID);
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
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<TipoUsuario> GetTipoUsuarioID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                TipoUsuario tu = new TipoUsuario();
                tu= await MyTipoUsuario.GetTipoUsuarioID(pID);
                if (tu == null)
                {
                    return null;
                }
                else
                {
                    return tu;
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
        public async Task<Cliente> GetClienteID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                Cliente cli = new Cliente();
                cli = await MyCliente.GetClienteID(pID);
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
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<Pedido> GetPedidoID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                Pedido ped = new Pedido();
                ped = await MyPedido.GetPedidoID(pID);
                if (ped == null)
                {
                    return null;
                }
                else
                {
                    return ped;
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
        public async Task<Repuesto> GetRepuestoID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                Repuesto rep = new Repuesto();
                rep = await MyRepuesto.GetRepuestoID(pID);
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
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<TipoRepuesto> GetTipoRepuestoID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                TipoRepuesto trep = new TipoRepuesto();
                trep = await MyTipoRepuesto.GetTipoRepuestoID(pID);
                if (trep == null)
                {
                    return null;
                }
                else
                {
                    return trep;
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
        public async Task<Herramienta> GetHerramientaID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                Herramienta her = new Herramienta();
                her = await MyHerramienta.GetHerramientaID(pID);
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
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<Producto> GetProductoID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                Producto prod = new Producto();
                prod = await MyProducto.GetProductoID(pID);
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
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task<TipoProducto> GetTipoProductoID(int pID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                TipoProducto tprod = new TipoProducto();
                tprod = await MyTipoProducto.GetTipoProductoID(pID);
                if (tprod == null)
                {
                    return null;
                }
                else
                {
                    return tprod;
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
        #endregion

        #region Get(List)
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
        public async Task<List<TipoProducto>> GetTipoProducto()
        {
            try
            {
                List<TipoProducto> tprod = new List<TipoProducto>();
                tprod = await MyTipoProducto.GetAllTipoProductoList();
                if (tprod == null)
                {
                    return null;
                }
                else
                {
                    return tprod;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Pedido>> GetPedido()
        {
            try
            {
                List<Pedido> ped = new List<Pedido>();
                ped = await MyPedido.GetAllPedidoList();
                if (ped == null)
                {
                    return null;
                }
                else
                {
                    return ped;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get(ObservableCollection)
        public async Task<ObservableCollection<Usuario>> GetUsuarios()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Usuario> list = new ObservableCollection<Usuario>();
                list = await MyUsuario.GetUsuarios();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        public async Task<ObservableCollection<TipoUsuario>> GetTipoUsuarios()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<TipoUsuario> list = new ObservableCollection<TipoUsuario>();
                list = await MyTipoUsuario.GetTipoUsuarios();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        public async Task<ObservableCollection<Pedido>> GetPedidos()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Pedido> list = new ObservableCollection<Pedido>();
                list = await MyPedido.GetPedidos();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        public async Task<ObservableCollection<Cliente>> GetClientes()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Cliente> list = new ObservableCollection<Cliente>();
                list = await MyCliente.GetClientes();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        public async Task<ObservableCollection<Repuesto>> GetRepuestos()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Repuesto> list = new ObservableCollection<Repuesto>();
                list = await MyRepuesto.GetRepuestos();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        public async Task<ObservableCollection<TipoRepuesto>> GetTipoRepuestos()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<TipoRepuesto> list = new ObservableCollection<TipoRepuesto>();
                list = await MyTipoRepuesto.GetTipoRepuestos();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        public async Task<ObservableCollection<Herramienta>> GetHerramientas()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Herramienta> list = new ObservableCollection<Herramienta>();
                list = await MyHerramienta.GetHerramientas();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        public async Task<ObservableCollection<Producto>> GetProductos()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Producto> list = new ObservableCollection<Producto>();
                list = await MyProducto.GetProductos();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        public async Task<ObservableCollection<TipoProducto>> GetTipoProductos()
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<TipoProducto> list = new ObservableCollection<TipoProducto>();
                list = await MyTipoProducto.GetTipoProductos();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
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
        #endregion

        #region Add
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
        #endregion

        #region Delete
        public async Task<bool> DeleteUsuario(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyUsuario.DeleteUser(pID);
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
        public async Task<bool> DeleteTipoUsuario(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyTipoUsuario.DeleteTipoUsuario(pID);
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
        public async Task<bool> DeleteTipoRepuesto(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyTipoRepuesto.DeleteTipoRepuesto(pID);
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
        public async Task<bool> DeleteTipoProducto(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyTipoProducto.DeleteTipoProducto(pID);
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
        public async Task<bool> DeleteRepuesto(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyRepuesto.DeleteRepuesto(pID);
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
        public async Task<bool> DeleteProducto(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyProducto.DeleteProducto(pID);
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
        public async Task<bool> DeletePedido(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyPedido.DeletePedido(pID);
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
        public async Task<bool> DeleteHerramienta(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyHerramienta.DeleteHerramienta(pID);
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
        public async Task<bool> DeleteCliente(int pID)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                bool R = await MyCliente.DeleteCliente(pID);
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
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName =
        null)
        {
            PropertyChanged?.Invoke(this, new
         PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
