using UnityEngine;

public class SpellSelector : MonoBehaviour
{
    [SerializeField] int maxSpells = 3; // Set the maximum number of spells
    public int currentSpellIndex = 0;
    [SerializeField] GameObject[] spells;

    void Update()
    {
        // Use mouse wheel to cycle through spells
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel != 0f)
        {
            ChangeSpell((int)Mathf.Sign(mouseWheel));
        }

        // Use number keys to select specific spells
        for (int i = 1; i <= maxSpells; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                SetSpell(i - 1);
            }
        }
    }

    void ChangeSpell(int direction)
    {
        currentSpellIndex = (currentSpellIndex + direction + maxSpells) % maxSpells;
        spells[0].SetActive(false);
        spells[1].SetActive(false);
        spells[2].SetActive(false);
        spells[currentSpellIndex].SetActive(true);
        Debug.Log("Selected Spell: " + currentSpellIndex);
    }

    void SetSpell(int spellIndex)
    {
        if (spellIndex >= 0 && spellIndex < maxSpells)
        {
            currentSpellIndex = spellIndex;
            spells[0].SetActive(false);
            spells[1].SetActive(false);
            spells[2].SetActive(false);
            spells[currentSpellIndex].SetActive(true);
            Debug.Log("Selected Spell: " + currentSpellIndex);
        }
    }
}