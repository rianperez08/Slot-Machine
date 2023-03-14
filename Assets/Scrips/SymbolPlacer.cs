using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolPlacer : MonoBehaviour
{
    public static Sprite[] sprites = null;

    private void Awake()
    {

        if (sprites == null)
            sprites = Resources.LoadAll<Sprite>("figures");
    }

    private void Start()
    {


       loadRandomSprite(transform);
    }

    public void Hey()
    {
        Transform t = transform.parent;
        transform.parent = null;
        for (int i = 1; i < t.GetComponent<Reels>().slices; i++)
        {
            Transform a;
            a = Instantiate(gameObject).gameObject.transform;
            a.RotateAround(t.position, new Vector3(1, 0, 0),
                i * (360f / t.GetComponent<Reels>().slices));
            a.SetParent(t, true);
            //loadRandomSprite(a);
        }
        transform.SetParent(t, true);
    }
    public void loadRandomSprite(Transform t)
    {
        t.GetComponent<SpriteRenderer>().sprite = sprites[
           t.parent.parent.GetComponent<SymbolPool>().PopSymbol()
        ];
    }

    
}
