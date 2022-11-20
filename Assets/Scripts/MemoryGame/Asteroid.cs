using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private AsteroidsManager asteroidsManager;
    private int asteroidIndex;

    public AsteroidsManager AsteroidsManager { set { asteroidsManager = value; } }
    public int AsteroidIndex { get { return asteroidIndex; } set { asteroidIndex = value; } }


    public void StartOrderAnimation(){
        StartCoroutine(OrderAnimationCoroutine());
    }

    private IEnumerator OrderAnimationCoroutine(){
        // Resize the asteroid
        Vector3 startingSize = this.gameObject.transform.localScale;
        this.transform.localScale = startingSize * 1.5f;

        yield return new WaitForSeconds(1);

        this.transform.localScale = startingSize;
        asteroidsManager.NextAnimOrder();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            asteroidsManager.TouchAsteroid(asteroidIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            asteroidsManager.TouchAsteroid(asteroidIndex);
        }
    }
}
