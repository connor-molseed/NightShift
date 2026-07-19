using UnityEngine;

public struct InteractContext
{
    public GameObject _user;
    public InputType _inputType;

    public InteractContext (GameObject user, InputType inputType = InputType.Press)
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
