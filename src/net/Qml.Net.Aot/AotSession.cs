using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Qml.Net.Aot
{
    public class AotSession
    {
        private readonly string _name;
        private readonly List<Type> _types = new List<Type>();
        private readonly List<Type> _registeredTypes = new List<Type>();

        internal AotSession(string name)
        {
            name = (name ?? "").Trim();
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            _name = name;
        }
        
        public string Name
        {
            get => _name;
        }

        public void AddType(Type type)
        {
            if (!_types.Contains(type))
            {
                _types.Add(type);
            }
        }

        public void RegisterType(Type type)
        {
            AddType(type);
            if (!_registeredTypes.Contains(type))
            {
                _registeredTypes.Add(type);
            }
        }

        public static AotSession Start(string name)
        {
            return new AotSession(name);
        }

        public string WriteSourceFiles(string outputDirectory)
        {
            if (string.IsNullOrEmpty(outputDirectory))
            {
                throw new ArgumentException(nameof(outputDirectory));
            }

            if (!Directory.Exists(outputDirectory))
            {
                throw new Exception($"Directory {outputDirectory} doesn't exist.");
            }

            if (Directory.GetFiles(outputDirectory).Length > 0 || Directory.GetDirectories(outputDirectory).Length > 0)
            {
                throw new Exception($"Directory {outputDirectory} isn't empty.");
            }

            foreach (var type in _registeredTypes)
            {
                
            }
            
            var priFile = Path.Combine(outputDirectory, $"{Name}.pri");

            using (var priFileStream = File.OpenWrite(priFile))
            {
                using (var streamWriter = new StreamWriter(priFileStream))
                {
                    streamWriter.WriteLine("");
                }
            }
        }
    }
}