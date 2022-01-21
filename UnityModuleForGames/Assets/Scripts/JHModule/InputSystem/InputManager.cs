using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JHModule.InputSystem
{
    using Events;

    [System.Flags, System.Serializable] enum InputMask : int
    {
        Player = 0x00000001,
        UI = 0x00000002,

    }
    [System.Serializable] public class PlayerInput
    {
        // state from MouseDown
        public static bool isMouseDown {get; private set;} = false;

        [Header("Move Key Event")]
        public UnityVector2Event MoveKeyAction;
        
        [Header("Fire Key Event(true = key Down\false = key Up)")]
        public UnityBoolEvent FireAction;
        [Header("Mouse Delta Event")]
        public UnityVector2Event MouseDeltaAction;
        [Header("Mouse Position Event")]
        public UnityVector2Event MousePositionAction;

        // 이동 키보드 상태
        Vector2 m_movekeyStatus = Vector2.zero;
        // 이동 키보드 누름 상태
        bool m_ismovekeyDown = false;
        public Vector2 MousePosition {get; private set;} = Vector2.zero;

        /// player input initialized
        public void Awake(Jin_H_Input input)
        {
            Debug.Log("player Input Initialized");
            // Move Event init
            input.Player.Move.performed -= performedEvent_MoveKey;
            input.Player.Move.performed += performedEvent_MoveKey;
            input.Player.Move.canceled -= cancleEvent_MoveKey;
            input.Player.Move.canceled += cancleEvent_MoveKey;
            // Fire Event init
            input.Player.Fire.performed -= performedEvent_Fire;
            input.Player.Fire.performed += performedEvent_Fire;
            input.Player.Fire.canceled -= cancleEvent_Fire;
            input.Player.Fire.canceled += cancleEvent_Fire;
            // MousePosition
            input.Player.MousePosition.performed -= performedEvent_MousePosition;
            input.Player.MousePosition.performed += performedEvent_MousePosition;
            // MouseDelta
            input.Player.MouseDelta.performed -= performedEvent_MouseDelta;
            input.Player.MouseDelta.performed += performedEvent_MouseDelta;
        }
        public void Update() 
        {
            if(m_ismovekeyDown) MoveKeyAction?.Invoke(m_movekeyStatus);
        }
        /// player input destroy
        public void OnDestroy(Jin_H_Input input)
        {
            // Move
            input.Player.Move.performed -= performedEvent_MoveKey;
            input.Player.Move.canceled -= cancleEvent_MoveKey;
            // Fire
            input.Player.Fire.performed -= performedEvent_Fire;
            input.Player.Fire.canceled -= cancleEvent_Fire;
            // Look
            input.Player.MousePosition.performed -= performedEvent_MousePosition;
            // MouseDelta
            input.Player.MouseDelta.performed -= performedEvent_MouseDelta;
        }
        /// Move Key delegate
        private void performedEvent_MoveKey(UnityEngine.InputSystem.InputAction.CallbackContext caltex)
        {
            m_movekeyStatus = caltex.ReadValue<Vector2>();
            m_ismovekeyDown = true;
        }
        private void cancleEvent_MoveKey(UnityEngine.InputSystem.InputAction.CallbackContext caltex)
        
        {
            m_ismovekeyDown = false;
            m_movekeyStatus = Vector2.zero;
            MoveKeyAction?.Invoke(Vector2.zero);
        }
        /// fire key delegate
        private void performedEvent_Fire(UnityEngine.InputSystem.InputAction.CallbackContext caltex)
        {
            isMouseDown = true;
            FireAction?.Invoke(isMouseDown);
        }
        private void cancleEvent_Fire(UnityEngine.InputSystem.InputAction.CallbackContext caltex)
        {
            isMouseDown = false;
            FireAction?.Invoke(isMouseDown);
        }
        /// Mouse position delegate
        private void performedEvent_MousePosition(UnityEngine.InputSystem.InputAction.CallbackContext caltex)
        {
            MousePosition = caltex.ReadValue<Vector2>();
            MousePositionAction?.Invoke(MousePosition);
        }
        /// Mouse Delta delegate
        private void performedEvent_MouseDelta(UnityEngine.InputSystem.InputAction.CallbackContext caltex)
        {
            MouseDeltaAction?.Invoke(caltex.ReadValue<Vector2>());
        }
    }
    
    [System.Serializable] public class InputManager
    {
        /// position from mouse
        public static Vector2 MousePosition { get { return Manager.inputManager.playerInput.MousePosition; } }
        /// ray from targetCamera to mouseScreenPoint
        public static Ray GetMouseRayPoint(Camera targetCamera)
        {
            return targetCamera.ScreenPointToRay(MousePosition);
        }
        [SerializeField] InputMask inputMask = new InputMask();
        Jin_H_Input input = null;
        [SerializeField] PlayerInput playerInput = new PlayerInput();

        public void Awake() 
        {
            if(input == null) input = new Jin_H_Input();
            if((inputMask & InputMask.Player) > 0) playerInput.Awake(input);
        }
        public void OnEnable() {
            if((inputMask) != 0) 
            {
                Debug.Log("Enable player input");
                input?.Enable();
            }
        }
        public void OnDisable() {
            if(inputMask != 0){
                Debug.Log("Disable player input");
                input?.Disable();
            } 
        }

        public void Update() {
            if((inputMask & InputMask.Player) > 0) playerInput.Update();
        }

        public void OnDestroy()
        {
            if((inputMask & InputMask.Player) > 0) playerInput.OnDestroy(input);
            input = null;
        }
    }
}