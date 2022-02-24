using Entitas;
using UnityEngine;

public class GameSystems : Feature
{
    public GameSystems(Contexts contexts, Camera mainCamera)
    {
        Add(new MouseInputSystem(contexts, mainCamera));

        Add(new WorldPositionSystem(contexts.game));

        Add(new NavMeshMoverSystem(contexts));

        Add(new PlayerMoverSystem(contexts));

        Add(new PlayerAnimationSystem(contexts));

        Add(new MoverToTargetSystem(contexts));

        Add(new DroneMoverSystem(contexts));

        Add(new OpenDoorsSystem(contexts));

        Add(new DoorAnimationSystem(contexts));

        Add(new ButtonAnimationSystem(contexts));
    }
}
