﻿using Microsoft.VisualStudio.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio;
using VsLanguageService.Regex.Compiler;

namespace VsLanguageService.Regex
{
    public class TestAuthoringScope : AuthoringScope
    {
        public ParseTreeNode ParseTree { get; private set; }

        public TestAuthoringScope(string input)
        {
            var parser = new Parser();
            this.ParseTree = parser.Parse(input);
        }

        public override string GetDataTipText(int line, int col, out TextSpan span)
        {
            span = new TextSpan();
            return null;
        }

        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)
        {
            return null;
        }

        public override Methods GetMethods(int line, int col, string name)
        {
            return null;
        }

        public override string Goto(VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)
        {
            span = new TextSpan();
            return null;
        }
    }
}
