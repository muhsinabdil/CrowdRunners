using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level", order = 0)]//! 3 paremetre alır
public class LevelSO : ScriptableObject
{

    public Chunk[] chunks;

}
