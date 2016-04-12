using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLanguageService.Regex
{
    public class TestLanguageService : LanguageService
    {
        private LanguagePreferences languagePreferences;
        private IScanner scanner;
        
        public override string Name
        {
            get
            {
                return "Test Language";
            }
        }

        public TestLanguageService()
        {
            
        }
 
        public override string GetFormatFilterList()
        {
            return null;
        }

        public override LanguagePreferences GetLanguagePreferences()
        {
            if (this.languagePreferences == null)
            {
                this.languagePreferences = new LanguagePreferences(this.Site, typeof(TestLanguageService).GUID, this.Name);
                this.languagePreferences.Init();
            }

            return this.languagePreferences;
        }

        public override Colorizer GetColorizer(IVsTextLines buffer)
        {
            var scanner = GetScanner(buffer);
            return new TestColorizer(this, buffer, scanner);
        }

        public override IScanner GetScanner(IVsTextLines buffer)
        {
            if(this.scanner == null)
                this.scanner = new TestScanner(buffer);
            return this.scanner;
        }

        public override AuthoringScope ParseSource(ParseRequest req)
        {
            var authoringScope = new TestAuthoringScope();
            switch (req.Reason)
            {
                case ParseReason.None:
                    break;
                case ParseReason.MemberSelect:
                    break;
                case ParseReason.HighlightBraces:
                    break;
                case ParseReason.MemberSelectAndHighlightBraces:
                    break;
                case ParseReason.MatchBraces:
                    break;
                case ParseReason.Check:
                    break;
                case ParseReason.CompleteWord:
                    break;
                case ParseReason.DisplayMemberList:
                    break;
                case ParseReason.QuickInfo:
                    break;
                case ParseReason.MethodTip:
                    break;
                case ParseReason.Autos:
                    break;
                case ParseReason.CodeSpan:
                    break;
                case ParseReason.Goto:
                    break;
                default:
                    break;
            }

            return authoringScope;
        }
    }
}
