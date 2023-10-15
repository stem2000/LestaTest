using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace PlayerLogic
{
    [RequireComponent(typeof(IComponentsProvider))]
    public class AnimatorContoller : MonoBehaviour, IInitializableComponent
    {
        [SerializeField] private Animator _animator;

        private float _velocityX;
        private float _velocityZ;
        private IInputProvider _inputProvider;

        private void Update()
        {
            var _playerInput = _inputProvider.GetDirectionInput();
            _velocityX = _playerInput.x;
            _velocityZ = _playerInput.z;
            _animator.SetFloat("VelocityX", _velocityX);
            _animator.SetFloat("VelocityZ", _velocityZ);
        }

        public void Initialize(IComponentsProvider componentsProvider)
        {
            _inputProvider = componentsProvider.GetInputProvider();
        }
    }

}
