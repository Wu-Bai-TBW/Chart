using System;
using System.Collections.Generic;
using UnityEngine;

namespace M_Chart
{
    public enum EScaleDataType
    {
        Value,      // ���ݴ������� ��̬�޸����п̶�ֵ
        Custom      // ��������ÿ���̶�ֵ
    }
    public abstract class ChartAxis
    {
        protected RectTransform m_RectTransform;


        [SerializeField] protected bool _AxisLine = true;                       // �Ƿ���������
        [SerializeField] protected float _AxisLineWight = 1;                    // ���߿��
        [SerializeField] protected float _AxisOffset = 0;                       // ����ƫ��ֵ
        [SerializeField] protected Color _AxisColor = Color.white;              // ������ɫ
        [SerializeField] protected bool _Inversion = false;                     // �Ƿ�ת��


        [SerializeField] protected bool _Scale = true;                          // �Ƿ����ÿ̶�
        [SerializeField] protected Font _Font;                                  // ����
        [SerializeField] protected int _FontSize = 14;                          // �����С
        [SerializeField] protected Color _FontColor = Color.white;              // ������ɫ
        [SerializeField] protected EScaleDataType _EScaleDataType;              // �̶�ֵģʽ
        [SerializeField] protected int _ScaleDisNum = 3;                        // �̶���ʾ����(�м�)


        [SerializeField] protected bool _ScaleLine = false;                     // �Ƿ����ÿ̶���
        [SerializeField] protected float _ScaleLineHeight;                      // �̶��߸߶�
        [SerializeField] protected float _ScaleLineWight;                       // �̶��߿��
        [SerializeField] protected float _ScaleLineOffset;                      // �̶���ƫ��ֵ
        [SerializeField] protected Color _ScaleLineColor = Color.white;         // �̶�����ɫ


        public bool _ScaleAuxiliaryLine = false;                                // �Ƿ����ÿ̶ȸ�����
        [SerializeField] protected Color _ScaleAuxiliaryColor = Color.white;    // �̶ȸ�������ɫ


        public bool _Arrow = false;     // �Ƿ����ü�ͷ

        //===============================================================================

        public Color GetAxisColor => _AxisColor;
        public Color GetFontColor => _FontColor;
        public Color GetScaleLineColor => _ScaleLineColor;

        //===============================================================================

        /// <summary>
        /// �������߻��Ƶ�
        /// </summary>
        /// <param name="_AxisLineWight"></param>
        /// <returns></returns>
        public abstract Vector2[] GetAxisPoint(Rect rect);
        /// <summary>
        /// ���ؿ̶��߻��Ƶ�
        /// </summary>
        /// <param name="_TickMarkLineWight"></param>
        /// <returns></returns>
        public abstract List<Vector2[]> GetScaleLinePoint(Rect rect);
        /// <summary>
        /// չʾ�̶�����
        /// </summary>
        public abstract void ShowScaleText(Rect rect);

        //===============================================================================

        protected float ScaleNumAvg(float num)
        {
            return num / (_ScaleDisNum + 1);
        }
    }
}