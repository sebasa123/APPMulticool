using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using APPMulticool.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace APPMulticool.ModelsDTO
{
    public class TipoUsuarioDTO
    {
        public RestRequest Request { get; set; }
        public int IDTU { get; set; }
        public string NombreTU { get; set; }
        public async Task<TipoUsuarioDTO> GetTipoUsuarioData(string nombre)
        {
            try
            {
                string RouteSuffix =
                    string.Format("TipoUsuarios/GetTipoUsuarioData?NombreTU={0}", nombre);
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
                        JsonConvert.DeserializeObject<List<TipoUsuarioDTO>>(response.Content);
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
