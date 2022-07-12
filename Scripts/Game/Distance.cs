using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Distance : MonoBehaviour
{
    [Header("Variables")]
    public float velocidadPlayer;
    public int llavesRecogidas;
    public int llaveEspecialRecogidas;
    [Header("Layers")]
    [SerializeField] private LayerMask mask;
    Vector3 Pos = Vector3.zero;
    Vector3 Vector = Vector3.zero;
    RaycastHit hit;
    private bool puedoMoverme = true;
    private Rigidbody playerRB;
    [Space(1)]
    public List<Puertas> puertas = new List<Puertas>();
    
    [SerializeField] private GameObject puertaEspecial;
    [SerializeField] private GameObject panel;
    public Text puertaMensaje;
    public Text LLaveEspecialText;
    [SerializeField] private int puertaActual;
    private bool abrir;
    public Text llavesText;

    public List<LLaves> llavesList = new List<LLaves>();

    
    // Start is called before the first frame update
    void Start()
    {
        playerRB= GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {

        llavesText.text = llavesRecogidas + "/" + llavesList.Count ; 
        LLaveEspecialText.text = llaveEspecialRecogidas + "/" + 1;

        //Limite de llaves a recoger 
        llaveEspecialRecogidas = Mathf.Clamp(llaveEspecialRecogidas,0,1);

   if(puedoMoverme){

          if(Input.GetKeyDown(KeyCode.A)){
                Vector = Vector3.left;
                puedoMoverme = false;
            }
          if(Input.GetKeyDown(KeyCode.W)){
                Vector = Vector3.forward;
                puedoMoverme = false;
            }
            if(Input.GetKeyDown(KeyCode.D)){
                Vector = Vector3.right;
                puedoMoverme = false;
            }
            if(Input.GetKeyDown(KeyCode.S)){
                Vector = Vector3.back;
                puedoMoverme = false;
            }
    }            

            Ray(Vector);     
            Move(Vector);
            
    }

    private void FixedUpdate() {
        //Move(Vector);
    }

    void Ray(Vector3 vector){
        if(Physics.Raycast(transform.position,vector,out hit,Mathf.Infinity,mask)){
            Debug.Log(" La distancia es" + hit.distance);
            Debug.DrawRay(transform.position, Vector * hit.distance,Color.red);
            panel.gameObject.SetActive(false);
            //Detener al jugador
            if(hit.distance <= 1){
            Debug.DrawRay(transform.position, Vector * hit.distance,Color.green);
                Vector = Vector3.zero;
                puedoMoverme =true;
                Busqueda();
                AbrirPuertaEspecial();
            }
          
        }
    }
    void Move(Vector3 vector){
           //playerRB.velocity = vector * velocidadPlayer;
           this.transform.Translate(vector * velocidadPlayer * Time.deltaTime,Space.World);
    }
    void Busqueda(){
        if(hit.transform.gameObject.CompareTag("Puerta")){
                    for (var i = 0; i < puertas.Count; i++)
                    {
                        if(hit.transform.gameObject.name == puertas[i].gameObject.name){
                            puertaActual = i;
                            panel.gameObject.SetActive(true);
                            puertaMensaje.text = " Se necesita " + puertas[i].numeroDeLLaves + " de llaves para abrir esta puerta";
                            //Debug.Log("Esta en una puerta" +  puertas[i].numeroDeLLaves);
                           
                            break;
                        }
                    }
                }
    }

    //comportamiento de puerta especial
    void AbrirPuertaEspecial(){
         if(hit.transform.gameObject == puertaEspecial){
                    
                    if(llaveEspecialRecogidas == puertaEspecial.GetComponent<PuertaEspecial>().llaveEspecial){
                        Debug.Log("Abrir puerta especial");
                        puertaEspecial.GetComponent<PuertaEspecial>().BajarPuertaEspecial();
                        llaveEspecialRecogidas --;
                    }else 
                    {
                        panel.gameObject.SetActive(true);
                        puertaMensaje.text = " Se necesita una llave especial para pasar abrrir esta puerta";
                    }
                    //Debug.Log("Necesito " + puertaEspecial.GetComponent<PuertaEspecial>().llaveEspecial);
                }
    }


    public void BajarPuerta(){
        
        for (var i = 0; i < puertas.Count; i++)
        {
            if(i == puertaActual && puertas[i].numeroDeLLaves == llavesRecogidas){
                puertas[i].BajarPuerta();
                llavesRecogidas --;
                break;
            }
            else
            {
                Debug.Log("Numero e llaves insuficientes");
            }
        }
    }

   
    
    
}
