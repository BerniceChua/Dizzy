using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateTrap : MonoBehaviour {
    [SerializeField] TimeElapsed m_timeElapsed;
    [SerializeField] GameObject m_mainCanvas;

    string m_pathToFont = "Assets/TextMesh Pro/Fonts/Bangers";
    Font m_someFancyFont;

    Ray m_shootRay = new Ray();

    [SerializeField] Rect m_box;
    [SerializeField] GameObject m_trap;
    [SerializeField] Vector2 m_direction;
    [SerializeField] float m_rangeOrDistanceOfBoxcast = 100.0f;
    [SerializeField] RaycastHit hit;
    [SerializeField] LayerMask m_layermaskOfTargetGamePiece;

    GameObject m_thisCanvas;

    [SerializeField] Camera m_cameraTrap;

    void OnDrawGizmos()
    {
        //if (hit != null)
        //{
        //    //foreach (var h in hits)
        //    //{
        //        Gizmos.color = Color.white;
        //        Gizmos.DrawCube(hit.collider.transform.position, Vector2.one * 0.16f);
        //    //}
        //}
        if (hit.collider != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(hit.collider.transform.position, Vector2.one * 0.16f);
        }
        Gizmos.color = Color.green;
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + m_box.center, this.transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, m_box.size);
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + m_box.center + (m_direction.normalized * m_rangeOrDistanceOfBoxcast), this.transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, m_box.size);
        Gizmos.color = Color.cyan;
        Gizmos.matrix = Matrix4x4.TRS((Vector2)this.transform.position + m_box.center, Quaternion.identity, Vector3.one);
        Gizmos.DrawLine(Vector2.zero, m_direction.normalized * m_rangeOrDistanceOfBoxcast);
    }

    // Use this for initialization
    void Start () {
        m_layermaskOfTargetGamePiece = LayerMask.GetMask("Player");
        m_someFancyFont = (Font)Resources.Load(m_pathToFont);

        //m_thisCanvas.transform.position.x = Screen.width;
        //m_thisCanvas.transform.position.y = Screen.height;
        m_box.height = Screen.height;
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(Physics2D.BoxCast(
        //    (Vector2)this.transform.position + m_trap.center,
        //    m_trap.size,
        //    this.transform.eulerAngles.z,
        //    m_direction,
        //    m_rangeOrDistanceOfBoxcast,
        //    m_layermaskOfTargetGamePiece
        //));
        //Debug.Log("(Vector2)this.transform.position + m_trap.center + " + (Vector2)this.transform.position + m_trap.center);
        //Debug.Log("m_trap.size = " + m_trap.size);
        //Debug.Log("this.transform.eulerAngles.z = " + this.transform.eulerAngles.z);
        //Debug.Log("m_direction = " + m_direction);
        //Debug.Log("m_rangeOrDistanceOfBoxcast = " + m_rangeOrDistanceOfBoxcast);
        //Debug.Log("m_layermaskOfTargetGamePiece = " + m_layermaskOfTargetGamePiece.value);

        //if (Physics2D.BoxCast(
        //    /*(Vector2)this.transform.position + */m_trap.center,
        //    m_trap.size,
        //    this.transform.eulerAngles.z,
        //    m_direction,
        //    m_rangeOrDistanceOfBoxcast,
        //    m_layermaskOfTargetGamePiece
        //)) {
        //    Debug.Log("My raycast has hit something!!! ^__^");
        //    /// Add explosions animation & sounds here

        //    m_mainCanvas.AddComponent<Text>().fontSize = 300;
        //    m_mainCanvas.AddComponent<Text>().font = m_someFancyFont;
        //    m_mainCanvas.AddComponent<Text>().text = "Game Over";

        //    m_timeElapsed.m_gameOver = true;
        //    m_timeElapsed.GameOver();
        //}

        //if (Physics.Raycast(m_shootRay, out hit, m_range, m_gamePiece)) {
        //    Debug.Log("My raycast has hit something!!! ^__^");
        //    /// Add explosions animation & sounds here

        //    m_mainCanvas.AddComponent<Text>().fontSize = 300;
        //    m_mainCanvas.AddComponent<Text>().font = m_someFancyFont;
        //    m_mainCanvas.AddComponent<Text>().text = "Game Over";

        //    m_timeElapsed.m_gameOver = true;
        //    m_timeElapsed.GameOver();
        //}

        //if (m_layermaskOfTargetGamePiece != 0) {
        //    //Debug.Log("My raycast has hit something!!! ^__^");
        //    ///// Add explosions animation & sounds here

        //    //m_mainCanvas.AddComponent<Text>().fontSize = 300;
        //    //m_mainCanvas.AddComponent<Text>().font = m_someFancyFont;
        //    //m_mainCanvas.AddComponent<Text>().text = "Game Over";

        //    m_timeElapsed.m_gameOver = true;
        //    m_timeElapsed.GameOver();
        //}

        //if (Physics.Raycast(m_trap.transform.position, m_trap.transform.forward, m_rangeOrDistanceOfBoxcast, m_layermaskOfTargetGamePiece)) {
        //    if (hit.collider.CompareTag("Player"))
        //        Debug.Log("We're here!!!");
        //}

        //if (m_cameraTrap.ScreenToWorldPoint(Vector3.zero)) {
        //    m_cameraTrap.scree
        //}
    }

    //void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.CompareTag("Player")) {
    //      Debug.Log("We're here!!!");
    //    }
    //}
}