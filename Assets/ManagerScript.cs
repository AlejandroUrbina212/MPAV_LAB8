using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public Camera fpsCamera;
    public Light mSpotLight;
    public Text nameText;
    private AudioSource mAudioSource;
    public AudioClip maudioClip;
    private bool isEnabled;

    // Start is called before the first frame update
    void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray myRay = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hitInfo;


        if (Input.GetMouseButtonDown(0))

        {   
            if (mSpotLight)
            {
                if (mAudioSource)
                {
                    mSpotLight.enabled = !isEnabled;
                    isEnabled = !isEnabled;
                    mAudioSource.PlayOneShot(maudioClip);
                }
                
            }
            
        }

        if (nameText)
        {
            if (Physics.Raycast(myRay, out hitInfo))
            {
                if (hitInfo.collider.tag == "cube")
                {
                    nameText.text = "Esto es un cubo";
                } else
                {
                    nameText.text = "";
                }
            }
        }




    }
}
