using Services;
using Leopotam.Ecs;
using Components.PhysicsEvents;
using Systems.CoreSystems.BaseGameplay;
using Systems.Spawners;
using Systems.MoveSystems;
using Components.Common.Input;
using Components.Core;
using UnityComponents.Common;
using UnityEngine;
using Leopotam.Ecs.Ui.Systems;
using Systems.InputSystems;

sealed class EcsStartup : MonoBehaviour
{
	[SerializeField]
	private StaticData _staticData;
	[SerializeField]
	private SceneData _sceneData;
	[SerializeField] 
	private EcsUiEmitter _uiEmitter;

	private const string Coregameplay = "CoreGameplay";
	private const string Movable = "Movable";
	private const string Spawn = "Spawn";
	
	private EcsWorld _world;
	private EcsSystems _systems;
	private EcsSystems _fixedSystem;
	
	private PauseService _pauseService;
	private ScoreService _scoreService;
	
	private int _spawnSystems;
	private int _coreGameplaySystems;
	private int _movableSystems;

	private void Start()
	{
		_world = new EcsWorld();
		_systems = new EcsSystems(_world, "UpdateSystems");
		_fixedSystem = new EcsSystems(_world, "FixedUpdateSystems");
		
		InitializedServices();
		InitializeObserver();
		
		InitializedUpdateSystems();
		InitializeFixedSystems();
		
		CalcSystemIndexes();

		Subscribe();

		SetGameplayState(true);
	}

	private void InitializeObserver()
	{
#if UNITY_EDITOR
		Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
		Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
		Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedSystem);
#endif
	}
	
	private void OnChangePauseState(bool isPause)
	{
		SetGameplayState(!isPause);
	}
	
	private void InitializedUpdateSystems()
	{
		EcsSystems inputSystems = InputSystems();
		EcsSystems spawnSystems = SpawnSystems(Spawn);
		EcsSystems uiSystems = UISystems();
		
		_systems
			.Add(uiSystems)
			.Add(inputSystems)
			.Add(spawnSystems)
			.Inject(_staticData)
			.Inject(_sceneData)
			.Inject(_pauseService)
			.Inject(_scoreService)
			.InjectUi(_uiEmitter)
			.Init();
	}
	
	private void InitializeFixedSystems()
	{
		EcsSystems coreSystems = CoreGameplaySystems(Coregameplay);
		EcsSystems movableSystems = MovableSystems(Movable);

		_fixedSystem
			.Add(coreSystems)
			.Add(movableSystems)
			.OneFrame<OnCollisionEnterEvent>()
			.OneFrame<OnTriggerEnterEvent>()
			.Inject(_sceneData)
			.Inject(_staticData)
			.Inject(_pauseService)
			.Inject(_scoreService)
			.Init();
	}
	
	private void InitializedServices()
	{
		_pauseService = new PauseService(false);
		_scoreService = new ScoreService();
	}
	
	private void CalcSystemIndexes()
	{
		_spawnSystems = _systems.GetNamedRunSystem(Spawn);
		_coreGameplaySystems = _fixedSystem.GetNamedRunSystem(Coregameplay);
		_movableSystems = _fixedSystem.GetNamedRunSystem(Movable);
	}
	
	private void Update()
	{
		_systems?.Run();
	}
	
	private void FixedUpdate()
	{
		_fixedSystem?.Run();
	}

	private void OnDestroy()
	{
		if (_fixedSystem != null)
		{
			_fixedSystem.Destroy();
			_fixedSystem = null;
		}

		if (_systems != null)
		{
			_systems.Destroy();
			_systems = null;
		}

		if (_world != null)
		{
			_world.Destroy();
			_world = null;
		}

		Unsubscribe();
	}
	
	private void SetGameplayState(bool value)
	{
		_systems.SetRunSystemState(_spawnSystems, value);
		_fixedSystem.SetRunSystemState(_coreGameplaySystems, value);
		_fixedSystem.SetRunSystemState(_movableSystems, value);
	}

	private void Subscribe()
	{
		_pauseService.ChangeStateEvent += OnChangePauseState;
	}
	
	private void Unsubscribe()
	{
		_pauseService.ChangeStateEvent -= OnChangePauseState;
	}
	
	private EcsSystems UISystems()
	{
		return new EcsSystems(_world);
	}
	
	private EcsSystems SpawnSystems(string name)
	{
		return new EcsSystems(_world, name)
			.Add(new EnemySpawner())
			.Add(new CardsSpawnerSystem())
			.Add(new SpawnSystem());;
	}

	private EcsSystems InputSystems()
	{
		return new EcsSystems(_world)
			.Add(new KeyInputSystem())
			.Add(new PlayerMovementSystem())
			.OneFrame<MoveKeyDownEvent>();
	}

	private EcsSystems MovableSystems(string name)
	{
		return new EcsSystems(_world, name)
			.Add(new EnemyFollowSystem())
			.Add(new GravitationSystem())
			.Add(new MoveForwardSystem())
			.Add(new MoveSystem())
			.Add(new UpdateRigidbodyPosition());
	}

	private EcsSystems CoreGameplaySystems(string name)
	{
		return new EcsSystems(_world, name)
			.Add(new DeadOverTimeSystem())
			.Add(new FindClosestEnemiesSystem())
			.Add(new SpawnMeleeAttackSystem())
			.Add(new DamageOnTriggerEnterSystem())
			.Add(new DamageSystem())
			.Add(new DeadSystem())
			.Add(new PickUpSystem())
			.OneFrame<PickUpEvent>()
			.OneFrame<EnemyCloseEvent>()
			.OneFrame<OnCollisionEnterEvent>()
			.OneFrame<DamageEvent>()
			.OneFrame<DeadEvent>()
			.OneFrame<OnTriggerEnterEvent>();
	}
}