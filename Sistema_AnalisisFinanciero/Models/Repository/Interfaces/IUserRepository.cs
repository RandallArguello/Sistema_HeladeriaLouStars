using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeladeriaLouStarsApp.Models.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<string> ValidateCredentialsAsync(string username, string password);
    }
}
