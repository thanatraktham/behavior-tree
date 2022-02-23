using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum State
    {
        Running,
        Failure,
        Success  
    }

    public State state = State.Running;
    public bool started = false;
    public string guid;

    public State Update()
    {
        if(!started)
        {
            Onstart();
            started = true;
        }
        
        state = OnUpdate();

        if(state == State.Failure || state == State.Success)
        {
            Onstop();
            started = false;       
        }

        return state;
    }

    protected abstract void Onstart();
    protected abstract void Onstop();
    protected abstract State OnUpdate();
}
