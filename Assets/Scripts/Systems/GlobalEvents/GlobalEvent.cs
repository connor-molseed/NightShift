using UnityEngine;
using UltEvents;
using System.Collections.Generic;

/**
    Global Event System Parts
    - GlobalEvent ScriptableObject, created as project assets per type of event
    - Listener Component, added to GameObjects that are needed to react to events

    Generics Defined
    - A: Arguments to be sent alongside the event callback (e.g. int, string, custom struct)
    - E: GlobalEvent type the listener can subscribe to (e.g. different types can use different arguments)
**/

/// <summary>
/// 
/// </summary>
/// <typeparam name="A">Argument to be sent alongside the event callback (e.g. int, string, custom struct)</typeparam>
public abstract class GlobalEvent<A> : ScriptableObject
{
    //Config Parameters
    
    //State Variables
    private readonly List<IGlobalEventListener<A>> listeners = new List<IGlobalEventListener<A>>();
    
    //Cached References
    
    //Properties
    
    //Events
    

    public void RegisterListener(IGlobalEventListener<A> listener) => listeners.Add(listener);
    public void DeregisterListener(IGlobalEventListener<A> listener) => listeners.Add(listener);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="A">Argument to be sent alongside the event callback (e.g. int, string, custom struct)</typeparam>
public interface IGlobalEventListener<A>
{
    void OnEventRaised(GameObject source, A value);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="A">Argument to be sent alongside the event callback (e.g. int, string, custom struct)</typeparam>
/// <typeparam name="E">Global Event type the Listener can subscribe to (e.g. must be type that supports expected Argument)</typeparam>
public abstract class GlobalEventListener<A, E> : MonoBehaviour, IGlobalEventListener<A>
    where E : GlobalEvent<A>
{
    [SerializeField] private E _event;
    [SerializeField] private UltEvent<GameObject, A> _response;

    private void OnEnable() => _event?.RegisterListener(this);
    private void OnDisable() => _event?.DeregisterListener(this);
    public void OnEventRaised(GameObject source, A value) => _response?.Invoke(source, value);
}