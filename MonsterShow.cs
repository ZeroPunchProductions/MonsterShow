using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShow : MonoBehaviour
{
    public Camera m;
    public GameObject cam;
    public Light flash;
    float flashAmount = 15;
    private bool isFlash;
    private bool timer;

    // Start is called before the first frame update
    void Start()
    {
        isFlash = false;
        timer = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && cam.activeSelf == true && isFlash == false)
        {
            StartCoroutine("DisableMask");
            timer = true;
        }

        if (timer == true && flash.intensity < 25)
        {
            flash.intensity += 60 * Time.deltaTime ;
        }
        else if (timer == false && flash.intensity > 0)
        {
            flash.intensity -= 60 * Time.deltaTime;
        }

    }
    private void Show()
    {
        m.cullingMask |= 1 << LayerMask.NameToLayer("Monster");
    }

    private void Hide()
    {
        m.cullingMask &= ~(1 << LayerMask.NameToLayer("Monster"));
    }
    IEnumerator DisableMask()
    {
        isFlash = true;
        Show();


        yield return new WaitForSeconds(.5f);
        Hide();
        timer = false;
        yield return new WaitForSeconds(2);
        isFlash = false;
        
    }

    
}
