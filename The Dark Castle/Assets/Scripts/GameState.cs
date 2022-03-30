using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{
    public enum States
    {
        Playing, Paused, Win, Lose
    }

    public States CurrentState;

    private int killCount;
    int targetKill = 7;
    public int KillCount
    {
        get => killCount;
        set
        {
            killCount = value;
            //Pengecekan kondisi menang
            if (killCount == targetKill && CurrentState == States.Playing)
            {
                CurrentState = States.Win;
            }
        }
    }

    public bool IsPlaying()
    {
        return CurrentState == States.Playing;
    }

    public bool IsWin()
    {
        return CurrentState == States.Win;
    }
  
    public bool IsLose()
    {
        return CurrentState == States.Lose;
    }
    public bool IsPaused()
    {
        return CurrentState == States.Paused;
    }
}
