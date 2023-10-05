using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace APPMulticool.ModelsDTO
{
    public class RepuestoDTO
    {
        public RestRequest Request { get; set; }
        public int IDRep { get; set; }
        public bool CompletoRep { get; set; }
        public string DescripcionRep { get; set; }
        public int FKTipoRep { get; set; }
        public int FKHerramientas { get; set; }
        public async Task<RepuestoDTO> GetRepuestoData(string desc)
        {
            try
            {
                string RouteSuffix =
                    string.Format("Repuestos/GetRepuestoData?DescripcionRep={0}", desc);
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
                        JsonConvert.DeserializeObject<List<RepuestoDTO>>(response.Content);
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
    }
}
