using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasVerdes : MonoBehaviour
{
   public bool activarPuerta = false;

 [SerializeField] int enterCount ;
  
   private void OnTriggerEnter(Collider other) {
          if(other.gameObject.CompareTag("Player")){
            activarPuerta = true;
            enterCount ++;
            if(enterCount == 4){
                activarPuerta =false;
                enterCount = 0;
            }
        }
   }
}
