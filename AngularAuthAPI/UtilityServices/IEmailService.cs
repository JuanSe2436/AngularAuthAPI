using AngularAuthAPI.Models;

namespace AngularAuthAPI.UtilityServices
{
    public interface IEmailService
    {
        void SendEmail(EmailModel emailModel);   
    }
}
