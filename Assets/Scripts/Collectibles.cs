using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private GameObject collectibles;
    private float nb;
    [SerializeField] private float maxNb;
    
    void Awake()
    {
        nb = 0;
        collectibles = transform.parent.parent.gameObject;
    }

    // Start is called before the first frame update
    void OnMouseOver()
    {

        if(Input.GetMouseButtonDown(0) && nb != maxNb)
        {
            
            Debug.Log("Left Click" + nb);
            nb = Mathf.Min(maxNb, nb + 1);
            collectibles.GetComponent<Dot>().SetDot(transform.position.x, transform.position.y, nb);
        }
        else if(Input.GetMouseButtonDown(1) && nb != 0)
        {
            Debug.Log("Right Click" + nb);     
            collectibles.GetComponent<Dot>().RemoveDot(transform.position.x, transform.position.y, nb);
            nb = Mathf.Max(0, nb - 1);
        }
    }
}
