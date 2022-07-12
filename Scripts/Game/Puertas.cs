using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public int numeroDeLLaves;
    public int llaveEspecial = 0;
    private Distance distance;

    public Animator animator;
    private bool bajarPuerta;
    private void Start() {

        distance = GameObject.FindObjectOfType<Distance>();
        distance.puertas.Add(GetComponent<Puertas>());
    }
 
    private void Update() {
        LimiteDePuertas(this.gameObject);
        if(bajarPuerta){
            transform.Translate(Vector3.down * 0.5f * Time.deltaTime,Space.World);
        }
    }
    public void BajarPuerta(){
        bajarPuerta= true;
    }

     void LimiteDePuertas(GameObject P){
         P.transform.position = new Vector3(P.transform.position.x,Mathf.Clamp(P.transform.position.y,-2.5f,0),P.transform.position.z);
    }
    

}
