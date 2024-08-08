using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestAG.Module.Shot
{
    public class ShotModel : BaseModel, IShotMechanic
    {
        private GameObject bullet;
        private Transform spawnPosition;
        private Animator animator;

        public void ShootAction()
        {
            GameObject spawnedBullet = GameObject.Instantiate(bullet, spawnPosition.position, Quaternion.Euler(0, 0, 90));
        }

        public void SetBullet(GameObject prefabBullet)
        {
            bullet = prefabBullet;
            SetDataAsDirty();
        }

        public void SetPosition(Transform spawnPositionTarget)
        {
            spawnPosition = spawnPositionTarget;
            SetDataAsDirty();
        }

        public void SetAnimator(Animator animator)
        {
            this.animator = animator;
        }

        public void PlayAnimation()
        {
            animator.SetTrigger("ShootAnim");
        }
    }
}
