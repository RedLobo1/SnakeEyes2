using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBounce : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float forceStrength = 5f;
    [SerializeField] private float torqueStrength = 5f;
    [SerializeField] private float interval = 1.5f;

    private void Start()
    {
        if (_rb == null)
            _rb = GetComponent<Rigidbody>();

        StartCoroutine(ApplyRandomForcesRoutine());
    }

    private IEnumerator ApplyRandomForcesRoutine()
    {
        while (true)
        {
            ApplyRandomForceAndTorque();
            yield return new WaitForSeconds(interval);
        }
    }

    private void ApplyRandomForceAndTorque()
    {
        Vector3 randomForce = Random.insideUnitSphere * forceStrength;
        Vector3 randomTorque = Random.insideUnitSphere * torqueStrength;

        _rb.AddForce(randomForce, ForceMode.Impulse);
        _rb.AddTorque(randomTorque, ForceMode.Impulse);
    }
}
