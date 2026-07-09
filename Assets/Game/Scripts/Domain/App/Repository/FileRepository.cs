using System;
using System.IO;
using System.Threading;
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

        public async UniTask<(bool, int)> Save(byte[] data, int version, CancellationToken ct = default)
        {
            //Запись контрольной суммы
            try
            {
                await File.WriteAllBytesAsync(GetPath(version), data, ct);
                return (true, version);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return (false, -1);
            }
        }

        public async UniTask<(bool, byte[])> Load(int version, CancellationToken ct = default)
        {
            if (!File.Exists(GetPath(version)))
                return (false, null);
            
            try
            {
                //Проверка контрольной суммы
                byte[] bytes = await File.ReadAllBytesAsync(GetPath(version), ct);
                return (true, bytes);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return (false, null);
            }
        }

        private string GetPath(int version) => 
            $"{_filePath}_{version}";
    }
}