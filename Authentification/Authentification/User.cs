using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Authentification
{
    class User
    {
        protected static List<User> users = new List<User>();
        public string firstNames, lastNames, passwords, userNames;
        public int userIds;
        

        public static void CreateUser()
        {
            //string kon;
            Console.Clear();
            string firstName, lastName, password, userName, kon;
            int userId;
            
                Console.WriteLine("==Create User==");
                Console.Write("First Name : ");
                firstName = Console.ReadLine();
                Console.Write("Last Name : ");
                lastName = Console.ReadLine();
                Console.Write("Password (min 8 characters, contains Uppercase, symbols and numbers): ");
                password = Console.ReadLine();
            
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");
                var hasSymbol = new Regex(@".[!*@#$%^&+=]");
                if (password == "")
                {
                    Console.WriteLine("Password Should not be empty");
                    kon = Console.ReadLine();
                    CreateUser();
                }
                else if (!hasNumber.IsMatch(password))
                {
                    Console.WriteLine("Password should contains number");
                    kon = Console.ReadLine();
                    CreateUser();
                }
                else if (!hasUpperChar.IsMatch(password))
                {
                    Console.WriteLine("Password should has Upper Character");
                    kon = Console.ReadLine();
                    CreateUser();
                }
                else if (!hasMinimum8Chars.IsMatch(password))
                {
                    Console.WriteLine("Password should has Minimum 8 Characters");
                    kon = Console.ReadLine();
                    CreateUser();
                }
                else if (!hasSymbol.IsMatch(password))
                {
                    Console.WriteLine("Password should contains symbol");
                    kon = Console.ReadLine();
                    CreateUser();

                }
                else
                {
                    
                    userId = (users.Count) + 1;
                    userName = firstName.Substring(0, 2) + lastName.Substring(0, 2)+userId;
                    string passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);
                    users.Add(new User { userIds = userId, firstNames = firstName, lastNames = lastName, passwords = passwordHashed, userNames = userName });
                   
                }
            
          


        }

        public static void ShowUser()
        {

            Console.Clear();
            Console.WriteLine("======Show User=======");
            Console.WriteLine("======================");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"ID       : {users[i].userIds}");
                Console.WriteLine($"NAME     : {users[i].firstNames} {users[i].lastNames}");
                Console.WriteLine($"USERNAME : {users[i].userNames}");
                Console.WriteLine($"PASSWORD : {users[i].passwords}");
                Console.WriteLine("======================");
            }


        }

        

        public static void Search()
        {
            string username, kon;
            Console.Clear();
            Console.Write("Masukkan Username : ");
            username = Console.ReadLine();
            int i = users.FindIndex(c => c.userNames == username);
           //int userId = Convert.ToInt32(Console.ReadLine());
            if (i<0)
            {
                Console.WriteLine("Username not found");
                kon = Console.ReadLine();
            }
            else { 
            Console.WriteLine($"ID      : { users[i].userIds}");
            Console.WriteLine("NAME     :" + users[i].firstNames + " " + users[i].lastNames);
            Console.WriteLine("USERNAME :" + users[i].userNames);
            Console.WriteLine("PASSWORD :" + users[i].passwords);
            }
        }

        

        


    }
}
