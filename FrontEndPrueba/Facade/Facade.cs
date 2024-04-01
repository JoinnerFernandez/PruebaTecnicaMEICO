using FrontEndPrueba.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace FrontEndPrueba.Facade
{
    public class Facade
    {

        private HttpClient client;
        private string BaseUrl = "https://localhost:7237/api/Prueba/";

        public Facade()
        {
            InicializadorHttpClient();
        }

        #region Metodos para inicializar
        private void InicializadorHttpClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;charset=UTF-8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
        }
        #endregion

        public async Task<T> GetAsync<T>(string path)
        {
            try
            {
                var response = await client.GetAsync(BaseUrl + path);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<T>();
                }
                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + ex.Message.ToString());
            }

        }

        public async Task<T> PostAsync<T>(string path, object data)
        {
            try
            {
                var response = await client.PostAsJsonAsync(BaseUrl + path, data);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<T>();
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + ex.Message.ToString());
            }

        }

        public async Task<bool> PutAsync<T>(string path, object data)
        {
            try
            {
                var response = await client.PutAsJsonAsync(BaseUrl + path, data);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + ex.Message.ToString());
            }
        }

        public async Task<bool> DeleteAsync(string path)
        {
            try
            {
                var response = await client.DeleteAsync(BaseUrl + path);
                if (response.IsSuccessStatusCode)
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
                throw new Exception(ex.InnerException?.Message + ex.Message.ToString());
            }
        }


        public async Task<Usuario> getContactos(string IdUsuario)
        {
            var path = $"getContactos/{IdUsuario}";
            return await GetAsync<Usuario>(path);
        }

        public async Task<bool> postUsuario(Usuario obj)
        {
            var path = "postUsuario";
            return await PostAsync<bool>(path, obj);
        }

        public async Task<bool> postContacto(Contacto obj)
        {
            var path = "postContacto";
            return await PostAsync<bool>(path, obj);
        }

        public async Task<bool> deleteContacto(int id)
        {
            var path = $"deleteContacto/{id}";
            return await DeleteAsync (path);
        }
    }
}
