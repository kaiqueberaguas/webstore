﻿using Microsoft.Extensions.Logging;
using System;

namespace WebApiProdutos.Src.Infra.Loggin
{
    public class InternalLooger : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
            throw new NotImplementedException();
        }

        public ILogger CreateLogger(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}