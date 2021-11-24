using ASCOPC.Domain.Contracts;
using ASCOPC.Infrastructure.Extensions;
using ASCOPC.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCOPC.Infrastructure.Services
{
    public class CitilinkBucketService
    {
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

        public async Task<IResult> Add(string url)
        {
            var resultBuilder = OperationResult.CreateBuilder();
            var path = GetPath();

            if (string.IsNullOrWhiteSpace(path))
                return resultBuilder.AppendError($"Chrome is required to work: {path} ")
                    .BuildResult();

            using (Process process = new())
            {
                try
                {
                    process.StartInfo.FileName = GetPath(); 
                    process.StartInfo.Arguments = url + " --new-window";
                    process.Start();
                    process.WaitForExit(10000); //dodge the 429 response
                }
                catch (Exception) { }
                finally
                {
                    byte W = 0x57; //the keycode for the W key

                    Thread.Sleep(3000); //dodge the 429 response
                    HtmlLoaderExtension.SetForegroundWindow(process.Handle);
                    HtmlLoaderExtension.Send(W, true, false, false, false); //Ctrl+W

                    //maybe clean?
                    process.Dispose();
                }
            }

            return resultBuilder.BuildResult();
        }
    }
}
