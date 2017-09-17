﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BuilderBuilder.Test
{
    [TestClass]
    public class NhibernateParserTest
    {
        private Parser Parser => new NhibernateParser();

        [TestMethod]
        public void Parse_Example() {
            BuilderEntity result = Parser.Parse(ExampleInput);

            AssertHelper.AssertBuilderEntity(result, "ExampleEntity",
                ("long?", "Id"), ("string", "Name"), ("My_class_123", "My_name_123"));
        }

        private string ExampleInput {
            get => @"
                using ...

                namespace ...
                {
                    [Class]
                    public class ExampleEntity
                    {
                        [Id]
                        public virtual long? Id { get; set; }

                        [Property]
                        public virtual string Name { get; set; }

                        [Property(Name = ""Name_123"")]
                        public virtual My_class_123 My_name_123 { get; set; }

                        [ManyToMany]
                        public virtual IEnumerable<Stuff> Stuffs { get; set; }

                        public virtual int IgnoreMe()
                        {
                            return 42;
                        }
                    }
                }
            ";
        }
    }
}
