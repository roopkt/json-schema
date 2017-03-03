using NJsonSchema;
using NJsonSchema.CodeGeneration.TypeScript;
using sample.Models;
using Xunit;

namespace sample.Tests
{
    public class GenerateJsonSchemaTests
    {
        [Fact]
        public void I_Can_Generate__Json_Schema
            ()
        {
            var task = JsonSchema4.FromTypeAsync<Person>();
            task.Wait();
            var json = task.Result.ToJson();
            Assert.NotNull(json);
        }

        [Fact]
        public void I_Can_Generate_Typescript_Person()
        {
            var schema = GetPersonJsonSchema();
            var generator = new TypeScriptGenerator(schema);
            var type = generator.GenerateType("person");
            Assert.NotNull(type);
        }

        private static JsonSchema4 GetPersonJsonSchema()
        {
            var task = JsonSchema4.FromTypeAsync<Person>();

            task.Wait();

            var schema = task.Result;
            return schema;
        }
    }
}
