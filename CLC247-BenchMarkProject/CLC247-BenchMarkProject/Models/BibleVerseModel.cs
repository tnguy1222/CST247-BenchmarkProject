/* BenchMark Project version 1.0
 * BibileVerseModel version 1.0
 * Jim Nguyen
 * April 24, 2020
 * BibileVerseModel class acts as a Model
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC247_BenchMarkProject.Models
{
    public class BibleVerseModel
    {
        

        public string Testament { get; set; }

        public string Book { get; set; }

        public string ChapterNumber { get; set; }

        public string VerseNumber { get; set; }

        public string VerseText { get; set; }
        //public List<BibleVerseModel> verses { get; set; }
        public BibleVerseModel(string testament, string book, string chapterNumber, string verseNumber, string verseText)
        {
            Testament = testament;
            Book = book;
            ChapterNumber = chapterNumber;
            VerseNumber = verseNumber;
            VerseText = verseText;
        }

        public BibleVerseModel()
        {

        }
    }
}