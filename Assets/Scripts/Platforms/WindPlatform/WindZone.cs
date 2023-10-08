using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platforms
{
    public class WindZone : MonoBehaviour
    {
        [SerializeField] private float _changeDirectionCooldown = 2f;
        [SerializeField] private float _windForce = 1f;

        private Vector3 _windDirection;
        private List<Rigidbody> _bodies;
        private bool _isActivated = true;

        private void Awake()
        {
            _bodies = new List<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_isActivated)
                StartCoroutine("SetWindDirection");
            AddWindForce();
        }

        private void OnTriggerEnter(Collider collision)
        {
            var body = collision.gameObject.GetComponent<Rigidbody>();

            if (body != null)
                _bodies.Add(body);
        }

        private void OnTriggerExit(Collider collision)
        {
            var body = collision.gameObject.GetComponent<Rigidbody>();

            if (body != null)
                _bodies.Remove(body);
        }

        private IEnumerator SetWindDirection()
        {
            _isActivated = false;
            _windDirection.x = Random.Range(Random.Range(-1f, -0.5f), Random.Range(0.5f, 1f));
            _windDirection.z = Random.Range(Random.Range(-1f, -0.5f), Random.Range(0.5f, 1f));
            yield return new WaitForSeconds(_changeDirectionCooldown);
            _isActivated = true;
        }

        private void AddWindForce()
        {
            foreach (var body in _bodies)
            {
                body.AddForce(_windDirection.normalized * _windForce, ForceMode.VelocityChange);
            }
        }
    }
}

