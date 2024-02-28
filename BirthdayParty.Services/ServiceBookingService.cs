using BirthdayParty.Models;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Service GetServiceById(int id)
        {
            return serviceRepository.GetAll().FirstOrDefault(s => s.ServiceId == id);
        }

        public Service UpdateService(Service updatedService)
        {
            var existingService = serviceRepository.GetAll().FirstOrDefault(s => s.ServiceId == updatedService.ServiceId);

            if (existingService == null)
            {
                throw new ArgumentException("Service not found");
            }

            existingService.ServiceName = updatedService.ServiceName;

            serviceRepository.Update(updatedService);

            return existingService;
        }

        public Service DeleteService(int id)
        {
            var existingService = GetServiceById(id);

            if (existingService == null)
            {
                throw new ArgumentException("Service not found");
            }

            serviceRepository.Delete(id);

            return existingService;
        }

        public void CreateService(Service service)
        {
            serviceRepository.Add(service);
        }


    }
}
