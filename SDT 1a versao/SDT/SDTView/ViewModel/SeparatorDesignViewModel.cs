using SDTDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SDTBusiness;
using SDTBusiness.Registers;
using SDTDomainModel.Enums;
using SDTDomainModel.Enums.Resources;
using SDTPresentation.Utils;
using System.Windows;


namespace SDTPresentation.ViewModel
{
    public class SeparatorDesignViewModel : ViewModelBase
    {
        //public SeparatorGeneralInformationViewModel GeneralInformationVM { get; set; }
        //public SeparatorProcessInformationViewModel ProcessInformationVM { get; set; }
        //public SeparatorGeometryViewModel GeometryVM { get; set; }
        //public SeparatorOutputViewModel OutputVM { get; set; }
        public ConsultaAlunoViewModel ConsultaAlunoVM { get; set; }

        //private SeparatorDesign separatorDesign;
        private Aluno aluno;

        //private bool ishiiKataokaIsChecked;
        //private bool tattersonDallmanHanrattyChecked;

        const string VISIBLE = "Visible";
        const string HIDDEN = "Hidden";

        //public bool IshiiKataokaIsChecked
        //{
        //    get { return ishiiKataokaIsChecked; }
        //    set
        //    {
        //        //if (TattersonDallmanHanrattyChecked) TattersonDallmanHanrattyChecked = false;
        //        ishiiKataokaIsChecked = value;
        //        RaisePropertyChangedEvent("IshiiKataokaIsChecked");
        //    }
        //}

        //public bool TattersonDallmanHanrattyChecked
        //{
        //    get { return tattersonDallmanHanrattyChecked; }
        //    set
        //    {
        //        //if (IshiiKataokaIsChecked) IshiiKataokaIsChecked = false;
        //        tattersonDallmanHanrattyChecked = value;
        //        RaisePropertyChangedEvent("TattersonDallmanHanrattyChecked");
        //    }
        //}

        #region subViews
        public SeparatorDesignViewModel()
        {
            aluno = new Aluno();

            //IshiiKataokaIsChecked = true;

            ////temporário - Será refatorado
            //for (int i = 0; i < 5; i++)
            //{
            //separatorDesign.ProcessInfo.Cases.Add(new SeparatorProcessDesignCase());
            //}
            //GeneralInformationVM = new SeparatorGeneralInformationViewModel(this, separatorDesign.Aluno);
            //ProcessInformationVM = new SeparatorProcessInformationViewModel(this, separatorDesign.ProcessInfo);
            //GeometryVM = new SeparatorGeometryViewModel(this, separatorDesign);
            //OutputVM = new SeparatorOutputViewModel(separatorDesign);
            ConsultaAlunoVM = new ConsultaAlunoViewModel();
        }

        //public SeparatorGeneralInformationViewModel generalInformationView
        //{
        //    get { return GeneralInformationVM; }
        //}

        //public SeparatorProcessInformationViewModel processInformationView
        //{
        //    get { return ProcessInformationVM; }
        //}

        //public SeparatorGeometryViewModel geometryView
        //{
        //    get { return GeometryVM; }
        //}

        //public SeparatorOutputViewModel outputView
        //{
        //    get { return OutputVM; }
        //}
        
        public ConsultaAlunoViewModel consultaAlunoView
        {
            get { return ConsultaAlunoVM; }
        }


        #endregion
        
        
        #region Delegate Commands

        //public ICommand Open
        //{
        //    get { return new DelegateCommand(OpenFile); }
        //}

        //public ICommand Save
        //{
        //    get { return new DelegateCommand(SaveFile); }
        //}

        //public ICommand SaveAs
        //{
        //    get { return new DelegateCommand(SaveFileAs); }
        //}

        //public ICommand Clear
        //{
        //    get { return new DelegateCommand(ClearFile); }
        //}

        //public ICommand SetIshiiKataoka
        //{
        //    get { return new DelegateCommand(SetIshiiKataokaProperty); }
        //}

        //public ICommand SetTattersonDallmanHanratty
        //{
        //    get { return new DelegateCommand(SetTattersonDallmanHanrattyProperty); }
        //}
        #endregion
                
        #region Actions

       

