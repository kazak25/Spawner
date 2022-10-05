using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _cube;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var newCube = Instantiate(_cube);
            newCube.transform.position = new Vector3(Random.Range(-20, 20), 30, 10);
        }
    }
}
