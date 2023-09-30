﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

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
                string RouteSuffix = string.Format("Cliente");
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
    }
}