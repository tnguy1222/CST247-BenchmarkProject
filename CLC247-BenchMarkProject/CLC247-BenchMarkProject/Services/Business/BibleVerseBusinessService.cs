/* BenchMark Project version 1.0
 * BibleVerseBusinessService version 1.0
 * Jim Nguyen
 * April 24, 2020
 * BibleVerseBusinessService
 */
using CLC247_BenchMarkProject.Models;
using CLC247_BenchMarkProject.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC247_BenchMarkProject.Services.Business
{
    public class BibleVerseBusinessService
    {
        public BibleVerseModel Search(BibleVerseModel bibleVerse)
        {
            BibleVerseDataService service = new BibleVerseDataService();
            return service.Search(bibleVerse);
        }

        public List<BibleVerseModel> SearchByPhrase(string phrase)
        {
            BibleVerseDataService service = new BibleVerseDataService();
            return service.SearchByPhrase(phrase);
        }
    }
}