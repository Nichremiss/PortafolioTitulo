﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoladePruebas.Medico {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Medico.IMedico")]
    public interface IMedico {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMedico/ValidarLoginMedico", ReplyAction="http://tempuri.org/IMedico/ValidarLoginMedicoResponse")]
        bool ValidarLoginMedico(CentroMedico.Datos.MedicoEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMedico/ValidarLoginMedico", ReplyAction="http://tempuri.org/IMedico/ValidarLoginMedicoResponse")]
        System.Threading.Tasks.Task<bool> ValidarLoginMedicoAsync(CentroMedico.Datos.MedicoEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMedico/InsertarMedico", ReplyAction="http://tempuri.org/IMedico/InsertarMedicoResponse")]
        bool InsertarMedico(CentroMedico.Datos.MedicoEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMedico/InsertarMedico", ReplyAction="http://tempuri.org/IMedico/InsertarMedicoResponse")]
        System.Threading.Tasks.Task<bool> InsertarMedicoAsync(CentroMedico.Datos.MedicoEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMedico/ObtenerMedico", ReplyAction="http://tempuri.org/IMedico/ObtenerMedicoResponse")]
        string ObtenerMedico();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMedico/ObtenerMedico", ReplyAction="http://tempuri.org/IMedico/ObtenerMedicoResponse")]
        System.Threading.Tasks.Task<string> ObtenerMedicoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMedicoChannel : ConsoladePruebas.Medico.IMedico, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MedicoClient : System.ServiceModel.ClientBase<ConsoladePruebas.Medico.IMedico>, ConsoladePruebas.Medico.IMedico {
        
        public MedicoClient() {
        }
        
        public MedicoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MedicoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MedicoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MedicoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidarLoginMedico(CentroMedico.Datos.MedicoEnt entidad) {
            return base.Channel.ValidarLoginMedico(entidad);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarLoginMedicoAsync(CentroMedico.Datos.MedicoEnt entidad) {
            return base.Channel.ValidarLoginMedicoAsync(entidad);
        }
        
        public bool InsertarMedico(CentroMedico.Datos.MedicoEnt entidad) {
            return base.Channel.InsertarMedico(entidad);
        }
        
        public System.Threading.Tasks.Task<bool> InsertarMedicoAsync(CentroMedico.Datos.MedicoEnt entidad) {
            return base.Channel.InsertarMedicoAsync(entidad);
        }
        
        public string ObtenerMedico() {
            return base.Channel.ObtenerMedico();
        }
        
        public System.Threading.Tasks.Task<string> ObtenerMedicoAsync() {
            return base.Channel.ObtenerMedicoAsync();
        }
    }
}