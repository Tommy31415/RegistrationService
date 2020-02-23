using MediatR;

namespace RegistrationService.Handlers
{
    public class DeleteRequest : IRequest<bool>
    {
        public long Id { get; }

        public DeleteRequest(in long id)
        {
            Id = id;
        }
    }
}