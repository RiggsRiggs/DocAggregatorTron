﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using DataAccessLayer;

//Adding a comment just to enable New Features branch

namespace DocAggregatorDotnetCore
{
    public class TomAggregator : IProcessor
    {
        private const string WorkingDirectory = @"G:\My Drive\MyAdmin\PropertyDocAggregator\FilesHere";
        private const string OutputDirectory = @"G:\My Drive\MyAdmin\PropertyDocAggregator\Output";
        private const int offset = 5;

        public void DoSomeWork()
        {

            //get files to be processed
            var files = GetFiles(WorkingDirectory);

            var fileInfos = files as FileInfo[] ?? files.ToArray();
            if (!fileInfos.Any())
                return;

            var timeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            var outputDirectoryName = $"Output_{timeStamp}";
            var outputDirectoryPath = Path.Combine(OutputDirectory, outputDirectoryName);

            Directory.CreateDirectory(outputDirectoryPath);

            //make array of property refs
            var ctx = new RiggsTestContext();
            var listOfDocs = ctx.PropDocs.Select(p => p).ToList();
            var docsArray = listOfDocs.ToArray();


            //new make directories
            foreach (var item in docsArray)
            {
                Console.WriteLine(item.PropRef);
                //Console.WriteLine(file.Name.Substring(0, offset));
                var propertyDirectory = Path.Combine(outputDirectoryPath,item.PropRef.ToString());
                Directory.CreateDirectory(propertyDirectory);
            }


            foreach (var file in fileInfos)
            {
                //Console.WriteLine(file.Name.Substring(0, offset));
                var propertyDirectory = Path.Combine(outputDirectoryPath, file.Name.Substring(0, offset));
                var fileToCopy = Path.Combine(WorkingDirectory, file.Name);
                var newLocation = Path.Combine(propertyDirectory, file.Name);
                
                File.Copy(fileToCopy, newLocation);
            }


            // Get all subdirectories

            string[] subdirectoryEntries = Directory.GetDirectories(outputDirectoryPath);

            foreach(var item in subdirectoryEntries)
            {
                string folderToZip = item;
                string zipFile = item+".zip";

                ZipFile.CreateFromDirectory(folderToZip, zipFile);

                Directory.Delete(item, true);
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