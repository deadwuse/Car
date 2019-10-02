using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Gameplay : MonoBehaviour {

    public static Gameplay current;

    private float range;
    public float merge = 80000;
    [Space(10)]
    public GameObject MoneyText;
    public GameObject CarPriceText;
    
    /*public GameObject ReputText;*/
    [Space(10)]
    public GameObject backWindow;
    public GameObject button;
    public GameObject buttonExit;
    /*public GameObject CountParText;
    public GameObject ResultParText;
    public GameObject CountCanteenText;
    public GameObject ResultEatText;*/
    [Space(10)]
    public Sprite sprite;
    public Sprite EmptyIcon;
    [Space(10)]
    public GameObject Game;
    public GameObject MainMenu;
    public GameObject PanelNewGameQ;
    public GameObject Hud;
    public GameObject Options;
    public GameObject Build_panel;
    public GameObject Build_Main;
    public GameObject Build_Engine;
    public GameObject Sell_Panel;
    public GameObject Extp_Conveyer_not_full;
    public GameObject Extp_Conveyer_not_empty;
    public GameObject Extp_Nothing_to_sell;
    [Space(10)]
    //public GameObject ProgressBarEat;
    public GameObject ButtonContinue;
    /*public GameObject ButtonIconEngine;
    public GameObject ButtonIconWheels;
    public GameObject ButtonIconBody;*/
    GameObject ButtonIconEngine = null;
    GameObject ButtonIconWheels = null;
    GameObject ButtonIconBody = null;
    GameObject CarInfoPriceText = null;
    GameObject priceText = null;

    [Space(10)]
    public GameObject engine1image;
    public GameObject engine1icon;
    [Space(10)]
    public GameObject wheels1image;
    public GameObject wheels1icon;
    [Space(10)]
    public GameObject body1image;
    public GameObject body1icon;
    [Space(10)]
    public GameObject enginespot;
    public GameObject wheelsspot;
    public GameObject bodyspot;

    public Engines[] engines = new Engines[6];
    public Wheels[] wheels = new Wheels[10];
    public Body[] body = new Body[10];
    public Car[] cars = new Car[10];
    public GameObject[] createdcars = new GameObject[10];





    IEnumerator waitParts(float speed, GameObject wheelst, GameObject enginet, GameObject bodyt) //Функция анимации сбара машины
    {
        if (!SaveData.GetInstance().Pause)
        {
            SaveData.GetInstance().BuildCarInProgress = true;
            Transform childe;
            Transform childw;
            Transform childb;

            childw = wheelst.transform.GetChild(0);
            childe = enginet.transform.GetChild(0);
            childb = bodyt.transform.GetChild(0);

            while (childw.localPosition.y > -1.7 & !SaveData.GetInstance().Pause)
            {

                childw.localPosition -= new Vector3(0, 0.1f, 0);
                yield return new WaitForSeconds(speed);

            }
            while (childw.localPosition.x < 2.975 & !SaveData.GetInstance().Pause)
            {

                childw.localPosition += new Vector3(0.1f, 0, 0);
                yield return new WaitForSeconds(speed);

            }
            while (childe.localPosition.y > -1.7 & !SaveData.GetInstance().Pause)
            {

                childe.localPosition -= new Vector3(0, 0.1f, 0);
                yield return new WaitForSeconds(speed);
                

            }
            while (childe.localPosition.x < 2.9 & !SaveData.GetInstance().Pause)
            {

                childw.localPosition += new Vector3(0.1f, 0, 0);
                childe.localPosition += new Vector3(0.1f, 0, 0);
                yield return new WaitForSeconds(speed);

            }
            while (childb.localPosition.y > -1.7 & !SaveData.GetInstance().Pause)
            {

                childb.localPosition -= new Vector3(0, 0.1f, 0);
                yield return new WaitForSeconds(speed);

            }
            while (childe.localPosition.x < 5.8 & !SaveData.GetInstance().Pause)
            {

                childw.localPosition += new Vector3(0.1f, 0, 0);
                childe.localPosition += new Vector3(0.1f, 0, 0);
                childb.localPosition += new Vector3(0.1f, 0, 0);
                yield return new WaitForSeconds(speed);

            }
            while (childe.localPosition.y > -2.4f & !SaveData.GetInstance().Pause)
            {

                childw.localPosition -= new Vector3(0, 0.1f, 0);
                childe.localPosition -= new Vector3(0, 0.1f, 0);
                childb.localPosition -= new Vector3(0, 0.1f, 0);
                yield return new WaitForSeconds(speed);

                createdcars[1] = new GameObject();
                createdcars[1].transform.position = new Vector3(5.8f, -2.4f, 0);
                childw.SetParent(createdcars[1].transform);
                childe.SetParent(createdcars[1].transform);
                childb.SetParent(createdcars[1].transform);
                SaveData.GetInstance().BuildCarInProgress = false;
            }

            cars[1].body = body[Convert.ToInt32(SaveData.GetInstance().body_number)];
            cars[1].engine = engines[Convert.ToInt32(SaveData.GetInstance().engine_number)];
            cars[1].wheels = wheels[Convert.ToInt32(SaveData.GetInstance().wheels_number)];
            cars[1].price = cars[1].engine.price + cars[1].wheels.price + cars[1].body.price;



        }

        yield return new WaitForEndOfFrame();
    }



    public void CreateCar() //Функция сбора машины
    {
        if (!SaveData.GetInstance().CarOnConveyer)
        {
            if (SaveData.GetInstance().conveyer[0] + SaveData.GetInstance().conveyer[1] + SaveData.GetInstance().conveyer[2] != 0)
            {
                if (!SaveData.GetInstance().BuildCarInProgress)
                {

                    SaveData.GetInstance().CarOnConveyer = true;
                    StartCoroutine(waitParts(0.1f, wheelsspot, enginespot, bodyspot));
                }

            }
            else
                Extp_Conveyer_not_full.transform.position = new Vector3(0, 0, 0);
        }
        else
            GetWindow(Extp_Conveyer_not_empty);
    }

    public void ConveyerMptFullButtonApply() //Функция подтверждения кнопки !!можно заменить на BottonClose!!
    {
        Extp_Conveyer_not_full.transform.position = new Vector3(0, merge, 0);
    }

    

    public void Pause()
    {
        PartsSaver();
        SaveLoad.Save();
        Game.transform.position = new Vector3(0, merge, 0);
        MainMenu.transform.position = new Vector3(0, 0, 0);
        SaveData.GetInstance().Pause = true;


    }

    

    

    

    

    public void PartsSaver()
    {
        if (SaveData.GetInstance().BuildCarInProgress)
        {
            Transform childe;
            Transform childw;
            Transform childb;

            childw = wheelsspot.transform.GetChild(0);
            childe = enginespot.transform.GetChild(0);
            childb = bodyspot.transform.GetChild(0);

            SaveData.GetInstance().enginex = childe.transform.localPosition.x;
            SaveData.GetInstance().enginey = childe.transform.localPosition.y;
            SaveData.GetInstance().wheelsx = childw.transform.localPosition.x;
            SaveData.GetInstance().wheelsy = childw.transform.localPosition.y;
            SaveData.GetInstance().bodyx = childb.transform.localPosition.x;
            SaveData.GetInstance().bodyy = childb.transform.localPosition.y;
        }
    }

    public void PartsLoader()
    {

        if (SaveData.GetInstance().BuildCarInProgress)
        {
            Transform childe;
            Transform childw;
            Transform childb;

            childw = wheelsspot.transform.GetChild(0);
            childe = enginespot.transform.GetChild(0);
            childb = bodyspot.transform.GetChild(0);

            childe.transform.localPosition = new Vector3(SaveData.GetInstance().enginex, SaveData.GetInstance().enginey, 0);
            childw.transform.localPosition = new Vector3(SaveData.GetInstance().wheelsx, SaveData.GetInstance().wheelsy, 0);
            childb.transform.localPosition = new Vector3(SaveData.GetInstance().bodyx, SaveData.GetInstance().bodyy, 0);

            StartCoroutine(waitParts(0.2f, wheelsspot, enginespot, bodyspot));
        }
    }

    public string TimeDisplay(float num)
    {
        string time;
        time = (num < 10) ? "0" + num.ToString() : "" + num.ToString();
        return time;
    }

    public void Calendar()
    {
        if (SaveData.GetInstance().vyear >= 5)
        {
            SaveData.GetInstance().vyear -= 4;
        }

        if (SaveData.GetInstance().week >= 8)
        {
            SaveData.GetInstance().week -= 7;
        }

        if (SaveData.GetInstance().minute >= 60)
        {
            SaveData.GetInstance().hour += 1;
            SaveData.GetInstance().minute -= 60;
        }

        if (SaveData.GetInstance().hour >= 24)
        {
            SaveData.GetInstance().day += 1;
            SaveData.GetInstance().hour -= 24;
        }
        if (SaveData.GetInstance().month == 1 | SaveData.GetInstance().month == 3 | SaveData.GetInstance().month == 5 | SaveData.GetInstance().month == 7 | SaveData.GetInstance().month == 8 | SaveData.GetInstance().month == 10 | SaveData.GetInstance().month == 12)
        {
            if (SaveData.GetInstance().day >= 32)
            {
                SaveData.GetInstance().month += 1;
                SaveData.GetInstance().day -= 31;
            }
        }
        else
        {
            if (SaveData.GetInstance().month == 2)
            {
                if (SaveData.GetInstance().vyear == 4)
                {
                    if (SaveData.GetInstance().day >= 30)
                    {
                        SaveData.GetInstance().month += 1;
                        SaveData.GetInstance().day -= 29;
                    }
                }
                else
                {
                    if (SaveData.GetInstance().day >= 29)
                    {
                        SaveData.GetInstance().month += 1;
                        SaveData.GetInstance().day -= 28;
                    }
                }
            }
            else
            {
                if (SaveData.GetInstance().day >= 31)
                {
                    SaveData.GetInstance().month += 1;
                    SaveData.GetInstance().day -= 30;
                }
            }
        }



        if (SaveData.GetInstance().month >= 13)
        {
            SaveData.GetInstance().year += 1;
            SaveData.GetInstance().month -= 12;
        }
    }

    public void NewEngine()
    {
        GameObject eng;
        eng = Instantiate(engines[Convert.ToInt32(SaveData.GetInstance().engine_number)].image, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        eng.transform.SetParent(enginespot.transform);
        eng.transform.localPosition = new Vector3(0, 0, 0);
        eng.transform.localScale = new Vector3(1, 1, 1);
        SaveData.GetInstance().conveyer[0] = SaveData.GetInstance().engine_number;
        eng.GetComponent<SpriteRenderer>().sortingOrder = -61;
    }

    public void NewWheels()
    {
        GameObject whls;
        whls = Instantiate(wheels[Convert.ToInt32(SaveData.GetInstance().wheels_number)].image, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        whls.transform.SetParent(wheelsspot.transform);
        whls.transform.localPosition = new Vector3(0, 0, 0);
        whls.transform.localScale = new Vector3(1, 1, 1);
        SaveData.GetInstance().conveyer[1] = SaveData.GetInstance().wheels_number;
        whls.GetComponent<SpriteRenderer>().sortingOrder = -60;
    }

    public void NewBody()
    {
        GameObject bod;
        bod = Instantiate(body[Convert.ToInt32(SaveData.GetInstance().body_number)].image, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        bod.transform.SetParent(bodyspot.transform);
        bod.transform.localPosition = new Vector3(0, 0, 0);
        bod.transform.localScale = new Vector3(1, 1, 1);
        SaveData.GetInstance().conveyer[2] = SaveData.GetInstance().body_number;
        bod.GetComponent<SpriteRenderer>().sortingOrder = -59;
    }

    public void ApplyParts()
    {
        if (SaveData.GetInstance().conveyer[0] + SaveData.GetInstance().conveyer[1] + SaveData.GetInstance().conveyer[2] == 0)
        {
            NewEngine();
            NewBody();
            NewWheels();
            
            
        }
        else
            Extp_Conveyer_not_empty.transform.position = new Vector3(0, 0, 0);
    }

    public void ConveyerNotEmptyButton()
    {
        Extp_Conveyer_not_empty.transform.position = new Vector3(0, merge, 0);
    }

    public void Table_press()
    {
        //Build_panel.transform.position = new Vector3(0, 0, 0);
        cars[1] = new Car();
        cars[1].engine = new Engines();
        cars[1].wheels = new Wheels();
        cars[1].body = new Body();
        BuildMenuIcons();
        
    }

    void TransformCamera(GameObject Out, GameObject In)
    {
        Out.transform.localPosition = new Vector3(0, merge, 0);
        In.transform.localPosition = new Vector3(0, 0, 0);
    }


    public void ButtonClose(GameObject obj)
    {
        obj.transform.position = new Vector3(0, merge, 0);
    }

    public void Leave_Car()
    {
        if (SaveData.GetInstance().CarOnConveyer)
        {
            if (SaveData.GetInstance().conveyer[0] + SaveData.GetInstance().conveyer[1] + SaveData.GetInstance().conveyer[2] != 0 & SaveData.GetInstance().BuildCarInProgress != true)
            {
                Instantiate(SellMenu());
            }
            else
                GetWindow(Extp_Nothing_to_sell);
        }
        else
            GetWindow(Extp_Nothing_to_sell);

        Instantiate(SellMenu());//УДАЛИИИИИИИИИИИИИИТЬ
    }

    public void Sell_button()
    {
        SaveData.GetInstance().money += SaveData.GetInstance().carprice - cars[1].price; ;
        Destroy(createdcars[1]);
        SaveData.GetInstance().conveyer[0] = 0;
        SaveData.GetInstance().conveyer[1] = 0;
        SaveData.GetInstance().conveyer[2] = 0;
        SaveData.GetInstance().CarOnConveyer = false;
    }

    public void Change_Price_button(float ch)
    {

        if (ch < 0)
        {
            if (SaveData.GetInstance().carprice > 1000)
            {
                SaveData.GetInstance().carprice += ch;
            }
        }
        else
            SaveData.GetInstance().carprice += ch;
    }

    public void GetWindow(GameObject window)
    {
        window.transform.position = new Vector3(0, 0, 0);
    }



    public GameObject AddEngine(Engines dvig, float posx, float posy, GameObject destroy, GameObject textPrice, GameObject textMass)
    {
        GameObject engine = Instantiate(dvig.image, new Vector3(posx, posy, 0), Quaternion.identity) as GameObject;
        engine.AddComponent<Image>().sprite = engine.GetComponent<SpriteRenderer>().sprite;
        Destroy(engine.GetComponent<SpriteRenderer>());
        engine.AddComponent<Button>().onClick.AddListener(
            () => {
                SaveData.GetInstance().engine_number = dvig.id;
                textPrice.GetComponent<Text>().text = "Price: " + dvig.price.ToString();
                textMass.GetComponent<Text>().text = "Mass: " + dvig.mass.ToString();
            }
            );
        return engine;
    }

    public GameObject AddWheels(Wheels wheel, float posx, float posy, GameObject destroy, GameObject textPrice, GameObject textMass)
    {
        GameObject wheels = Instantiate(wheel.image, new Vector3(posx, posy, 0), Quaternion.identity) as GameObject;
        wheels.AddComponent<Image>().sprite = wheels.GetComponent<SpriteRenderer>().sprite;
        Destroy(wheels.GetComponent<SpriteRenderer>());
        wheels.AddComponent<Button>().onClick.AddListener(
            () =>
            {
                SaveData.GetInstance().wheels_number = wheel.id;
                textPrice.GetComponent<Text>().text = "Price: " + wheel.price.ToString();
                textMass.GetComponent<Text>().text = "Mass: " + wheel.mass.ToString();
            }
            );
        return wheels;
    }

    public GameObject AddBody(Body body, float posx, float posy, GameObject destroy, GameObject textPrice, GameObject textMass)
    {
        GameObject bodys = Instantiate(body.image, new Vector3(posx, posy, 0), Quaternion.identity) as GameObject;
        bodys.AddComponent<Image>().sprite = bodys.GetComponent<SpriteRenderer>().sprite;
        Destroy(bodys.GetComponent<SpriteRenderer>());
        bodys.AddComponent<Button>().onClick.AddListener(
            () => {
                SaveData.GetInstance().body_number = body.id;
                textPrice.GetComponent<Text>().text = "Price: " + body.price.ToString();
                textMass.GetComponent<Text>().text = "Mass: " + body.mass.ToString();
            }
            );
        return bodys;
    }


    private GameObject CreateText(String Text, GameObject parent)
    {
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject text = new GameObject();
        text.transform.SetParent(parent.transform);
        text.AddComponent<Text>().font = ArialFont;
        text.GetComponent<Text>().color = Color.black;
        text.GetComponent<Text>().text = Text;
        text.GetComponent<Text>().fontSize = 25;
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 40);
        text.transform.localScale = new Vector3(1, 1, 1);

        return text;
    }

    private GameObject CreateBackInfo()
    {
        GameObject back = Instantiate(backWindow);
        back.transform.SetParent(Game.transform);
        back.AddComponent<Mask>();

        back.AddComponent<ScrollRect>().horizontal = false;
        back.AddComponent<Image>().sprite = back.GetComponent<SpriteRenderer>().sprite;
        Destroy(back.GetComponent<SpriteRenderer>());
        back.transform.localScale = new Vector3(1, 1, 1);
        return back;
    }

    private GameObject CreateBackInfoCar(GameObject parent)
    {
        GameObject back = Instantiate(backWindow);
        back.transform.SetParent(parent.transform);

        back.AddComponent<Image>().sprite = back.GetComponent<SpriteRenderer>().sprite;
        Destroy(back.GetComponent<SpriteRenderer>());
        back.transform.localScale = new Vector3(1, 1, 1);
        return back;
    }

    private GameObject CreateInfoPart()
    {
        GameObject info = Instantiate(backWindow);
        info.transform.SetParent(Game.transform);
        info.transform.localPosition = new Vector3(-285f, 0, 0);
        info.AddComponent<Image>().sprite = info.GetComponent<SpriteRenderer>().sprite;
        Destroy(info.GetComponent<SpriteRenderer>());
        info.AddComponent<VerticalLayoutGroup>().childForceExpandHeight = false;
        info.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = false;
        info.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        info.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.UpperCenter;

        return info;
    }

    private GameObject CreateInfoCar(GameObject parent)
    {
        GameObject info = new GameObject();
        info.transform.SetParent(parent.transform);
        info.transform.localPosition = new Vector3(0, 0, 0);
        //info.AddComponent<Image>().sprite = info.GetComponent<SpriteRenderer>().sprite;
        //Destroy(info.GetComponent<SpriteRenderer>());
        info.AddComponent<VerticalLayoutGroup>().childForceExpandHeight = false;
        info.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = false;
        info.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        info.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.UpperCenter;

        return info;
    }

    private GameObject CreateCanvasInfo(GameObject back)
    {
        GameObject canvas = new GameObject();
        canvas.transform.SetParent(back.transform);
        canvas.AddComponent<CanvasRenderer>();
        canvas.AddComponent<RectTransform>();
        canvas.transform.localScale = new Vector3(1, 1, 1);
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 225);
        canvas.AddComponent<VerticalLayoutGroup>().childForceExpandHeight = false;
        canvas.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = false;
        canvas.AddComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        canvas.AddComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        canvas.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.UpperCenter;
        canvas.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
        back.GetComponent<ScrollRect>().content = canvas.GetComponent<RectTransform>();

        return canvas;
    }

    private GameObject CreateCloseButtonInfo(GameObject back, GameObject info)
    {
        GameObject close = Instantiate(button);
        close.transform.SetParent(back.transform);
        close.AddComponent<Canvas>().overrideSorting = true;
        close.AddComponent<GraphicRaycaster>();
        close.GetComponentInChildren<Text>().text = "Закрыть";
        close.transform.position = new Vector3(0, -150, 0);

        close.GetComponent<Button>().onClick.AddListener(
            () => {
                Destroy(back);
                Destroy(info);
                BuildMenuIcons();
            }
            );
        return close;
    }

    public void SelectEngine()
    {
        GameObject back = CreateBackInfo();
        GameObject info = CreateInfoPart();

        GameObject priceText = CreateText("Price: - ", info);
        GameObject massText = CreateText("Mass: - ", info);

        GameObject canvas = CreateCanvasInfo(back);

        foreach (Engines g in engines)
        {
            if (g.id != 0)
            {
                GameObject engine1 = AddEngine(g, 0f, 0f, back, priceText, massText);
                engine1.transform.SetParent(canvas.transform);
            }
        }

        GameObject close = CreateCloseButtonInfo(back, info);

    }

    public void SelectWheels()
    {

        GameObject back = CreateBackInfo();
        GameObject info = CreateInfoPart();

        GameObject priceText = CreateText("Price: - ", info);
        GameObject massText = CreateText("Mass: - ", info);

        GameObject canvas = CreateCanvasInfo(back);

        foreach (Wheels g in wheels)
        {
            if (g.id != 0)
            {
                GameObject wheel1 = AddWheels(g, 0f, 0f, back, priceText, massText);
                wheel1.transform.SetParent(canvas.transform);
            }
        }

        GameObject close = CreateCloseButtonInfo(back, info);
    }

    public void SelectBody()
    {
        GameObject back = CreateBackInfo();
        GameObject info = CreateInfoPart();

        GameObject priceText = CreateText("Price: - ", info);
        GameObject massText = CreateText("Mass: - ", info);

        GameObject canvas = CreateCanvasInfo(back);

        foreach (Body g in body)
        {
            if (g.id != 0)
            {
                GameObject body1 = AddBody(g, 0f, 0f, back, priceText, massText);
                body1.transform.SetParent(canvas.transform);
            }
        }

        GameObject close = CreateCloseButtonInfo(back, info);
    }

    private void UpdateBuildMenu(GameObject engine, GameObject wheel, GameObject bodys, GameObject price)
    {
        if (SaveData.GetInstance().engine_number == 0)
            engine.GetComponent<Image>().sprite = EmptyIcon;
        else
            engine.GetComponent<Image>().sprite = engines[Convert.ToInt32(SaveData.GetInstance().engine_number)].image.GetComponent<SpriteRenderer>().sprite;

        if (SaveData.GetInstance().wheels_number == 0)
            wheel.GetComponent<Image>().sprite = EmptyIcon;
        else
            wheel.GetComponent<Image>().sprite = wheels[Convert.ToInt32(SaveData.GetInstance().wheels_number)].image.GetComponent<SpriteRenderer>().sprite;

        if (SaveData.GetInstance().body_number == 0)
            bodys.GetComponent<Image>().sprite = EmptyIcon;
        else
            bodys.GetComponent<Image>().sprite = body[Convert.ToInt32(SaveData.GetInstance().body_number)].image.GetComponent<SpriteRenderer>().sprite;

        price.GetComponent<Text>().text = "Price: " + (engines[Convert.ToInt32(SaveData.GetInstance().engine_number)].price + wheels[Convert.ToInt32(SaveData.GetInstance().wheels_number)].price + body[Convert.ToInt32(SaveData.GetInstance().body_number)].price).ToString();
    }

    public void BuildMenuIcons()
    {
        


        if (SaveData.GetInstance().BuildMenuActive == false)
        {

            GameObject background = Instantiate(backWindow);
            GameObject canvasMain = InstantiateHorizontalCanvas(background);

            background.transform.SetParent(Game.transform);
            background.transform.localPosition = new Vector3(0, 0, 0);

            background.AddComponent<Image>().sprite = background.GetComponent<SpriteRenderer>().sprite;
            Destroy(background.GetComponent<SpriteRenderer>());

            ButtonIconEngine = InstantiateButton(canvasMain, -100, 0);
            ButtonIconEngine.GetComponent<Button>().onClick.AddListener(() => SelectEngine());

            ButtonIconWheels = InstantiateButton(canvasMain, 0, 0);
            ButtonIconWheels.GetComponent<Button>().onClick.AddListener(() => SelectWheels());

            ButtonIconBody = InstantiateButton(canvasMain, 100, 0);
            ButtonIconBody.GetComponent<Button>().onClick.AddListener(() => SelectBody());

            GameObject ButtonApply = InstantiateButton(background, 0, -150);
            ButtonApply.GetComponent<Button>().onClick.AddListener(() => { ApplyParts(); Destroy(background); });
            ButtonApply.GetComponent<Image>().sprite = EmptyIcon;

            GameObject back = CreateBackInfoCar(background);
            back.transform.localPosition = new Vector3(0, 285, 0);

            GameObject info = CreateInfoCar(back);
            GameObject exit = InstantiateButtonExit(90, 150, background);

            priceText = CreateText("Price: - ", info);

            UpdateBuildMenu(ButtonIconEngine, ButtonIconWheels, ButtonIconBody, priceText);

            exit.GetComponent<Button>().onClick.AddListener(
                () =>
                {
                    Destroy(background);
                    SaveData.GetInstance().BuildMenuActive = false;

                }
                );
            SaveData.GetInstance().BuildMenuActive = true;
        }
        else
            UpdateBuildMenu(ButtonIconEngine, ButtonIconWheels, ButtonIconBody, priceText);
    }

    private GameObject SellMenu()
    {
        GameObject menu = new GameObject();
        menu.transform.SetParent(Game.transform);

        GameObject background = CreateBackInfoCar(menu);
        GameObject canvasSell = InstantiateHorizontalCanvas(menu);
        
        GameObject sellText = CreateText("Продать?", menu);
        sellText.transform.localPosition = new Vector3(0, 130, 0);
        Destroy(canvasSell.GetComponent<ContentSizeFitter>());
        Destroy(canvasSell.GetComponent<HorizontalLayoutGroup>());

        GameObject buttonMinus = InstantiateButton(canvasSell, -75, 0);
        buttonMinus.GetComponent<Image>().sprite = button.GetComponent<Image>().sprite;
        Destroy(buttonMinus.GetComponent<ContentSizeFitter>());
        buttonMinus.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        GameObject carPrice = CreateText("1000", canvasSell);

        buttonMinus.GetComponent<Button>().onClick.AddListener(
            () =>
            {
                Change_Price_button(-1000);
                carPrice.GetComponent<Text>().text = SaveData.GetInstance().carprice.ToString();
            });



        return menu;
    }

    private GameObject InstantiateHorizontalCanvas(GameObject parent)
    {
        GameObject canvas = new GameObject();
        canvas.transform.SetParent(parent.transform);
        canvas.AddComponent<HorizontalLayoutGroup>().childForceExpandHeight = false;
        canvas.GetComponent<HorizontalLayoutGroup>().childForceExpandWidth = false;
        canvas.AddComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        canvas.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        canvas.GetComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
        
        return canvas;
    }

    private GameObject InstantiateButtonExit(float x, float y, GameObject parent)
    {
        GameObject exit = Instantiate(buttonExit, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        exit.transform.SetParent(parent.transform);
        exit.transform.localPosition = new Vector3(x, y, 0);

        return exit;
    }

    private GameObject InstantiateButton(GameObject parent, float x,float y)
    {
        GameObject button = new GameObject();
        button.AddComponent<Image>();
        button.AddComponent<Button>();
        button.transform.SetParent(parent.transform);
        button.transform.localPosition = new Vector3(x,y,0);
        button.AddComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        button.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;


        return button;
    }

    void Start()
    {
        
    }



    // Update is called once per frame
    void Update ()
    {
        Calendar();

        MoneyText.GetComponent<Text>().text = "Money: " + SaveData.GetInstance().money.ToString();
        CarPriceText.GetComponent<Text>().text = SaveData.GetInstance().carprice.ToString();




        if (SaveData.GetInstance().Pause)
            Hud.GetComponent<CanvasScaler>().scaleFactor = 0;
        else
            Hud.GetComponent<CanvasScaler>().scaleFactor = 1;




    }
}
