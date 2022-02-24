//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DoorComponent door { get { return (DoorComponent)GetComponent(GameComponentsLookup.Door); } }
    public bool hasDoor { get { return HasComponent(GameComponentsLookup.Door); } }

    public void AddDoor(bool newOpen) {
        var index = GameComponentsLookup.Door;
        var component = (DoorComponent)CreateComponent(index, typeof(DoorComponent));
        component.Open = newOpen;
        AddComponent(index, component);
    }

    public void ReplaceDoor(bool newOpen) {
        var index = GameComponentsLookup.Door;
        var component = (DoorComponent)CreateComponent(index, typeof(DoorComponent));
        component.Open = newOpen;
        ReplaceComponent(index, component);
    }

    public void RemoveDoor() {
        RemoveComponent(GameComponentsLookup.Door);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDoor;

    public static Entitas.IMatcher<GameEntity> Door {
        get {
            if (_matcherDoor == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Door);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDoor = matcher;
            }

            return _matcherDoor;
        }
    }
}
