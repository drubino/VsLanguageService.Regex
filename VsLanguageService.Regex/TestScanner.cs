using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLanguageService.Regex
{
    public class TestScanner : IScanner
    {
        private string line;
        private int offset;
        private string source;
        private IVsTextBuffer buffer;

        public TestScanner(IVsTextBuffer buffer)
        {

            this.buffer = buffer;
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo,
                                                   ref int state)
        {
            var found = false;
            if (tokenInfo != null)
            {
                found = GetNextToken(offset, tokenInfo, ref state);
                if (found)
                    this.offset++;
            }
            return found;
        }

        public void SetSource(string source, int offset)
        {
            this.offset = offset;
            this.source = source;
        }

        private bool GetNextToken(int startIndex,
                                 TokenInfo tokenInfo,
                                 ref int state)
        {
            var foundToken = false;
            tokenInfo.StartIndex = startIndex;
            if (startIndex < source.Length)
            {
                var character = source.Substring(startIndex, 1);
                if (character == "a")
                {
                    foundToken = true;
                    tokenInfo.Token = (int)ParseState.A;
                    tokenInfo.EndIndex = startIndex;
                    tokenInfo.Color = TokenColor.Keyword;
                    tokenInfo.Type = TokenType.Keyword;
                    state = 0;
                }
                else if (character == "b")
                {
                    foundToken = true;
                    tokenInfo.Token = (int)ParseState.B;
                    tokenInfo.EndIndex = startIndex;
                    tokenInfo.Color = TokenColor.String;
                    tokenInfo.Type = TokenType.String;
                    state = 1;
                }
                else
                {
                    foundToken = true;
                    tokenInfo.Token = (int)ParseState.Unknown;
                    tokenInfo.EndIndex = startIndex;
                    tokenInfo.Color = TokenColor.Text;
                    tokenInfo.Type = TokenType.Text;
                    state = 1;
                }
            }
            return foundToken;
        }
        
        private enum ParseState
        {
            A = 0,
            B = 1,
            Unknown
        }
    }
}
