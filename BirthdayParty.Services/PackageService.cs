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

        public PackageService(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
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
    }
}
