using System;
using Vital.Model;
namespace Vital.Service
{
    public interface IAdminUserService
    {

        bool ValidateLogin(String uname, string pword);

    }
}
