using BirthdayParty.Models;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;

namespace BirthdayParty.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        public List<Package> GetAllPackages()
        {
            return packageRepository.GetAll().ToList();
        }

        List<Package> IPackageService.GetAllPackages()
        {
            throw new NotImplementedException();
        }
    }
}
