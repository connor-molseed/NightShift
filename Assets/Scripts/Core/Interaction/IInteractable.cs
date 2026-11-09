using Core.Interaction;

public interface IInteractable
{
    string DisplayName{ get; }
    bool IsInteractable{ get; }

    bool InteractPress(InteractionContext context);
    bool InteractHold(InteractionContext context);
}