using UnityEngine;

public class Dot : MonoBehaviour
{
    [SerializeField] private GameObject[] dots;
    [SerializeField] private GameObject house;
    private bool assigned; 
    private bool first;
    private float activeDot;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < dots.Length; i++)
        {
            //dots[i].transform.position = new Vector3(house.transform.position.x + 5,house.transform.position.y + i - 3, 0);
            dots[i].SetActive(false);
        }

        activeDot = 0;
    }

    public void SetDot(float _x, float _y, float _nb)
    {
        first = true;
        for(int i = 0; i < dots.Length; i++)
        {
            //Debug.Log(dots[i].transform.position.x);
            //Debug.Log(house.transform.position.x + 5);
            
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

    public bool isDotMaxxed()
    {
        return activeDot == dots.Length;
    }
}
