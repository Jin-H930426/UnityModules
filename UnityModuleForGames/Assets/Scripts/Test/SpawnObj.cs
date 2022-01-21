using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public string path = "";
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            JHModule.Manager.resourcesManager.Instantiate<JHModule.Charactere.CharacterController>(path, transform);
        }
    }

    // Update is called once per frame
    
}
