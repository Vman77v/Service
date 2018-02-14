using System;
using System.Collections.Generic;

namespace Sandbox.Learning
{
    //using static System.Console; //C#6

    #region Extention Methods and Operators

    //public static class ExtentionMethods
    //{
    //    public static void DisplayPerson(this Person person)
    //    {
    //        foreach (var prop in person.GetType().GetProperties())
    //        {
    //            Console.WriteLine(prop.GetValue(person));
    //        }
    //    }


    //}
    //public sealed class Person
    //{
    //    public string FirstName { get; set; } = "Steve";
    //    public string LastName { get; set; } = "Rogers";
    //    public DateTime DateOfBirth { get; set; } = new DateTime(1920, 7, 4);

    //    public static int operator -(Person p1, Person p2) => (p1.DateOfBirth - p2.DateOfBirth).Days;

    //    public static bool operator ==(Person p1, Person p2) => (p1?.FirstName == p2?.FirstName && p1?.LastName == p2?.LastName);
    //    public static bool operator !=(Person p1, Person p2) => (p1?.FirstName != p2?.FirstName || p1?.LastName != p2?.LastName);
    //}

    #endregion

    #region Inheritance & Polymorphism Pt. 2
    using Vehicle = Program.Vehicle;

    public static class VehicleExtensions
    {
        public static void DisplayMakeAndModel(this Vehicle vehicle)
        {
            Console.WriteLine($"Make: {vehicle.Make}");
            Console.WriteLine($"Model: {vehicle.Model}");
        }
    }

    #endregion

    public class Program
    {
        #region Inheritance & Polymorphism Pt. 2

        static void Main()
        {
            Accumulator a1 = new Accumulator { Amount = 110.50M };
            Accumulator a2 = new Accumulator { Amount = 200.00M };

            Accumulator a3 = a1 + a2;

            bool b1 = a1 == a2;
            bool b2 = a1 != a2;

            //Vehicle vehicle = new Vehicle(); // does not compile because Vehicle is abtract
            Vehicle vehicle = new Car();
            vehicle.Drive();

            vehicle = new Truck();
            vehicle.Drive();


            vehicle.Make = "Chevrolet";
            vehicle.Model = "Silverado";
            vehicle.DisplayMakeAndModel();

        }

        public class Counter
        {
            private int _intCount;
            private int _stringCount;
            private int _dateCount;

            void Count(int input)
            {
                _intCount++;
            }

            void Count(string input)
            {
                _stringCount++;
            }

            void Count(DateTime input)
            {
                _dateCount++;
            }

        }

        public class Accumulator
        {
            public decimal Amount { get; set; }

            public static Accumulator operator +(Accumulator a1, Accumulator a2)
            {
                return new Accumulator { Amount = a1.Amount + a2.Amount };
            }

            public static Accumulator operator -(Accumulator a1, Accumulator a2)
            {
                return new Accumulator { Amount = a1.Amount - a2.Amount };
            }

            public static bool operator ==(Accumulator a1, Accumulator a2)
            {
                return a1?.Amount == a2?.Amount;
            }

            public static bool operator !=(Accumulator a1, Accumulator a2)
            {
                return a1?.Amount != a2?.Amount;
            }

            public override bool Equals(object obj)
            {
                var item = obj as Accumulator;

                return item != null && Amount.Equals(item.Amount);
            }

            public override int GetHashCode()
            {
                return Amount.GetHashCode();
            }


            public static void ApplyAccumulator(Accumulator accumulator)
            {
                if (accumulator is Deductible)
                    ApplyAccumulator((Deductible)accumulator);
                if (accumulator is OutOfPocket)
                    ApplyAccumulator((OutOfPocket)accumulator);
            }

            public static void ApplyAccumulator(Deductible accumulator) { }
            public static void ApplyAccumulator(OutOfPocket accumulator) { }
        }

        public class Deductible : Accumulator { }
        public class OutOfPocket : Accumulator { }

        public class Person
        {
            public string FirstName { get; set; }

