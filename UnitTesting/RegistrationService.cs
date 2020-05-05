using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public interface IEmailer
    {
        void Send(string to, string header, string body);
    }
    public interface IUserRepository
    {
        bool Exists(string email);
        void Add(string email, string name);
    }

    public class RegistrationViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class RegistrationService
    {
        private readonly IEmailer _emailer;
        private readonly IUserRepository _userRepository;

        public RegistrationService(IEmailer emailer, IUserRepository userRepository)
        {
            _emailer = emailer;
            _userRepository = userRepository;
        }

        public bool Register(RegistrationViewModel model)
        {
            if (_userRepository.Exists(model.Email))
                return false;
            _userRepository.Add(model.Email,model.Name);
            _emailer.Send(model.Name,"Welcome", "Welcome new user!");
            return true;
        }
    }
}
