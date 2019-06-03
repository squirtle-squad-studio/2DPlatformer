using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserCamera
{
    public class CameraFollower : MonoBehaviour
    {
        public static CameraFollower instance { get; private set; }
        public List<GameObject> listOfPlayers { get; private set; }
        private Camera cam;

        // Start is called before the first frame update
        void Awake()
        {
            // Only one should exist
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
            cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            /**
             * Move the camera at the midpoint of the characters.
             */
            if(listOfPlayers != null)
            {
                if (listOfPlayers.Count == 1)
                {
                    // Moves camera to the character
                    transform.position = new Vector3(listOfPlayers[0].transform.position.x, listOfPlayers[0].transform.position.y, transform.position.z);
                }
                else if (listOfPlayers.Count > 1)
                {
                    // Find midpoint
                    Vector3 midpoint = Vector3.zero;
                    foreach (GameObject element in listOfPlayers)
                    {
                        midpoint += element.transform.position;
                    }
                    midpoint /= 2;

                    // Move camera
                    transform.position = new Vector3(midpoint.x, midpoint.y, transform.position.z);
                }
            }
        }
    }
}
