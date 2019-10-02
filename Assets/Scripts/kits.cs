using UnityEngine;
using System.Collections;



[System.Serializable]
public class Engines 
{
    public string name;
    public float id;
    public float price;
    public float mass;
    public GameObject icon;
    public GameObject image;

    public  Engines()
    {
        this.name = "";
        this.icon = null;
        this.image = null;
        this.id= 0;
        this.price = 0;
        this.mass = 0;
    }
}
[System.Serializable]
public class Wheels
{
    public string name;
    public float id;
    public GameObject icon;
    public GameObject image;
    public float price;
    public float mass;

    public Wheels()
    {
        this.name = "";
        this.icon = null;
        this.image = null;
        this.id = 0;
        this.price = 0;
        this.mass = 0;
    }
}
[System.Serializable]
public class Body
{
    public string name;
    public float id;
    public float price;
    public float mass;
    public GameObject icon;
    public GameObject image;

    public Body()
    {
        this.name = "";
        this.icon = null;
        this.image = null;
        this.id = 0;
        this.price = 0;
        this.mass = 0;
    }
}

public class Car
{
    public string name;
    public float id;
    public float price;
    public Engines engine;
    public Wheels wheels;
    public Body body;

    public Car()
    {
        this.name = "";
        this.id = 0;
        this.price = 0;
        this.engine = null;
        this.wheels = null;
        this.body = null;
    }
}
