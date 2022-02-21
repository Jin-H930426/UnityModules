using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule.Charactere
{
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] Camera m_camera = null;
        [SerializeField] Transform m_character = null;
        [SerializeField] Vector3 m_direction = Vector3.zero;
        [Range(0.01f, 1.0f),SerializeField] float m_minDis = 0.01f;
        [SerializeField] bool m_TouchMove = false;
        [SerializeField] Interaction.InteractionRay m_interactionRay = null;
        [SerializeField] LayerMask m_mask;
        [ContextMenu("initialized")]
        private void Awake() {

            init();
            if(m_TouchMove) {
                m_interactionRay.RayHitEvent.AddListener(call => m_character.GetComponentInChildren<Charactere.CharacterController>().MovePosition(call.point, true));
                Manager.inputManager.playerInput.FireAction.AddListener(CharacterMove);
            }
        }

        void init()
        {
            if(!m_camera || ! m_character) return;
            m_direction = m_camera.transform.position - m_character.position;
            m_camera.transform.LookAt(m_character);

            if(m_TouchMove){
                if(!m_interactionRay) m_interactionRay = GetComponent<Interaction.InteractionRay>();
                if(!m_interactionRay) m_interactionRay = gameObject.AddComponent<Interaction.InteractionRay>();
            } 
        }

        private void LateUpdate() {
            LateUpdate_cameraTransform();
        }     
        void LateUpdate_cameraTransform()
        {
            if(!m_camera || ! m_character) return;

            RaycastCheck();
            m_camera.transform.LookAt(m_character);
        }
        void RaycastCheck()
        {
            RaycastHit hit;
            float dis = m_direction.magnitude;
            if(Physics.Raycast(m_character.position, m_direction, out hit, m_direction.magnitude, m_mask))
            {
                float dist = Mathf.Clamp((hit.point - m_character.position).magnitude - .8f, m_minDis * dis, dis);
                transform.position = m_character.position + m_direction.normalized * dist;
            }
            else
            {
                transform.position = m_character.position + m_direction;
            }
        }
        public void CharacterMove(bool clickValue)
        {
            if(clickValue) m_interactionRay.ShootRay();
        }
        #if UNITY_EDITOR
        private void OnValidate() {
            if(Application.isPlaying == false) init();
        }
        #endif
    }
}