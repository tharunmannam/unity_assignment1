using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab;

    [SerializeField]
    private GameObject _cubesParent;

    
    [SerializeField]
    private GameObject _cubeToggle;


    private UIManager _uiManager;

    [SerializeField]
    private float _speed = 3.5f;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GetComponent<UIManager>();

        _rigid = GetComponent<Rigidbody>();

        _cubesParent = GameObject.Find("Cubes");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = transform.position;
        currPos.z = 0;
        transform.position = currPos;


        if(_cubesParent.transform.childCount == 0)
        {
            _cubeToggle.SetActive(false);
        }

        checkBoundaries();
        


    }

    public void GenerateNew()
    {
        Vector3 pos = new Vector3(Random.Range(-5f,11f), Random.Range(-3.5f, 5f), 0);
        GameObject newCube = Instantiate(_cubePrefab, pos, Quaternion.identity);
        newCube.transform.parent = _cubesParent.transform;
        _cubeToggle.SetActive(true);
        _uiManager.setCubeToggleValueOff();
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
       

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        

    }


    void checkBoundaries()
    {
        if (transform.position.x >= 9f)
        {
            transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        }
        
        if(transform.position.x <= -9f)
        {
            transform.position = new Vector3( -9f, transform.position.y, transform.position.z);
        }

        if(transform.position.y >= 6.0f)
        {
            transform.position = new Vector3(transform.position.x,6f, transform.position.z);
        }

        if (transform.position.y <= -4f)
        {
            transform.position = new Vector3(transform.position.x,-4f, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == this.gameObject.tag)
        {
            
            if(other.rigidbody.velocity.magnitude < _rigid.velocity.magnitude)
            {
                Destroy(other.gameObject);
            }
            else
            {
                // Debug.Log("Entered here");
                Destroy(this.gameObject);
            }
            
        }
    }

}
