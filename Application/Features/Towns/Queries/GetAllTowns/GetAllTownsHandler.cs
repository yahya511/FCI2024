// Application/Features/Towns/Queries/GetAllTowns/GetAllTownsHandler.cs
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Domain.Models;
using Application.Features.Towns.Queries.GetAllTowns;

namespace Application.Features.Towns.Queries.GetAllTowns
{
    public class GetAllTownsHandler : IRequestHandler<GetAllTownsRequest, IEnumerable<Town>>
    {
        private readonly IGenericRepository<Town> _townRepository;

        public GetAllTownsHandler(IGenericRepository<Town> townRepository)
        {
            _townRepository = townRepository;
        }

        public async Task<IEnumerable<Town>> Handle(GetAllTownsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _townRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                // يمكنك استخدام ILogger لتسجيل الخطأ
                // Log.Error(ex, "An error occurred while retrieving towns.");
                throw new Exception("Handle error occurred while retrieving towns.", ex);
            }
        }
    }
}
