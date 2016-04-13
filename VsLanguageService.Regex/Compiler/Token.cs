using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLanguageService.Regex.Compiler
{
    public enum ParserTokenType
    {
        Expression,
        Addition,
        Subtraction,
        Character,
        EndOfStream
    }

    public class Token
    {
        public ParserTokenType Type { get; private set; }
        public string Value { get; private set; }

        public Token(ParserTokenType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{ this.Type }: {Value}";
        }
    }
}
