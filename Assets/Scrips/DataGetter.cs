using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGetter : MonoBehaviour
{
    
    public static int Data;
    [SerializeField]
    int ID;
   
    Manager manager;
    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<Manager>();

    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the other object has a certain tag

        Data = int.Parse(other.gameObject.tag);

        manager.Catch(ID, Data);

     //   print(Data);
    }

}
