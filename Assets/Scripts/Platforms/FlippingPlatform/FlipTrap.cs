using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlipTrap : MonoBehaviour
{
    [SerializeField] private float _flipForce = 5f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddRelativeTorque(Random.rotation.eulerAngles.normalized * _flipForce, ForceMode.Impulse);
    }
}