        //private void SetIshiiKataokaProperty()
        //{
        //    if (TattersonDallmanHanrattyChecked) TattersonDallmanHanrattyChecked = false;
        //    IshiiKataokaIsChecked = true;
        //    separatorDesign.CorrelationType = CorrelationType.IshiiKataoka;
        //    OutputVM.GenerateAllOutputs(OutputVM.TabSelectedIndex);
        //}

        //private void SetTattersonDallmanHanrattyProperty()
        //{
        //    if (IshiiKataokaIsChecked) IshiiKataokaIsChecked = false;
        //    TattersonDallmanHanrattyChecked = true;
        //    separatorDesign.CorrelationType = CorrelationType.TattersonDallmanHanratty;
        //    OutputVM.GenerateAllOutputs(OutputVM.TabSelectedIndex);
        //}

        //private void OpenFile()
        //{
        //    ClearFile();
        //    string JsonResult = FileViewModel.Open();

        //    if (JsonResult != null)
        //    {
        //        TabControlSelectedIndex = 0;

        //        SeparatorDesign separator = new SeparatorDesign();

        //        try
        //        {
        //            separator = JsonResult.FromJson<SeparatorDesign>();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show(WarningMessage.UNEXPECTEDFILEFORMAT, WarningMessage.ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
        //            return;
        //        }

        //        try
        //        {
        //            Aluno GeneralInformationResult = separator.Aluno;
        //            GeneralInformationVM.Nome = GeneralInformationResult.Nome;
        //            GeneralInformationVM.Contato = GeneralInformationResult.Contato;
        //            //GeneralInformationVM.NomeAluno = GeneralInformationResult.NomeAluno;
        //            //GeneralInformationVM.EmailAluno = GeneralInformationResult.EmailAluno;
        //            //GeneralInformationVM.TelefoneAluno = GeneralInformationResult.TelefoneAluno;
        //            //GeneralInformationVM.NomeResponsavel1 = GeneralInformationResult.NomeResponsavel1;
        //            //GeneralInformationVM.EmailResponsavel1 = GeneralInformationResult.EmailResponsavel1;
        //            //GeneralInformationVM.TelefoneResponsavel1 = GeneralInformationResult.TelefoneResponsavel1;
        //            //GeneralInformationVM.NomeResponsavel2 = GeneralInformationResult.NomeResponsavel2;
        //            //GeneralInformationVM.EmailResponsavel2 = GeneralInformationResult.EmailResponsavel2;
        //            //GeneralInformationVM.TelefoneResponsavel2 = GeneralInformationResult.TelefoneResponsavel2;
        //            //GeneralInformationVM.Turma = GeneralInformationResult.Livro.Turma;
        //            //GeneralInformationVM.Ano = GeneralInformationResult.Livro.Ano;
        //            //GeneralInformationVM.Semestre = GeneralInformationResult.Livro.Semestre;
        //            //GeneralInformationVM.Nota1 = GeneralInformationResult.Livro.Nota1;
        //            //GeneralInformationVM.Nota2 = GeneralInformationResult.Livro.Nota2;
        //            //GeneralInformationVM.Nota3 = GeneralInformationResult.Livro.Nota3;
        //            //GeneralInformationVM.Media = GeneralInformationResult.Livro.Media;
        //            //GeneralInformationVM.StatusCertificado = GeneralInformationResult.Livro.StatusCertificado;
        //            GeneralInformationVM.Turma = GeneralInformationResult.Turma;
        //            GeneralInformationVM.Ano = GeneralInformationResult.Ano;
        //            GeneralInformationVM.Semestre = GeneralInformationResult.Semestre;
        //            GeneralInformationVM.Nota1 = GeneralInformationResult.Nota1;
        //            GeneralInformationVM.Nota2 = GeneralInformationResult.Nota2;
        //            GeneralInformationVM.Nota3 = GeneralInformationResult.Nota3;
        //            GeneralInformationVM.Media = GeneralInformationResult.Media;
        //            GeneralInformationVM.StatusCertificado = GeneralInformationResult.Certificado;


        //            SeparatorProcessInformation ProcessInformationResult = separator.ProcessInfo;
        //            ProcessInformationVM.PressureUnitCbx = ((PressureUnit)ProcessInformationResult.PressureUnit).Symbol();
        //            ProcessInformationVM.TemperatureUnitCbx = ((TemperatureUnit)ProcessInformationResult.TemperatureUnit).Symbol();
        //            ProcessInformationVM.Pressure = ProcessInformationResult.Pressure;
        //            ProcessInformationVM.Temperature = ProcessInformationResult.Temperature;


