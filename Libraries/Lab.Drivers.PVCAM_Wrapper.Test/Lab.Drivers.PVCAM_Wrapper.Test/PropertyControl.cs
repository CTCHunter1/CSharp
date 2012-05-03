using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Lab_Drivers_PVCAM_Wrapper;

namespace Lab.Drivers.PVCAM_Wrapper.Test
{
    public partial class PropertyControl : UserControl
    {
        String propertyType;
        PVCAM_Wrapper_Class PVCAM_obj;

        public PropertyControl()
        {
            InitializeComponent();

            typeCombBox.DataSource = Enum.GetValues(typeof(ATTR_TYPE));
            accessComboBox.DataSource = Enum.GetValues(typeof(ATTR_ACCESS));
        }
        

        public String PropertyType
        {
            set
            {
                propertyType = value;
                groupBox.Text = value;                
            }
        }

        public PVCAM_Wrapper_Class PVCAM_Obj
        {
            set
            {
                this.PVCAM_obj = value;
            }
        }

        public object [] ParamItems
        {
            set
            {
                parameterComboBox.Items.Clear();
                parameterComboBox.Items.AddRange(value);
                parameterComboBox.SelectedIndex = 0;
            }
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            PARAMS ccd_param = (PARAMS)parameterComboBox.SelectedItem;

            if (PVCAM_obj.GetParameterAvailable((uint)ccd_param) == false)
            {
                availableTextBox.Text = "Feature Not Available";
                currentValNumericUpDown.Value = 0;
                minLabel.Text = "N/A";
                maxLabel.Text = "N/A";
                defaultLabel.Text = "N/A";

                return;
            }

            availableTextBox.Text = "Feature Available";

            ATTR_TYPE paramType = PVCAM_obj.GetParameterType((uint) ccd_param);
            ATTR_ACCESS paramAccess = PVCAM_obj.GetParameterAccess((uint) ccd_param);

            typeCombBox.SelectedItem = paramType;
            accessComboBox.SelectedItem = paramAccess;
            
            uint curValInt;
            uint defValInt;

