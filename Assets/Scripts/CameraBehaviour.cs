using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CameraBehaviour : MonoBehaviour
{
    public List<GameObject> Levels = new List<GameObject>();

    public GameObject BackGround1;
    public GameObject BackGround2;

    public int CurrentLevelIndex = 0;

    public bool isTransition = false;
    public float transitionFactor = 10f;

    public GameObject HellParticle;
    public GameObject SandParticle;
    public GameObject IceParticle;

    public static int CheckPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        ProceedNextLevel(CheckPoint);
        GameObject.Find("character").transform.position = Levels[CheckPoint].transform.Find("playerSpawnPoint").transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Levels[CurrentLevelIndex].transform.position + new Vector3(0,0,-10), transitionFactor * Time.deltaTime);

        if(CurrentLevelIndex <= 3)
        {
            BackGround1.transform.position = transform.position + new Vector3(0, 0, 10);
        }
        if(CurrentLevelIndex == 11)
        {
            //
        }

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10f);
        Debug.Log(worldPosition);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(HellParticle, worldPosition, new Quaternion(), null);
            GameObject.Find("TileMapController").GetComponent<TileMapController>().
                ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(worldPosition.x * 2), Mathf.FloorToInt(worldPosition.y * 2), Mathf.FloorToInt(worldPosition.z)), TileMapController.CardType.Hell);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(IceParticle, worldPosition, new Quaternion(), null);
            GameObject.Find("TileMapController").GetComponent<TileMapController>().
                ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(worldPosition.x * 2), Mathf.FloorToInt(worldPosition.y * 2), Mathf.FloorToInt(worldPosition.z)), TileMapController.CardType.Ice);
        }
        if (Input.GetMouseButtonDown(2))
        {
            Instantiate(SandParticle, worldPosition, new Quaternion(), null);
            GameObject.Find("TileMapController").GetComponent<TileMapController>().
                ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(worldPosition.x * 2), Mathf.FloorToInt(worldPosition.y * 2), Mathf.FloorToInt(worldPosition.z)), TileMapController.CardType.Sand);
        }
    }
    public void RestartLevel()
    {
        int levelIndex = CurrentLevelIndex;
        SceneManager.LoadScene("Main", LoadSceneMode.Single);

        CurrentLevelIndex = levelIndex;
        CheckPoint = levelIndex;
    }

    public void ProceedNextLevel(int newCurrentLevelIndex)
    {
        CurrentLevelIndex = newCurrentLevelIndex;

        if(newCurrentLevelIndex > CheckPoint)
        {
            CheckPoint = newCurrentLevelIndex;
        }

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