            //public void set_FirstName(string value) { }
            //public string get_FirstName() { }

            private string _lastName;
            public string LastName { get { return _lastName; } set { _lastName = value; } }

            private string _name;
            public void set_name(string value)
            {
                _name = value;
            }

            public string get_name()
            {
                return _name;
            }
        }

        public abstract class Vehicle
        {
            public string Make { get; set; }
            public string Model { get; set; }

            public virtual void Drive()
            {
                Console.WriteLine($"The {nameof(Vehicle)} is driving.");
            }

            public abstract void DoMaintenance();
        }

        public class Car : Vehicle
        {
            public override void Drive()
            {
                // provide new logic
                Console.WriteLine($"The {nameof(Car)} is driving.");
            }

            public override void DoMaintenance()
            {
                Console.WriteLine($"{nameof(Car)} is being maintenanced");
            }
        }

        public sealed class Truck : Vehicle
        {
            public override void Drive()
            {
                // extend the current logic
                base.Drive();
                Console.WriteLine($"The Vehicle is a {nameof(Truck)}.");
            }

            public override void DoMaintenance()
            {
                Console.WriteLine($"{nameof(Truck)} is being maintenanced");
            }
        }

        //public class HalfTon : Truck { } // does not compile because Truck is sealed



        #endregion

        #region Inheritance & Polymorphism Pt. 1

        //static void Main()
        //{
        //    IWingedAnimal animal = new Bat();
        //    IWingedAnimal animal2 = new Bird();


        //    animal.Fly();
        //}

        //public class Person
        //{
        //    protected DateTime _dateOfBirth;

        //    public Person() { }

        //    public string Name { get; private set; }

        //    protected Person(string name)
        //    {
        //        Name = name;
        //    }

        //    public DateTime DateOfBirth
        //    {
        //        get { return _dateOfBirth; }
        //        set { _dateOfBirth = value; }
        //    }

        //}

        //public class Member : Person
        //{
        //    public Member() { }

        //    protected Member(string name) : base(name) { }

        //    public DateTime EffectiveDate { get; set; }
        //}

        //public class PolicyHolder : Member
        //{
        //    public PolicyHolder(string name, DateTime dateOfBirth)
        //    {
        //        // doesn't compile, inaccessable because _name is private to Person
        //        //_name = name;

        //        // compiles, accessable because _dateOfBirth is protected by Person so all it's child classes can access it.
        //        _dateOfBirth = dateOfBirth;
        //    }

        //    public PolicyHolder(string name) : base(name) { }


        //    public Dependent[] Dependents { get; set; }
        //}

        //public class Dependent : Member
        //{
        //    public PolicyHolder PolicyHolder { get; set; }
        //}


        //public class Animal
        //{
        //    public void Eat()
        //    {
        //        Console.WriteLine("Eating yummy food.");
        //    }
        //}

        //public interface IWingedAnimal
        //{
        //    void Fly();
        //}

        //public interface IMammal
        //{
        //    void Breath();
        //}

        //public class Bat : Animal, IWingedAnimal, IMammal
        //{
        //    public void Fly()
        //    {
        //        Console.WriteLine("Bat is flying");
        //    }

        //    public void Breath()
        //    {
        //        Console.WriteLine("Bat is breathing");
        //    }
        //}

        //public class Bird : Animal, IWingedAnimal
        //{
        //    public void Fly()
        //    {
        //        Console.WriteLine("Bird is flying");
        //    }
        //}

        #endregion

        #region Linq

        //private static readonly int[] Ints1 = { 1, 2, 3, 4, 5, 6 };
        //private static readonly int[] Ints2 = { 5, 6, 7, 8, 9, 10 };

        //static void Main()
        //{
        //    var context = new DataModel();

