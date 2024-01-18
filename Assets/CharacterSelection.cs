using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        if(characters != null || characters.Length > 0)
        {
            characters[selectedCharacter].SetActive(false);
            selectedCharacter = (selectedCharacter + 1) % characters.Length;
            characters[selectedCharacter].SetActive(true);
        }
    }

    public void PreviousCharacter() 
    {
        if (characters != null || characters.Length > 0)
        {
            characters[selectedCharacter].SetActive(false);
            selectedCharacter--;

            if (selectedCharacter < 0)
            {
                selectedCharacter = characters.Length - 1;
            }

            characters[selectedCharacter].SetActive(true);
        }
    }

    public void StartGame()
    {
        string sceneName = "GameScene";
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
