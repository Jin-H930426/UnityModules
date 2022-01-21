using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule.Charactere
{
    public class CharacterController : MonoBehaviour
    {
        [Header("For Move Property")]
        [SerializeField] SpeedProperty speedProperty = new SpeedProperty();


        /// initialize characterController
        private void Awake() {
            speedProperty.init();
        }

        public void updateMovePlayer_2D(UnityEngine.InputSystem.InputAction.CallbackContext tex)
        {
            updateMovePlayer_2D(tex.ReadValue<Vector2>());
        }
        public void updateMovePlayer_2D(Vector2 direction)
        {
            transform.Translate(direction * TimeProperty.runtime_DeltaTime * speedProperty.speed);
        }
        public void updateMovePlayer_sideScrolling(UnityEngine.InputSystem.InputAction.CallbackContext tex)
        {
            updateMovePlayer_sideScrolling(tex.ReadValue<Vector2>());
        }
        public void updateMovePlayer_sideScrolling(Vector2 direction)
        {
            transform.Translate(new Vector3(direction.x, 0, 0) * TimeProperty.runtime_DeltaTime * speedProperty.speed);
        }
        public void updateMovePlayer_3D(UnityEngine.InputSystem.InputAction.CallbackContext tex)
        {
            updateMovePlayer_3D(tex.ReadValue<Vector2>());
        }
        public void updateMovePlayer_3D(Vector2 direction)
        {
            transform.Translate(new Vector3(direction.x, 0, direction.y) * TimeProperty.runtime_DeltaTime * speedProperty.speed);
        }

    }
}