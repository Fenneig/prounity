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
using UnityEngine;
using System.Collections.Generic;
using Game.UI;

namespace Game.Entities
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class EntityAPI
	{

		///Tags
		public static readonly int Moveable;
		public static readonly int Damageable;
		public static readonly int Interactable;
		public static readonly int Character;

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
		public static readonly int Weapon; // IVariable<IEntity>
		public static readonly int FireAnticipation; // ICooldown
		public static readonly int WantsToFire; // IReactiveVariable<bool>
		public static readonly int WeaponCooldown; // ICooldown
		public static readonly int Ammo; // IReactiveVariable<int>
		public static readonly int Lifetime; // ICooldown
		public static readonly int Damage; // IValue<int>
		public static readonly int InteractCommand; // ICommand<IEntity>
		public static readonly int Trigger; // TriggerEvents
		public static readonly int DestroyAction; // IAction
		public static readonly int RespawnAction; // ICompositeAction
		public static readonly int AnimationEvents; // IValue<AnimationEvents>
		public static readonly int Animator; // Animator
		public static readonly int AudioSource; // AudioSource
		public static readonly int ParticleSystem; // ParticleSystem
		public static readonly int TrailRender; // TrailRenderer
		public static readonly int Target; // IVariable<IEntity>
		public static readonly int Owner; // IVariable<IEntity>
		public static readonly int Score; // IReactiveVariable<int>
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

		static EntityAPI()
		{
			//Tags
			Moveable = NameToId(nameof(Moveable));
			Damageable = NameToId(nameof(Damageable));
			Interactable = NameToId(nameof(Interactable));
			Character = NameToId(nameof(Character));

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
			Score = NameToId(nameof(Score));
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
		public static bool HasMoveableTag(this IEntity entity) => entity.HasTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveableTag(this IEntity entity) => entity.AddTag(Moveable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveableTag(this IEntity entity) => entity.DelTag(Moveable);

		#endregion

		#region Damageable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IEntity entity) => entity.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IEntity entity) => entity.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IEntity entity) => entity.DelTag(Damageable);

		#endregion

		#region Interactable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractableTag(this IEntity entity) => entity.HasTag(Interactable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractableTag(this IEntity entity) => entity.AddTag(Interactable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractableTag(this IEntity entity) => entity.DelTag(Interactable);

		#endregion

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacterTag(this IEntity entity) => entity.HasTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacterTag(this IEntity entity) => entity.AddTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacterTag(this IEntity entity) => entity.DelTag(Character);

		#endregion


		///Value Extensions

		#region Position

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Vector3> GetPosition(this IEntity entity) => entity.GetValue<IVariable<Vector3>>(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPosition(this IEntity entity, out IVariable<Vector3> value) => entity.TryGetValue(Position, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPosition(this IEntity entity, IVariable<Vector3> value) => entity.AddValue(Position, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPosition(this IEntity entity) => entity.HasValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPosition(this IEntity entity) => entity.DelValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPosition(this IEntity entity, IVariable<Vector3> value) => entity.SetValue(Position, value);

		#endregion

		#region Rotation

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Quaternion> GetRotation(this IEntity entity) => entity.GetValue<IVariable<Quaternion>>(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotation(this IEntity entity, out IVariable<Quaternion> value) => entity.TryGetValue(Rotation, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotation(this IEntity entity, IVariable<Quaternion> value) => entity.AddValue(Rotation, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotation(this IEntity entity) => entity.HasValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotation(this IEntity entity) => entity.DelValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotation(this IEntity entity, IVariable<Quaternion> value) => entity.SetValue(Rotation, value);

		#endregion

		#region MoveRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetMoveRequest(this IEntity entity) => entity.GetValue<IRequest<Vector3>>(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveRequest(this IEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(MoveRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveRequest(this IEntity entity, IRequest<Vector3> value) => entity.AddValue(MoveRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveRequest(this IEntity entity) => entity.HasValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveRequest(this IEntity entity) => entity.DelValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveRequest(this IEntity entity, IRequest<Vector3> value) => entity.SetValue(MoveRequest, value);

		#endregion

		#region MoveCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<MoveArgs> GetMoveCommand(this IEntity entity) => entity.GetValue<ICommand<MoveArgs>>(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCommand(this IEntity entity, out ICommand<MoveArgs> value) => entity.TryGetValue(MoveCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCommand(this IEntity entity, ICommand<MoveArgs> value) => entity.AddValue(MoveCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCommand(this IEntity entity) => entity.HasValue(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCommand(this IEntity entity) => entity.DelValue(MoveCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCommand(this IEntity entity, ICommand<MoveArgs> value) => entity.SetValue(MoveCommand, value);

		#endregion

		#region MoveSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveSpeed(this IEntity entity) => entity.GetValue<IValue<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IEntity entity, out IValue<float> value) => entity.TryGetValue(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeed(this IEntity entity, IValue<float> value) => entity.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IEntity entity) => entity.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IEntity entity) => entity.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IEntity entity, IValue<float> value) => entity.SetValue(MoveSpeed, value);

		#endregion

		#region MoveTime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<float> GetMoveTime(this IEntity entity) => entity.GetValue<IVariable<float>>(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveTime(this IEntity entity, out IVariable<float> value) => entity.TryGetValue(MoveTime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveTime(this IEntity entity, IVariable<float> value) => entity.AddValue(MoveTime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveTime(this IEntity entity) => entity.HasValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveTime(this IEntity entity) => entity.DelValue(MoveTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveTime(this IEntity entity, IVariable<float> value) => entity.SetValue(MoveTime, value);

		#endregion

		#region MoveDuration

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveDuration(this IEntity entity) => entity.GetValue<IValue<float>>(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDuration(this IEntity entity, out IValue<float> value) => entity.TryGetValue(MoveDuration, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveDuration(this IEntity entity, IValue<float> value) => entity.AddValue(MoveDuration, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDuration(this IEntity entity) => entity.HasValue(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDuration(this IEntity entity) => entity.DelValue(MoveDuration);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDuration(this IEntity entity, IValue<float> value) => entity.SetValue(MoveDuration, value);

		#endregion

		#region RotateRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetRotateRequest(this IEntity entity) => entity.GetValue<IRequest<Vector3>>(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateRequest(this IEntity entity, out IRequest<Vector3> value) => entity.TryGetValue(RotateRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateRequest(this IEntity entity, IRequest<Vector3> value) => entity.AddValue(RotateRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateRequest(this IEntity entity) => entity.HasValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateRequest(this IEntity entity) => entity.DelValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateRequest(this IEntity entity, IRequest<Vector3> value) => entity.SetValue(RotateRequest, value);

		#endregion

		#region RotateCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<RotateArgs> GetRotateCommand(this IEntity entity) => entity.GetValue<ICommand<RotateArgs>>(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCommand(this IEntity entity, out ICommand<RotateArgs> value) => entity.TryGetValue(RotateCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateCommand(this IEntity entity, ICommand<RotateArgs> value) => entity.AddValue(RotateCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCommand(this IEntity entity) => entity.HasValue(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCommand(this IEntity entity) => entity.DelValue(RotateCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCommand(this IEntity entity, ICommand<RotateArgs> value) => entity.SetValue(RotateCommand, value);

		#endregion

		#region RotationSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRotationSpeed(this IEntity entity) => entity.GetValue<IValue<float>>(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotationSpeed(this IEntity entity, out IValue<float> value) => entity.TryGetValue(RotationSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotationSpeed(this IEntity entity, IValue<float> value) => entity.AddValue(RotationSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotationSpeed(this IEntity entity) => entity.HasValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotationSpeed(this IEntity entity) => entity.DelValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotationSpeed(this IEntity entity, IValue<float> value) => entity.SetValue(RotationSpeed, value);

		#endregion

		#region MaxHealth

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetMaxHealth(this IEntity entity) => entity.GetValue<IValue<int>>(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMaxHealth(this IEntity entity, out IValue<int> value) => entity.TryGetValue(MaxHealth, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMaxHealth(this IEntity entity, IValue<int> value) => entity.AddValue(MaxHealth, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMaxHealth(this IEntity entity) => entity.HasValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMaxHealth(this IEntity entity) => entity.DelValue(MaxHealth);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMaxHealth(this IEntity entity, IValue<int> value) => entity.SetValue(MaxHealth, value);

		#endregion

		#region Health

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealth(this IEntity entity) => entity.GetValue<IReactiveVariable<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity entity, out IReactiveVariable<int> value) => entity.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IEntity entity, IReactiveVariable<int> value) => entity.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity entity) => entity.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity entity) => entity.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity entity, IReactiveVariable<int> value) => entity.SetValue(Health, value);

		#endregion

		#region TakeDamageAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<int> GetTakeDamageAction(this IEntity entity) => entity.GetValue<ICompositeAction<int>>(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTakeDamageAction(this IEntity entity, out ICompositeAction<int> value) => entity.TryGetValue(TakeDamageAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTakeDamageAction(this IEntity entity, ICompositeAction<int> value) => entity.AddValue(TakeDamageAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTakeDamageAction(this IEntity entity) => entity.HasValue(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTakeDamageAction(this IEntity entity) => entity.DelValue(TakeDamageAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTakeDamageAction(this IEntity entity, ICompositeAction<int> value) => entity.SetValue(TakeDamageAction, value);

		#endregion

		#region FireRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetFireRequest(this IEntity entity) => entity.GetValue<IRequest>(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireRequest(this IEntity entity, out IRequest value) => entity.TryGetValue(FireRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireRequest(this IEntity entity, IRequest value) => entity.AddValue(FireRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireRequest(this IEntity entity) => entity.HasValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireRequest(this IEntity entity) => entity.DelValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireRequest(this IEntity entity, IRequest value) => entity.SetValue(FireRequest, value);

		#endregion

		#region FireCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetFireCommand(this IEntity entity) => entity.GetValue<ICommand>(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCommand(this IEntity entity, out ICommand value) => entity.TryGetValue(FireCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCommand(this IEntity entity, ICommand value) => entity.AddValue(FireCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCommand(this IEntity entity) => entity.HasValue(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCommand(this IEntity entity) => entity.DelValue(FireCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCommand(this IEntity entity, ICommand value) => entity.SetValue(FireCommand, value);

		#endregion

		#region Weapon

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IEntity> GetWeapon(this IEntity entity) => entity.GetValue<IVariable<IEntity>>(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeapon(this IEntity entity, out IVariable<IEntity> value) => entity.TryGetValue(Weapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeapon(this IEntity entity, IVariable<IEntity> value) => entity.AddValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeapon(this IEntity entity) => entity.HasValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeapon(this IEntity entity) => entity.DelValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeapon(this IEntity entity, IVariable<IEntity> value) => entity.SetValue(Weapon, value);

		#endregion

		#region FireAnticipation

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetFireAnticipation(this IEntity entity) => entity.GetValue<ICooldown>(FireAnticipation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAnticipation(this IEntity entity, out ICooldown value) => entity.TryGetValue(FireAnticipation, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireAnticipation(this IEntity entity, ICooldown value) => entity.AddValue(FireAnticipation, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAnticipation(this IEntity entity) => entity.HasValue(FireAnticipation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAnticipation(this IEntity entity) => entity.DelValue(FireAnticipation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAnticipation(this IEntity entity, ICooldown value) => entity.SetValue(FireAnticipation, value);

		#endregion

		#region WantsToFire

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<bool> GetWantsToFire(this IEntity entity) => entity.GetValue<IReactiveVariable<bool>>(WantsToFire);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWantsToFire(this IEntity entity, out IReactiveVariable<bool> value) => entity.TryGetValue(WantsToFire, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWantsToFire(this IEntity entity, IReactiveVariable<bool> value) => entity.AddValue(WantsToFire, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWantsToFire(this IEntity entity) => entity.HasValue(WantsToFire);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWantsToFire(this IEntity entity) => entity.DelValue(WantsToFire);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWantsToFire(this IEntity entity, IReactiveVariable<bool> value) => entity.SetValue(WantsToFire, value);

		#endregion

		#region WeaponCooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetWeaponCooldown(this IEntity entity) => entity.GetValue<ICooldown>(WeaponCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeaponCooldown(this IEntity entity, out ICooldown value) => entity.TryGetValue(WeaponCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeaponCooldown(this IEntity entity, ICooldown value) => entity.AddValue(WeaponCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeaponCooldown(this IEntity entity) => entity.HasValue(WeaponCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeaponCooldown(this IEntity entity) => entity.DelValue(WeaponCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeaponCooldown(this IEntity entity, ICooldown value) => entity.SetValue(WeaponCooldown, value);

		#endregion

		#region Ammo

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetAmmo(this IEntity entity) => entity.GetValue<IReactiveVariable<int>>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IEntity entity, out IReactiveVariable<int> value) => entity.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAmmo(this IEntity entity, IReactiveVariable<int> value) => entity.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IEntity entity) => entity.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IEntity entity) => entity.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IEntity entity, IReactiveVariable<int> value) => entity.SetValue(Ammo, value);

		#endregion

		#region Lifetime

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetLifetime(this IEntity entity) => entity.GetValue<ICooldown>(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifetime(this IEntity entity, out ICooldown value) => entity.TryGetValue(Lifetime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddLifetime(this IEntity entity, ICooldown value) => entity.AddValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifetime(this IEntity entity) => entity.HasValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifetime(this IEntity entity) => entity.DelValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifetime(this IEntity entity, ICooldown value) => entity.SetValue(Lifetime, value);

		#endregion

		#region Damage

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IEntity entity) => entity.GetValue<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IEntity entity, out IValue<int> value) => entity.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IEntity entity, IValue<int> value) => entity.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IEntity entity) => entity.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IEntity entity) => entity.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IEntity entity, IValue<int> value) => entity.SetValue(Damage, value);

		#endregion

		#region InteractCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand<IEntity> GetInteractCommand(this IEntity entity) => entity.GetValue<ICommand<IEntity>>(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractCommand(this IEntity entity, out ICommand<IEntity> value) => entity.TryGetValue(InteractCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractCommand(this IEntity entity, ICommand<IEntity> value) => entity.AddValue(InteractCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractCommand(this IEntity entity) => entity.HasValue(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractCommand(this IEntity entity) => entity.DelValue(InteractCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractCommand(this IEntity entity, ICommand<IEntity> value) => entity.SetValue(InteractCommand, value);

		#endregion

		#region Trigger

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEvents GetTrigger(this IEntity entity) => entity.GetValue<TriggerEvents>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IEntity entity, out TriggerEvents value) => entity.TryGetValue(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrigger(this IEntity entity, TriggerEvents value) => entity.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IEntity entity) => entity.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IEntity entity) => entity.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IEntity entity, TriggerEvents value) => entity.SetValue(Trigger, value);

		#endregion

		#region DestroyAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IEntity entity) => entity.GetValue<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IEntity entity, out IAction value) => entity.TryGetValue(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDestroyAction(this IEntity entity, IAction value) => entity.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IEntity entity) => entity.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IEntity entity) => entity.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IEntity entity, IAction value) => entity.SetValue(DestroyAction, value);

		#endregion

		#region RespawnAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction GetRespawnAction(this IEntity entity) => entity.GetValue<ICompositeAction>(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRespawnAction(this IEntity entity, out ICompositeAction value) => entity.TryGetValue(RespawnAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRespawnAction(this IEntity entity, ICompositeAction value) => entity.AddValue(RespawnAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRespawnAction(this IEntity entity) => entity.HasValue(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRespawnAction(this IEntity entity) => entity.DelValue(RespawnAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRespawnAction(this IEntity entity, ICompositeAction value) => entity.SetValue(RespawnAction, value);

		#endregion

		#region AnimationEvents

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<AnimationEvents> GetAnimationEvents(this IEntity entity) => entity.GetValue<IValue<AnimationEvents>>(AnimationEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimationEvents(this IEntity entity, out IValue<AnimationEvents> value) => entity.TryGetValue(AnimationEvents, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimationEvents(this IEntity entity, IValue<AnimationEvents> value) => entity.AddValue(AnimationEvents, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimationEvents(this IEntity entity) => entity.HasValue(AnimationEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimationEvents(this IEntity entity) => entity.DelValue(AnimationEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimationEvents(this IEntity entity, IValue<AnimationEvents> value) => entity.SetValue(AnimationEvents, value);

		#endregion

		#region Animator

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IEntity entity) => entity.GetValue<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IEntity entity, out Animator value) => entity.TryGetValue(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimator(this IEntity entity, Animator value) => entity.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IEntity entity) => entity.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IEntity entity) => entity.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IEntity entity, Animator value) => entity.SetValue(Animator, value);

		#endregion

		#region AudioSource

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AudioSource GetAudioSource(this IEntity entity) => entity.GetValue<AudioSource>(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAudioSource(this IEntity entity, out AudioSource value) => entity.TryGetValue(AudioSource, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAudioSource(this IEntity entity, AudioSource value) => entity.AddValue(AudioSource, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAudioSource(this IEntity entity) => entity.HasValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAudioSource(this IEntity entity) => entity.DelValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAudioSource(this IEntity entity, AudioSource value) => entity.SetValue(AudioSource, value);

		#endregion

		#region ParticleSystem

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ParticleSystem GetParticleSystem(this IEntity entity) => entity.GetValue<ParticleSystem>(ParticleSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetParticleSystem(this IEntity entity, out ParticleSystem value) => entity.TryGetValue(ParticleSystem, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddParticleSystem(this IEntity entity, ParticleSystem value) => entity.AddValue(ParticleSystem, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasParticleSystem(this IEntity entity) => entity.HasValue(ParticleSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelParticleSystem(this IEntity entity) => entity.DelValue(ParticleSystem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetParticleSystem(this IEntity entity, ParticleSystem value) => entity.SetValue(ParticleSystem, value);

		#endregion

		#region TrailRender

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TrailRenderer GetTrailRender(this IEntity entity) => entity.GetValue<TrailRenderer>(TrailRender);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrailRender(this IEntity entity, out TrailRenderer value) => entity.TryGetValue(TrailRender, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrailRender(this IEntity entity, TrailRenderer value) => entity.AddValue(TrailRender, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrailRender(this IEntity entity) => entity.HasValue(TrailRender);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrailRender(this IEntity entity) => entity.DelValue(TrailRender);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrailRender(this IEntity entity, TrailRenderer value) => entity.SetValue(TrailRender, value);

		#endregion

		#region Target

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IEntity> GetTarget(this IEntity entity) => entity.GetValue<IVariable<IEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IEntity entity, out IVariable<IEntity> value) => entity.TryGetValue(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTarget(this IEntity entity, IVariable<IEntity> value) => entity.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IEntity entity) => entity.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IEntity entity) => entity.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IEntity entity, IVariable<IEntity> value) => entity.SetValue(Target, value);

		#endregion

		#region Owner

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IEntity> GetOwner(this IEntity entity) => entity.GetValue<IVariable<IEntity>>(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetOwner(this IEntity entity, out IVariable<IEntity> value) => entity.TryGetValue(Owner, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddOwner(this IEntity entity, IVariable<IEntity> value) => entity.AddValue(Owner, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasOwner(this IEntity entity) => entity.HasValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelOwner(this IEntity entity) => entity.DelValue(Owner);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetOwner(this IEntity entity, IVariable<IEntity> value) => entity.SetValue(Owner, value);

		#endregion

		#region Score

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetScore(this IEntity entity) => entity.GetValue<IReactiveVariable<int>>(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetScore(this IEntity entity, out IReactiveVariable<int> value) => entity.TryGetValue(Score, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddScore(this IEntity entity, IReactiveVariable<int> value) => entity.AddValue(Score, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasScore(this IEntity entity) => entity.HasValue(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelScore(this IEntity entity) => entity.DelValue(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetScore(this IEntity entity, IReactiveVariable<int> value) => entity.SetValue(Score, value);

		#endregion

		#region BloodParticle

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ParticleSystem GetBloodParticle(this IEntity entity) => entity.GetValue<ParticleSystem>(BloodParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBloodParticle(this IEntity entity, out ParticleSystem value) => entity.TryGetValue(BloodParticle, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBloodParticle(this IEntity entity, ParticleSystem value) => entity.AddValue(BloodParticle, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBloodParticle(this IEntity entity) => entity.HasValue(BloodParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBloodParticle(this IEntity entity) => entity.DelValue(BloodParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBloodParticle(this IEntity entity, ParticleSystem value) => entity.SetValue(BloodParticle, value);

		#endregion

		#region DeadParticle

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ParticleSystem GetDeadParticle(this IEntity entity) => entity.GetValue<ParticleSystem>(DeadParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeadParticle(this IEntity entity, out ParticleSystem value) => entity.TryGetValue(DeadParticle, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDeadParticle(this IEntity entity, ParticleSystem value) => entity.AddValue(DeadParticle, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeadParticle(this IEntity entity) => entity.HasValue(DeadParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeadParticle(this IEntity entity) => entity.DelValue(DeadParticle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeadParticle(this IEntity entity, ParticleSystem value) => entity.SetValue(DeadParticle, value);

		#endregion

		#region MoveAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetMoveAudioClips(this IEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(MoveAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveAudioClips(this IEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(MoveAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(MoveAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveAudioClips(this IEntity entity) => entity.HasValue(MoveAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveAudioClips(this IEntity entity) => entity.DelValue(MoveAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(MoveAudioClips, value);

		#endregion

		#region PainAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetPainAudioClips(this IEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(PainAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPainAudioClips(this IEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(PainAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPainAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(PainAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPainAudioClips(this IEntity entity) => entity.HasValue(PainAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPainAudioClips(this IEntity entity) => entity.DelValue(PainAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPainAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(PainAudioClips, value);

		#endregion

		#region DeathAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetDeathAudioClips(this IEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(DeathAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeathAudioClips(this IEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(DeathAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDeathAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(DeathAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeathAudioClips(this IEntity entity) => entity.HasValue(DeathAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeathAudioClips(this IEntity entity) => entity.DelValue(DeathAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeathAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(DeathAudioClips, value);

		#endregion

		#region AttackAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetAttackAudioClips(this IEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(AttackAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackAudioClips(this IEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(AttackAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(AttackAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackAudioClips(this IEntity entity) => entity.HasValue(AttackAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackAudioClips(this IEntity entity) => entity.DelValue(AttackAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(AttackAudioClips, value);

		#endregion

		#region BodyFallAudioClips

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<List<AudioClip>> GetBodyFallAudioClips(this IEntity entity) => entity.GetValue<IValue<List<AudioClip>>>(BodyFallAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBodyFallAudioClips(this IEntity entity, out IValue<List<AudioClip>> value) => entity.TryGetValue(BodyFallAudioClips, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBodyFallAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.AddValue(BodyFallAudioClips, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBodyFallAudioClips(this IEntity entity) => entity.HasValue(BodyFallAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBodyFallAudioClips(this IEntity entity) => entity.DelValue(BodyFallAudioClips);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBodyFallAudioClips(this IEntity entity, IValue<List<AudioClip>> value) => entity.SetValue(BodyFallAudioClips, value);

		#endregion

		#region MoveSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetMoveSoundRequest(this IEntity entity) => entity.GetValue<IRequest>(MoveSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSoundRequest(this IEntity entity, out IRequest value) => entity.TryGetValue(MoveSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSoundRequest(this IEntity entity, IRequest value) => entity.AddValue(MoveSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSoundRequest(this IEntity entity) => entity.HasValue(MoveSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSoundRequest(this IEntity entity) => entity.DelValue(MoveSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSoundRequest(this IEntity entity, IRequest value) => entity.SetValue(MoveSoundRequest, value);

		#endregion

		#region MoveSoundCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetMoveSoundCommand(this IEntity entity) => entity.GetValue<ICommand>(MoveSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSoundCommand(this IEntity entity, out ICommand value) => entity.TryGetValue(MoveSoundCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSoundCommand(this IEntity entity, ICommand value) => entity.AddValue(MoveSoundCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSoundCommand(this IEntity entity) => entity.HasValue(MoveSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSoundCommand(this IEntity entity) => entity.DelValue(MoveSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSoundCommand(this IEntity entity, ICommand value) => entity.SetValue(MoveSoundCommand, value);

		#endregion

		#region BodyFallSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetBodyFallSoundRequest(this IEntity entity) => entity.GetValue<IRequest>(BodyFallSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBodyFallSoundRequest(this IEntity entity, out IRequest value) => entity.TryGetValue(BodyFallSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBodyFallSoundRequest(this IEntity entity, IRequest value) => entity.AddValue(BodyFallSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBodyFallSoundRequest(this IEntity entity) => entity.HasValue(BodyFallSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBodyFallSoundRequest(this IEntity entity) => entity.DelValue(BodyFallSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBodyFallSoundRequest(this IEntity entity, IRequest value) => entity.SetValue(BodyFallSoundRequest, value);

		#endregion

		#region BodyFallSoundCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetBodyFallSoundCommand(this IEntity entity) => entity.GetValue<ICommand>(BodyFallSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBodyFallSoundCommand(this IEntity entity, out ICommand value) => entity.TryGetValue(BodyFallSoundCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBodyFallSoundCommand(this IEntity entity, ICommand value) => entity.AddValue(BodyFallSoundCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBodyFallSoundCommand(this IEntity entity) => entity.HasValue(BodyFallSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBodyFallSoundCommand(this IEntity entity) => entity.DelValue(BodyFallSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBodyFallSoundCommand(this IEntity entity, ICommand value) => entity.SetValue(BodyFallSoundCommand, value);

		#endregion

		#region FireSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetFireSoundRequest(this IEntity entity) => entity.GetValue<IRequest>(FireSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireSoundRequest(this IEntity entity, out IRequest value) => entity.TryGetValue(FireSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireSoundRequest(this IEntity entity, IRequest value) => entity.AddValue(FireSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireSoundRequest(this IEntity entity) => entity.HasValue(FireSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireSoundRequest(this IEntity entity) => entity.DelValue(FireSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireSoundRequest(this IEntity entity, IRequest value) => entity.SetValue(FireSoundRequest, value);

		#endregion

		#region AttackSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetAttackSoundRequest(this IEntity entity) => entity.GetValue<IRequest>(AttackSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackSoundRequest(this IEntity entity, out IRequest value) => entity.TryGetValue(AttackSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackSoundRequest(this IEntity entity, IRequest value) => entity.AddValue(AttackSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackSoundRequest(this IEntity entity) => entity.HasValue(AttackSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackSoundRequest(this IEntity entity) => entity.DelValue(AttackSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackSoundRequest(this IEntity entity, IRequest value) => entity.SetValue(AttackSoundRequest, value);

		#endregion

		#region AttackSoundCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetAttackSoundCommand(this IEntity entity) => entity.GetValue<ICommand>(AttackSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackSoundCommand(this IEntity entity, out ICommand value) => entity.TryGetValue(AttackSoundCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackSoundCommand(this IEntity entity, ICommand value) => entity.AddValue(AttackSoundCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackSoundCommand(this IEntity entity) => entity.HasValue(AttackSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackSoundCommand(this IEntity entity) => entity.DelValue(AttackSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackSoundCommand(this IEntity entity, ICommand value) => entity.SetValue(AttackSoundCommand, value);

		#endregion

		#region ShoutSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetShoutSoundRequest(this IEntity entity) => entity.GetValue<IRequest>(ShoutSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetShoutSoundRequest(this IEntity entity, out IRequest value) => entity.TryGetValue(ShoutSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddShoutSoundRequest(this IEntity entity, IRequest value) => entity.AddValue(ShoutSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasShoutSoundRequest(this IEntity entity) => entity.HasValue(ShoutSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelShoutSoundRequest(this IEntity entity) => entity.DelValue(ShoutSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetShoutSoundRequest(this IEntity entity, IRequest value) => entity.SetValue(ShoutSoundRequest, value);

		#endregion

		#region ShoutSoundCommand

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICommand GetShoutSoundCommand(this IEntity entity) => entity.GetValue<ICommand>(ShoutSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetShoutSoundCommand(this IEntity entity, out ICommand value) => entity.TryGetValue(ShoutSoundCommand, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddShoutSoundCommand(this IEntity entity, ICommand value) => entity.AddValue(ShoutSoundCommand, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasShoutSoundCommand(this IEntity entity) => entity.HasValue(ShoutSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelShoutSoundCommand(this IEntity entity) => entity.DelValue(ShoutSoundCommand);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetShoutSoundCommand(this IEntity entity, ICommand value) => entity.SetValue(ShoutSoundCommand, value);

		#endregion

		#region AttackAnticipationSoundRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetAttackAnticipationSoundRequest(this IEntity entity) => entity.GetValue<IRequest>(AttackAnticipationSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackAnticipationSoundRequest(this IEntity entity, out IRequest value) => entity.TryGetValue(AttackAnticipationSoundRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAttackAnticipationSoundRequest(this IEntity entity, IRequest value) => entity.AddValue(AttackAnticipationSoundRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackAnticipationSoundRequest(this IEntity entity) => entity.HasValue(AttackAnticipationSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackAnticipationSoundRequest(this IEntity entity) => entity.DelValue(AttackAnticipationSoundRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackAnticipationSoundRequest(this IEntity entity, IRequest value) => entity.SetValue(AttackAnticipationSoundRequest, value);

		#endregion
    }
}
