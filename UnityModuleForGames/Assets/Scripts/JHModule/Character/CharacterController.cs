using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule.Charactere
{
    [System.Serializable] public class PropertyParent
    {
        public string name;
    }
    [System.Serializable] public class triggerProperty : PropertyParent
    {

    }
    [System.Serializable] public class boolProperty : PropertyParent
    {
        public bool value;
    }
    [System.Serializable] public class intProperty : PropertyParent
    {
        public int value;
    }
    [System.Serializable] public class floatProperty : PropertyParent
    {
        [Range(0, 1)] public float value;
    }
    
    public struct animationProperty
    {
        public Animator m_animator;

    }
    public class CharacterController : MonoBehaviour
    {
        [Header("For Animation Property")]
        [SerializeField] Animator ani;
        [Header("For Move Property")]
        [SerializeField] SpeedProperty m_speedProperty = new SpeedProperty();
        [SerializeField, Range(0, 1)] float m_slowDistance = 0.2f;
        IEnumerator m_eff;
        float m_moveTime = 0;

        Vector3 m_targetPos = Vector3.zero;
        Vector3 m_velocity = Vector3.zero;
        public Vector3 velocity {get {return m_velocity;}}

        /// initialize characterController
        private void Awake() {
            m_speedProperty.init();
            m_targetPos = transform.position;
        }

        public void MovePosition(Vector3 position, bool isUseSlow)
        {
            if(m_eff != null)
            {
                StopCoroutine(m_eff);
                m_eff = null;
            }
            m_eff = _MovePosition(position, isUseSlow);
            StartCoroutine(m_eff);
        }
        IEnumerator _MovePosition(Vector3 position, bool isUseSlow)
        {
            float slowPoint = Vector3.Magnitude(position - transform.position) * m_slowDistance; 
            while(true)
            {
                yield return null;
                Vector3 direction = position - transform.position;
                direction.y = 0;
                if(Vector3.Magnitude(direction) < 0.001f) 
                    break;
                else if (Vector3.Magnitude(direction) < slowPoint)
                    this.m_moveTime = Mathf.Clamp(this.m_moveTime - (TimeProperty.runtime_DeltaTime * 10), .1f, 1);
                else
                {
                    this.m_moveTime = Mathf.Clamp01(this.m_moveTime + (TimeProperty.runtime_DeltaTime * 3f));
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), m_moveTime);
                }

                Vector3 move = Vector3.ClampMagnitude(direction.normalized * m_speedProperty.speed * TimeProperty.runtime_DeltaTime * this.m_moveTime, direction.magnitude );
                transform.position += move;

                
            }

            this.m_moveTime = 0;
            this.m_eff = null;
        }

        public void updateMovePlayer_2D(UnityEngine.InputSystem.InputAction.CallbackContext tex)
        {
            updateMovePlayer_2D(tex.ReadValue<Vector2>());
        }
        public void updateMovePlayer_2D(Vector2 direction)
        {
            // transform.Translate(direction * TimeProperty.runtime_DeltaTime * m_speedProperty.speed);
            Vector3 velocity = direction * TimeProperty.runtime_DeltaTime * m_speedProperty.speed;
            Vector3 nextPos = transform.position + velocity;
            MovePosition(nextPos, direction == Vector2.zero);
        }
        public void updateMovePlayer_sideScrolling(UnityEngine.InputSystem.InputAction.CallbackContext tex)
        {
            updateMovePlayer_sideScrolling(tex.ReadValue<Vector2>());
        }
        public void updateMovePlayer_sideScrolling(Vector2 direction)
        {
            // transform.Translate(new Vector3(direction.x, 0, 0) * TimeProperty.runtime_DeltaTime * m_speedProperty.speed);
            m_velocity = new Vector3(direction.x, 0, 0) * TimeProperty.runtime_DeltaTime * m_speedProperty.speed;
            Vector3 nextPos = transform.position + velocity;
        }
        public void updateMovePlayer_3D(UnityEngine.InputSystem.InputAction.CallbackContext tex)
        {
            updateMovePlayer_3D(tex.ReadValue<Vector2>());
        }
        public void updateMovePlayer_3D(Vector2 direction)
        {
            // transform.Translate(new Vector3(direction.x, 0, direction.y) * TimeProperty.runtime_DeltaTime * m_speedProperty.speed);
            m_velocity = new Vector3(direction.x, 0, direction.y) * TimeProperty.runtime_DeltaTime * m_speedProperty.speed;
            Vector3 nextPos = transform.position + velocity;
        }

    }
}