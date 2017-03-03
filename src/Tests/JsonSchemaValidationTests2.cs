using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NJsonSchema;
using sample.Models;
using Xunit;

namespace sample.Tests
{
    public class JsonSchemaValidationTests2
    {

        [Fact]
        public void I_Can_Validate_Person_Json_Against_Schema()
        {
            var schema = GetPersonJsonSchema();

            const string personJson = @"{
	""Name"": ""Adam"",
	""Age"": 12,
	""Address"": {
		""AddressLines"": [{
			""Line"": ""Cool Street""
		}]
	}
}";
            var validationError = schema.Validate(personJson);

            Assert.Equal(0, validationError.Count);
        }


        [Fact]
        public void I_Can_Validate_Person_Bad_Json()
        {

            const string personJson = @"{
	""Name"": ""Adam"",
	""Age"": ""12"",
	""Address"": {
		""AddressLines"": [{
			""Line"": ""Cool Street""
		}]
	}
}";
            var schema = GetPersonJsonSchema();

            var validationError = schema.Validate(personJson);

            Assert.Equal(1, validationError.Count);

            Assert.Equal(NJsonSchema.Validation.ValidationErrorKind.IntegerExpected, validationError.First().Kind);

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
