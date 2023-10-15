using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLogic
{
    [RequireComponent(typeof(IInitializableComponent))]
    public class Rotation : MonoBehaviour, IInitializableComponent
    {
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private float _mouseSense;

        private IInputProvider _inputProvider;
        private float _xRotation;
        private float _yRotation;


        public void FixedUpdate()
        {
            var mouseDelta = _inputProvider.GetMouseDeltaInput();

            _yRotation += mouseDelta.x * Time.deltaTime * _mouseSense;

            _xRotation -= mouseDelta.y * Time.deltaTime * _mouseSense;
            _xRotation = Mathf.Clamp(_xRotation, -45f, 90f);

            transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
            _cameraTarget.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        }

        public void Initialize(IComponentsProvider componentsProvider)
        {
            _inputProvider = componentsProvider.GetInputProvider();
        }

    }
}