        //    //JoinExample(context.People, context.Claims);
        //    //CastExample(context.Cars);
        //    //ConcatExample();
        //    //UnionExample();
        //    //IntersectExample();
        //    //ExceptExample();
        //    //ContainsExample();
        //    //ZipExample();
        //    //DefaultIfEmptyExample();
        //    //DistinctExample();
        //    //FirstExample(context.People);
        //    //LastExample(context.People);
        //    //SingleExample(context.People);
        //    //GroupByExample(context);
        //    //GroupJoinExample in Mapper.cs
        //    //SelectExample(context);
        //    ComputingExample(context);


        //    Console.ReadKey(true);
        //}

        //private static void ComputingExample(DataModel context)
        //{
        //    var result1 = Ints1.Sum();
        //    var result2 = Ints1.Aggregate((x, y) => x * y);
        //    var result3 = Ints1.Average();
        //    var result4 = Ints1.Min();
        //    var result5 = context.Claims.Min(x => x.Amount);
        //    var result6 = context.Claims.Max(x => x.Amount);
        //}

        //private static void SelectExample(DataModel context)
        //{
        //    var select1 = context.People.Select(x => x.FirstName).ToList();
        //    var select2 = context.People.Select(x => x.Claims.Where(y => y.Amount > 100)).ToList();
        //    var select3 = context.People.SelectMany(x => x.Claims.Where(y => y.Amount > 100)).ToList();
        //    var select4 = context.People.Select(x => new { Name = $"{x.FirstName} {x.LastName}", ClaimsNums = x.Claims.Select(y => y.ClaimNumber) }).ToList();

        //    var select5 = (from person in context.People
        //                  where person.Claims.Count > 2
        //                  select person.FirstName).ToList();

        //    var select6 = context.People.Where(x => x.Claims.Count > 2).Select(x => x.FirstName).ToList();
        //}

        //private static void ZipExample()
        //{
        //    var result = Ints1.Zip(Ints2, (x, y) => x * y);
        //}

        //private static void UnionExample()
        //{
        //    var result = Ints1.Union(Ints2);
        //}

        //private static void SingleExample(ICollection<Person> people)
        //{
        //    people.Add(new Person { FirstName = "Steve" });

        //    //var person1 = people.Single(x => x.FirstName == "Steve");
        //    var person2 = people.SingleOrDefault(x => x.FirstName == "Matt");
        //    //var person3 = people.Single(x => x.FirstName == "Matt");
        //    var person4 = people.Single(x => x.FirstName == "Tony");
        //}


        //private static void JoinExample(ICollection<Person> people, ICollection<Claim> claims)
        //{
        //    var results = people.Join(claims, p => p.PersonId, c => c.PersonId, (p, c) => new { Person = p, Claim = c });
        //}

        //private static void IntersectExample()
        //{
        //    var result = Ints1.Intersect(Ints2);
        //}

        //private static void GroupByExample(DataModel context)
        //{
        //    var groupedclaims = context.Claims.GroupBy(x => x.Person).ToList();

        //    foreach (var groupedclaim in groupedclaims)
        //    {
        //        Console.WriteLine($"{groupedclaim.Key.FirstName} {groupedclaim.Key.LastName} Claims:");
        //        foreach (var claim in groupedclaim)
        //        {
        //            Console.WriteLine($"{claim.ClaimId} {claim.ClaimDate} {claim.Amount}");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //private static void LastExample(ICollection<Person> people)
        //{
        //    var lastPerson = people.Last();

        //    //FirstOrDefault
        //    var nullPerson = people.LastOrDefault(x => x.FirstName == "Matthew");
        //    var exceptionPerson = people.Last(x => x.FirstName == "Matthew");
        //}

        //private static void FirstExample(ICollection<Person> people)
        //{
        //    var firstPerson = people.First();

        //    //FirstOrDefault
        //    var nullPerson = people.FirstOrDefault(x => x.FirstName == "Matthew");
        //    var exceptionPerson = people.First(x => x.FirstName == "Matthew");
        //}

        //private static void ExceptExample()
        //{
        //    var result = Ints1.Except(Ints2);
        //}

        //private static void CastExample(IEnumerable<Vehicle> vehicles)
        //{
        //    var cars = vehicles.Cast<Car>();
        //}

