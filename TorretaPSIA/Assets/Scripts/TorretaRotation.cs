using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaRotation : MonoBehaviour {

    //Variaveis para rotacionar e pegar referencias do disparador
    public Transform disparador;
    public float limiteRotacao;
    public float limiteDistancia;
    public float velocidadeRotacao;

    //RayCast para verificar no que esta batendo
    Ray ray;
    RaycastHit hit;
    //Usado para verificar situações do jogo
    private float rotacaoAtual;
    public static bool atirar;
    Vector3 front;
	void Update () {
        //Irei ter um Vector3 Com minha referencia necessaria para o RayCastGirar junto
        front = disparador.transform.TransformDirection(Vector3.forward) * limiteDistancia;
        //Desenhando o RayCast
        Debug.DrawRay(disparador.transform.position, front, Color.red);
        //Fazendo a fisica do RayCast
        if(Physics.Raycast(disparador.transform.position,front,out hit))
        {
            //Se ele colidir com meu player
            if (hit.collider.CompareTag("Player"))
            {
                //Minha torreta pode atirar e parar de rotacionar
                atirar = true;
                //Agora coloco a orientacao para o o transform do objeto que estou batendo no raycast
                transform.LookAt(hit.collider.gameObject.transform);
            }
            //Se eu nao bati no player, nao estou batendo em nada
            else
            {
                //Desligo a condicao
                atirar = false;
                print("Desliguei o atirar: " + atirar);
            }
        }
        //Desligando a condicao de se o ray cast bater em algo, somente por seguranca
        else
        {
            atirar = false;
            print("Desliguei o atirar: " + atirar);
        }

        //Se eu nao estou atirando logo posso rotacionar
        if (!atirar)
        {
            //Minha rotacao atual vai ser sempre + minha velocidade
            rotacaoAtual += velocidadeRotacao;
            //Rotaciono minha torreta somente no eixoY passando a minha rotacao atual
            transform.eulerAngles = new Vector3(0.0f, rotacaoAtual, 0.0f);
            //Aqui vou fazer o limitador De Rotacao com a biblioteca MathF.Abs
            if (Mathf.Abs(rotacaoAtual) >= limiteRotacao)
            {
                //Fazendo a rotação voltar ao eixo oposto sempre
                velocidadeRotacao *= -1;
            }
        }
        
    }
}
