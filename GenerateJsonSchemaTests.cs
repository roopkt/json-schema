using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NJsonSchema.Generation;
using Xunit;

namespace sample
{
    public class GenerateJsonSchemaTests
    {
        [Fact]
        public   void I_Can_Generate__Json_Schema
            ()
        {
            var task = NJsonSchema.JsonSchema4.FromTypeAsync<Person>();
            task.Wait();
            var json = task.Result.ToJson();
            Assert.Null(json);
        }

     //   [Fact]
        public void I_Can_Generate_Typescript_Person()
        {
            //var person = new Person
            //{
            //    Name = "Adam",
            //    Age = 12,
            //    Address = new Address {AddressLines = new List<AddressLine> {new AddressLine {Line = "Cool Street"}}}
            //};
            
            //var json = JsonConvert.SerializeObject(person);


            var task = NJsonSchema.JsonSchema4.FromTypeAsync<Person>();
            task.Wait();
            var schema = task.Result;
          //  var generator = new TypeScriptGenerator(schema);
         //   Assert.Null(json);
        }

    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public List<AddressLine> AddressLines { get; set; }
    }
    public class AddressLine
    {
        public string Line { get; set; }
    }
}
