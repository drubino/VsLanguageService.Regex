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
        private int index;
        private string source;
        private Lexer lexer;
        private IEnumerable<Token> tokens;

        public TestScanner(IVsTextBuffer buffer)
        {
            this.buffer = buffer;
            this.lexer = new Lexer();
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            var found = false;
            if (tokenInfo != null)
                found = GetNextToken(tokenInfo, ref state);
            return found;
        }

        public void SetSource(string source, int offset)
        {
            this.offset = offset;
            this.index = 0;
            this.source = source;

            try
            {
                this.tokens = this.lexer.Lex(this.source).ToList();
            }
            catch
            {
                this.tokens = Enumerable.Empty<Token>();
            }
        }

        private bool GetNextToken(TokenInfo tokenInfo, ref int state)
        {
            var token = this.tokens.ElementAtOrDefault(this.index++);
            if (token != null)
            {
                var tokenLength = token.Value.Length == 0 ? 0 : token.Value.Length - 1;
                tokenInfo.StartIndex = this.offset;
                tokenInfo.EndIndex = this.offset + tokenLength;

                switch (token.Type)
                {
                    case ParserTokenType.Addition:
                    case ParserTokenType.Subtraction:
                        tokenInfo.Color = TokenColor.Keyword;
                        break;
                    case ParserTokenType.Character:
                        tokenInfo.Color = TokenColor.String;
                        break;
                    case ParserTokenType.EndOfStream:
                    default:
                        tokenInfo.Color = TokenColor.Text;
                        break;
                }
                
                this.offset += token.Value.Length;
            }
            
            return token != null && token.Type != ParserTokenType.EndOfStream;
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
