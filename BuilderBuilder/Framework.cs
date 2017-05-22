﻿using System.Linq;

namespace BuilderBuilder
{
    class Frameworks
    {
        private static Framework[] _frameworks;
        public static Framework[] All = _frameworks ?? BuildFrameworks();

        private static Framework[] BuildFrameworks() {
            _frameworks = new Framework[] {
                new Framework("C# NHibernate", "CsNhibernate", new NhibernateParser(), new VipCompiler())
            };
            return _frameworks;
        }

        public static Framework FromSlug(string slug) {
            return All.First(f => f.Slug == slug);
        }

        public static int IndexOf(Framework framework) {
            for (int i = 0; i < All.Length; i++) {
                if (All[i] == framework) {
                    return i;
                }
            }
            return -1;
        }
    }

    class Framework
    {
        public string Name { get; private set; }
        public string Slug { get; private set; }

        public Parser Parser { get; private set; }
        public Compiler Compiler { get; private set; }

        public Framework(string name, Parser parser, Compiler compiler) : this(name, name, parser, compiler) { }

        public Framework(string name, string slug, Parser parser, Compiler compiler) {
            Name = name;
            Slug = slug;
            Parser = parser;
            Compiler = compiler;
        }
    }
}