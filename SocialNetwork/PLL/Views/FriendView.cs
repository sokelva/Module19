using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public  class FriendView
    {
        
        public void Show(UserEntity friend)
        {
            var friendData = new FriendData();
            var userService = new UserService();

            Console.WriteLine("Введите Email друга:");
            friendData.email = Console.ReadLine();

            try
			{
                var user = userService.FindByEmail(friend.email);


                if (user == null)
                {
                    Console.WriteLine("Друзей нет.");
                    return;
                }
                else if (user != null)
                {
                    Console.WriteLine($"Друзья: {friend.firstname +" "+ friend.lastname}\n");
                }

                //user.ToList().ForEach(friend =>
                //{
                //    Console.WriteLine($"Друзья: {friend.Email + " " + friend.friend_id}\n");
                //});
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
