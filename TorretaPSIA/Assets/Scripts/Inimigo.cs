using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

    public float velocidade;
    public float distVisao;
    public GameObject alvo;

    private Vector3 posicaoInicial;

    public bool patrulhar, retornar, perseguir;
	void Start () {
        posicaoInicial = transform.position;
	}
	
	void Update () {
        float d = Vector3.Distance(transform.position, alvo.transform.position);
        if(d < distVisao)
        {
            //Posso perseguir
            transform.position = Vector3.Lerp(transform.position, alvo.transform.position, Mathf.Abs(velocidade) * Time.deltaTime);
            retornar = true;
        }
        else
        {
            if (!retornar)
            {
                //Posso Patrulhar
                transform.Translate(Vector3.left * velocidade * Time.deltaTime);
                if (transform.position.x < posicaoInicial.x -5f|| transform.position.x > posicaoInicial.x +5f)
                {
                    velocidade *= -1;
                }
            }
            else
            {
                //Posso Retornar
                transform.position = Vector3.Lerp(transform.position, posicaoInicial, Mathf.Abs(velocidade) * Time.deltaTime);
                if(Vector3.Distance(transform.position , posicaoInicial) < 0.1f)
                {
                    retornar = false;
                }
            }
            retornar = false;
        }
	}
}
