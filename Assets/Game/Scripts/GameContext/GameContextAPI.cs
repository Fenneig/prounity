/**
* Code generation. Don't modify! 
**/

using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Atomic.Elements;
using Game.Entities;

namespace Game
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class GameContextAPI
	{
		///Values
		public static readonly int BulletPool; // GameEntityPool
		public static readonly int Character; // GameEntity
		public static readonly int Score; // IReactiveVariable<int>

		static GameContextAPI()
		{
			//Values
			BulletPool = NameToId(nameof(BulletPool));
			Character = NameToId(nameof(Character));
			Score = NameToId(nameof(Score));
		}


		///Value Extensions

		#region BulletPool

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameEntityPool GetBulletPool(this IGameContext entity) => entity.GetValue<GameEntityPool>(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPool(this IGameContext entity, out GameEntityPool value) => entity.TryGetValue(BulletPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBulletPool(this IGameContext entity, GameEntityPool value) => entity.AddValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPool(this IGameContext entity) => entity.HasValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPool(this IGameContext entity) => entity.DelValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPool(this IGameContext entity, GameEntityPool value) => entity.SetValue(BulletPool, value);

		#endregion

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameEntity GetCharacter(this IGameContext entity) => entity.GetValue<GameEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IGameContext entity, out GameEntity value) => entity.TryGetValue(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharacter(this IGameContext entity, GameEntity value) => entity.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IGameContext entity) => entity.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IGameContext entity) => entity.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IGameContext entity, GameEntity value) => entity.SetValue(Character, value);

		#endregion

		#region Score

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetScore(this IGameContext entity) => entity.GetValue<IReactiveVariable<int>>(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetScore(this IGameContext entity, out IReactiveVariable<int> value) => entity.TryGetValue(Score, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddScore(this IGameContext entity, IReactiveVariable<int> value) => entity.AddValue(Score, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasScore(this IGameContext entity) => entity.HasValue(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelScore(this IGameContext entity) => entity.DelValue(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetScore(this IGameContext entity, IReactiveVariable<int> value) => entity.SetValue(Score, value);

		#endregion
    }
}
