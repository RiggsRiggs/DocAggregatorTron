using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DocAggregatorTron
{
    public class TomAggregator : IProcessor
    {
        private const string WorkingDirectory = @"G:\My Drive\MyAdmin\PropertyDocAggregator\FilesHere";
        public void DoSomeWork()
        {
            //get files to be processed
            var files = GetFiles(WorkingDirectory);

            var fileInfos = files as FileInfo[] ?? files.ToArray();
            if (!fileInfos.Any())
                return;

            foreach (var file in fileInfos)
            {
                Console.WriteLine($"Processing {file.Name}");
            }

        }

        private IEnumerable<FileInfo> GetFiles(string workingDirectory)
        {
            var sourceDirectory = new DirectoryInfo(workingDirectory);
            var files = sourceDirectory.GetFiles("*");

            var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));

            return filtered;
        }

    }
}
