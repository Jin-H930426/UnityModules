using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule.Events
{
    using UnityEngine.Events;
    [System.Serializable] public class UnityVector2Event : UnityEvent<Vector2>{} 
    [System.Serializable] public class UnityBoolEvent : UnityEvent<bool>{}
}