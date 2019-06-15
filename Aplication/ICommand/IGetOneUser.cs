using Aplication.DTO;
using Aplication.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.ICommand
{
   public interface IGetOneUser:ICommand<int, UserDto>
    {
    }
}
