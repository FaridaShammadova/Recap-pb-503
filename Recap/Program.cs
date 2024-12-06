    namespace Recap
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Weapon weapon = new Weapon(30, 30, ShootingMode.Automatic);

                Console.WriteLine("Main Menu:");
                Console.WriteLine("0 - Show Info");
                Console.WriteLine("1 - Shoot");
                Console.WriteLine("2 - Fire");
                Console.WriteLine("3 - Get Remain Bullet Count");
                Console.WriteLine("4 - Reload");
                Console.WriteLine("5 - Change Fire Mode");
                Console.WriteLine("6 - Exit");
                Console.WriteLine("7 - Edit Menu");

                bool check = false;

                while(!check)
                {
                    string? choose=Console.ReadLine();

                    try
                    {
                        CheckOptions(choose);
                    }
                    catch (NotInvalidException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    switch (choose)
                    {
                        case "0":
                            weapon.ShowInfo();
                            break;
                        case "1":
                            weapon.Shoot();
                            break;
                        case "2":
                            weapon.Fire();
                            break;
                        case "3":
                            weapon.GetRemainBulletCount();
                            break;
                        case "4":
                            weapon.Reload();
                            break;
                        case "5":
                            weapon.ChangeFireMode();
                            break;
                        case "6":
                            check = true;
                            break;
                        case "7":
                            Edit(ref weapon);
                            break;
                    }
                }
                Console.WriteLine("Program has ended.");
            }

            static void Edit(ref Weapon weapon)
            {
                Console.WriteLine("8 - Change bullet capacity");
                Console.WriteLine("9 - Change bullet count");
                Console.WriteLine("0 - Back to Main Menu");

                bool check = false;

                while(!check)
                {
                    string? choose = Console.ReadLine();
                    try
                    {
                        CheckOptionsInEdit(choose);
                    }
                    catch(NotInvalidException ex)
                    {
                        Console.WriteLine(ex.Message);
                    continue;
                    }

                    switch (choose)
                    {
                        case "8":
                        string? value1input;
                        int value1;
                        bool check1 = false;

                        while (!check1)
                        {
                            Console.WriteLine("Enter the new bullet capacity: ");
                            value1input = Console.ReadLine();

                            try
                            {
                                CheckValue(value1input);
                                value1 = Convert.ToInt32(value1input);

                                if (value1 > 0)
                                {
                                    if (value1 != weapon.BulletCapacity)
                                    {
                                        weapon.BulletCapacity = value1;
                                        check1 = true;
                                        Console.WriteLine($"The bullet capacity changed to {weapon.BulletCapacity}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"The bullet capacity is already {weapon.BulletCapacity}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("The bullet capacity cannot be negative.");
                                }
                            }
                            catch (NotInvalidException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;

                        case "9":
                        string? value2input;
                        int value2;
                        bool check2 = false;

                        while (!check2)
                        {
                            Console.WriteLine("Enter the new bullet count: ");
                            value2input = Console.ReadLine();

                            try
                            {
                                CheckValue(value2input);
                                value2 = Convert.ToInt32(value2input);

                                if (value2 < 0)
                                {
                                    Console.WriteLine("Bullet count cannot be negative.");
                                }
                                else if (value2 > weapon.BulletCapacity)
                                {
                                    Console.WriteLine("Bullet count cannot be greater than the bullet capacity.");
                                }
                                else
                                {
                                    weapon.BulletCount = value2;
                                    Console.WriteLine($"Bullet count changed to {weapon.BulletCount}");
                                    check2 = true;
                                }
                            }
                            catch (NotInvalidException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;
                        case "0":
                            check = true;
                            Console.WriteLine("You are now in the Main Menu!");
                            break;
                    }
                }
            }

            static void CheckOptions(string? value)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NotInvalidException("Invalid option! Choose the correct option in the Main Menu!");
                }

                foreach(char chr in value)
                {
                    if (!char.IsDigit(chr))
                    {
                        throw new NotInvalidException("Invalid option! Choose the correct option in the Main Menu!");
                    }
                }

                int number = Convert.ToInt32(value);

                if(number<0 || number > 7)
                {
                    throw new NotInvalidException("Invalid option! Choose the correct option in the Main Menu!");
                }
            }

            static void CheckOptionsInEdit(string? value)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NotInvalidException("Invalid option! Choose the correct option in the Edit Menu!");
                }

                foreach (char chr in value)
                {
                    if (!char.IsDigit(chr))
                    {
                        throw new NotInvalidException("Invalid option! Choose the correct option in the Edit Menu!");
                    }
                }

                int number = Convert.ToInt32(value);

                if (number < 0 || (number != 8 && number != 9 && number != 0))
                {
                    throw new NotInvalidException("Invalid option! Choose the correct option in the Edit Menu!");
                }
            }

            static void CheckValue(string? value)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NotInvalidException("Invalid option! Choose the number!");
                }

                foreach (char chr in value)
                {
                    if (!char.IsDigit(chr))
                    {
                        throw new NotInvalidException("Invalid option! Choose the number!");
                    }
                }

                int number = Convert.ToInt32(value);

                if (number < 0)
                {
                    throw new NotInvalidException("Invalid option! Choose the positive number!");
                }
            }
        }
    }
