using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLanguageService.Regex.Compiler
{
    public class Lexer
    {
        public IEnumerable<Token> Lex(string input)
        {
            foreach (var character in (input ?? "") + "\n")
            {
                switch (character)
                {
                    case '-':
                        yield return new Token(ParserTokenType.Subtraction, character.ToString());
                        break;
                    case '+':
                        yield return new Token(ParserTokenType.Addition, character.ToString());
                        break;
                    case 'a':
                        yield return new Token(ParserTokenType.Character, character.ToString());
                        break;
                    case '\n':
                        yield return new Token(ParserTokenType.EndOfStream, "");
                        break;
                    default:
                        throw new Exception($"The character { character } is not part of the language");
                }
            }
        }
    }
}
