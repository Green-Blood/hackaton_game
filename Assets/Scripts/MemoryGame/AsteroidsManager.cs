using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidsManager : MonoBehaviour
{

    [SerializeField]
    private List<Asteroid> asteroids;
    [SerializeField] private GameObject finishMenu;

    private List<int> touchedAsteroids;

    private int[] asteroidsOrder;

    private int currentAnimIndex = 0;

    private bool showingOrder = false;
    private bool nextAnim = false;

    #region Unity Cycle
    void Start()
    {
        touchedAsteroids = new List<int>();
    }

    void Update()
    {
        // Check the animations state
        if(showingOrder && nextAnim){
            asteroids[asteroidsOrder[currentAnimIndex]].StartOrderAnimation();

            // Checkl the next animation
            if (asteroidsOrder.Length - 1 == currentAnimIndex){
                showingOrder = false;
            }else{
                currentAnimIndex++;
            }
            nextAnim = false;
        }
    }
    #endregion

    #region Public

    public void NextAnimOrder()
    {
        nextAnim = true;
    }

    public void TouchAsteroid(int asteroidIndex)
    {
        touchedAsteroids.Add(asteroidIndex);

        CheckTouchedAsteroids();
    }

    public void ResetTouchedAsteroids()
    {
        touchedAsteroids.Clear();
        //StartGame();
    }
    
    public void StartGame()
    {
        StartCoroutine(waitCoroutine());
    }

    

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion


    #region Private

    private IEnumerator waitCoroutine()
    {
        yield return new WaitForSeconds(2);
        LoadGame();
    }

    public void LoadGame()
    {
        currentAnimIndex = 0;
        showingOrder = false;
        nextAnim = false;

        touchedAsteroids.Clear();

        // Shuffle the asteroids order
        AsteroidsOrderShuffle();

        // Configure the asteroids
        for (int i = 0; i < asteroids.Count; i++)
        {
            asteroids[asteroidsOrder[i]].AsteroidIndex = i;
            asteroids[asteroidsOrder[i]].AsteroidsManager = this;
        }

        showingOrder = true;
        nextAnim = true;
    }

    private void AsteroidsOrderShuffle()
    {
        asteroidsOrder = new int[asteroids.Count];
        for(int i = 0; i < asteroids.Count; i++)
        {
            asteroidsOrder[i] = i;
        }


        for(int i = 0; i < asteroidsOrder.Length; i++)
        {
            int rnd = Random.Range(0, asteroidsOrder.Length);

            int temp = asteroidsOrder[rnd];
            asteroidsOrder[rnd] = asteroidsOrder[i];
            asteroidsOrder[i] = temp;
        }
    }

    private void CheckTouchedAsteroids()
    {
        foreach(int i in touchedAsteroids)
        {
            Debug.Log(i);
        }

        Debug.Log("  ");

        bool correctOrder = true;
        if (touchedAsteroids.Count >= asteroids.Count)
        {
            for(int i = 0; i < asteroidsOrder.Length; i++)
            {
                if(touchedAsteroids[i] != i)
                {
                    correctOrder= false;
                }
            }

            if (correctOrder == true)
            {
                Debug.Log("You Win");
            }
            else
            {
                Debug.Log("You Lose");
            }

            finishMenu.SetActive(true);
        }

        
    }

    #endregion
}
