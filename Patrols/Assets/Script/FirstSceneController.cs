using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FirstSceneController : MonoBehaviour, ISceneController, IUserAction
{

    public GameObject player;
    public Factory factory;
    public ScoreController scoreController;
    public PatrolActionManager patrolActionManager;
    public float playerSpeed = 5f;
    private List<GameObject> patrols;
    private bool gameOver = false;


    // Use this for initialization
    void Start()
    {
        Director director = Director.GetInstance();
        director.CurrentScenceController = this;
        factory = Singleton<Factory>.Instance;
        patrolActionManager = gameObject.AddComponent<PatrolActionManager>() as PatrolActionManager;
        LoadResource();
        scoreController = Singleton<ScoreController>.Instance;

    }

    public void LoadResource()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/Environment"));
        Instantiate(Resources.Load<GameObject>("Prefabs/Floor"));
        Instantiate(Resources.Load<GameObject>("Prefabs/Lights"));
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        patrols = factory.GetPatrol();

        for (int i = 0; i < patrols.Count; i++)
        {
            patrolActionManager.GoPatrol(patrols[i]);
        }
    }

    public int GetScore()
    {
        return scoreController.GetScore();
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    private void Score()
    {
        scoreController.Score();
    }

    private void GameOver()
    {
        gameOver = true;
        patrolActionManager.DestroyAllAction();
    }

    private void OnEnable()
    {
        EventHandler.GameOverChange += GameOver;
        EventHandler.ScoreChange += Score;
    }

    private void OnDisable()
    {
        EventHandler.GameOverChange -= GameOver;
        EventHandler.ScoreChange -= Score;
    }
}
