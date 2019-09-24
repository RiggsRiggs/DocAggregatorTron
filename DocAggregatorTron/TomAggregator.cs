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
        private const string OutputDirectory = @"G:\My Drive\MyAdmin\PropertyDocAggregator\Output";
        public void DoSomeWork()
        {
            //get files to be processed
            var files = GetFiles(WorkingDirectory);

            var fileInfos = files as FileInfo[] ?? files.ToArray();
            if (!fileInfos.Any())
                return;

            foreach (var file in fileInfos)
            {
                Console.WriteLine(file.Name.Substring(0,5));
            }

            var timeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            var outputDirectoryName = $"Output_{timeStamp}";
            var outputDirectoryPath = Path.Combine(OutputDirectory, outputDirectoryName);

            Directory.CreateDirectory(outputDirectoryPath);

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
