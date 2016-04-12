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

        public override IScanner GetScanner(IVsTextLines buffer)
        {
            if(this.scanner == null)
                this.scanner = new TestScanner(buffer);
            return this.scanner;
        }

        public override AuthoringScope ParseSource(ParseRequest req)
        {
            return new TestAuthoringScope();
        }
    }
}
