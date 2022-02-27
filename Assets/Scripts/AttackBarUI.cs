using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBarUI : MonoBehaviour
{
    public Transform target;

    public Image thisImage;

    private _PersonnagesManager scriptPlayer;

    void Start()
    {
        scriptPlayer = transform.parent.parent.GetComponent<_PersonnagesManager>();
    }

    void Update()
    {
        transform.LookAt(target);
        thisImage.fillAmount = scriptPlayer.attackBar / 100;
    }
}
