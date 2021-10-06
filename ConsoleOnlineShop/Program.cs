namespace ConsoleOnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            User currentUser = new User();

            while (!isExit)
            {
                Menu notLoggedInMenu = new("Online shop verification system", new string[3] { "Log in", "Register", "Exit" });
                int choise = notLoggedInMenu.ShowMenuToUserAndReturnChoise();

                RequestField field;
                string[] answers;

                switch (choise)
                {
                    case 0:
                        field = new("Log in", new string[3] { "Login", "Password", "Confirm" });
                        answers = new string[3];
                        field.ShowMenuToUserAndReturnChoise(ref answers);

                        currentUser = new User(answers[0], answers[1]);

                        currentUser.LogInUser();
                        break;
                    case 1:
                        field = new("Register", new string[3] { "Login", "Password", "Confirm" });
                        answers = new string[3];
                        field.ShowMenuToUserAndReturnChoise(ref answers);

                        currentUser = new User(answers[0], answers[1]);

                        currentUser.RegisterUser();
                        break;
                    case 2:
                        isExit = true;
                        break;
                }

                while (currentUser.isAuthorized)
                {
                    // do smth...
                }

            }
        }
    }
}
