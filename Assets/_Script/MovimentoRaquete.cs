using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    [Range(1, 15)]
    public float velocidade = 5.0f;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME)return;

        float inputX = Input.GetAxis("Horizontal");   
        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME){
            gm.changeState(GameManager.GameState.PAUSE);
        }
        
    }
}
