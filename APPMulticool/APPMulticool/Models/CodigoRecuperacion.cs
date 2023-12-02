using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace APPMulticool.Models
{
    public class CodigoRecuperacion
    {
        public RestRequest Request { get; set; }
        public int IDCR { get; set; }
        public string CodigoRec { get; set; }
        public bool EstadoCR { get; set; }
        public DateTime FechaCR { get; set; }
        public string Email { get; set; }
        public int FKUsuario { get; set; }
        //public virtual Usuario CRXUs { get; set; }
        public async Task<bool> ValidarCodigoRec()
        {
            try
            {
                string RouteSuffix =
                string.Format("CodigoRecuperacions/ValidateCode?pEmail={0}&pCodigo={1}",
                this.Email, this.CodigoRec);
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
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }
        public async Task<bool> AddCodigoRecuperacion()
        {
            try
            {
                string RouteSuffix = 
                string.Format("CodigoRecuperacions/PostCodigoRecuperacion");
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Post);
                Request.RequestFormat = DataFormat.Json;
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                Request.AddJsonBody(
                   new
                   {
                       idcr = this.IDCR,
                       codigoRec = this.CodigoRec,
                       estadoCr = this.EstadoCR,
                       fechaCr = this.FechaCR,
                       email = this.Email,
                       fkusuario = this.FKUsuario
                   });
                //string SerializedModel = JsonConvert.SerializeObject(this);
                //Request.AddBody(SerializedModel, GlobalObjects.MimeType);
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
