using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JHModule.InputSystem
{
    using Events;

    [System.Flags, System.Serializable]
    enum InputMask : int
    {
        Keyborad = 0x00000001,
        Mouse = 0x00000002,

    }
    [System.Serializable]
    public class KeyboradInput
    {
        Vector2 m_movekeyStatus = Vector2.zero;
        bool m_ismovekeyDown = false;
        public UnityVector2Event MoveBeginKeyAction;
        public UnityVector2Event MoveExitKeyAction;

        public void init(Input input)
        {
            input.Keyborads.Move.performed -= MoveKeyBeginEvent;
            input.Keyborads.Move.performed += MoveKeyBeginEvent;
            input.Keyborads.Move.canceled -= MoveKeyExitEvent;
            input.Keyborads.Move.canceled += MoveKeyExitEvent;
        }
        public void Update() 
        {
            if(m_ismovekeyDown) MoveBeginKeyAction?.Invoke(m_movekeyStatus);
        }
        public void MoveKeyBeginEvent(UnityEngine.InputSystem.InputAction.CallbackContext caltex)
        {
            m_ismovekeyDown = true;
            m_movekeyStatus = caltex.ReadValue<Vector2>();
        }
        public void MoveKeyExitEvent(UnityEngine.InputSystem.InputAction.CallbackContext caltex)
        {
            m_ismovekeyDown = false;
            m_movekeyStatus = Vector2.zero;
            MoveExitKeyAction?.Invoke(Vector2.zero);
        }
    }
    public class InputManager : MonoBehaviour
    {
        [SerializeField] InputMask inputMask = new InputMask();
        Input input = null;
        [SerializeField] KeyboradInput keyboradInput = new KeyboradInput();

        

        void Awake() 
        {
            if(input == null) input = new Input();
            if((inputMask & InputMask.Keyborad) > 0) keyboradInput.init(input);
        }
        private void OnEnable() {
            if(inputMask > 0) input?.Enable();
        }
        private void OnDisable() {
            if(inputMask > 0) input?.Disable();
        }

        private void Update() {
            if((inputMask & InputMask.Keyborad) > 0) keyboradInput.Update();
        }
        
        
    }
}