        //private static void ConcatExample()
        //{
        //    var result = Ints1.Concat(Ints2);
        //}

        //private static void ContainsExample()
        //{
        //    var result1 = new[] { 1, 2, 3, 4, 5, 6 }.Contains(4);
        //    var result2 = "Hi my name is Steve.".Contains("Steve");
        //}

        //private static void DefaultIfEmptyExample()
        //{
        //    var list1 = new List<int>();

        //    var list2 = list1.DefaultIfEmpty();

        //    foreach (var i in list1)
        //    {
        //        Console.WriteLine(i);
        //    }

        //    Console.ReadKey(true);

        //    foreach (var i in list2)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}

        //private static void DistinctExample()
        //{
        //    var list1 = new[] { 1, 2, 3, 3, 3, 4, 5, 5, 6 };
        //    var list2 = list1.Distinct();

        //    Console.WriteLine("List1:");
        //    foreach (var i in list1)
        //    {
        //        Console.WriteLine(i);
        //    }

        //    Console.WriteLine("List2:");
        //    foreach (var i in list2)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}

        #endregion

        #region Access Modifiers / Misc Keywords

        //static void Main()
        //{

        //}

        //static void Main()
        //{
        //    Person person = new Person();
        //    person.Talk();
        //    person.Move();
        //    Console.WriteLine();

        //    Child child = new Child();
        //    child.Talk();
        //    child.Move();
        //    Console.WriteLine();

        //    Person person2 = new Child();
        //    person2.Talk();
        //    person2.Move();

        //    Console.ReadLine();
        //}

        //public class Person
        //{
        //    private string _name;
        //    protected DateTime _dateOfBirth;

        //    public string Name { get { return _name; } set { _name = value; } }
        //    public DateTime DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }

        //    public void Talk()
        //    {
        //        Console.WriteLine("Person Talking");
        //    }

        //    public virtual void Move()
        //    {
        //        Console.WriteLine("Person moving");
        //    }

        //}

        //public sealed class Developer : Person
        //{
        //    public Developer()
        //    {
        //        _dateOfBirth = new DateTime();
        //        //_name = "Clint Barton";
        //    }
        //}

        //public class RyanClone : Developer
        //{
        //    public string MuscleSize { get; set; } = "Huge";
        //}

        //public class Child : Person
        //{
        //    public new void Talk()
        //    {
        //        Console.WriteLine("Child Talking");
        //    }

        //    public override void Move()
        //    {
        //        Console.WriteLine("Child Moving");
        //    }
        //}

        #endregion

        #region Extention Methods and Operators

        //public static void Main()
        //{
        //    new Person().DisplayPerson();
        //    var myPerson = new Person();
        //    myPerson.DisplayPerson();

        //    var person1 = new Person
        //    {
        //        DateOfBirth = new DateTime(1920, 7, 19)
        //    };
        //    var person2 = new Person();

        //    //- operator
        //    Console.WriteLine($"- operator: {person1 - person2}");
        //    //== operator
        //    Console.WriteLine($"== operator: {person1 == person2}");

        //    Console.ReadLine();
        //}

        #endregion

        #region C#6

        //static void Main(string[] args)
        //{
        //    //String Interpolation
        //    var hawkeye = new Person("Clint", "Barton");
        //    var fullName = hawkeye.FirstName + " " + hawkeye.LastName; //Old way
        //    var fullName2 = string.Format("{0} {1}", hawkeye.FirstName, hawkeye.LastName); //Old way
        //    var fullName3 = $"{hawkeye.FirstName} {hawkeye.LastName}"; //New way
        //    Console.WriteLine(fullName);
        //    Console.WriteLine(fullName2);
        //    Console.WriteLine(fullName3);
        //    Console.WriteLine();


        //    //Auto-Implemented Properties
        //    var captain = new Person();
        //    Console.WriteLine(captain.FirstName);
        //    Console.WriteLine(captain.LastName);
        //    Console.WriteLine(captain.Dob);
        //    Console.WriteLine();


