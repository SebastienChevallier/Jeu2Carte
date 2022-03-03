using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoZones : MonoBehaviour
{
    void OnDrawGizmos()
    {
        BoxCollider col = transform.gameObject.GetComponent<BoxCollider>();
        if (tag == "Offensive")
            Gizmos.color = new Color(1, 0, 0, 0.5f);
        else if (tag == "Defensive")
            Gizmos.color = new Color(1, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(col.size.x, col.size.y, col.size.z));
    }
}