using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1, 15)]
    public float velocidade = 5.0f;

    private Vector3 direcao;

    GameManager gm;

    private AudioSource ball_sound;

    // Start is called before the first frame update
    void Start()
    {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;

        gm = GameManager.GetInstance();

        ball_sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME)return;
        transform.position += direcao * Time.deltaTime * velocidade;
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        if(posicaoViewport.x <0 || posicaoViewport.x > 1){
            direcao = new Vector3(-direcao.x,direcao.y);
        }if(posicaoViewport.y > 1){ 
            direcao = new Vector3(direcao.x,-direcao.y);
        }if(posicaoViewport.y < 0){ //bateu no fundo
            Reset();
        }
        //Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");
        
    }
    private void Reset(){

        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition + new Vector3(0, 0.5f, 0);

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);
        direcao = new Vector3(dirX, dirY).normalized;


        gm.vidas--; //tirar vidas

        //checar se as vidas acabaram
        if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME){
            gm.changeState(GameManager.GameState.ENDGAME);
        }
    }
    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.CompareTag("Player")){
            float dirX = Random.Range(-5.0f,5.0f);
            float dirY = Random.Range(1.0f,5.0f);
            ball_sound.Play();
            direcao = new Vector3(dirX,dirY).normalized;
        }
        else if(col.gameObject.CompareTag("Tijolo")){
            direcao = new Vector3(direcao.x,-direcao.y);
            gm.pontos++;
        }
        

    }

}
