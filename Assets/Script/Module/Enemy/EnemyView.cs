using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Enemy
{
    public class EnemyView : ObjectView<IEnemyModel>
    {
        

        public UnityEvent onPhysicsUpdate;
        public UnityEvent onEnemyDie;

        private float speed;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        protected override void InitRenderModel(IEnemyModel model)
        {
            speed = model.enemySpeed;
        }

        protected override void UpdateRenderModel(IEnemyModel model)
        {
            speed = model.enemySpeed;
        }


        private void FixedUpdate()
        {
            
            

            rb.MovePosition(transform.position + Vector3.down * speed * Time.fixedDeltaTime);

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                onEnemyDie.Invoke();
            }
        }

        
    }
}
