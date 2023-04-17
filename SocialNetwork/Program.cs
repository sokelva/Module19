using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;
using System;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        static UserService userService; 
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static MessageSendingView messageSendingView;
        public static UserDataUpdateView userDataUpdateView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserInfoView userInfoView;
        public static UserMenuView userMenuView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static FriendView friendView;

        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();
            mainView= new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService,userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            friendView = new FriendView(userService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}