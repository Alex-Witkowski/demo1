using AngleSharp.Parser.Html;
using Scoolio.TimeTableWatcher.Manos.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scoolio.TimeTableWatcher.Manos.Crawler
{
    class GymKahlaCrawler
    {
        public async Task<ChangeInformation> GetTimeTableChanges()
        {
            var result = new ChangeInformation();
            var changes = new List<ChangeInformationItem>();
            var client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("pass", "morgen"));
            var response = await client.PostAsync("http://new.gym-kahla.de/vertretungsplan/", new FormUrlEncodedContent (postData));
            var res = await response.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var doc = parser.Parse(res);
            var dateSpan = doc.All.Where(m => m.ClassList.Contains("vpfuerdatum")).First();
            
            result.Date = this.GetDate(dateSpan.TextContent);

            return result;
        }

        private DateTime GetDate(string textContent)
        {
            var date = DateTime.Now;
            var culture = new CultureInfo("de-DE");
            var styles = DateTimeStyles.None;
            var datespcified = DateTime.TryParse(textContent, culture, styles, out date);
            return datespcified ? date : DateTime.Now;
        }
    }
}
