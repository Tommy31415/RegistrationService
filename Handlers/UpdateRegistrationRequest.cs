using MediatR;

namespace RegistrationService.Handlers
{
    public class UpdateRegistrationRequest : IRequest<bool>
    {
        public long Id { get; }
        public RegisterCustomerCommand CustomerRegistration { get; }

        public UpdateRegistrationRequest(in long id, RegisterCustomerCommand customerRegistration)
        {
            Id = id;
            CustomerRegistration = customerRegistration;
        }
    }
}