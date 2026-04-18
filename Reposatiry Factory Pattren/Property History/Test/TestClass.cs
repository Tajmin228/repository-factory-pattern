using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_History
{
    public class TestClass
    {
        IRepoCompany company;
        public TestClass(IRepoCompany company)
        {
            this.company = company;
        }
        public void Run()
        {
            IRepo<Category> repoC = company.CreateRepo<Category>();
            repoC.AddRange(new Category[]
            {
                new Category{id=1,Name="Residential"},
                new Category{id=2,Name="Commercial"},
                new Category{id=3,Name="Industrial"},
                new Category{id=4,Name="Agricultural"},

            });
            Console.WriteLine("==================Get All==================");
            repoC.GetAll().ToList().ForEach(c => Console.WriteLine($"{c.id},{c.Name}"));
            Console.WriteLine();

            Console.WriteLine("============================Get==================");
            var city = repoC.Get(3);
            Console.WriteLine($"ID : {city.id},Name : {city.Name}");
            Console.WriteLine();

            Console.WriteLine("============================Update==================");
            city.Name = "Commercial";
            repoC.Update(city);
            repoC.GetAll().OrderBy(x=>x.id).ToList().ForEach(c => Console.WriteLine($"ID : {c.id},Name : {c.Name}"));
            Console.WriteLine();

            Console.WriteLine("============================delete==================");
            repoC.Delete(4);
            repoC.GetAll().OrderBy(x => x.id).ToList().ForEach(c => Console.WriteLine($"ID : {c.id},Name : {c.Name}"));
            Console.WriteLine();

            Console.WriteLine("============================Add==================");
            IRepo<Property> repoP= company.CreateRepo<Property>();
            repoP.AddRange(new Property[]
            {
                new Property{id=1,PropertyName="Abason",Location="Purbachal-sector(30)",TypeOfLand="Nal",Size="5 Katha",Price=4800000,CategoryId=1},
                new Property{id=2,PropertyName="Nikunjo",Location="Purbachal-sector(27)",TypeOfLand="Store",Size="10 Katha",Price=8000000,CategoryId=2},
                new Property{id=3,PropertyName="Dewliya",Location="Purbachal-sector(29)",TypeOfLand="Shiplo",Size="12 Katha",Price=9000000,CategoryId=3},
                new Property{id=4,PropertyName="Abason",Location="Purbachal-sector(25)",TypeOfLand="Nal",Size="5 Katha",Price=4800000,CategoryId=1},

            });
            Console.WriteLine("===================Property================");
            Console.WriteLine("==================Get All==================");
            repoP.GetAll().ToList().ForEach(p => Console.WriteLine($"{p.id},{p.PropertyName},{p.Location},{p.Size}"));
            Console.WriteLine();

            Console.WriteLine("============================Get==================");
            var prop = repoP.Get(2);
            Console.WriteLine($"ID : {prop.id},PropertyName : {prop.PropertyName},Location : {prop.Location},Size : {prop.Size}");
            Console.WriteLine();

            Console.WriteLine("============================Update==================");
            prop.Size = "15 Katha";
            repoP.Update(prop);
            repoP.GetAll().OrderBy(x => x.id).ToList().ForEach(p => Console.WriteLine($"ID : {p.id},PropertyName : {p.PropertyName},Location : {p.Location},Size : {p.Size}"));
            Console.WriteLine();

            Console.WriteLine("============================delete==================");
            repoP.Delete(3);
            repoP.GetAll().OrderBy(x => x.id).ToList().ForEach(p => Console.WriteLine($"ID : {p.id},PropertyName : {p.PropertyName},Location : {p.Location},Size : {p.Size}"));
            Console.WriteLine();



        }
    }
}
