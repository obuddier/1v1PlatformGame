using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    public int p1Life;
    public int p2Life;

    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;

    public AudioSource hurtSound;
    public string mainMenu;


     void Update()
    {
      if(p1Life <= 0)
        {
            p1.SetActive(false);
            p2Wins.SetActive(true);

        }

        if (p2Life <= 0)
        {
            p2.SetActive(false);
            p1Wins.SetActive(true);

        }

        /*if(p1Wins.activeSelf||p2Wins.activeSelf)
        {

        }*/

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // halihaz�rda a��k olan sahnenin ad�n� getiriyor
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }


    }

    public void HurtP1()
    {
        p1Life -= 1;
        for(int i = 0; i < p1Sticks.Length;i++)
        {
            if(p1Life>i)
            {
                p1Sticks[i].SetActive(true);
            }
            else
            {
                p1Sticks[i].SetActive(false);
            }
        }

        hurtSound.Play();
    }

    public void HurtP2()
    {
        p2Life -= 1;
        for (int i = 0; i < p2Sticks.Length; i++)
        {
            if (p2Life > i)
            {
                p2Sticks[i].SetActive(true);
            }
            else
            {
                p2Sticks[i].SetActive(false);
            }
        }
        hurtSound.Play();
    }
}
