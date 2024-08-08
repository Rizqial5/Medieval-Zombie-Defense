using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestAG.Module.Character
{
    public class CharacterModule : BaseModel
    {
        public int playerPositionIndex {  get; private set; }

        public GameObject character {  get;  set; }



        public void CharacterMover( Transform[] positionObject)
        {
            character.transform.position = positionObject[playerPositionIndex].position;
        }

        public void SetPosisionIndex()
        {
            playerPositionIndex = 0;
        }

        public void AddPositionIndex()
        {

            playerPositionIndex += 1;

            if (playerPositionIndex > 2)
            {
                playerPositionIndex = 0;
                return;
            }

            
            SetDataAsDirty();
        }

        public void DecreasePositionIndex()
        {
            playerPositionIndex -= 1;

            if (playerPositionIndex < 0)
            { 
                playerPositionIndex = 2;
                return;
            } 

           
            SetDataAsDirty();
        }

        
    }
}
