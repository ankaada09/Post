using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.ICommand;
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

        public IEnumerable<UserDto> Execute(UserSearch request)
        {

            var query = Context.Users.AsQueryable();

            if (request.UserName != null)
            {
                query = query.Where(c => c.Username.ToLower().Contains(request.UserName.ToLower()));

            }
            return query.Include(c=>c.UserType).Select(c => new UserDto
            {
                Id=c.Id,
                UserName=c.Username,
                Email=c.Email,
                Password=c.Password,
                userType = c.UserType.Type

            });
        }
    }
}
