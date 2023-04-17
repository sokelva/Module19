using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public  class FriendView
    {

        UserService userService;
       // FriendData friendData;

        public FriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {

            var friendData = new FriendData();

            Console.WriteLine("Введите Email друга:");
            friendData.email = Console.ReadLine();

            try
			{
                var u = userService.FindByEmail(friendData.email);
                friendData.friend_id = u.Id;
                friendData.user_id = user.Id;

                if (u == null)
                {
                    Console.WriteLine("Такой пользователь отсутствует.");
                    return;
                }
                else if (u != null)
                {
                    userService.AddFriend(friendData);
                    SuccessMessage.Show("Друг успешно добавлен!");
                }
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
