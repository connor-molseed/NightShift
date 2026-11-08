using UnityEngine;

namespace Core.Interaction
{
    public struct InteractionContext
    {
        public GameObject User;
        public bool IsPlayer;
    
        public InteractionContext (GameObject user, bool isPlayer = true)
        {
            User = user;
            IsPlayer = isPlayer;
        }
    }
    
    public enum InputType
    {
        Press,
        Hold
    }
}
