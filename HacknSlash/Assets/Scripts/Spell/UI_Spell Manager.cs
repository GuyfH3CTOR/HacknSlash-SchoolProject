using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class UI_SpellManager : MonoBehaviour
{
    [Header("Variable")]
    public GameObject g_PlayerArm;
    public Vector2 iconIncreasedSize = new Vector2(200,200);
    private Vector2 iconNormalSize;

    private int SelectedSpellNumber = 1;
    private float scrollScale = 0.1f;

    [Header("Spell Slot")]
    public GameObject[] spellSlot;
    public List<Spell> spellsList = new List<Spell>();

    [Header("Selected Spell Varaibles")]
    private GameObject _gameobject;
    private string _castType;
    private int _manaCost;
    private float _damage;
    private float _loadTime;
    private float _ReloadTime;
    private float _speed;
    private float _zoneSize;

    [Header("Load Slider")]
    public GameObject LoadSlider;
    private float Load;
    private bool isLoading;

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        iconNormalSize = spellSlot[2].GetComponent<RectTransform>().sizeDelta; // Get size of 2nd skill icon

        // ##### Get Spells Data #####
        string[] datas = LoadSpellData.ReadString();
        for(int id=1 ; id<datas.Length; id++)
        {
            // Debug.Log("ID : " + id + ", Value : " + datas[id]);
            Spell spell = LoadSpellData.CreateSpellData(datas[id]);
            spellsList.Add(spell);
        }

        // ##### Load Spells #####
        for (int i=0; i < spellSlot.Length; i++)
        {
            spellSlot[i].GetComponent<Image>().sprite = spellsList[i].icon; // Get ALl spells icon
            spellSlot[i].GetComponent<SpellReload>().SetSliderValue(spellsList[i].ReloadTime); // Set ReloadTime of Spell
        }
        UpdateSpellsSlot();
    }

    void Update()
    {
        MouseInput();        

        if(isLoading)
        {
            LoadCast();
        }
    }

    void MouseInput()
    {
        float _scrollvar = Input.mouseScrollDelta.y * scrollScale; // Get Mouse Scroll Input

        if(_scrollvar > 0.1) // Scroll Up Check
        {
            SelectedSpellNumber++;
            if(SelectedSpellNumber > spellSlot.Length) // Check if superior to number of skills length
            {
                SelectedSpellNumber = 1; // Loop to first skill
            }
            UpdateSpellsSlot();
        }
        if(_scrollvar < -0.1) // Scroll Down Check
        {
            SelectedSpellNumber--;
            if(SelectedSpellNumber < 1) // Check if inferior than 1
            {
                SelectedSpellNumber = spellSlot.Length;  // Loop to last skill
            }
            UpdateSpellsSlot();
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && spellSlot[SelectedSpellNumber - 1].GetComponent<SpellReload>().isLoaded)
        {
            StartSpellCast();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && spellSlot[SelectedSpellNumber - 1].GetComponent<SpellReload>().isLoaded)
        {
            SpellCast();
        }
    }

    void UpdateSpellsSlot()
    {
        foreach(GameObject _g in spellSlot) // Get all spells icon
        {
            _g.GetComponent<RectTransform>().sizeDelta = iconNormalSize; // Reset size of ALL skill icon
        }

        spellSlot[SelectedSpellNumber - 1].GetComponent<RectTransform>().sizeDelta = iconIncreasedSize; // Increase size of selected skill icon
    }

    void StartSpellCast()
    {
        _gameobject = spellsList[SelectedSpellNumber - 1].gameobject;
        _castType = spellsList[SelectedSpellNumber - 1].castType;
        _manaCost = spellsList[SelectedSpellNumber - 1].manaCost;
        _damage = spellsList[SelectedSpellNumber - 1].damage;
        _loadTime = spellsList[SelectedSpellNumber - 1].loadTime;
        _ReloadTime = spellsList[SelectedSpellNumber - 1].ReloadTime;
        _speed = spellsList[SelectedSpellNumber - 1].speed;
        _zoneSize = spellsList[SelectedSpellNumber - 1].zoneSize;

        LoadSlider.GetComponent<Slider>().maxValue = _loadTime;

        switch(_castType)
        {
            case "Simple Cast":
                // Debug.Log("Simple Cast");
                LoadSlider.GetComponent<Slider>().maxValue = 0.05f;
                isLoading = true;
                break;
            case "Charging Cast":
                // Debug.Log("Charging Cast");
                isLoading = true;
                break;
            case "Zone Cast":
                // Debug.Log("Zone Cast");
                LoadSlider.GetComponent<Slider>().maxValue = 0.05f;
                isLoading = true;
                break;
        }
    }

    void LoadCast()
    {
        Load += Time.deltaTime;
        LoadSlider.GetComponent<Slider>().value = Load;
        if(Load >= _loadTime)
        {
            isLoading = false;
        }
    }

    void SpellCast()
    {
        isLoading = false;
        Load = 0;
        LoadSlider.GetComponent<Slider>().value = Load;
        spellSlot[SelectedSpellNumber - 1].GetComponent<SpellReload>().ResetLoading();

        if(_castType == "Zone Cast") // cast zone
        {
            RaycastHit hitData;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitData, 1000, LayerMask.NameToLayer("Ground")))
            {
                Instantiate(_gameobject, hitData.point, new Quaternion(), GameObject.Find("Instances").transform);
            }
        }
        else
        {
            Instantiate(_gameobject, g_PlayerArm.transform.position, g_PlayerArm.transform.rotation, GameObject.Find("Instances").transform);
        }
        // Debug.Log("Cast");
    }
}
