// Application/Features/Towns/Queries/GetAllTowns/GetAllTownsRequest.cs
using MediatR;
using System.Collections.Generic;
using Domain.Models;

namespace Application.Features.Towns.Queries.GetAllTowns
{
    public class GetAllTownsRequest : IRequest<IEnumerable<Town>>

    {
    }
}
