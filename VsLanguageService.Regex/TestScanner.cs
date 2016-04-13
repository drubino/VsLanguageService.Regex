using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsLanguageService.Regex.Compiler;

namespace VsLanguageService.Regex
{
    public class TestScanner : IScanner
    {
        private IVsTextBuffer buffer;
        private int offset;
        private string source;
        private Lexer lexer;
        private List<Token> tokens;

        public TestScanner(IVsTextBuffer buffer)
        {
            this.buffer = buffer;
            this.lexer = new Lexer();
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            var found = false;
            if (tokenInfo != null)
                found = GetNextToken(offset, tokenInfo, ref state);
            return found;
        }

        public void SetSource(string source, int offset)
        {
            this.offset = offset;
            this.source = source;
            this.tokens = this.lexer.Lex(this.source).ToList();
        }

        private bool GetNextToken(int index, TokenInfo tokenInfo, ref int state)
        {
            var token = this.tokens.ElementAtOrDefault(index++);
            if (token != null)
            {
                switch (token.Type)
                {
                    case ParserTokenType.Expression:
                        break;
                    case ParserTokenType.Addition:
                        break;
                    case ParserTokenType.Subtraction:
                        break;
                    case ParserTokenType.Character:
                        break;
                    case ParserTokenType.EndOfStream:
                        break;
                    default:
                        break;
                }
            }
            
            return token != null || token.Type != ParserTokenType.EndOfStream;
        }
        
        private enum ParseState
        {
            Unknown = 0,
            A = 1,
            B = 2,
            C = 3,
        }
    }
}
