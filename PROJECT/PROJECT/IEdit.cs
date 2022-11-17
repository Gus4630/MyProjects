using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT
{
    internal interface IEdit
    {
        bool Add_Word(Dictionary d, Wordclass w);
        bool Remove_Word(Dictionary d, Wordclass w);
        bool Remove_Word(Dictionary d, Wordclass word, string translation);
        bool Word_Edit(Dictionary d, Wordclass _old, Wordclass _new);
        bool Word_Edit(Dictionary d, Wordclass word, string old_translation, string new_translation);
    }
}
