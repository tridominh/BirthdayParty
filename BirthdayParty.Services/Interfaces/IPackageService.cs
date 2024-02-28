using BirthdayParty.Models;

namespace BirthdayParty.Services.Interfaces
{
    public interface IPackageService
    {
        List<Package> GetAllPackages();
    }
}
