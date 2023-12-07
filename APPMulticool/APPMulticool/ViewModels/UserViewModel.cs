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
            MyTipoUsuarioDTO = new TipoUsuarioDTO();
            MyClienteDTO = new ClienteDTO();
            MyPedidoDTO = new PedidoDTO();
            MyRepuestoDTO = new RepuestoDTO();
            MyHerramientaDTO = new HerramientaDTO();
            MyTipoRepuestoDTO = new TipoRepuestoDTO();
            MyProductoDTO = new ProductoDTO();
            MyTipoProductoDTO = new TipoProductoDTO();
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
        public async Task<bool> ValidacionCodigoRecuperacion(string pCodigo)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
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
        #endregion

        #region GetNombre
        public async Task<ObservableCollection<Usuario>> GetNombreUsuario(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Usuario> list = new ObservableCollection<Usuario>();
                MyUsuario.NombreUs = pNombre;
                list = await MyUsuario.GetUsuarioListByName();
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
        public async Task<ObservableCollection<TipoUsuario>> GetNombreTipoUsuario(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<TipoUsuario> list = new ObservableCollection<TipoUsuario>();
                MyTipoUsuario.NombreTU = pNombre;
                list = await MyTipoUsuario.GetTipoUsuarioListByName();
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
        public async Task<ObservableCollection<Pedido>> GetNombrePedido(int pCliente)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Pedido> list = new ObservableCollection<Pedido>();
                MyPedido.FKCli = pCliente;
                list = await MyPedido.GetPedidoListByCliente();
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
        public async Task<ObservableCollection<Repuesto>> GetNombreRepuesto(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Repuesto> list = new ObservableCollection<Repuesto>();
                MyRepuesto.DescripcionRep = pNombre;
                list = await MyRepuesto.GetRepuestoListByName();
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
        public async Task<ObservableCollection<TipoRepuesto>> GetNombreTipoRepuesto(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<TipoRepuesto> list = new ObservableCollection<TipoRepuesto>();
                MyTipoRepuesto.DescripcionTR = pNombre;
                list = await MyTipoRepuesto.GetTipoRepuestoListByName();
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
        public async Task<ObservableCollection<Herramienta>> GetNombreHerramienta(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Herramienta> list = new ObservableCollection<Herramienta>();
                MyHerramienta.NombreHer = pNombre;
                list = await MyHerramienta.GetHerramientaListByName();
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
        public async Task<ObservableCollection<Cliente>> GetNombreCliente(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Cliente> list = new ObservableCollection<Cliente>();
                MyCliente.NombreCli = pNombre;
                list = await MyCliente.GetClienteListByName();
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
        public async Task<ObservableCollection<Producto>> GetNombreProducto(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Producto> list = new ObservableCollection<Producto>();
                MyProducto.NombreProd = pNombre;
                list = await MyProducto.GetProductoListByName();
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
        public async Task<ObservableCollection<TipoProducto>> GetNombreTipoProducto(string pNombre)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<TipoProducto> list = new ObservableCollection<TipoProducto>();
                MyTipoProducto.NombreTP = pNombre;
                list = await MyTipoProducto.GetTipoProductoListByName();
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
            string pContraUs, int pTipo, int pIDUs = 0, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUsuario.IDUs = pIDUs;
                MyUsuario.NombreUs = pNombreUs;
                MyUsuario.ContrasUs = pContraUs;
                MyUsuario.FKTipoUsuario = pTipo;
                MyUsuario.EstadoUs = pEstado;
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
        public async Task<bool> AddTipoUsuario(string pNombreTU, int pID = 0)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoUsuario.IDTU = pID;
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
            int pCedula, string pDireccion, int pID = 0, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyCliente.IDCli = pID;
                MyCliente.NombreCli = pNombreCli;
                MyCliente.ApellidoCli = pApellido;
                MyCliente.CedulaCli = pCedula;
                MyCliente.DireccionCli = pDireccion;
                MyCliente.EstadoCli = pEstado;
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
            int pRep, int pCli, int pUs, int pProd, int pID = 0, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyPedido.IDPed = pID;
                MyPedido.DecripcionPed = pDescripcionPed;
                MyPedido.FechaPed = pFecha;
                MyPedido.FKRep = pRep;
                MyPedido.FKCli = pCli;
                MyPedido.FKUs = pUs;
                MyPedido.FKProd = pProd;
                MyPedido.EstadoPed = pEstado;
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
            int pHer, int pIDRep = 0)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyRepuesto.IDRep = pIDRep;
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
        public async Task<bool> AddHerramienta(string pNombreHer, int pNumero,
            int pID = 0, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyHerramienta.IDHer = pID;
                MyHerramienta.NombreHer = pNombreHer;
                MyHerramienta.NumeroHer = pNumero;
                MyHerramienta.EstadoHer = pEstado;
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
        public async Task<bool> AddTipoRepuesto(string pDescripcionTR, int pIDTR = 0)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoRepuesto.IDTR = pIDTR;
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
        public async Task<bool> AddProducto(string pNombreProd, int pTP,
            int pID = 0, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyProducto.IDProd = pID;
                MyProducto.NombreProd = pNombreProd;
                MyProducto.FKTipoProd = pTP;
                MyProducto.EstadoProd = pEstado;
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
        public async Task<bool> AddTipoProducto(string pNombreTP, int pIDTP = 0)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoProducto.IDTP = pIDTP;
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
        public async Task<bool> AddCodigoRecuperacion(string pEmail, int us)
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
                MyCodigoRec.EstadoCR = true;
                MyCodigoRec.FKUsuario = us;
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

        #region Update
        public async Task<bool> UpdateUsuario(int pIDUs, string pNombreUs,
            string pContraUs, int pTipo, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUsuarioDTO.IDUs = pIDUs;
                MyUsuarioDTO.NombreUs = pNombreUs;
                MyUsuarioDTO.ContrasUs = pContraUs;
                MyUsuarioDTO.FKTipoUsuario = pTipo;
                MyUsuarioDTO.EstadoUs = pEstado;
                bool R = await MyUsuarioDTO.UpdateUsuario();
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
        public async Task<bool> UpdateTipoUsuario(int pID, string pNombre)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoUsuarioDTO.IDTU = pID;
                MyTipoUsuarioDTO.NombreTU = pNombre;
                bool R = await MyTipoUsuarioDTO.UpdateTipoUsuario();
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
        public async Task<bool> UpdateCliente(int pID, string pNombre,
            string pApellido, int pCedula, string pDireccion, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyClienteDTO.IDCli = pID;
                MyClienteDTO.NombreCli = pNombre;
                MyClienteDTO.ApellidoCli = pApellido;
                MyClienteDTO.CedulaCli = pCedula;
                MyClienteDTO.DireccionCli = pDireccion;
                MyClienteDTO.EstadoCli = pEstado;
                bool R = await MyClienteDTO.UpdateCliente();
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
        public async Task<bool> UpdatePedido(int pID, string pDesc,
            DateTime pFecha, int pFKRep, int pFKCli, int pFKUs, int pFKProd,
            bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyPedidoDTO.IDPed = pID;
                MyPedidoDTO.DescripcionPed = pDesc;
                MyPedidoDTO.FechaPed = pFecha;
                MyPedidoDTO.FKRep = pFKRep;
                MyPedidoDTO.FKCli = pFKCli;
                MyPedidoDTO.FKUs = pFKUs;
                MyPedidoDTO.FKProd = pFKProd;
                MyPedidoDTO.EstadoPed = pEstado;
                bool R = await MyPedidoDTO.UpdatePedido();
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
        public async Task<bool> UpdateRepuesto(int pID, bool pComp, 
            string pDesc, int pFKTR, int pHer)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyRepuestoDTO.IDRep = pID;
                MyRepuestoDTO.CompletoRep = pComp;
                MyRepuestoDTO.DescripcionRep = pDesc;
                MyRepuestoDTO.FKTipoRep = pFKTR;
                MyRepuestoDTO.FKHerramientas = pHer;
                bool R = await MyRepuestoDTO.UpdateRepuesto();
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
        public async Task<bool> UpdateTipoRepuesto(int pIDTR, string pDesc)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoRepuestoDTO.IDTR = pIDTR;
                MyTipoRepuestoDTO.DescripcionTR = pDesc;
                bool R = await MyTipoRepuestoDTO.UpdateTipoRepuesto();
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
        public async Task<bool> UpdateHerramienta(int pID, string pNombre, 
            int pNumero, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyHerramientaDTO.IDHer = pID;
                MyHerramientaDTO.NombreHer = pNombre;
                MyHerramientaDTO.NumeroHer = pNumero;
                bool R = await MyHerramientaDTO.UpdateHerramienta();
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
        public async Task<bool> UpdateProducto(int pID, string pNombre, 
            int pFKTP, bool pEstado = true)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyProductoDTO.IDProd = pID;
                MyProductoDTO.NombreProd = pNombre;
                MyProductoDTO.FKTipoProd = pFKTP;
                MyProductoDTO.EstadoProd = pEstado;
                bool R = await MyProductoDTO.UpdateProducto();
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
        public async Task<bool> UpdateTipoProducto(int pIDTP, string pNombre)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyTipoProductoDTO.IDTP = pIDTP;
                MyTipoProductoDTO.NombreTP = pNombre;
                bool R = await MyTipoProductoDTO.UpdateTipoProducto();
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