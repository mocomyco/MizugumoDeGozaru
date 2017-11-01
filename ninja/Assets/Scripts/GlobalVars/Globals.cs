using UnityEngine;

public class Globals : Singleton<Globals>
{
    protected Globals() { } // guarantee this will be always a singleton only - can't use the constructor!

    public string persistentString = "test";
    public int playCount = 0;
}