using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.ICommand;
using Aplication.Responses;
using Aplication.Search;
using DataAcess;
using Microsoft.EntityFrameworkCore;

namespace EFCommand
{
    public class EFGetUserCommand : BaseEFCommand, IGetUserCommand
    {
        public EFGetUserCommand(PostContext context) : base(context)
        {
        }

        public PagedResponses<UserDto> Execute(UserSearch request)
        {
            var query = Context.Users.AsQueryable();
            var totalCount = query.Count();

            query = query.Include(p=>p.UserType).Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponses<UserDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = query.Select(p => new UserDto
                {
                    Id = p.Id,
                    UserName=p.Username,
                    Email=p.Email,
                    userType=p.UserType.Type


                })




            };
            return response;
        }
    }
}
