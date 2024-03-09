using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNAPanel : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text dna_text;

    [SerializeField]
    private Image dna_icon;
    
    void Start()
    {
        dna_text.SetText("0");
    }

    public void updateDNA(int dna)
    {
        dna_text.SetText(dna.ToString());
    }

    public void insufficientFunds()
    {
        StartCoroutine(insufficientFundsAnimation());
    }
    
    public IEnumerator insufficientFundsAnimation()
    {
        Color color = new Color(1, 1, 1, 1);
        
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            color.g = i;
            color.b = i;
            dna_icon.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        for (float i = 0; i < 1; i += 0.1f)
        {
            color.g = i;
            color.b = i;
            dna_icon.color = color;
            yield return new WaitForSeconds(0.01f);
        }

    }
}
