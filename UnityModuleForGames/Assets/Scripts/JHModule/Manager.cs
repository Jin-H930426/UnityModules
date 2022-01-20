using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule
{
    /// Component for Game with controll
    public class Manager : SingletonManager<Manager> 
    {
        #region  Unity Editor
        #if UNITY_EDITOR
        [SerializeField, Range(1, 4)] float runtime_TimeScale = 1;
        [SerializeField, Range(1, 4)] float ui_TimeScale = 1;
        
        private void EditorUpdate() {
            TimeProperty.runtime_TimeScale = runtime_TimeScale;
            TimeProperty.ui_TimeScale = ui_TimeScale;
        }
        #endif
        #endregion
        public InputSystem.InputManager inputManager;
        
        protected override void Awake() {
            base.Awake();
            if(!inputManager) inputManager = GetComponentInChildren<InputSystem.InputManager>();
        }

        private void Update() {
            #region  UnityEditor
            #if UNITY_EDITOR
            EditorUpdate();
            #endif
            #endregion
        }

    }
}