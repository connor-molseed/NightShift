using System;
using UnityEngine;

//No workie, don't use
[Obsolete("Class doesn't currently work")]
public class GlobalEventCaller : MonoBehaviour
{
    [SerializeField] protected GlobalEvent<EventArgs> _event;
}
