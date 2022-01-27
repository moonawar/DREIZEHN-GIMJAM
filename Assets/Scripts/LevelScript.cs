using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelIsUnlocked"))
        {
            PlayerPrefs.SetInt("levelIsUnlocked", currentLevel + 1);
            
        }

        Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelIsUnlocked") + " UNLOCKED");
        SceneManager.LoadScene(5);
    }
}
