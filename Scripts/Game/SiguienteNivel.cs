using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SiguienteNivel : MonoBehaviour
{
    [SerializeField] Text siguienteNivel;
    [SerializeField] GameObject player;
   private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            siguienteNivel.gameObject.SetActive(true);
            player.GetComponent<Distance>().enabled = false;
        }
   }
}