            switch (paramType)
            {
                case ATTR_TYPE.TYPE_ENUM_W:
                    // this parameter is of the enumeration type
                    // only some parameters populated with values of enumeratino
                    curValInt = PVCAM_obj.GetParameterEnum((uint)ccd_param, ATTR.ATTR_CURRENT);
                    defValInt = PVCAM_obj.GetParameterEnum((uint)ccd_param, ATTR.ATTR_DEFAULT);
                
                    switch (ccd_param)
                    {
                        case PARAMS.PARAM_CLEAR_MODE_W:
                            enumDefaultComboBox.DataSource = Enum.GetValues(typeof(CLEAR_MODE));
                            enumValueComboBox.DataSource = Enum.GetValues(typeof(CLEAR_MODE));

                            enumDefaultComboBox.SelectedItem = (CLEAR_MODE) defValInt;
                            enumValueComboBox.SelectedItem = (CLEAR_MODE) curValInt;

                            break;

                        case PARAMS.PARAM_CONT_CLEARS_W:
                            currentValNumericUpDown.Value = Convert.ToDecimal(curValInt);
                            defaultLabel.Text = defValInt.ToString();
                            break;
                        // shutter enums
                        case PARAMS.PARAM_EXPOSURE_MODE_W:
                            enumDefaultComboBox.DataSource = Enum.GetValues(typeof(EXPOSURE_MODE));
                            enumValueComboBox.DataSource = Enum.GetValues(typeof(EXPOSURE_MODE));
                            
                            enumDefaultComboBox.SelectedItem = (EXPOSURE_MODE) defValInt;
                            enumValueComboBox.SelectedItem = (EXPOSURE_MODE) curValInt;
                            
                            break;

                        case PARAMS.PARAM_PREFLASH_W:
                            enumDefaultComboBox.DataSource = Enum.GetValues(typeof(EXPOSURE_MODE));
                            enumValueComboBox.DataSource = Enum.GetValues(typeof(EXPOSURE_MODE));
                            
                            enumDefaultComboBox.SelectedItem = (EXPOSURE_MODE) defValInt;
                            enumValueComboBox.SelectedItem = (EXPOSURE_MODE) curValInt;


                            break;

                        case PARAMS.PARAM_SHTR_OPEN_MODE_W:
                            enumDefaultComboBox.DataSource = Enum.GetValues(typeof(SHUTTER_OPEN_MODE));
                            enumValueComboBox.DataSource = Enum.GetValues(typeof(SHUTTER_OPEN_MODE));

                            enumDefaultComboBox.SelectedItem = (SHUTTER_OPEN_MODE)defValInt;
                            enumValueComboBox.SelectedItem = (SHUTTER_OPEN_MODE)curValInt;
                            break;

                        case PARAMS.PARAM_SHTR_RES_W:
                            enumDefaultComboBox.DataSource = Enum.GetValues(typeof(SHUTTER_RES));
                            enumValueComboBox.DataSource = Enum.GetValues(typeof(SHUTTER_RES));

                            enumDefaultComboBox.SelectedItem = (SHUTTER_RES)defValInt;
                            enumValueComboBox.SelectedItem = (SHUTTER_RES)curValInt;
                            break;

                        // acquistion enums
                        case PARAMS.PARAM_EXP_RES_W:
                            enumDefaultComboBox.DataSource = Enum.GetValues(typeof(EXPOSURE_RES));
                            enumValueComboBox.DataSource = Enum.GetValues(typeof(EXPOSURE_RES));

                            enumDefaultComboBox.SelectedItem = (EXPOSURE_RES)defValInt;
                            enumValueComboBox.SelectedItem = (EXPOSURE_RES)curValInt;
                            break;
                    }

                    break;

                case ATTR_TYPE.TYPE_INT8_W:
                    currentValNumericUpDown.Value =
                        Convert.ToDecimal(PVCAM_obj.GetParameterInt8((uint)ccd_param, ATTR.ATTR_CURRENT));
                    minLabel.Text = PVCAM_obj.GetParameterInt8((uint)ccd_param, ATTR.ATTR_MIN).ToString();
                    maxLabel.Text = PVCAM_obj.GetParameterInt8((uint)ccd_param, ATTR.ATTR_MAX).ToString();
                    defaultLabel.Text = PVCAM_obj.GetParameterInt8((uint)ccd_param, ATTR.ATTR_DEFAULT).ToString();
                    break;

                case ATTR_TYPE.TYPE_UNS8_W:
                    currentValNumericUpDown.Value =
                        Convert.ToDecimal(PVCAM_obj.GetParameterUns8((uint)ccd_param, ATTR.ATTR_CURRENT));
                    minLabel.Text = PVCAM_obj.GetParameterUns8((uint)ccd_param, ATTR.ATTR_MIN).ToString();
                    maxLabel.Text = PVCAM_obj.GetParameterUns8((uint)ccd_param, ATTR.ATTR_MAX).ToString();
                    defaultLabel.Text = PVCAM_obj.GetParameterUns8((uint)ccd_param, ATTR.ATTR_DEFAULT).ToString();
                    break;

                case ATTR_TYPE.TYPE_INT16_W:
                    currentValNumericUpDown.Value =
                        Convert.ToDecimal(PVCAM_obj.GetParameterInt16((uint)ccd_param, ATTR.ATTR_CURRENT));
                    minLabel.Text = PVCAM_obj.GetParameterInt16((uint)ccd_param, ATTR.ATTR_MIN).ToString();
                    maxLabel.Text = PVCAM_obj.GetParameterInt16((uint)ccd_param, ATTR.ATTR_MAX).ToString();
                    defaultLabel.Text = PVCAM_obj.GetParameterInt16((uint)ccd_param, ATTR.ATTR_DEFAULT).ToString();
                    break;

                case ATTR_TYPE.TYPE_UNS16_W:
                    currentValNumericUpDown.Value =
                        Convert.ToDecimal(PVCAM_obj.GetParameterUns16((uint)ccd_param, ATTR.ATTR_CURRENT));
                    minLabel.Text = PVCAM_obj.GetParameterUns16((uint)ccd_param, ATTR.ATTR_MIN).ToString();
                    maxLabel.Text = PVCAM_obj.GetParameterUns16((uint)ccd_param, ATTR.ATTR_MAX).ToString();
                    defaultLabel.Text = PVCAM_obj.GetParameterUns16((uint)ccd_param, ATTR.ATTR_DEFAULT).ToString();
                    break;

                case ATTR_TYPE.TYPE_INT32_W:
                    currentValNumericUpDown.Value =
                        Convert.ToDecimal(PVCAM_obj.GetParameterInt32((uint)ccd_param, ATTR.ATTR_CURRENT));
                    minLabel.Text = PVCAM_obj.GetParameterInt32((uint)ccd_param, ATTR.ATTR_MIN).ToString();
                    maxLabel.Text = PVCAM_obj.GetParameterInt32((uint)ccd_param, ATTR.ATTR_MAX).ToString();
                    defaultLabel.Text = PVCAM_obj.GetParameterInt32((uint)ccd_param, ATTR.ATTR_DEFAULT).ToString();
                    break;

                case ATTR_TYPE.TYPE_UNS32_W:
                    decimal paramValue = Convert.ToDecimal(PVCAM_obj.GetParameterUns32((uint)ccd_param, ATTR.ATTR_CURRENT));
                    if (currentValNumericUpDown.Maximum < paramValue)
                        currentValNumericUpDown.Maximum = paramValue;
                    if (currentValNumericUpDown.Minimum > paramValue)
                        currentValNumericUpDown.Minimum = paramValue;

                    currentValNumericUpDown.Value = paramValue; 
                        
                    minLabel.Text = PVCAM_obj.GetParameterUns32((uint)ccd_param, ATTR.ATTR_MIN).ToString();
                    maxLabel.Text = PVCAM_obj.GetParameterUns32((uint)ccd_param, ATTR.ATTR_MAX).ToString();
                    defaultLabel.Text = PVCAM_obj.GetParameterUns32((uint)ccd_param, ATTR.ATTR_DEFAULT).ToString();
                    break;

                case ATTR_TYPE.TYPE_FLT64_W:
                    currentValNumericUpDown.Value =
                        Convert.ToDecimal(PVCAM_obj.GetParameterFlt64((uint)ccd_param, ATTR.ATTR_CURRENT));
                    minLabel.Text = PVCAM_obj.GetParameterFlt64((uint)ccd_param, ATTR.ATTR_MIN).ToString();
                    maxLabel.Text = PVCAM_obj.GetParameterFlt64((uint)ccd_param, ATTR.ATTR_MAX).ToString();
                    defaultLabel.Text = PVCAM_obj.GetParameterFlt64((uint)ccd_param, ATTR.ATTR_DEFAULT).ToString();
                    break;

                case ATTR_TYPE.TYPE_BOOLEAN_W:
                    currentValNumericUpDown.Value =
                        Convert.ToDecimal(PVCAM_obj.GetParameterBool((uint)ccd_param, ATTR.ATTR_CURRENT));
                    minLabel.Text = PVCAM_obj.GetParameterBool((uint)ccd_param, ATTR.ATTR_MIN).ToString();
                    maxLabel.Text = PVCAM_obj.GetParameterBool((uint)ccd_param, ATTR.ATTR_MAX).ToString();
                    defaultLabel.Text = PVCAM_obj.GetParameterBool((uint)ccd_param, ATTR.ATTR_DEFAULT).ToString();
                    break;
            }    
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            switch ((ATTR_TYPE) typeCombBox.SelectedItem)
            {
                case ATTR_TYPE.TYPE_ENUM_W:
                    PVCAM_obj.SetParameterEnum((PARAMS)parameterComboBox.SelectedItem, (short) enumValueComboBox.SelectedItem);
                    break;

                case ATTR_TYPE.TYPE_UNS16_W:
                    PVCAM_obj.SetParameterUns16((PARAMS)parameterComboBox.SelectedItem, (ushort)currentValNumericUpDown.Value);
                    break;
            }


        }  
    }
}
