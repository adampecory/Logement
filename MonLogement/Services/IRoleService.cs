using MonLogement.Models;
using System;
using System.Net.Http;
namespace MonLogement.Services
{
    interface IService<T> where T:class
    {
        HttpResponseMessage GetAll();
        HttpResponseMessage GetbyId(long id);
        HttpResponseMessage GetbyName(string name);
        HttpResponseMessage Add(T obj);
        HttpResponseMessage Update(T obj);
        HttpResponseMessage Delete(long id);
    }
}
