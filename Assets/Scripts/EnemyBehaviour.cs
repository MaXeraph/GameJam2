using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Transform _playerTransform;

    private Quaternion _lookRotation;
    private Vector3 _direction;
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = (_playerTransform.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = _lookRotation;

        if (!_cooldown)
        {
            Bullet.Create(transform.position + transform.forward + new Vector3(0, -0.25f, 0), transform.forward, 10f, 5, false);
            _cooldown = true;
            StartCoroutine(Cooldown());
        }
    }
    private bool _cooldown = false;
    private float _cooldownDelay = 1f;

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldownDelay);
        _cooldown = false;
    }
}
