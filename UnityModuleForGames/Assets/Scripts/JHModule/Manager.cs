using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule
{
    /// Component for Game with controll
    public class Manager : SingletonManager<Manager> 
    {
        #region  Static Area
        public static Resource.ResourcesManager resourcesManager { get { return singleton.m_resourcesManager; } }
        public static InputSystem.InputManager inputManager { get { return singleton.m_inputManager; } }
        #endregion

        [Header("Manager Property")]
        [Tooltip("Resources Manager Property"), SerializeField] Resource.ResourcesManager m_resourcesManager = new Resource.ResourcesManager();
        [Tooltip("InputManager Property"), SerializeField] InputSystem.InputManager m_inputManager = new InputSystem.InputManager();


        protected override void Awake() {
            base.Awake();

            m_resourcesManager.Awake();
            m_inputManager.Awake();
        }
        private void OnEnable() {
            m_inputManager.OnEnable();
        }
        private void OnDisable() {
            m_inputManager.OnDisable();
        }
        protected override void OnDestroy() {
            
            m_resourcesManager.OnDestroy();
            m_inputManager.OnDestroy();
            base.OnDestroy();
        }
        
        private void Update() {
            m_inputManager.Update();

            #region  UnityEditor
            #if UNITY_EDITOR
            EditorUpdate();
            #endif
            #endregion
        }



        #region  Unity Editor
        #if UNITY_EDITOR
        [Header("-------------Unity Editor-------------"),Space(20)]
        [SerializeField, Range(1, 4)] float runtime_TimeScale = 1;
        [SerializeField, Range(1, 4)] float ui_TimeScale = 1;
        
        private void EditorUpdate() {
            TimeProperty.runtime_TimeScale = runtime_TimeScale;
            TimeProperty.ui_TimeScale = ui_TimeScale;
        }
        #endif
        #endregion
    }
}