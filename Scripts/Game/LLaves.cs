using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLaves : MonoBehaviour
{
    [SerializeField] Distance distance;
    
    private void Start() {
        distance = GameObject.FindObjectOfType<Distance>();
        distance.llavesList.Add(GetComponent<LLaves>());
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject){
            distance.llavesRecogidas ++;
            distance.llavesText.text = "Keys " + distance.llavesRecogidas;
            
            for (var i = 0; i < distance.llavesList.Count; i++)
            {
                if(distance.llavesList[i].gameObject.name == this.gameObject.name){
                    distance.llavesList.Remove(distance.llavesList[i]); 
                }
            }
            Destroy(gameObject);
        }
    }
}
