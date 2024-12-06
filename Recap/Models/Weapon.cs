using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    public class Weapon
    {
        public int BulletCapacity { get; set; }
        public int BulletCount { get; set; }
        public ShootingMode ShootingMode;

        public Weapon(int bulletCapacity, int bulletCount, ShootingMode shootingMode)
        {
            BulletCapacity = bulletCapacity;
            BulletCount = bulletCount;
            ShootingMode = shootingMode;
        }

        public override string ToString()
        {
            return $"Bullet capacity: {BulletCapacity};  Bullet count: {BulletCount}; Shooting mode: {ShootingMode}";
        }

        public void ShowInfo()
        {
            Console.WriteLine(ToString());
        }

        public void Shoot()
        {
            if (BulletCount > 0)
            {
                if (ShootingMode == ShootingMode.Automatic)
                {
                    BulletCount--;
                    Console.WriteLine($"Automatic weapon shooted. Bullet count is {BulletCount}.");
                }
                else if (ShootingMode == ShootingMode.Single)
                {
                    BulletCount--;
                    Console.WriteLine($"Single weapon shooted. Bullet count is {BulletCount}.");
                }
                else if (ShootingMode == ShootingMode.Burst)
                {
                    BulletCount--;
                    Console.WriteLine($"Burst weapon shooted. Bullet count is {BulletCount}.");
                }
            }
            else
            {
                Console.WriteLine("There isn't any bullet!");
            }
        }

        public void Fire()
        {
            if (BulletCount > 0)
            {
                if (ShootingMode == ShootingMode.Automatic)
                {
                    BulletCount=0;
                    Console.WriteLine($"Automatic weapon fired. Bullet count is {BulletCount}.");
                }
                else if (ShootingMode == ShootingMode.Single)
                {
                    BulletCount--;
                    Console.WriteLine($"Single weapon fired. Bullet count is {BulletCount}.");
                }
                else if (ShootingMode == ShootingMode.Burst)
                {
                    BulletCount-=3;
                    Console.WriteLine($"Burst weapon fired. Bullet count is {BulletCount}.");
                }
            }
            else
            {
                Console.WriteLine("There isn't any bullet!");
            }
        }
        
        public void GetRemainBulletCount()
        {
            int remainBullet = BulletCapacity - BulletCount;
            Console.WriteLine($"{remainBullet} bullets needed to fill the weapon.");
        }

        public void Reload()
        {
            BulletCount = BulletCapacity;
            Console.WriteLine("The weapon fulled!");
        }

        public void ChangeFireMode()
        {
            Console.WriteLine("Choose fire mode:");
            Console.WriteLine("1 - Automatic mode");
            Console.WriteLine("2 - Single mode");
            Console.WriteLine("3 - Burst mode");

            bool check = false;

            while (!check)
            {
                string? choose = Console.ReadLine();

                try
                {
                    ChooseFireMode(choose);
                }
                catch (NotInvalidException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                switch (choose)
                {
                    case "1":
                        if (ShootingMode != ShootingMode.Automatic)
                        {
                            ShootingMode = ShootingMode.Automatic;
                            check = true;
                            Console.WriteLine("The fire mode changed to Automatic mode.");
                        }
                        else
                        {
                            Console.WriteLine("The weapon is currently in Automatic mode. Choose other shooting mode.");
                        }
                        break;

                    case "2":
                        if (ShootingMode != ShootingMode.Single)
                        {
                            ShootingMode = ShootingMode.Single;
                            check = true;
                            Console.WriteLine("The fire mode changed to Single mode.");
                        }
                        else
                        {
                            Console.WriteLine("The weapon is currently in Single mode. Choose other shooting mode.");
                        }
                        break;

                    case "3":
                        if (ShootingMode != ShootingMode.Burst)
                        {
                            ShootingMode = ShootingMode.Burst;
                            check= true;
                            Console.WriteLine("The fire mode changed to Burst mode.");
                        }
                        else
                        {
                            Console.WriteLine("The weapon is currently in Burst mode. Choose other shooting mode.");
                        }
                        break;
                }
            }
        }

        static void ChooseFireMode(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NotInvalidException("Invalid option! Choose the correct shooting mode!");
            }

            foreach(char chr in value)
            {
                if (!char.IsDigit(chr))
                {
                    throw new NotInvalidException("Invalid option! Choose the correct shooting mode!");
                }
            }

            int number = Convert.ToInt32(value);

            if(number<0 || number > 3)
            {
                throw new NotInvalidException("Invalid option! Choose the correct shooting mode!");
            }
        }
    }
}
