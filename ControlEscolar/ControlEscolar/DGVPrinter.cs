using System;
using System.Windows.Forms;

namespace ControlEscolar
{
    internal class DGVPrinter
    {
        internal object subtitle;

        public string Title { get; internal set; }
        public bool PageNumbers { get; internal set; }
        public bool PorportionalColumns { get; internal set; }

        internal void PrintDataGridView(DataGridView dgAlumnos)
        {
            throw new NotImplementedException();
        }
    }
}