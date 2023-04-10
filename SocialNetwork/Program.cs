using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System.Globalization;

namespace SocialNetwork
{
    public class Program
    {
        public static UserService userService = new UserService();

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть!");

            while (true)
            {
                Console.WriteLine("Для регистрации пользователя введите имя пользователя: ");
                string firstname = Console.ReadLine();

                Console.WriteLine("фамилия: ");
                string lastname = Console.ReadLine();

                Console.WriteLine("пароль: ");
                string password = Console.ReadLine();

                Console.WriteLine("почтовый адрес: ");
                string email = Console.ReadLine();

                UserRegistrationData registrationData = new UserRegistrationData()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(registrationData);
                    Console.WriteLine("Регистрация проищошла успешно!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректное значение.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при регистрации: {ex.Message}.");
                }

                Console.ReadLine();
            }
        }
    }
}