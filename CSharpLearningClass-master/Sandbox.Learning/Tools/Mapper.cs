using System.Collections.Generic;
using System.Linq;
using Sandbox.Learning.Entities;

namespace Sandbox.Learning.Tools
{
    public static class PersonClaimLinker
    {
        //public static void LinkPersonToClaims(ICollection<Person> people, ICollection<Claim> claims)
        //{
        //    foreach (var person in people)
        //    {
        //        person.Claims.AddRange(claims.Where(x => x.PersonId == person.PersonId));
        //    }

        //    foreach (var claim in claims)
        //    {
        //        claim.Person = people.SingleOrDefault(x => x.PersonId == claim.PersonId);
        //    }
        //}

        public static void LinkPersonToClaims(ref ICollection<Person> people, ref ICollection<Claim> claims)
        {
            people = people.GroupJoin(claims,
                p => p.PersonId,
                c => c.PersonId,
                (p, c)
                    => new Person(p)
                    { Claims = c.ToList() }).ToList();

            claims = claims.GroupJoin(
                people,
                c => c.PersonId,
                p => p.PersonId,
                (c, p)
                    => new Claim(c)
                    { Person = p.SingleOrDefault(x => x.PersonId == c.PersonId) }).ToList();
        }
    }
}
