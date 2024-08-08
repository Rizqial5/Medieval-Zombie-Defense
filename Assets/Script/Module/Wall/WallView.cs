using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Wall
{
    public class WallView : ObjectView<IWallModel>   
    {

        [SerializeField] int castleHealth;
        [SerializeField] TextMeshProUGUI showCastleHealth;

        public UnityAction onCastleDamage;
        public UnityEvent onHealthDepleted;
        
        protected override void InitRenderModel(IWallModel model)
        {
            showCastleHealth.text = "Castle Health : " + model.castleHealth;
        }

        protected override void UpdateRenderModel(IWallModel model)
        {
            showCastleHealth.text = "Castle Health : " + model.castleHealth;

            if(model.castleHealth <= 0)
            {
                showCastleHealth.text = "Castle Health : " + 0;
            }
        }


        public int CastleHealth() { return castleHealth; }

        


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                print("Kena");

                onCastleDamage.Invoke();

                Destroy(collision.gameObject);
            }
        }

    }
}
