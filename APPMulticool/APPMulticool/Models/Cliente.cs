using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace APPMulticool.Models
{
    public class Cliente
    {
        public RestRequest Request { get; set; }
        public Cliente() { }
        public int IDCli { get; set; }
        public string NombreCli { get; set; }
        public string ApellidoCli { get; set; }
        public int CedulaCli { get; set; }
        public string DireccionCli { get; set; }
        public bool EstadoCli { get; set; }
        public async Task<bool> AddCliente()
        {
            try
            {
                string RouteSuffix = string.Format("Clientes/PostCliente");
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
        public async Task<List<Cliente>> GetAllClienteList()
        {
            try
            {
                string RouteSuffix = string.Format("Clientes");
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
                    var ClienteLista = JsonConvert.DeserializeObject<List<Cliente>>(response.Content);
                    return ClienteLista;
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
        public async Task<List<Cliente>> GetAllClienteNameList(string pNombre)
        {
            try
            {
                string RouteSuffix = string.Format("Cliente");
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
                    var NombreCliLista = JsonConvert.DeserializeObject<List<Cliente>>(pNombre);
                    return NombreCliLista;
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
        public async Task<ObservableCollection<Cliente>> GetClienteListByName()
        {
            try
            {
                string RouteSuffix = string.Format("Clientes/GetClienteListByNombre?pNombre={0}", this.NombreCli);
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
                    var NombreCliLista = JsonConvert.DeserializeObject<ObservableCollection<Cliente>>(response.Content);
                    return NombreCliLista;
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
        public async Task<bool> DeleteCliente(int pID)
        {
            try
            {
                string RouteSuffix =
                     string.Format("Clientes/DeleteClinte/{0}", pID);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Delete);
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                Request.AddHeader("Accept", "*/*");
                RestResponse response = await client.DeleteAsync(Request);
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
        public async Task<ObservableCollection<Cliente>> GetClientes()
        {
            try
            {
                string RouteSuffix = string.Format("Clientes");
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
                    var ClienteLista = JsonConvert.DeserializeObject<ObservableCollection<Cliente>>(response.Content);
                    return ClienteLista;
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
        public async Task<Cliente> GetClienteID(int pID)
        {
            try
            {
                string RouteSufix = string.Format("Clientes/{0}", pID);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<Cliente>>(response.Content);
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
