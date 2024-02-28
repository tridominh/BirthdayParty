using BirthdayParty.Models;

namespace BirthdayParty.Services.Interfaces
{
    public interface IServiceBookingService
    {
        List<Service> GetAllServices();
    }
}
