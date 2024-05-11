using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public List<GameObject> Levels = new List<GameObject>();

    public int CurrentLevelIndex = 0;

    public bool isTransition = false;
    public float transitionFactor = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Levels[CurrentLevelIndex].transform.position + new Vector3(0,0,-10), transitionFactor * Time.deltaTime);
    }

    public void ProceedNextLevel(int newCurrentLevelIndex)
    {
        CurrentLevelIndex = newCurrentLevelIndex;

        if (CurrentLevelIndex >= Levels.Count)
        {
            //game over
        }
        else
        {
            isTransition = true;
        }

    }
}
