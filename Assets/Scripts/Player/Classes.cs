using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : Player
{
    [SerializeField] Player _player;
    
    
    
    private void SuperPower(int choice)
    {
        switch (choice)
        {
            case 1:
                Time.timeScale = 2f;//SpeedPlayer
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                break;
            case 2:
                Time.timeScale = 0.1f;//SlowPlayer
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                break;
            case 3:

                break;
            default:
                break;
        }
    }
   
    public void OnChoices(int choice)
    {
        SuperPower(choice);
    }
}
