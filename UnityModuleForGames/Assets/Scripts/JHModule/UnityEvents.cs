using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule.Events
{
    using UnityEngine.Events;
    [System.Serializable] public class UnityVector2Event : UnityEvent<Vector2>{} 
    [System.Serializable] public class UnityBoolEvent : UnityEvent<bool>{}
    [System.Serializable] public class UnityRayEvent : UnityEvent<RaycastHit>{}
    [System.Serializable] public class UnityRay2DEvent : UnityEvent<RaycastHit2D>{}
}