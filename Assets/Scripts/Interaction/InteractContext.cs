using UnityEngine;

public struct InteractionContext
{
    public GameObject User;
    public bool IsPlayer;
    public InputType Type;

    public InteractionContext (GameObject user, bool isPlayer = true, InputType inputType = InputType.Press)
    {
        User = user;
        IsPlayer = isPlayer;
        Type = inputType;
    }
}

public enum InputType
{
    Press,
    Hold
}
