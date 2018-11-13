using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorScript : MonoBehaviour {

    //Este script vai no disparador
    //Referencia do projetil
    public GameObject projetil;
	// Meu void start virou uma corountine que sempre ficara executando
	IEnumerator Start () {
        yield return new WaitForSeconds(1.5f);
        //Verifico se posso atirar
        if (TorretaRotation.atirar) {
            //Aqui vem o pulo do gato falo que minha posicao de spawn vai ter 0.2F a mais na altura para o raycast nao perde a visao do player
            Vector3 SpawnPosition = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            //Instancio o projetil
            Instantiate(projetil, SpawnPosition, transform.rotation);
        }
        StartCoroutine(Start());
	}
	

}
