using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Authentification
{

    class Program
    {
        public static void Main()
        {
            int input;
            string kon;
            Boolean cond = false;
            //User Giri = new User();
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("==Basic Authentification==");
                    Console.WriteLine("1. Create User ");
                    Console.WriteLine("2. Show User ");
                    Console.WriteLine("3. Search");
                    Console.WriteLine("4. Login");
                    Console.WriteLine("5. Exit");
                    Console.Write("Input : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            try { 
                            User.CreateUser();
                            }
                              catch(Exception)
                            {
                                Console.WriteLine("Inputan Salah");
                                User.CreateUser();
                                
                            }
                            cond = true;
                        break;
                        case 2:
                            try
                            {   
                                User.ShowUser();
                                kon = Console.ReadLine();
                                cond = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Inputan Salah");
                                kon = Console.ReadLine();
                                cond = true;

                            }
                            
                            break;
                        case 3:
  
                            
                            try
                            {
                                User.Search();
                                kon = Console.ReadLine();
                                cond = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Inputan Salah");
                                kon = Console.ReadLine();
                                cond = true;
                            }
                            break;
                        case 4:                   

                            try
                            {
                                Login.UserLogin();
                                cond = false;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Inputan Salah");
                                kon = Console.ReadLine();
                                cond = true;
                            }
                            break;
                        case 5:
                            cond = false;
                            break;
                        default:
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
    }
}
