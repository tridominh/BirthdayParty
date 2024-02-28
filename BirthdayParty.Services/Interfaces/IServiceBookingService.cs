using BirthdayParty.Models;

namespace BirthdayParty.Services.Interfaces
{
    public interface IServiceBookingService
    {
        List<Service> GetAllServices();
        Service GetServiceById(int id);
        Service UpdateService(Service updatedService);
        Service DeleteService(int id);
        public void CreateService(Service service);
    }
}
