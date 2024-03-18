using BirthdayParty.Models;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Repository;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public List<Packages> GetAllPackages()
        {
            return packageRepository.GetAll(q => q.Include(p => p.Services)).ToList();
        }

        public void CreatePackage(Packages package)
        {
            packageRepository.Add(package);
        }

        public Packages UpdatePackage(int id, Packages package)
        {
            Packages existingPackage = packageRepository.Get(id);

            existingPackage.PackageName = package.PackageName;
            existingPackage.PackageType = package.PackageType;

            packageRepository.Update(existingPackage);

            return existingPackage;
        }

        public Packages DeletePackage(int id)
        {
            Packages package = packageRepository.Delete(id);

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
