using ASOPC.Application.Interfaces.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCOPC.Infrastructure.Parser.Citilink
{
    public class CitilinkParserSetting : IParserSettings
    {

        public CitilinkParserSetting(string nav)
        {
            Navigate = nav;
            BaseUrl = "https://www.citilink.ru";
        }

        public CitilinkParserSetting()
        {

        }

      
        public string Url => $"{BaseUrl}/{Navigate}";
        public string Navigate { get; private set; }
        public string BaseUrl { get; private set; }
        public string FullUrl { get; set; }

        private bool isValidCategory = false;
        public bool IsValidCategory
        {
            get {
                if (!string.IsNullOrEmpty(FullUrl))
                    foreach (var nav in NavigateCategory)
                        if (FullUrl.Contains(nav))
                            return !isValidCategory;

                return isValidCategory;
            }
        }
        // TODO: serialize in file
        private HashSet<string> NavigateCategory => new()
        {
            "materinskaya",
            "ssd",
            "processor",
            "videokarta",
            "pamyat",
            "blok-pitaniya",
            "ventilyator",
            "ustroistvo-ohlazhdeniya-kuler"
        };
    }
}
