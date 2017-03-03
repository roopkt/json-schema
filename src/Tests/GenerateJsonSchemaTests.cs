using System.Threading.Tasks;
using Newtonsoft.Json;
using NJsonSchema.CodeGeneration.TypeScript;
using NJsonSchema.Generation;
using Xunit;

namespace sample.Tests
{
    public class GenerateJsonSchemaTests
    {
        [Fact]
        public void I_Can_Generate__Json_Schema
            ()
        {
            var task = NJsonSchema.JsonSchema4.FromTypeAsync<Person>();
            task.Wait();
            var json = task.Result.ToJson();
            Assert.NotNull(json);
        }

        [Fact]
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
         
            var generator = new TypeScriptGenerator(schema);
            
            var code = generator.GenerateFile();
            
            Assert.NotNull(code);

            var type = generator.GenerateType("person");

             Assert.NotNull(type);
        }
    }
}
