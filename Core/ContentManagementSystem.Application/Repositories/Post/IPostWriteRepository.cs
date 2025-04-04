﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentManagementSystem.Domain.Entities;

namespace ContentManagementSystem.Application.Repositories
{
    public interface IPostWriteRepository : IWriteRepository<Post>
    {
    }
}
