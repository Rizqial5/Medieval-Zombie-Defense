using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Character
{
    public class CharacterView : BaseView
    {
        [SerializeField] Transform[] positionList;
        [SerializeField] GameObject bullet;
        [SerializeField] Animator animator;

        private int playerPositionIndex;

        public UnityEvent onUpdate;

       

        private void Update()
        {
            onUpdate.Invoke();

            
        }

        public GameObject SetPlayer()
        {
            return this.gameObject;

            
        }

        public Transform[] SetPositionList() { return positionList; }
        public GameObject SetBullet() {return bullet;}
        public Animator SetAnimator() {return animator;}
    }
}
