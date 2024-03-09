using BirthdayParty.Models;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Repository;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;

namespace BirthdayParty.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository packageRepository;
        private readonly IServiceRepository serviceRepository;

        public PackageService(IPackageRepository packageRepository, IServiceRepository serviceRepository)
        {
            this.packageRepository = packageRepository;
            this.serviceRepository = serviceRepository;
        }

        public List<Package> GetAllPackages()
        {
            return packageRepository.GetAll().ToList();
        }

        public void CreatePackage(Package package)
        {
            packageRepository.Add(package);
        }

        public Package UpdatePackage(int id, Package package)
        {
            Package existingPackage = packageRepository.Get(id);

            existingPackage.PackageName = package.PackageName;
            existingPackage.PackageType = package.PackageType;

            packageRepository.Update(existingPackage);

            return existingPackage;
        }

        public Package DeletePackage(int id)
        {
            Package package = packageRepository.Delete(id);

            return package;
        }

        public List<Service> GetAllServicesByPackageId(int packageId)
        {
            List<Service> services = serviceRepository.GetAll()
                .Where(s => s.PackageId == packageId).ToList();

            return services;
        }
    }
}
