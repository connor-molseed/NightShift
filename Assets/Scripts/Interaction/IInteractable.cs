public interface IInteractable
{
    //Properties
    bool CanInteract => true;
    
    //Methods
    void Interact (InteractContext context);
}
