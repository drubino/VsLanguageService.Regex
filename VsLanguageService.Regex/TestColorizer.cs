using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VsLanguageService.Regex
{
    class TestColorizer : Colorizer
    {
        public TestColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner) 
            : base(svc, buffer, scanner)
        {
        }
    }
}
