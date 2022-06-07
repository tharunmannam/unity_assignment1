using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject cubesPrefab;

    [SerializeField]
    private GameObject cylindersPrefab;

    [SerializeField]
    private GameObject spheresPrefab;

    

    [SerializeField]
    private GameObject _cube;
    [SerializeField]
    private GameObject _sphere;
    [SerializeField]
    private GameObject _cylinder;


    private Renderer cubeRenderer;
    private Renderer sphereRenderer;
    private Renderer cylinderRenderer;

    [SerializeField]
    private Toggle _cubeToggle  , _sphereToggle , _cylinderToggle;

    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = _cube.GetComponent<Renderer>();
        sphereRenderer = _sphere.GetComponent<Renderer>();
        cylinderRenderer = _cylinder.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void SetCubeColor()
    {
        if (_cubeToggle.isOn)
        {
            cubeRenderer.sharedMaterial.SetColor("_Color", Color.red);
        }
        else
        {
            cubeRenderer.sharedMaterial.SetColor("_Color", Color.white);
        }
    }

    public void SetCylinderColor()
    {
        if (_cylinderToggle.isOn)
        {
            cylinderRenderer.sharedMaterial.SetColor("_Color", Color.blue);
        }
        else
        {
            cylinderRenderer.sharedMaterial.SetColor("_Color", Color.white);
        }
    }

    public void SetSphereColor()
    {
        if (_sphereToggle.isOn)
        {
            sphereRenderer.sharedMaterial.SetColor("_Color", Color.green);
        }
        else
        {
            sphereRenderer.sharedMaterial.SetColor("_Color", Color.white);
        }

    }


    public void setCubeToggleValueOff()
    {
        _cubeToggle.isOn = false;
    }

    public void setSphereToggleValueOff()
    {
        _sphereToggle.isOn = false;
    }

    public void setCylinderToggleValueOff()
    {
        _cylinderToggle.isOn = false;
    }

}