        //            //#region Cases

        //            //SeparatorProcessDesignCase caseWithUnits = ProcessInformationResult.Cases[0];

        //            //ProcessInformationVM.WvUnit = ((MassFlowRateUnit)caseWithUnits.VaporMassFlowRateMeasurementUnit).Symbol();
        //            //ProcessInformationVM.PvUnit = ((MassDensityUnit)caseWithUnits.VaporMassDensityMeasurementUnit).Symbol();
        //            //ProcessInformationVM.UvUnit = ((ViscosityUnit)caseWithUnits.VaporViscosityMeasurementUnit).Symbol();
        //            //ProcessInformationVM.MWvUnit = ((MolecularWeightUnit)caseWithUnits.VaporMolecularWeightMeasurementUnit).Symbol();
        //            //ProcessInformationVM.WhcUnit = ((MassFlowRateUnit)caseWithUnits.HCMassFlowRateMeasurementUnit).Symbol();
        //            //ProcessInformationVM.PhcUnit = ((MassDensityUnit)caseWithUnits.HCMassDensityMeasurementUnit).Symbol();
        //            //ProcessInformationVM.UhcUnit = ((ViscosityUnit)caseWithUnits.HCViscosityMeasurementUnit).Symbol();
        //            //ProcessInformationVM.OhcUnit = ((SurfaceTensionUnit)caseWithUnits.HCSurfaceTensionMeasurementUnit).Symbol();
        //            //ProcessInformationVM.WwUnit = ((MassFlowRateUnit)caseWithUnits.WaterMassFlowRateMeasurementUnit).Symbol();
        //            //ProcessInformationVM.PwUnit = ((MassDensityUnit)caseWithUnits.WaterMassDensityMeasurementUnit).Symbol();
        //            //ProcessInformationVM.UwUnit = ((ViscosityUnit)caseWithUnits.WaterViscosityMeasurementUnit).Symbol();
        //            //ProcessInformationVM.OwUnit = ((SurfaceTensionUnit)caseWithUnits.WaterSurfaceTensionMeasurementUnit).Symbol();

        //            //ProcessInformationVM.WvCase1 = ProcessInformationResult.Cases[0].VaporMassFlowRate;
        //            //ProcessInformationVM.PvCase1 = ProcessInformationResult.Cases[0].VaporMassDensity;
        //            //ProcessInformationVM.UvCase1 = ProcessInformationResult.Cases[0].VaporViscosity;
        //            //ProcessInformationVM.MWvCase1 = ProcessInformationResult.Cases[0].VaporMolecularWeight;
        //            //ProcessInformationVM.WhcCase1 = ProcessInformationResult.Cases[0].HCMassFlowRate;
        //            //ProcessInformationVM.PhcCase1 = ProcessInformationResult.Cases[0].HCMassDensity;
        //            //ProcessInformationVM.UhcCase1 = ProcessInformationResult.Cases[0].HCViscosity;
        //            //ProcessInformationVM.OhcCase1 = ProcessInformationResult.Cases[0].HCSurfaceTension;
        //            //ProcessInformationVM.WwCase1 = ProcessInformationResult.Cases[0].WaterMassFlowRate;
        //            //ProcessInformationVM.PwCase1 = ProcessInformationResult.Cases[0].WaterMassDensity;
        //            //ProcessInformationVM.UwCase1 = ProcessInformationResult.Cases[0].WaterViscosity;
        //            //ProcessInformationVM.OwCase1 = ProcessInformationResult.Cases[0].WaterSurfaceTension;

        //            //ProcessInformationVM.WvCase2 = ProcessInformationResult.Cases[1].VaporMassFlowRate;
        //            //ProcessInformationVM.PvCase2 = ProcessInformationResult.Cases[1].VaporMassDensity;
        //            //ProcessInformationVM.UvCase2 = ProcessInformationResult.Cases[1].VaporViscosity;
        //            //ProcessInformationVM.MWvCase2 = ProcessInformationResult.Cases[1].VaporMolecularWeight;
        //            //ProcessInformationVM.WhcCase2 = ProcessInformationResult.Cases[1].HCMassFlowRate;
        //            //ProcessInformationVM.PhcCase2 = ProcessInformationResult.Cases[1].HCMassDensity;
        //            //ProcessInformationVM.UhcCase2 = ProcessInformationResult.Cases[1].HCViscosity;
        //            //ProcessInformationVM.OhcCase2 = ProcessInformationResult.Cases[1].HCSurfaceTension;
        //            //ProcessInformationVM.WwCase2 = ProcessInformationResult.Cases[1].WaterMassFlowRate;
        //            //ProcessInformationVM.PwCase2 = ProcessInformationResult.Cases[1].WaterMassDensity;
        //            //ProcessInformationVM.UwCase2 = ProcessInformationResult.Cases[1].WaterViscosity;
        //            //ProcessInformationVM.OwCase2 = ProcessInformationResult.Cases[1].WaterSurfaceTension;

