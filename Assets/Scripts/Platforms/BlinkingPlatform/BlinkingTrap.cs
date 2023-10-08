using UnityEngine;
using PlayerLogic;
using GeneralLogic;
using System.Collections.Generic;
using System.Collections;

namespace Platforms
{
    [RequireComponent(typeof(Renderer))]
    public class BlinkingTrap : MonoBehaviour
    {
        [SerializeField] private float _cooldownTime = 5f;
        [SerializeField] private float _damageDelay = 1f;
        [SerializeField] private float _damage = 10f;
        [SerializeField] private Color _activationColor;
        [SerializeField] private Color _damageColor;

        private bool _isActivated = true;
        private List<IDamageable> _damageables;
        private Renderer _renderer;
        private Color _baseColor;

        private void Awake()
        {
            _damageables = new List<IDamageable>();
            _renderer = GetComponent<Renderer>();
            _baseColor = _renderer.material.color;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (CheckIfDamageable(damageable) && _isActivated)
            {
                _damageables.Add(damageable);
                StartCoroutine("ActivateTrap");
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if(CheckIfDamageable(damageable))
                _damageables.Remove(damageable);
        }

        private bool CheckIfDamageable(IDamageable damageable)
        {
            if (damageable != null)
                return true;
            return false;          
        }

        private IEnumerator ActivateTrap()
        {
            _isActivated = false;
            Blink(_activationColor);
            yield return new WaitForSeconds(_damageDelay);
            ApplyDamage();
            StartCoroutine("ResetTrap");
        }

        private void ApplyDamage()
        {
            Blink(_damageColor);
            foreach(var damageable in _damageables)
            {
                Debug.Log("MakeDamage");
                damageable.GetDamage(_damage);
            }
        }

        private void Blink(Color color)
        {
            StartCoroutine("BlinkRutine", color);
        }

        private IEnumerator BlinkRutine(Color color)
        {
            _renderer.material.color = color;
            yield return new WaitForSeconds(0.5f);
            _renderer.material.color = _baseColor;
        }

        private IEnumerator ResetTrap()
        {
            yield return new WaitForSeconds(_cooldownTime);
            _isActivated = true;
        }
    }
}

