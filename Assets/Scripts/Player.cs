using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject _bulletPrefab;

    private Rigidbody2D _rigidbody2d;

    [SerializeField]
    private Camera _camera;

    private Vector2 _mousePosition;
    private Vector2 _randomForce;

    private void Start() {
        _rigidbody2d = GetComponent<Rigidbody2D>();

        InvokeRepeating("AddRandomForceToPlayer", 1f, 2f);
    }

    void Update() {
        ShootBullet();

        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        HandleRotation();
    }

    void ShootBullet() {
        if (Input.GetButtonDown("Fire1")) {
            GameObject newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity) as GameObject;

            Rigidbody2D bulletRigibody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigibody.AddForce(transform.up * 10f, ForceMode2D.Impulse);

            _rigidbody2d.AddForce(transform.up * -1f, ForceMode2D.Impulse);

            Destroy(newBullet, 2f);
        }
    }

    void HandleRotation() {
        Vector2 lookDirection = _mousePosition - _rigidbody2d.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidbody2d.rotation = angle;
    }

    void AddRandomForceToPlayer() {
        _randomForce = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        _rigidbody2d.AddForce(_randomForce, ForceMode2D.Impulse);
    }
}
