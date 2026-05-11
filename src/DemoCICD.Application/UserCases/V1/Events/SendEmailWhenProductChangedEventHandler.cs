using DemoCICD.Contract.Abstractions.Message;
using DemoCICD.Contract.Services.V1.Product;

namespace DemoCICD.Application.UserCases.V1.Events;
internal class SendEmailWhenProductChangedEventHandler : IDomainEventHandler<DomainEvent.ProductCreated>,
    IDomainEventHandler<DomainEvent.ProductDeleted>, IDomainEventHandler<DomainEvent.ProductUpdated>
{
    // Inject Service to send email here, for example IEmailService _emailService;

    public async Task Handle(DomainEvent.ProductCreated notification, CancellationToken cancellationToken)
    {
        await Task.Delay(1000);
    }

    public async Task Handle(DomainEvent.ProductDeleted notification, CancellationToken cancellationToken)
    {
        await Task.Delay(1000);
    }

    public async Task Handle(DomainEvent.ProductUpdated notification, CancellationToken cancellationToken)
    {
        await Task.Delay(1000);
    }
}
