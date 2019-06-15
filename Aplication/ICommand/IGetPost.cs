using Aplication.DTO;
using Aplication.Interface;
using Aplication.Search;
using System;
using System.Collections.Generic;
using System.Text;

using Aplication.Responses;

namespace Aplication.ICommand
{
   public interface IGetPost: ICommand<PostSearch, PagedResponses<PostDto>>
    {
    }
}
