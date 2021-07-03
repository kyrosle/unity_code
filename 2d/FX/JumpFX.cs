using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFX : MonoBehaviour
{
    public void Finished() {
        gameObject.SetActive(false);
    }
}
