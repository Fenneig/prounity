using System;
using System.IO;
using Cysharp.Threading.Tasks;
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

        public async UniTask<(bool, int)> Save(byte[] data, int version)
        {
            try
            {
                await File.WriteAllBytesAsync($"{_filePath}_{version}.txt", data);
                return (true, version); 
            }
            catch(Exception e)
            {
                Debug.LogError(e.ToString());
                return (false, -1);
            }
        }

        public async UniTask<(bool, byte[])> Load(int version)
        {
            try
            {
                byte[] bytes = await File.ReadAllBytesAsync($"{_filePath}_{version}");
                return (true, bytes);
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
                return (false, null);
            }
        }
    }
}