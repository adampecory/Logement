

using MonLogement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace MonLogement.Services
{
    public class RoleService
    {
        string baseAPI = System.Configuration.ConfigurationManager.AppSettings["LogementAPI"];

        public void Add(Role role)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string,string>("Id",role.Id.ToString()),
                        new KeyValuePair<string,string>("Name",role.Name.ToString())
                    });
                var response = client.PostAsync("roles", content).Result;
                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException("Ajout impossible : " + response.ReasonPhrase);
            }
        }

        public IEnumerable<Role> GetAll()
        {
            IEnumerable<Role> roles = new List<Role>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                var response = client.GetAsync("roles").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    roles = JsonConvert.DeserializeObject<IEnumerable<Role>>(responseString);
                }
                return roles;
            }
        }

        public Role GetbyId(long id)
        {
            var role = new Role();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                var response = client.GetAsync("roles/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    role = JsonConvert.DeserializeObject<Role>(responseString);
                }
            }
            return role;
        }

        public Role GetbyName(string name)
        {
            var role = new Role();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                var response = client.GetAsync("roles/name/" + name).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    role = JsonConvert.DeserializeObject<Role>(responseString);
                }
            }
            return role;
        }

        public void Update(Role role)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string,string>("Id",role.Id.ToString()),
                        new KeyValuePair<string,string>("Name",role.Name.ToString())
                    });
                var response = client.PutAsync("roles/" + role.Id, content).Result;
            }
        }

        public void Delete(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                var response = client.DeleteAsync("roles/" + id).Result;
            }
        }
    }
}