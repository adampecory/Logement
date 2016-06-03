using System;
namespace MonLogement.Services
{
    interface IRoleService
    {
        System.Net.Http.HttpResponseMessage Add(MonLogement.Models.Role role);
        System.Net.Http.HttpResponseMessage Delete(long id);
        System.Net.Http.HttpResponseMessage GetAll();
        System.Net.Http.HttpResponseMessage GetbyId(long id);
        System.Net.Http.HttpResponseMessage GetbyName(string name);
        System.Net.Http.HttpResponseMessage Update(MonLogement.Models.Role role);
    }
}
