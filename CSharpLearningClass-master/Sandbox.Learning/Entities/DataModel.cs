using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Learning.Tools;

namespace Sandbox.Learning.Entities
{
    public class DataModel
    {
        private ICollection<Claim> _claims = DataGenerator.GenerateClaims();
        private ICollection<Person> _people = DataGenerator.GeneratePeople();

        public ICollection<Claim> Claims
        {
            get { return _claims; }
            set { _claims = value; }
        } 
        public ICollection<Person> People
        {
            get { return _people; }
            set { _people = value; }
        }
        public ICollection<Car> Cars { get; set; } = DataGenerator.GenerateCars();
        public ICollection<int> Ints { get; set; } = DataGenerator.GenerateInts();


        public DataModel()
        {
            PersonClaimLinker.LinkPersonToClaims(ref _people, ref _claims);
        }
    }
}
