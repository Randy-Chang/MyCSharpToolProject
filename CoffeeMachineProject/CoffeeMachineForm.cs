using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMachineProject
{
    public partial class CoffeeMachineForm : Form, ICoffeeMachineFormUI, ICoffeeMachineFormPack
    {
        #region 宣告
        public ICoffeeMachineFormUI CoffeeMachineFormUI { get; set; }
        private ICoffeeMachineFormPack pack;
        #endregion

        /// <summary>
        /// 初始化 CoffeeMachineForm 類別的新執例。
        /// </summary>
        /// <param name="pack">ICoffeeMachineFormPack 介面的實作。</param>
        public CoffeeMachineForm(ICoffeeMachineFormPack pack)
        {
            InitializeComponent();

            this.pack = pack;
        }

        public void InitUI()
        {
            btnConfirm.Click += btnConfirm_Click;
            cmbCoffeeMachineType.SelectedIndexChanged += cmbCoffeeMachineType_SelectedIndexChanged;
            cmbCoffeeBean.SelectedIndexChanged += cmbCoffeeBean_SelectedIndexChanged;
            InitCmbCoffeeBean();
            InitCmbCoffeeMachineType();
        }

        #region UI 事件
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ResponseMachine();
        }

        private void cmbCoffeeMachineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string type = cmb.SelectedItem?.ToString();
            ChangeCoffeeMachineType(type);
        }

        private void cmbCoffeeBean_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string bean = cmb.SelectedItem?.ToString();
            string info = ShowCoffeeBeamInfo(bean);

            rtbCoffeeBeamInfo.Text = info;
        }
        #endregion

        #region ICoffeeMachineFormUI 實作
        public ComboBox CmbCoffeeMachineType { get { return cmbCoffeeMachineType; } }

        public ComboBox CmbCoffeeBean { get { return cmbCoffeeBean; } }

        public Button BtnConfirm { get { return btnConfirm; } }

        public Label LbCoffeeMachineState { get { return lbCoffeeMachinState; } }
        #endregion

        #region ICoffeeMachineFormPack 實作 
        public void InitCmbCoffeeMachineType()
        {
            pack.InitCmbCoffeeMachineType();
        }

        public void InitCmbCoffeeBean()
        {
            pack.InitCmbCoffeeBean();
        }

        public void ResponseMachine()
        {
            pack.ResponseMachine();
        }

        public string ShowCoffeeBeamInfo(string coffeeBeamType)
        {
            return pack.ShowCoffeeBeamInfo(coffeeBeamType);
        }

        public void ChangeCoffeeMachineType(string type)
        {
            pack.ChangeCoffeeMachineType(type);
        }
        #endregion
    }

    public interface ICoffeeMachineFormUI
    {
        ComboBox CmbCoffeeMachineType { get; }
        ComboBox CmbCoffeeBean { get; }
        Button BtnConfirm { get; }
        Label LbCoffeeMachineState { get; }
    }

    public interface ICoffeeMachineFormPack
    {
        void InitCmbCoffeeMachineType();
        void InitCmbCoffeeBean();
        void ResponseMachine();
        void ChangeCoffeeMachineType(string type);
        string ShowCoffeeBeamInfo(string bean);
    }

}
