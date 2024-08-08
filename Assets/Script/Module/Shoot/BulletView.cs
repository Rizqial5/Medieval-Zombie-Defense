using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestAG.Module.Shot
{
    public class BulletView : BaseView
    {
        private Rigidbody2D _bullet;

        [SerializeField] private float _speed;

        private void Awake()
        {
            _bullet = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            _bullet.MovePosition(transform.position + Vector3.up * _speed * Time.fixedDeltaTime);

            Destroy(gameObject, 2.5f);
        }

        
    }
}
