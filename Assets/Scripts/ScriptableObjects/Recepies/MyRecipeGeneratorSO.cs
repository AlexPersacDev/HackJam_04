using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="Prueba")]
public class MyRecipeGeneratorSO : ScriptableObject
{
    [SerializeField]
    private Ranks[] allRanks;

    private List<MyRecipeSO> allRecipes = new List<MyRecipeSO>();

    private void OnEnable()
    {

       
       
    }
    private void GenerateAllRecipes()
    {
        //for (int i = 0; i < allIngredients.Length; i++)
        //{
        //    for (int j = 0; j < allIngredients.Length; j++)
        //    {
        //        MyRecipeSO recipe = CreateInstance<MyRecipeSO>();


        //        AssetDatabase.CreateAsset(recipe, "Assets/NewScripableObject.asset");
        //        AssetDatabase.SaveAssets();

        //        EditorUtility.FocusProjectWindow();

        //        Selection.activeObject = recipe;
        //    }
        //}
    }
}
