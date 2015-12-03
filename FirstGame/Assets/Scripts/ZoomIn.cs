using UnityEngine;
using System.Collections;

public class ZoomIn : MonoBehaviour {

    Vector3 akHip = new Vector3(0.25F, -0.25F, 0.3F);
    Vector3 umpHip = new Vector3(0.25F, -0.4F, 0.3F);
    Vector3 ethanReg = new Vector3(0.25F, -2.25F, -0.35F);
    public float UMPzoomOffsetX = -0.285F;
    public float UMPzoomOffsetY = -0.02F;
    public float AK47zoomOffsetX = -0.25F;
    public float AK47zoomOffsetY = 0.055F;
    public float zoomSpeed = 2.5F;
    public GameObject ak47;
    public GameObject ump45;
    public GameObject ethan;
    public float PosZ = 0.3F;

    bool isZoomed = false;

	// Update is called once per frame
	void Update () 
    {
        Vector3 akZoom = new Vector3(akHip.x + AK47zoomOffsetX, akHip.y + AK47zoomOffsetY, PosZ);
        Vector3 umpZoom = new Vector3(umpHip.x + UMPzoomOffsetX, umpHip.y + UMPzoomOffsetY, PosZ);
        Vector3 ethanZoomAK = new Vector3(ethanReg.x + AK47zoomOffsetX, ethanReg.y , -0.5F);
        Vector3 ethanZoomUMP = new Vector3(ethanReg.x + UMPzoomOffsetX, ethanReg.y + UMPzoomOffsetY, -0.5F);

        if (Input.GetButtonDown("Zoom") && !isZoomed)
        {
            if (ak47.activeInHierarchy)
            {
                transform.localPosition = akZoom;
                ethan.transform.localPosition = ethanZoomAK;
                isZoomed = true;
            }
            else if (ump45.activeInHierarchy)
            {
                transform.localPosition = umpZoom;
                ethan.transform.localPosition = ethanZoomUMP;
                isZoomed = true;
            }

        }
        else if (Input.GetButtonUp("Zoom") && isZoomed)
        {
            if (ak47.activeInHierarchy)
            {
                transform.localPosition = akHip;
                ethan.transform.localPosition = ethanReg;
                isZoomed = false;
            }
            else if (ump45.activeInHierarchy)
            {
                transform.localPosition = umpHip;
                ethan.transform.localPosition = ethanReg;
                isZoomed = false;
            }
        }
      
        if (Input.GetButtonDown("Switch"))
        {
            if (ak47.activeInHierarchy  && !isZoomed)
            {
                ak47.gameObject.SetActive(false);
                ump45.gameObject.SetActive(true);
                
            }
            else if (ump45.activeInHierarchy && !isZoomed)
            {
                ump45.gameObject.SetActive(false);
                ak47.gameObject.SetActive(true);
                
            }
        }


	}

    
}
