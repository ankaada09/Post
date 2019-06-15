using Aplication.DTO;
using Aplication.Interface;
using Aplication.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.ICommand
{
  public  interface IGetUserCommand:ICommand<UserSearch, IEnumerable<UserDto>>
    {
    }
}
