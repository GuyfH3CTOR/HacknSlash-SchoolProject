using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleCollision : MonoBehaviour
{
    public PoisonSpray poisonSpray;

    void OnParticleCollision(GameObject _gameObject){
        // Debug.Log("collision : "+_gameObject);
        if(_gameObject.GetComponent<Entity_Damagable>()){
            poisonSpray.OnHit(_gameObject.GetComponent<Entity_Damagable>());
        }
    }
}
