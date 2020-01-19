using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
        [SerializeField]
        int _channel;

        public int Channel  {
            get { return _channel; }
            set { _channel = value; }
        }

               [SerializeField]
        Transform _world;

        public Transform World  {
            get { return _world; }
            set { _world = value; }
        }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var worlds = GameObject.FindGameObjectsWithTag("world");
        World = worlds[0].transform;
        
    }
}
