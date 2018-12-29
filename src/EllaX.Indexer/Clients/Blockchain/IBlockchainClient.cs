﻿using System.Threading;
using System.Threading.Tasks;
using EllaX.Indexer.Clients.Responses;
using EllaX.Indexer.Clients.Responses.Eth;

namespace EllaX.Indexer.Clients.Blockchain
{
    public interface IBlockchainClient
    {
        Task<Response<ulong>> GetHeight(CancellationToken cancellationToken = default);
        Task<Response<BlockResult>> GetBlock(string blockHash, CancellationToken cancellationToken = default);
        Task<Response<BlockResult>> GetBlock(ulong blockNumber, CancellationToken cancellationToken = default);
    }
}
