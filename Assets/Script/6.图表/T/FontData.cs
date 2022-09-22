using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace M_Chart
{
    [Serializable]
    /// <summary>
    /// Struct for storing Text generation settings.
    /// </summary>
    public class FontData : ISerializationCallbackReceiver
    {
        [SerializeField][FormerlySerializedAs("font")] private Font m_Font;                 // ����
        [SerializeField][FormerlySerializedAs("fontSize")] private int m_FontSize;          // ����ߴ�
        [SerializeField][FormerlySerializedAs("fontStyle")] private FontStyle m_FontStyle;  // ������ʽ

        [SerializeField] private bool m_BestFit;        // �������
        [SerializeField] private int m_MinSize;         // ������С�ߴ�
        [SerializeField] private int m_MaxSize;         // �������ߴ�

        [SerializeField][FormerlySerializedAs("alignment")] private TextAnchor m_Alignment; // �ı����뷽ʽ

        [SerializeField] private bool m_AlignByGeometry;

        [SerializeField][FormerlySerializedAs("richText")] private bool m_RichText; // ���ı�

        [SerializeField] private HorizontalWrapMode m_HorizontalOverflow;
        [SerializeField] private VerticalWrapMode m_VerticalOverflow;

        [SerializeField] private float m_LineSpacing;   // �м��           

        //==============================================================================
        public static FontData defaultFontData
        {
            get
            {
                var fontData = new FontData
                {
                    m_FontSize = 14,
                    m_LineSpacing = 1f,
                    m_FontStyle = FontStyle.Normal,
                    m_BestFit = false,
                    m_MinSize = 10,
                    m_MaxSize = 40,
                    m_Alignment = TextAnchor.UpperLeft,
                    m_HorizontalOverflow = HorizontalWrapMode.Wrap,
                    m_VerticalOverflow = VerticalWrapMode.Truncate,
                    m_RichText = true,
                    m_AlignByGeometry = false
                };
                return fontData;
            }
        }
        public Font font { get { return m_Font; } set { m_Font = value; } }
        public int fontSize { get { return m_FontSize; } set { m_FontSize = value; } }
        public FontStyle fontStyle { get { return m_FontStyle; } set { m_FontStyle = value; } }
        public bool bestFit { get { return m_BestFit; } set { m_BestFit = value; } }
        public int minSize { get { return m_MinSize; } set { m_MinSize = value; } }
        public int maxSize { get { return m_MaxSize; } set { m_MaxSize = value; } }
        public TextAnchor alignment { get { return m_Alignment; } set { m_Alignment = value; } }

        /// <summary>
        /// ʹ�����μ��ε�������ִ��ˮƽ���룬���������ζ�����
        /// </summary>
        /// <remarks>
        /// ����ܻᵼ�¸����ʵ����Ҷ��룬������ͼ���������(��ר�ŵ���������)�����ڱ˴�֮��ʱ�����ܻᵼ�´���Ķ�λ��
        /// </remarks>
        public bool alignByGeometry
        {
            get { return m_AlignByGeometry; }
            set { m_AlignByGeometry = value; }
        }

        /// <summary>
        /// Should rich text be used for this generated Text object.
        /// </summary>
        public bool richText
        {
            get { return m_RichText; }
            set { m_RichText = value; }
        }

        /// <summary>
        /// The horizontal overflow policy for this generated Text object.
        /// </summary>
        public HorizontalWrapMode horizontalOverflow
        {
            get { return m_HorizontalOverflow; }
            set { m_HorizontalOverflow = value; }
        }

        /// <summary>
        /// The vertical overflow policy for this generated Text object.
        /// </summary>
        public VerticalWrapMode verticalOverflow
        {
            get { return m_VerticalOverflow; }
            set { m_VerticalOverflow = value; }
        }

        /// <summary>
        /// The line spaceing for this generated Text object.
        /// </summary>
        public float lineSpacing
        {
            get { return m_LineSpacing; }
            set { m_LineSpacing = value; }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {

        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            m_FontSize = Mathf.Clamp(m_FontSize, 0, 300);
            m_MinSize = Mathf.Clamp(m_MinSize, 0, m_FontSize);
            m_MaxSize = Mathf.Clamp(m_MaxSize, m_FontSize, 300);
        }
    }
}