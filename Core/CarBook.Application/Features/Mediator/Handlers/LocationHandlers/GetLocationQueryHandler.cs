﻿using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetServiceQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResult
            {
                Name= x.Name,
                LocationID=x.LocationID
            }).ToList();
        }
    }
}
