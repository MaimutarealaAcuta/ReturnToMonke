using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNAPanel : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text dna_text;
    
    void Start()
    {
        dna_text.SetText("0");
    }

    public void updateDNA(int dna)
    {
        dna_text.SetText(dna.ToString());
    }
}
