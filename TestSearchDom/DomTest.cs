using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using XmlParser;

namespace TestSearchDom
{
    [TestClass]
    public class DomTest
    {
        [TestMethod]
        public void TestSearchWithCriteria()
        {
            // Search by Genre and Company.(string genre, string year, string company, string rating, string price)
            SearchCriteria criteria = new SearchCriteria("Open world", "2018", "RockStar", "", "");

            string expectedGenre = "Open world";
            string expectedYear = "2018";
            string expectedCompany = "RockStar";
            string expectedRating = "9.8/10";
            string expectedPrice = "120$";

            ISearch search = new DomSearch();
            List<Game> games = search.Search(criteria);

            Assert.AreEqual(expectedGenre, games[0].Genre);
            Assert.AreEqual(expectedYear, games[0].Year);
            Assert.AreEqual(expectedCompany, games[0].Company);
            Assert.AreEqual(expectedRating, games[0].Rating);
            Assert.AreEqual(expectedPrice, games[0].Price);
        }

        [TestMethod]
        public void TestSearchWithWrongCriteria()
        {
            // Search by Genre and Company.(string genre, string year, string company, string rating, string price)
            SearchCriteria criteria = new SearchCriteria("Openn world", "20188", "RockStarr", "", "");

            ISearch search = new DomSearch();
            List<Game> games = search.Search(criteria);

            Assert.AreEqual(0, games.Count);
        }
    }
}
