using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaEspecial : MonoBehaviour
{
    public int llaveEspecial;
    public bool abrirPuerta;
    private void Update() {
        LimiteDePuertas(this.gameObject);
        if(abrirPuerta){
            transform.Translate(Vector3.down * 0.5f * Time.deltaTime,Space.World);
        }
    }
    public void BajarPuertaEspecial(){
            abrirPuerta = true;
    }

     void LimiteDePuertas(GameObject P){
         P.transform.position = new Vector3(P.transform.position.x,Mathf.Clamp(P.transform.position.y,-2.5f,0),P.transform.position.z);
    }
    
}
