using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class CameraFollower : MonoBehaviour
    {
        public static CameraFollower instance { get; private set; }
        public List<GameObject> listOfPlayers { get; private set; }
        private float depth; // used to store old value of the depth (z)

        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null && instance != this)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
                Debug.Log("Multiple Camera detected this camera won't be used");
            }
        }
        private void Start()
        {
            listOfPlayers = new List<GameObject>();
            depth = transform.position.z;
        }

        // Update is called once per frame
        void Update()
        {
            if(listOfPlayers != null || listOfPlayers.Count != 0)
            {
                Vector3 midpoint = Vector3.zero;

                foreach (GameObject element in listOfPlayers)
                {
                    midpoint += element.transform.position;
                }
                midpoint /= 2;


                transform.position = new Vector3(midpoint.x, midpoint.y, depth);
            }
        }
    }
}
