/**
* Code generation. Don't modify! 
**/

using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Atomic.Elements;
using UnityEngine;
using System.Collections.Generic;

namespace Game.Entities
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class GameEntityAPI
	{

		///Tags
		public static readonly int Moveable;
		public static readonly int Damageable;
		public static readonly int Interactable;
		public static readonly int Character;
		public static readonly int Scorable;

		///Values
		public static readonly int Position; // IVariable<Vector3>
		public static readonly int Rotation; // IVariable<Quaternion>
		public static readonly int MoveRequest; // IRequest<Vector3>
		public static readonly int MoveCommand; // ICommand<MoveArgs>
		public static readonly int MoveSpeed; // IValue<float>
		public static readonly int MoveTime; // IVariable<float>
		public static readonly int MoveDuration; // IValue<float>
		public static readonly int RotateRequest; // IRequest<Vector3>
		public static readonly int RotateCommand; // ICommand<RotateArgs>
		public static readonly int RotationSpeed; // IValue<float>
		public static readonly int MaxHealth; // IValue<int>
		public static readonly int Health; // IReactiveVariable<int>
		public static readonly int TakeDamageAction; // ICompositeAction<int>
		public static readonly int FireRequest; // IRequest
		public static readonly int FireCommand; // ICommand
		public static readonly int Weapon; // IVariable<IGameEntity>
		public static readonly int FireAnticipation; // ICooldown
		public static readonly int WantsToFire; // IReactiveVariable<bool>
		public static readonly int WeaponCooldown; // ICooldown
		public static readonly int Ammo; // IReactiveVariable<int>
		public static readonly int Lifetime; // ICooldown
		public static readonly int Damage; // IValue<int>
		public static readonly int InteractCommand; // ICommand<IGameEntity>
		public static readonly int Trigger; // TriggerEvents
		public static readonly int DestroyAction; // IAction
		public static readonly int RespawnAction; // ICompositeAction
		public static readonly int AnimationEvents; // IValue<AnimationEvents>
		public static readonly int Animator; // Animator
		public static readonly int AudioSource; // AudioSource
		public static readonly int ParticleSystem; // ParticleSystem
		public static readonly int TrailRender; // TrailRenderer
		public static readonly int Target; // IVariable<IGameEntity>
		public static readonly int Owner; // IVariable<IGameEntity>
		public static readonly int BloodParticle; // ParticleSystem
		public static readonly int DeadParticle; // ParticleSystem
		public static readonly int MoveAudioClips; // IValue<List<AudioClip>>
		public static readonly int PainAudioClips; // IValue<List<AudioClip>>
		public static readonly int DeathAudioClips; // IValue<List<AudioClip>>
		public static readonly int AttackAudioClips; // IValue<List<AudioClip>>
		public static readonly int BodyFallAudioClips; // IValue<List<AudioClip>>
		public static readonly int MoveSoundRequest; // IRequest
		public static readonly int MoveSoundCommand; // ICommand
		public static readonly int BodyFallSoundRequest; // IRequest
		public static readonly int BodyFallSoundCommand; // ICommand
		public static readonly int FireSoundRequest; // IRequest
		public static readonly int AttackSoundRequest; // IRequest
		public static readonly int AttackSoundCommand; // ICommand
		public static readonly int ShoutSoundRequest; // IRequest
		public static readonly int ShoutSoundCommand; // ICommand
		public static readonly int AttackAnticipationSoundRequest; // IRequest

		static GameEntityAPI()
		{
			//Tags
			Moveable = NameToId(nameof(Moveable));
			Damageable = NameToId(nameof(Damageable));
			Interactable = NameToId(nameof(Interactable));
			Character = NameToId(nameof(Character));
			Scorable = NameToId(nameof(Scorable));

			//Values
			Position = NameToId(nameof(Position));
			Rotation = NameToId(nameof(Rotation));
			MoveRequest = NameToId(nameof(MoveRequest));
			MoveCommand = NameToId(nameof(MoveCommand));
			MoveSpeed = NameToId(nameof(MoveSpeed));
			MoveTime = NameToId(nameof(MoveTime));
			MoveDuration = NameToId(nameof(MoveDuration));
			RotateRequest = NameToId(nameof(RotateRequest));
			RotateCommand = NameToId(nameof(RotateCommand));
			RotationSpeed = NameToId(nameof(RotationSpeed));
			MaxHealth = NameToId(nameof(MaxHealth));
			Health = NameToId(nameof(Health));
			TakeDamageAction = NameToId(nameof(TakeDamageAction));
			FireRequest = NameToId(nameof(FireRequest));
			FireCommand = NameToId(nameof(FireCommand));
			Weapon = NameToId(nameof(Weapon));
			FireAnticipation = NameToId(nameof(FireAnticipation));
			WantsToFire = NameToId(nameof(WantsToFire));
			WeaponCooldown = NameToId(nameof(WeaponCooldown));
			Ammo = NameToId(nameof(Ammo));
			Lifetime = NameToId(nameof(Lifetime));
			Damage = NameToId(nameof(Damage));
			InteractCommand = NameToId(nameof(InteractCommand));
			Trigger = NameToId(nameof(Trigger));
			DestroyAction = NameToId(nameof(DestroyAction));
			RespawnAction = NameToId(nameof(RespawnAction));
			AnimationEvents = NameToId(nameof(AnimationEvents));
			Animator = NameToId(nameof(Animator));
			AudioSource = NameToId(nameof(AudioSource));
			ParticleSystem = NameToId(nameof(ParticleSystem));
			TrailRender = NameToId(nameof(TrailRender));
			Target = NameToId(nameof(Target));
			Owner = NameToId(nameof(Owner));
			BloodParticle = NameToId(nameof(BloodParticle));
			DeadParticle = NameToId(nameof(DeadParticle));
			MoveAudioClips = NameToId(nameof(MoveAudioClips));
			PainAudioClips = NameToId(nameof(PainAudioClips));
			DeathAudioClips = NameToId(nameof(DeathAudioClips));
			AttackAudioClips = NameToId(nameof(AttackAudioClips));
			BodyFallAudioClips = NameToId(nameof(BodyFallAudioClips));
			MoveSoundRequest = NameToId(nameof(MoveSoundRequest));
			MoveSoundCommand = NameToId(nameof(MoveSoundCommand));
			BodyFallSoundRequest = NameToId(nameof(BodyFallSoundRequest));
			BodyFallSoundCommand = NameToId(nameof(BodyFallSoundCommand));
			FireSoundRequest = NameToId(nameof(FireSoundRequest));
			AttackSoundRequest = NameToId(nameof(AttackSoundRequest));
			AttackSoundCommand = NameToId(nameof(AttackSoundCommand));
			ShoutSoundRequest = NameToId(nameof(ShoutSoundRequest));
			ShoutSoundCommand = NameToId(nameof(ShoutSoundCommand));
			AttackAnticipationSoundRequest = NameToId(nameof(AttackAnticipationSoundRequest));
		}


		///Tag Extensions

		#region Moveable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveableTag(this IGameEntity entity) => entity.HasTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveableTag(this IGameEntity entity) => entity.AddTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveableTag(this IGameEntity entity) => entity.DelTag(Moveable);

		#endregion

		#region Damageable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IGameEntity entity) => entity.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IGameEntity entity) => entity.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IGameEntity entity) => entity.DelTag(Damageable);

		#endregion

		#region Interactable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractableTag(this IGameEntity entity) => entity.HasTag(Interactable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractableTag(this IGameEntity entity) => entity.AddTag(Interactable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractableTag(this IGameEntity entity) => entity.DelTag(Interactable);

		#endregion

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacterTag(this IGameEntity entity) => entity.HasTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacterTag(this IGameEntity entity) => entity.AddTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacterTag(this IGameEntity entity) => entity.DelTag(Character);

		#endregion

		#region Scorable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasScorableTag(this IGameEntity entity) => entity.HasTag(Scorable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddScorableTag(this IGameEntity entity) => entity.AddTag(Scorable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelScorableTag(this IGameEntity entity) => entity.DelTag(Scorable);

		#endregion


		///Value Extensions

		#region Position

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Vector3> GetPosition(this IGameEntity entity) => entity.GetValue<IVariable<Vector3>>(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPosition(this IGameEntity entity, out IVariable<Vector3> value) => entity.TryGetValue(Position, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPosition(this IGameEntity entity, IVariable<Vector3> value) => entity.AddValue(Position, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPosition(this IGameEntity entity) => entity.HasValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPosition(this IGameEntity entity) => entity.DelValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPosition(this IGameEntity entity, IVariable<Vector3> value) => entity.SetValue(Position, value);

		#endregion

		#region Rotation

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Quaternion> GetRotation(this IGameEntity entity) => entity.GetValue<IVariable<Quaternion>>(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotation(this IGameEntity entity, out IVariable<Quaternion> value) => entity.TryGetValue(Rotation, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotation(this IGameEntity entity, IVariable<Quaternion> value) => entity.AddValue(Rotation, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotation(this IGameEntity entity) => entity.HasValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotation(this IGameEntity entity) => entity.DelValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotation(this IGameEntity entity, IVariable<Quaternion> value) => entity.SetValue(Rotation, value);

		#endregion

		#region MoveRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetMoveRequest(this IGameEntity entity) => entity.GetValue<IRequest<Vector3>>(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveRequest(this IGameEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(MoveRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.AddValue(MoveRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveRequest(this IGameEntity entity) => entity.HasValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveRequest(this IGameEntity entity) => entity.DelValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.SetValue(MoveRequest, value);

		#endregion

		#region MoveCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<MoveArgs> GetMoveCommand(this IGameEntity entity) => entity.GetValue<ICommand<MoveArgs>>(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCommand(this IGameEntity entity, out ICommand<MoveArgs> value) => entity.TryGetValue(MoveCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCommand(this IGameEntity entity, ICommand<MoveArgs> value) => entity.AddValue(MoveCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCommand(this IGameEntity entity) => entity.HasValue(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCommand(this IGameEntity entity) => entity.DelValue(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCommand(this IGameEntity entity, ICommand<MoveArgs> value) => entity.SetValue(MoveCommand, value);

		#endregion

		#region MoveSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveSpeed(this IGameEntity entity) => entity.GetValue<IValue<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IGameEntity entity, out IValue<float> value) => entity.TryGetValue(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeed(this IGameEntity entity, IValue<float> value) => entity.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IGameEntity entity) => entity.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IGameEntity entity) => entity.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IGameEntity entity, IValue<float> value) => entity.SetValue(MoveSpeed, value);

		#endregion

		#region MoveTime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<float> GetMoveTime(this IGameEntity entity) => entity.GetValue<IVariable<float>>(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveTime(this IGameEntity entity, out IVariable<float> value) => entity.TryGetValue(MoveTime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveTime(this IGameEntity entity, IVariable<float> value) => entity.AddValue(MoveTime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveTime(this IGameEntity entity) => entity.HasValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveTime(this IGameEntity entity) => entity.DelValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveTime(this IGameEntity entity, IVariable<float> value) => entity.SetValue(MoveTime, value);

		#endregion

		#region MoveDuration

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveDuration(this IGameEntity entity) => entity.GetValue<IValue<float>>(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDuration(this IGameEntity entity, out IValue<float> value) => entity.TryGetValue(MoveDuration, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveDuration(this IGameEntity entity, IValue<float> value) => entity.AddValue(MoveDuration, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDuration(this IGameEntity entity) => entity.HasValue(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDuration(this IGameEntity entity) => entity.DelValue(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDuration(this IGameEntity entity, IValue<float> value) => entity.SetValue(MoveDuration, value);

		#endregion

		#region RotateRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetRotateRequest(this IGameEntity entity) => entity.GetValue<IRequest<Vector3>>(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateRequest(this IGameEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(RotateRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.AddValue(RotateRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateRequest(this IGameEntity entity) => entity.HasValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateRequest(this IGameEntity entity) => entity.DelValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.SetValue(RotateRequest, value);

		#endregion

		#region RotateCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<RotateArgs> GetRotateCommand(this IGameEntity entity) => entity.GetValue<ICommand<RotateArgs>>(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCommand(this IGameEntity entity, out ICommand<RotateArgs> value) => entity.TryGetValue(RotateCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateCommand(this IGameEntity entity, ICommand<RotateArgs> value) => entity.AddValue(RotateCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCommand(this IGameEntity entity) => entity.HasValue(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCommand(this IGameEntity entity) => entity.DelValue(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCommand(this IGameEntity entity, ICommand<RotateArgs> value) => entity.SetValue(RotateCommand, value);

		#endregion

		#region RotationSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRotationSpeed(this IGameEntity entity) => entity.GetValue<IValue<float>>(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotationSpeed(this IGameEntity entity, out IValue<float> value) => entity.TryGetValue(RotationSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotationSpeed(this IGameEntity entity, IValue<float> value) => entity.AddValue(RotationSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotationSpeed(this IGameEntity entity) => entity.HasValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotationSpeed(this IGameEntity entity) => entity.DelValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotationSpeed(this IGameEntity entity, IValue<float> value) => entity.SetValue(RotationSpeed, value);

		#endregion

		#region MaxHealth

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMaxHealth(this IGameEntity entity) => entity.GetValue<IValue<int>>(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxHealth(this IGameEntity entity, out IValue<int> value) => entity.TryGetValue(MaxHealth, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxHealth(this IGameEntity entity, IValue<int> value) => entity.AddValue(MaxHealth, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxHealth(this IGameEntity entity) => entity.HasValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxHealth(this IGameEntity entity) => entity.DelValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxHealth(this IGameEntity entity, IValue<int> value) => entity.SetValue(MaxHealth, value);

		#endregion

		#region Health

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealth(this IGameEntity entity) => entity.GetValue<IReactiveVariable<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IGameEntity entity, out IReactiveVariable<int> value) => entity.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IGameEntity entity, IReactiveVariable<int> value) => entity.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IGameEntity entity) => entity.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IGameEntity entity) => entity.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IGameEntity entity, IReactiveVariable<int> value) => entity.SetValue(Health, value);

		#endregion

		#region TakeDamageAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<int> GetTakeDamageAction(this IGameEntity entity) => entity.GetValue<ICompositeAction<int>>(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTakeDamageAction(this IGameEntity entity, out ICompositeAction<int> value) => entity.TryGetValue(TakeDamageAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTakeDamageAction(this IGameEntity entity, ICompositeAction<int> value) => entity.AddValue(TakeDamageAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTakeDamageAction(this IGameEntity entity) => entity.HasValue(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTakeDamageAction(this IGameEntity entity) => entity.DelValue(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTakeDamageAction(this IGameEntity entity, ICompositeAction<int> value) => entity.SetValue(TakeDamageAction, value);

		#endregion

		#region FireRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetFireRequest(this IGameEntity entity) => entity.GetValue<IRequest>(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(FireRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireRequest(this IGameEntity entity, IRequest value) => entity.AddValue(FireRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireRequest(this IGameEntity entity) => entity.HasValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireRequest(this IGameEntity entity) => entity.DelValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireRequest(this IGameEntity entity, IRequest value) => entity.SetValue(FireRequest, value);

		#endregion

		#region FireCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetFireCommand(this IGameEntity entity) => entity.GetValue<ICommand>(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCommand(this IGameEntity entity, out ICommand value) => entity.TryGetValue(FireCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCommand(this IGameEntity entity, ICommand value) => entity.AddValue(FireCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCommand(this IGameEntity entity) => entity.HasValue(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCommand(this IGameEntity entity) => entity.DelValue(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCommand(this IGameEntity entity, ICommand value) => entity.SetValue(FireCommand, value);

		#endregion

		#region Weapon

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IGameEntity> GetWeapon(this IGameEntity entity) => entity.GetValue<IVariable<IGameEntity>>(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeapon(this IGameEntity entity, out IVariable<IGameEntity> value) => entity.TryGetValue(Weapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeapon(this IGameEntity entity, IVariable<IGameEntity> value) => entity.AddValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeapon(this IGameEntity entity) => entity.HasValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeapon(this IGameEntity entity) => entity.DelValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeapon(this IGameEntity entity, IVariable<IGameEntity> value) => entity.SetValue(Weapon, value);

		#endregion

		#region FireAnticipation

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetFireAnticipation(this IGameEntity entity) => entity.GetValue<ICooldown>(FireAnticipation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAnticipation(this IGameEntity entity, out ICooldown value) => entity.TryGetValue(FireAnticipation, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireAnticipation(this IGameEntity entity, ICooldown value) => entity.AddValue(FireAnticipation, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAnticipation(this IGameEntity entity) => entity.HasValue(FireAnticipation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAnticipation(this IGameEntity entity) => entity.DelValue(FireAnticipation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAnticipation(this IGameEntity entity, ICooldown value) => entity.SetValue(FireAnticipation, value);

		#endregion

		#region WantsToFire

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<bool> GetWantsToFire(this IGameEntity entity) => entity.GetValue<IReactiveVariable<bool>>(WantsToFire);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWantsToFire(this IGameEntity entity, out IReactiveVariable<bool> value) => entity.TryGetValue(WantsToFire, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWantsToFire(this IGameEntity entity, IReactiveVariable<bool> value) => entity.AddValue(WantsToFire, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWantsToFire(this IGameEntity entity) => entity.HasValue(WantsToFire);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWantsToFire(this IGameEntity entity) => entity.DelValue(WantsToFire);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWantsToFire(this IGameEntity entity, IReactiveVariable<bool> value) => entity.SetValue(WantsToFire, value);

		#endregion

		#region WeaponCooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetWeaponCooldown(this IGameEntity entity) => entity.GetValue<ICooldown>(WeaponCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeaponCooldown(this IGameEntity entity, out ICooldown value) => entity.TryGetValue(WeaponCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeaponCooldown(this IGameEntity entity, ICooldown value) => entity.AddValue(WeaponCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeaponCooldown(this IGameEntity entity) => entity.HasValue(WeaponCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeaponCooldown(this IGameEntity entity) => entity.DelValue(WeaponCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeaponCooldown(this IGameEntity entity, ICooldown value) => entity.SetValue(WeaponCooldown, value);

		#endregion

		#region Ammo

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetAmmo(this IGameEntity entity) => entity.GetValue<IReactiveVariable<int>>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IGameEntity entity, out IReactiveVariable<int> value) => entity.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAmmo(this IGameEntity entity, IReactiveVariable<int> value) => entity.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IGameEntity entity) => entity.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IGameEntity entity) => entity.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IGameEntity entity, IReactiveVariable<int> value) => entity.SetValue(Ammo, value);

		#endregion

		#region Lifetime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetLifetime(this IGameEntity entity) => entity.GetValue<ICooldown>(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifetime(this IGameEntity entity, out ICooldown value) => entity.TryGetValue(Lifetime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLifetime(this IGameEntity entity, ICooldown value) => entity.AddValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifetime(this IGameEntity entity) => entity.HasValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifetime(this IGameEntity entity) => entity.DelValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifetime(this IGameEntity entity, ICooldown value) => entity.SetValue(Lifetime, value);

		#endregion

		#region Damage

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IGameEntity entity) => entity.GetValue<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IGameEntity entity, out IValue<int> value) => entity.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IGameEntity entity, IValue<int> value) => entity.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IGameEntity entity) => entity.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IGameEntity entity) => entity.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IGameEntity entity, IValue<int> value) => entity.SetValue(Damage, value);

		#endregion

		#region InteractCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<IGameEntity> GetInteractCommand(this IGameEntity entity) => entity.GetValue<ICommand<IGameEntity>>(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractCommand(this IGameEntity entity, out ICommand<IGameEntity> value) => entity.TryGetValue(InteractCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractCommand(this IGameEntity entity, ICommand<IGameEntity> value) => entity.AddValue(InteractCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractCommand(this IGameEntity entity) => entity.HasValue(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractCommand(this IGameEntity entity) => entity.DelValue(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractCommand(this IGameEntity entity, ICommand<IGameEntity> value) => entity.SetValue(InteractCommand, value);

		#endregion

		#region Trigger

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEvents GetTrigger(this IGameEntity entity) => entity.GetValue<TriggerEvents>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IGameEntity entity, out TriggerEvents value) => entity.TryGetValue(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrigger(this IGameEntity entity, TriggerEvents value) => entity.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IGameEntity entity) => entity.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IGameEntity entity) => entity.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IGameEntity entity, TriggerEvents value) => entity.SetValue(Trigger, value);

		#endregion

		#region DestroyAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IGameEntity entity) => entity.GetValue<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IGameEntity entity, out IAction value) => entity.TryGetValue(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDestroyAction(this IGameEntity entity, IAction value) => entity.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IGameEntity entity) => entity.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IGameEntity entity) => entity.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IGameEntity entity, IAction value) => entity.SetValue(DestroyAction, value);

		#endregion

		#region RespawnAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction GetRespawnAction(this IGameEntity entity) => entity.GetValue<ICompositeAction>(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRespawnAction(this IGameEntity entity, out ICompositeAction value) => entity.TryGetValue(RespawnAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRespawnAction(this IGameEntity entity, ICompositeAction value) => entity.AddValue(RespawnAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRespawnAction(this IGameEntity entity) => entity.HasValue(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRespawnAction(this IGameEntity entity) => entity.DelValue(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRespawnAction(this IGameEntity entity, ICompositeAction value) => entity.SetValue(RespawnAction, value);

		#endregion

		#region AnimationEvents

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<AnimationEvents> GetAnimationEvents(this IGameEntity entity) => entity.GetValue<IValue<AnimationEvents>>(AnimationEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimationEvents(this IGameEntity entity, out IValue<AnimationEvents> value) => entity.TryGetValue(AnimationEvents, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimationEvents(this IGameEntity entity, IValue<AnimationEvents> value) => entity.AddValue(AnimationEvents, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimationEvents(this IGameEntity entity) => entity.HasValue(AnimationEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimationEvents(this IGameEntity entity) => entity.DelValue(AnimationEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimationEvents(this IGameEntity entity, IValue<AnimationEvents> value) => entity.SetValue(AnimationEvents, value);

		#endregion

		#region Animator

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IGameEntity entity) => entity.GetValue<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IGameEntity entity, out Animator value) => entity.TryGetValue(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimator(this IGameEntity entity, Animator value) => entity.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IGameEntity entity) => entity.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IGameEntity entity) => entity.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IGameEntity entity, Animator value) => entity.SetValue(Animator, value);

		#endregion

		#region AudioSource

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AudioSource GetAudioSource(this IGameEntity entity) => entity.GetValue<AudioSource>(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAudioSource(this IGameEntity entity, out AudioSource value) => entity.TryGetValue(AudioSource, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAudioSource(this IGameEntity entity, AudioSource value) => entity.AddValue(AudioSource, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAudioSource(this IGameEntity entity) => entity.HasValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAudioSource(this IGameEntity entity) => entity.DelValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAudioSource(this IGameEntity entity, AudioSource value) => entity.SetValue(AudioSource, value);

		#endregion

		#region ParticleSystem

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ParticleSystem GetParticleSystem(this IGameEntity entity) => entity.GetValue<ParticleSystem>(ParticleSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetParticleSystem(this IGameEntity entity, out ParticleSystem value) => entity.TryGetValue(ParticleSystem, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddParticleSystem(this IGameEntity entity, ParticleSystem value) => entity.AddValue(ParticleSystem, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasParticleSystem(this IGameEntity entity) => entity.HasValue(ParticleSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelParticleSystem(this IGameEntity entity) => entity.DelValue(ParticleSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetParticleSystem(this IGameEntity entity, ParticleSystem value) => entity.SetValue(ParticleSystem, value);

		#endregion

		#region TrailRender

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TrailRenderer GetTrailRender(this IGameEntity entity) => entity.GetValue<TrailRenderer>(TrailRender);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrailRender(this IGameEntity entity, out TrailRenderer value) => entity.TryGetValue(TrailRender, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrailRender(this IGameEntity entity, TrailRenderer value) => entity.AddValue(TrailRender, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrailRender(this IGameEntity entity) => entity.HasValue(TrailRender);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrailRender(this IGameEntity entity) => entity.DelValue(TrailRender);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrailRender(this IGameEntity entity, TrailRenderer value) => entity.SetValue(TrailRender, value);

		#endregion

		#region Target

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IGameEntity> GetTarget(this IGameEntity entity) => entity.GetValue<IVariable<IGameEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IGameEntity entity, out IVariable<IGameEntity> value) => entity.TryGetValue(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTarget(this IGameEntity entity, IVariable<IGameEntity> value) => entity.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IGameEntity entity) => entity.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IGameEntity entity) => entity.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IGameEntity entity, IVariable<IGameEntity> value) => entity.SetValue(Target, value);

		#endregion

		#region Owner

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IGameEntity> GetOwner(this IGameEntity entity) => entity.GetValue<IVariable<IGameEntity>>(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetOwner(this IGameEntity entity, out IVariable<IGameEntity> value) => entity.TryGetValue(Owner, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddOwner(this IGameEntity entity, IVariable<IGameEntity> value) => entity.AddValue(Owner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasOwner(this IGameEntity entity) => entity.HasValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelOwner(this IGameEntity entity) => entity.DelValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetOwner(this IGameEntity entity, IVariable<IGameEntity> value) => entity.SetValue(Owner, value);

		#endregion

		#region BloodParticle

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ParticleSystem GetBloodParticle(this IGameEntity entity) => entity.GetValue<ParticleSystem>(BloodParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBloodParticle(this IGameEntity entity, out ParticleSystem value) => entity.TryGetValue(BloodParticle, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBloodParticle(this IGameEntity entity, ParticleSystem value) => entity.AddValue(BloodParticle, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBloodParticle(this IGameEntity entity) => entity.HasValue(BloodParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBloodParticle(this IGameEntity entity) => entity.DelValue(BloodParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBloodParticle(this IGameEntity entity, ParticleSystem value) => entity.SetValue(BloodParticle, value);

		#endregion

		#region DeadParticle

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ParticleSystem GetDeadParticle(this IGameEntity entity) => entity.GetValue<ParticleSystem>(DeadParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeadParticle(this IGameEntity entity, out ParticleSystem value) => entity.TryGetValue(DeadParticle, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDeadParticle(this IGameEntity entity, ParticleSystem value) => entity.AddValue(DeadParticle, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeadParticle(this IGameEntity entity) => entity.HasValue(DeadParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeadParticle(this IGameEntity entity) => entity.DelValue(DeadParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeadParticle(this IGameEntity entity, ParticleSystem value) => entity.SetValue(DeadParticle, value);

		#endregion

		#region MoveAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetMoveAudioClips(this IGameEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(MoveAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveAudioClips(this IGameEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(MoveAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(MoveAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveAudioClips(this IGameEntity entity) => entity.HasValue(MoveAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveAudioClips(this IGameEntity entity) => entity.DelValue(MoveAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(MoveAudioClips, value);

		#endregion

		#region PainAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetPainAudioClips(this IGameEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(PainAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPainAudioClips(this IGameEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(PainAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPainAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(PainAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPainAudioClips(this IGameEntity entity) => entity.HasValue(PainAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPainAudioClips(this IGameEntity entity) => entity.DelValue(PainAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPainAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(PainAudioClips, value);

		#endregion

		#region DeathAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetDeathAudioClips(this IGameEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(DeathAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeathAudioClips(this IGameEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(DeathAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDeathAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(DeathAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeathAudioClips(this IGameEntity entity) => entity.HasValue(DeathAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeathAudioClips(this IGameEntity entity) => entity.DelValue(DeathAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeathAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(DeathAudioClips, value);

		#endregion

		#region AttackAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetAttackAudioClips(this IGameEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(AttackAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackAudioClips(this IGameEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(AttackAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(AttackAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackAudioClips(this IGameEntity entity) => entity.HasValue(AttackAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackAudioClips(this IGameEntity entity) => entity.DelValue(AttackAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(AttackAudioClips, value);

		#endregion

		#region BodyFallAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetBodyFallAudioClips(this IGameEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(BodyFallAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBodyFallAudioClips(this IGameEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(BodyFallAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBodyFallAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(BodyFallAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBodyFallAudioClips(this IGameEntity entity) => entity.HasValue(BodyFallAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBodyFallAudioClips(this IGameEntity entity) => entity.DelValue(BodyFallAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBodyFallAudioClips(this IGameEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(BodyFallAudioClips, value);

		#endregion

		#region MoveSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetMoveSoundRequest(this IGameEntity entity) => entity.GetValue<IRequest>(MoveSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSoundRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(MoveSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSoundRequest(this IGameEntity entity, IRequest value) => entity.AddValue(MoveSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSoundRequest(this IGameEntity entity) => entity.HasValue(MoveSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSoundRequest(this IGameEntity entity) => entity.DelValue(MoveSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSoundRequest(this IGameEntity entity, IRequest value) => entity.SetValue(MoveSoundRequest, value);

		#endregion

		#region MoveSoundCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetMoveSoundCommand(this IGameEntity entity) => entity.GetValue<ICommand>(MoveSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSoundCommand(this IGameEntity entity, out ICommand value) => entity.TryGetValue(MoveSoundCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSoundCommand(this IGameEntity entity, ICommand value) => entity.AddValue(MoveSoundCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSoundCommand(this IGameEntity entity) => entity.HasValue(MoveSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSoundCommand(this IGameEntity entity) => entity.DelValue(MoveSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSoundCommand(this IGameEntity entity, ICommand value) => entity.SetValue(MoveSoundCommand, value);

		#endregion

		#region BodyFallSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetBodyFallSoundRequest(this IGameEntity entity) => entity.GetValue<IRequest>(BodyFallSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBodyFallSoundRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(BodyFallSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBodyFallSoundRequest(this IGameEntity entity, IRequest value) => entity.AddValue(BodyFallSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBodyFallSoundRequest(this IGameEntity entity) => entity.HasValue(BodyFallSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBodyFallSoundRequest(this IGameEntity entity) => entity.DelValue(BodyFallSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBodyFallSoundRequest(this IGameEntity entity, IRequest value) => entity.SetValue(BodyFallSoundRequest, value);

		#endregion

		#region BodyFallSoundCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetBodyFallSoundCommand(this IGameEntity entity) => entity.GetValue<ICommand>(BodyFallSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBodyFallSoundCommand(this IGameEntity entity, out ICommand value) => entity.TryGetValue(BodyFallSoundCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBodyFallSoundCommand(this IGameEntity entity, ICommand value) => entity.AddValue(BodyFallSoundCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBodyFallSoundCommand(this IGameEntity entity) => entity.HasValue(BodyFallSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBodyFallSoundCommand(this IGameEntity entity) => entity.DelValue(BodyFallSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBodyFallSoundCommand(this IGameEntity entity, ICommand value) => entity.SetValue(BodyFallSoundCommand, value);

		#endregion

		#region FireSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetFireSoundRequest(this IGameEntity entity) => entity.GetValue<IRequest>(FireSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireSoundRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(FireSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireSoundRequest(this IGameEntity entity, IRequest value) => entity.AddValue(FireSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireSoundRequest(this IGameEntity entity) => entity.HasValue(FireSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireSoundRequest(this IGameEntity entity) => entity.DelValue(FireSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireSoundRequest(this IGameEntity entity, IRequest value) => entity.SetValue(FireSoundRequest, value);

		#endregion

		#region AttackSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetAttackSoundRequest(this IGameEntity entity) => entity.GetValue<IRequest>(AttackSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackSoundRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(AttackSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackSoundRequest(this IGameEntity entity, IRequest value) => entity.AddValue(AttackSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackSoundRequest(this IGameEntity entity) => entity.HasValue(AttackSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackSoundRequest(this IGameEntity entity) => entity.DelValue(AttackSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackSoundRequest(this IGameEntity entity, IRequest value) => entity.SetValue(AttackSoundRequest, value);

		#endregion

		#region AttackSoundCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetAttackSoundCommand(this IGameEntity entity) => entity.GetValue<ICommand>(AttackSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackSoundCommand(this IGameEntity entity, out ICommand value) => entity.TryGetValue(AttackSoundCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackSoundCommand(this IGameEntity entity, ICommand value) => entity.AddValue(AttackSoundCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackSoundCommand(this IGameEntity entity) => entity.HasValue(AttackSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackSoundCommand(this IGameEntity entity) => entity.DelValue(AttackSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackSoundCommand(this IGameEntity entity, ICommand value) => entity.SetValue(AttackSoundCommand, value);

		#endregion

		#region ShoutSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetShoutSoundRequest(this IGameEntity entity) => entity.GetValue<IRequest>(ShoutSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetShoutSoundRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(ShoutSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddShoutSoundRequest(this IGameEntity entity, IRequest value) => entity.AddValue(ShoutSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasShoutSoundRequest(this IGameEntity entity) => entity.HasValue(ShoutSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelShoutSoundRequest(this IGameEntity entity) => entity.DelValue(ShoutSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetShoutSoundRequest(this IGameEntity entity, IRequest value) => entity.SetValue(ShoutSoundRequest, value);

		#endregion

		#region ShoutSoundCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetShoutSoundCommand(this IGameEntity entity) => entity.GetValue<ICommand>(ShoutSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetShoutSoundCommand(this IGameEntity entity, out ICommand value) => entity.TryGetValue(ShoutSoundCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddShoutSoundCommand(this IGameEntity entity, ICommand value) => entity.AddValue(ShoutSoundCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasShoutSoundCommand(this IGameEntity entity) => entity.HasValue(ShoutSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelShoutSoundCommand(this IGameEntity entity) => entity.DelValue(ShoutSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetShoutSoundCommand(this IGameEntity entity, ICommand value) => entity.SetValue(ShoutSoundCommand, value);

		#endregion

		#region AttackAnticipationSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetAttackAnticipationSoundRequest(this IGameEntity entity) => entity.GetValue<IRequest>(AttackAnticipationSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackAnticipationSoundRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValue(AttackAnticipationSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackAnticipationSoundRequest(this IGameEntity entity, IRequest value) => entity.AddValue(AttackAnticipationSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackAnticipationSoundRequest(this IGameEntity entity) => entity.HasValue(AttackAnticipationSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackAnticipationSoundRequest(this IGameEntity entity) => entity.DelValue(AttackAnticipationSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackAnticipationSoundRequest(this IGameEntity entity, IRequest value) => entity.SetValue(AttackAnticipationSoundRequest, value);

		#endregion
    }
}
