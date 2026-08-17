/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Atomic.Elements;
using Game.UI;
using TMPro;

namespace Game.UI
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class GameUIAPI
	{
		///Values
		public static readonly int HealthView; // ValueKey<IGameUI,TMP_Text>
		public static readonly int AmmoView; // ValueKey<IGameUI,TMP_Text>
		public static readonly int AttackJoystick; // IValue<Joystick>
		public static readonly int MoveJoystick; // IValue<Joystick>

		static GameUIAPI()
		{
			//Values
			HealthView = NameToId(nameof(HealthView));
			AmmoView = NameToId(nameof(AmmoView));
			AttackJoystick = NameToId(nameof(AttackJoystick));
			MoveJoystick = NameToId(nameof(MoveJoystick));
		}


		///Value Extensions

		#region HealthView

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ValueKey<IGameUI,TMP_Text> GetHealthView(this IGameUI entity) => entity.GetValue<ValueKey<IGameUI,TMP_Text>>(HealthView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealthView(this IGameUI entity, out ValueKey<IGameUI,TMP_Text> value) => entity.TryGetValue(HealthView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealthView(this IGameUI entity, ValueKey<IGameUI,TMP_Text> value) => entity.AddValue(HealthView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealthView(this IGameUI entity) => entity.HasValue(HealthView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealthView(this IGameUI entity) => entity.DelValue(HealthView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealthView(this IGameUI entity, ValueKey<IGameUI,TMP_Text> value) => entity.SetValue(HealthView, value);

		#endregion

		#region AmmoView

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ValueKey<IGameUI,TMP_Text> GetAmmoView(this IGameUI entity) => entity.GetValue<ValueKey<IGameUI,TMP_Text>>(AmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmoView(this IGameUI entity, out ValueKey<IGameUI,TMP_Text> value) => entity.TryGetValue(AmmoView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAmmoView(this IGameUI entity, ValueKey<IGameUI,TMP_Text> value) => entity.AddValue(AmmoView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmoView(this IGameUI entity) => entity.HasValue(AmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmoView(this IGameUI entity) => entity.DelValue(AmmoView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmoView(this IGameUI entity, ValueKey<IGameUI,TMP_Text> value) => entity.SetValue(AmmoView, value);

		#endregion

		#region AttackJoystick

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<Joystick> GetAttackJoystick(this IGameUI entity) => entity.GetValue<IValue<Joystick>>(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackJoystick(this IGameUI entity, out IValue<Joystick> value) => entity.TryGetValue(AttackJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackJoystick(this IGameUI entity, IValue<Joystick> value) => entity.AddValue(AttackJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackJoystick(this IGameUI entity) => entity.HasValue(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackJoystick(this IGameUI entity) => entity.DelValue(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackJoystick(this IGameUI entity, IValue<Joystick> value) => entity.SetValue(AttackJoystick, value);

		#endregion

		#region MoveJoystick

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<Joystick> GetMoveJoystick(this IGameUI entity) => entity.GetValue<IValue<Joystick>>(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveJoystick(this IGameUI entity, out IValue<Joystick> value) => entity.TryGetValue(MoveJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveJoystick(this IGameUI entity, IValue<Joystick> value) => entity.AddValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveJoystick(this IGameUI entity) => entity.HasValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveJoystick(this IGameUI entity) => entity.DelValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveJoystick(this IGameUI entity, IValue<Joystick> value) => entity.SetValue(MoveJoystick, value);

		#endregion
    }
}
