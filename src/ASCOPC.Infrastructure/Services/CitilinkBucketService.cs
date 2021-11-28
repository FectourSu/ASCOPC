using ASCOPC.Domain.Contracts;
using ASCOPC.Infrastructure.Extensions;
using ASCOPC.Infrastructure.Parser.Citilink;
using ASCOPC.Shared;
using ASOPC.Application.Interfaces.Services;
using System.Diagnostics;

namespace ASCOPC.Infrastructure.Services
{
    public class CitilinkBucketService : ICitilinkBucketService
    {
        /// <summary>
        /// Getting the path to chrome.exe
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            var path = Microsoft.Win32.Registry.GetValue(
                @"HKEY_CLASSES_ROOT\ChromeHTML\shell\open\command", null, null) as string;

            if (path != null)
            {
                var split = path.Split('\"');
                path = split.Length >= 2 ? split[1] : null;

                return path;
            }

            return string.Empty;
        }

        /// <summary>
        /// Add an items to the citilink.ru/order/
        /// </summary>
        public async Task<IResult> Add(IEnumerable<int> codeProduct)
        {
            var resultBuilder = OperationResult.CreateBuilder();

            foreach (var code in codeProduct)
            {
                if (code is 0)
                    return resultBuilder.AppendError($"Sorry, code item is: {code} ")
                        .BuildResult();

                CitilinkParserSetting navigate = new($"basket/add/product/{code}");

                var path = GetPath();

                if (string.IsNullOrWhiteSpace(path))
                    return resultBuilder.AppendError($"Sorry, chrome.exe is required to work: {path} ")
                        .BuildResult();

                using (Process process = new())
                {
                    try
                    {
                        process.StartInfo.FileName = GetPath();
                        process.StartInfo.Arguments = navigate.Url + " --new-window";
                        process.Start();
                        process.WaitForExit(10000); // Dodge the 429 response
                    }
                    catch (Exception) 
                    {
                        throw;
                    }
                    finally
                    {
                        byte W = 0x57; // The keycode for the W key

                        Thread.Sleep(2000); // Second attempt to dodge
                        CitilinkBucketExtension.SetForegroundWindow(process.Handle);
                        CitilinkBucketExtension.Send(W, true, false, false, false); // Ctrl+W to close window

                        // Just in case
                        process.Dispose();
                    }
                }
            }
            return resultBuilder.BuildResult();
        }
    }
}