        //            //ProcessInformationVM.WvCase3 = ProcessInformationResult.Cases[2].VaporMassFlowRate;
        //            //ProcessInformationVM.PvCase3 = ProcessInformationResult.Cases[2].VaporMassDensity;
        //            //ProcessInformationVM.UvCase3 = ProcessInformationResult.Cases[2].VaporViscosity;
        //            //ProcessInformationVM.MWvCase3 = ProcessInformationResult.Cases[2].VaporMolecularWeight;
        //            //ProcessInformationVM.WhcCase3 = ProcessInformationResult.Cases[2].HCMassFlowRate;
        //            //ProcessInformationVM.PhcCase3 = ProcessInformationResult.Cases[2].HCMassDensity;
        //            //ProcessInformationVM.UhcCase3 = ProcessInformationResult.Cases[2].HCViscosity;
        //            //ProcessInformationVM.OhcCase3 = ProcessInformationResult.Cases[2].HCSurfaceTension;
        //            //ProcessInformationVM.WwCase3 = ProcessInformationResult.Cases[2].WaterMassFlowRate;
        //            //ProcessInformationVM.PwCase3 = ProcessInformationResult.Cases[2].WaterMassDensity;
        //            //ProcessInformationVM.UwCase3 = ProcessInformationResult.Cases[2].WaterViscosity;
        //            //ProcessInformationVM.OwCase3 = ProcessInformationResult.Cases[2].WaterSurfaceTension;

        //            //ProcessInformationVM.WvCase4 = ProcessInformationResult.Cases[3].VaporMassFlowRate;
        //            //ProcessInformationVM.PvCase4 = ProcessInformationResult.Cases[3].VaporMassDensity;
        //            //ProcessInformationVM.UvCase4 = ProcessInformationResult.Cases[3].VaporViscosity;
        //            //ProcessInformationVM.MWvCase4 = ProcessInformationResult.Cases[3].VaporMolecularWeight;
        //            //ProcessInformationVM.WhcCase4 = ProcessInformationResult.Cases[3].HCMassFlowRate;
        //            //ProcessInformationVM.PhcCase4 = ProcessInformationResult.Cases[3].HCMassDensity;
        //            //ProcessInformationVM.UhcCase4 = ProcessInformationResult.Cases[3].HCViscosity;
        //            //ProcessInformationVM.OhcCase4 = ProcessInformationResult.Cases[3].HCSurfaceTension;
        //            //ProcessInformationVM.WwCase4 = ProcessInformationResult.Cases[3].WaterMassFlowRate;
        //            //ProcessInformationVM.PwCase4 = ProcessInformationResult.Cases[3].WaterMassDensity;
        //            //ProcessInformationVM.UwCase4 = ProcessInformationResult.Cases[3].WaterViscosity;
        //            //ProcessInformationVM.OwCase4 = ProcessInformationResult.Cases[3].WaterSurfaceTension;

        //            //ProcessInformationVM.WvCase5 = ProcessInformationResult.Cases[4].VaporMassFlowRate;
        //            //ProcessInformationVM.PvCase5 = ProcessInformationResult.Cases[4].VaporMassDensity;
        //            //ProcessInformationVM.UvCase5 = ProcessInformationResult.Cases[4].VaporViscosity;
        //            //ProcessInformationVM.MWvCase5 = ProcessInformationResult.Cases[4].VaporMolecularWeight;
        //            //ProcessInformationVM.WhcCase5 = ProcessInformationResult.Cases[4].HCMassFlowRate;
        //            //ProcessInformationVM.PhcCase5 = ProcessInformationResult.Cases[4].HCMassDensity;
        //            //ProcessInformationVM.UhcCase5 = ProcessInformationResult.Cases[4].HCViscosity;
        //            //ProcessInformationVM.OhcCase5 = ProcessInformationResult.Cases[4].HCSurfaceTension;
        //            //ProcessInformationVM.WwCase5 = ProcessInformationResult.Cases[4].WaterMassFlowRate;
        //            //ProcessInformationVM.PwCase5 = ProcessInformationResult.Cases[4].WaterMassDensity;
        //            //ProcessInformationVM.UwCase5 = ProcessInformationResult.Cases[4].WaterViscosity;
        //            //ProcessInformationVM.OwCase5 = ProcessInformationResult.Cases[4].WaterSurfaceTension;

