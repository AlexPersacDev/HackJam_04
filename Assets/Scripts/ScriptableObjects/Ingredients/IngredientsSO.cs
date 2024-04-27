using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredient")]
public class IngredientsSO : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Ranks rank;

    public Ranks Rank => rank;
}
