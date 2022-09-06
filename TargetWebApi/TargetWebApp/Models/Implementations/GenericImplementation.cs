using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TargetWebApp.Models.Base;
using TargetWebApp.Models.Interfaces;
using TargetWebApp.Results;
using TargetWebApp.Util;

namespace TargetWebApp.Models.Implementations
{
    public class GenericImplementation<T> : IModel<T> where T : BaseModel
    {
        private readonly string _apiController;
        private readonly string _endPoint;

        public GenericImplementation(string apiController, string endPoint)
        {
            _apiController = apiController;
            _endPoint = endPoint;
        }

        public GenericImplementation(string apiController)
        {
            _apiController = apiController;
            _endPoint = "";
        }
        public T Atualizar(T mod)
        {
            string json = WebApi.Request_PUT(string.Concat(_apiController, "/", _endPoint), JsonConvert.SerializeObject(mod));
            return JsonConvert.DeserializeObject<T>(json);
        }

        public T Registrar(T mod)
        {
            string json = WebApi.Request_POST(string.Concat(_apiController, "/", _endPoint), JsonConvert.SerializeObject(mod));
            return JsonConvert.DeserializeObject<T>(json);
        }

        public ResultAllServices Remover(int id)
        {
            string json = WebApi.Request_DELETE(string.Concat(_apiController, "/", _endPoint), id.ToString());
            return JsonConvert.DeserializeObject<ResultAllServices>(json);
        }

        public List<T> ListarTodos()
        {
            string json = WebApi.Request_GET(string.Concat(_apiController, "/", _endPoint), "");
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
        public T Buscar(int id)
        {
            string json = WebApi.Request_GET(string.Concat(_apiController, "/", _endPoint), id.ToString());
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}