﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CentroMedico.Mvc.CajeroSvc {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CajeroSvc.ICajero")]
    public interface ICajero {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICajero/RecaudacionGeneral", ReplyAction="http://tempuri.org/ICajero/RecaudacionGeneralResponse")]
        string RecaudacionGeneral(string fecha_inicio, string fecha_fin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICajero/RecaudacionGeneral", ReplyAction="http://tempuri.org/ICajero/RecaudacionGeneralResponse")]
        System.Threading.Tasks.Task<string> RecaudacionGeneralAsync(string fecha_inicio, string fecha_fin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICajero/MuestraDatoReporte", ReplyAction="http://tempuri.org/ICajero/MuestraDatoReporteResponse")]
        CentroMedico.Datos.CajeroEnt MuestraDatoReporte(string fecha_inicio, string fecha_fin, string id_medico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICajero/MuestraDatoReporte", ReplyAction="http://tempuri.org/ICajero/MuestraDatoReporteResponse")]
        System.Threading.Tasks.Task<CentroMedico.Datos.CajeroEnt> MuestraDatoReporteAsync(string fecha_inicio, string fecha_fin, string id_medico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICajero/MuestraCalculoGral", ReplyAction="http://tempuri.org/ICajero/MuestraCalculoGralResponse")]
        CentroMedico.Datos.CajeroEnt MuestraCalculoGral(string fecha_inicio, string fecha_fin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICajero/MuestraCalculoGral", ReplyAction="http://tempuri.org/ICajero/MuestraCalculoGralResponse")]
        System.Threading.Tasks.Task<CentroMedico.Datos.CajeroEnt> MuestraCalculoGralAsync(string fecha_inicio, string fecha_fin);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICajeroChannel : CentroMedico.Mvc.CajeroSvc.ICajero, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CajeroClient : System.ServiceModel.ClientBase<CentroMedico.Mvc.CajeroSvc.ICajero>, CentroMedico.Mvc.CajeroSvc.ICajero {
        
        public CajeroClient() {
        }
        
        public CajeroClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CajeroClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CajeroClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CajeroClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string RecaudacionGeneral(string fecha_inicio, string fecha_fin) {
            return base.Channel.RecaudacionGeneral(fecha_inicio, fecha_fin);
        }
        
        public System.Threading.Tasks.Task<string> RecaudacionGeneralAsync(string fecha_inicio, string fecha_fin) {
            return base.Channel.RecaudacionGeneralAsync(fecha_inicio, fecha_fin);
        }
        
        public CentroMedico.Datos.CajeroEnt MuestraDatoReporte(string fecha_inicio, string fecha_fin, string id_medico) {
            return base.Channel.MuestraDatoReporte(fecha_inicio, fecha_fin, id_medico);
        }
        
        public System.Threading.Tasks.Task<CentroMedico.Datos.CajeroEnt> MuestraDatoReporteAsync(string fecha_inicio, string fecha_fin, string id_medico) {
            return base.Channel.MuestraDatoReporteAsync(fecha_inicio, fecha_fin, id_medico);
        }
        
        public CentroMedico.Datos.CajeroEnt MuestraCalculoGral(string fecha_inicio, string fecha_fin) {
            return base.Channel.MuestraCalculoGral(fecha_inicio, fecha_fin);
        }
        
        public System.Threading.Tasks.Task<CentroMedico.Datos.CajeroEnt> MuestraCalculoGralAsync(string fecha_inicio, string fecha_fin) {
            return base.Channel.MuestraCalculoGralAsync(fecha_inicio, fecha_fin);
        }
    }
}