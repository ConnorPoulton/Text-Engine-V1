using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public enum State
    {
        movie,
        gameplay,
        idle,
        init
    }

    private State _state = State.idle;

	// Use this for initialization
	IEnumerable Start ()
    {
        while(true)
        {
            switch (_state)
            {
                case State.movie:
                    break;
                case State.gameplay:
                    break;
                case State.idle:
                    break;
                case State.init:
                    break;
                default:
                    break;
            }
            yield return 0;
        }
		 
	}
	
}
