using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_fimdejogo : MonoBehaviour
{
    public Text message;
    GameManager gm;
    
    void OnEnable()
    {
        gm = GameManager.GetInstance();

        // se no fim do jogo tiver vidas você ganhou 
        if(gm.vidas > 0){
            message.text="Você Ganhouu!!";
        }else{
            message.text="Você Perdeu!!";
        }
    }
    public void Voltar(){
        gm.changeState(GameManager.GameState.GAME);
    }

    
}
