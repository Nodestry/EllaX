﻿using System;

namespace EllaX.Indexer.Clients.Responses
{
    public class Response<TResult>
    {
        public string JsonRpc { get; set; }
        public TResult Result { get; set; }
        public Guid Id { get; set; }
    }
}
