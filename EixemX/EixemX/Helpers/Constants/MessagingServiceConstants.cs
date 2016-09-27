using EixemX.Controls.Menus;

namespace EixemX.Helpers.Constants
{
    public static class MessagingServiceConstants
    {
        public const string AUTHENTICATED = "AUTHENTICATED";
        public const string REGISTERED = "REGISTERED";
           
        public const string DASHBOARD = "DASHBOARD";
        public const string HISTORY = "HISTORY";
        public const string EMPRUNTER = "EMPRUNTER";
        public const string PRETER = "PRETER";
        public const string RETIRER = "RETIRER";
        public const string ABOUT = "ABOUT";
        public const string CONTACT = "CONTACT";
        public const string PROFESSIONAL = "PROFESSIONAL";
        public const string PAYER = "PAYER";
        
        public static string Get(MenuType menu)
        {
            string result = string.Empty;
            switch (menu)
            {
                   case MenuType.Dashboard:
                    result = DASHBOARD;
                    break;
                   case MenuType.History:
                    result = HISTORY;
                    break;
                   case MenuType.Emprunter:
                    result = EMPRUNTER;
                    break;
                case MenuType.Preter:
                    result = PRETER;
                    break;
                case MenuType.Payer:
                    result = PAYER;
                    break;
                case MenuType.Retirer:
                    result = RETIRER;
                    break;
                   case MenuType.About:
                    result = ABOUT;
                    break;
                   case MenuType.Contact:
                    result = CONTACT;
                    break;
                   case MenuType.Professional:
                    result = PROFESSIONAL;
                    break;
            }
            return result;
        }
    }
}