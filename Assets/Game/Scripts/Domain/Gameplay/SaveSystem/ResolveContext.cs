using Modules.Entities;

namespace Game.Gameplay
{
    public sealed class ResolveContext
    {
        public EntityWorld EntityWorld { get; }
        public EntityCatalog EntityCatalog { get; }
        
        public ResolveContext(EntityWorld entityWorld, EntityCatalog entityCatalog)
        {
            EntityWorld = entityWorld;
            EntityCatalog = entityCatalog;
        }
    }
}