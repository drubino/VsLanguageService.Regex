using Microsoft.VisualStudio.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio;

namespace VsLanguageService.Regex
{
    public class TestSource : Source
    {
        public TestSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer) 
            : base(service, textLines, colorizer)
        {
        }

        public override void OnCommand(IVsTextView textView, VSConstants.VSStd2KCmdID command, char ch)
        {
            base.OnCommand(textView, command, ch);
        }

        public override TokenInfo GetTokenInfo(int line, int col)
        {
            return base.GetTokenInfo(line, col);
        }
    }
}
