using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entity_Damagable : MonoBehaviour
{    
    [Header("References")]
    public GameObject entity;
    public GameObject Slider;

    private Slider lifeSlider;
    private Transform playerCamera;

    [Space]

    [Header("Life Settings")]
    public float life = 100;
    public float maxLife = 100;
    public bool Shield;
    public float shield;

    void Start()
    {
        lifeSlider = Slider.GetComponent<Slider>();
        lifeSlider.maxValue = maxLife;
        lifeSlider.value = life;

        playerCamera = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(playerCamera);
    }

    public void ExternalInitialization(GameObject _entity, float _maxLife)
    {
        entity = _entity;
        maxLife = _maxLife;

        lifeSlider.maxValue = maxLife;
        lifeSlider.value = life;
    }

    public void UpdateLife(float value)
    {
        life = life + value;
        lifeSlider.value = life;
        Slider.SetActive(true);

        StartCoroutine(ColorEffect());

        if(life <= 0)
        {
            Destroy(entity);
        }
    }
    
    IEnumerator ColorEffect()
    {
        Material _mat = entity.GetComponent<Renderer>().material;
        Color _color = entity.GetComponent<Renderer>().material.color;

        _color = _mat.color;
        _mat.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        _mat.color = _color;
    }
}
