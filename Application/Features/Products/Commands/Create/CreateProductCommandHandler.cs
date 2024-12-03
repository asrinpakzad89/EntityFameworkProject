using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories;

namespace Application.Features.Products.Commands.Create;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IEFRepositories<Product> _productRepository;
    private readonly IMapper _mapper;

    private CreateProductCommand _command;
    public CreateProductCommandHandler(IEFRepositories<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _command = new();
    }

    public async Task<Unit> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        try
        {
            _command = command;
            var product = _mapper.Map<Product>(_command);
            await _productRepository.AddAsync(product, cancellationToken);
            await _productRepository.SaveChangeAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            var mes = ex.Message;
            throw new ApplicationException(mes, ex);
        }
        return Unit.Value;
    }
}
