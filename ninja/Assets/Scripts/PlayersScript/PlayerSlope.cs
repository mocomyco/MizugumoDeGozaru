using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSlope : MonoBehaviour {
    public enum Player
    {
        Player1, Player2,
    }

    [SerializeField] private float initialSlope;
    [SerializeField] private float recoveryRate;
    [SerializeField] private float stunTime;
    [SerializeField] private Player player;//

    public float currentSlope;
    //private float currentStunTime;
    //private bool isStunned;
    private Dictionary<float, string> playerState = 
        new Dictionary<float, string>();

    public Rigidbody playerRig;

    public Vector3 SendDamageVec;
    public DamageSeni _DamageSeni;

    void Start() {
        
        currentSlope = initialSlope;

        playerState.Add(90, "Normal");
        playerState.Add(60, "Slanted");
        playerState.Add(30, "Falling");
        playerState.Add(0, "Down");
    }

    // Update is called once per frame
    void Update() {
        if (currentSlope == initialSlope) return;

        //if(isStunned)
        //{
        //    currentStunTime += Time.deltaTime;
        //    if (currentStunTime >= stunTime) currentStunTime = 0;
        //    if (currentStunTime == 0) isStunned = false;

        //    return;
        //}

        if (currentSlope <= 0) currentSlope = 0;

        if (currentSlope <= initialSlope)
        {
            if(currentSlope <0)
            currentSlope += Time.deltaTime * recoveryRate;
        }
        else
            currentSlope = initialSlope;

        
        SendDamageVec = ((transform.position).normalized) * ((90 - currentSlope) / 90);
    }

    public void DamageVec(Vector3 vec)//衝突時、方向ベクトルを取得してキャラの傾く方向を指定。ダメージ量を乗算してSend
    {
        if (playerRig == null) return;

        Debug.Log("向き"+　(vec - transform.position).normalized);
        Debug.Log(currentSlope);
        Debug.Log("向き+威力" + ((vec - transform.position).normalized)*((90-currentSlope)/90));
        Debug.Log("向き+威力 角度変換" + (((vec - transform.position).normalized) * ((90 - currentSlope) / 90)));
       
        SendDamageVec = (((vec - transform.position).normalized)*((90-currentSlope)/90));
        _DamageSeni.SendMessage("Damaged");
    }

    public void Damaged(int value) {
        //if (isStunned) return;

        currentSlope -= value;
        //isStunned = true;
    }

    public float CurrentSlope
    {
        get { return currentSlope; }
    }

    public string CurrentState()
    {
        foreach(var stateDict in playerState)
        {
            if (currentSlope >= stateDict.Key)
                return stateDict.Value;
        }

        return "";
    }

    public void Finish()
    {
        switch (player)
        {
            case Player.Player1:

                break;
            case Player.Player2:

                break;
        }
    }

    //public bool IsStunned
    //{
    //    get { return isStunned; }
    //}
}
