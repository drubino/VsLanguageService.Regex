using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLanguageService.Regex.Compiler
{
    public class ParseTreeNode
    {
        public ParserTokenType Type { get; private set; }
        public Token Token { get; private set; }
        public bool IsTerminal { get { return this.Token != null; } }
        public IEnumerable<ParseTreeNode> Children { get; private set; }
        
        public ParseTreeNode(Token token)
        {
            this.Type = token.Type;
            this.Token = token;
        }

        public ParseTreeNode(ParserTokenType type, IEnumerable<ParseTreeNode> children)
        {
            this.Type = type;
            this.Children = children;
        }
        
        public override string ToString()
        {
            return this.IsTerminal ? 
                this.Token.Value : 
                string.Join("", this.Children);
        }
    }
}
