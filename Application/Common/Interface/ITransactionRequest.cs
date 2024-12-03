using MediatR;

namespace Application.Common.Interfaces;

//For CQRS
public class ITransactionRequest<TResponse> : IRequest<TResponse>
{
}
public interface ITransactionRequest : IRequest
{
}
