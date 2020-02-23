using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RegistrationService.Data;

namespace RegistrationService.Handlers
{
    public class RegisterCustomerCommandHandler : INotificationHandler<RegisterCustomerCommand>
    {
        private readonly DataContext _context;

        public RegisterCustomerCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(RegisterCustomerCommand notification, CancellationToken cancellationToken)
        {
            _context.Customers.Add(notification.Customer);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}