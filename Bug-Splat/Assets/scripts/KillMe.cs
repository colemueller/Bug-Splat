using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMe : MonoBehaviour
{
    public void KillThis()
    {
        GameObject.Destroy(this.gameObject);
    }
}
