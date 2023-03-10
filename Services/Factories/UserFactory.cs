using BusinessLogic.SupplierRoot.DomainModels;
using Microsoft.Extensions.Logging;
using Services.Factories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly ILogger _logger;

        public UserFactory(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<UserFactory>();
        }

        public User CreateNewUser(string name, string email, string contactNo, int roleId, bool isActive)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new Exception("Name is required");

            var user = new User(name, email, contactNo, roleId, isActive);
            return user;
        }
    }
}
