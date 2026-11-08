using Core.Interaction;

public interface IInteractable
{
    string DisplayName{ get; }
    bool IsEnabled{ get; }

    bool InteractPress(InteractionContext context);
    bool InteractHold(InteractionContext context);
}