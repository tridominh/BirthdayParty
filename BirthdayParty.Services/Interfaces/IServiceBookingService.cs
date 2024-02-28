using BirthdayParty.Models;

namespace BirthdayParty.Services.Interfaces
{
    public interface IServiceBookingService
    {
        List<Service> GetAllServices();
        public Service GetServiceById(int id);
        public Service UpdateService(Service updatedService);
        public Service DeleteService(int id);
        public Service CreateService(Service service);
    }
}
