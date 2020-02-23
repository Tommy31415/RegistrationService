using MediatR;
using RegistrationService.Models;

namespace RegistrationService.Handlers
{
    public class GetCustomersRequest : IRequest<Customer[]>
    {
    }
}