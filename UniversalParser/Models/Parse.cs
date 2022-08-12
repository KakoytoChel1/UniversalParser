using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;

namespace UniversalParser.Models
{
    static internal class Parse
    {
        static public async Task<string> GetParseResultAsync(string url, string selector, bool hrefState)
        {
            string result = String.Empty;
            try
            {
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);

                var document = await context.OpenAsync(url);

                IHtmlCollection<IElement> cells = document.QuerySelectorAll(selector);

                var titles = cells.Select(m => m).ToList();

                if (hrefState == true)
                {
                    foreach (var title in titles)
                    {
                        result += $"{((IHtmlAnchorElement)title).Href}\n";
                    }
                }
                else
                {
                    foreach (var title in titles)
                    {
                        result += $"{((IHtmlElement)title).TextContent}\n";
                    }
                }
            }
            catch (Exception ex) { result = ex.Message; }

            return result;
        }
    }
}
