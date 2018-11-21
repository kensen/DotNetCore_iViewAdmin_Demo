using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace DotNetCore_iViewAdmin_demo
{
    public class SQLConnection:IOptions<SQLConnection>
    {
        public string Connecting { get; set; }

        public SQLConnection Value => this;
    }
}
