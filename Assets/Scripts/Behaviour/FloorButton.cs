using Entitas;
using Entitas.Unity;
using UnityEngine;

public class FloorButton : MonoBehaviour, IEntityView
{
    public GameEntity Entity { get; set; }

    [field: SerializeField] public Door RelatedDoor { get; set; }

    [field: SerializeField] public Animator Animator { get; set; }

    [field: SerializeField] private Color ButtonAndDoorColor { get; set; }

    [field: SerializeField] private Renderer Render { get; set; }

    private void Awake()
    {
        SetColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        IEntityView player = other.gameObject.GetComponent<IEntityView>();

        if (player != null)
        {
            Contexts.sharedInstance.game.CreateEntity().AddCollision(Entity, player.Entity);
        }
    }

    public void SetColor()
    {
        Material newMaterial = new Material(Render.material);

        newMaterial.color = ButtonAndDoorColor;

        Render.material = newMaterial;

        RelatedDoor.SetColor(ButtonAndDoorColor);
    }
}
