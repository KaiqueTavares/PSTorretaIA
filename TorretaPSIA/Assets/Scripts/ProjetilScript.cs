using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour {

    //Referencias
    public float velocidade;
    public float tempoVida;

	// Use this for initialization
	void Start () {
        //Destroi o objeto depois de X tempo de vida
        Destroy(gameObject, tempoVida);
	}
	
	// Update is called once per frame
	void Update () {
        //Fazendo meu projetil Andar no eixo de frente
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
	}
    //Quando ele colidir com qualquer coisa
    private void OnCollisionEnter(Collision collision)
    {
        //Destruo ele.
        Destroy(gameObject);
    }
}
