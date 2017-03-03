﻿using System.Collections.Generic;
using Newtonsoft.Json;
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
           
            var task = JsonSchema4.FromTypeAsync<Person>();
            
            task.Wait();
            
            var schema = task.Result;
         
            var generator = new TypeScriptGenerator(schema);
            
            var code = generator.GenerateFile();
            
            Assert.NotNull(code);

            var type = generator.GenerateType("person");

             Assert.NotNull(type);
        }

        [Fact]
        public void I_Can_Validate() {
            var person = new Person
            {
                Name = "Adam",
                Age = 12,
                Address = new Address { AddressLines = new List<AddressLine> { new AddressLine { Line = "Cool Street" } } }
            };

            var json = JsonConvert.SerializeObject(person);
               


        }
    }
}