        //    //using static
        //    WriteLine("using static example");
        //    WriteLine();


        //    //Null-Conditional Operator
        //    var ironman = new Person("Tony", "Stark");
        //    //var ironmanCity = ironman.Address.City;
        //    //var ironmanCity = ironman.Address?.City;
        //    var ironmanCity = ironman.Address?.City ?? "City not found.";
        //    Console.WriteLine(ironmanCity);
        //    Console.WriteLine();


        //    //nameof
        //    var myExampleVariable = string.Empty;
        //    Console.WriteLine(nameof(myExampleVariable));
        //    Console.WriteLine();


        //    //Exception filtering
        //    try
        //    {
        //        //throw new IndexOutOfRangeException("BadIndex");
        //        //throw new IndexOutOfRangeException();
        //        throw new ArgumentNullException();
        //    }
        //    catch (IndexOutOfRangeException ex) when (ex.Message.Equals("BadIndex"))
        //    {
        //        Console.WriteLine("Caught BadIndex");
        //    }
        //    catch (IndexOutOfRangeException)
        //    {
        //        Console.WriteLine("Caught IndexOutOfRangeException");
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Caught Exception");
        //    }
        //    Console.WriteLine();


        //    //Expression-bodied members
        //    Console.WriteLine(ironman.OldFullName);
        //    Console.WriteLine(ironman.NewFullName);

        //    Console.ReadLine();

        //}

        //class Person
        //{

        //    public string FirstName { get; } = "Steve";
        //    public string LastName { get; } = "Rogers";
        //    public string OldFullName { get { return $"{FirstName} {LastName}"; } }
        //    public string NewFullName => $"{FirstName} {LastName}";
        //    public DateTime Dob { get; set; } = new DateTime(1920, 7, 4);
        //    public Address Address { get; set; }

        //    public Person()
        //    {

        //    }

        //    public Person(string firstName, string lastName)
        //    {
        //        FirstName = firstName;
        //        LastName = lastName;
        //    }


        //}

        //public class Address
        //{
        //    public string Street { get; set; }
        //    public string City { get; set; }
        //    public string State { get; set; }
        //    public string Zip { get; set; }
        //}

        #endregion

        #region Dependency Injection

        static void Main(string[] args)
        {
            //Breads
            var ryeBread = new RyeBread("Rainbow");
        var wheatBread = new WheatBread("Franz");

        //Meats
        var ham = new Ham("Fresh");
        var turkey = new Turkey("Rotten");

        //Condiments
        var condiments = new List<ICondiment>
            {
                new Mayo("Hellmans"),
                new Mustard("French's"),
                new Ketchup("Heinz")
            };

        //Sandwiches
        var sandwiches = new List<Sandwich>
            {
                new Sandwich(ryeBread, ham, condiments),
                new Sandwich(wheatBread, ham, condiments),
                new Sandwich(ryeBread, turkey, condiments)
            };

        var sandwichNumber = 1;
            foreach (var sandwich in sandwiches)
            {
                Console.WriteLine($"Making sandwich {sandwichNumber++}");
                sandwich.Assemble();
                Console.WriteLine("Completed sandwich");
                Console.WriteLine();
            }


    Console.ReadKey();
        }

class Sandwich
{
    IBread Bread { get; }
    IMeat Meat { get; }
    ICollection<ICondiment> Condiments { get; }

    public Sandwich(IBread bread, IMeat meat, ICollection<ICondiment> condiments)
    {
        Bread = bread;
        Meat = meat;
        Condiments = condiments;
    }

    public void Assemble()
    {
        Bread.Apply();
        Meat.Apply();
        foreach (var condiment in Condiments)
        {
            condiment.Apply();
        }
        Bread.Apply();
    }
}

interface IMeat
{
    string Age { get; set; }
    void Apply();
}

class Ham : IMeat
{
    public string Age { get; set; }

    public Ham(string age)
    {
        Age = age;
    }

