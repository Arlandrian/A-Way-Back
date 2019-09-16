using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    public BackgroundLayer [] backgroundLayers;
    public Color topColor;
    
    // Use this for initialization
    void Start () {
        //DontDestroyOnLoad(this.gameObject);
        InitAllLayers();

    }
    private void InitAllLayers() {
        for (int i = 0; i < backgroundLayers.Length; i++) {
            InitBackground(backgroundLayers[i]);
        }
    }

    private void InitBackground(BackgroundLayer layer) {
        GameObject gameObjRef = layer.gameObjRef;
        GameObject gameObject1, gameObject2;

        gameObject1 = Instantiate(gameObjRef, Vector3.up*layer.yPos, Quaternion.identity);
        gameObject1.transform.SetParent(this.transform);
        gameObject1.GetComponent<ScrollingObject>().scrollRatio = layer.scrollSpeedRatio;
        gameObject1.GetComponent<ScrollingObject>().row = layer.row;

        //layer.width = gameObject1.GetComponent<BoxCollider2D>().size.x;
        //layer.height = gameObject1.GetComponent<BoxCollider2D>().size.y;
        if (layer.row == 0) {
            Utils.backgroundSize.x = layer.GetWidth();// gameObject1.GetComponent<BoxCollider2D>().size.x;
            Utils.backgroundSize.y = layer.GetHeight();// gameObject1.GetComponent<BoxCollider2D>().size.y;
        }

        Vector3 pos = Vector3.right * layer.GetWidth() + Vector3.up * layer.yPos;
        gameObject2 = Instantiate(gameObjRef, pos, Quaternion.identity);
        gameObject2.transform.SetParent(this.transform);
        gameObject2.transform.Rotate(Vector3.up * 180f);
        gameObject2.GetComponent<ScrollingObject>().scrollRatio = layer.scrollSpeedRatio;
        gameObject2.GetComponent<ScrollingObject>().row = layer.row;

    }
    public SpriteRenderer skyGradientInGameRef;
    public Sprite level2Sprite;
    public Sprite level2SkyGradient;

    public void ChangeLayerImage(int layerPos) {

        SpriteRenderer obj1 = transform.GetChild(layerPos).GetComponent<SpriteRenderer>();
        SpriteRenderer obj2 = transform.GetChild(layerPos+1).GetComponent<SpriteRenderer>();
        obj1.sprite = level2Sprite;
        obj2.sprite = level2Sprite;

        skyGradientInGameRef.sprite = level2SkyGradient;
    }

    [System.Serializable]
    public struct BackgroundLayer {
        public int row;

        public float GetHeight() {
            return gameObjRef.GetComponent<BoxCollider2D>().size.y;
        }
        public float GetWidth() {
            return gameObjRef.GetComponent<BoxCollider2D>().size.x;
        }
        public float scrollSpeedRatio;
        public GameObject gameObjRef;
        public float yPos;

        public BackgroundLayer(int row,GameObject reference,float scrollSpeedRatio,float yPos) {
            this.row = row;
            gameObjRef = reference;
            this.scrollSpeedRatio = scrollSpeedRatio;
            this.yPos = yPos;
        }
    }
}
/*    private Color calculateAvgColor(Color [] colors) {
        Vector3 colorSum = Vector3.zero;
        for (int i = 0; i < colors.Length; i++) {
            colorSum.x += colors[i].r;
            colorSum.y += colors[i].g;
            colorSum.z += colors[i].b;
        }
        colorSum.x = colorSum.x / colors.Length;
        colorSum.x = colorSum.y / colors.Length;
        colorSum.x = colorSum.z / colors.Length;
        return new Color(colorSum.x,colorSum.y,colorSum.z);
    }

*/