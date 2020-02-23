using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RegistrationService.Data;

namespace RegistrationService.Handlers
{
    public class UpdateRegistrationRequestHandler : IRequestHandler<UpdateRegistrationRequest,bool>
    {
        private readonly DataContext _context;

        public UpdateRegistrationRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async  Task<bool> Handle(UpdateRegistrationRequest request, CancellationToken cancellationToken)
        {
            var updatedCustomer = request.CustomerRegistration.Customer;
            var customer = _context.Customers.FirstOrDefault(c => c.Id == request.Id);
            if (customer == null) return false;
            customer.Vendor = updatedCustomer.Vendor;
            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.Address = updatedCustomer.Address;
            customer.Additional = updatedCustomer.Additional;
            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}