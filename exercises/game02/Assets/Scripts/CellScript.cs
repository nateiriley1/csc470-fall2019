using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
	public bool alive = false;
	public bool nextAlive;
	bool prevAlive;
	public int x = -1;
	public int y = -1;

	Renderer renderer;

	// Start is called before the first frame update
	void Start()
    {
		prevAlive = alive;
	}

    // Update is called once per frame
    void Update()
    {
		if (prevAlive != alive) {
			updateColor();
		}

        if (this.alive)
        {
            gameObject.tag = "Alive";
        }
        else
        {
            gameObject.tag = "Dead";
        }

		prevAlive = alive;
	}

	public void updateColor()
	{
		if (renderer == null) {
			renderer = gameObject.GetComponent<Renderer>();
		}

		if (this.alive) {
			renderer.material.color = Color.green;
           
        } else {
			renderer.material.color = Color.red;
            gameObject.tag = "Dead";
        }
	}

	//private void OnMouseDown()
	//{
		//alive = !alive;
	//}
}
