﻿using Aplication.DTO;
using Aplication.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.ICommand
{
   public interface IGetOneComment:ICommand<int,CommentDto>
    {
    }
}
