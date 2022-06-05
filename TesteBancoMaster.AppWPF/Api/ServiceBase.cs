using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace TesteBancoMaster.AppWPF.Api
{

    class Resultado
    {
        public string Message { get; set; }
    }

    class ServiceBase
    {
        public ServiceBase()
        {
            ClientHttp = new HttpClient();
            ClientHttp.BaseAddress = new Uri("http://localhost:25433/api/");
            ClientHttp.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected HttpClient ClientHttp { get; set; }

        protected HttpResponseMessage RequisicaoGet(string url)
        {
            HttpResponseMessage response = ClientHttp.GetAsync(url).Result;

            ObterResposta(response);

            return response;
        }

        protected HttpResponseMessage RequisicaoPost<T>(string url, T conteudo)
        {
            HttpResponseMessage response = ClientHttp.PostAsJsonAsync(url, conteudo).Result;
            ObterResposta(response);
            return response;
        }

        protected void ObterResposta(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                ProcessarStatusCode(response);
            }
        }

        protected T ObterResposta<T>(HttpResponseMessage response)
        {
            ObterResposta(response);
            string jsonString = response.Content.ReadAsStringAsync().Result;

            return System.Text.Json.JsonSerializer.Deserialize<T>(jsonString);
        }

        protected void ProcessarStatusCode(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;                
                throw new ApplicationException(System.Text.Json.JsonSerializer.Deserialize<Resultado>(jsonString).Message);
            }

            response.EnsureSuccessStatusCode();
        }

    }
}
