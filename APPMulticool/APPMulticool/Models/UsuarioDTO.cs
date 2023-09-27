using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using FluentAssertions.Common;
using RestSharp;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APPMulticool.Models
{
    public class UsuarioDTO
    {
        public RestRequest Request { get; set; }
        public int IDUs { get; set; }
        public string NombreUs { get; set; }
        public string ContrasUs { get; set; }
        public int FKTipoUsuario { get; set; }
        public bool EstadoUs { get; set; }
        public async Task<UsuarioDTO> GetUsuarioData(string nombre)
        {
            try
            {
                string RouteSuffix =
                    string.Format("Usuarios/GetUsuarioData?NombreUs={0}", nombre);
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
                        JsonConvert.DeserializeObject<List<UsuarioDTO>>(response.Content);
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
