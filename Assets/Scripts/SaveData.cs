using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class SaveData
{

    public static SaveData current;

    public float money;
    public float eat;
    public float carprice;

    public float engine_number;
    public float wheels_number;
    public float body_number;

    public float[] conveyer = new float[3]; //Количество деталей автомобиля на конвеере
    public float[,] cars = new float[3, 6];//количество частей машины и количество самих машин
    public float[] selectedPartsBuildMenu = new float[3];//выбранные компоненты в меню строительства автомобиля 


    public float enginex;
    public float enginey;
    public float wheelsx;
    public float wheelsy;
    public float bodyx;
    public float bodyy;

    public float minute;
    public float hour;
    public float day;
    public float week;
    public float month;
    public float year;
    public float vyear;

    public float countPar;
    public float countCanteen;
    public float countEat;

    public bool CameraMenu;
    public bool CameraGame;

    public bool NewGame;
    public bool Pause;
    public bool BuildCarInProgress;
    public bool CarOnConveyer;
    public bool BuildMenuActive = false;



    public SaveData()
    {
        
    }
    public static SaveData GetInstance()
    {
        if (current == null)
        {
            current = new SaveData();
        }

        return current;
    }
}
