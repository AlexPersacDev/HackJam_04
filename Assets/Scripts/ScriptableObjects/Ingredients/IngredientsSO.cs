using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient")]
public class IngredientsSO : ScriptableObject
{
    [SerializeField] private string ingredientName;
    [SerializeField] private Ranks rank;

    public Ranks Rank => rank;

    public string IngredientName { get => ingredientName;}
}
