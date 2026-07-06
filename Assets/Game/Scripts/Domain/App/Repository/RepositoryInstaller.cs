using System.IO;
using UnityEngine;
using Zenject;

namespace Game.App
{
    [CreateAssetMenu(fileName = "Repository Installer", menuName = "Game/Repository Installer")]
    public class RepositoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private string _fileName = "GameSave.txt";
        
        public override void InstallBindings()
        {
            Container
                .Bind<IGameRepository>()
                .To<FileRepository>()
                .AsSingle()
                .WithArguments(Path.Combine(Application.persistentDataPath, _fileName));
        }
    }
}