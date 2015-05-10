using SDTDomainModel.Enums;
using SDTPresentation.Utils;
using SDTPresentation.View;
using SDTBusiness.Registers;
using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using SDTDomainModel.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SDTPresentation.ViewModel
{
    public class SeparatorProcessInformationViewModel : ViewModelBase
    {
        public SeparatorProcessInformationViewModel(SeparatorDesignViewModel separatorDesignViewModel, SeparatorProcessInformation processInfo)
        {
            _separatorDesignViewModel = separatorDesignViewModel;
            StatusCases = new bool[]{true,false,false,false,false};
            _processInfo = processInfo;            

            #region Default Units


            WvUnit = MassFlowRateUnit.KilogramPerHour.Symbol();
            PvUnit = MassDensityUnit.KilogramPerCubicMeter.Symbol();
            UvUnit = ViscosityUnit.Centipoise.Symbol();
            MWvUnit = MolecularWeightUnit.GramPerGramMol.Symbol();

            WhcUnit = MassFlowRateUnit.KilogramPerHour.Symbol();
            PhcUnit = MassDensityUnit.KilogramPerCubicMeter.Symbol();
            UhcUnit = ViscosityUnit.Centipoise.Symbol();
            OhcUnit = SurfaceTensionUnit.NewtonPerMeter.Symbol();

            WwUnit = MassFlowRateUnit.KilogramPerHour.Symbol();
            PwUnit = MassDensityUnit.KilogramPerCubicMeter.Symbol();
            UwUnit = ViscosityUnit.Centipoise.Symbol();
            OwUnit = SurfaceTensionUnit.NewtonPerMeter.Symbol();


            _processInfo.TemperatureUnit = TemperatureUnit.Celsius;
            _processInfo.PressureUnit = PressureUnit.Pascal;

            _processInfo.Cases[0].isChecked = true;
            #endregion
        }

        private SeparatorProcessInformation _processInfo;
        private SeparatorDesignViewModel _separatorDesignViewModel;

        //public SeparatorProcessInformation SeparatorProcessInformation
        //{
        //    get { return _processInfo; }
        //    set { _processInfo = value; }
        //}

        public bool[] StatusCases { get; set; }

        const string VISIBLE = "Visible";
        const string HIDDEN = "Hidden";
        
        private string _visibilityChk1 = VISIBLE;
        private string _visibilityChk2 = HIDDEN;
        private string _visibilityChk3 = HIDDEN;
        private string _visibilityChk4 = HIDDEN;
        private string _visibilityChk5 = HIDDEN;
        private string _visibilityGrid1 = VISIBLE;
        private string _visibilityGrid2 = HIDDEN;
        private string _visibilityGrid3 = HIDDEN;
        private string _visibilityGrid4 = HIDDEN;
        private string _visibilityGrid5 = HIDDEN;
        private bool _isEnabledAddColumnButton = true;
        private string _visibilityPopup = HIDDEN;
        private bool _ratio = true;
        private bool _absoluteValue = false;
        private double? _valueToCopy = 100;
        private bool _isCheckedChk1 = true;
        private bool _isCheckedChk2 = true;
        private bool _isCheckedChk3 = true;
        private bool _isCheckedChk4 = true;
        private bool _isCheckedChk5 = true;
        private bool _isEnabledGrid1 = true;
        private bool _isEnabledGrid2 = true;
        private bool _isEnabledGrid3 = true;
        private bool _isEnabledGrid4 = true;
        private bool _isEnabledGrid5 = true;

        

        #region Properties

        public double? Pressure
        {
            get { return _processInfo.Pressure; }
            set
            {
                _processInfo.Pressure = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("Pressure");
            }
        }

        public double? Temperature
        {
            get { return _processInfo.Temperature; }
            set
            {
                _processInfo.Temperature = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("Temperature");
            }
        }

        public string PressureUnitCbx
        {
            get { return _processInfo.PressureUnit.Symbol(); }
            set
            {
                Pressure = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(Pressure, (int)PresentationUtils.ConvertSymbolToNamePressureUnit(_processInfo.PressureUnit.Symbol()), (int)PresentationUtils.ConvertSymbolToNamePressureUnit(value), ConversionUnitType.PressureUnit);
                _processInfo.PressureUnit = PresentationUtils.ConvertSymbolToNamePressureUnit(value);
                RaisePropertyChangedEvent("PressureUnitCbx");
            }
        }

        public string TemperatureUnitCbx
        {
            get { return _processInfo.TemperatureUnit.Symbol(); }
            set
            {
                Temperature = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(Temperature, (int)PresentationUtils.ConvertSymbolToNameTemperatureUnit(_processInfo.TemperatureUnit.Symbol()), (int)PresentationUtils.ConvertSymbolToNameTemperatureUnit(value), ConversionUnitType.TemperatureUnit);
                _processInfo.TemperatureUnit = PresentationUtils.ConvertSymbolToNameTemperatureUnit(value);
                RaisePropertyChangedEvent("TemperatureUnitCbx");
            }
        }

        #region VisibilityChecks

        public string VisibilityChk1
        {
            get { return _visibilityChk1; }
            set
            {
                _visibilityChk1 = value;
                RaisePropertyChangedEvent("VisibilityChk1");
            }
        }

        public string VisibilityChk2
        {
            get { return _visibilityChk2; }
            set
            {
                _visibilityChk2 = value;
                RaisePropertyChangedEvent("VisibilityChk2");
            }
        }

        public string VisibilityChk3
        {
            get { return _visibilityChk3; }
            set
            {
                _visibilityChk3 = value;
                RaisePropertyChangedEvent("VisibilityChk3");
            }
        }

        public string VisibilityChk4
        {
            get { return _visibilityChk4; }
            set
            {
                _visibilityChk4 = value;
                RaisePropertyChangedEvent("VisibilityChk4");
            }
        }

        public string VisibilityChk5
        {
            get { return _visibilityChk5; }
            set
            {
                _visibilityChk5 = value;
                RaisePropertyChangedEvent("VisibilityChk5");
            }
        }

        #endregion

        #region VisibilityGrids

        public string VisibilityGrid1
        {
            get { return _visibilityGrid1; }
            set
            {
                _visibilityGrid1 = value;
                RaisePropertyChangedEvent("VisibilityGrid1");
            }
        }

        public string VisibilityGrid2
        {
            get { return _visibilityGrid2; }
            set
            {
                _visibilityGrid2 = value;
                RaisePropertyChangedEvent("VisibilityGrid2");
            }
        }
        
        public string VisibilityGrid3
        {
            get { return _visibilityGrid3; }
            set
            {
                _visibilityGrid3 = value;
                RaisePropertyChangedEvent("VisibilityGrid3");
            }
        }
        
        public string VisibilityGrid4
        {
            get { return _visibilityGrid4; }
            set
            {
                _visibilityGrid4 = value;
                RaisePropertyChangedEvent("VisibilityGrid4");
            }
        }

        public string VisibilityGrid5
        {
            get { return _visibilityGrid5; }
            set
            {
                _visibilityGrid5 = value;
                RaisePropertyChangedEvent("VisibilityGrid5");
            }
        }

        #endregion

        public bool IsEnabledAddColumnButton
        {
            get { return _isEnabledAddColumnButton; }
            set
            {
                _isEnabledAddColumnButton = value;
                RaisePropertyChangedEvent("IsEnabledAddColumnButton");
            }
        }

        public string VisibilityPopup
        {
            get { return _visibilityPopup; }
            set
            {
                _visibilityPopup = value;
                RaisePropertyChangedEvent("VisibilityPopup");
            }
        }

        public bool Ratio
        {
            get { return _ratio; }
            set
            {
                _ratio = value;
                RaisePropertyChangedEvent("Ratio");
            }
        }

        public bool AbsoluteValue
        {
            get { return _absoluteValue; }
            set
            {
                _absoluteValue = value;
                RaisePropertyChangedEvent("AbsoluteValue");
            }
        }

        public double? ValueToCopy
        {
            get { return _valueToCopy; }
            set
            {
                _valueToCopy = value;
                RaisePropertyChangedEvent("ValueToCopy");
            }
        }

        #region IsChecked Checkboxes

        public bool IsCheckedChk1
        {
            get { return _isCheckedChk1; }
            set
            {
                StatusCases[0] = value;
                value = UpdateValueBasedOnCheckNumberOfSelectedCases(value, 0);
                _isCheckedChk1 = value;
                IsEnabledGrid1 = value;
                _separatorDesignViewModel.GeometryVM.VisibilityCase1 = ReturnVisibleIfCheckboxIsChecked(_isCheckedChk1);
                _processInfo.Cases[0].isChecked = value;
                _separatorDesignViewModel.OutputVM.IsEnabledTab1 = value;
                RaisePropertyChangedEvent("IsCheckedChk1");
            }
        }

        public bool IsCheckedChk2
        {
            get { return _isCheckedChk2; }
            set{
                StatusCases[1] = value;
                value = UpdateValueBasedOnCheckNumberOfSelectedCases(value, 1); 
                _isCheckedChk2 = value;
                IsEnabledGrid2 = value;
                _separatorDesignViewModel.GeometryVM.VisibilityCase2 = ReturnVisibleIfCheckboxIsChecked(_isCheckedChk2);
                _processInfo.Cases[1].isChecked = value;
                _separatorDesignViewModel.OutputVM.IsEnabledTab2 = value;
                RaisePropertyChangedEvent("IsCheckedChk2");
            }
        }

        public bool IsCheckedChk3
        {
            get { return _isCheckedChk3; }
            set
            {
                StatusCases[2] = value;
                value = UpdateValueBasedOnCheckNumberOfSelectedCases(value,2);
                _isCheckedChk3 = value;
                IsEnabledGrid3 = value;
                _separatorDesignViewModel.GeometryVM.VisibilityCase3 = ReturnVisibleIfCheckboxIsChecked(_isCheckedChk3);
                _processInfo.Cases[2].isChecked = value;
                _separatorDesignViewModel.OutputVM.IsEnabledTab3 = value;
                RaisePropertyChangedEvent("IsCheckedChk3");
            }
        }

        public bool IsCheckedChk4
        {
            get { return _isCheckedChk4; }
            set
            {
                StatusCases[3] = value;
                value = UpdateValueBasedOnCheckNumberOfSelectedCases(value, 3);
                _isCheckedChk4 = value;
                IsEnabledGrid4 = value;
                _separatorDesignViewModel.GeometryVM.VisibilityCase4 = ReturnVisibleIfCheckboxIsChecked(_isCheckedChk4);
                _processInfo.Cases[3].isChecked = value;
                _separatorDesignViewModel.OutputVM.IsEnabledTab4 = value;
                RaisePropertyChangedEvent("IsCheckedChk4");
            }
        }

        public bool IsCheckedChk5
        {
            get { return _isCheckedChk5; }
            set
            {
                StatusCases[4] = value;
                value = UpdateValueBasedOnCheckNumberOfSelectedCases(value, 4);
                _isCheckedChk5 = value;
                IsEnabledGrid5 = value;
                _separatorDesignViewModel.GeometryVM.VisibilityCase5 = ReturnVisibleIfCheckboxIsChecked(_isCheckedChk5);
                _processInfo.Cases[4].isChecked = value;
                _separatorDesignViewModel.OutputVM.IsEnabledTab5 = value;
                RaisePropertyChangedEvent("IsCheckedChk5");
            }
        }

        #endregion

        #region IsEnabled Grids

        public bool IsEnabledGrid1
        {
            get { return _isEnabledGrid1; }
            set
            {
                _isEnabledGrid1 = value;
                RaisePropertyChangedEvent("IsEnabledGrid1");
            }
        }

        public bool IsEnabledGrid2
        {
            get { return _isEnabledGrid2; }
            set
            {
                _isEnabledGrid2 = value;
                RaisePropertyChangedEvent("IsEnabledGrid2");
            }
        }

        public bool IsEnabledGrid3
        {
            get { return _isEnabledGrid3; }
            set
            {
                _isEnabledGrid3 = value;
                RaisePropertyChangedEvent("IsEnabledGrid3");
            }
        }

        public bool IsEnabledGrid4
        {
            get { return _isEnabledGrid4; }
            set
            {
                _isEnabledGrid4 = value;
                RaisePropertyChangedEvent("IsEnabledGrid4");
            }
        }

        public bool IsEnabledGrid5
        {
            get { return _isEnabledGrid5; }
            set
            {
                _isEnabledGrid5 = value;
                RaisePropertyChangedEvent("IsEnabledGrid5");
            }
        }

        #endregion
        
        #region Units

        public string WvUnit 
        {
            get { return _processInfo.Cases[0].VaporMassFlowRateMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(_processInfo.Cases[0].VaporMassFlowRateMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(value);
                WvCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].VaporMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WvCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].VaporMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WvCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].VaporMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WvCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].VaporMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WvCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].VaporMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                _processInfo.Cases[0].VaporMassFlowRateMeasurementUnit = PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(value);
                _processInfo.Cases[1].VaporMassFlowRateMeasurementUnit = _processInfo.Cases[0].VaporMassFlowRateMeasurementUnit;
                _processInfo.Cases[2].VaporMassFlowRateMeasurementUnit = _processInfo.Cases[0].VaporMassFlowRateMeasurementUnit;
                _processInfo.Cases[3].VaporMassFlowRateMeasurementUnit = _processInfo.Cases[0].VaporMassFlowRateMeasurementUnit;
                _processInfo.Cases[4].VaporMassFlowRateMeasurementUnit = _processInfo.Cases[0].VaporMassFlowRateMeasurementUnit;
                RaisePropertyChangedEvent("WvUnit");
            }
        }

        public string PvUnit
        {
            get { return _processInfo.Cases[0].VaporMassDensityMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameDensityUnity(_processInfo.Cases[0].VaporMassDensityMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameDensityUnity(value);
                PvCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].VaporMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PvCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].VaporMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PvCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].VaporMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PvCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].VaporMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PvCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].VaporMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                _processInfo.Cases[0].VaporMassDensityMeasurementUnit = PresentationUtils.ConvertSymbolToNameDensityUnity(value);
                _processInfo.Cases[1].VaporMassDensityMeasurementUnit = _processInfo.Cases[0].VaporMassDensityMeasurementUnit;
                _processInfo.Cases[2].VaporMassDensityMeasurementUnit = _processInfo.Cases[0].VaporMassDensityMeasurementUnit;
                _processInfo.Cases[3].VaporMassDensityMeasurementUnit = _processInfo.Cases[0].VaporMassDensityMeasurementUnit;
                _processInfo.Cases[4].VaporMassDensityMeasurementUnit = _processInfo.Cases[0].VaporMassDensityMeasurementUnit;
                RaisePropertyChangedEvent("PvUnit");
            }
        }
        
        public string UvUnit
        {
            get { return _processInfo.Cases[0].VaporViscosityMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameViscosityUnit(_processInfo.Cases[0].VaporViscosityMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameViscosityUnit(value);
                UvCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].VaporViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UvCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].VaporViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UvCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].VaporViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UvCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].VaporViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UvCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].VaporViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                _processInfo.Cases[0].VaporViscosityMeasurementUnit = PresentationUtils.ConvertSymbolToNameViscosityUnit(value);
                _processInfo.Cases[1].VaporViscosityMeasurementUnit = _processInfo.Cases[0].VaporViscosityMeasurementUnit;
                _processInfo.Cases[2].VaporViscosityMeasurementUnit = _processInfo.Cases[0].VaporViscosityMeasurementUnit;
                _processInfo.Cases[3].VaporViscosityMeasurementUnit = _processInfo.Cases[0].VaporViscosityMeasurementUnit;
                _processInfo.Cases[4].VaporViscosityMeasurementUnit = _processInfo.Cases[0].VaporViscosityMeasurementUnit;
                RaisePropertyChangedEvent("UvUnit");
            }
        }

        public string MWvUnit
        {
            get { return _processInfo.Cases[0].VaporMolecularWeightMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToMolecularWeightUnit(_processInfo.Cases[0].VaporMolecularWeightMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToMolecularWeightUnit(value);
                MWvCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].VaporMolecularWeight, codeFrom, codeTo, ConversionUnitType.MolecularWeightUnit);
                MWvCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].VaporMolecularWeight, codeFrom, codeTo, ConversionUnitType.MolecularWeightUnit);
                MWvCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].VaporMolecularWeight, codeFrom, codeTo, ConversionUnitType.MolecularWeightUnit);
                MWvCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].VaporMolecularWeight, codeFrom, codeTo, ConversionUnitType.MolecularWeightUnit);
                MWvCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].VaporMolecularWeight, codeFrom, codeTo, ConversionUnitType.MolecularWeightUnit);
                _processInfo.Cases[0].VaporMolecularWeightMeasurementUnit = PresentationUtils.ConvertSymbolToMolecularWeightUnit(value);
                _processInfo.Cases[1].VaporMolecularWeightMeasurementUnit = _processInfo.Cases[0].VaporMolecularWeightMeasurementUnit;
                _processInfo.Cases[2].VaporMolecularWeightMeasurementUnit = _processInfo.Cases[0].VaporMolecularWeightMeasurementUnit;
                _processInfo.Cases[3].VaporMolecularWeightMeasurementUnit = _processInfo.Cases[0].VaporMolecularWeightMeasurementUnit;
                _processInfo.Cases[4].VaporMolecularWeightMeasurementUnit = _processInfo.Cases[0].VaporMolecularWeightMeasurementUnit;
                RaisePropertyChangedEvent("MwvUnit");
            }
        }

        public string WhcUnit
        {
            get { return _processInfo.Cases[0].HCMassFlowRateMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(_processInfo.Cases[0].HCMassFlowRateMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(value);
                WhcCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].HCMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WhcCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].HCMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WhcCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].HCMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WhcCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].HCMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WhcCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].HCMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                _processInfo.Cases[0].HCMassFlowRateMeasurementUnit = PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(value);
                _processInfo.Cases[1].HCMassFlowRateMeasurementUnit = _processInfo.Cases[0].HCMassFlowRateMeasurementUnit;
                _processInfo.Cases[2].HCMassFlowRateMeasurementUnit = _processInfo.Cases[0].HCMassFlowRateMeasurementUnit;
                _processInfo.Cases[3].HCMassFlowRateMeasurementUnit = _processInfo.Cases[0].HCMassFlowRateMeasurementUnit;
                _processInfo.Cases[4].HCMassFlowRateMeasurementUnit = _processInfo.Cases[0].HCMassFlowRateMeasurementUnit;
                RaisePropertyChangedEvent("WhcUnit");
            }
        }

        public string PhcUnit
        {
            get { return _processInfo.Cases[0].HCMassDensityMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameDensityUnity(_processInfo.Cases[0].HCMassDensityMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameDensityUnity(value);
                PhcCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].HCMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PhcCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].HCMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PhcCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].HCMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PhcCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].HCMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PhcCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].HCMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                _processInfo.Cases[0].HCMassDensityMeasurementUnit = PresentationUtils.ConvertSymbolToNameDensityUnity(value);
                _processInfo.Cases[1].HCMassDensityMeasurementUnit = _processInfo.Cases[0].HCMassDensityMeasurementUnit;
                _processInfo.Cases[2].HCMassDensityMeasurementUnit = _processInfo.Cases[0].HCMassDensityMeasurementUnit;
                _processInfo.Cases[3].HCMassDensityMeasurementUnit = _processInfo.Cases[0].HCMassDensityMeasurementUnit;
                _processInfo.Cases[4].HCMassDensityMeasurementUnit = _processInfo.Cases[0].HCMassDensityMeasurementUnit;
                RaisePropertyChangedEvent("PhcUnit");
            }
        }

        public string UhcUnit
        {
            get { return _processInfo.Cases[0].HCViscosityMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameViscosityUnit(_processInfo.Cases[0].HCViscosityMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameViscosityUnit(value);
                UhcCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].HCViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UhcCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].HCViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UhcCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].HCViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UhcCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].HCViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UhcCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].HCViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                _processInfo.Cases[0].HCViscosityMeasurementUnit = PresentationUtils.ConvertSymbolToNameViscosityUnit(value);
                _processInfo.Cases[1].HCViscosityMeasurementUnit = _processInfo.Cases[0].HCViscosityMeasurementUnit;
                _processInfo.Cases[2].HCViscosityMeasurementUnit = _processInfo.Cases[0].HCViscosityMeasurementUnit;
                _processInfo.Cases[3].HCViscosityMeasurementUnit = _processInfo.Cases[0].HCViscosityMeasurementUnit;
                _processInfo.Cases[4].HCViscosityMeasurementUnit = _processInfo.Cases[0].HCViscosityMeasurementUnit;
                RaisePropertyChangedEvent("UhcUnit");
            }
        }

        public string OhcUnit
        {
            get { return _processInfo.Cases[0].HCSurfaceTensionMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameSurfaceTensionUnit(_processInfo.Cases[0].HCSurfaceTensionMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameSurfaceTensionUnit(value);
                OhcCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].HCSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                OhcCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].HCSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                OhcCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].HCSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                OhcCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].HCSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                OhcCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].HCSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                _processInfo.Cases[0].HCSurfaceTensionMeasurementUnit = PresentationUtils.ConvertSymbolToNameSurfaceTensionUnit(value);
                _processInfo.Cases[1].HCSurfaceTensionMeasurementUnit = _processInfo.Cases[0].HCSurfaceTensionMeasurementUnit;
                _processInfo.Cases[2].HCSurfaceTensionMeasurementUnit = _processInfo.Cases[0].HCSurfaceTensionMeasurementUnit;
                _processInfo.Cases[3].HCSurfaceTensionMeasurementUnit = _processInfo.Cases[0].HCSurfaceTensionMeasurementUnit;
                _processInfo.Cases[4].HCSurfaceTensionMeasurementUnit = _processInfo.Cases[0].HCSurfaceTensionMeasurementUnit;
                RaisePropertyChangedEvent("OhcUnit");
            }
        }

        public string WwUnit
        {
            get { return _processInfo.Cases[0].WaterMassFlowRateMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(_processInfo.Cases[0].WaterMassFlowRateMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(value);
                WwCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].WaterMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WwCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].WaterMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WwCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].WaterMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WwCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].WaterMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                WwCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].WaterMassFlowRate, codeFrom, codeTo, ConversionUnitType.MassFlowRateUnit);
                _processInfo.Cases[0].WaterMassFlowRateMeasurementUnit = PresentationUtils.ConvertSymbolToNameMassFlowRateUnit(value);
                _processInfo.Cases[1].WaterMassFlowRateMeasurementUnit = _processInfo.Cases[0].WaterMassFlowRateMeasurementUnit;
                _processInfo.Cases[2].WaterMassFlowRateMeasurementUnit = _processInfo.Cases[0].WaterMassFlowRateMeasurementUnit;
                _processInfo.Cases[3].WaterMassFlowRateMeasurementUnit = _processInfo.Cases[0].WaterMassFlowRateMeasurementUnit;
                _processInfo.Cases[4].WaterMassFlowRateMeasurementUnit = _processInfo.Cases[0].WaterMassFlowRateMeasurementUnit;
                RaisePropertyChangedEvent("WwUnit");
            }
        }

        public string PwUnit
        {
            get { return _processInfo.Cases[0].WaterMassDensityMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameDensityUnity(_processInfo.Cases[0].WaterMassDensityMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameDensityUnity(value);
                PwCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].WaterMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PwCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].WaterMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PwCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].WaterMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PwCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].WaterMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                PwCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].WaterMassDensity, codeFrom, codeTo, ConversionUnitType.MassDensityUnit);
                _processInfo.Cases[0].WaterMassDensityMeasurementUnit = PresentationUtils.ConvertSymbolToNameDensityUnity(value);
                _processInfo.Cases[1].WaterMassDensityMeasurementUnit = _processInfo.Cases[0].WaterMassDensityMeasurementUnit;
                _processInfo.Cases[2].WaterMassDensityMeasurementUnit = _processInfo.Cases[0].WaterMassDensityMeasurementUnit;
                _processInfo.Cases[3].WaterMassDensityMeasurementUnit = _processInfo.Cases[0].WaterMassDensityMeasurementUnit;
                _processInfo.Cases[4].WaterMassDensityMeasurementUnit = _processInfo.Cases[0].WaterMassDensityMeasurementUnit;
                RaisePropertyChangedEvent("PwUnit");
            }
        }

        public string UwUnit
        {
            get { return _processInfo.Cases[0].WaterViscosityMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameViscosityUnit(_processInfo.Cases[0].WaterViscosityMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameViscosityUnit(value);
                UwCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].WaterViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UwCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].WaterViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UwCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].WaterViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UwCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].WaterViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                UwCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].WaterViscosity, codeFrom, codeTo, ConversionUnitType.ViscosityUnit);
                _processInfo.Cases[0].WaterViscosityMeasurementUnit = PresentationUtils.ConvertSymbolToNameViscosityUnit(value);
                _processInfo.Cases[1].WaterViscosityMeasurementUnit = _processInfo.Cases[0].WaterViscosityMeasurementUnit;
                _processInfo.Cases[2].WaterViscosityMeasurementUnit = _processInfo.Cases[0].WaterViscosityMeasurementUnit;
                _processInfo.Cases[3].WaterViscosityMeasurementUnit = _processInfo.Cases[0].WaterViscosityMeasurementUnit;
                _processInfo.Cases[4].WaterViscosityMeasurementUnit = _processInfo.Cases[0].WaterViscosityMeasurementUnit;
                RaisePropertyChangedEvent("UwUnit");
            }
        }

        public string OwUnit
        {
            get { return _processInfo.Cases[0].WaterSurfaceTensionMeasurementUnit.Symbol(); }
            set
            {
                int codeFrom = (int)PresentationUtils.ConvertSymbolToNameSurfaceTensionUnit(_processInfo.Cases[0].WaterSurfaceTensionMeasurementUnit.Symbol());
                int codeTo = (int)PresentationUtils.ConvertSymbolToNameSurfaceTensionUnit(value);
                OwCase1 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[0].WaterSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                OwCase2 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[1].WaterSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                OwCase3 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[2].WaterSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                OwCase4 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[3].WaterSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                OwCase5 = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(_processInfo.Cases[4].WaterSurfaceTension, codeFrom, codeTo, ConversionUnitType.SurfaceTensionUnit);
                _processInfo.Cases[0].WaterSurfaceTensionMeasurementUnit = PresentationUtils.ConvertSymbolToNameSurfaceTensionUnit(value);
                _processInfo.Cases[1].WaterSurfaceTensionMeasurementUnit = _processInfo.Cases[0].WaterSurfaceTensionMeasurementUnit;
                _processInfo.Cases[2].WaterSurfaceTensionMeasurementUnit = _processInfo.Cases[0].WaterSurfaceTensionMeasurementUnit;
                _processInfo.Cases[3].WaterSurfaceTensionMeasurementUnit = _processInfo.Cases[0].WaterSurfaceTensionMeasurementUnit;
                _processInfo.Cases[4].WaterSurfaceTensionMeasurementUnit = _processInfo.Cases[0].WaterSurfaceTensionMeasurementUnit;
                RaisePropertyChangedEvent("OwUnit");
            }
        }
        
        #endregion 

        #region Case1
        public double? WvCase1
        {
            get { return _processInfo.Cases[0].VaporMassFlowRate; }
            set
            {
                _processInfo.Cases[0].VaporMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WvCase1");
            }
        }

        public double? PvCase1
        {
            get { return _processInfo.Cases[0].VaporMassDensity; }
            set
            {
                _processInfo.Cases[0].VaporMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PvCase1");
            }
        }

        public double? UvCase1
        {
            get { return _processInfo.Cases[0].VaporViscosity; }
            set
            {
                _processInfo.Cases[0].VaporViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UvCase1");
            }
        }

        public double? MWvCase1
        {
            get { return _processInfo.Cases[0].VaporMolecularWeight; }
            set
            {
                _processInfo.Cases[0].VaporMolecularWeight = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("MWvCase1");
            }
        }

        public double? WhcCase1
        {
            get { return _processInfo.Cases[0].HCMassFlowRate; }
            set
            {
                _processInfo.Cases[0].HCMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WhcCase1");
            }
        }

        public double? PhcCase1
        {
            get { return _processInfo.Cases[0].HCMassDensity; }
            set
            {
                _processInfo.Cases[0].HCMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PhcCase1");
            }
        }

        public double? UhcCase1
        {
            get { return _processInfo.Cases[0].HCViscosity; }
            set
            {
                _processInfo.Cases[0].HCViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UhcCase1");
            }
        }

        public double? OhcCase1
        {
            get { return _processInfo.Cases[0].HCSurfaceTension; }
            set
            {
                _processInfo.Cases[0].HCSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OhcCase1");
            }
        }

        public double? WwCase1
        {
            get { return _processInfo.Cases[0].WaterMassFlowRate; }
            set
            {
                _processInfo.Cases[0].WaterMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WwCase1");
            }
        }

        public double? PwCase1
        {
            get { return _processInfo.Cases[0].WaterMassDensity; }
            set
            {
                _processInfo.Cases[0].WaterMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PwCase1");
            }
        }

        public double? UwCase1
        {
            get { return _processInfo.Cases[0].WaterViscosity; }
            set
            {
                _processInfo.Cases[0].WaterViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UwCase1");
            }
        }

        public double? OwCase1
        {
            get { return _processInfo.Cases[0].WaterSurfaceTension; }
            set
            {
                _processInfo.Cases[0].WaterSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OwCase1");
            }
        }
        #endregion

        #region Case2
        public double? WvCase2
        {
            get { return _processInfo.Cases[1].VaporMassFlowRate; }
            set
            {
                _processInfo.Cases[1].VaporMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WvCase2");
            }
        }

        public double? PvCase2
        {
            get { return _processInfo.Cases[1].VaporMassDensity; }
            set
            {
                _processInfo.Cases[1].VaporMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PvCase2");
            }
        }

        public double? UvCase2
        {
            get { return _processInfo.Cases[1].VaporViscosity; }
            set
            {
                _processInfo.Cases[1].VaporViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UvCase2");
            }
        }

        public double? MWvCase2
        {
            get { return _processInfo.Cases[1].VaporMolecularWeight; }
            set
            {
                _processInfo.Cases[1].VaporMolecularWeight = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("MWvCase2");
            }
        }

        public double? WhcCase2
        {
            get { return _processInfo.Cases[1].HCMassFlowRate; }
            set
            {
                _processInfo.Cases[1].HCMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WhcCase2");
            }
        }

        public double? PhcCase2
        {
            get { return _processInfo.Cases[1].HCMassDensity; }
            set
            {
                _processInfo.Cases[1].HCMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PhcCase2");
            }
        }

        public double? UhcCase2
        {
            get { return _processInfo.Cases[1].HCViscosity; }
            set
            {
                _processInfo.Cases[1].HCViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UhcCase2");
            }
        }

        public double? OhcCase2
        {
            get { return _processInfo.Cases[1].HCSurfaceTension; }
            set
            {
                _processInfo.Cases[1].HCSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OhcCase2");
            }
        }

        public double? WwCase2
        {
            get { return _processInfo.Cases[1].WaterMassFlowRate; }
            set
            {
                _processInfo.Cases[1].WaterMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WwCase2");
            }
        }

        public double? PwCase2
        {
            get { return _processInfo.Cases[1].WaterMassDensity; }
            set
            {
                _processInfo.Cases[1].WaterMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PwCase2");
            }
        }

        public double? UwCase2
        {
            get { return _processInfo.Cases[1].WaterViscosity; }
            set
            {
                _processInfo.Cases[1].WaterViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UwCase2");
            }
        }

        public double? OwCase2
        {
            get { return _processInfo.Cases[1].WaterSurfaceTension; }
            set
            {
                _processInfo.Cases[1].WaterSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OwCase2");
            }
        }
        #endregion

        #region Case3
        public double? WvCase3
        {
            get { return _processInfo.Cases[2].VaporMassFlowRate; }
            set
            {
                _processInfo.Cases[2].VaporMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WvCase3");
            }
        }

        public double? PvCase3
        {
            get { return _processInfo.Cases[2].VaporMassDensity; }
            set
            {
                _processInfo.Cases[2].VaporMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PvCase3");
            }
        }

        public double? UvCase3
        {
            get { return _processInfo.Cases[2].VaporViscosity; }
            set
            {
                _processInfo.Cases[2].VaporViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UvCase3");
            }
        }

        public double? MWvCase3
        {
            get { return _processInfo.Cases[2].VaporMolecularWeight; }
            set
            {
                _processInfo.Cases[2].VaporMolecularWeight = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("MWvCase3");
            }
        }

        public double? WhcCase3
        {
            get { return _processInfo.Cases[2].HCMassFlowRate; }
            set
            {
                _processInfo.Cases[2].HCMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WhcCase3");
            }
        }

        public double? PhcCase3
        {
            get { return _processInfo.Cases[2].HCMassDensity; }
            set
            {
                _processInfo.Cases[2].HCMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PhcCase3");
            }
        }

        public double? UhcCase3
        {
            get { return _processInfo.Cases[2].HCViscosity; }
            set
            {
                _processInfo.Cases[2].HCViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UhcCase3");
            }
        }

        public double? OhcCase3
        {
            get { return _processInfo.Cases[2].HCSurfaceTension; }
            set
            {
                _processInfo.Cases[2].HCSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OhcCase3");
            }
        }

        public double? WwCase3
        {
            get { return _processInfo.Cases[2].WaterMassFlowRate; }
            set
            {
                _processInfo.Cases[2].WaterMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WwCase3");
            }
        }

        public double? PwCase3
        {
            get { return _processInfo.Cases[2].WaterMassDensity; }
            set
            {
                _processInfo.Cases[2].WaterMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PwCase3");
            }
        }

        public double? UwCase3
        {
            get { return _processInfo.Cases[2].WaterViscosity; }
            set
            {
                _processInfo.Cases[2].WaterViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UwCase3");
            }
        }

        public double? OwCase3
        {
            get { return _processInfo.Cases[2].WaterSurfaceTension; }
            set
            {
                _processInfo.Cases[2].WaterSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OwCase3");
            }
        }
        #endregion

        #region Case4
        public double? WvCase4
        {
            get { return _processInfo.Cases[3].VaporMassFlowRate; }
            set
            {
                _processInfo.Cases[3].VaporMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WvCase4");
            }
        }

        public double? PvCase4
        {
            get { return _processInfo.Cases[3].VaporMassDensity; }
            set
            {
                _processInfo.Cases[3].VaporMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PvCase4");
            }
        }

        public double? UvCase4
        {
            get { return _processInfo.Cases[3].VaporViscosity; }
            set
            {
                _processInfo.Cases[3].VaporViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UvCase4");
            }
        }

        public double? MWvCase4
        {
            get { return _processInfo.Cases[3].VaporMolecularWeight; }
            set
            {
                _processInfo.Cases[3].VaporMolecularWeight = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("MWvCase4");
            }
        }

        public double? WhcCase4
        {
            get { return _processInfo.Cases[3].HCMassFlowRate; }
            set
            {
                _processInfo.Cases[3].HCMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WhcCase4");
            }
        }

        public double? PhcCase4
        {
            get { return _processInfo.Cases[3].HCMassDensity; }
            set
            {
                _processInfo.Cases[3].HCMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PhcCase4");
            }
        }

        public double? UhcCase4
        {
            get { return _processInfo.Cases[3].HCViscosity; }
            set
            {
                _processInfo.Cases[3].HCViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UhcCase4");
            }
        }

        public double? OhcCase4
        {
            get { return _processInfo.Cases[3].HCSurfaceTension; }
            set
            {
                _processInfo.Cases[3].HCSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OhcCase4");
            }
        }

        public double? WwCase4
        {
            get { return _processInfo.Cases[3].WaterMassFlowRate; }
            set
            {
                _processInfo.Cases[3].WaterMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WwCase4");
            }
        }

        public double? PwCase4
        {
            get { return _processInfo.Cases[3].WaterMassDensity; }
            set
            {
                _processInfo.Cases[3].WaterMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PwCase4");
            }
        }

        public double? UwCase4
        {
            get { return _processInfo.Cases[3].WaterViscosity; }
            set
            {
                _processInfo.Cases[3].WaterViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UwCase4");
            }
        }

        public double? OwCase4
        {
            get { return _processInfo.Cases[3].WaterSurfaceTension; }
            set
            {
                _processInfo.Cases[3].WaterSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OwCase4");
            }
        }
        
        #endregion
        
        #region Case5
        public double? WvCase5
        {
            get { return _processInfo.Cases[4].VaporMassFlowRate; }
            set
            {
                _processInfo.Cases[4].VaporMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WvCase5");
            }
        }

        public double? PvCase5
        {
            get { return _processInfo.Cases[4].VaporMassDensity; }
            set
            {
                _processInfo.Cases[4].VaporMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PvCase5");
            }
        }

        public double? UvCase5
        {
            get { return _processInfo.Cases[4].VaporViscosity; }
            set
            {
                _processInfo.Cases[4].VaporViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UvCase5");
            }
        }

        public double? MWvCase5
        {
            get { return _processInfo.Cases[4].VaporMolecularWeight; }
            set
            {
                _processInfo.Cases[4].VaporMolecularWeight = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("MWvCase5");
            }
        }

        public double? WhcCase5
        {
            get { return _processInfo.Cases[4].HCMassFlowRate; }
            set
            {
                _processInfo.Cases[4].HCMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WhcCase5");
            }
        }

        public double? PhcCase5
        {
            get { return _processInfo.Cases[4].HCMassDensity; }
            set
            {
                _processInfo.Cases[4].HCMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PhcCase5");
            }
        }

        public double? UhcCase5
        {
            get { return _processInfo.Cases[4].HCViscosity; }
            set
            {
                _processInfo.Cases[4].HCViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UhcCase5");
            }
        }

        public double? OhcCase5
        {
            get { return _processInfo.Cases[4].HCSurfaceTension; }
            set
            {
                _processInfo.Cases[4].HCSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OhcCase5");
            }
        }

        public double? WwCase5
        {
            get { return _processInfo.Cases[4].WaterMassFlowRate; }
            set
            {
                _processInfo.Cases[4].WaterMassFlowRate = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("WwCase5");
            }
        }

        public double? PwCase5
        {
            get { return _processInfo.Cases[4].WaterMassDensity; }
            set
            {
                _processInfo.Cases[4].WaterMassDensity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("PwCase5");
            }
        }

        public double? UwCase5
        {
            get { return _processInfo.Cases[4].WaterViscosity; }
            set
            {
                _processInfo.Cases[4].WaterViscosity = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("UwCase5");
            }
        }

        public double? OwCase5
        {
            get { return _processInfo.Cases[4].WaterSurfaceTension; }
            set
            {
                _processInfo.Cases[4].WaterSurfaceTension = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                RaisePropertyChangedEvent("OwCase5");
            }
        }
        #endregion
       
        #endregion

        #region Combobox

        public static string[] PressureUnitCombobox
        {
            get { return new string[] { PressureUnit.Pascal.Symbol(), PressureUnit.PoundPerSquareInch.Symbol(), PressureUnit.bar.Symbol() }; }
        }

        public static string[] TemperatureUnitCombobox
        {
            get { return new string[] { TemperatureUnit.Celsius.Symbol(), TemperatureUnit.Fahrenheit.Symbol(), TemperatureUnit.Kelvin.Symbol() }; }
        }

        public static string[] MassFlowRateUnitCombobox
        {
            get { return new string[]{ MassFlowRateUnit.KilogramPerHour.Symbol(), MassFlowRateUnit.KilogramPerSecond.Symbol(), MassFlowRateUnit.PoundPerHour.Symbol(), MassFlowRateUnit.PoundPerSecond.Symbol()};}
        }

        public static string[] DensityUnityCombobox
        {
            get { return new string[] { MassDensityUnit.GramPerCubicCentimeter.Symbol(), MassDensityUnit.KilogramPerCubicMeter.Symbol(), MassDensityUnit.PoundPerCubicFeet.Symbol() }; }
        }

        public static string[] ViscosityUnityCombobox
        {
            get { return new string[] { ViscosityUnit.Centipoise.Symbol(), ViscosityUnit.PascalSecond.Symbol(), ViscosityUnit.PoundPerFeetSecond.Symbol()}; }
        }

        public static string[] MolecularWeightUnitCombobox
        {
            get { return new string[] { MolecularWeightUnit.GramPerGramMol.Symbol(), MolecularWeightUnit.PoundPerPoundMol.Symbol()}; }
        }

        public static string[] SurfaceTensionUnitCombobox
        {
            get { return new string[] { SurfaceTensionUnit.DynePerCentimeter.Symbol(), SurfaceTensionUnit.NewtonPerMeter.Symbol() }; }
        }

        #endregion

        #region Commands

        public ICommand AddButtonCommand
        {
            get { return new DelegateCommand(ShowPopup); }
        }

        public ICommand HidePopupCommand
        {
            get { return new DelegateCommand(HidePopup); }
        }

        public ICommand AddCaseAndCopyValuesCommand
        {
            get { return new DelegateCommand(AddCaseAndCopyValues); }
        }

        #endregion

        #region Actions

        public void ShowPopup(){
            VisibilityPopup = VISIBLE;
        }

        public void HidePopup() {
            VisibilityPopup = HIDDEN;
        }

        public void AddCaseAndCopyValues()
        {   
            _processInfo.NumberOfCasesCreatedBeyondCaseOne++;

            switch (_processInfo.NumberOfCasesCreatedBeyondCaseOne)
            {
                case 1:
                    VisibilityChk2 = VISIBLE;
                    VisibilityGrid2 = VISIBLE;
                    IsCheckedChk2 = true;
                    CopyValuesAndCalculateRatioToCase();
                    break;
                case 2:
                    VisibilityChk3 = VISIBLE;
                    VisibilityGrid3 = VISIBLE;
                    IsCheckedChk3 = true;
                    CopyValuesAndCalculateRatioToCase();
                    break;
                case 3:
                    VisibilityChk4 = VISIBLE;
                    VisibilityGrid4 = VISIBLE;
                    IsCheckedChk4 = true;
                    CopyValuesAndCalculateRatioToCase();
                    break;
                case 4:
                    VisibilityChk5 = VISIBLE;
                    VisibilityGrid5 = VISIBLE;
                    IsCheckedChk5 = true;
                    IsEnabledAddColumnButton = false;
                    CopyValuesAndCalculateRatioToCase();
                    break;
            }
            HidePopup();
        }

        public bool UpdateValueBasedOnCheckNumberOfSelectedCases(bool value, int arrayPosition)
        {
            if (CountSelectedCases() < 1 )
            {
                MessageBox.Show(WarningMessage.ATLEASTONECOLUMNENABLED, WarningMessage.WARNING, MessageBoxButton.OK, MessageBoxImage.Warning);
                StatusCases[arrayPosition] = true;
                return true;
            }
            else {
                StatusCases[arrayPosition] = value;
                return value;
            }
        }

        public int CountSelectedCases() {

            int s =  StatusCases.Where(x => x == true).Count();
            return s;
        }

        public static string ReturnVisibleIfCheckboxIsChecked(bool isCheckedCase) {
            return (isCheckedCase) ? VISIBLE : HIDDEN;
        }

        public double? ReturnVaporMassFlowFromCase1ToBeCopy() { 
            if (_ratio)
                return _processInfo.Cases[0].VaporMassFlowRate * (_valueToCopy / 100);
            return _valueToCopy;
        }

        public double? ReturnHCMassFlowFromCase1ToBeCopy()
        {
            if (_ratio)
                return _processInfo.Cases[0].HCMassFlowRate * (_valueToCopy / 100);
            return _valueToCopy;
        }

        public double? ReturnWaterMassFlowFromCase1ToBeCopy()
        {
            if (_ratio)
                return _processInfo.Cases[0].WaterMassFlowRate * (_valueToCopy / 100);
            return _valueToCopy;
        }


        public void CopyValuesAndCalculateRatioToCase()
        {
            switch (_processInfo.NumberOfCasesCreatedBeyondCaseOne)
            {
                case 1:
                    WvCase2 = ReturnVaporMassFlowFromCase1ToBeCopy();
                    WhcCase2 = ReturnHCMassFlowFromCase1ToBeCopy();
                    WwCase2 = ReturnWaterMassFlowFromCase1ToBeCopy();
                    PvCase2 = _processInfo.Cases[0].VaporMassDensity;
                    UvCase2 = _processInfo.Cases[0].VaporViscosity;
                    MWvCase2 = _processInfo.Cases[0].VaporMolecularWeight;
                    PhcCase2 = _processInfo.Cases[0].HCMassDensity;
                    UhcCase2 = _processInfo.Cases[0].HCViscosity;
                    OhcCase2 = _processInfo.Cases[0].HCSurfaceTension;
                    PwCase2 = _processInfo.Cases[0].WaterMassDensity;
                    UwCase2 = _processInfo.Cases[0].WaterViscosity;
                    OwCase2 = _processInfo.Cases[0].WaterSurfaceTension;
                    break;
                case 2:
                    WvCase3 = ReturnVaporMassFlowFromCase1ToBeCopy();
                    WhcCase3 = ReturnHCMassFlowFromCase1ToBeCopy();
                    WwCase3 = ReturnWaterMassFlowFromCase1ToBeCopy();
                    PvCase3 = _processInfo.Cases[0].VaporMassDensity;
                    UvCase3 = _processInfo.Cases[0].VaporViscosity;
                    MWvCase3 = _processInfo.Cases[0].VaporMolecularWeight;
                    PhcCase3 = _processInfo.Cases[0].HCMassDensity;
                    UhcCase3 = _processInfo.Cases[0].HCViscosity;
                    OhcCase3 = _processInfo.Cases[0].HCSurfaceTension;
                    PwCase3 = _processInfo.Cases[0].WaterMassDensity;
                    UwCase3 = _processInfo.Cases[0].WaterViscosity;
                    OwCase3 = _processInfo.Cases[0].WaterSurfaceTension;
                    break;
                case 3:
                    WvCase4 = ReturnVaporMassFlowFromCase1ToBeCopy();
                    WhcCase4 = ReturnHCMassFlowFromCase1ToBeCopy();
                    WwCase4 = ReturnWaterMassFlowFromCase1ToBeCopy();
                    PvCase4 = _processInfo.Cases[0].VaporMassDensity;
                    UvCase4 = _processInfo.Cases[0].VaporViscosity;
                    MWvCase4 = _processInfo.Cases[0].VaporMolecularWeight;
                    PhcCase4 = _processInfo.Cases[0].HCMassDensity;
                    UhcCase4 = _processInfo.Cases[0].HCViscosity;
                    OhcCase4 = _processInfo.Cases[0].HCSurfaceTension;
                    PwCase4 = _processInfo.Cases[0].WaterMassDensity;
                    UwCase4 = _processInfo.Cases[0].WaterViscosity;
                    OwCase4 = _processInfo.Cases[0].WaterSurfaceTension;
                    break;
                case 4:
                    WvCase5 = ReturnVaporMassFlowFromCase1ToBeCopy();
                    WhcCase5 = ReturnHCMassFlowFromCase1ToBeCopy();
                    WwCase5 = ReturnWaterMassFlowFromCase1ToBeCopy();
                    PvCase5 = _processInfo.Cases[0].VaporMassDensity;
                    UvCase5 = _processInfo.Cases[0].VaporViscosity;
                    MWvCase5 = _processInfo.Cases[0].VaporMolecularWeight;
                    PhcCase5 = _processInfo.Cases[0].HCMassDensity;
                    UhcCase5 = _processInfo.Cases[0].HCViscosity;
                    OhcCase5 = _processInfo.Cases[0].HCSurfaceTension;
                    PwCase5 = _processInfo.Cases[0].WaterMassDensity;
                    UwCase5 = _processInfo.Cases[0].WaterViscosity;
                    OwCase5 = _processInfo.Cases[0].WaterSurfaceTension;
                    break;
            }
        }

        #endregion
    }
}
