using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeath : MonoBehaviour
{
    private GameManager manager;

    private void Start () {
        manager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            manager.ChangeScene("end");
            StartCoroutine(EndJump());
        }
    }

    IEnumerator EndJump() {
        yield return new WaitForSeconds(2.03f);
        manager.ChangeScene("SampleScene");
    }
}
