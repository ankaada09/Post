﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interface
{
  public  interface ICommand<TRequest>
    {
        void Execute(TRequest request);
    }

    public interface ICommand<TRequest,TResult>
    {
       TResult Execute(TRequest request);
    }
}
