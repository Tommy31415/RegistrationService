using MediatR;
using RegistrationService.Models;

namespace RegistrationService.Handlers
{
    public class RegisterCustomerCommand : INotification
    {
        public Customer Customer { get; set; }
    }
}