        //            //separatorDesign.ProcessInfo.NumberOfCasesCreatedBeyondCaseOne = ProcessInformationResult.NumberOfCasesCreatedBeyondCaseOne;
        //            //ShowCases(separatorDesign.ProcessInfo.NumberOfCasesCreatedBeyondCaseOne);

        //            //for (int i = 0; i < 5; i++)
        //            //{
        //            //    ProcessInformationVM.StatusCases[i] = ProcessInformationResult.Cases[i].isChecked;
        //            //}


        //            //for (int i = 0; i < 5; i++)
        //            //{
        //            //    EnableChecks(ProcessInformationResult.Cases[i].isChecked, i);
        //            //}

        //            //#endregion

        //            //SeparatorGeometry GeometryResult = separator.Geometry;
        //            //GeometryVM.DrumInsideDiameterMeasurementUnit = GeometryResult.DrumInsideDiameterMeasurementUnit.Symbol();
        //            //GeometryVM.InletDevicesCbx = GeometryResult.InletDevice.Name();
        //            //GeometryVM.InletNozzleInsideDiameterMeasurementUnit = GeometryResult.InletNozzleInsideDiameterMeasurementUnit.Symbol();
        //            //GeometryVM.InsideDiameterVaporOutletNozzleUnit = GeometryResult.VaporOutletNozzleInsideDiameterMeasurementUnit.Symbol();
        //            //GeometryVM.InsideDiameterLiquidOutletNozzleUnit = GeometryResult.LiquidOutletNozzleInsideDiameterMeasurementUnit.Symbol();

        //            //GeometryVM.DrumInsideDiameter = GeometryResult.DrumInsideDiameter;
        //            //GeometryVM.InletNozzleInsideDiameter = GeometryResult.InletNozzleInsideDiameter;
        //            //GeometryVM.HCInitialGuessForDropletSize = GeometryResult.HCInitialGuessForDropletSize;
        //            //GeometryVM.WaterInitialGuessForDropletSize = GeometryResult.WaterInitialGuessForDropletSize;
        //            //GeometryVM.InsideDiameterVaporOutletNozzle = GeometryResult.VaporOutletNozzleInsideDiameter;
        //            //GeometryVM.InsideDiameterLiquidOutletNozzle = GeometryResult.LiquidOutletNozzleInsideDiameter;
        //        }
        //        catch (Exception)
        //        {
        //            return;
        //        }

        //        MessageBox.Show(WarningMessage.FILEHASBEENOPENED, WarningMessage.SUCCESS, MessageBoxButton.OK, MessageBoxImage.None);
        //    }
        //}

        //private void EnableChecks(bool isChecked, int index) 
        //{
        //    switch (index)
        //    {
        //        case 0:
        //            ProcessInformationVM.IsCheckedChk1 = isChecked;
        //            ProcessInformationVM.IsEnabledGrid1 = isChecked;
        //            break;
        //        case 1:
        //            ProcessInformationVM.IsCheckedChk2 = isChecked;
        //            ProcessInformationVM.IsEnabledGrid2 = isChecked;
        //            break;
        //        case 2:
        //            ProcessInformationVM.IsCheckedChk3 = isChecked;
        //            ProcessInformationVM.IsEnabledGrid3 = isChecked;
        //            break;
        //        case 3:
        //            ProcessInformationVM.IsCheckedChk4 = isChecked;
        //            ProcessInformationVM.IsEnabledGrid4 = isChecked;
        //            break;
        //        case 4:
        //            ProcessInformationVM.IsCheckedChk5 = isChecked;
        //            ProcessInformationVM.IsEnabledGrid5 = isChecked;
        //            break;
        //    }
        //}

