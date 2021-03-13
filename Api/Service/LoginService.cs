using Api.Domain;
using Api.Models;

namespace Api.Service
{
    public class LoginService : ILoginService
    {
        public Usuario Autentica(Credencial credencial)
        {
            if (credencial.Username == "tadriano" && credencial.Password == "102030")
            {
                return new Usuario
                {
                    Nome = "Thiafo Adriano",
                    Role = "Admin"
                };
            }

            return null;


        }

    }
}
