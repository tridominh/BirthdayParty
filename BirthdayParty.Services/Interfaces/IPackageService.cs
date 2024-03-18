using BirthdayParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Interfaces
{
    public interface IPackageService
    {
        List<Packages> GetAllPackages();

        List<Service> GetAllServicesByPackageId(int packageId);

        void CreatePackage(Packages package);

        Packages UpdatePackage(int id, Packages package);

        Packages DeletePackage(int id);
    }
}
