using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DangerousCube : MonoBehaviour {    
    public static float delay;
    public GameObject cube;
    private static int cubesDodged;
    private static int winScore = 50;
    private static bool winGame;
    private static bool lostGame;
    private static float timeFlow = 0f;
    private static bool firstLoad = true;
    GameObject[] menu;

	// Use this for initialization
	void Start () {
        menu = GameObject.FindGameObjectsWithTag("Menu");        
        
        //First run game paused.
        if (firstLoad)
        {
            ShowGameMenu();
            SearchGameObject("EntryText").SetActive(true);
            firstLoad = false;
        }
        else
        {
            foreach (var item in menu)
                item.SetActive(false);
        }
        if (delay == 0f)
            delay = 0.1f;
        cubesDodged = 0;
        winGame = false;
        lostGame = false;
        Time.timeScale = timeFlow;
        InvokeRepeating("Spawn", delay, delay);
                
	}
	
    void Update ()
    {
        if (!lostGame && !winGame)
            GameObject.Find("ScoreLabel").GetComponent<Text>().text = "Score: " + cubesDodged.ToString() + " / " + winScore.ToString();     
        //Game lost condition
        if (!GameObject.Find("Sphere") && !lostGame)
        {
            ShowGameMenu();
            SearchGameObject("FailText").SetActive(true);
            CancelInvoke();
            lostGame = true;
        }
        //Game won condition
        if (cubesDodged >= winScore && !winGame)
        {
            ShowGameMenu();
            winGame = true;            
            CancelInvoke();
            SearchGameObject("WinText").SetActive(true);
            SearchGameObject("WinText").GetComponent<Text>().text = "Congratulations \n Your score: " + winScore.ToString();
            winScore = 0;
        }
        
    }

    //Show score in upper left corner


    void Spawn ()
    {
        Instantiate(cube, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
	}

    //calculate score
    public static void Score()
    {
        cubesDodged++;
    }

    public static bool GameWon ()
    {
        if (winGame)
            return true;
        return false;
    }

    public void NewGame()
    {
        foreach (var item in menu)
        {
            switch (item.name)
            {
                case "Easy":
                    item.SetActive(true);
                    break;
                case "Normal":
                    item.SetActive(true);
                    break;
                case "Hard":
                    item.SetActive(true);
                    break;
                default:
                    item.SetActive(false);
                    break;
            }
        }        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    //Starts game and unpause it also reloads game with different difficulties
    public void ChangeDifficulty (int difLevel)
    {
        switch (difLevel)
        {
            case 1:
                delay = 0.4f;
                winScore = 10;
                timeFlow = 1f;
                SceneManager.LoadScene("Level_01");
                break;
            case 2:
                delay = 0.25f;
                winScore = 25;
                timeFlow = 1f;
                SceneManager.LoadScene("Level_01");
                break;
            case 3:
                delay = 0.1f;
                winScore = 50;
                timeFlow = 1f;
                SceneManager.LoadScene("Level_01");
                break;
            default:
                delay = 0.1f;
                winScore = 100;
                timeFlow = 1f;
                SceneManager.LoadScene("Level_01");
                break;
        }
    }
    void ShowGameMenu ()
    {
        foreach (var item in menu)
        {
            switch (item.name)
            {
                case "NewGame":
                    item.SetActive(true);
                    break;
                case "QuitGame":
                    item.SetActive(true);
                    break;
                default:
                    item.SetActive(false);
                    break;
            }
        }
    }
    // Function that made my life littlebit easier
    GameObject SearchGameObject (string name)
    {
        foreach (var item in menu)
        {
            if (item.name == name)
                return item;
        }
        return null;
    }
}
