using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHModule.Charactere
{
    public class CharacterController : SingletonManager<CharacterController>
    {
        [Header("For Move Property")]
        [SerializeField] SpeedProperty speedProperty = new SpeedProperty();


        /// initialize characterController
        protected override void Awake() {
            base.Awake();
            speedProperty.init();
        }

        
        public void updateMovePlayer(Vector2 direction)
        {
            transform.Translate(new Vector3(direction.x, 0, direction.y) * TimeProperty.runtime_DeltaTime * speedProperty.speed);
        }

    }
}