using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPuertas : MonoBehaviour
{
    //Mover puertas verdes
   [SerializeField] private PuertasVerdes puertasVerdes;
   
   [SerializeField] GameObject puerta1;
   [SerializeField] GameObject puerta2;
   [SerializeField] float limiteY = 0;
   [SerializeField] float limiteNegativoY = 2.5f;

   private void Start() {
    puertasVerdes = GameObject.FindObjectOfType<PuertasVerdes>();
   }


   private void Update() {
        LimiteDePuertas(puerta1);
        LimiteDePuertas(puerta2);

        BajarPuerta_SubirPuerta(puerta1,puerta2);
        
       
   }
    void LimiteDePuertas(GameObject P){
     P.transform.position = new Vector3(P.transform.position.x,Mathf.Clamp(P.transform.position.y,-limiteNegativoY,limiteY),P.transform.position.z);

    }
   void BajarPuerta_SubirPuerta(GameObject P,GameObject P2){
        if(puertasVerdes.activarPuerta){
            Vector3 vector= Vector3.down;
            if(P.transform.position.y <= -limiteNegativoY){
                vector = Vector3.zero;
            }
            P.transform.Translate(vector * 0.5f * Time.deltaTime,Space.World);
            //======================================================================//
            Vector3 vector1 = Vector3.up;
             if(P2.transform.position.y >= limiteY){
                vector1 = Vector3.zero;
            }
            P2.transform.Translate(vector1 * 0.5f * Time.deltaTime,Space.World);

        }else if(!puertasVerdes.activarPuerta)
        {
            Vector3 vector = Vector3.up;
             if(P.transform.position.y >= limiteY){
                vector = Vector3.zero;
            }
            P.transform.Translate(vector * 0.5f * Time.deltaTime,Space.World);
            //=====================================================================//
            Vector3 vector1 = Vector3.down;
              if(P2.transform.position.y <= -limiteNegativoY){
                vector1 = Vector3.zero;
            }
            P2.transform.Translate(vector1 * 0.5f * Time.deltaTime,Space.World);
           
        }
   }
}
