using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML.Logic.Provider;

namespace XML.Logic
{
    public class FileProvider : IProvider
    {
        private readonly string filePath;
        private readonly Parser parser;
        private readonly ILogger logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FileProvider(string filePath, Parser parser, ILogger logger)
        {
            this.filePath = filePath ?? throw new ArgumentNullException($"{nameof(filePath)} is null");
            this.parser = parser ?? throw new ArgumentNullException($"{nameof(parser)} is null");
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} is null");
        }

        /// <summary>
        /// Load urls from file.
        /// </summary>
        /// <returns>lis of URLs</returns>
        public IEnumerable<URL> Load()
        {
            IEnumerable<string> urlList = File.ReadLines(filePath);
            var parsedUrls = new List<URL>();

            foreach (var item in urlList)
            {
                if (IsValid(item))
                {
                    parsedUrls.Add(parser.Parse(item));
                }
                else
                {
                    logger.Debug($"Can't parse { nameof(item) }");
                }
            }

            return parsedUrls;
        }

        /// <summary>
        /// Is valid url.
        /// </summary>
        /// <param name="url">Url.</param>
        private bool IsValid(string url)
        {
            if (url != null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url.Contains("http://") || url.Contains("https://"))
            {
                return true;
            }

            return false;

        }
    }
}
