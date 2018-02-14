using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Learning.Entities;

namespace Sandbox.Learning.Tools
{
    public static class DataGenerator
    {
        public static ICollection<Person> GeneratePeople()
        {
            var number = 0;
            var people = new List<Person>
            {
                new Person { PersonId = ++number, FirstName = "Clint", LastName = "Barton" },
                new Person { PersonId = ++number, FirstName = "Steve", LastName = "Rogers" },
                new Person { PersonId = ++number, FirstName = "Tony", LastName = "Stark" },
                new Person { PersonId = ++number, FirstName = "Bruce", LastName = "Banner" },
                new Person { PersonId = ++number, FirstName = "Scott", LastName = "Summers" },
                new Person { PersonId = ++number, FirstName = "James", LastName = "Howlett" }
            };

            return people;
        }

        public static ICollection<Claim> GenerateClaims()
        {
            var number = 0;
            var qualifier = 'A';
            var rng = new Random();

            var claims = new List<Claim>
            {
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 1, ClaimDate = new DateTime(2014, 01, 23), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 1, ClaimDate = new DateTime(2014, 07, 30), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 1, ClaimDate = new DateTime(2015, 04, 12), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 1, ClaimDate = new DateTime(2015, 09, 16), Amount = rng.NextDecimal()},

                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 2, ClaimDate = new DateTime(2013, 04, 06), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 2, ClaimDate = new DateTime(2013, 05, 17), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 2, ClaimDate = new DateTime(2015, 01, 25), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 2, ClaimDate = new DateTime(2015, 07, 01), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 2, ClaimDate = new DateTime(2015, 11, 13), Amount = rng.NextDecimal()},

                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 3, ClaimDate = new DateTime(2015, 03, 03), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 3, ClaimDate = new DateTime(2015, 05, 23), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 3, ClaimDate = new DateTime(2015, 06, 28), Amount = rng.NextDecimal()},

                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 4, ClaimDate = new DateTime(2013, 04, 14), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 4, ClaimDate = new DateTime(2013, 06, 19), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 4, ClaimDate = new DateTime(2014, 11, 20), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 4, ClaimDate = new DateTime(2014, 12, 06), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 4, ClaimDate = new DateTime(2016, 02, 29), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 4, ClaimDate = new DateTime(2016, 04, 04), Amount = rng.NextDecimal()},

                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 5, ClaimDate = new DateTime(2016, 01, 01), Amount = rng.NextDecimal()},
                new Claim { ClaimId = ++number, ClaimNumber = qualifier + number.ToString().PadLeft(7, '0'), PersonId = 5, ClaimDate = new DateTime(2016, 02, 14), Amount = rng.NextDecimal()},
            };

            return claims;
        }

        public static ICollection<Car> GenerateCars()
        {
            var cars = new List<Car>
            {
                new Car(1968, "Chevrolet", "Camaro"),
                new Car(1972, "Ford", "Mustang"),
                new Car(1986, "Pontiac", "GTO"),
            };

            return cars;
        }

        public static ICollection<int> GenerateInts()
            => new List<int> { 1, 2, 3, 4, 5, 6 };


        private static decimal NextDecimal(this Random rng)
            => new decimal(rng.Next(100, 100000), 0, 0, false, 2);



    }
}
