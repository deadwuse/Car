using UnityEngine;
using UnityEngineInternal;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Scripting;

public class MainMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject background;
    public GameObject button;
    [Space(10)]
    public GameObject mainGame;
    public GameObject options;
    public GameObject mainMenu;
    public GameObject questionNewGamePanel;

    public GameObject panelNewGame;
    GameObject panelMainMenu;
    GameObject panelOptions;

    void Start()
    {
        panelMainMenu = Instantiate(canvas) as GameObject;
        panelMainMenu.GetComponent<Canvas>().worldCamera = Camera.main;
        GameObject background = CreateBackground(0,0,1920,1080,panelMainMenu) as GameObject;
        //GameObject buttonExit = CreateButton(0.33f * 1920, 0, 300, 100, panelMainMenu,"Exit");
        //buttonExit.GetComponent<Button>().onClick.AddListener(delegate { Exit(); });
        /*
        SaveData.GetInstance().Pause = true;
        SaveData.GetInstance().BuildCarInProgress = false;

        SaveData.GetInstance().money = 1000;
        SaveData.GetInstance().carprice = 1000;

        SaveData.GetInstance().minute = 0;
        SaveData.GetInstance().hour = 7;
        SaveData.GetInstance().day = 31;
        SaveData.GetInstance().month = 8;
        SaveData.GetInstance().year = 2016;
        SaveData.GetInstance().week = 7;
        SaveData.GetInstance().vyear = 4;

        SaveData.GetInstance().conveyer = new float[3] { 0, 0, 0 };
        */
    }
    /*
    public void Option()
    {
        panelOptions = Instantiate(options) as GameObject;
    }

    public void OptionBack()
    {
        options.transform.position = new Vector3(4000, 0, 0);
    }

    public void Continue()
    {
        if (!SaveData.GetInstance().NewGame)
        {
            SaveLoad.Clear();
            SaveLoad.Load();

            SaveData.GetInstance().NewGame = true;
            SaveData.GetInstance().Pause = false;
            Start();
        }
        else
        {
            SaveLoad.Load();
            foreach (SaveData g in SaveLoad.savedGames)
            {
                SaveData.current = g;
            }
        }

        Destroy(mainMenu);
        Instantiate(mainGame);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    public void ResetYes()
    {
        SaveLoad.Clear();
        SaveLoad.Load();

        Application.LoadLevel(0);
        SaveData.GetInstance().NewGame = true;
        SaveData.GetInstance().Pause = false;
        Start();

        SaveData.GetInstance().NewGame = true;
        SaveData.GetInstance().Pause = false;
    }

    public void ResetGame()
    {
        panelNewGame = Instantiate(questionNewGamePanel) as GameObject;
    }

    public void ResetNo()
    {
        Destroy(panelNewGame);
    }*/

    public GameObject CreateBackground(float posX, float posY, float sizeX, float sizeY, GameObject parent)
    {
        GameObject back = Instantiate(background, Vector3.zero, Quaternion.identity) as GameObject;
        back.transform.SetParent(parent.transform);
        back.transform.localScale = new Vector3(sizeX, sizeY, 1);
        back.transform.localPosition = new Vector3(posX, posY, 0);
        return back;
    }
    /*
    public GameObject CreateButton(float posX, float posY, float sizeX, float sizeY, GameObject parent, string text)
    {
        GameObject but = Instantiate(button) as GameObject;
        but.transform.SetParent(parent.transform);
        but.transform.localScale = new Vector3(sizeX, sizeY, 1);
        but.transform.localPosition = new Vector3(posX, posY, 0);
        but.GetComponentInChildren<Text>().text = text;
        return but;
    }
    */
}
