using DataAcess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommand
{
    public abstract class BaseEFCommand
    {
        protected PostContext Context {get;}

        protected BaseEFCommand(PostContext context) => Context = context;

    }
}
