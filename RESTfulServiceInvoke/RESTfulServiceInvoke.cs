using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulServiceInvoke
{
    public class RESTfulServiceInvoke
    {
        /// <summary>
        /// makes rest service call and return the result as J object 
        /// </summary> 
        /// <typeparam name="J">the data type to return</typeparam>
        /// <param name="serviceUri">The uri of the rest service to invoke</param>
        /// <param name="callMethode">call methed can be POST or GET</param>
        /// <param name="headerParam">parametre used to filte needed data, used only when you need a filter in the server side, used only when callMethode is POST</param>
        /// <returns>return data as type J</returns> 
        public static async Task<J> Invoke<J>(string serviceUri, Metode callMethode, object headerParam = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedJsonRequest = JsonConvert.SerializeObject(headerParam);
                    HttpResponseMessage response = new HttpResponseMessage();
                    switch (callMethode)
                    {
                        case Metode.POST:
                            HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");
                            response = await client.PostAsync(serviceUri, content);
                            break;
                        case Metode.GET:
                            response = await client.GetAsync(serviceUri);
                            break;
                    }

                    response.EnsureSuccessStatusCode();
                    string dataResult = response.Content.ReadAsStringAsync().Result;
                    J jResponse = JsonConvert.DeserializeObject<J>(dataResult);
                    return jResponse;
                }
            }
            catch (Exception ex)
            {
                return default(J);
            }
        }
    }
    public enum Metode
    {
        POST,
        GET
    }
}
