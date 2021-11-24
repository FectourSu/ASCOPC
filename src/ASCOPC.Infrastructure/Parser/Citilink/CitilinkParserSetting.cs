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
        public string Url => $"{BaseUrl}/{Navigate}";
        public string Navigate { get; private set; }
        public string BaseUrl { get; private set; }
    }
}
