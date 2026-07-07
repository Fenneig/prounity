using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Game.App
{
    public class FileRepository : IGameRepository
    {
        private readonly string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(JObject data, int version)
        {
            string json = data.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(json);

            try
            {
                File.WriteAllBytes($"{_filePath}_{version}", bytes);
            }
            catch(Exception e)
            {
                Debug.LogError(e.ToString());
            }
        }

        public (bool, JObject) Load(int version)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes($"{_filePath}_{version}");
                string json = Encoding.UTF8.GetString(bytes);
                return (true, JObject.Parse(json));
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
                return (false, null);
            }
        }
    }
}