        //private void ShowCases(int numberOfCasesCreatedBeyondCaseOne) 
        //{
        //    ShowCase1();
        //    switch(numberOfCasesCreatedBeyondCaseOne)
        //    {
        //        case 1:
        //            ShowCase2();
        //            break;
        //        case 2:
        //            ShowCase2();
        //            ShowCase3();
        //            break;
        //        case 3:
        //            ShowCase2();
        //            ShowCase3();
        //            ShowCase4();
        //            break;
        //        case 4:
        //            ShowCase2();
        //            ShowCase3();
        //            ShowCase4();
        //            ShowCase5();
        //            ProcessInformationVM.IsEnabledAddColumnButton = false;
        //            break;
        //    }
        //}

        //private void SaveFile()
        //{
        //    FileViewModel.Save(this.aluno.ToJson());
        //}

        //private void SaveFileAs()
        //{
        //    FileViewModel.SaveAs(this.aluno.ToJson());               
        //}

        //private void ClearFile()
        //{
        //    //OutputVM.TabSelectedIndex = 0;
        //    TabControlSelectedIndex = 0;

        //    ClearAllInputs();
   
        //    OutputVM.ClearAllOutputs();

        //    SetDefaultValuesDesignGeometryParameters();

        //}

        //private void ClearAllInputs()
        //{
        //    //for (int i = 0; i < 5; i++)
        //    //{
        //    //    separatorDesign.ProcessInfo.Cases.Add(new SeparatorProcessDesignCase());
        //    //}

        //    ClearGeneralInformationTab();
        //    ClearProcessInformationTab();
        //    ClearGeometryTabInputs();
        //}

        //private void ClearGeometryTabInputs()
        //{
        //    GeometryVM.DrumInsideDiameter = null;
        //    GeometryVM.InletNozzleInsideDiameter = null;
        //    GeometryVM.InsideDiameterVaporOutletNozzle = null;
        //    GeometryVM.InsideDiameterLiquidOutletNozzle = null;
        //    GeometryVM.SetDefaultValues();
            
        //}

        //private void ClearProcessInformationTab()
        //{
        //    ProcessInformationVM.Pressure = null;
        //    ProcessInformationVM.Temperature = null;

        //    ProcessInformationVM.WvCase1 = null;
        //    ProcessInformationVM.PvCase1 = null;
        //    ProcessInformationVM.UvCase1 = null;
        //    ProcessInformationVM.MWvCase1 = null;
        //    ProcessInformationVM.WhcCase1 = null;
        //    ProcessInformationVM.PhcCase1 = null;
        //    ProcessInformationVM.UhcCase1 = null;
        //    ProcessInformationVM.OhcCase1 = null;
        //    ProcessInformationVM.WwCase1 = null;
        //    ProcessInformationVM.PwCase1 = null;
        //    ProcessInformationVM.UwCase1 = null;
        //    ProcessInformationVM.OwCase1 = null;

        //    ProcessInformationVM.WvCase2 = null;
        //    ProcessInformationVM.PvCase2 = null;
        //    ProcessInformationVM.UvCase2 = null;
        //    ProcessInformationVM.MWvCase2 = null;
        //    ProcessInformationVM.WhcCase2 = null;
        //    ProcessInformationVM.PhcCase2 = null;
        //    ProcessInformationVM.UhcCase2 = null;
        //    ProcessInformationVM.OhcCase2 = null;
        //    ProcessInformationVM.WwCase2 = null;
        //    ProcessInformationVM.PwCase2 = null;
        //    ProcessInformationVM.UwCase2 = null;
        //    ProcessInformationVM.OwCase2 = null;

        //    ProcessInformationVM.WvCase3 = null;
        //    ProcessInformationVM.PvCase3 = null;
        //    ProcessInformationVM.UvCase3 = null;
        //    ProcessInformationVM.MWvCase3 = null;
        //    ProcessInformationVM.WhcCase3 = null;
        //    ProcessInformationVM.PhcCase3 = null;
        //    ProcessInformationVM.UhcCase3 = null;
        //    ProcessInformationVM.OhcCase3 = null;
        //    ProcessInformationVM.WwCase3 = null;
        //    ProcessInformationVM.PwCase3 = null;
        //    ProcessInformationVM.UwCase3 = null;
        //    ProcessInformationVM.OwCase3 = null;

