using UnityEngine;

public class Interaction_SecurityCameraMonitor : MonoBehaviour
{
    [SerializeField] protected SecurityCameraScreen _securityCameraUI;

    void Awake()
    {
        
    }


    protected void Handle_OnInteractPress(InteractionContext context)
    {
        PlayerController player = context.User?.GetComponent<PlayerController>();

        if (player == null) return;

        _securityCameraUI.EnableUI();
    }
}