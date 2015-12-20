﻿using System.Collections.Generic;
using Microsoft.AspNet.FileProviders;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;

namespace ModernDynamicData.Infrastructure
{
    public class ListOfFileProvider : IFileProvider
    {
        private readonly IEnumerable<IFileProvider> _fileProviders;

        public ListOfFileProvider(params IFileProvider[] fileProviders)
        {
            _fileProviders = fileProviders;
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            Debug.WriteLine(nameof(GetFileInfo) + ":" + subpath);
            IFileInfo fileInfo = null;
            foreach (var fileProvider in _fileProviders)
            {
                fileInfo = fileProvider.GetFileInfo(subpath);
                if (fileInfo.Exists)
                {
                    break;
                }
            }
            return fileInfo;
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            Debug.WriteLine(nameof(GetDirectoryContents) + ":" + subpath);
            IDirectoryContents directoryContents = null;
            foreach (var fileProvider in _fileProviders)
            {
                directoryContents = fileProvider.GetDirectoryContents(subpath);
                if (directoryContents.Exists)
                {
                    break;
                }
            }
            return directoryContents;
        }

        public IChangeToken Watch(string filter)
        {
            IChangeToken changeToken = null;
            foreach (var fileProvider in _fileProviders)
            {
                changeToken = fileProvider.Watch(filter);
                if (changeToken.ActiveChangeCallbacks)
                {
                    break;
                }
            }
            return changeToken;
        }
    }
}