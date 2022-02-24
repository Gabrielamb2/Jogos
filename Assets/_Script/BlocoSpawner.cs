using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    public GameObject Bloco;
    GameManager gm;
    // private AudioSource block_sound;
    // Start is called before the first frame update
    void Start()
    {
        // block_sound = GetComponent<AudioSource>();
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
        
        
    }
    void Construir(){
        if(gm.gameState == GameManager.GameState.GAME){
            foreach(Transform child in transform){
                GameObject.Destroy(child.gameObject);
                // block_sound.Play();
            }
            for(int i=0; i<12;i++){
                for(int j=0; j<4;j++){
                    Vector3 posicao = new Vector3(-9 + 1.55f * i , 4-0.55f * j);
                    Instantiate(Bloco,posicao,Quaternion.identity,transform);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //se não tiver mais blocos quer dizer que acabou
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME){
            gm.changeState(GameManager.GameState.ENDGAME);
        }
    }
}
