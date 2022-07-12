using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLaveEspecial : MonoBehaviour
{
   [SerializeField] Distance distance;
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject){
            distance = GameObject.FindObjectOfType<Distance>();
            distance.llaveEspecialRecogidas ++; 
            Destroy(gameObject);
        }
    }
}
