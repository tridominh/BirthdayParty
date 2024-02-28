using BirthdayParty.Models;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;

namespace BirthdayParty.Services
{
    public class ServiceBookingService : IServiceBookingService
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceBookingService(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public List<Service> GetAllServices()
        {
            return serviceRepository.GetAll().ToList();
        }

        List<Service> IServiceBookingService.GetAllServices()
        {
            throw new NotImplementedException();
        }
    }
}
