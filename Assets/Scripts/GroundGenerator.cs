using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    public Transform groundPoint;
    public ObjectPooler[] groundPoolers;
    private float[] groundWidths;

    // Start is called before the first frame update
    void Start()
    {
        groundWidths = new float[groundPoolers.Length];

        for (int i = 0; i < groundPoolers.Length; i++)
        {
            groundWidths[i] = groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x < groundPoint.position.x)
        {
            int random = Random.Range(0, groundPoolers.Length);
            float distance = groundWidths[random]/2;
            transform.position = new Vector3(
                transform.position.x + distance,
                transform.position.y,
                transform.position.z
                );

            GameObject ground = groundPoolers[random].GetPooledGameObject();
            ground.transform.position = transform.position;
            ground.SetActive(true);

            transform.position = new Vector3(
               transform.position.x + distance,
               transform.position.y,
               transform.position.z
               );
        }
        
    }
}
