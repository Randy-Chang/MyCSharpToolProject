﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MyCSharpToolProject
{
    public static partial class ToolFunctions
    {

        /// <summary>
        /// 在指定的父容器中，按照橫列數量和直行數量生成子 Panel。
        /// </summary>
        /// <param name="parentPanel">父容器 Panel。</param>
        /// <param name="columns">橫列數量。</param>
        /// <param name="rows">直行數量。</param>
        /// <param name="spacing">子 Panel 間距。</param>
        /// <returns>生成的子 Panel 列表。</returns>
        public static List<Panel> CreateChildPanels(Panel parentPanel, int columns, int rows, int spacing)
        {
            if (parentPanel == null) throw new ArgumentNullException(nameof(parentPanel));
            if (columns <= 0 || rows <= 0) throw new ArgumentException("Columns and rows must be greater than 0.");
            if (spacing < 0) throw new ArgumentException("Spacing must be non-negative.");

            List<Panel> childPanels = new List<Panel>();

            // 計算子 Panel 的大小
            int panelWidth = (parentPanel.Width - (columns + 1) * spacing) / columns;
            int panelHeight = (parentPanel.Height - (rows + 1) * spacing) / rows;

            // 清空父容器中的控件
            parentPanel.Controls.Clear();

            // 動態生成子 Panel
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    // ... other code ...

                    Panel childPanel = new Panel
                    {
                        Size = new System.Drawing.Size(panelWidth, panelHeight), // Use System.Drawing.Size
                        Location = new System.Drawing.Point(
                            col * (panelWidth + spacing) + spacing, // 考慮左側間距
                            row * (panelHeight + spacing) + spacing // 考慮上方間距
                        ),
                        BorderStyle = BorderStyle.FixedSingle // 可調整為需要的樣式
                    };

                    // 添加子 Panel 到父容器
                    parentPanel.Controls.Add(childPanel);

                    // 添加到列表
                    childPanels.Add(childPanel);
                }
            }

            return childPanels;
        }

        /// <summary>
        /// 將 Enum 的值填入 ComboBox 中。
        /// </summary>
        /// <typeparam name="TEnum">Enum 類型。</typeparam>
        /// <param name="comboBox">要填入的 ComboBox。</param>
        public static void FillComboBoxWithEnum<TEnum>(ComboBox comboBox) where TEnum : Enum
        {
            if (comboBox == null) throw new ArgumentNullException(nameof(comboBox));

            comboBox.Items.Clear();

            foreach (var value in Enum.GetValues(typeof(TEnum)))
            {
                comboBox.Items.Add(value);
            }

            comboBox.SelectedIndex = 0;
            comboBox.MaxDropDownItems = comboBox.Items.Count;
        }

    }
}
