using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace APPMulticool.ModelsDTO
{
    public class PedidoDTO
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
        public async Task<PedidoDTO> GetPedidoData(string desc)
        {
            try
            {
                string RouteSuffix =
                    string.Format("Pedidos/GetPedidoData?DescripcionPed={0}", desc);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType,
                    GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var list =
                        JsonConvert.DeserializeObject<List<PedidoDTO>>(response.Content);
                    var item = list[0];
                    return item;
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

        public async Task<bool> UpdatePedido()
        {
            try
            {

                string RouteSufix = string.Format("Pedidos/{0}", this.IDPed);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Put);
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                string SerializedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
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
