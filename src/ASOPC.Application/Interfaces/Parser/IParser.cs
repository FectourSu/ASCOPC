﻿using AngleSharp.Html.Dom;

namespace ASOPC.Application.Interfaces.Parser
{
    public interface IParser<T> 
        where T : class
    {
        T Parse(IHtmlDocument document);
    }

    public interface IParserSettings
    {
        string BaseUrl { get; }
        string Url { get; }
        string Navigate { get; }
    }
}
