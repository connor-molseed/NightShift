using UnityEngine;

public struct InteractionContext
{
    public GameObject _user;
    public InputType _inputType;

    public InteractionContext (GameObject user, InputType inputType = InputType.Press)
    {
        _user = user;
        _inputType = inputType;
    }
}

public enum InputType
{
    Press,
    Hold
}
