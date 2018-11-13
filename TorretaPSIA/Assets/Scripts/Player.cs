using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    //Referencias
    public Camera cam;
    public float velocidade;

    NavMeshAgent agenteNav;
    RaycastHit hit;
    Ray ray;

	// Use this for initialization
	void Start () {
        //Pegando meu nav mesh
        agenteNav = GetComponent<NavMeshAgent>();
        //Setando a velocidade do meu nav mesh não é obrigatorio
        agenteNav.speed = velocidade;

    }
	
	// Update is called once per frame
	void Update () {
        //Quando eu clicar no input fire1
        if (Input.GetButtonDown("Fire1"))
        {
            //Irei capturar em uma variavel do tipo ray a posição do meu mouse
            ray = cam.ScreenPointToRay(Input.mousePosition);
            //Solto um raycast baseado na camera
            if(Physics.Raycast(ray, out hit))
            {
                //Falo para o navAgente movimentar até o ponto de colisao do meu rayCast com o chao
                agenteNav.SetDestination(hit.point);
            }
        }
		
	}
}
