using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisos : MonoBehaviour
{
    private CamaraFollow camaraFollow;

    private void Awake() {
        camaraFollow = GameObject.FindObjectOfType<CamaraFollow>();
        camaraFollow.Floor.Add(this.gameObject);
    }
}
