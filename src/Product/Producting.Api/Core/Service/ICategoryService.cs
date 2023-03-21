using App.Producting.Api.Core.Data.Entities;
using App.Shared.Core.Service;
using Microsoft.AspNetCore.Hosting.Server;

namespace App.Producting.Api.Core.Service;

public interface ICategoryService:IService<Category>
{
    Task<List<Category>> GetAll(string search);
}