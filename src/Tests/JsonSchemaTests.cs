using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Xunit;

namespace sample.Tests
{
    public class JsonSchemaTests
    {
        [Fact]
        public void Validate_Person()
        {
            var schema = JsonSchema.Parse(
                @"{
    'type': 'object',
    'properties': {
        'name': {'type':'string'},
        'hobbies': {'type': 'array'}
    },
    'additionalProperties': false
    }");
          var person = JObject.Parse(@"{'name': 'James','hobbies': ['.NET', 'LOLCATS']}");
            Assert.True(person.IsValid(schema));
        }

        [Fact]
        public void Validate_Bad_Person()
        {
            var schema = JsonSchema.Parse(
                @"{
    'type': 'object',
    'properties': {
        'name': {'type':'string'},
        'hobbies': {'type': 'array'}
    },
    'additionalProperties': false
    }");
            var person = JObject.Parse(@"{'surname': 'James','hobbies': ['.NET', 'LOLCATS']}");
            Assert.False(person.IsValid(schema));
        }

        [Fact]
        public void Validate_Bad_Person_Property_Type()
        {
            var schema = JsonSchema.Parse(
                @"{
    'type': 'object',
    'properties': {
        'name': {'type':'string'},
        'hobbies': {'type': 'array'}
    },
    'additionalProperties': false
    }");
            var person = JObject.Parse(@"{'name': 2,'hobbies': ['.NET', 'LOLCATS']}");
            Assert.False(person.IsValid(schema));
        }
    }
}
