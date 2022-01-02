using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform tf;   // Main CameraのTransform
    Camera cam;     // Main CameraのCamera
    Rigidbody hrb;  // Human(親オブジェクト)のRigidbody

    // Start is called before the first frame update
    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>();
        cam = this.gameObject.GetComponent<Camera>();
        hrb = transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!(Input.GetKey(KeyCode.LeftShift)) &&
             (Input.GetKey(KeyCode.UpArrow)))
        {
            // 人を前進させる
            hrb.position = hrb.position + (transform.forward * Time.deltaTime * 7.0f);
        }
        else if(!(Input.GetKey(KeyCode.LeftShift)) &&
                 (Input.GetKey(KeyCode.DownArrow)))
        {
            // 人を後ずさり
            hrb.position = hrb.position - (transform.forward * Time.deltaTime * 7.0f);
        }

        if (!(Input.GetKey(KeyCode.LeftShift)) &&
             (Input.GetKey(KeyCode.LeftArrow)))
        {
            // 人を左へカニ歩き
            hrb.position = hrb.position - (transform.right * Time.deltaTime * 7.0f);
        }
        else if (!(Input.GetKey(KeyCode.LeftShift)) &&
                  (Input.GetKey(KeyCode.DownArrow)))
        {
            // 人を右へカニ歩き
            hrb.position = hrb.position + (transform.right * Time.deltaTime * 7.0f);
        }

        if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.UpArrow)))
        {
            // カメラを上へ回転
            transform.Rotate(new Vector3(-2.0f, 0.0f, 0.0f));
        }
        else if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.DownArrow)))
        {
            // カメラを下へ回転
            transform.Rotate(new Vector3(2.0f, 0.0f, 0.0f));
        }

        if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.LeftArrow)))
        {
            // カメラを左へ回転
            transform.Rotate(new Vector3(0.0f, -2.0f, 0.0f));
        }
        else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow))
        {
            // カメラを右へ回転
            transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));
        }

        if(Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.R)))
        {
            // カメラの回転をリセット
            tf.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
