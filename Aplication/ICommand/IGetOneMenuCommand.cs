using Aplication.DTO;
using Aplication.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.ICommand
{
   public interface IGetOneMenuCommand:ICommand<int, MenuDto>
    {
    }
}
