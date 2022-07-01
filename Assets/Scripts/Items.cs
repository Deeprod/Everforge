using UnityEngine;

public class Items : MonoBehaviour
{
    //[SerializeField] private GameObject[] dots;
    public GameObject[] dots;
    private bool first;
    private float activeDot;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] _dots = new GameObject[GameObject.Find("DotContainer").transform.childCount];
        dots = _dots;

        for (int i = 0; i < dots.Length; i++)
        {
            dots[i] = GameObject.Find("DotContainer").transform.GetChild(i).gameObject;
        }
 
        for(int i = 0; i < dots.Length; i++)
        {
            dots[i].SetActive(false);
            dots[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Kiwi");
        }

        activeDot = 0;
    }

    public void SetDot(float _x, float _y, float _nb)
    {
        first = true;
        for(int i = 0; i < dots.Length; i++)
        {            
            if(!dots[i].activeInHierarchy && first)
            {
                dots[i].SetActive(true);
                dots[i].transform.position = new Vector3(_x + 2,_y + _nb, 0);
                first = false;
            }
        }

        activeDot += 1;
    }

    public void RemoveDot(float _x, float _y, float _nb)
    {
        for(int i = 0; i < dots.Length; i++)
        {
            if(dots[i].activeInHierarchy)
            {
                if(dots[i].transform.position == new Vector3(_x + 2,_y + _nb, 0))
                {
                    dots[i].SetActive(false);
                }
            }
        }

        activeDot -= 1;
    }

    public bool isDotFull()
    {
        return activeDot == dots.Length;
    }

    public bool isDotEmpty()
    {
        return activeDot == 0;
    }
}
