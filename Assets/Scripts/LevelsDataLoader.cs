using System;
 using System.Collections.Generic;
 using System.Linq;
 using UnityEngine;
 
 public class LevelsDataLoader : MonoBehaviour
 {
     private const string LevelsPath = "Levels";
 
     public Dictionary<int, LevelsData.LevelData> ReadLevelsData()
     {
         var jsonFile = Resources.Load(LevelsPath, typeof(TextAsset)) as TextAsset;
         if (jsonFile == null)
         {
             throw new ApplicationException("Levels file is not accessible");
         }
 
         var loadedData = JsonUtility.FromJson<LevelsData>(jsonFile.text);
         return loadedData.levels.ToDictionary(level => level.number, level => level);
     }
 }