﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        void Save();
        Task SaveAsync();
    }
}
