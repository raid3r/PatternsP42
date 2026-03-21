using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Behavioral;


public class ChainOfResponsibilityClientCode
{
    private bool IsBlockedUser(string login)
    {
        // перевірити чи користувач заблокований
        return false;
    }



    public void Run()
    {



        var user = new User { Login = "admin", Password = "admin123", Role = "Admin" };


        var loginHandler = new LoginHandler();
        var emptyPasswordHandler = new EmptyPasswordHandler();
        var roleHandler = new RoleHandler();
        var passwordCheckHandler = new PasswordCheckHandler();
        var blockedUserHandler = new BlockedUserHandler();
        var accessRightsHandler = new AccessRightsHandler();
        var authorizedUserHandler = new AuthorizedUserHandler();
        var byTimeAccessHandler = new ByTimeAccessHandler();

        var userHandlerChain = byTimeAccessHandler
            .SetNext(loginHandler)
            .SetNext(emptyPasswordHandler)
            .SetNext(roleHandler)
            .SetNext(passwordCheckHandler)
            .SetNext(blockedUserHandler)
            .SetNext(accessRightsHandler)
            .SetNext(authorizedUserHandler);

        userHandlerChain.Handle(user);


        // авторизація користувача

        // перевірити що логін не пустий

        //var userValid = true;
        //if (string.IsNullOrEmpty(user.Login)) {
        //    userValid = false;
        //}

        //// перевірити що пароль не пустий
        //if (string.IsNullOrEmpty(user.Password)) {
        //    userValid = false;
        //}
        //// перевірити що роль є валідною
        //var validRoles = new List<string> { "Admin", "User", "Guest" };
        //if (!validRoles.Contains(user.Role)) {
        //    userValid = false;
        //}
        //// перевірити що пароль вірний для цього логіна
        //if (user.Login == "admin" && user.Password != "admin123") {
        //    userValid = false;
        //}
        //// перевірити що користувач не заблокований
        //if (IsBlockedUser(user.Login)) {
        //    userValid = false;
        //}
        //// перевірити що користувач роль адмін
        //if (user.Role != "Admin") {
        //    userValid = false;
        //}
        //// здійснити якусь дію для авторизованого користувача
        //if (userValid) {
        //    Console.WriteLine("User is valid and authorized.");
        //} else {
        //    Console.WriteLine("User is not valid or not authorized.");
        //}


        // Запит -> Обробник 1 (перевірка логіна) -> Обробник 2 (перевірка пароля) -> Обробник 3 (перевірка ролі) -> Обробник 4 (перевірка блокування) -> Обробник 5 (перевірка прав доступу) -> Обробник 6 (дія для авторизованого користувача)


    }
}

public interface IUserHandler
{
    IUserHandler SetNext(IUserHandler handler);
    void Handle(User user);
}

// // Запит ->
// Обробник 1 (перевірка логіна) ->
// Обробник 2 (перевірка пароля) ->
// Обробник 3 (перевірка ролі) ->
// Обробник 4 (перевірка блокування) ->
// Обробник 5 (перевірка прав доступу) ->
// Обробник 6 (дія для авторизованого користувача)


public class AbstractUserHandler : IUserHandler
{
    private IUserHandler _nextHandler;
    public IUserHandler SetNext(IUserHandler handler)
    {
        if (_nextHandler != null)
        {
            _nextHandler.SetNext(handler);
        }
        else _nextHandler = handler;
        return this;
    }
    public virtual void Handle(User user)
    {
        if (_nextHandler != null)
        {
            _nextHandler.Handle(user);
        }
    }
}


class LoginHandler : AbstractUserHandler
{
    public override void Handle(User user)
    {
        if (string.IsNullOrEmpty(user.Login))
        {
            Console.WriteLine("Login is empty.");
            return;
        }
        base.Handle(user);
    }
}

class EmptyPasswordHandler : AbstractUserHandler
{
    public override void Handle(User user)
    {
        if (string.IsNullOrEmpty(user.Password))
        {
            Console.WriteLine("Password is empty.");
            return;
        }
        base.Handle(user);
    }
}

public class RoleHandler : AbstractUserHandler
{
    private readonly List<string> _validRoles = new List<string> { "Admin", "User", "Guest" };
    public override void Handle(User user)
    {
        if (!_validRoles.Contains(user.Role))
        {
            Console.WriteLine("Invalid role.");
            return;
        }
        base.Handle(user);
    }
}

public class PasswordCheckHandler : AbstractUserHandler
{
    public override void Handle(User user)
    {
        if (user.Login == "admin" && user.Password != "admin123")
        {
            Console.WriteLine("Incorrect password for admin.");
            return;
        }
        base.Handle(user);
    }
}

public class BlockedUserHandler : AbstractUserHandler
{
    private bool IsBlockedUser(string login)
    {
        // перевірити чи користувач заблокований
        return false;
    }
    public override void Handle(User user)
    {
        if (IsBlockedUser(user.Login))
        {
            Console.WriteLine("User is blocked.");
            return;
        }
        base.Handle(user);
    }
}

public class AccessRightsHandler : AbstractUserHandler
{
    public override void Handle(User user)
    {
        if (user.Role != "Admin")
        {
            Console.WriteLine("User does not have admin access.");
            return;
        }
        base.Handle(user);
    }
}

public class AuthorizedUserHandler : AbstractUserHandler
{
    public override void Handle(User user)
    {
        Console.WriteLine("User is valid and authorized.");
        base.Handle(user);
    }
}


public class ByTimeAccessHandler : AbstractUserHandler
{
    public override void Handle(User user)
    {
        if (DateTime.Now.Hour < 9 || DateTime.Now.Hour > 17)
        {
            Console.WriteLine("Access is allowed only between 9 AM and 12 PM.");
            return;
        }


        base.Handle(user);
    }
}


public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}




