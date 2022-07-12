using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] GameObject targetPlayer;

 
    [Header("Variables")]
    private float velocity;
    int numeroDeVueltas;
    bool puedoJugar;
    bool moverCamara;
    private Distance distance;
    [Header("Lista")]
    public List<GameObject> Floor = new List<GameObject>();
    [Header("Vectores")]
    Vector3 actualPosPlayer;
    Vector3 offset;
    Vector3 sumaDeVectores;
    Vector3 refVector = Vector3.zero;
    private void Start() {  
       StartCoroutine(EmpezarJuego());
    }
    private void Update() {
       
    
        
        if(puedoJugar){
            //if(Camera.main.transform.position <= )
                if(Camera.main.orthographicSize <= 4.5f){
                distance.enabled = true;
                //this.transform.position = targetPlayer.transform.position;
                }    
        }
         //Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize,4,2f * Time.deltaTime);
    }
    private void LateUpdate() {
        if(moverCamara){
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, targetPlayer.transform.position, ref refVector,0.5f,5);
        }
        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize,3, ref velocity,2f );
        
    }
    public void PLay(){
        //Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, targetPlayer.transform.position, ref refVector,2f,7);
        //transform.position = targetPlayer.transform.position;
        moverCamara = true;
        puedoJugar =true;
    }
    IEnumerator EmpezarJuego(){
         distance = GameObject.FindObjectOfType<Distance>();
        distance.enabled = false;    
        foreach (var item in Floor)
        {
            sumaDeVectores += item.transform.position;
            numeroDeVueltas ++;
            if(numeroDeVueltas == Floor.Count){
                sumaDeVectores /= numeroDeVueltas;
            }
        }

        transform.position = sumaDeVectores;
        Camera.main.orthographicSize = 8;
        
        yield return new WaitForSeconds (2);
        PLay();
    }
}
