/* BenchMark Project version 1.0
 * BibileController version 1.0
 * Jim Nguyen
 * April 24, 2020
 * BibleController handles BibleVerse methods
 */
using CLC247_BenchMarkProject.Models;
using CLC247_BenchMarkProject.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC247_BenchMarkProject.Controllers
{
    public class BibleController : Controller
    {
        // GET: Bible
        public ActionResult Index()
        {
            return View("Home");
        }

        public ActionResult Search()
        {
            return View("SearchForm");
        }

        public ActionResult SearchByPhrase()
        {
            return View("SearchByPhraseForm");
        }

        [HttpPost]
        public ActionResult OnSearch(BibleVerseModel bibleVerse)
        {

            //Call the Security Business Service authenticate method from the Login() method

            BibleVerseBusinessService service = new BibleVerseBusinessService();

           
            // the results of the method call is saved in local method sucess
            BibleVerseModel verse = service.Search(bibleVerse);

            if (verse!=null)
            {
                //if finds verse, navigate to ResultSuccess View
                return View("ResultSuccess", verse);

            }
            else
            {
                //if does not find, navigate to ResultFailed View
                return View("ResultFailed");
            }

        }

        [HttpPost]
        public ActionResult OnSearchByPhrase(string phrase)
        {

            //Call the Security Business Service authenticate method from the Login() method

            BibleVerseBusinessService service = new BibleVerseBusinessService();

            List<BibleVerseModel> verses = new List<BibleVerseModel>();
            // the results of the method call is saved in local method sucess
            verses = service.SearchByPhrase(phrase);

            if (verses != null)
            {
                //if finds verse, navigate to ResultSuccess View
                return View("VersesResult", verses);

            }
            else
            {
                //if does not find, navigate to ResultFailed View
                ViewData["message"] = "No result found. Please try again";
                return View();
            }

        }
    }
}