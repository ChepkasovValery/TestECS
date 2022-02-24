using Entitas;
using UnityEngine;
using UnityEngine.AI;

public class Bootstrap : MonoBehaviour
{
    [field: SerializeField] private Camera MainCamera { get; set; }

    [field: SerializeField] private NavMeshAgent Player { get; set; }

    [field: SerializeField] private NavMeshAgent Drone { get; set; }

    [field: SerializeField] private Animator PlayerAnimator { get; set; }

    [field: SerializeField] private ToTargetMoverConfig CameraMoverConfig { get; set; }

    [field: SerializeField] private FloorButton[] FloorButtons { get; set; }

    [field: SerializeField] private Door[] Doors { get; set; }

    private GameSystems _gameSystems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        InitPlayer(contexts);

        InitDrone(contexts);

        InitDoors(contexts);

        InitFloorBtns(contexts);

        CreateCameraFollower(contexts);

        _gameSystems = new GameSystems(contexts, MainCamera);

        _gameSystems.Initialize();
    }

    private void Update()
    {
        _gameSystems.Execute();

        _gameSystems.Cleanup();
    }

    private void InitFloorBtns(Contexts contexts)
    {
        foreach(FloorButton button in FloorButtons)
        {
            GameEntity entity = contexts.game.CreateEntity();

            entity.AddFloorButton(false);

            entity.AddRelatedGameEntity(button.RelatedDoor.Entity);

            entity.AddAnimator(button.Animator);

            button.Entity = entity;
        }
    }

    private void InitDoors(Contexts contexts)
    {
        foreach (Door door in Doors)
        {
            GameEntity entity = contexts.game.CreateEntity();

            entity.AddDoor(false);

            entity.AddAnimator(door.Animator);

            door.Entity = entity;
        }
    }

    private void InitPlayer(Contexts contexts)
    {
        GameEntity entity = contexts.game.CreateEntity();

        entity.isPlayer = true;

        entity.AddView(Player.gameObject);

        entity.AddMouseWorldRayPosition(Vector3.zero);

        entity.AddNavMeshTargetPosition(Vector3.zero);

        entity.AddNavMeshMover(Player);

        entity.AddPlayerAnimation(PlayerAnimator, Player);

        Player.gameObject.GetComponent<IEntityView>().Entity = entity;
    }

    private void InitDrone(Contexts contexts)
    {
        GameEntity entity = contexts.game.CreateEntity();

        entity.isDrone = true;

        entity.AddView(Drone.gameObject);

        entity.AddNavMeshTargetPosition(Vector3.zero);

        entity.AddNavMeshMover(Drone);
    }

    private void CreateCameraFollower(Contexts contexts)
    {
        GameEntity entity = contexts.game.CreateEntity();

        entity.AddView(MainCamera.gameObject);

        entity.AddWorldPosition(MainCamera.transform.position);

        entity.AddMoverToTarget(Player.transform, CameraMoverConfig.offset, CameraMoverConfig.speed);
    }
}
