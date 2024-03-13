using BirthdayParty.Models.LocalImages;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;

namespace BirthdayParty.Services.LocalImages
{
    public class ServiceImageLocalService : IServiceImageLocalService
    {
        private readonly IGenericRepository<ServiceImageLocal> _serviceImageRepository;

        public ServiceImageLocalService(IGenericRepository<ServiceImageLocal> serviceImageRepository)
        {
            _serviceImageRepository = serviceImageRepository;
        }

        public List<ServiceImageLocal> GetAllServiceImages()
        {
            return _serviceImageRepository.GetAll().ToList();
        }

        public ServiceImageLocal GetServiceImage(int id)
        {
            return _serviceImageRepository.Get(id);
        }

        public ServiceImageLocal UpdateServiceImage(ServiceImageLocal updatedImage)
        {
            return _serviceImageRepository.Update(updatedImage);
        }

        public ServiceImageLocal DeleteServiceImage(int id)
        {
            return _serviceImageRepository.Delete(id);
        }

        public ServiceImageLocal CreateServiceImage(ServiceImageLocal image)
        {
            return _serviceImageRepository.Add(image);
        }

    }
}