    public void Apply()
    {
        Console.WriteLine($"The {Age} {nameof(Ham)} has been applied.");
    }
}

class Turkey : IMeat
{
    public string Age { get; set; }

    public Turkey(string age)
    {
        Age = age;
    }

    public void Apply()
    {
        Console.WriteLine($"The {Age} {nameof(Turkey)} has been applied.");
    }
}

interface IBread
{
    string Company { get; set; }
    void Apply();
}

class WheatBread : IBread
{
    public string Company { get; set; }

    public WheatBread(string company)
    {
        Company = company;
    }

    public void Apply()
    {
        Console.WriteLine($"The {Company} {nameof(WheatBread)} has been applied.");
    }
}

class RyeBread : IBread
{
    public string Company { get; set; }

    public RyeBread(string company)
    {
        Company = company;
    }

    public void Apply()
    {
        Console.WriteLine($"The {Company} {nameof(RyeBread)} has been applied.");
    }
}

interface ICondiment
{
    string Brand { get; set; }
    void Apply();
}

class Mayo : ICondiment
{
    public string Brand { get; set; }

    public Mayo(string brand)
    {
        Brand = brand;
    }

    public void Apply()
    {
        Console.WriteLine($"The {Brand} {nameof(Mayo)} has been applied.");
    }
}

class Mustard : ICondiment
{
    public string Brand { get; set; }

    public Mustard(string brand)
    {
        Brand = brand;
    }

    public void Apply()
    {
        Console.WriteLine($"The {Brand} {nameof(Mustard)} has been applied.");
    }
}

class Ketchup : ICondiment
{
    public string Brand { get; set; }

    public Ketchup(string brand)
    {
        Brand = brand;
    }

    public void Apply()
    {
        Console.WriteLine($"The {Brand} {nameof(Ketchup)} has been applied.");
    }
}

        #endregion

        #region Reflection

        //    static void Main(string[] args)
        //    {
        //        var props = typeof(Person).GetProperties();


        //        var prop = typeof(Person).GetProperty("FirstName");
        //        var dateProp = typeof(Person).GetProperty("DateOfBirth");


        //        var person = new Person { FirstName = "Bruce", LastName = "Banner", DateOfBirth = new DateTime(1969, 12, 18) };

        //        var test = typeof(Person);
        //        var test2 = person.GetType();
        //        var myClass = Activator.CreateInstance(test);

        //        var testType = myClass.GetType();

        //        ChangeStringProperty(person, "Brian", prop);


        //        ChangeDynamicProperty(person, "1952/08/22", dateProp);

        //        ExecuteMethod(person, "WriteName");


        //        Console.ReadKey();

        //    }

        //    public static void ChangeStringProperty(object obj, string newValue, PropertyInfo propToChange)
        //    {
        //        Console.WriteLine($"Before: {propToChange.Name} - {propToChange.GetValue(obj)}");

        //        propToChange.SetValue(obj, newValue);




        //        Console.WriteLine($"After: {propToChange.Name} - {propToChange.GetValue(obj)}");
        //    }

        //    public static void ChangeDynamicProperty(object obj, string newValue, PropertyInfo propToChange)
        //    {
        //        Console.WriteLine($"Before: {propToChange.Name} - {propToChange.GetValue(obj)}");


        //        propToChange.SetValue(obj, Convert.ChangeType(newValue, propToChange.PropertyType));



        //        Console.WriteLine($"After: {propToChange.Name} - {propToChange.GetValue(obj)}");
        //    }

        //    public static void ExecuteMethod(object obj, string methodName)
        //    {
        //        var type = obj.GetType();
        //        var method = type.GetMethod(methodName);
        //        method.Invoke(obj, null);

        //        obj.GetType().GetMethod(methodName).Invoke(obj, null);

        //    }

        //}

        //public class Person
        //{
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public DateTime DateOfBirth { get; set; }

        //    public void WriteName()
        //    {
        //        Console.WriteLine($"From WriteName: {FirstName} {LastName}");
        //    }

        //}

        #endregion
    }
}
