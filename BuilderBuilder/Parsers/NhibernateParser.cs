﻿namespace BuilderBuilder
{
    public class NhibernateParser : CsParser
    {
        private BuilderEntity _result;

        public override BuilderEntity Parse(string[] lines) {
            _result = new BuilderEntity();

            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];

                parseName(lines, i, line);
                parseField(lines, i, line);
            }

            return _result;
        }

        private void parseName(string[] lines, int i, string line) {
            const string classPattern = @"^\s*public\s+class\s+(\w+)";

            if (MatchesPattern(line, classPattern) && LineHasAttribute(lines, i, "Class")) {
                _result.Name = GetPatternMatch(line, classPattern);
            }
        }

        private void parseField(string[] lines, int i, string line) {
            var field = ParsePublicVirtualField(line);
            if (field != null && LineHasParsableAttribute(lines, i)) {
                _result.Fields.Add(new Field(field.Value.type, field.Value.name));
            }
        }

        private bool LineHasParsableAttribute(string[] lines, int i) {
            return LineHasAttribute(lines, i, "Property") || LineHasAttribute(lines, i, "Id");
        }
    }
}
