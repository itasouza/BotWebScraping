using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BotInstagram
{
    public static class Instagram
    {
        public static Profile GetProfileByUser(string username)
        {
            var profile = new Profile(username);
            string url = @"https://www.instagram.com/" + username + "/";
            string markup;

            using (WebClient wc = new WebClient())
            {
                wc.Headers["Cookie"] = "security=true";
                markup = wc.DownloadString(url);
            }

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(markup);

            var list = html.DocumentNode.SelectNodes("//meta");

            foreach (var item in list)
            {
                string property = item.GetAttributeValue("property", "");

                if (property == "al:ios:app_name")
                    profile.IosAppName = item.GetAttributeValue("content", "");

            }

            return profile;
        }
    }
}
