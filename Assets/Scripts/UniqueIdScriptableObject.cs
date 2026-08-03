using UnityEngine;

public abstract class UniqueIdScriptableObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private string uniqueId;

    public string UniqueId => uniqueId;

    public void OnAfterDeserialize() { }

    public void OnBeforeSerialize()
    {
        if (string.IsNullOrEmpty(uniqueId))
        {
            GenerateId();
        }
    }

    protected virtual void OnValidate()
    {
        if (string.IsNullOrEmpty(uniqueId))
        {
            GenerateId();
        }
    }

    [ContextMenu("Regenerate Unique ID")]
    private void GenerateId()
    {
        uniqueId = System.Guid.NewGuid().ToString();
        
        #if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}