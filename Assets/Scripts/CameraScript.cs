using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject objFollowing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // quem esta seguindo

        // seguir
        Follow(objFollowing);
    }

    private void Follow(GameObject obj)
    {
        this.transform.position = obj.transform.position + new Vector3(0f, 31f, -7.5f);
    }
}
