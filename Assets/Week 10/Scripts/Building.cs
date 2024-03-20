using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject well;
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject dummy;
    Coroutine building;
    [SerializeField] float timer;

    [SerializeField] float maxTimer = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        building = StartCoroutine(buidling());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if ( timer > maxTimer + Time.deltaTime)
        {
            timer = 0;
        }
    }

    IEnumerator buidling()
    {
         
        
        
        while(well.transform.localScale.x < 1)
        {
            well.transform.localScale = Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f), timer);
            
            yield return null;
            //Debug.Log("building well");

        }

        while (rock.transform.localScale.x < 1)
        {
            rock.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, timer);
            yield return null;
            Debug.Log("building rock");

        }


       
        while (dummy.transform.localScale.x < 1)
        {
            dummy.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, timer);
            yield return null;
            Debug.Log("building dummy");
        }
        Debug.Log("completed");


    }



}
