﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace APPMulticool.Models
{
    public class Repuesto
    {
        public RestRequest Request { get; set; }
        public Repuesto() { }
        public int IDRep { get; set; }
        public bool CompletoRep { get; set; }
        public string DescripcionRep { get; set; }
        public int FKTipoRep { get; set; }
        public int FKHerramientas { get; set; }
        public virtual TipoRepuesto RepXTR { get; set; }
        public virtual Herramienta RepXHer { get; set; }
        public async Task<bool> AddRepuesto()
        {
            try
            {
                string RouteSuffix = string.Format("Repuesto");
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
        public async Task<List<Repuesto>> GetAllRepuestoList()
        {
            try
            {
                string RouteSuffix = string.Format("Repuestos");
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
                    var RepuestoLista = JsonConvert.DeserializeObject<List<Repuesto>>(response.Content);
                    return RepuestoLista;
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