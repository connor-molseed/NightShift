using UnityEngine;

public struct InteractionContext
{
    public GameObject User;
    public InputType Type;

    public InteractionContext (GameObject user, InputType inputType = InputType.Press)
    {
        User = user;
        Type = inputType;
    }
}

public enum InputType
{
    Press,
    Hold
}
