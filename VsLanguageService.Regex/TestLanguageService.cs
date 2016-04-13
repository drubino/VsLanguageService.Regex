using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLanguageService.Regex
{
    public class TestLanguageService : LanguageService
    {
        #region Fields

        private LanguagePreferences languagePreferences;
        private IScanner scanner;

        #endregion //Fields

        #region Properties

        public override string Name
        {
            get
            {
                return "Test Language";
            }
        }

        #endregion //Properties

        #region Constructors

        public TestLanguageService()
        {
        }

        #endregion //Constructors

        #region Methods

        #region Source

        public override Source CreateSource(IVsTextLines buffer)
        {
            var colorizer = GetColorizer(buffer);
            return new TestSource(this, buffer, colorizer);
        }

        #endregion //Source

        #region Scanner

        public override IScanner GetScanner(IVsTextLines buffer)
        {
            if (this.scanner == null)
                this.scanner = new TestScanner(buffer);
            return this.scanner;
        }

        #endregion //Scanner

        #region Parser

        public override AuthoringScope ParseSource(ParseRequest req)
        {
            var authoringScope = new TestAuthoringScope(req.Text);
            switch (req.Reason)
            {
                case ParseReason.None:
                case ParseReason.Check:
                    break;
                default:
                    break;
            }

            return authoringScope;
        }

        #endregion //Parser

        #region Colorizer

        public override Colorizer GetColorizer(IVsTextLines buffer)
        {
            var scanner = GetScanner(buffer);
            return new TestColorizer(this, buffer, scanner);
        }

        public override int GetItemCount(out int count)
        {
            return base.GetItemCount(out count);
        }

        public override int GetColorableItem(int index, out IVsColorableItem item)
        {
            return base.GetColorableItem(index, out item);
        }

        #endregion //Colorizer

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

        #endregion //Methods
    }
}
