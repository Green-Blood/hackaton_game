using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Button playButton;
    [SerializeField] TextMeshProUGUI requestedMilkText;
    [SerializeField] TextMeshProUGUI currentMilkText;
    [SerializeField] private int currentMilk;
    [SerializeField] private List<Scene> scenes;

    private PlanetUI selectedPlanet;

    private enum CurrentMenu
    {
        Spaceship,
        Minigames,
        Friends,
        StoryMode
    }

    private CurrentMenu currentMenu = CurrentMenu.Spaceship;

    private void Start()
    {
        playButton.interactable = false;
        requestedMilkText.text = "";
        currentMilkText.text = currentMilk.ToString();
    }


    public void GoToStoryMode()
    {
    }
    public void GoToFriends()
    {
    }
    public void GoToMinigames()
    {
        animator.Play("SpaceshipToMinigames");
        currentMenu = CurrentMenu.Minigames;
    }

    public void SelectPlanet(PlanetUI planet)
    {
        if(selectedPlanet != null)
        {
            selectedPlanet.DeselectAnimation();
        }

        selectedPlanet = planet;
        requestedMilkText.text = selectedPlanet.GetRequestedMilk.ToString();

        if (currentMilk >= selectedPlanet.GetRequestedMilk)
        {
            playButton.interactable = true;
            selectedPlanet.Interactable = true;
        }
        else
        {
            playButton.interactable = false;
            selectedPlanet.Interactable = false;
        }
    }

    public void ReturnToMainMenu()
    {
        if(selectedPlanet != null)
        {
            selectedPlanet.DeselectAnimation();
            selectedPlanet = null;
        }

        switch (currentMenu)    
        {
            case CurrentMenu.Spaceship:
                animator.Play("MinigamesToSpaceship");
                break;
            case CurrentMenu.Minigames:
                animator.Play("MinigamesToSpaceship");
                break;
            case CurrentMenu.Friends:
                animator.Play("FriendsToSpaceship");
                break;
            case CurrentMenu.StoryMode:
                animator.Play("StoryModeToSpaceship");
                break;
        }
        currentMenu = CurrentMenu.Spaceship;
    }

    public void PlayMinigame()
    {
        currentMilk -= selectedPlanet.GetRequestedMilk;

        SceneManager.LoadScene(selectedPlanet.GetScene);
        
    }
}
