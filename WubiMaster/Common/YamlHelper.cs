using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WubiMaster.Common
{
    public static class YamlHelper
    {
        private static IDeserializer _deserializer;
        private static IDeserializer _jsondeserializer;
        private static ISerializer _jsonserializer;
        private static ISerializer _serializer;

        static YamlHelper()
        {
            _serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            _deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
            _jsondeserializer = new DeserializerBuilder().Build();
            _jsonserializer = new SerializerBuilder().JsonCompatible().Build();
        }

        public static T DeserializeFromFile<T>(string filePath)
        {
            var yaml = File.ReadAllText(filePath, Encoding.UTF8);
            return Deserizlize<T>(yaml);
        }

        public static T Deserizlize<T>(string yaml)
        {
            return _deserializer.Deserialize<T>(yaml);
        }

        public static string Serialize(object target)
        {
            return _serializer.Serialize(target);
        }

        public static void SerizlizerToFile(object target, string filePath)
        {
            var content = Serialize(target);
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }

        public static void WriteYaml(object target, string filePath)
        {
            StreamWriter yamlWriter = File.CreateText(filePath);
            Serializer yamlSerializer = new Serializer();
            yamlSerializer.Serialize(yamlWriter, target);
            yamlWriter.Close();
        }

        public static string YamlToJson(string yaml)
        {
            var yamlObject = _jsondeserializer.Deserialize(yaml);
            var json = _jsonserializer.Serialize(yamlObject);

            return json;
        }
    }
}