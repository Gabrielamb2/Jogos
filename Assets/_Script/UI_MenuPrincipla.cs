using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuPrincipla : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;
    private void OnEnable(){
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    public void Comecar()
    {
        gm.changeState(GameManager.GameState.GAME);
        
    }
}
