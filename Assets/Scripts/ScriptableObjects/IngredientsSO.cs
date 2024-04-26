using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredient")]
public class IngredientsSO : ScriptableObject
{
    [SerializeField] private string name;
}
