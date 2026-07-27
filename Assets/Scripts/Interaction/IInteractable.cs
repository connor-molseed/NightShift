using System;

[Obsolete("Use Interaction instead.")]
public interface IInteractable
{
    //Properties
    bool CanInteract => true;
    
    //Methods
    void Interact (InteractionContext context);
}