        //    ProcessInformationVM.WvCase4 = null;
        //    ProcessInformationVM.PvCase4 = null;
        //    ProcessInformationVM.UvCase4 = null;
        //    ProcessInformationVM.MWvCase4 = null;
        //    ProcessInformationVM.WhcCase4 = null;
        //    ProcessInformationVM.PhcCase4 = null;
        //    ProcessInformationVM.UhcCase4 = null;
        //    ProcessInformationVM.OhcCase4 = null;
        //    ProcessInformationVM.WwCase4 = null;
        //    ProcessInformationVM.PwCase4 = null;
        //    ProcessInformationVM.UwCase4 = null;
        //    ProcessInformationVM.OwCase4 = null;

        //    ProcessInformationVM.WvCase5 = null;
        //    ProcessInformationVM.PvCase5 = null;
        //    ProcessInformationVM.UvCase5 = null;
        //    ProcessInformationVM.MWvCase5 = null;
        //    ProcessInformationVM.WhcCase5 = null;
        //    ProcessInformationVM.PhcCase5 = null;
        //    ProcessInformationVM.UhcCase5 = null;
        //    ProcessInformationVM.OhcCase5 = null;
        //    ProcessInformationVM.WwCase5 = null;
        //    ProcessInformationVM.PwCase5 = null;
        //    ProcessInformationVM.UwCase5 = null;
        //    ProcessInformationVM.OwCase5 = null;

        //    separatorDesign.ProcessInfo.NumberOfCasesCreatedBeyondCaseOne = 0;
        //    ResetCases();
        //}

        //private void ClearGeneralInformationTab()
        //{
        //    //GeneralInformationVM.NomeAluno = null;
        //    //GeneralInformationVM.EmailAluno = null;
        //    //GeneralInformationVM.TelefoneAluno = null;
        //    //GeneralInformationVM.NomeResponsavel1 = null;
        //    //GeneralInformationVM.EmailResponsavel1 = null;
        //    //GeneralInformationVM.TelefoneResponsavel1 = null;
        //    //GeneralInformationVM.NomeResponsavel2 = null;
        //    //GeneralInformationVM.EmailResponsavel2 = null;
        //    //GeneralInformationVM.TelefoneResponsavel2 = null;
        //    GeneralInformationVM.Nome = null;
        //    GeneralInformationVM.Contato = null;
        //    GeneralInformationVM.Turma = null;
        //    GeneralInformationVM.Ano = null;
        //    GeneralInformationVM.Semestre = null;
        //    GeneralInformationVM.Nota1 = null;
        //    GeneralInformationVM.Nota2 = null;
        //    GeneralInformationVM.Nota3 = null;
        //    GeneralInformationVM.Media = null;
        //    GeneralInformationVM.StatusCertificado = null;
        //}

        //private void ResetCases() {
        //    ProcessInformationVM.VisibilityChk1 = VISIBLE;
        //    ProcessInformationVM.VisibilityGrid1 = VISIBLE;
        //    ProcessInformationVM.IsEnabledGrid1 = true;
        //    ProcessInformationVM.IsCheckedChk1 = true;
        //    ProcessInformationVM.VisibilityChk2 = HIDDEN;
        //    ProcessInformationVM.VisibilityGrid2 = HIDDEN;
        //    ProcessInformationVM.IsEnabledGrid2 = true;
        //    ProcessInformationVM.IsCheckedChk2 = false;
        //    ProcessInformationVM.VisibilityChk3 = HIDDEN;
        //    ProcessInformationVM.VisibilityGrid3 = HIDDEN;
        //    ProcessInformationVM.IsEnabledGrid3 = true;
        //    ProcessInformationVM.IsCheckedChk3 = false;
        //    ProcessInformationVM.VisibilityChk4 = HIDDEN;
        //    ProcessInformationVM.VisibilityGrid4 = HIDDEN;
        //    ProcessInformationVM.IsEnabledGrid4 = true;
        //    ProcessInformationVM.IsCheckedChk4 = false;
        //    ProcessInformationVM.VisibilityChk5 = HIDDEN;
        //    ProcessInformationVM.VisibilityGrid5 = HIDDEN;
        //    ProcessInformationVM.IsEnabledGrid5 = true;
        //    ProcessInformationVM.IsCheckedChk5 = false;
        //    ProcessInformationVM.IsEnabledAddColumnButton = true;
        //    ProcessInformationVM.StatusCases = new bool[] { true, false, false, false, false };
        //}

