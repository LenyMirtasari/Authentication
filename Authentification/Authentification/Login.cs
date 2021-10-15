using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Authentification
{
    class Login : User
    {

        public static void UserLogin()
        {
            Console.Clear();
            Console.Write("Masukkan Username : ");
            string userName = Console.ReadLine();
            Console.Write("Masukkan Password : ");
            string password = Console.ReadLine();
            var index = users.FindIndex(c => c.userNames == userName);
            var id = users[index].userIds;
            var idx = users.FindIndex(c => c.userIds == id);
            bool result = BCrypt.Net.BCrypt.Verify(password, users[idx].passwords);
            //Console.WriteLine(idx);
            if (id > 0)
            {
                if (users[idx].userNames == userName && result == true)
                {
                    
                    MenuLogin();
                }
                else
                {
                    Console.WriteLine("login failed");
                }
            }
            else
            {
                Console.WriteLine("login failed");
            }
        }

        public static void MenuLogin()
        {
             int input;
            string kon;
;            bool cond = false;
            try
            {
                do {
                    Console.Clear();
                    Console.WriteLine("login success");
                    Console.WriteLine("1. INFO");
                    Console.WriteLine("2. HAPUS AKUN");
                    Console.WriteLine("3. EDIT USERNAME");
                    Console.WriteLine("4. LOGOUT");
                    Console.WriteLine("INPUT : ");


                    input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:

                            User.Search();
                            kon = Console.ReadLine();
                            cond = true;
                            break;
                        case 2:
                            DeleteUser();
                            cond = false;
                            break;
                        case 3:
                            try
                            {
                                EditUser();
                                cond = true;
                            }
                            catch
                            {
                                cond = true;
                            }
                            break;
                        case 4:
                            Program.Main();
                            break;
                        default:
                            Console.WriteLine("inputan salah");
                            kon = Console.ReadLine();
                            cond = true;
                            break;
                    }
                } while (cond);
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR INPUT !!!!");
                kon = Console.ReadLine();
                cond = true;
            }
                
            }

        public static void DeleteUser()
        {
            Console.Clear();
            Console.Write("Masukkan ID USER Yang Akan Dihapus: ");
            string kon;
            int userId = Convert.ToInt32(Console.ReadLine());
            var index = users.FindIndex(c => c.userIds == userId);
            if (index >= 0)
            {
                users.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("User Not Found");
                kon = Console.ReadLine();
                DeleteUser();
            }
        }

        public static void EditUser()
        {
            Console.Clear();
            Console.Write("Masukkan User ID Yang Akan Diubah: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            var index = users.FindIndex(c => c.userIds == userId);
            string kon;
            if (index >= 0)
            {
                Console.Write("Masukkan Username Baru: ");
                string userName = Console.ReadLine();
                Console.Write("Masukkan Password Baru (min 8 characters, contains Uppercase, symbols and numbers): ");
                string password = Console.ReadLine();
                int j = 0;
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].userNames == userName)
                    {
                        j = 1;
                    }
                }
                if (j > 0)
                {
                    Console.WriteLine("Username sudah ada");
                    kon = Console.ReadLine();
                    EditUser();
                }
                else
                {
                    var hasNumber = new Regex(@"[0-9]+");
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasMinimum8Chars = new Regex(@".{8,}");
                    var hasSymbol = new Regex(@".[!*@#$%^&+=]");
                    if (password == "")
                    {
                        Console.WriteLine("Password Should not be empty");
                        kon = Console.ReadLine();
                        EditUser();

                    }
                    else if (!hasNumber.IsMatch(password))
                    {
                        Console.WriteLine("Password should contains number");
                        kon = Console.ReadLine();
                        EditUser();
                    }
                    else if (!hasUpperChar.IsMatch(password))
                    {
                        Console.WriteLine("Password should has Upper Character");
                        kon = Console.ReadLine();
                        EditUser();
                    }
                    else if (!hasMinimum8Chars.IsMatch(password))
                    {
                        Console.WriteLine("Password should has Minimum 8 Characters");
                        kon = Console.ReadLine();
                        EditUser();
                    }
                    else if (!hasSymbol.IsMatch(password))
                    {
                        Console.WriteLine("assword should contains symbol");
                        kon = Console.ReadLine();
                        EditUser();
                    }
                    else
                    {
                        string passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);
                        users[index].userNames = userName;
                        users[index].passwords = passwordHashed;
                    }
                }

            }
            else
            {
                Console.WriteLine("User Not Found");
                kon = Console.ReadLine();
                EditUser();
            }
        }



    }
}
