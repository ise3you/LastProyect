using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{

    [Range(2,3)]
    [SerializeField] float rango;
    [SerializeField] int colorIndex;
    //SerializeField] private Image panel;
    [SerializeField] private List<Image> paneles = new List<Image>();
    [SerializeField] private List<Color> colors = new List<Color>();
    
    private int panelIndex;
    private int scena;
    private float time = 0;
    private bool siguientePanel;
  

    private void Update() {
     
        //Cambiar colores de los paneles de manera gradual
        
        paneles[panelIndex].color = Color.Lerp(paneles[panelIndex].color,colors[colorIndex], rango * Time.deltaTime);
        time = Mathf.Lerp(time,1f,rango * Time.deltaTime);
         if(time > 0.9f){
            time = 0;
            colorIndex ++; 
            if(colorIndex >= colors.Count){
                colorIndex = 0;
                siguientePanel = true;
            }else return;
        }

        if(siguientePanel){
            panelIndex ++;
            panelIndex = (panelIndex >= paneles.Count) ? 0 : panelIndex;
            siguientePanel = false;
        }
    }
        

    
    // Empezar el Juego
    public void  Star() {
        scena = 1;
        CambiarScena(scena);
    }

    //Cambiar Scenas
    private void CambiarScena(int scena){
        SceneManager.LoadScene(scena);
    }
    // Termiar el Juego 
    public void Quit(){
        Application.Quit();
    }
 }

