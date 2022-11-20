using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetUI : MonoBehaviour
{
    [SerializeField] private int requestedMilk;
    [SerializeField] private string scene;
    [SerializeField] private int index;
    [SerializeField] private GameObject selectCircle;
    [SerializeField] private float animSpeed;
    [SerializeField] private Vector3 selectedScale = new Vector3(0.175f, 0.175f, 0.175f);

    private MainMenu mainMenu;

    private Vector3 startingScale;
   
    private bool interactable;

    

    private Coroutine currentCoroutine;

    public bool Interactable { set { interactable = value; } }
    public int GetRequestedMilk => requestedMilk;
    public string GetScene => scene;

    private void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        startingScale = selectCircle.transform.localScale;
    }

    private void Update()
    {
    }

    public void SelectPlanet()
    {
        mainMenu.SelectPlanet(this);

        selectCircle.GetComponent<Image>().color = interactable ? Color.white : Color.red;
        SelectAnimation();
    }

    private void SelectAnimation()
    {
        if(currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(SelectAnimationCoroutine());
    }

    public void DeselectAnimation()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(DeselectAnimationCoroutine());
    }

    private IEnumerator SelectAnimationCoroutine()
    {
        while(selectCircle.transform.localScale.x <= selectedScale.x)
        {
            selectCircle.transform.localScale += Vector3.one * animSpeed * Time.deltaTime;
            yield return 0;
        }
    }

    private IEnumerator DeselectAnimationCoroutine()
    {
        while (selectCircle.transform.localScale.x >= startingScale.x)
        {
            selectCircle.transform.localScale -= Vector3.one * animSpeed * Time.deltaTime;
            yield return 0;
        }
    }
}
