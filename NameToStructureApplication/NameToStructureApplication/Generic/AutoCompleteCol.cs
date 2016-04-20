using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NameToStructureApplication.Generic
{
    public static class AutoCompleteCol
    {

        private static AutoCompleteStringCollection _tancollection = null;
        public static AutoCompleteStringCollection TANcollection
        {
            get { return _tancollection; }
            set { _tancollection = value; }
        }
    }
}
