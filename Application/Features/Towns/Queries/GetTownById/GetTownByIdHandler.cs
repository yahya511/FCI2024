

namespace Application.Features.Towns.Queries.GetTownById
{
    public class GetTownByIdHandler : IRequestHandler<GetTownByIdRequest, Town>
    {
        private readonly IGenericRepository<Town> _townRepository;

        public GetTownByIdHandler(IGenericRepository<Town> townRepository)
        {
            _townRepository = townRepository;
        }

        public async Task<Town> Handle(GetTownByIdRequest request, CancellationToken cancellationToken)
        {
            return await _townRepository.GetByIdAsync(request.TownID);
        }
    }

}
