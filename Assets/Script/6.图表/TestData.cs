using M_Chart;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using FontData = M_Chart.FontData;

public class TestData : MaskableGraphic
{
    [SerializeField] public Font font;
    // void Start()
    // {
    //     TextGenerationSettings settings = new TextGenerationSettings();
    //     settings.textAnchor = TextAnchor.MiddleCenter;
    //     settings.color = Color.red;
    //     settings.generationExtents = new Vector2(500.0F, 200.0F);
    //     settings.pivot = Vector2.zero;
    //     settings.richText = true;
    //     settings.font = font;
    //     settings.fontSize = 32;
    //     settings.fontStyle = FontStyle.Normal;
    //     settings.verticalOverflow = VerticalWrapMode.Overflow;
    //     TextGenerator generator = new TextGenerator();
    //     generator.Populate("I am a string", settings);
    //     Debug.Log("I generated: " + generator.vertexCount + " verts!");
    // }

    [TextArea(3, 10)][SerializeField] protected string m_Text = String.Empty;
    [SerializeField] private FontData m_FontData = FontData.defaultFontData;

    public float pixelsPerUnit
    {
        get
        {
            var localCanvas = canvas;
            if (!localCanvas)
                return 1;
            // For dynamic fonts, ensure we use one pixel per pixel on the screen.
            if (!font || font.dynamic)
                return localCanvas.scaleFactor;
            // For non-dynamic fonts, calculate pixels per unit based on specified font size relative to font object's own font size.
            if (m_FontData.fontSize <= 0 || font.fontSize <= 0)
                return 1;
            return font.fontSize / (float)m_FontData.fontSize;
        }
    }
    private TextGenerator m_TextCache;
    readonly UIVertex[] m_TempVerts = new UIVertex[4];
    public TextGenerator cachedTextGenerator
    {
        get { return m_TextCache ?? (m_TextCache = (m_Text.Length != 0 ? new TextGenerator(m_Text.Length) : new TextGenerator())); }
    }
    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        Vector2 extents = rectTransform.rect.size;

        TextGenerationSettings settings = new TextGenerationSettings();
        settings.textAnchor = TextAnchor.MiddleCenter;
        settings.color = Color.red;
        settings.generationExtents = extents;
        settings.pivot = Vector2.zero;
        settings.richText = true;
        settings.font = font;
        settings.fontSize = 32;
        settings.fontStyle = FontStyle.Normal;
        settings.verticalOverflow = VerticalWrapMode.Overflow;

        cachedTextGenerator.PopulateWithErrors("I am a string", settings, gameObject);

        IList<UIVertex> verts = cachedTextGenerator.verts;
        float unitsPerPixel = 1 / pixelsPerUnit;
        int vertCount = verts.Count;


        if (vertCount <= 0)
        {
            toFill.Clear();
            return;
        }

        Vector2 roundingOffset = new Vector2(verts[0].position.x, verts[0].position.y) * unitsPerPixel;
        roundingOffset = PixelAdjustPoint(roundingOffset) - roundingOffset;
        toFill.Clear();
        if (roundingOffset != Vector2.zero)
        {
            for (int i = 0; i < vertCount; ++i)
            {
                int tempVertsIndex = i & 3;
                m_TempVerts[tempVertsIndex] = verts[i];
                m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
                m_TempVerts[tempVertsIndex].position.x += roundingOffset.x;
                m_TempVerts[tempVertsIndex].position.y += roundingOffset.y;
                if (tempVertsIndex == 3)
                    toFill.AddUIVertexQuad(m_TempVerts);
            }
        }
        else
        {
            for (int i = 0; i < vertCount; ++i)
            {
                int tempVertsIndex = i & 3;
                m_TempVerts[tempVertsIndex] = verts[i];
                m_TempVerts[tempVertsIndex].position *= unitsPerPixel;
                if (tempVertsIndex == 3)
                    toFill.AddUIVertexQuad(m_TempVerts);
            }
        }
    }
}
