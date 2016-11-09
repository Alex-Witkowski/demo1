using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Scoolio.TimeTableWatcher.Manos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Scoolio.TimeTableWatcher.Manos.Crawler
{
    public class ManosCrawler
    {
        public async Task<List<ChangeInformation>> GetTimeTableChanges()
        {
            var result = new List<ChangeInformation>();
            var client = new HttpClient();
            var res = await client.GetStringAsync("http://www.manos-dresden.de/aktuelles/vplan.php");
            var parser = new HtmlParser();
            var doc = parser.Parse(res);
            var cell = doc.All.Where(m => m.ClassList.Contains("s6")).First();
            var table = cell.Parent.Parent;
            var rows = table.ChildNodes.Where(e => e is IHtmlTableRowElement).Cast< IHtmlTableRowElement>();
            //htmlDoc.LoadHtml(res);
            //var table = htmlDoc.DocumentNode.SelectNodes(@"//td[@class='s6']/../../tbody");

            foreach (var row in rows)
            {
                if (row.Cells.Count() != 6 || (!row.Cells.FirstOrDefault()?.ClassList.Contains("s9") ?? true))
                {
                    continue;
                }

                var data = new ChangeInformation();
                data.ClassString = row.Cells[0].TextContent;
                data.HourNumber = int.Parse(row.Cells[1].TextContent);
                data.Subject = row.Cells[2].TextContent;
                data.Teacher = row.Cells[3].TextContent;
                data.Room = row.Cells[4].TextContent;
                data.Description = row.Cells[5].TextContent;

                result.Add(data);
            }

            return result;
        }
    }
}
