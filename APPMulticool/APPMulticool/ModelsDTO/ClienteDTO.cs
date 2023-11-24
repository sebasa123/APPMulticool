using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace APPMulticool.ModelsDTO
{
    public class ClienteDTO
    {
        public RestRequest Request { get; set; }
        public int IDCli { get; set; }
        public string NombreCli { get; set; }
        public string ApellidoCli { get; set; }
        public int CedulaCli { get; set; }
        public string DireccionCli { get; set; }
        public bool EstadoCli { get; set; }
        public async Task<ClienteDTO> GetClienteData(string nombre)
        {
            try
            {
                string RouteSuffix =
                    string.Format("Clientes/GetClienteData?NombreCli={0}", nombre);
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
                        JsonConvert.DeserializeObject<List<ClienteDTO>>(response.Content);
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

        public async Task<bool> UpdateCliente()
        {
            try
            {

                string RouteSufix = string.Format("Clientes/PutCliente/{0}", this.IDCli);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Put);
                Request.RequestFormat = DataFormat.Json;
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                Request.AddJsonBody(
                    new
                    {
                        idcli = this.IDCli,
                        nombreCli = this.NombreCli,
                        apellidoCli = this.ApellidoCli,
                        cedulaCli = this.CedulaCli,
                        direccionCli = this.DireccionCli,
                        estadoCli = this.EstadoCli
                    });
                //string SerializedModel = JsonConvert.SerializeObject(this);
                //Request.AddBody(SerializedModel, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.NoContent)
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
