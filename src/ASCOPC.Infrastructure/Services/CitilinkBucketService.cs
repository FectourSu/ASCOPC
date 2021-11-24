using ASCOPC.Domain.Contracts;
using ASCOPC.Infrastructure.Extensions;
using ASCOPC.Shared;
using System.Diagnostics;

namespace ASCOPC.Infrastructure.Services
{
    public class CitilinkBucketService
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
                    process.WaitForExit(10000); // Dodge the 429 response
                }
                catch (Exception) { }
                finally
                {
                    byte W = 0x57; // The keycode for the W key

                    Thread.Sleep(3000); // Second attempt to dodge
                    CitilinkBucketExtension.SetForegroundWindow(process.Handle);
                    CitilinkBucketExtension.Send(W, true, false, false, false); // Ctrl+W to close window

                    // Just in case
                    process.Dispose();
                }
            }

            return resultBuilder.BuildResult();
        }
    }
}
