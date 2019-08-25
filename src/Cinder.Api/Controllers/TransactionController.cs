﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Cinder.Api.Infrastructure.Features.Transaction;
using Cinder.Api.Infrastructure.Repositories;
using Cinder.Core.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinder.Api.Controllers
{
    public class TransactionController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(GetTransactions.Model), StatusCodes.Status200OK)]
        public async Task<IPage<GetTransactions.Model>> GetTransactions(int? page, int? size,
            SortOrder sort = SortOrder.Ascending)
        {
            return await Mediator.Send(new GetTransactions.Query {Page = page, Size = size, Sort = sort});
        }

        [HttpGet("{hash}")]
        [ProducesResponseType(typeof(GetTransactionByHash.Model), StatusCodes.Status200OK)]
        public async Task<GetTransactionByHash.Model> GetTransactionByHash(string hash)
        {
            return await Mediator.Send(new GetTransactionByHash.Query {Hash = hash});
        }

        [HttpGet("block/{blockHash}")]
        [ProducesResponseType(typeof(GetTransactionsByBlockHash.Model), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetTransactionsByBlockHash.Model>> GetTransactionsByBlockHash(string blockHash)
        {
            return await Mediator.Send(new GetTransactionsByBlockHash.Query {BlockHash = blockHash});
        }
    }
}