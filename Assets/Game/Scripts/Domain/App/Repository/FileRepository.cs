using System;
using System.IO;
using System.Text;
using Cysharp.Threading.Tasks;
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

        public async UniTask<(bool, int)> Save(JObject data, int version)
        {
            string json = data.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(json);

            try
            {
                await File.WriteAllBytesAsync($"{_filePath}_{version}", bytes);
                return (true, version); 
            }
            catch(Exception e)
            {
                Debug.LogError(e.ToString());
                return (false, -1);
            }
        }

        public async UniTask<(bool, JObject)> Load(int version)
        {
            try
            {
                byte[] bytes = await File.ReadAllBytesAsync($"{_filePath}_{version}");
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