﻿using Aplication.DTO;
using Aplication.Interface;
using Aplication.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.ICommand
{
  public   interface IGetMenuCommand:ICommand<MenuSearch,IEnumerable<MenuDto>>
    {
    }
}
