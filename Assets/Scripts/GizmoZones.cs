using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoZones : MonoBehaviour
{
    private BoxCollider col;

    void OnDrawGizmos()
    {
        col = transform.gameObject.GetComponent<BoxCollider>();
        if (tag == "Offensive")
            Gizmos.color = Color.red;
        else if (tag == "Defensive")
            Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(col.size.x, col.size.y, col.size.z));
    }
}
