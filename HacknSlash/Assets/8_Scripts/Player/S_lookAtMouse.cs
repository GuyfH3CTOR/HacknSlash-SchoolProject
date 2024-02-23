using UnityEngine;

public class S_lookAtMouse : MonoBehaviour
{
    [SerializeField] LayerMask lm_layerMask;
    RaycastHit hitData;

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitData, 1000, lm_layerMask))
        {
            transform.LookAt( new Vector3 (hitData.point.x,transform.position.y,hitData.point.z) );
        }
    }
}