        //private void ShowCase1() {
        //    ProcessInformationVM.VisibilityChk1 = VISIBLE;
        //    ProcessInformationVM.VisibilityGrid1 = VISIBLE;
        //}

        //private void ShowCase2() { 
        //    ProcessInformationVM.VisibilityChk2 = VISIBLE;
        //    ProcessInformationVM.VisibilityGrid2 = VISIBLE;
        //}

        //private void ShowCase3() { 
        //    ProcessInformationVM.VisibilityChk3 = VISIBLE;
        //    ProcessInformationVM.VisibilityGrid3 = VISIBLE;
        //}

        //private void ShowCase4() { 
        //    ProcessInformationVM.VisibilityChk4 = VISIBLE;
        //    ProcessInformationVM.VisibilityGrid4 = VISIBLE;
        //}

        //private void ShowCase5() { 
        //    ProcessInformationVM.VisibilityChk5 = VISIBLE;
        //    ProcessInformationVM.VisibilityGrid5 = VISIBLE;
        //}

        //private int _tabControlSelectedIndex;

        //public int TabControlSelectedIndex
        //{
        //    get { return _tabControlSelectedIndex; }
        //    set
        //    {
        //        _tabControlSelectedIndex = value;
        //        RaisePropertyChangedEvent("TabControlSelectedIndex");
        //    }
        //}

        //private bool _tabControlSelectedGeometry;

        //public bool TabControlSelectedGeometry
        //{
        //    get { return _tabControlSelectedGeometry; }
        //    set
        //    {
        //        _tabControlSelectedGeometry = value;
        //        if (value == true)
        //        {
        //            GeometryVM.GenerateAllGeometryOutput();

        //        }
        //    }
        //}

        //private bool _tabControlSelectedOutputs;

        //public bool TabControlSelectedOutputs
        //{
        //    get { return _tabControlSelectedOutputs; }
        //    set
        //    {
        //        _tabControlSelectedOutputs = value;
        //        if (value == true)
        //        {
        //            OutputVM.GenerateAllOutputs(0);

        //        }
        //    }
        //}

        //private void SetDefaultValuesDesignGeometryParameters()
        //{

        //    separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleInsideDiameterNOTAcceptable = false;
        //    separatorDesign.ProcessInfo.Cases[1].LiquidOutletNozzleInsideDiameterNOTAcceptable = false;
        //    separatorDesign.ProcessInfo.Cases[2].LiquidOutletNozzleInsideDiameterNOTAcceptable = false;
        //    separatorDesign.ProcessInfo.Cases[3].LiquidOutletNozzleInsideDiameterNOTAcceptable = false;
        //    separatorDesign.ProcessInfo.Cases[4].LiquidOutletNozzleInsideDiameterNOTAcceptable = false;

        //    separatorDesign.ProcessInfo.Cases[0].HCDropletCutDiameterBadEstimateValue = false;
        //    separatorDesign.ProcessInfo.Cases[1].HCDropletCutDiameterBadEstimateValue = false;
        //    separatorDesign.ProcessInfo.Cases[2].HCDropletCutDiameterBadEstimateValue = false;
        //    separatorDesign.ProcessInfo.Cases[3].HCDropletCutDiameterBadEstimateValue = false;
        //    separatorDesign.ProcessInfo.Cases[4].HCDropletCutDiameterBadEstimateValue = false;

        //    separatorDesign.ProcessInfo.Cases[0].WaterDropletCutDiameterBadEstimateValue = false;
        //    separatorDesign.ProcessInfo.Cases[1].WaterDropletCutDiameterBadEstimateValue = false;
        //    separatorDesign.ProcessInfo.Cases[2].WaterDropletCutDiameterBadEstimateValue = false;
        //    separatorDesign.ProcessInfo.Cases[3].WaterDropletCutDiameterBadEstimateValue = false;
        //    separatorDesign.ProcessInfo.Cases[4].WaterDropletCutDiameterBadEstimateValue = false;

        //    separatorDesign.Geometry.InletDevice = InletDevices.InletVaneDiffuser;
        //    separatorDesign.Geometry.HCInitialGuessForDropletSize = 300;
        //    separatorDesign.Geometry.WaterInitialGuessForDropletSize = 300;
        //}

        #endregion
    }
}
