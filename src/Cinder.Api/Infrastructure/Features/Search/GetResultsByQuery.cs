﻿using System.Threading;
using System.Threading.Tasks;
using Cinder.Api.Infrastructure.Models;
using Cinder.Api.Infrastructure.Services;
using FluentValidation;
using MediatR;

namespace Cinder.Api.Infrastructure.Features.Search
{
    public class GetResultsByQuery
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(m => m.Q).NotEmpty();
            }
        }

        public class Query : IRequest<Model>
        {
            public string Q { get; set; }
        }

        public class Model
        {
            public string Id { get; set; }
            public SearchResultType Type { get; set; }
        }

        public class Handler : IRequestHandler<Query, Model>
        {
            private readonly ISearchService _searchService;

            public Handler(ISearchService searchService)
            {
                _searchService = searchService;
            }

            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                SearchResult result = await _searchService.ExecuteSearch(request.Q).ConfigureAwait(false);

                return new Model {Id = result.Id, Type = result.Type};
            }
        }
    }
}
