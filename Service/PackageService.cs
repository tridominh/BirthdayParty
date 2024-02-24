using BirthdayParty.Models;
using BirthdayParty.Repository;
using BirthdayParty.Repository.Interfaces;
using Service.Interfaces;

namespace Service
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
    }
}
