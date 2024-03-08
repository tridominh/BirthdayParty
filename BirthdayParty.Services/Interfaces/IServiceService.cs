using BirthdayParty.Models;
using BirthdayParty.Models.DTOs;

namespace BirthdayParty.Services.Interfaces
{
    public interface IServiceService
    {
        List<Service> GetAllServices();
        Service GetServiceById(int id);
        Service UpdateService(ServiceUpdateDto updatedService);
        Service DeleteService(int id);
        Service CreateService(ServiceCreateDto service);
    }
}
