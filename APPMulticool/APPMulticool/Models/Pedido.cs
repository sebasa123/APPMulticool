using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace APPMulticool.Models
{
    public class Pedido
    {
        public RestRequest Request { get; set; }
        public int IDPed { get; set; }
        public string DescripcionPed { get; set; }
        public DateTime FechaPed { get; set; }
        public int FKRep { get; set; }
        public int FKCli { get; set; }
        public int FKUs { get; set; }
        public int FKProd { get; set; }
        public bool EstadoPed { get; set; }
        public virtual Repuesto PedXRep { get; set; }
        public virtual Cliente PedXCli { get; set; }
        public virtual Usuario PedXUs { get; set; }
        public virtual Producto PedXProd { get; set; }
        public async Task<ObservableCollection<Pedido>> GetPedidoListByCliente()
        {
            try
            {
                string RouteSuffix = string.Format("Pedidos/GetPedidoByCliente?pIDCli={0}",
                this.FKCli);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var PedidoLista = JsonConvert.DeserializeObject<ObservableCollection<Pedido>>(response.Content);
                    return PedidoLista;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }
        public async Task<bool> AddPedido()
        {
            try
            {
                string RouteSuffix = string.Format("Pedidos");
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Post);
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                string SerializedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }
    }
}
